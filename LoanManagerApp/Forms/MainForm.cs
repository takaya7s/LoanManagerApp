using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    [DesignerCategory("Form")]
    public sealed partial class MainForm : Form
    {
        private readonly AppSettings _settings;
        private readonly LoanRepository _repository;

        private DateTime _simulationDate = DateTime.Today;
        private bool _updatingSimulationDate;
        private bool _loadingLoanList;
        private long? _selectedLoanId;

        // Visual Studioデザイナー用。アプリケーションからは使用しません。
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(AppSettings settings, LoanRepository repository)
            : this()
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            _colLoanAnnualInterestRate.DefaultCellStyle.Format = CreateInterestRateFormat();

            _updatingSimulationDate = true;
            try
            {
                _simulationDate = DateTime.Today;
                _dtpSimulationDate.Value = _simulationDate;
            }
            finally
            {
                _updatingSimulationDate = false;
            }

            UpdateSimulationVisualState();
            Shown += delegate { ApplyMainSplitLayout(); };
            LoadLoanList(null);
        }

        private void RefreshLoanList(object sender, EventArgs e)
        {
            if (_repository != null)
            {
                LoadLoanList(_selectedLoanId);
            }
        }

        private void LoanGridCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditLoan(sender, EventArgs.Empty);
            }
        }

        private void RemainingOnlyCheckedChanged(object sender, EventArgs e)
        {
            if (_repository != null)
            {
                LoadSelectedSchedule();
            }
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
                long? targetLoanId = selectLoanId ?? _selectedLoanId;
                IList<LoanListItem> items = _repository.GetLoanListItems(_simulationDate);

                _loadingLoanList = true;
                try
                {
                    _loanGrid.DataSource = items.ToList();
                    ApplyLoanRowStyles();
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
                    }
                    else
                    {
                        long targetId = targetLoanId.HasValue &&
                            items.Any(x => x.Id == targetLoanId.Value)
                            ? targetLoanId.Value
                            : items[0].Id;
                        SelectLoanRow(targetId);

                        LoanListItem selected = GetSelectedLoanListItem();
                        _selectedLoanId = selected == null ? (long?)null : selected.Id;
                    }
                }
                finally
                {
                    _loadingLoanList = false;
                }

                if (items.Count > 0)
                {
                    // DataSourceの再設定中にSelectionChangedが先頭行で発生しても、
                    // 復元したローンIDを基準に明細を明示的に再読み込みする。
                    LoadSelectedSchedule();
                    LoadSelectedDetails();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("ローン一覧の読み込みに失敗しました。", ex);
                ShowError("ローン一覧を読み込めませんでした。", ex);
            }
        }

        private void SelectLoanRow(long loanId)
        {
            _loanGrid.ClearSelection();

            DataGridViewRow targetRow = null;
            foreach (DataGridViewRow row in _loanGrid.Rows)
            {
                LoanListItem item = row.DataBoundItem as LoanListItem;
                if (item != null && item.Id == loanId)
                {
                    targetRow = row;
                    break;
                }
            }

            if (targetRow == null && _loanGrid.Rows.Count > 0)
            {
                targetRow = _loanGrid.Rows[0];
            }

            if (targetRow != null)
            {
                targetRow.Selected = true;
                if (targetRow.Cells.Count > 0)
                {
                    _loanGrid.CurrentCell = targetRow.Cells[0];
                }
            }
        }

        private void ApplyLoanRowStyles()
        {
            foreach (DataGridViewRow row in _loanGrid.Rows)
            {
                LoanListItem item = row.DataBoundItem as LoanListItem;
                if (item != null && item.IsCompleted)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
                    row.DefaultCellStyle.ForeColor = Color.DimGray;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = SystemColors.Window;
                    row.DefaultCellStyle.ForeColor = SystemColors.ControlText;
                }
            }
        }

        private void LoanSelectionChanged(object sender, EventArgs e)
        {
            if (_repository == null || _loadingLoanList)
            {
                return;
            }

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
                DateTime referenceDate = _simulationDate.Date;
                IList<RepaymentScheduleItem> fullSchedule = _repository.GetSchedule(_selectedLoanId.Value);
                IEnumerable<RepaymentScheduleItem> displaySchedule = fullSchedule;
                if (_chkRemainingOnly.Checked)
                {
                    displaySchedule = displaySchedule.Where(
                        x => x.PaymentDate.Date >= referenceDate || x.IsPaymentFailed);
                }

                List<ScheduleViewItem> views = displaySchedule
                    .Select(x => CreateScheduleViewItem(x, referenceDate))
                    .ToList();
                _scheduleGrid.DataSource = views;

                long totalPrincipal = fullSchedule.Sum(x => x.RepaymentAmount);
                long totalInterest = fullSchedule.Sum(x => x.InterestAmount);
                long totalPayment = fullSchedule.Sum(x => x.PaymentAmount);
                int remainingCount = fullSchedule.Count(
                    x => x.PaymentDate.Date >= referenceDate || x.IsPaymentFailed);
                string referenceDateText = IsSimulationActive()
                    ? "【日付シミュレーション基準日: " + referenceDate.ToString("yyyy年MM月dd日") + "】\r\n"
                    : string.Empty;
                _lblScheduleSummary.Text = referenceDateText + string.Format(
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
                builder.AppendLine("ボーナス払い　　　" + DisplayText.BonusPayment(loan.BonusPaymentFrequency));

                if (loan.UseBonusPayment)
                {
                    builder.AppendLine("ボーナス加算元金　" + loan.BonusPrincipalAmount.ToString("N0") + "円／回");
                    string bonusMonths = loan.BonusPaymentFrequency == BonusPaymentFrequency.OncePerYear
                        ? loan.BonusMonth1 + "月"
                        : loan.BonusMonth1 + "月・" + loan.BonusMonth2 + "月";
                    builder.AppendLine("ボーナス払い月　　" + bonusMonths);
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

        private void SimulationDateChanged(object sender, EventArgs e)
        {
            if (_updatingSimulationDate)
            {
                return;
            }

            _simulationDate = _dtpSimulationDate.Value.Date;
            UpdateSimulationVisualState();
            if (_repository != null)
            {
                LoadLoanList(_selectedLoanId);
            }
        }

        private void ResetSimulationDate(object sender, EventArgs e)
        {
            SetSimulationDate(DateTime.Today);
        }

        private void SetSimulationDate(DateTime date)
        {
            DateTime normalizedDate = date.Date;
            _updatingSimulationDate = true;
            try
            {
                _simulationDate = normalizedDate;
                _dtpSimulationDate.Value = normalizedDate;
            }
            finally
            {
                _updatingSimulationDate = false;
            }

            UpdateSimulationVisualState();
            if (_repository != null)
            {
                LoadLoanList(_selectedLoanId);
            }
        }

        private bool IsSimulationActive()
        {
            return _simulationDate.Date != DateTime.Today;
        }

        private void UpdateSimulationVisualState()
        {
            if (_simulationPanel == null || _lblSimulationState == null ||
                _btnResetSimulationDate == null || _scheduleTab == null)
            {
                return;
            }

            bool active = IsSimulationActive();
            if (active)
            {
                _lblSimulationState.Text = "● シミュレーション中";
                _lblSimulationState.ForeColor = Color.DarkRed;
                _simulationPanel.BackColor = Color.LightGoldenrodYellow;
                _scheduleTab.Text = "返済スケジュール【シミュレーション中】";
            }
            else
            {
                _lblSimulationState.Text = "本日基準";
                _lblSimulationState.ForeColor = SystemColors.ControlText;
                _simulationPanel.BackColor = SystemColors.Control;
                _scheduleTab.Text = "返済スケジュール";
            }

            _btnResetSimulationDate.Enabled = active;
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

        private static ScheduleViewItem CreateScheduleViewItem(
            RepaymentScheduleItem item,
            DateTime referenceDate)
        {
            string status;
            if (item.IsPaymentFailed)
            {
                status = "入金失敗";
            }
            else if (item.PaymentDate.Date < referenceDate.Date)
            {
                status = "経過済み";
            }
            else if (item.PaymentDate.Date == referenceDate.Date)
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
