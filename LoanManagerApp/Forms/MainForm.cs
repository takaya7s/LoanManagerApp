using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoanManagerApp.Domain;
using LoanManagerApp.Infrastructure;
using LoanManagerApp.Services;

namespace LoanManagerApp.Forms
{
    public sealed class MainForm : Form
    {
        private readonly AppSettings _settings;
        private readonly LoanRepository _repository;

        private DataGridView _loanGrid;
        private DataGridView _scheduleGrid;
        private CheckBox _chkRemainingOnly;
        private Button _btnFailure;
        private TextBox _txtDetails;
        private Label _lblScheduleSummary;
        private ToolStripStatusLabel _statusLabel;
        private SplitContainer _mainSplit;
        private long? _selectedLoanId;

        public MainForm(AppSettings settings, LoanRepository repository)
        {
            _settings = settings;
            _repository = repository;
            InitializeForm();
            CreateControls();
            Shown += delegate { ApplyMainSplitLayout(); };
            LoadLoanList(null);
        }

        private void InitializeForm()
        {
            Text = "ローン管理アプリ";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1360, 880);
            MinimumSize = new Size(1080, 700);
            AutoScaleMode = AutoScaleMode.Dpi;
            Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        }

        private void CreateControls()
        {
            TableLayoutPanel shell = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };
            shell.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            shell.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            shell.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            shell.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            Controls.Add(shell);

            ToolStrip toolbar = new ToolStrip
            {
                GripStyle = ToolStripGripStyle.Hidden,
                Padding = new Padding(6),
                ImageScalingSize = new Size(24, 24),
                Font = this.Font
            };
            ToolStripButton addButton = new ToolStripButton("新規登録");
            ToolStripButton editButton = new ToolStripButton("編集");
            ToolStripButton deleteButton = new ToolStripButton("削除");
            ToolStripButton refreshButton = new ToolStripButton("再読み込み");
            ToolStripButton openDataButton = new ToolStripButton("データ保存先");
            addButton.Click += AddLoan;
            editButton.Click += EditLoan;
            deleteButton.Click += DeleteLoan;
            refreshButton.Click += delegate { LoadLoanList(_selectedLoanId); };
            openDataButton.Click += OpenDataFolder;
            toolbar.Items.AddRange(new ToolStripItem[]
            {
                addButton,
                editButton,
                deleteButton,
                new ToolStripSeparator(),
                refreshButton,
                new ToolStripSeparator(),
                openDataButton
            });

            _mainSplit = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal
            };
            shell.Controls.Add(_mainSplit, 0, 1);

            _loanGrid = CreateGrid();
            ConfigureLoanGrid(_loanGrid);
            _loanGrid.SelectionChanged += LoanSelectionChanged;
            _loanGrid.CellDoubleClick += delegate { EditLoan(this, EventArgs.Empty); };
            _mainSplit.Panel1.Controls.Add(_loanGrid);

            TabControl tabs = new TabControl { Dock = DockStyle.Fill };
            TabPage scheduleTab = new TabPage("返済スケジュール");
            TabPage detailTab = new TabPage("ローン詳細");
            tabs.TabPages.Add(scheduleTab);
            tabs.TabPages.Add(detailTab);
            _mainSplit.Panel2.Controls.Add(tabs);

            TableLayoutPanel scheduleRoot = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 1,
                Padding = new Padding(8)
            };
            scheduleRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            scheduleRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            scheduleRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            scheduleTab.Controls.Add(scheduleRoot);

            FlowLayoutPanel scheduleTools = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                WrapContents = false
            };
            _chkRemainingOnly = new CheckBox
            {
                Text = "残りの返済のみ表示",
                Checked = true,
                AutoSize = true,
                Margin = new Padding(3, 8, 16, 3)
            };
            _chkRemainingOnly.CheckedChanged += delegate { LoadSelectedSchedule(); };
            _btnFailure = new Button
            {
                Text = "入金失敗を登録",
                AutoSize = true,
                MinimumSize = new Size(160, 42)
            };
            _btnFailure.Click += TogglePaymentFailure;
            scheduleTools.Controls.Add(_chkRemainingOnly);
            scheduleTools.Controls.Add(_btnFailure);
            scheduleRoot.Controls.Add(scheduleTools, 0, 0);

            _scheduleGrid = CreateGrid();
            ConfigureScheduleGrid(_scheduleGrid);
            _scheduleGrid.SelectionChanged += ScheduleSelectionChanged;
            scheduleRoot.Controls.Add(_scheduleGrid, 0, 1);

            _lblScheduleSummary = new Label
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                Padding = new Padding(4, 8, 4, 0),
                Text = "ローンを選択してください。"
            };
            scheduleRoot.Controls.Add(_lblScheduleSummary, 0, 2);

            _txtDetails = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                BorderStyle = BorderStyle.None,
                BackColor = SystemColors.Window,
                Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point),
                Padding = new Padding(12)
            };
            detailTab.Controls.Add(_txtDetails);

            StatusStrip status = new StatusStrip
            {
                Font = this.Font
            };
            _statusLabel = new ToolStripStatusLabel
            {
                Spring = true,
                TextAlign = ContentAlignment.MiddleLeft
            };
            status.Items.Add(_statusLabel);
            toolbar.Dock = DockStyle.Fill;
            status.Dock = DockStyle.Fill;
            shell.Controls.Add(toolbar, 0, 0);
            shell.Controls.Add(status, 0, 2);

        }

        private void ApplyMainSplitLayout()
        {
            if (_mainSplit == null || _mainSplit.IsDisposed)
            {
                return;
            }

            int availableHeight = _mainSplit.ClientSize.Height - _mainSplit.SplitterWidth;
            if (availableHeight <= 0)
            {
                return;
            }

            const int desiredPanel1MinSize = 180;
            const int desiredPanel2MinSize = 260;
            const int desiredSplitterDistance = 280;

            int panel1MinSize = desiredPanel1MinSize;
            int panel2MinSize = desiredPanel2MinSize;

            // 高DPIや小さい画面でも、最小サイズの合計が実際の高さを超えないようにする。
            if (panel1MinSize + panel2MinSize > availableHeight)
            {
                panel1MinSize = Math.Min(desiredPanel1MinSize, availableHeight / 2);
                panel2MinSize = Math.Max(0, availableHeight - panel1MinSize);
            }

            int minimumDistance = panel1MinSize;
            int maximumDistance = availableHeight - panel2MinSize;
            int splitterDistance = Math.Max(
                minimumDistance,
                Math.Min(desiredSplitterDistance, maximumDistance));

            // SplitContainerの既定サイズ中に最小サイズを設定すると例外になるため、
            // 表示後の実サイズに対して、先に有効な分割位置を設定する。
            _mainSplit.Panel1MinSize = 0;
            _mainSplit.Panel2MinSize = 0;
            _mainSplit.SplitterDistance = splitterDistance;
            _mainSplit.Panel1MinSize = panel1MinSize;
            _mainSplit.Panel2MinSize = panel2MinSize;
        }

        private void LoadLoanList(long? selectLoanId)
        {
            try
            {
                IList<LoanListItem> items = _repository.GetLoanListItems(DateTime.Today);
                _loanGrid.DataSource = items.ToList();
                _statusLabel.Text = string.Format(
                    "登録ローン: {0}件　　ログ: {1}",
                    items.Count,
                    Logger.LogFilePath);

                if (items.Count == 0)
                {
                    _selectedLoanId = null;
                    _scheduleGrid.DataSource = null;
                    _txtDetails.Clear();
                    _lblScheduleSummary.Text = "ローンを新規登録してください。";
                    return;
                }

                long targetId = selectLoanId ?? items[0].Id;
                SelectLoanRow(targetId);
            }
            catch (Exception ex)
            {
                Logger.Error("ローン一覧の読み込みに失敗しました。", ex);
                ShowError("ローン一覧を読み込めませんでした。", ex);
            }
        }

        private void SelectLoanRow(long loanId)
        {
            foreach (DataGridViewRow row in _loanGrid.Rows)
            {
                LoanListItem item = row.DataBoundItem as LoanListItem;
                if (item != null && item.Id == loanId)
                {
                    row.Selected = true;
                    _loanGrid.CurrentCell = row.Cells[1];
                    return;
                }
            }

            if (_loanGrid.Rows.Count > 0)
            {
                _loanGrid.Rows[0].Selected = true;
                _loanGrid.CurrentCell = _loanGrid.Rows[0].Cells[1];
            }
        }

        private void LoanSelectionChanged(object sender, EventArgs e)
        {
            LoanListItem item = GetSelectedLoanListItem();
            _selectedLoanId = item == null ? (long?)null : item.Id;
            LoadSelectedSchedule();
            LoadSelectedDetails();
        }

        private void LoadSelectedSchedule()
        {
            if (!_selectedLoanId.HasValue)
            {
                _scheduleGrid.DataSource = null;
                return;
            }

            try
            {
                IList<RepaymentScheduleItem> fullSchedule = _repository.GetSchedule(_selectedLoanId.Value);
                IEnumerable<RepaymentScheduleItem> displaySchedule = fullSchedule;
                if (_chkRemainingOnly.Checked)
                {
                    displaySchedule = displaySchedule.Where(
                        x => x.PaymentDate.Date >= DateTime.Today || x.IsPaymentFailed);
                }

                List<ScheduleViewItem> views = displaySchedule
                    .Select(CreateScheduleViewItem)
                    .ToList();
                _scheduleGrid.DataSource = views;

                long totalPrincipal = fullSchedule.Sum(x => x.RepaymentAmount);
                long totalInterest = fullSchedule.Sum(x => x.InterestAmount);
                long totalPayment = fullSchedule.Sum(x => x.PaymentAmount);
                int remainingCount = fullSchedule.Count(
                    x => x.PaymentDate.Date >= DateTime.Today || x.IsPaymentFailed);
                _lblScheduleSummary.Text = string.Format(
                    "返済額（元金）合計: {0:N0}円　利息合計: {1:N0}円　総お支払い額: {2:N0}円　残回数: {3}回\r\n" +
                    "※返済額は残高から減る元金、お支払い額は返済額＋利息です。ボーナス月はボーナス分も含みます。",
                    totalPrincipal,
                    totalInterest,
                    totalPayment,
                    remainingCount);
                ScheduleSelectionChanged(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Logger.Error("返済スケジュールの読み込みに失敗しました。", ex);
                ShowError("返済スケジュールを読み込めませんでした。", ex);
            }
        }

        private void LoadSelectedDetails()
        {
            if (!_selectedLoanId.HasValue)
            {
                _txtDetails.Clear();
                return;
            }

            try
            {
                Loan loan = _repository.GetLoan(_selectedLoanId.Value);
                if (loan == null)
                {
                    _txtDetails.Clear();
                    return;
                }

                IList<RepaymentScheduleItem> schedule = _repository.GetSchedule(loan.Id);
                long firstRepaymentAmount = schedule.Count > 0 ? schedule[0].RepaymentAmount : 0;
                long firstPaymentAmount = schedule.Count > 0 ? schedule[0].PaymentAmount : 0;
                long maximumPaymentAmount = schedule.Count > 0
                    ? schedule.Max(x => x.PaymentAmount)
                    : 0;
                long totalRepaymentAmount = schedule.Sum(x => x.RepaymentAmount);
                long totalInterestAmount = schedule.Sum(x => x.InterestAmount);
                long totalPaymentAmount = schedule.Sum(x => x.PaymentAmount);

                StringBuilder builder = new StringBuilder();
                builder.AppendLine("ローン名称　　　　" + loan.Name);
                builder.AppendLine("借入額　　　　　　" + loan.PrincipalAmount.ToString("N0") + "円");
                builder.AppendLine("年間金利　　　　　" + FormatInterestRate(loan.AnnualInterestRate) + "%");
                builder.AppendLine("返済方式　　　　　" + DisplayText.RepaymentType(loan.RepaymentType));
                builder.AppendLine("利息計算　　　　　" + DisplayText.InterestMethod(loan.InterestCalculationMethod));
                builder.AppendLine("借入日　　　　　　" + loan.BorrowDate.ToString("yyyy年MM月dd日"));
                builder.AppendLine("初回返済日　　　　" + loan.FirstRepaymentDate.ToString("yyyy年MM月dd日"));
                builder.AppendLine("返済条件　　　　　" + DisplayText.RepaymentSetting(loan.RepaymentSettingMode));
                if (loan.RepaymentSettingMode == RepaymentSettingMode.ByMonthlyPayment &&
                    loan.RepaymentType != RepaymentType.LumpSum)
                {
                    string configuredAmountLabel = loan.RepaymentType == RepaymentType.EqualPrincipal
                        ? "設定元金返済額　　"
                        : "設定お支払い額　　";
                    builder.AppendLine(
                        configuredAmountLabel +
                        loan.DesiredMonthlyPaymentAmount.ToString("N0") +
                        "円");
                    builder.AppendLine("算出返済期間　　　" + FormatPeriod(loan.RepaymentMonths));
                }
                else
                {
                    builder.AppendLine("返済期間　　　　　" + FormatPeriod(loan.RepaymentMonths));
                }
                builder.AppendLine("毎月の返済日　　　" + loan.MonthlyPaymentDay + "日");
                builder.AppendLine("初回返済額（元金）" + firstRepaymentAmount.ToString("N0") + "円");
                builder.AppendLine("初回お支払い額　　" + firstPaymentAmount.ToString("N0") + "円");
                builder.AppendLine("最大お支払い額　　" + maximumPaymentAmount.ToString("N0") + "円");
                builder.AppendLine("総返済額（元金）　" + totalRepaymentAmount.ToString("N0") + "円");
                builder.AppendLine("利息合計　　　　　" + totalInterestAmount.ToString("N0") + "円");
                builder.AppendLine("総お支払い額　　　" + totalPaymentAmount.ToString("N0") + "円");
                builder.AppendLine("ボーナス払い　　　" + DisplayText.BonusPayment(loan.UseBonusPayment));

                if (loan.UseBonusPayment)
                {
                    builder.AppendLine("ボーナス対象元金　" + loan.BonusPrincipalAmount.ToString("N0") + "円");
                    builder.AppendLine("ボーナス払い月　　" + loan.BonusMonth1 + "月・" + loan.BonusMonth2 + "月");
                }

                builder.AppendLine("登録日時　　　　　" + loan.CreatedAt.ToString("yyyy年MM月dd日 HH:mm:ss"));
                builder.AppendLine("更新日時　　　　　" + loan.UpdatedAt.ToString("yyyy年MM月dd日 HH:mm:ss"));
                builder.AppendLine();
                builder.AppendLine("メモ");
                builder.AppendLine(string.IsNullOrWhiteSpace(loan.Memo) ? "（なし）" : loan.Memo);
                _txtDetails.Text = builder.ToString();
            }
            catch (Exception ex)
            {
                Logger.Error("ローン詳細の読み込みに失敗しました。", ex);
                ShowError("ローン詳細を読み込めませんでした。", ex);
            }
        }

        private void AddLoan(object sender, EventArgs e)
        {
            using (LoanEditForm form = new LoanEditForm(_settings, null))
            {
                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    long id = _repository.SaveLoan(form.ResultLoan, form.ResultSchedule);
                    Logger.Info("ローンを登録しました。LoanId=" + id);
                    LoadLoanList(id);
                }
                catch (Exception ex)
                {
                    Logger.Error("ローンの登録に失敗しました。", ex);
                    ShowError("ローンを登録できませんでした。", ex);
                }
            }
        }

        private void EditLoan(object sender, EventArgs e)
        {
            LoanListItem selected = GetSelectedLoanListItem();
            if (selected == null)
            {
                return;
            }

            try
            {
                Loan loan = _repository.GetLoan(selected.Id);
                if (loan == null)
                {
                    MessageBox.Show(this, "選択したローンが見つかりません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadLoanList(null);
                    return;
                }

                using (LoanEditForm form = new LoanEditForm(_settings, loan))
                {
                    if (form.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }

                    DialogResult confirm = MessageBox.Show(
                        this,
                        "保存すると返済スケジュールを再計算します。\r\n同じ返済回数の入金失敗情報は引き継がれます。保存しますか？",
                        "編集内容の保存",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (confirm != DialogResult.Yes)
                    {
                        return;
                    }

                    _repository.SaveLoan(form.ResultLoan, form.ResultSchedule);
                    Logger.Info("ローンを更新しました。LoanId=" + selected.Id);
                    LoadLoanList(selected.Id);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("ローンの編集に失敗しました。", ex);
                ShowError("ローンを編集できませんでした。", ex);
            }
        }

        private void DeleteLoan(object sender, EventArgs e)
        {
            LoanListItem selected = GetSelectedLoanListItem();
            if (selected == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show(
                this,
                "「" + selected.Name + "」と返済スケジュールを削除します。\r\nこの操作は元に戻せません。",
                "ローンの削除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _repository.DeleteLoan(selected.Id);
                Logger.Info("ローンを削除しました。LoanId=" + selected.Id);
                LoadLoanList(null);
            }
            catch (Exception ex)
            {
                Logger.Error("ローンの削除に失敗しました。", ex);
                ShowError("ローンを削除できませんでした。", ex);
            }
        }

        private void TogglePaymentFailure(object sender, EventArgs e)
        {
            ScheduleViewItem selected = GetSelectedScheduleViewItem();
            if (selected == null)
            {
                MessageBox.Show(this, "返済スケジュールを選択してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (selected.IsPaymentFailed)
                {
                    DialogResult resolve = MessageBox.Show(
                        this,
                        "入金失敗を解消済みにしますか？",
                        "入金失敗の解消",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (resolve == DialogResult.Yes)
                    {
                        _repository.ResolvePaymentFailure(selected.Id);
                        Logger.Info("入金失敗を解消しました。ScheduleId=" + selected.Id);
                    }
                }
                else
                {
                    using (PaymentFailureForm form = new PaymentFailureForm(selected.FailureNote))
                    {
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            _repository.RegisterPaymentFailure(selected.Id, form.FailureNote);
                            Logger.Info("入金失敗を登録しました。ScheduleId=" + selected.Id);
                        }
                    }
                }

                LoadLoanList(_selectedLoanId);
            }
            catch (Exception ex)
            {
                Logger.Error("入金失敗情報の更新に失敗しました。", ex);
                ShowError("入金失敗情報を更新できませんでした。", ex);
            }
        }

        private void ScheduleSelectionChanged(object sender, EventArgs e)
        {
            ScheduleViewItem selected = GetSelectedScheduleViewItem();
            if (selected == null)
            {
                _btnFailure.Enabled = false;
                _btnFailure.Text = "入金失敗を登録";
                return;
            }

            _btnFailure.Enabled = true;
            _btnFailure.Text = selected.IsPaymentFailed ? "入金失敗を解消" : "入金失敗を登録";
        }

        private void OpenDataFolder(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", AppPaths.RootDirectory);
            }
            catch (Exception ex)
            {
                Logger.Error("データ保存先を開けませんでした。", ex);
                ShowError("データ保存先を開けませんでした。", ex);
            }
        }

        private LoanListItem GetSelectedLoanListItem()
        {
            if (_loanGrid.CurrentRow == null)
            {
                return null;
            }
            return _loanGrid.CurrentRow.DataBoundItem as LoanListItem;
        }

        private ScheduleViewItem GetSelectedScheduleViewItem()
        {
            if (_scheduleGrid.CurrentRow == null)
            {
                return null;
            }
            return _scheduleGrid.CurrentRow.DataBoundItem as ScheduleViewItem;
        }

        private static DataGridView CreateGrid()
        {
            DataGridView grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = false,
                RowHeadersVisible = false,
                BackgroundColor = SystemColors.Window,
                BorderStyle = BorderStyle.Fixed3D,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                ColumnHeadersHeight = 40,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
            };
            grid.RowTemplate.Height = 34;
            return grid;
        }

        private void ConfigureLoanGrid(DataGridView grid)
        {
            grid.Columns.Add(TextColumn("Name", "ローン名称", 190));
            grid.Columns.Add(TextColumn("RepaymentTypeName", "返済方式", 170));
            grid.Columns.Add(TextColumn("BonusPaymentName", "ボーナス払い", 105));
            grid.Columns.Add(NumberColumn("PrincipalAmount", "借入額", 120, "#,##0円"));
            grid.Columns.Add(NumberColumn(
                "AnnualInterestRate",
                "年利(%)",
                75,
                CreateInterestRateFormat()));
            grid.Columns.Add(DateColumn("NextPaymentDate", "次回返済日", 110));
            DataGridViewTextBoxColumn nextPaymentColumn = NumberColumn(
                "NextPaymentAmount",
                "お支払い額",
                120,
                "#,##0円");
            nextPaymentColumn.ToolTipText = "次回返済日に支払う予定額です。";
            grid.Columns.Add(nextPaymentColumn);
            grid.Columns.Add(NumberColumn("RemainingBalance", "推定残高", 120, "#,##0円"));
            grid.Columns.Add(NumberColumn("RemainingPaymentCount", "残回数", 75, "#,##0回"));
            grid.Columns.Add(NumberColumn("TotalPaymentAmount", "総お支払い額", 135, "#,##0円"));
        }

        private static void ConfigureScheduleGrid(DataGridView grid)
        {
            grid.Columns.Add(NumberColumn("PaymentNumber", "回", 55, "0"));
            grid.Columns.Add(TextColumn("TargetMonthText", "返済対象月", 100));
            grid.Columns.Add(TextColumn("BaseDueDateText", "調整前", 100));
            grid.Columns.Add(TextColumn("PaymentDateText", "返済予定日", 105));
            DataGridViewTextBoxColumn repaymentColumn = NumberColumn(
                "RepaymentAmount",
                "返済額（元金）",
                135,
                "#,##0円");
            repaymentColumn.ToolTipText = "その回に返済する元金。残高から減る金額です。";
            grid.Columns.Add(repaymentColumn);

            DataGridViewTextBoxColumn paymentColumn = NumberColumn(
                "PaymentAmount",
                "お支払い額",
                125,
                "#,##0円");
            paymentColumn.ToolTipText = "返済額（元金）と利息の合計。ボーナス月はボーナス分も含みます。";
            grid.Columns.Add(paymentColumn);
            grid.Columns.Add(NumberColumn("InterestAmount", "利息", 100, "#,##0円"));
            grid.Columns.Add(NumberColumn("RemainingBalance", "残高", 115, "#,##0円"));
            grid.Columns.Add(TextColumn("Status", "状態", 90));
            grid.Columns.Add(TextColumn("FailureNote", "入金失敗メモ", 220));
        }

        private static DataGridViewTextBoxColumn TextColumn(string propertyName, string header, int width)
        {
            return new DataGridViewTextBoxColumn
            {
                DataPropertyName = propertyName,
                HeaderText = header,
                Width = width,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
        }

        private static DataGridViewTextBoxColumn NumberColumn(
            string propertyName,
            string header,
            int width,
            string format)
        {
            DataGridViewTextBoxColumn column = TextColumn(propertyName, header, width);
            column.DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleRight,
                Format = format
            };
            return column;
        }

        private static DataGridViewTextBoxColumn DateColumn(string propertyName, string header, int width)
        {
            DataGridViewTextBoxColumn column = TextColumn(propertyName, header, width);
            column.DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Format = "yyyy/MM/dd"
            };
            return column;
        }

        private static ScheduleViewItem CreateScheduleViewItem(RepaymentScheduleItem item)
        {
            string status;
            if (item.IsPaymentFailed)
            {
                status = "入金失敗";
            }
            else if (item.PaymentDate.Date < DateTime.Today)
            {
                status = "経過済み";
            }
            else if (item.PaymentDate.Date == DateTime.Today)
            {
                status = "返済日";
            }
            else
            {
                status = "予定";
            }

            return new ScheduleViewItem
            {
                Id = item.Id,
                PaymentNumber = item.PaymentNumber,
                TargetMonthText = item.TargetMonth.ToString("yyyy年MM月"),
                BaseDueDateText = item.BaseDueDate.ToString("yyyy/MM/dd"),
                PaymentDateText = item.PaymentDate.ToString("yyyy/MM/dd"),
                RepaymentAmount = item.RepaymentAmount,
                PaymentAmount = item.PaymentAmount,
                InterestAmount = item.InterestAmount,
                RemainingBalance = item.RemainingBalance,
                Status = status,
                IsPaymentFailed = item.IsPaymentFailed,
                FailureNote = item.FailureNote
            };
        }

        private string FormatInterestRate(decimal value)
        {
            return value.ToString(CreateInterestRateFormat());
        }

        private string CreateInterestRateFormat()
        {
            int places = Math.Max(0, Math.Min(6, _settings.InterestRateDecimalPlaces));
            return places == 0 ? "0" : "0." + new string('#', places);
        }

        private static string FormatPeriod(int months)
        {
            int years = months / 12;
            int remainingMonths = months % 12;
            if (years == 0)
            {
                return remainingMonths + "か月";
            }
            if (remainingMonths == 0)
            {
                return years + "年";
            }
            return years + "年" + remainingMonths + "か月";
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show(
                this,
                message + "\r\n\r\n" + ex.Message + "\r\n\r\nログ: " + Logger.LogFilePath,
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private sealed class ScheduleViewItem
        {
            public long Id { get; set; }
            public int PaymentNumber { get; set; }
            public string TargetMonthText { get; set; }
            public string BaseDueDateText { get; set; }
            public string PaymentDateText { get; set; }
            public long RepaymentAmount { get; set; }
            public long PaymentAmount { get; set; }
            public long InterestAmount { get; set; }
            public long RemainingBalance { get; set; }
            public string Status { get; set; }
            public bool IsPaymentFailed { get; set; }
            public string FailureNote { get; set; }
        }
    }
}
