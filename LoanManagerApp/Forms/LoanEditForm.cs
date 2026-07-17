using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
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
        private bool _normalizingPeriod;

        private static readonly Color ValidationErrorBackColor =
            Color.FromArgb(255, 235, 205);

        public Loan ResultLoan { get; private set; }
        public IList<RepaymentScheduleItem> ResultSchedule { get; private set; }

        // Visual Studioデザイナー用。アプリケーションからは使用しません。
        public LoanEditForm()
        {
            InitializeComponent();
            _normalClientHeight = 881;
        }

        public LoanEditForm(AppSettings settings, Loan loan)
            : this()
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _sourceLoan = loan;
            _calculator = new RepaymentCalculator();
            ClientSize = new Size(1124, _normalClientHeight);

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
            UpdateMonthMaximumForYear();

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

        private void PeriodYearsValueChanged(object sender, EventArgs e)
        {
            if (_normalizingPeriod || _settings == null)
            {
                return;
            }

            UpdateMonthMaximumForYear();
            UpdatePreview();
        }

        private void PeriodMonthsValueChanged(object sender, EventArgs e)
        {
            if (_normalizingPeriod || _settings == null)
            {
                return;
            }

            if (_nudMonths.Value == 12)
            {
                int nextTotalMonths = checked(((int)_nudYears.Value + 1) * 12);
                if (nextTotalMonths <= _settings.MaximumRepaymentMonths &&
                    _nudYears.Value < _nudYears.Maximum)
                {
                    try
                    {
                        _normalizingPeriod = true;
                        _nudYears.Value += 1;
                        _nudMonths.Value = 0;
                        UpdateMonthMaximumForYear();
                    }
                    finally
                    {
                        _normalizingPeriod = false;
                    }
                }
                else
                {
                    _nudMonths.Value = Math.Min(11, _nudMonths.Maximum);
                }
            }

            UpdatePreview();
        }

        private void UpdateMonthMaximumForYear()
        {
            if (_settings == null || _nudYears == null || _nudMonths == null)
            {
                return;
            }

            int usedMonths = checked((int)_nudYears.Value * 12);
            int remainingMonths = Math.Max(0, _settings.MaximumRepaymentMonths - usedMonths);
            decimal maximumMonths = remainingMonths >= 12
                ? 12
                : Math.Min(11, remainingMonths);

            if (_nudMonths.Value > maximumMonths)
            {
                _nudMonths.Value = maximumMonths;
            }
            _nudMonths.Maximum = maximumMonths;
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
            _txtDesiredMonthlyPayment.Text = Math.Max(1, loan.DesiredMonthlyPaymentAmount)
                .ToString("N0", CultureInfo.CurrentCulture);
            _nudPaymentDay.Value = Math.Max(1, Math.Min(31, loan.MonthlyPaymentDay));
            SelectBonusPaymentFrequency(loan.BonusPaymentFrequency);
            _txtBonusPrincipal.Text = Math.Max(1, loan.BonusPrincipalAmount)
                .ToString("N0", CultureInfo.CurrentCulture);
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
                _txtBonusPrincipal == null ||
                _cmbRepaymentType == null ||
                _cmbRepaymentSettingMode == null ||
                _pnlPeriod == null ||
                _txtDesiredMonthlyPayment == null ||
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

            bool showPeriod = !byMonthlyPayment;
            SetFieldRowVisible(
                8,
                showPeriod,
                _lblPeriod,
                _pnlPeriod,
                _lblPeriodNote);
            SetFieldRowVisible(
                9,
                byMonthlyPayment,
                _lblDesiredMonthlyAmount,
                _txtDesiredMonthlyPayment,
                _lblMonthlyPaymentNote);

            _pnlPeriod.Enabled = showPeriod;
            _txtDesiredMonthlyPayment.Enabled = byMonthlyPayment;

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

            AdjustLayoutForBonusPayment();
        }

        private void SetFieldRowVisible(
            int rowIndex,
            bool visible,
            params Control[] controls)
        {
            if (_fields == null || rowIndex < 0 || rowIndex >= _fields.RowStyles.Count)
            {
                return;
            }

            foreach (Control control in controls)
            {
                if (control != null)
                {
                    control.Visible = visible;
                }
            }

            RowStyle rowStyle = _fields.RowStyles[rowIndex];
            rowStyle.SizeType = visible ? SizeType.AutoSize : SizeType.Absolute;
            rowStyle.Height = 0F;
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
                ResetValidationAppearance();
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
                ShowValidationError(ex, true);
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
                ResetValidationAppearance();
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
                ShowValidationError(ex, false);
            }
        }

        private void ResetValidationAppearance()
        {
            if (_lblPreview != null)
            {
                _lblPreview.BackColor = SystemColors.Control;
            }

            ResetInputBackColor(_txtName);
            ResetInputBackColor(_txtPrincipal);
            ResetInputBackColor(_txtRate);
            ResetInputBackColor(_cmbRepaymentType);
            ResetInputBackColor(_cmbInterestMethod);
            ResetInputBackColor(_dtpBorrowDate);
            ResetInputBackColor(_dtpFirstRepaymentDate);
            ResetInputBackColor(_cmbRepaymentSettingMode);
            ResetInputBackColor(_nudYears);
            ResetInputBackColor(_nudMonths);
            ResetInputBackColor(_txtDesiredMonthlyPayment);
            ResetInputBackColor(_nudPaymentDay);
            ResetInputBackColor(_rdoBonusNone);
            ResetInputBackColor(_rdoBonusOnce);
            ResetInputBackColor(_rdoBonusTwice);
            ResetInputBackColor(_txtBonusPrincipal);
            ResetInputBackColor(_cmbBonusMonth1);
            ResetInputBackColor(_cmbBonusMonth2);

            ResetLabelBackColor(_lblName);
            ResetLabelBackColor(_lblPrincipal);
            ResetLabelBackColor(_lblRate);
            ResetLabelBackColor(_lblBorrowDate);
            ResetLabelBackColor(_lblFirstRepaymentDate);
            ResetLabelBackColor(_lblPeriod);
            ResetLabelBackColor(_lblDesiredMonthlyAmount);
            ResetLabelBackColor(_lblUseBonus);
            ResetLabelBackColor(_lblBonusPrincipal);
            ResetLabelBackColor(_lblBonusMonths);
        }

        private static void ResetInputBackColor(Control control)
        {
            if (control == null)
            {
                return;
            }

            if (control is RadioButton)
            {
                control.BackColor = Color.Transparent;
                return;
            }

            control.BackColor = SystemColors.Window;
        }

        private static void ResetLabelBackColor(Control control)
        {
            if (control != null)
            {
                control.BackColor = Color.Transparent;
            }
        }

        private void ShowValidationError(Exception ex, bool focusInput)
        {
            ResetValidationAppearance();
            _lblPreview.BackColor = ValidationErrorBackColor;
            _lblPreview.Text = "計算できません: " + ex.Message;

            Control[] targets = GetValidationTargets(ex);
            foreach (Control target in targets)
            {
                if (target != null)
                {
                    target.BackColor = ValidationErrorBackColor;
                }
            }

            if (focusInput)
            {
                Control focusTarget = targets.FirstOrDefault(
                    x => x != null && x.CanSelect && x.Visible && x.Enabled);
                if (focusTarget != null)
                {
                    focusTarget.Focus();
                }
            }
        }

        private Control[] GetValidationTargets(Exception ex)
        {
            InputValidationException validationException =
                ex as InputValidationException;
            if (validationException != null)
            {
                return validationException.Targets;
            }

            string message = ex.Message ?? string.Empty;
            if (message.Contains("ボーナス払い月") ||
                message.Contains("ボーナス月") ||
                message.Contains("ボーナス払いがありません") ||
                message.Contains("実際のボーナス加算がありません"))
            {
                return new Control[]
                {
                    _lblUseBonus,
                    _rdoBonusOnce,
                    _rdoBonusTwice,
                    _lblBonusMonths,
                    _cmbBonusMonth1,
                    _cmbBonusMonth2
                };
            }
            if (message.Contains("ボーナス加算元金"))
            {
                return new Control[]
                {
                    _lblUseBonus,
                    _lblBonusPrincipal,
                    _txtBonusPrincipal
                };
            }
            if (message.Contains("毎月のお支払い額") ||
                message.Contains("通常月のお支払い額") ||
                message.Contains("毎月の元金返済額") ||
                message.Contains("毎月の金額") ||
                message.Contains("金額では最大返済期間"))
            {
                return new Control[]
                {
                    _lblDesiredMonthlyAmount,
                    _txtDesiredMonthlyPayment
                };
            }
            if (message.Contains("ローン名称"))
            {
                return new Control[] { _lblName, _txtName };
            }
            if (message.Contains("年間金利"))
            {
                return new Control[] { _lblRate, _txtRate };
            }
            if (message.Contains("初回返済日"))
            {
                return new Control[]
                {
                    _lblBorrowDate,
                    _dtpBorrowDate,
                    _lblFirstRepaymentDate,
                    _dtpFirstRepaymentDate
                };
            }
            if (message.Contains("指定した条件では返済期間内に完済できません"))
            {
                return new Control[]
                {
                    _lblPeriod,
                    _nudYears,
                    _nudMonths,
                    _lblBonusPrincipal,
                    _txtBonusPrincipal,
                    _lblBonusMonths,
                    _cmbBonusMonth1,
                    _cmbBonusMonth2
                };
            }
            if (message.Contains("借入額"))
            {
                return new Control[] { _lblPrincipal, _txtPrincipal };
            }
            if (message.Contains("返済期間"))
            {
                return new Control[] { _lblPeriod, _nudYears, _nudMonths };
            }

            return new Control[0];
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
                DesiredMonthlyPaymentAmount = ReadDesiredMonthlyPaymentAmount(),
                MonthlyPaymentDay = (int)_nudPaymentDay.Value,
                BonusPaymentFrequency = GetSelectedBonusPaymentFrequency(),
                BonusPrincipalAmount = ReadBonusPrincipalAmount(),
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
                throw new InputValidationException(
                    "ローン名称を入力してください。",
                    _lblName,
                    _txtName);
            }

            if (loan.PrincipalAmount < _settings.MinimumLoanAmount ||
                loan.PrincipalAmount > _settings.MaximumLoanAmount)
            {
                throw new InputValidationException(
                    string.Format(
                        "借入額は {0:N0}円～{1:N0}円で入力してください。",
                        _settings.MinimumLoanAmount,
                        _settings.MaximumLoanAmount),
                    _lblPrincipal,
                    _txtPrincipal);
            }

            if (loan.AnnualInterestRate < _settings.MinimumInterestRate ||
                loan.AnnualInterestRate > _settings.MaximumInterestRate)
            {
                throw new InputValidationException(
                    string.Format(
                        "年間金利は {0}～{1}%で入力してください。",
                        FormatRate(_settings.MinimumInterestRate),
                        FormatRate(_settings.MaximumInterestRate)),
                    _lblRate,
                    _txtRate);
            }

            bool periodMode = loan.RepaymentType == RepaymentType.LumpSum ||
                              loan.RepaymentSettingMode == RepaymentSettingMode.ByPeriod;
            if (periodMode &&
                (loan.RepaymentMonths < _settings.MinimumRepaymentMonths ||
                 loan.RepaymentMonths > _settings.MaximumRepaymentMonths))
            {
                throw new InputValidationException(
                    string.Format(
                        "返済期間は {0}～{1}か月で入力してください。",
                        _settings.MinimumRepaymentMonths,
                        _settings.MaximumRepaymentMonths),
                    _lblPeriod,
                    _nudYears,
                    _nudMonths);
            }

            if (!periodMode &&
                (loan.DesiredMonthlyPaymentAmount <= 0 ||
                 loan.DesiredMonthlyPaymentAmount > _settings.MaximumLoanAmount))
            {
                string amountName = loan.RepaymentType == RepaymentType.EqualPrincipal
                    ? "毎月の元金返済額"
                    : "毎月のお支払い額";
                throw new InputValidationException(
                    string.Format(
                        "{0}は1円～{1:N0}円で入力してください。",
                        amountName,
                        _settings.MaximumLoanAmount),
                    _lblDesiredMonthlyAmount,
                    _txtDesiredMonthlyPayment);
            }

            if (loan.FirstRepaymentDate <= loan.BorrowDate)
            {
                throw new InputValidationException(
                    "初回返済日は借入日より後の日付にしてください。",
                    _lblBorrowDate,
                    _dtpBorrowDate,
                    _lblFirstRepaymentDate,
                    _dtpFirstRepaymentDate);
            }

            if (loan.UseBonusPayment)
            {
                if (loan.RepaymentType == RepaymentType.LumpSum)
                {
                    throw new InputValidationException(
                        "一括返済ではボーナス払いを使用できません。",
                        _lblUseBonus,
                        _rdoBonusNone,
                        _rdoBonusOnce,
                        _rdoBonusTwice);
                }

                if (loan.BonusPaymentFrequency == BonusPaymentFrequency.TwicePerYear &&
                    loan.BonusMonth1 == loan.BonusMonth2)
                {
                    throw new InputValidationException(
                        "年2回のボーナス払い月は異なる月を指定してください。",
                        _lblBonusMonths,
                        _cmbBonusMonth1,
                        _cmbBonusMonth2);
                }

                if (loan.BonusPrincipalAmount <= 0 ||
                    loan.BonusPrincipalAmount > loan.PrincipalAmount)
                {
                    throw new InputValidationException(
                        "1回あたりのボーナス加算元金は借入額以下で入力してください。",
                        _lblBonusPrincipal,
                        _txtBonusPrincipal);
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
            AmountKeyPress(sender, e);
        }

        private void DesiredMonthlyPaymentEnter(object sender, EventArgs e)
        {
            long value;
            if (TryReadDesiredMonthlyPaymentAmount(out value))
            {
                _txtDesiredMonthlyPayment.Text = value.ToString(CultureInfo.InvariantCulture);
                _txtDesiredMonthlyPayment.SelectionStart = _txtDesiredMonthlyPayment.TextLength;
            }
        }

        private void DesiredMonthlyPaymentLeave(object sender, EventArgs e)
        {
            long value;
            if (TryReadDesiredMonthlyPaymentAmount(out value))
            {
                _txtDesiredMonthlyPayment.Text = value.ToString("N0", CultureInfo.CurrentCulture);
            }

            UpdatePreview();
        }

        private void BonusPrincipalEnter(object sender, EventArgs e)
        {
            long value;
            if (TryReadBonusPrincipalAmount(out value))
            {
                _txtBonusPrincipal.Text = value.ToString(CultureInfo.InvariantCulture);
                _txtBonusPrincipal.SelectionStart = _txtBonusPrincipal.TextLength;
            }
        }

        private void BonusPrincipalLeave(object sender, EventArgs e)
        {
            long value;
            if (TryReadBonusPrincipalAmount(out value))
            {
                _txtBonusPrincipal.Text = value.ToString("N0", CultureInfo.CurrentCulture);
            }

            UpdatePreview();
        }

        private void AmountKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BackgroundMouseDown(object sender, MouseEventArgs e)
        {
            if ((_txtPrincipal != null && _txtPrincipal.Focused) ||
                (_txtDesiredMonthlyPayment != null && _txtDesiredMonthlyPayment.Focused) ||
                (_txtBonusPrincipal != null && _txtBonusPrincipal.Focused))
            {
                ActiveControl = null;
            }
        }

        private long ReadPrincipalAmount()
        {
            long value;
            if (!TryReadPrincipalAmount(out value))
            {
                throw new InputValidationException(
                    "借入額は1円単位の整数で入力してください。",
                    _lblPrincipal,
                    _txtPrincipal);
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

        private long ReadDesiredMonthlyPaymentAmount()
        {
            long value;
            if (TryReadDesiredMonthlyPaymentAmount(out value))
            {
                return value;
            }

            RepaymentType repaymentType = GetSelectedValue(
                _cmbRepaymentType,
                RepaymentType.EqualPayment);
            RepaymentSettingMode settingMode = GetSelectedValue(
                _cmbRepaymentSettingMode,
                RepaymentSettingMode.ByPeriod);
            bool monthlyAmountIsRequired =
                repaymentType != RepaymentType.LumpSum &&
                settingMode == RepaymentSettingMode.ByMonthlyPayment;

            if (!monthlyAmountIsRequired)
            {
                return _sourceLoan != null && _sourceLoan.DesiredMonthlyPaymentAmount > 0
                    ? _sourceLoan.DesiredMonthlyPaymentAmount
                    : 30000L;
            }

            string amountName = repaymentType == RepaymentType.EqualPrincipal
                ? "毎月の元金返済額"
                : "毎月のお支払い額";
            throw new InputValidationException(
                amountName + "は1円単位の整数で入力してください。",
                _lblDesiredMonthlyAmount,
                _txtDesiredMonthlyPayment);
        }

        private bool TryReadDesiredMonthlyPaymentAmount(out long value)
        {
            string text = (_txtDesiredMonthlyPayment == null
                ? string.Empty
                : _txtDesiredMonthlyPayment.Text ?? string.Empty).Trim();
            NumberStyles styles = NumberStyles.Integer | NumberStyles.AllowThousands;
            return long.TryParse(text, styles, CultureInfo.CurrentCulture, out value) ||
                   long.TryParse(text, styles, CultureInfo.InvariantCulture, out value);
        }

        private long ReadBonusPrincipalAmount()
        {
            long value;
            if (TryReadBonusPrincipalAmount(out value))
            {
                return value;
            }

            if (GetSelectedBonusPaymentFrequency() == BonusPaymentFrequency.None)
            {
                return _sourceLoan != null && _sourceLoan.BonusPrincipalAmount > 0
                    ? _sourceLoan.BonusPrincipalAmount
                    : 500000L;
            }

            throw new InputValidationException(
                "1回あたりのボーナス加算元金は1円単位の整数で入力してください。",
                _lblBonusPrincipal,
                _txtBonusPrincipal);
        }

        private bool TryReadBonusPrincipalAmount(out long value)
        {
            string text = (_txtBonusPrincipal == null
                ? string.Empty
                : _txtBonusPrincipal.Text ?? string.Empty).Trim();
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
                throw new InputValidationException(
                    "年間金利を数値で入力してください。",
                    _lblRate,
                    _txtRate);
            }

            int[] bits = decimal.GetBits(value);
            int scale = (bits[3] >> 16) & 0x7F;
            if (scale > _settings.InterestRateDecimalPlaces)
            {
                throw new InputValidationException(
                    "年間金利は小数点以下" +
                    _settings.InterestRateDecimalPlaces +
                    "桁までで入力してください。",
                    _lblRate,
                    _txtRate);
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


        private sealed class InputValidationException : ArgumentException
        {
            public Control[] Targets { get; private set; }

            public InputValidationException(
                string message,
                params Control[] targets)
                : base(message)
            {
                Targets = targets ?? new Control[0];
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
