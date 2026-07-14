using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using LoanManagerApp.Domain;
using LoanManagerApp.Infrastructure;
using LoanManagerApp.Services;

namespace LoanManagerApp.Forms
{
    [DesignerCategory("Form")]
    public sealed partial class LoanEditForm : Form
    {
        private readonly AppSettings _settings;
        private readonly Loan _sourceLoan;
        private readonly RepaymentCalculator _calculator;
        private int _normalClientHeight;
        private bool _adjustingLayout;

        public Loan ResultLoan { get; private set; }
        public IList<RepaymentScheduleItem> ResultSchedule { get; private set; }

        // Visual Studioデザイナー用。アプリケーションからは使用しません。
        public LoanEditForm()
        {
            InitializeComponent();
            _normalClientHeight = ClientSize.Height;
        }

        public LoanEditForm(AppSettings settings, Loan loan)
            : this()
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _sourceLoan = loan;
            _calculator = new RepaymentCalculator();

            Text = _sourceLoan == null ? "ローンを登録" : "ローンを編集";
            ConfigureRuntimeControls();
            LoadValues();
            UpdateControlStates();
        }

        private void ConfigureRuntimeControls()
        {
            _lblRateNote.Text = "%（小数点以下" + _settings.InterestRateDecimalPlaces + "桁まで）";
            _lblPeriodNote.Text = "1～" + _settings.MaximumRepaymentMonths + "か月";
            _nudYears.Maximum = _settings.MaximumRepaymentMonths / 12;
            _nudDesiredMonthlyPayment.Maximum = _settings.MaximumLoanAmount;
            _nudBonusPrincipal.Maximum = _settings.MaximumLoanAmount;

            _cmbRepaymentType.Items.Clear();
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

            _cmbInterestMethod.Items.Clear();
            AddNamedItem(_cmbInterestMethod, "月割り計算", InterestCalculationMethod.Monthly);
            AddNamedItem(_cmbInterestMethod, "日割り計算（Actual/Actual）", InterestCalculationMethod.Daily);

            _cmbRepaymentSettingMode.Items.Clear();
            AddNamedItem(_cmbRepaymentSettingMode, "返済期間で設定", RepaymentSettingMode.ByPeriod);
            AddNamedItem(_cmbRepaymentSettingMode, "毎月の金額で設定", RepaymentSettingMode.ByMonthlyPayment);

            PopulateMonthCombo(_cmbBonusMonth1);
            PopulateMonthCombo(_cmbBonusMonth2);
        }

        private static void PopulateMonthCombo(ComboBox combo)
        {
            combo.Items.Clear();
            for (int month = 1; month <= 12; month++)
            {
                AddNamedItem(combo, month.ToString(CultureInfo.CurrentCulture), month);
            }
        }

        private void RepaymentTypeChanged(object sender, EventArgs e)
        {
            if (_settings == null)
            {
                return;
            }
            UpdateControlStates();
            UpdatePreview();
        }

        private void RepaymentSettingModeChanged(object sender, EventArgs e)
        {
            if (_settings == null)
            {
                return;
            }
            UpdateControlStates();
            UpdatePreview();
        }

        private void BonusPaymentFrequencyChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio != null && !radio.Checked)
            {
                return;
            }

            if (_settings == null)
            {
                return;
            }
            UpdateControlStates();
            UpdatePreview();
        }

        private void PreviewValueChanged(object sender, EventArgs e)
        {
            if (_settings != null)
            {
                UpdatePreview();
            }
        }

        private void CalculateClicked(object sender, EventArgs e)
        {
            UpdatePreview();
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
            SelectBonusPaymentFrequency(loan.BonusPaymentFrequency);
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
                BonusPaymentFrequency = BonusPaymentFrequency.None,
                BonusPrincipalAmount = 500000L,
                BonusMonth1 = 6,
                BonusMonth2 = 12,
                Memo = string.Empty
            };
        }

        private void UpdateControlStates()
        {
            if (_grpBonus == null ||
                _bonusFrequencyPanel == null ||
                _rdoBonusNone == null ||
                _rdoBonusOnce == null ||
                _rdoBonusTwice == null ||
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
            BonusPaymentFrequency bonusFrequency =
                GetSelectedBonusPaymentFrequency();
            bool useBonusPayment =
                bonusFrequency != BonusPaymentFrequency.None;

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
                    _lblMonthlyPaymentNote.Text = useBonusPayment
                        ? "円（利息を除く。ボーナス月は指定元金を加算）"
                        : "円（利息を除く）";
                }
                else
                {
                    _lblDesiredMonthlyAmount.Text = "毎月のお支払い額";
                    _lblMonthlyPaymentNote.Text = useBonusPayment
                        ? "円（元金＋利息。ボーナス月は指定元金を加算）"
                        : "円（元金＋利息）";
                }
            }

            if (isLumpSum && useBonusPayment)
            {
                SelectBonusPaymentFrequency(BonusPaymentFrequency.None);
                bonusFrequency = BonusPaymentFrequency.None;
                useBonusPayment = false;
            }

            _bonusFrequencyPanel.Enabled = !isLumpSum;
            _grpBonus.Visible = !isLumpSum && useBonusPayment;
            bool twicePerYear =
                bonusFrequency == BonusPaymentFrequency.TwicePerYear;
            _lblBonusMonthsSeparator.Visible = twicePerYear;
            _cmbBonusMonth2.Visible = twicePerYear;

            long principalAmount;
            decimal bonusMaximum = _settings.MaximumLoanAmount;
            if (TryReadPrincipalAmount(out principalAmount))
            {
                bonusMaximum = Math.Max(1L, principalAmount);
            }
            _nudBonusPrincipal.Maximum = Math.Max(1m, bonusMaximum);
            if (_nudBonusPrincipal.Value > _nudBonusPrincipal.Maximum)
            {
                _nudBonusPrincipal.Value = _nudBonusPrincipal.Maximum;
            }

            AdjustLayoutForBonusPayment();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            AdjustLayoutForBonusPayment();
        }

        private void AdjustLayoutForBonusPayment()
        {
            if (_adjustingLayout ||
                _fields == null ||
                _scrollPanel == null ||
                _root == null ||
                _lblPreview == null ||
                _buttons == null)
            {
                return;
            }

            try
            {
                _adjustingLayout = true;

                _fields.PerformLayout();
                _root.PerformLayout();

                int preferredFieldsHeight = _fields.PreferredSize.Height;
                _scrollPanel.AutoScrollMinSize = new System.Drawing.Size(
                    0,
                    preferredFieldsHeight + 8);

                if (!_grpBonus.Visible || !IsHandleCreated)
                {
                    return;
                }

                int previewHeight = Math.Max(
                    _lblPreview.MinimumSize.Height,
                    _lblPreview.PreferredHeight);
                int buttonsHeight = Math.Max(
                    60,
                    _buttons.PreferredSize.Height);
                int desiredClientHeight =
                    _root.Padding.Vertical +
                    preferredFieldsHeight +
                    previewHeight +
                    buttonsHeight +
                    24;

                System.Drawing.Rectangle workingArea =
                    Screen.FromControl(this).WorkingArea;
                int nonClientHeight = Height - ClientSize.Height;
                int maximumClientHeight = Math.Max(
                    1,
                    workingArea.Height - nonClientHeight - 16);
                int targetClientHeight = Math.Min(
                    Math.Max(_normalClientHeight, desiredClientHeight),
                    maximumClientHeight);

                if (targetClientHeight > ClientSize.Height)
                {
                    ClientSize = new System.Drawing.Size(
                        ClientSize.Width,
                        targetClientHeight);

                    if (Bottom > workingArea.Bottom)
                    {
                        Top = Math.Max(workingArea.Top, workingArea.Bottom - Height);
                    }
                }
            }
            finally
            {
                _adjustingLayout = false;
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
                BonusPaymentFrequency = GetSelectedBonusPaymentFrequency(),
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

                if (loan.BonusPaymentFrequency == BonusPaymentFrequency.TwicePerYear &&
                    loan.BonusMonth1 == loan.BonusMonth2)
                {
                    throw new ArgumentException("年2回のボーナス払い月は異なる月を指定してください。");
                }

                if (loan.BonusPrincipalAmount <= 0 ||
                    loan.BonusPrincipalAmount > loan.PrincipalAmount)
                {
                    throw new ArgumentException(
                        "1回あたりのボーナス加算元金は借入額以下で入力してください。");
                }
            }
        }

        private BonusPaymentFrequency GetSelectedBonusPaymentFrequency()
        {
            if (_rdoBonusTwice.Checked)
            {
                return BonusPaymentFrequency.TwicePerYear;
            }

            if (_rdoBonusOnce.Checked)
            {
                return BonusPaymentFrequency.OncePerYear;
            }

            return BonusPaymentFrequency.None;
        }

        private void SelectBonusPaymentFrequency(BonusPaymentFrequency frequency)
        {
            _rdoBonusNone.Checked =
                frequency == BonusPaymentFrequency.None;
            _rdoBonusOnce.Checked =
                frequency == BonusPaymentFrequency.OncePerYear;
            _rdoBonusTwice.Checked =
                frequency == BonusPaymentFrequency.TwicePerYear;
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

        private void PrincipalKeyPress(object sender, KeyPressEventArgs e)
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
