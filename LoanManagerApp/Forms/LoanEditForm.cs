using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using LoanManagerApp.Domain;
using LoanManagerApp.Infrastructure;
using LoanManagerApp.Services;

namespace LoanManagerApp.Forms
{
    public sealed class LoanEditForm : Form
    {
        private readonly AppSettings _settings;
        private readonly Loan _sourceLoan;
        private readonly RepaymentCalculator _calculator;
        private Font _inputFont;

        private TextBox _txtName;
        private TextBox _txtPrincipal;
        private TextBox _txtRate;
        private ComboBox _cmbRepaymentType;
        private ComboBox _cmbInterestMethod;
        private DateTimePicker _dtpBorrowDate;
        private DateTimePicker _dtpFirstRepaymentDate;
        private ComboBox _cmbRepaymentSettingMode;
        private FlowLayoutPanel _pnlPeriod;
        private NumericUpDown _nudYears;
        private NumericUpDown _nudMonths;
        private NumericUpDown _nudDesiredMonthlyPayment;
        private Label _lblDesiredMonthlyAmount;
        private Label _lblMonthlyPaymentNote;
        private NumericUpDown _nudPaymentDay;
        private CheckBox _chkUseBonusPayment;
        private GroupBox _grpBonus;
        private NumericUpDown _nudBonusPrincipal;
        private ComboBox _cmbBonusMonth1;
        private ComboBox _cmbBonusMonth2;
        private TextBox _txtMemo;
        private Label _lblPreview;

        public Loan ResultLoan { get; private set; }
        public IList<RepaymentScheduleItem> ResultSchedule { get; private set; }

        public LoanEditForm(AppSettings settings, Loan loan)
        {
            _settings = settings;
            _sourceLoan = loan;
            _calculator = new RepaymentCalculator();

            InitializeForm();
            CreateControls();
            LoadValues();
            UpdateControlStates();
        }

        private void InitializeForm()
        {
            Text = _sourceLoan == null ? "ローンを登録" : "ローンを編集";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(980, 740);
            Size = new Size(1140, 920);
            AutoScaleMode = AutoScaleMode.Dpi;
            Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _inputFont = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        }

        private void CreateControls()
        {
            TableLayoutPanel root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(12)
            };
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            Controls.Add(root);

            Panel scrollPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            root.Controls.Add(scrollPanel, 0, 0);
            root.MouseDown += BackgroundMouseDown;
            scrollPanel.MouseDown += BackgroundMouseDown;

            TableLayoutPanel fields = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 3,
                Padding = new Padding(0, 0, 12, 0)
            };
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 270F));
            scrollPanel.Controls.Add(fields);
            fields.MouseDown += BackgroundMouseDown;

            int row = 0;
            _txtName = new TextBox { Dock = DockStyle.Fill, MaxLength = 100, Font = _inputFont };
            AddField(fields, ref row, "ローン名称", _txtName, "必須");

            _txtPrincipal = new TextBox
            {
                Dock = DockStyle.Left,
                Width = 280,
                Font = _inputFont,
                MaxLength = 20,
                TextAlign = HorizontalAlignment.Right
            };
            _txtPrincipal.Enter += PrincipalEnter;
            _txtPrincipal.Leave += PrincipalLeave;
            _txtPrincipal.KeyPress += PrincipalKeyPress;
            AddField(fields, ref row, "借入額", _txtPrincipal, "円");

            _txtRate = new TextBox
            {
                Dock = DockStyle.Left,
                Width = 180,
                Font = _inputFont,
                MaxLength = 20,
                TextAlign = HorizontalAlignment.Right
            };
            AddField(
                fields,
                ref row,
                "年間金利",
                _txtRate,
                "%（小数点以下" + _settings.InterestRateDecimalPlaces + "桁まで）");

            _cmbRepaymentType = CreateDropDown();
            _cmbRepaymentType.Width = 600;
            AddNamedItem(
                _cmbRepaymentType,
                "元利均等返済（元金と利息を含むお支払い額が原則一定）",
                RepaymentType.EqualPayment);
            AddNamedItem(
                _cmbRepaymentType,
                "元金均等返済（元金が一定でお支払い額は徐々に減少）",
                RepaymentType.EqualPrincipal);
            AddNamedItem(
                _cmbRepaymentType,
                "一括返済（期日に元金と利息をまとめて支払い）",
                RepaymentType.LumpSum);
            _cmbRepaymentType.SelectedIndexChanged += delegate { UpdateControlStates(); UpdatePreview(); };
            AddField(fields, ref row, "返済方式", _cmbRepaymentType, string.Empty);

            _cmbInterestMethod = CreateDropDown();
            AddNamedItem(_cmbInterestMethod, "月割り計算", InterestCalculationMethod.Monthly);
            AddNamedItem(_cmbInterestMethod, "日割り計算（Actual/Actual）", InterestCalculationMethod.Daily);
            AddField(fields, ref row, "利息の計算方法", _cmbInterestMethod, string.Empty);

            _dtpBorrowDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy年MM月dd日",
                Width = 230,
                Font = _inputFont
            };
            AddField(fields, ref row, "借入日", _dtpBorrowDate, string.Empty);

            _dtpFirstRepaymentDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy年MM月dd日",
                Width = 230,
                Font = _inputFont
            };
            AddField(fields, ref row, "初回返済日", _dtpFirstRepaymentDate, string.Empty);

            _cmbRepaymentSettingMode = CreateDropDown();
            AddNamedItem(
                _cmbRepaymentSettingMode,
                "返済期間で設定",
                RepaymentSettingMode.ByPeriod);
            AddNamedItem(
                _cmbRepaymentSettingMode,
                "毎月の金額で設定",
                RepaymentSettingMode.ByMonthlyPayment);
            _cmbRepaymentSettingMode.SelectedIndexChanged += delegate
            {
                UpdateControlStates();
                UpdatePreview();
            };
            AddField(fields, ref row, "返済条件", _cmbRepaymentSettingMode, string.Empty);

            _pnlPeriod = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Margin = new Padding(0)
            };
            _nudYears = new NumericUpDown
            {
                Width = 90,
                Font = _inputFont,
                Minimum = 0,
                Maximum = _settings.MaximumRepaymentMonths / 12,
                DecimalPlaces = 0
            };
            _nudMonths = new NumericUpDown
            {
                Width = 90,
                Font = _inputFont,
                Minimum = 0,
                Maximum = 11,
                DecimalPlaces = 0
            };
            _pnlPeriod.Controls.Add(_nudYears);
            _pnlPeriod.Controls.Add(new Label { Text = "年", AutoSize = true, Margin = new Padding(4, 6, 12, 0) });
            _pnlPeriod.Controls.Add(_nudMonths);
            _pnlPeriod.Controls.Add(new Label { Text = "か月", AutoSize = true, Margin = new Padding(4, 6, 0, 0) });
            AddField(fields, ref row, "返済期間", _pnlPeriod, "1～" + _settings.MaximumRepaymentMonths + "か月");

            _nudDesiredMonthlyPayment = new NumericUpDown
            {
                Dock = DockStyle.Left,
                Width = 280,
                Font = _inputFont,
                DecimalPlaces = 0,
                ThousandsSeparator = true,
                Minimum = 1,
                Maximum = _settings.MaximumLoanAmount,
                Increment = 1000
            };
            _lblMonthlyPaymentNote = AddField(
                fields,
                ref row,
                "毎月のお支払い額",
                _nudDesiredMonthlyPayment,
                "円（元金＋利息）",
                out _lblDesiredMonthlyAmount);

            _nudPaymentDay = new NumericUpDown
            {
                Width = 110,
                Font = _inputFont,
                Minimum = 1,
                Maximum = 31,
                DecimalPlaces = 0
            };
            AddField(fields, ref row, "毎月の返済日", _nudPaymentDay, "日（超過時は月末）");

            _chkUseBonusPayment = new CheckBox
            {
                Text = "ボーナス払いを使用する",
                AutoSize = true,
                Margin = new Padding(3, 8, 3, 8)
            };
            _chkUseBonusPayment.CheckedChanged += delegate
            {
                UpdateControlStates();
                UpdatePreview();
            };
            AddField(
                fields,
                ref row,
                "ボーナス払い",
                _chkUseBonusPayment,
                "一括返済では使用できません");

            _grpBonus = CreateBonusGroup();
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.Controls.Add(_grpBonus, 0, row);
            fields.SetColumnSpan(_grpBonus, 3);
            row++;

            _txtMemo = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                Height = 110,
                Font = _inputFont,
                ScrollBars = ScrollBars.Vertical,
                MaxLength = 2000
            };
            AddField(fields, ref row, "メモ", _txtMemo, string.Empty);

            _lblPreview = new Label
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                MinimumSize = new Size(0, 118),
                Padding = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                Text = "入力内容から返済額を計算します。"
            };
            root.Controls.Add(_lblPreview, 0, 1);

            FlowLayoutPanel buttons = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize = true,
                Padding = new Padding(0, 10, 0, 0)
            };
            Button btnCancel = new Button
            {
                Text = "キャンセル",
                DialogResult = DialogResult.Cancel,
                AutoSize = true,
                MinimumSize = new Size(120, 42)
            };
            Button btnSave = new Button
            {
                Text = "保存",
                AutoSize = true,
                MinimumSize = new Size(120, 42)
            };
            Button btnCalculate = new Button
            {
                Text = "再計算",
                AutoSize = true,
                MinimumSize = new Size(120, 42)
            };
            btnSave.Click += SaveClicked;
            btnCalculate.Click += delegate { UpdatePreview(); };
            buttons.Controls.Add(btnCancel);
            buttons.Controls.Add(btnSave);
            buttons.Controls.Add(btnCalculate);
            root.Controls.Add(buttons, 0, 2);

            AcceptButton = btnSave;
            CancelButton = btnCancel;

            EventHandler previewHandler = delegate { UpdatePreview(); };
            _txtRate.TextChanged += previewHandler;
            _cmbInterestMethod.SelectedIndexChanged += previewHandler;
            _dtpBorrowDate.ValueChanged += previewHandler;
            _dtpFirstRepaymentDate.ValueChanged += previewHandler;
            _nudYears.ValueChanged += previewHandler;
            _nudMonths.ValueChanged += previewHandler;
            _nudDesiredMonthlyPayment.ValueChanged += previewHandler;
            _nudPaymentDay.ValueChanged += previewHandler;
            _nudBonusPrincipal.ValueChanged += previewHandler;
            _cmbBonusMonth1.SelectedIndexChanged += previewHandler;
            _cmbBonusMonth2.SelectedIndexChanged += previewHandler;
        }

        private GroupBox CreateBonusGroup()
        {
            GroupBox group = new GroupBox
            {
                Text = "ボーナス払い設定",
                Dock = DockStyle.Top,
                AutoSize = true,
                Padding = new Padding(10)
            };
            TableLayoutPanel table = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 2
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            group.Controls.Add(table);

            _nudBonusPrincipal = new NumericUpDown
            {
                Width = 260,
                Font = _inputFont,
                DecimalPlaces = 0,
                ThousandsSeparator = true,
                Minimum = 1,
                Maximum = _settings.MaximumLoanAmount,
                Increment = 10000
            };
            AddSimpleRow(table, 0, "ボーナス払い対象元金", _nudBonusPrincipal);

            FlowLayoutPanel months = new FlowLayoutPanel { AutoSize = true, Margin = new Padding(0) };
            _cmbBonusMonth1 = CreateMonthCombo();
            _cmbBonusMonth2 = CreateMonthCombo();
            months.Controls.Add(_cmbBonusMonth1);
            months.Controls.Add(new Label { Text = "月 と", AutoSize = true, Margin = new Padding(5, 6, 5, 0) });
            months.Controls.Add(_cmbBonusMonth2);
            months.Controls.Add(new Label { Text = "月", AutoSize = true, Margin = new Padding(5, 6, 0, 0) });
            AddSimpleRow(table, 1, "ボーナス払い月", months);

            Label note = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(820, 0),
                Text = "借入額の一部をボーナス払い対象元金として分け、選択した返済方式の通常返済に加えて指定月に支払います。指定月までのボーナス分の利息は、ボーナス払い時にまとめて加算します。",
                Margin = new Padding(3, 8, 3, 3)
            };
            table.Controls.Add(note, 0, 2);
            table.SetColumnSpan(note, 2);
            return group;
        }

        private void LoadValues()
        {
            Loan loan = _sourceLoan ?? CreateDefaultLoan();
            _txtName.Text = loan.Name;
            _txtPrincipal.Text = loan.PrincipalAmount.ToString("N0", CultureInfo.CurrentCulture);
            _txtRate.Text = FormatRate(loan.AnnualInterestRate);
            SelectValue(_cmbRepaymentType, loan.RepaymentType);
            SelectValue(_cmbInterestMethod, loan.InterestCalculationMethod);
            _dtpBorrowDate.Value = loan.BorrowDate;
            _dtpFirstRepaymentDate.Value = loan.FirstRepaymentDate;
            SelectValue(_cmbRepaymentSettingMode, loan.RepaymentSettingMode);
            _nudYears.Value = Math.Min(_nudYears.Maximum, loan.RepaymentMonths / 12);
            _nudMonths.Value = loan.RepaymentMonths % 12;
            SetNumericValue(
                _nudDesiredMonthlyPayment,
                Math.Max(1, loan.DesiredMonthlyPaymentAmount));
            _nudPaymentDay.Value = Math.Max(1, Math.Min(31, loan.MonthlyPaymentDay));
            _chkUseBonusPayment.Checked = loan.UseBonusPayment;
            SetNumericValue(_nudBonusPrincipal, Math.Max(1, loan.BonusPrincipalAmount));
            SelectValue(_cmbBonusMonth1, loan.BonusMonth1);
            SelectValue(_cmbBonusMonth2, loan.BonusMonth2);
            _txtMemo.Text = loan.Memo;
            UpdatePreview();
        }

        private Loan CreateDefaultLoan()
        {
            DateTime borrowDate = DateTime.Today;
            DateTime firstDate = borrowDate.AddMonths(1);
            return new Loan
            {
                Name = "無題",
                PrincipalAmount = Math.Min(
                    _settings.MaximumLoanAmount,
                    Math.Max(_settings.MinimumLoanAmount, 1000000L)),
                AnnualInterestRate = 15m,
                RepaymentType = RepaymentType.EqualPayment,
                InterestCalculationMethod = InterestCalculationMethod.Monthly,
                BorrowDate = borrowDate,
                FirstRepaymentDate = firstDate,
                RepaymentSettingMode = RepaymentSettingMode.ByPeriod,
                RepaymentMonths = 12,
                DesiredMonthlyPaymentAmount = 30000L,
                MonthlyPaymentDay = firstDate.Day,
                UseBonusPayment = false,
                BonusPrincipalAmount = 500000L,
                BonusMonth1 = 6,
                BonusMonth2 = 12,
                Memo = string.Empty
            };
        }

        private void UpdateControlStates()
        {
            if (_grpBonus == null ||
                _chkUseBonusPayment == null ||
                _txtPrincipal == null ||
                _nudBonusPrincipal == null ||
                _cmbRepaymentType == null ||
                _cmbRepaymentSettingMode == null ||
                _pnlPeriod == null ||
                _nudDesiredMonthlyPayment == null ||
                _lblDesiredMonthlyAmount == null)
            {
                return;
            }

            RepaymentType type = GetSelectedValue(
                _cmbRepaymentType,
                RepaymentType.EqualPayment);
            bool isLumpSum = type == RepaymentType.LumpSum;

            if (isLumpSum &&
                GetSelectedValue(
                    _cmbRepaymentSettingMode,
                    RepaymentSettingMode.ByPeriod) != RepaymentSettingMode.ByPeriod)
            {
                SelectValue(_cmbRepaymentSettingMode, RepaymentSettingMode.ByPeriod);
            }

            _cmbRepaymentSettingMode.Enabled = !isLumpSum;
            RepaymentSettingMode settingMode = GetSelectedValue(
                _cmbRepaymentSettingMode,
                RepaymentSettingMode.ByPeriod);
            bool byMonthlyPayment = !isLumpSum &&
                                    settingMode == RepaymentSettingMode.ByMonthlyPayment;

            _pnlPeriod.Enabled = !byMonthlyPayment;
            _nudDesiredMonthlyPayment.Enabled = byMonthlyPayment;

            if (_lblMonthlyPaymentNote != null)
            {
                if (type == RepaymentType.EqualPrincipal)
                {
                    _lblDesiredMonthlyAmount.Text = "毎月の元金返済額";
                    _lblMonthlyPaymentNote.Text = _chkUseBonusPayment.Checked
                        ? "円（利息・ボーナス払い分を除く）"
                        : "円（利息を除く）";
                }
                else
                {
                    _lblDesiredMonthlyAmount.Text = "毎月のお支払い額";
                    _lblMonthlyPaymentNote.Text = _chkUseBonusPayment.Checked
                        ? "円（元金＋利息。ボーナス払い分を除く）"
                        : "円（元金＋利息）";
                }
            }

            if (isLumpSum && _chkUseBonusPayment.Checked)
            {
                _chkUseBonusPayment.Checked = false;
            }

            _chkUseBonusPayment.Enabled = !isLumpSum;
            _grpBonus.Visible = !isLumpSum && _chkUseBonusPayment.Checked;

            long principalAmount;
            decimal bonusMaximum = _settings.MaximumLoanAmount;
            if (TryReadPrincipalAmount(out principalAmount))
            {
                bonusMaximum = Math.Max(1L, principalAmount - 1L);
            }
            _nudBonusPrincipal.Maximum = Math.Max(1m, bonusMaximum);
            if (_nudBonusPrincipal.Value > _nudBonusPrincipal.Maximum)
            {
                _nudBonusPrincipal.Value = _nudBonusPrincipal.Maximum;
            }
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            try
            {
                Loan loan = ReadLoanFromControls();
                ValidateInput(loan);
                IList<RepaymentScheduleItem> schedule = _calculator.Calculate(loan, _settings.MaximumRepaymentMonths);
                ResultLoan = loan;
                ResultSchedule = schedule;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "入力内容を確認してください", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdatePreview()
        {
            if (_lblPreview == null)
            {
                return;
            }

            try
            {
                UpdateControlStates();
                Loan loan = ReadLoanFromControls();
                ValidateInput(loan);
                IList<RepaymentScheduleItem> schedule = _calculator.Calculate(loan, _settings.MaximumRepaymentMonths);
                long totalRepayment = schedule.Sum(x => x.RepaymentAmount);
                long totalPayment = schedule.Sum(x => x.PaymentAmount);
                long interest = schedule.Sum(x => x.InterestAmount);
                long firstRepayment = schedule.Count > 0 ? schedule[0].RepaymentAmount : 0;
                long firstInterest = schedule.Count > 0 ? schedule[0].InterestAmount : 0;
                long firstPayment = schedule.Count > 0 ? schedule[0].PaymentAmount : 0;
                long maxPayment = schedule.Count > 0 ? schedule.Max(x => x.PaymentAmount) : 0;
                _lblPreview.Text = string.Format(
                    "概算　返済期間: {0}\r\n" +
                    "初回返済額（元金）: {1:N0}円　初回利息: {2:N0}円　初回お支払い額: {3:N0}円\r\n" +
                    "最大お支払い額: {4:N0}円\r\n" +
                    "総返済額（元金）: {5:N0}円　利息合計: {6:N0}円　総お支払い額: {7:N0}円",
                    FormatPeriod(loan.RepaymentMonths),
                    firstRepayment,
                    firstInterest,
                    firstPayment,
                    maxPayment,
                    totalRepayment,
                    interest,
                    totalPayment);
            }
            catch (Exception ex)
            {
                _lblPreview.Text = "計算できません: " + ex.Message;
            }
        }

        private Loan ReadLoanFromControls()
        {
            int totalMonths = checked((int)_nudYears.Value * 12 + (int)_nudMonths.Value);
            Loan loan = new Loan
            {
                Id = _sourceLoan == null ? 0 : _sourceLoan.Id,
                Name = _txtName.Text.Trim(),
                PrincipalAmount = ReadPrincipalAmount(),
                AnnualInterestRate = ReadInterestRate(),
                RepaymentType = GetSelectedValue(_cmbRepaymentType, RepaymentType.EqualPayment),
                InterestCalculationMethod = GetSelectedValue(
                    _cmbInterestMethod,
                    InterestCalculationMethod.Monthly),
                BorrowDate = _dtpBorrowDate.Value.Date,
                FirstRepaymentDate = _dtpFirstRepaymentDate.Value.Date,
                RepaymentSettingMode = GetSelectedValue(
                    _cmbRepaymentSettingMode,
                    RepaymentSettingMode.ByPeriod),
                RepaymentMonths = totalMonths,
                DesiredMonthlyPaymentAmount =
                    decimal.ToInt64(_nudDesiredMonthlyPayment.Value),
                MonthlyPaymentDay = (int)_nudPaymentDay.Value,
                UseBonusPayment = _chkUseBonusPayment.Checked,
                BonusPrincipalAmount = decimal.ToInt64(_nudBonusPrincipal.Value),
                BonusMonth1 = GetSelectedValue(_cmbBonusMonth1, 6),
                BonusMonth2 = GetSelectedValue(_cmbBonusMonth2, 12),
                Memo = _txtMemo.Text.Trim(),
                CreatedAt = _sourceLoan == null ? DateTime.Now : _sourceLoan.CreatedAt,
                UpdatedAt = DateTime.Now
            };
            return loan;
        }

        private void ValidateInput(Loan loan)
        {
            if (string.IsNullOrWhiteSpace(loan.Name))
            {
                throw new ArgumentException("ローン名称を入力してください。");
            }

            if (loan.PrincipalAmount < _settings.MinimumLoanAmount ||
                loan.PrincipalAmount > _settings.MaximumLoanAmount)
            {
                throw new ArgumentException(string.Format(
                    "借入額は {0:N0}円～{1:N0}円で入力してください。",
                    _settings.MinimumLoanAmount,
                    _settings.MaximumLoanAmount));
            }

            if (loan.AnnualInterestRate < _settings.MinimumInterestRate ||
                loan.AnnualInterestRate > _settings.MaximumInterestRate)
            {
                throw new ArgumentException(string.Format(
                    "年間金利は {0}～{1}%で入力してください。",
                    FormatRate(_settings.MinimumInterestRate),
                    FormatRate(_settings.MaximumInterestRate)));
            }

            bool periodMode = loan.RepaymentType == RepaymentType.LumpSum ||
                              loan.RepaymentSettingMode == RepaymentSettingMode.ByPeriod;
            if (periodMode &&
                (loan.RepaymentMonths < _settings.MinimumRepaymentMonths ||
                 loan.RepaymentMonths > _settings.MaximumRepaymentMonths))
            {
                throw new ArgumentException(string.Format(
                    "返済期間は {0}～{1}か月で入力してください。",
                    _settings.MinimumRepaymentMonths,
                    _settings.MaximumRepaymentMonths));
            }

            if (!periodMode && loan.DesiredMonthlyPaymentAmount <= 0)
            {
                string amountName = loan.RepaymentType == RepaymentType.EqualPrincipal
                    ? "毎月の元金返済額"
                    : "毎月のお支払い額";
                throw new ArgumentException(amountName + "は1円以上で入力してください。");
            }

            if (loan.FirstRepaymentDate <= loan.BorrowDate)
            {
                throw new ArgumentException("初回返済日は借入日より後の日付にしてください。");
            }

            if (loan.UseBonusPayment)
            {
                if (loan.RepaymentType == RepaymentType.LumpSum)
                {
                    throw new ArgumentException("一括返済ではボーナス払いを使用できません。");
                }

                if (loan.BonusMonth1 == loan.BonusMonth2)
                {
                    throw new ArgumentException("ボーナス払い月は異なる月を指定してください。");
                }

                if (loan.BonusPrincipalAmount <= 0 || loan.BonusPrincipalAmount >= loan.PrincipalAmount)
                {
                    throw new ArgumentException("ボーナス払い対象元金は借入額未満で入力してください。");
                }
            }
        }

        private static Label AddField(
            TableLayoutPanel table,
            ref int row,
            string labelText,
            Control control,
            string note)
        {
            Label fieldLabel;
            return AddField(table, ref row, labelText, control, note, out fieldLabel);
        }

        private static Label AddField(
            TableLayoutPanel table,
            ref int row,
            string labelText,
            Control control,
            string note,
            out Label fieldLabel)
        {
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fieldLabel = new Label
            {
                Text = labelText,
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(3, 10, 3, 10)
            };
            control.Margin = new Padding(3, 6, 3, 6);
            Label noteLabel = new Label
            {
                Text = note,
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(3, 10, 3, 10)
            };
            table.Controls.Add(fieldLabel, 0, row);
            table.Controls.Add(control, 1, row);
            table.Controls.Add(noteLabel, 2, row);
            row++;
            return noteLabel;
        }

        private static void AddSimpleRow(TableLayoutPanel table, int row, string labelText, Control control)
        {
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.Controls.Add(new Label
            {
                Text = labelText,
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(3, 8, 3, 8)
            }, 0, row);
            control.Margin = new Padding(3, 5, 3, 5);
            table.Controls.Add(control, 1, row);
        }

        private ComboBox CreateDropDown()
        {
            return new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Left,
                Width = 310,
                Font = _inputFont
            };
        }

        private ComboBox CreateMonthCombo()
        {
            ComboBox combo = CreateDropDown();
            combo.Width = 85;
            for (int month = 1; month <= 12; month++)
            {
                AddNamedItem(combo, month.ToString(), month);
            }
            return combo;
        }

        private static void AddNamedItem<T>(ComboBox combo, string name, T value)
        {
            combo.Items.Add(new NamedValue<T>(name, value));
            if (combo.SelectedIndex < 0)
            {
                combo.SelectedIndex = 0;
            }
        }

        private static void SelectValue<T>(ComboBox combo, T value)
        {
            for (int i = 0; i < combo.Items.Count; i++)
            {
                NamedValue<T> item = combo.Items[i] as NamedValue<T>;
                if (item != null && EqualityComparer<T>.Default.Equals(item.Value, value))
                {
                    combo.SelectedIndex = i;
                    return;
                }
            }

            if (combo.Items.Count > 0)
            {
                combo.SelectedIndex = 0;
            }
        }

        private static T GetSelectedValue<T>(ComboBox combo, T defaultValue)
        {
            NamedValue<T> selected = combo.SelectedItem as NamedValue<T>;
            return selected == null ? defaultValue : selected.Value;
        }

        private static void SetNumericValue(NumericUpDown control, decimal value)
        {
            if (value < control.Minimum)
            {
                value = control.Minimum;
            }
            if (value > control.Maximum)
            {
                value = control.Maximum;
            }
            control.Value = value;
        }

        private void PrincipalEnter(object sender, EventArgs e)
        {
            long value;
            if (TryReadPrincipalAmount(out value))
            {
                _txtPrincipal.Text = value.ToString(CultureInfo.InvariantCulture);
                _txtPrincipal.SelectionStart = _txtPrincipal.TextLength;
            }
        }

        private void PrincipalLeave(object sender, EventArgs e)
        {
            long value;
            if (TryReadPrincipalAmount(out value))
            {
                _txtPrincipal.Text = value.ToString("N0", CultureInfo.CurrentCulture);
            }

            UpdateControlStates();
            UpdatePreview();
        }

        private static void PrincipalKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BackgroundMouseDown(object sender, MouseEventArgs e)
        {
            if (_txtPrincipal != null && _txtPrincipal.Focused)
            {
                ActiveControl = null;
            }
        }

        private long ReadPrincipalAmount()
        {
            long value;
            if (!TryReadPrincipalAmount(out value))
            {
                throw new ArgumentException("借入額は1円単位の整数で入力してください。");
            }
            return value;
        }

        private bool TryReadPrincipalAmount(out long value)
        {
            string text = (_txtPrincipal == null ? string.Empty : _txtPrincipal.Text ?? string.Empty).Trim();
            NumberStyles styles = NumberStyles.Integer | NumberStyles.AllowThousands;
            return long.TryParse(text, styles, CultureInfo.CurrentCulture, out value) ||
                   long.TryParse(text, styles, CultureInfo.InvariantCulture, out value);
        }

        private decimal ReadInterestRate()
        {
            string text = (_txtRate.Text ?? string.Empty).Trim();
            decimal value;
            if (!decimal.TryParse(
                    text,
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out value) &&
                !decimal.TryParse(
                    text,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out value))
            {
                throw new ArgumentException("年間金利を数値で入力してください。");
            }

            int[] bits = decimal.GetBits(value);
            int scale = (bits[3] >> 16) & 0x7F;
            if (scale > _settings.InterestRateDecimalPlaces)
            {
                throw new ArgumentException(
                    "年間金利は小数点以下" +
                    _settings.InterestRateDecimalPlaces +
                    "桁までで入力してください。");
            }

            return value;
        }

        private static string FormatRate(decimal value)
        {
            return value.ToString("0.######", CultureInfo.CurrentCulture);
        }

        private static string FormatPeriod(int months)
        {
            int years = months / 12;
            int remainingMonths = months % 12;
            if (years > 0 && remainingMonths > 0)
            {
                return years + "年" + remainingMonths + "か月";
            }
            if (years > 0)
            {
                return years + "年";
            }
            return remainingMonths + "か月";
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && _inputFont != null)
            {
                _inputFont.Dispose();
                _inputFont = null;
            }
        }

        private sealed class NamedValue<T>
        {
            public string Name { get; private set; }
            public T Value { get; private set; }

            public NamedValue(string name, T value)
            {
                Name = name;
                Value = value;
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
