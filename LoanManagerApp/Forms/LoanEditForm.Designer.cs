using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LoanManagerApp.Forms
{
    partial class LoanEditForm
    {
        private IContainer components = null;
        private TableLayoutPanel _root;
        private Panel _scrollPanel;
        private TableLayoutPanel _fields;
        private Label _lblName;
        private Label _lblNameNote;
        private TextBox _txtName;
        private Label _lblPrincipal;
        private Label _lblPrincipalNote;
        private TextBox _txtPrincipal;
        private Label _lblRate;
        private Label _lblRateNote;
        private TextBox _txtRate;
        private Label _lblRepaymentType;
        private Label _lblRepaymentTypeNote;
        private ComboBox _cmbRepaymentType;
        private Label _lblInterestMethod;
        private Label _lblInterestMethodNote;
        private ComboBox _cmbInterestMethod;
        private Label _lblBorrowDate;
        private Label _lblBorrowDateNote;
        private DateTimePicker _dtpBorrowDate;
        private Label _lblFirstRepaymentDate;
        private Label _lblFirstRepaymentDateNote;
        private DateTimePicker _dtpFirstRepaymentDate;
        private Label _lblRepaymentSettingMode;
        private Label _lblRepaymentSettingModeNote;
        private ComboBox _cmbRepaymentSettingMode;
        private Label _lblPeriod;
        private Label _lblPeriodNote;
        private FlowLayoutPanel _pnlPeriod;
        private NumericUpDown _nudYears;
        private Label _lblYearsUnit;
        private NumericUpDown _nudMonths;
        private Label _lblMonthsUnit;
        private Label _lblDesiredMonthlyAmount;
        private Label _lblMonthlyPaymentNote;
        private TextBox _txtDesiredMonthlyPayment;
        private Label _lblPaymentDay;
        private Label _lblPaymentDayNote;
        private NumericUpDown _nudPaymentDay;
        private Label _lblUseBonus;
        private Label _lblUseBonusNote;
        private FlowLayoutPanel _bonusFrequencyPanel;
        private RadioButton _rdoBonusNone;
        private RadioButton _rdoBonusOnce;
        private RadioButton _rdoBonusTwice;
        private GroupBox _grpBonus;
        private TableLayoutPanel _bonusTable;
        private Label _lblBonusPrincipal;
        private TextBox _txtBonusPrincipal;
        private Label _lblBonusMonths;
        private FlowLayoutPanel _bonusMonthsPanel;
        private ComboBox _cmbBonusMonth1;
        private Label _lblBonusMonthsSeparator;
        private ComboBox _cmbBonusMonth2;
        private Label _lblBonusMonthsSuffix;
        private Label _lblBonusNote;
        private Label _lblMemo;
        private Label _lblMemoNote;
        private TextBox _txtMemo;
        private Label _lblPreview;
        private FlowLayoutPanel _buttons;
        private Button _btnCancel;
        private Button _btnSave;
        private Button _btnCalculate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this._root = new TableLayoutPanel();
            this._scrollPanel = new Panel();
            this._fields = new TableLayoutPanel();
            this._lblName = new Label();
            this._txtName = new TextBox();
            this._lblNameNote = new Label();
            this._lblPrincipal = new Label();
            this._txtPrincipal = new TextBox();
            this._lblPrincipalNote = new Label();
            this._lblRate = new Label();
            this._txtRate = new TextBox();
            this._lblRateNote = new Label();
            this._lblRepaymentType = new Label();
            this._cmbRepaymentType = new ComboBox();
            this._lblRepaymentTypeNote = new Label();
            this._lblInterestMethod = new Label();
            this._cmbInterestMethod = new ComboBox();
            this._lblInterestMethodNote = new Label();
            this._lblBorrowDate = new Label();
            this._dtpBorrowDate = new DateTimePicker();
            this._lblBorrowDateNote = new Label();
            this._lblFirstRepaymentDate = new Label();
            this._dtpFirstRepaymentDate = new DateTimePicker();
            this._lblFirstRepaymentDateNote = new Label();
            this._lblRepaymentSettingMode = new Label();
            this._cmbRepaymentSettingMode = new ComboBox();
            this._lblRepaymentSettingModeNote = new Label();
            this._lblPeriod = new Label();
            this._pnlPeriod = new FlowLayoutPanel();
            this._nudYears = new NumericUpDown();
            this._lblYearsUnit = new Label();
            this._nudMonths = new NumericUpDown();
            this._lblMonthsUnit = new Label();
            this._lblPeriodNote = new Label();
            this._lblDesiredMonthlyAmount = new Label();
            this._txtDesiredMonthlyPayment = new TextBox();
            this._lblMonthlyPaymentNote = new Label();
            this._lblPaymentDay = new Label();
            this._nudPaymentDay = new NumericUpDown();
            this._lblPaymentDayNote = new Label();
            this._lblUseBonus = new Label();
            this._bonusFrequencyPanel = new FlowLayoutPanel();
            this._rdoBonusNone = new RadioButton();
            this._rdoBonusOnce = new RadioButton();
            this._rdoBonusTwice = new RadioButton();
            this._lblUseBonusNote = new Label();
            this._grpBonus = new GroupBox();
            this._bonusTable = new TableLayoutPanel();
            this._lblBonusPrincipal = new Label();
            this._txtBonusPrincipal = new TextBox();
            this._lblBonusMonths = new Label();
            this._bonusMonthsPanel = new FlowLayoutPanel();
            this._cmbBonusMonth1 = new ComboBox();
            this._lblBonusMonthsSeparator = new Label();
            this._cmbBonusMonth2 = new ComboBox();
            this._lblBonusMonthsSuffix = new Label();
            this._lblBonusNote = new Label();
            this._lblMemo = new Label();
            this._txtMemo = new TextBox();
            this._lblMemoNote = new Label();
            this._lblPreview = new Label();
            this._buttons = new FlowLayoutPanel();
            this._btnCancel = new Button();
            this._btnSave = new Button();
            this._btnCalculate = new Button();
            this._root.SuspendLayout();
            this._scrollPanel.SuspendLayout();
            this._fields.SuspendLayout();
            this._pnlPeriod.SuspendLayout();
            this._bonusFrequencyPanel.SuspendLayout();
            ((ISupportInitialize)(this._nudYears)).BeginInit();
            ((ISupportInitialize)(this._nudMonths)).BeginInit();
            ((ISupportInitialize)(this._nudPaymentDay)).BeginInit();
            this._grpBonus.SuspendLayout();
            this._bonusTable.SuspendLayout();
            this._bonusMonthsPanel.SuspendLayout();
            this._buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // _root
            // 
            this._root.ColumnCount = 1;
            this._root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this._root.Controls.Add(this._scrollPanel, 0, 0);
            this._root.Controls.Add(this._lblPreview, 0, 1);
            this._root.Controls.Add(this._buttons, 0, 2);
            this._root.Dock = DockStyle.Fill;
            this._root.Location = new Point(0, 0);
            this._root.Name = "_root";
            this._root.Padding = new Padding(12);
            this._root.RowCount = 3;
            this._root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this._root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._root.Size = new Size(1124, 1020);
            this._root.TabIndex = 0;
            this._root.MouseDown += new MouseEventHandler(this.BackgroundMouseDown);
            // 
            // _scrollPanel
            // 
            this._scrollPanel.AutoScroll = true;
            this._scrollPanel.Controls.Add(this._fields);
            this._scrollPanel.Dock = DockStyle.Fill;
            this._scrollPanel.Location = new Point(15, 15);
            this._scrollPanel.Name = "_scrollPanel";
            this._scrollPanel.Size = new Size(1094, 764);
            this._scrollPanel.TabIndex = 0;
            this._scrollPanel.MouseDown += new MouseEventHandler(this.BackgroundMouseDown);
            // 
            // _fields
            // 
            this._fields.AutoSize = true;
            this._fields.ColumnCount = 3;
            this._fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            this._fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this._fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 310F));
            this._fields.Controls.Add(this._lblName, 0, 0);
            this._fields.Controls.Add(this._txtName, 1, 0);
            this._fields.Controls.Add(this._lblNameNote, 2, 0);
            this._fields.Controls.Add(this._lblPrincipal, 0, 1);
            this._fields.Controls.Add(this._txtPrincipal, 1, 1);
            this._fields.Controls.Add(this._lblPrincipalNote, 2, 1);
            this._fields.Controls.Add(this._lblRate, 0, 2);
            this._fields.Controls.Add(this._txtRate, 1, 2);
            this._fields.Controls.Add(this._lblRateNote, 2, 2);
            this._fields.Controls.Add(this._lblRepaymentType, 0, 3);
            this._fields.Controls.Add(this._cmbRepaymentType, 1, 3);
            this._fields.Controls.Add(this._lblRepaymentTypeNote, 2, 3);
            this._fields.Controls.Add(this._lblInterestMethod, 0, 4);
            this._fields.Controls.Add(this._cmbInterestMethod, 1, 4);
            this._fields.Controls.Add(this._lblInterestMethodNote, 2, 4);
            this._fields.Controls.Add(this._lblBorrowDate, 0, 5);
            this._fields.Controls.Add(this._dtpBorrowDate, 1, 5);
            this._fields.Controls.Add(this._lblBorrowDateNote, 2, 5);
            this._fields.Controls.Add(this._lblFirstRepaymentDate, 0, 6);
            this._fields.Controls.Add(this._dtpFirstRepaymentDate, 1, 6);
            this._fields.Controls.Add(this._lblFirstRepaymentDateNote, 2, 6);
            this._fields.Controls.Add(this._lblRepaymentSettingMode, 0, 7);
            this._fields.Controls.Add(this._cmbRepaymentSettingMode, 1, 7);
            this._fields.Controls.Add(this._lblRepaymentSettingModeNote, 2, 7);
            this._fields.Controls.Add(this._lblPeriod, 0, 8);
            this._fields.Controls.Add(this._pnlPeriod, 1, 8);
            this._fields.Controls.Add(this._lblPeriodNote, 2, 8);
            this._fields.Controls.Add(this._lblDesiredMonthlyAmount, 0, 9);
            this._fields.Controls.Add(this._txtDesiredMonthlyPayment, 1, 9);
            this._fields.Controls.Add(this._lblMonthlyPaymentNote, 2, 9);
            this._fields.Controls.Add(this._lblPaymentDay, 0, 10);
            this._fields.Controls.Add(this._nudPaymentDay, 1, 10);
            this._fields.Controls.Add(this._lblPaymentDayNote, 2, 10);
            this._fields.Controls.Add(this._lblUseBonus, 0, 11);
            this._fields.Controls.Add(this._bonusFrequencyPanel, 1, 11);
            this._fields.Controls.Add(this._lblUseBonusNote, 2, 11);
            this._fields.Controls.Add(this._grpBonus, 0, 12);
            this._fields.Controls.Add(this._lblMemo, 0, 13);
            this._fields.Controls.Add(this._txtMemo, 1, 13);
            this._fields.Controls.Add(this._lblMemoNote, 2, 13);
            this._fields.Dock = DockStyle.Top;
            this._fields.Location = new Point(0, 0);
            this._fields.Name = "_fields";
            this._fields.Padding = new Padding(0, 0, 12, 0);
            this._fields.RowCount = 14;
            this._fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._fields.Size = new Size(1094, 782);
            this._fields.TabIndex = 0;
            this._fields.SetColumnSpan(this._grpBonus, 3);
            this._fields.MouseDown += new MouseEventHandler(this.BackgroundMouseDown);
            // 
            // common field labels
            // 
            this._lblName.Anchor = AnchorStyles.Left;
            this._lblName.AutoSize = true;
            this._lblName.Margin = new Padding(3, 10, 3, 10);
            this._lblName.Text = "ローン名称";
            this._lblPrincipal.Anchor = AnchorStyles.Left;
            this._lblPrincipal.AutoSize = true;
            this._lblPrincipal.Margin = new Padding(3, 10, 3, 10);
            this._lblPrincipal.Text = "借入額";
            this._lblRate.Anchor = AnchorStyles.Left;
            this._lblRate.AutoSize = true;
            this._lblRate.Margin = new Padding(3, 10, 3, 10);
            this._lblRate.Text = "年間金利";
            this._lblRepaymentType.Anchor = AnchorStyles.Left;
            this._lblRepaymentType.AutoSize = true;
            this._lblRepaymentType.Margin = new Padding(3, 10, 3, 10);
            this._lblRepaymentType.Text = "返済方式";
            this._lblInterestMethod.Anchor = AnchorStyles.Left;
            this._lblInterestMethod.AutoSize = true;
            this._lblInterestMethod.Margin = new Padding(3, 10, 3, 10);
            this._lblInterestMethod.Text = "利息の計算方法";
            this._lblBorrowDate.Anchor = AnchorStyles.Left;
            this._lblBorrowDate.AutoSize = true;
            this._lblBorrowDate.Margin = new Padding(3, 10, 3, 10);
            this._lblBorrowDate.Text = "借入日";
            this._lblFirstRepaymentDate.Anchor = AnchorStyles.Left;
            this._lblFirstRepaymentDate.AutoSize = true;
            this._lblFirstRepaymentDate.Margin = new Padding(3, 10, 3, 10);
            this._lblFirstRepaymentDate.Text = "初回返済日";
            this._lblRepaymentSettingMode.Anchor = AnchorStyles.Left;
            this._lblRepaymentSettingMode.AutoSize = true;
            this._lblRepaymentSettingMode.Margin = new Padding(3, 10, 3, 10);
            this._lblRepaymentSettingMode.Text = "返済条件";
            this._lblPeriod.Anchor = AnchorStyles.Left;
            this._lblPeriod.AutoSize = true;
            this._lblPeriod.Margin = new Padding(3, 10, 3, 10);
            this._lblPeriod.Text = "返済期間";
            this._lblDesiredMonthlyAmount.Anchor = AnchorStyles.Left;
            this._lblDesiredMonthlyAmount.AutoSize = true;
            this._lblDesiredMonthlyAmount.Margin = new Padding(3, 10, 3, 10);
            this._lblDesiredMonthlyAmount.Text = "毎月のお支払い額";
            this._lblPaymentDay.Anchor = AnchorStyles.Left;
            this._lblPaymentDay.AutoSize = true;
            this._lblPaymentDay.Margin = new Padding(3, 10, 3, 10);
            this._lblPaymentDay.Text = "毎月の返済日";
            this._lblUseBonus.Anchor = AnchorStyles.Left;
            this._lblUseBonus.AutoSize = true;
            this._lblUseBonus.Margin = new Padding(3, 10, 3, 10);
            this._lblUseBonus.Text = "ボーナス払い";
            this._lblMemo.Anchor = AnchorStyles.Left;
            this._lblMemo.AutoSize = true;
            this._lblMemo.Margin = new Padding(3, 10, 3, 10);
            this._lblMemo.Text = "メモ";
            this._lblNameNote.Anchor = AnchorStyles.Left;
            this._lblNameNote.AutoSize = true;
            this._lblNameNote.Margin = new Padding(3, 10, 3, 10);
            this._lblNameNote.Text = "必須";
            this._lblPrincipalNote.Anchor = AnchorStyles.Left;
            this._lblPrincipalNote.AutoSize = true;
            this._lblPrincipalNote.Margin = new Padding(3, 10, 3, 10);
            this._lblPrincipalNote.Text = "円";
            this._lblRateNote.Anchor = AnchorStyles.Left;
            this._lblRateNote.AutoSize = true;
            this._lblRateNote.Margin = new Padding(3, 10, 3, 10);
            this._lblRateNote.Text = "%（小数点以下2桁まで）";
            this._lblRepaymentTypeNote.Anchor = AnchorStyles.Left;
            this._lblRepaymentTypeNote.AutoSize = true;
            this._lblRepaymentTypeNote.Margin = new Padding(3, 10, 3, 10);
            this._lblRepaymentTypeNote.Text = string.Empty;
            this._lblInterestMethodNote.Anchor = AnchorStyles.Left;
            this._lblInterestMethodNote.AutoSize = true;
            this._lblInterestMethodNote.Margin = new Padding(3, 10, 3, 10);
            this._lblInterestMethodNote.Text = string.Empty;
            this._lblBorrowDateNote.Anchor = AnchorStyles.Left;
            this._lblBorrowDateNote.AutoSize = true;
            this._lblBorrowDateNote.Margin = new Padding(3, 10, 3, 10);
            this._lblBorrowDateNote.Text = string.Empty;
            this._lblFirstRepaymentDateNote.Anchor = AnchorStyles.Left;
            this._lblFirstRepaymentDateNote.AutoSize = true;
            this._lblFirstRepaymentDateNote.Margin = new Padding(3, 10, 3, 10);
            this._lblFirstRepaymentDateNote.Text = string.Empty;
            this._lblRepaymentSettingModeNote.Anchor = AnchorStyles.Left;
            this._lblRepaymentSettingModeNote.AutoSize = true;
            this._lblRepaymentSettingModeNote.Margin = new Padding(3, 10, 3, 10);
            this._lblRepaymentSettingModeNote.Text = string.Empty;
            this._lblPeriodNote.Anchor = AnchorStyles.Left;
            this._lblPeriodNote.AutoSize = true;
            this._lblPeriodNote.Margin = new Padding(3, 10, 3, 10);
            this._lblPeriodNote.Text = "1～600か月";
            this._lblMonthlyPaymentNote.AutoEllipsis = true;
            this._lblMonthlyPaymentNote.AutoSize = false;
            this._lblMonthlyPaymentNote.Dock = DockStyle.Fill;
            this._lblMonthlyPaymentNote.Margin = new Padding(3, 6, 3, 6);
            this._lblMonthlyPaymentNote.Text = "円（元金＋利息）";
            this._lblMonthlyPaymentNote.TextAlign = ContentAlignment.MiddleLeft;
            this._lblPaymentDayNote.Anchor = AnchorStyles.Left;
            this._lblPaymentDayNote.AutoSize = true;
            this._lblPaymentDayNote.Margin = new Padding(3, 10, 3, 10);
            this._lblPaymentDayNote.Text = "日（超過時は月末）";
            this._lblUseBonusNote.Anchor = AnchorStyles.Left;
            this._lblUseBonusNote.AutoSize = true;
            this._lblUseBonusNote.Margin = new Padding(3, 10, 3, 10);
            this._lblUseBonusNote.Text = "一括返済では使用できません";
            this._lblMemoNote.Anchor = AnchorStyles.Left;
            this._lblMemoNote.AutoSize = true;
            this._lblMemoNote.Margin = new Padding(3, 10, 3, 10);
            this._lblMemoNote.Text = string.Empty;
            // 
            // _txtName
            // 
            this._txtName.Dock = DockStyle.Fill;
            this._txtName.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._txtName.Location = new Point(223, 6);
            this._txtName.Margin = new Padding(3, 6, 3, 6);
            this._txtName.MaxLength = 100;
            this._txtName.Name = "_txtName";
            this._txtName.Size = new Size(586, 39);
            this._txtName.TabIndex = 0;
            // 
            // _txtPrincipal
            // 
            this._txtPrincipal.Dock = DockStyle.Left;
            this._txtPrincipal.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._txtPrincipal.Location = new Point(223, 57);
            this._txtPrincipal.Margin = new Padding(3, 6, 3, 6);
            this._txtPrincipal.MaxLength = 20;
            this._txtPrincipal.Name = "_txtPrincipal";
            this._txtPrincipal.Size = new Size(280, 39);
            this._txtPrincipal.TabIndex = 1;
            this._txtPrincipal.TextAlign = HorizontalAlignment.Right;
            this._txtPrincipal.Enter += new System.EventHandler(this.PrincipalEnter);
            this._txtPrincipal.Leave += new System.EventHandler(this.PrincipalLeave);
            this._txtPrincipal.KeyPress += new KeyPressEventHandler(this.PrincipalKeyPress);
            // 
            // _txtRate
            // 
            this._txtRate.Dock = DockStyle.Left;
            this._txtRate.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._txtRate.Location = new Point(223, 108);
            this._txtRate.Margin = new Padding(3, 6, 3, 6);
            this._txtRate.MaxLength = 20;
            this._txtRate.Name = "_txtRate";
            this._txtRate.Size = new Size(180, 39);
            this._txtRate.TabIndex = 2;
            this._txtRate.TextAlign = HorizontalAlignment.Right;
            this._txtRate.TextChanged += new System.EventHandler(this.PreviewValueChanged);
            // 
            // combo boxes
            // 
            this._cmbRepaymentType.Dock = DockStyle.Left;
            this._cmbRepaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            this._cmbRepaymentType.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._cmbRepaymentType.Margin = new Padding(3, 6, 3, 6);
            this._cmbRepaymentType.Size = new Size(560, 39);
            this._cmbRepaymentType.TabIndex = 3;
            this._cmbRepaymentType.SelectedIndexChanged += new System.EventHandler(this.RepaymentTypeChanged);
            this._cmbInterestMethod.Dock = DockStyle.Left;
            this._cmbInterestMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            this._cmbInterestMethod.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._cmbInterestMethod.Margin = new Padding(3, 6, 3, 6);
            this._cmbInterestMethod.Size = new Size(310, 39);
            this._cmbInterestMethod.TabIndex = 4;
            this._cmbInterestMethod.SelectedIndexChanged += new System.EventHandler(this.PreviewValueChanged);
            this._cmbRepaymentSettingMode.Dock = DockStyle.Left;
            this._cmbRepaymentSettingMode.DropDownStyle = ComboBoxStyle.DropDownList;
            this._cmbRepaymentSettingMode.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._cmbRepaymentSettingMode.Margin = new Padding(3, 6, 3, 6);
            this._cmbRepaymentSettingMode.Size = new Size(310, 39);
            this._cmbRepaymentSettingMode.TabIndex = 7;
            this._cmbRepaymentSettingMode.SelectedIndexChanged += new System.EventHandler(this.RepaymentSettingModeChanged);
            // 
            // date controls
            // 
            this._dtpBorrowDate.CustomFormat = "yyyy年MM月dd日";
            this._dtpBorrowDate.Dock = DockStyle.Left;
            this._dtpBorrowDate.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._dtpBorrowDate.Format = DateTimePickerFormat.Custom;
            this._dtpBorrowDate.Margin = new Padding(3, 6, 3, 6);
            this._dtpBorrowDate.Size = new Size(230, 39);
            this._dtpBorrowDate.TabIndex = 5;
            this._dtpBorrowDate.ValueChanged += new System.EventHandler(this.PreviewValueChanged);
            this._dtpFirstRepaymentDate.CustomFormat = "yyyy年MM月dd日";
            this._dtpFirstRepaymentDate.Dock = DockStyle.Left;
            this._dtpFirstRepaymentDate.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._dtpFirstRepaymentDate.Format = DateTimePickerFormat.Custom;
            this._dtpFirstRepaymentDate.Margin = new Padding(3, 6, 3, 6);
            this._dtpFirstRepaymentDate.Size = new Size(230, 39);
            this._dtpFirstRepaymentDate.TabIndex = 6;
            this._dtpFirstRepaymentDate.ValueChanged += new System.EventHandler(this.PreviewValueChanged);
            // 
            // _pnlPeriod
            // 
            this._pnlPeriod.AutoSize = true;
            this._pnlPeriod.Controls.Add(this._nudYears);
            this._pnlPeriod.Controls.Add(this._lblYearsUnit);
            this._pnlPeriod.Controls.Add(this._nudMonths);
            this._pnlPeriod.Controls.Add(this._lblMonthsUnit);
            this._pnlPeriod.FlowDirection = FlowDirection.LeftToRight;
            this._pnlPeriod.Location = new Point(220, 357);
            this._pnlPeriod.Margin = new Padding(0);
            this._pnlPeriod.Name = "_pnlPeriod";
            this._pnlPeriod.Size = new Size(264, 45);
            this._pnlPeriod.TabIndex = 8;
            this._pnlPeriod.WrapContents = false;
            this._nudYears.DecimalPlaces = 0;
            this._nudYears.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._nudYears.Increment = 1;
            this._nudYears.Margin = new Padding(3, 6, 3, 6);
            this._nudYears.Maximum = 50;
            this._nudYears.Minimum = 0;
            this._nudYears.Size = new Size(90, 39);
            this._nudYears.ThousandsSeparator = false;
            this._nudYears.TabIndex = 0;
            this._nudYears.ValueChanged += new System.EventHandler(this.PeriodYearsValueChanged);
            this._lblYearsUnit.AutoSize = true;
            this._lblYearsUnit.Margin = new Padding(4, 6, 12, 0);
            this._lblYearsUnit.Text = "年";
            this._nudMonths.DecimalPlaces = 0;
            this._nudMonths.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._nudMonths.Increment = 1;
            this._nudMonths.Margin = new Padding(3, 6, 3, 6);
            this._nudMonths.Maximum = 12;
            this._nudMonths.Minimum = 0;
            this._nudMonths.Size = new Size(90, 39);
            this._nudMonths.ThousandsSeparator = false;
            this._nudMonths.TabIndex = 1;
            this._nudMonths.ValueChanged += new System.EventHandler(this.PeriodMonthsValueChanged);
            this._lblMonthsUnit.AutoSize = true;
            this._lblMonthsUnit.Margin = new Padding(4, 6, 0, 0);
            this._lblMonthsUnit.Text = "か月";
            // 
            // amount/day controls
            // 
            this._txtDesiredMonthlyPayment.Dock = DockStyle.Left;
            this._txtDesiredMonthlyPayment.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._txtDesiredMonthlyPayment.Location = new Point(223, 459);
            this._txtDesiredMonthlyPayment.Margin = new Padding(3, 6, 3, 6);
            this._txtDesiredMonthlyPayment.MaxLength = 20;
            this._txtDesiredMonthlyPayment.Name = "_txtDesiredMonthlyPayment";
            this._txtDesiredMonthlyPayment.Size = new Size(280, 39);
            this._txtDesiredMonthlyPayment.TabIndex = 9;
            this._txtDesiredMonthlyPayment.TextAlign = HorizontalAlignment.Right;
            this._txtDesiredMonthlyPayment.Enter += new System.EventHandler(this.DesiredMonthlyPaymentEnter);
            this._txtDesiredMonthlyPayment.Leave += new System.EventHandler(this.DesiredMonthlyPaymentLeave);
            this._txtDesiredMonthlyPayment.KeyPress += new KeyPressEventHandler(this.AmountKeyPress);
            this._nudPaymentDay.DecimalPlaces = 0;
            this._nudPaymentDay.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._nudPaymentDay.Increment = 1;
            this._nudPaymentDay.Margin = new Padding(3, 6, 3, 6);
            this._nudPaymentDay.Maximum = 31;
            this._nudPaymentDay.Minimum = 1;
            this._nudPaymentDay.Size = new Size(110, 39);
            this._nudPaymentDay.ThousandsSeparator = false;
            this._nudPaymentDay.TabIndex = 10;
            this._nudPaymentDay.ValueChanged += new System.EventHandler(this.PreviewValueChanged);
            // 
            // _bonusFrequencyPanel
            // 
            this._bonusFrequencyPanel.AutoSize = true;
            this._bonusFrequencyPanel.Controls.Add(this._rdoBonusNone);
            this._bonusFrequencyPanel.Controls.Add(this._rdoBonusOnce);
            this._bonusFrequencyPanel.Controls.Add(this._rdoBonusTwice);
            this._bonusFrequencyPanel.Dock = DockStyle.Left;
            this._bonusFrequencyPanel.Location = new Point(220, 508);
            this._bonusFrequencyPanel.Margin = new Padding(0);
            this._bonusFrequencyPanel.Name = "_bonusFrequencyPanel";
            this._bonusFrequencyPanel.Size = new Size(324, 48);
            this._bonusFrequencyPanel.TabIndex = 11;
            this._bonusFrequencyPanel.WrapContents = false;
            // 
            // _rdoBonusNone
            // 
            this._rdoBonusNone.AutoSize = true;
            this._rdoBonusNone.Checked = true;
            this._rdoBonusNone.Location = new Point(3, 8);
            this._rdoBonusNone.Margin = new Padding(3, 8, 12, 8);
            this._rdoBonusNone.Name = "_rdoBonusNone";
            this._rdoBonusNone.Size = new Size(65, 32);
            this._rdoBonusNone.TabIndex = 0;
            this._rdoBonusNone.TabStop = true;
            this._rdoBonusNone.Text = "なし";
            this._rdoBonusNone.UseVisualStyleBackColor = true;
            this._rdoBonusNone.CheckedChanged += new System.EventHandler(this.BonusPaymentFrequencyChanged);
            // 
            // _rdoBonusOnce
            // 
            this._rdoBonusOnce.AutoSize = true;
            this._rdoBonusOnce.Location = new Point(83, 8);
            this._rdoBonusOnce.Margin = new Padding(3, 8, 12, 8);
            this._rdoBonusOnce.Name = "_rdoBonusOnce";
            this._rdoBonusOnce.Size = new Size(91, 32);
            this._rdoBonusOnce.TabIndex = 1;
            this._rdoBonusOnce.Text = "年1回";
            this._rdoBonusOnce.UseVisualStyleBackColor = true;
            this._rdoBonusOnce.CheckedChanged += new System.EventHandler(this.BonusPaymentFrequencyChanged);
            // 
            // _rdoBonusTwice
            // 
            this._rdoBonusTwice.AutoSize = true;
            this._rdoBonusTwice.Location = new Point(189, 8);
            this._rdoBonusTwice.Margin = new Padding(3, 8, 3, 8);
            this._rdoBonusTwice.Name = "_rdoBonusTwice";
            this._rdoBonusTwice.Size = new Size(91, 32);
            this._rdoBonusTwice.TabIndex = 2;
            this._rdoBonusTwice.Text = "年2回";
            this._rdoBonusTwice.UseVisualStyleBackColor = true;
            this._rdoBonusTwice.CheckedChanged += new System.EventHandler(this.BonusPaymentFrequencyChanged);
            // 
            // _grpBonus
            // 
            this._grpBonus.AutoSize = false;
            this._grpBonus.Controls.Add(this._bonusTable);
            this._grpBonus.Dock = DockStyle.Top;
            this._grpBonus.Location = new Point(3, 559);
            this._grpBonus.Name = "_grpBonus";
            this._grpBonus.MinimumSize = new Size(0, 220);
            this._grpBonus.Padding = new Padding(10);
            this._grpBonus.Size = new Size(1076, 220);
            this._grpBonus.TabIndex = 12;
            this._grpBonus.TabStop = false;
            this._grpBonus.Text = "ボーナス払い設定";
            // 
            // _bonusTable
            // 
            this._bonusTable.AutoSize = false;
            this._bonusTable.ColumnCount = 2;
            this._bonusTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 310F));
            this._bonusTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this._bonusTable.Controls.Add(this._lblBonusPrincipal, 0, 0);
            this._bonusTable.Controls.Add(this._txtBonusPrincipal, 1, 0);
            this._bonusTable.Controls.Add(this._lblBonusMonths, 0, 1);
            this._bonusTable.Controls.Add(this._bonusMonthsPanel, 1, 1);
            this._bonusTable.Controls.Add(this._lblBonusNote, 0, 2);
            this._bonusTable.Dock = DockStyle.Fill;
            this._bonusTable.Location = new Point(10, 37);
            this._bonusTable.Name = "_bonusTable";
            this._bonusTable.RowCount = 3;
            this._bonusTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            this._bonusTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            this._bonusTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this._bonusTable.Size = new Size(1056, 173);
            this._bonusTable.TabIndex = 0;
            this._bonusTable.SetColumnSpan(this._lblBonusNote, 2);
            this._lblBonusPrincipal.Anchor = AnchorStyles.Left;
            this._lblBonusPrincipal.AutoSize = true;
            this._lblBonusPrincipal.Margin = new Padding(3, 8, 3, 8);
            this._lblBonusPrincipal.Text = "ボーナス払い対象元金（1回あたり）";
            this._lblBonusMonths.Anchor = AnchorStyles.Left;
            this._lblBonusMonths.AutoSize = true;
            this._lblBonusMonths.Margin = new Padding(3, 8, 3, 8);
            this._lblBonusMonths.Text = "ボーナス払い月";
            this._txtBonusPrincipal.Dock = DockStyle.Left;
            this._txtBonusPrincipal.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._txtBonusPrincipal.Margin = new Padding(3, 6, 3, 6);
            this._txtBonusPrincipal.MaxLength = 20;
            this._txtBonusPrincipal.Name = "_txtBonusPrincipal";
            this._txtBonusPrincipal.Size = new Size(280, 39);
            this._txtBonusPrincipal.TabIndex = 0;
            this._txtBonusPrincipal.TextAlign = HorizontalAlignment.Right;
            this._txtBonusPrincipal.Enter += new System.EventHandler(this.BonusPrincipalEnter);
            this._txtBonusPrincipal.Leave += new System.EventHandler(this.BonusPrincipalLeave);
            this._txtBonusPrincipal.KeyPress += new KeyPressEventHandler(this.AmountKeyPress);
            // 
            // _bonusMonthsPanel
            // 
            this._bonusMonthsPanel.AutoSize = true;
            this._bonusMonthsPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this._bonusMonthsPanel.Controls.Add(this._cmbBonusMonth1);
            this._bonusMonthsPanel.Controls.Add(this._lblBonusMonthsSeparator);
            this._bonusMonthsPanel.Controls.Add(this._cmbBonusMonth2);
            this._bonusMonthsPanel.Controls.Add(this._lblBonusMonthsSuffix);
            this._bonusMonthsPanel.Location = new Point(220, 48);
            this._bonusMonthsPanel.Margin = new Padding(0);
            this._bonusMonthsPanel.MinimumSize = new Size(0, 58);
            this._bonusMonthsPanel.Name = "_bonusMonthsPanel";
            this._bonusMonthsPanel.Padding = new Padding(0, 2, 0, 12);
            this._bonusMonthsPanel.Size = new Size(245, 58);
            this._bonusMonthsPanel.TabIndex = 1;
            this._cmbBonusMonth1.DropDownStyle = ComboBoxStyle.DropDownList;
            this._cmbBonusMonth1.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._cmbBonusMonth1.Margin = new Padding(3, 3, 3, 8);
            this._cmbBonusMonth1.Size = new Size(85, 39);
            this._cmbBonusMonth1.TabIndex = 0;
            this._cmbBonusMonth1.SelectedIndexChanged += new System.EventHandler(this.PreviewValueChanged);
            this._lblBonusMonthsSeparator.AutoSize = true;
            this._lblBonusMonthsSeparator.Margin = new Padding(5, 6, 5, 8);
            this._lblBonusMonthsSeparator.Text = "月 と";
            this._cmbBonusMonth2.DropDownStyle = ComboBoxStyle.DropDownList;
            this._cmbBonusMonth2.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._cmbBonusMonth2.Margin = new Padding(3, 3, 3, 8);
            this._cmbBonusMonth2.Size = new Size(85, 39);
            this._cmbBonusMonth2.TabIndex = 1;
            this._cmbBonusMonth2.SelectedIndexChanged += new System.EventHandler(this.PreviewValueChanged);
            this._lblBonusMonthsSuffix.AutoSize = true;
            this._lblBonusMonthsSuffix.Margin = new Padding(5, 6, 0, 8);
            this._lblBonusMonthsSuffix.Text = "月";
            // 
            // _lblBonusNote
            // 
            this._lblBonusNote.AutoSize = true;
            this._lblBonusNote.Dock = DockStyle.Fill;
            this._lblBonusNote.Location = new Point(3, 101);
            this._lblBonusNote.Margin = new Padding(3, 8, 3, 8);
            this._lblBonusNote.MinimumSize = new Size(0, 56);
            this._lblBonusNote.Name = "_lblBonusNote";
            this._lblBonusNote.Size = new Size(798, 56);
            this._lblBonusNote.TabIndex = 2;
            this._lblBonusNote.Text = "指定した月ごとに、入力した元金額を通常返済へ上乗せします。金額を回数で分割することはありません。残高を超える場合は残高まで支払います。";
            // 
            // _txtMemo
            // 
            this._txtMemo.Dock = DockStyle.Fill;
            this._txtMemo.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this._txtMemo.Location = new Point(223, 722);
            this._txtMemo.Margin = new Padding(3, 6, 3, 6);
            this._txtMemo.MaxLength = 2000;
            this._txtMemo.Multiline = true;
            this._txtMemo.Name = "_txtMemo";
            this._txtMemo.ScrollBars = ScrollBars.Vertical;
            this._txtMemo.Size = new Size(586, 110);
            this._txtMemo.TabIndex = 13;
            // 
            // _lblPreview
            // 
            this._lblPreview.AutoSize = true;
            this._lblPreview.BorderStyle = BorderStyle.FixedSingle;
            this._lblPreview.Dock = DockStyle.Fill;
            this._lblPreview.Location = new Point(15, 782);
            this._lblPreview.MinimumSize = new Size(0, 118);
            this._lblPreview.Name = "_lblPreview";
            this._lblPreview.Padding = new Padding(10);
            this._lblPreview.Size = new Size(1094, 118);
            this._lblPreview.TabIndex = 1;
            this._lblPreview.Text = "入力内容から返済額を計算します。";
            // 
            // _buttons
            // 
            this._buttons.AutoSize = true;
            this._buttons.Controls.Add(this._btnCancel);
            this._buttons.Controls.Add(this._btnSave);
            this._buttons.Controls.Add(this._btnCalculate);
            this._buttons.Dock = DockStyle.Fill;
            this._buttons.FlowDirection = FlowDirection.RightToLeft;
            this._buttons.Location = new Point(15, 903);
            this._buttons.Name = "_buttons";
            this._buttons.Padding = new Padding(0, 10, 0, 0);
            this._buttons.Size = new Size(1094, 102);
            this._buttons.TabIndex = 2;
            this._btnCancel.AutoSize = true;
            this._btnCancel.DialogResult = DialogResult.Cancel;
            this._btnCancel.MinimumSize = new Size(120, 42);
            this._btnCancel.Text = "キャンセル";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.TabIndex = 2;
            this._btnSave.AutoSize = true;
            this._btnSave.DialogResult = DialogResult.None;
            this._btnSave.MinimumSize = new Size(120, 42);
            this._btnSave.Text = "保存";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.TabIndex = 1;
            this._btnSave.Click += new System.EventHandler(this.SaveClicked);
            this._btnCalculate.AutoSize = true;
            this._btnCalculate.DialogResult = DialogResult.None;
            this._btnCalculate.MinimumSize = new Size(120, 42);
            this._btnCalculate.Text = "再計算";
            this._btnCalculate.UseVisualStyleBackColor = true;
            this._btnCalculate.TabIndex = 0;
            this._btnCalculate.Click += new System.EventHandler(this.CalculateClicked);
            // 
            // LoanEditForm
            // 
            this.AcceptButton = this._btnSave;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new Size(1124, 1020);
            this.Controls.Add(this._root);
            this.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.MinimumSize = new Size(980, 740);
            this.Name = "LoanEditForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "ローンを登録";
            this._root.ResumeLayout(false);
            this._root.PerformLayout();
            this._scrollPanel.ResumeLayout(false);
            this._scrollPanel.PerformLayout();
            this._fields.ResumeLayout(false);
            this._fields.PerformLayout();
            this._pnlPeriod.ResumeLayout(false);
            this._pnlPeriod.PerformLayout();
            this._bonusFrequencyPanel.ResumeLayout(false);
            this._bonusFrequencyPanel.PerformLayout();
            ((ISupportInitialize)(this._nudYears)).EndInit();
            ((ISupportInitialize)(this._nudMonths)).EndInit();
            ((ISupportInitialize)(this._nudPaymentDay)).EndInit();
            this._grpBonus.ResumeLayout(false);
            this._grpBonus.PerformLayout();
            this._bonusTable.ResumeLayout(false);
            this._bonusTable.PerformLayout();
            this._bonusMonthsPanel.ResumeLayout(false);
            this._bonusMonthsPanel.PerformLayout();
            this._buttons.ResumeLayout(false);
            this._buttons.PerformLayout();
            this.ResumeLayout(false);
        }

    }
}
