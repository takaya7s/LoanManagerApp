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
            this._root = new System.Windows.Forms.TableLayoutPanel();
            this._scrollPanel = new System.Windows.Forms.Panel();
            this._fields = new System.Windows.Forms.TableLayoutPanel();
            this._lblName = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._lblNameNote = new System.Windows.Forms.Label();
            this._lblPrincipal = new System.Windows.Forms.Label();
            this._txtPrincipal = new System.Windows.Forms.TextBox();
            this._lblPrincipalNote = new System.Windows.Forms.Label();
            this._lblRate = new System.Windows.Forms.Label();
            this._txtRate = new System.Windows.Forms.TextBox();
            this._lblRateNote = new System.Windows.Forms.Label();
            this._lblRepaymentType = new System.Windows.Forms.Label();
            this._cmbRepaymentType = new System.Windows.Forms.ComboBox();
            this._lblRepaymentTypeNote = new System.Windows.Forms.Label();
            this._lblInterestMethod = new System.Windows.Forms.Label();
            this._cmbInterestMethod = new System.Windows.Forms.ComboBox();
            this._lblInterestMethodNote = new System.Windows.Forms.Label();
            this._lblBorrowDate = new System.Windows.Forms.Label();
            this._dtpBorrowDate = new System.Windows.Forms.DateTimePicker();
            this._lblBorrowDateNote = new System.Windows.Forms.Label();
            this._lblFirstRepaymentDate = new System.Windows.Forms.Label();
            this._dtpFirstRepaymentDate = new System.Windows.Forms.DateTimePicker();
            this._lblFirstRepaymentDateNote = new System.Windows.Forms.Label();
            this._lblRepaymentSettingMode = new System.Windows.Forms.Label();
            this._cmbRepaymentSettingMode = new System.Windows.Forms.ComboBox();
            this._lblRepaymentSettingModeNote = new System.Windows.Forms.Label();
            this._lblPeriod = new System.Windows.Forms.Label();
            this._pnlPeriod = new System.Windows.Forms.FlowLayoutPanel();
            this._nudYears = new System.Windows.Forms.NumericUpDown();
            this._lblYearsUnit = new System.Windows.Forms.Label();
            this._nudMonths = new System.Windows.Forms.NumericUpDown();
            this._lblMonthsUnit = new System.Windows.Forms.Label();
            this._lblPeriodNote = new System.Windows.Forms.Label();
            this._lblDesiredMonthlyAmount = new System.Windows.Forms.Label();
            this._txtDesiredMonthlyPayment = new System.Windows.Forms.TextBox();
            this._lblMonthlyPaymentNote = new System.Windows.Forms.Label();
            this._lblPaymentDay = new System.Windows.Forms.Label();
            this._nudPaymentDay = new System.Windows.Forms.NumericUpDown();
            this._lblPaymentDayNote = new System.Windows.Forms.Label();
            this._lblUseBonus = new System.Windows.Forms.Label();
            this._bonusFrequencyPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._rdoBonusNone = new System.Windows.Forms.RadioButton();
            this._rdoBonusOnce = new System.Windows.Forms.RadioButton();
            this._rdoBonusTwice = new System.Windows.Forms.RadioButton();
            this._lblUseBonusNote = new System.Windows.Forms.Label();
            this._grpBonus = new System.Windows.Forms.GroupBox();
            this._bonusTable = new System.Windows.Forms.TableLayoutPanel();
            this._lblBonusPrincipal = new System.Windows.Forms.Label();
            this._txtBonusPrincipal = new System.Windows.Forms.TextBox();
            this._lblBonusMonths = new System.Windows.Forms.Label();
            this._bonusMonthsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._cmbBonusMonth1 = new System.Windows.Forms.ComboBox();
            this._lblBonusMonthsSeparator = new System.Windows.Forms.Label();
            this._cmbBonusMonth2 = new System.Windows.Forms.ComboBox();
            this._lblBonusMonthsSuffix = new System.Windows.Forms.Label();
            this._lblBonusNote = new System.Windows.Forms.Label();
            this._lblMemo = new System.Windows.Forms.Label();
            this._txtMemo = new System.Windows.Forms.TextBox();
            this._lblMemoNote = new System.Windows.Forms.Label();
            this._lblPreview = new System.Windows.Forms.Label();
            this._buttons = new System.Windows.Forms.FlowLayoutPanel();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCalculate = new System.Windows.Forms.Button();
            this._root.SuspendLayout();
            this._scrollPanel.SuspendLayout();
            this._fields.SuspendLayout();
            this._pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudMonths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudPaymentDay)).BeginInit();
            this._bonusFrequencyPanel.SuspendLayout();
            this._grpBonus.SuspendLayout();
            this._bonusTable.SuspendLayout();
            this._bonusMonthsPanel.SuspendLayout();
            this._buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // _root
            // 
            this._root.ColumnCount = 1;
            this._root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._root.Controls.Add(this._scrollPanel, 0, 0);
            this._root.Controls.Add(this._lblPreview, 0, 1);
            this._root.Controls.Add(this._buttons, 0, 2);
            this._root.Dock = System.Windows.Forms.DockStyle.Fill;
            this._root.Location = new System.Drawing.Point(0, 0);
            this._root.Name = "_root";
            this._root.Padding = new System.Windows.Forms.Padding(12);
            this._root.RowCount = 3;
            this._root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._root.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._root.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._root.Size = new System.Drawing.Size(1124, 1020);
            this._root.TabIndex = 0;
            this._root.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackgroundMouseDown);
            // 
            // _scrollPanel
            // 
            this._scrollPanel.AutoScroll = true;
            this._scrollPanel.Controls.Add(this._fields);
            this._scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scrollPanel.Location = new System.Drawing.Point(15, 15);
            this._scrollPanel.Name = "_scrollPanel";
            this._scrollPanel.Size = new System.Drawing.Size(1094, 808);
            this._scrollPanel.TabIndex = 0;
            this._scrollPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackgroundMouseDown);
            // 
            // _fields
            // 
            this._fields.AutoSize = true;
            this._fields.ColumnCount = 3;
            this._fields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this._fields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._fields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 310F));
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
            this._fields.Dock = System.Windows.Forms.DockStyle.Top;
            this._fields.Location = new System.Drawing.Point(0, 0);
            this._fields.Name = "_fields";
            this._fields.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this._fields.RowCount = 14;
            this._fields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fields.Size = new System.Drawing.Size(1077, 876);
            this._fields.TabIndex = 0;
            this._fields.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackgroundMouseDown);
            // 
            // _lblName
            // 
            this._lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(3, 11);
            this._lblName.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(76, 21);
            this._lblName.TabIndex = 0;
            this._lblName.Text = "ローン名称";
            // 
            // _txtName
            // 
            this._txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtName.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._txtName.Location = new System.Drawing.Point(203, 6);
            this._txtName.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._txtName.MaxLength = 100;
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(549, 32);
            this._txtName.TabIndex = 0;
            // 
            // _lblNameNote
            // 
            this._lblNameNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblNameNote.AutoSize = true;
            this._lblNameNote.Location = new System.Drawing.Point(758, 11);
            this._lblNameNote.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblNameNote.Name = "_lblNameNote";
            this._lblNameNote.Size = new System.Drawing.Size(42, 21);
            this._lblNameNote.TabIndex = 1;
            this._lblNameNote.Text = "必須";
            // 
            // _lblPrincipal
            // 
            this._lblPrincipal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblPrincipal.AutoSize = true;
            this._lblPrincipal.Location = new System.Drawing.Point(3, 55);
            this._lblPrincipal.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblPrincipal.Name = "_lblPrincipal";
            this._lblPrincipal.Size = new System.Drawing.Size(58, 21);
            this._lblPrincipal.TabIndex = 2;
            this._lblPrincipal.Text = "借入額";
            // 
            // _txtPrincipal
            // 
            this._txtPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this._txtPrincipal.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._txtPrincipal.Location = new System.Drawing.Point(203, 50);
            this._txtPrincipal.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._txtPrincipal.MaxLength = 20;
            this._txtPrincipal.Name = "_txtPrincipal";
            this._txtPrincipal.Size = new System.Drawing.Size(280, 32);
            this._txtPrincipal.TabIndex = 1;
            this._txtPrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtPrincipal.Enter += new System.EventHandler(this.PrincipalEnter);
            this._txtPrincipal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrincipalKeyPress);
            this._txtPrincipal.Leave += new System.EventHandler(this.PrincipalLeave);
            // 
            // _lblPrincipalNote
            // 
            this._lblPrincipalNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblPrincipalNote.AutoSize = true;
            this._lblPrincipalNote.Location = new System.Drawing.Point(758, 55);
            this._lblPrincipalNote.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblPrincipalNote.Name = "_lblPrincipalNote";
            this._lblPrincipalNote.Size = new System.Drawing.Size(26, 21);
            this._lblPrincipalNote.TabIndex = 3;
            this._lblPrincipalNote.Text = "円";
            // 
            // _lblRate
            // 
            this._lblRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblRate.AutoSize = true;
            this._lblRate.Location = new System.Drawing.Point(3, 99);
            this._lblRate.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblRate.Name = "_lblRate";
            this._lblRate.Size = new System.Drawing.Size(74, 21);
            this._lblRate.TabIndex = 4;
            this._lblRate.Text = "年間金利";
            // 
            // _txtRate
            // 
            this._txtRate.Dock = System.Windows.Forms.DockStyle.Left;
            this._txtRate.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._txtRate.Location = new System.Drawing.Point(203, 94);
            this._txtRate.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._txtRate.MaxLength = 20;
            this._txtRate.Name = "_txtRate";
            this._txtRate.Size = new System.Drawing.Size(180, 32);
            this._txtRate.TabIndex = 2;
            this._txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtRate.TextChanged += new System.EventHandler(this.PreviewValueChanged);
            // 
            // _lblRateNote
            // 
            this._lblRateNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblRateNote.AutoSize = true;
            this._lblRateNote.Location = new System.Drawing.Point(758, 99);
            this._lblRateNote.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblRateNote.Name = "_lblRateNote";
            this._lblRateNote.Size = new System.Drawing.Size(185, 21);
            this._lblRateNote.TabIndex = 5;
            this._lblRateNote.Text = "%（小数点以下2桁まで）";
            // 
            // _lblRepaymentType
            // 
            this._lblRepaymentType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblRepaymentType.AutoSize = true;
            this._lblRepaymentType.Location = new System.Drawing.Point(3, 144);
            this._lblRepaymentType.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblRepaymentType.Name = "_lblRepaymentType";
            this._lblRepaymentType.Size = new System.Drawing.Size(74, 21);
            this._lblRepaymentType.TabIndex = 6;
            this._lblRepaymentType.Text = "返済方式";
            // 
            // _cmbRepaymentType
            // 
            this._cmbRepaymentType.Dock = System.Windows.Forms.DockStyle.Left;
            this._cmbRepaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbRepaymentType.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._cmbRepaymentType.Location = new System.Drawing.Point(203, 138);
            this._cmbRepaymentType.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._cmbRepaymentType.Name = "_cmbRepaymentType";
            this._cmbRepaymentType.Size = new System.Drawing.Size(549, 33);
            this._cmbRepaymentType.TabIndex = 3;
            this._cmbRepaymentType.SelectedIndexChanged += new System.EventHandler(this.RepaymentTypeChanged);
            // 
            // _lblRepaymentTypeNote
            // 
            this._lblRepaymentTypeNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblRepaymentTypeNote.AutoSize = true;
            this._lblRepaymentTypeNote.Location = new System.Drawing.Point(758, 144);
            this._lblRepaymentTypeNote.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblRepaymentTypeNote.Name = "_lblRepaymentTypeNote";
            this._lblRepaymentTypeNote.Size = new System.Drawing.Size(0, 21);
            this._lblRepaymentTypeNote.TabIndex = 7;
            // 
            // _lblInterestMethod
            // 
            this._lblInterestMethod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblInterestMethod.AutoSize = true;
            this._lblInterestMethod.Location = new System.Drawing.Point(3, 189);
            this._lblInterestMethod.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblInterestMethod.Name = "_lblInterestMethod";
            this._lblInterestMethod.Size = new System.Drawing.Size(119, 21);
            this._lblInterestMethod.TabIndex = 8;
            this._lblInterestMethod.Text = "利息の計算方法";
            // 
            // _cmbInterestMethod
            // 
            this._cmbInterestMethod.Dock = System.Windows.Forms.DockStyle.Left;
            this._cmbInterestMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbInterestMethod.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._cmbInterestMethod.Location = new System.Drawing.Point(203, 183);
            this._cmbInterestMethod.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._cmbInterestMethod.Name = "_cmbInterestMethod";
            this._cmbInterestMethod.Size = new System.Drawing.Size(310, 33);
            this._cmbInterestMethod.TabIndex = 4;
            this._cmbInterestMethod.SelectedIndexChanged += new System.EventHandler(this.PreviewValueChanged);
            // 
            // _lblInterestMethodNote
            // 
            this._lblInterestMethodNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblInterestMethodNote.AutoSize = true;
            this._lblInterestMethodNote.Location = new System.Drawing.Point(758, 189);
            this._lblInterestMethodNote.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblInterestMethodNote.Name = "_lblInterestMethodNote";
            this._lblInterestMethodNote.Size = new System.Drawing.Size(0, 21);
            this._lblInterestMethodNote.TabIndex = 9;
            // 
            // _lblBorrowDate
            // 
            this._lblBorrowDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblBorrowDate.AutoSize = true;
            this._lblBorrowDate.Location = new System.Drawing.Point(3, 233);
            this._lblBorrowDate.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblBorrowDate.Name = "_lblBorrowDate";
            this._lblBorrowDate.Size = new System.Drawing.Size(58, 21);
            this._lblBorrowDate.TabIndex = 10;
            this._lblBorrowDate.Text = "借入日";
            // 
            // _dtpBorrowDate
            // 
            this._dtpBorrowDate.CustomFormat = "yyyy年MM月dd日";
            this._dtpBorrowDate.Dock = System.Windows.Forms.DockStyle.Left;
            this._dtpBorrowDate.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._dtpBorrowDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpBorrowDate.Location = new System.Drawing.Point(203, 228);
            this._dtpBorrowDate.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._dtpBorrowDate.Name = "_dtpBorrowDate";
            this._dtpBorrowDate.Size = new System.Drawing.Size(230, 32);
            this._dtpBorrowDate.TabIndex = 5;
            this._dtpBorrowDate.ValueChanged += new System.EventHandler(this.PreviewValueChanged);
            // 
            // _lblBorrowDateNote
            // 
            this._lblBorrowDateNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblBorrowDateNote.AutoSize = true;
            this._lblBorrowDateNote.Location = new System.Drawing.Point(758, 233);
            this._lblBorrowDateNote.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblBorrowDateNote.Name = "_lblBorrowDateNote";
            this._lblBorrowDateNote.Size = new System.Drawing.Size(0, 21);
            this._lblBorrowDateNote.TabIndex = 11;
            // 
            // _lblFirstRepaymentDate
            // 
            this._lblFirstRepaymentDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblFirstRepaymentDate.AutoSize = true;
            this._lblFirstRepaymentDate.Location = new System.Drawing.Point(3, 277);
            this._lblFirstRepaymentDate.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblFirstRepaymentDate.Name = "_lblFirstRepaymentDate";
            this._lblFirstRepaymentDate.Size = new System.Drawing.Size(90, 21);
            this._lblFirstRepaymentDate.TabIndex = 12;
            this._lblFirstRepaymentDate.Text = "初回返済日";
            // 
            // _dtpFirstRepaymentDate
            // 
            this._dtpFirstRepaymentDate.CustomFormat = "yyyy年MM月dd日";
            this._dtpFirstRepaymentDate.Dock = System.Windows.Forms.DockStyle.Left;
            this._dtpFirstRepaymentDate.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._dtpFirstRepaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFirstRepaymentDate.Location = new System.Drawing.Point(203, 272);
            this._dtpFirstRepaymentDate.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._dtpFirstRepaymentDate.Name = "_dtpFirstRepaymentDate";
            this._dtpFirstRepaymentDate.Size = new System.Drawing.Size(230, 32);
            this._dtpFirstRepaymentDate.TabIndex = 6;
            this._dtpFirstRepaymentDate.ValueChanged += new System.EventHandler(this.PreviewValueChanged);
            // 
            // _lblFirstRepaymentDateNote
            // 
            this._lblFirstRepaymentDateNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblFirstRepaymentDateNote.AutoSize = true;
            this._lblFirstRepaymentDateNote.Location = new System.Drawing.Point(758, 277);
            this._lblFirstRepaymentDateNote.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblFirstRepaymentDateNote.Name = "_lblFirstRepaymentDateNote";
            this._lblFirstRepaymentDateNote.Size = new System.Drawing.Size(0, 21);
            this._lblFirstRepaymentDateNote.TabIndex = 13;
            // 
            // _lblRepaymentSettingMode
            // 
            this._lblRepaymentSettingMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblRepaymentSettingMode.AutoSize = true;
            this._lblRepaymentSettingMode.Location = new System.Drawing.Point(3, 322);
            this._lblRepaymentSettingMode.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblRepaymentSettingMode.Name = "_lblRepaymentSettingMode";
            this._lblRepaymentSettingMode.Size = new System.Drawing.Size(74, 21);
            this._lblRepaymentSettingMode.TabIndex = 14;
            this._lblRepaymentSettingMode.Text = "返済条件";
            // 
            // _cmbRepaymentSettingMode
            // 
            this._cmbRepaymentSettingMode.Dock = System.Windows.Forms.DockStyle.Left;
            this._cmbRepaymentSettingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbRepaymentSettingMode.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._cmbRepaymentSettingMode.Location = new System.Drawing.Point(203, 316);
            this._cmbRepaymentSettingMode.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._cmbRepaymentSettingMode.Name = "_cmbRepaymentSettingMode";
            this._cmbRepaymentSettingMode.Size = new System.Drawing.Size(310, 33);
            this._cmbRepaymentSettingMode.TabIndex = 7;
            this._cmbRepaymentSettingMode.SelectedIndexChanged += new System.EventHandler(this.RepaymentSettingModeChanged);
            // 
            // _lblRepaymentSettingModeNote
            // 
            this._lblRepaymentSettingModeNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblRepaymentSettingModeNote.AutoSize = true;
            this._lblRepaymentSettingModeNote.Location = new System.Drawing.Point(758, 322);
            this._lblRepaymentSettingModeNote.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblRepaymentSettingModeNote.Name = "_lblRepaymentSettingModeNote";
            this._lblRepaymentSettingModeNote.Size = new System.Drawing.Size(0, 21);
            this._lblRepaymentSettingModeNote.TabIndex = 15;
            // 
            // _lblPeriod
            // 
            this._lblPeriod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblPeriod.AutoSize = true;
            this._lblPeriod.Location = new System.Drawing.Point(3, 366);
            this._lblPeriod.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblPeriod.Name = "_lblPeriod";
            this._lblPeriod.Size = new System.Drawing.Size(74, 21);
            this._lblPeriod.TabIndex = 16;
            this._lblPeriod.Text = "返済期間";
            // 
            // _pnlPeriod
            // 
            this._pnlPeriod.AutoSize = true;
            this._pnlPeriod.Controls.Add(this._nudYears);
            this._pnlPeriod.Controls.Add(this._lblYearsUnit);
            this._pnlPeriod.Controls.Add(this._nudMonths);
            this._pnlPeriod.Controls.Add(this._lblMonthsUnit);
            this._pnlPeriod.Location = new System.Drawing.Point(200, 355);
            this._pnlPeriod.Margin = new System.Windows.Forms.Padding(0);
            this._pnlPeriod.Name = "_pnlPeriod";
            this._pnlPeriod.Size = new System.Drawing.Size(277, 44);
            this._pnlPeriod.TabIndex = 8;
            this._pnlPeriod.WrapContents = false;
            // 
            // _nudYears
            // 
            this._nudYears.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._nudYears.Location = new System.Drawing.Point(3, 6);
            this._nudYears.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._nudYears.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this._nudYears.Name = "_nudYears";
            this._nudYears.Size = new System.Drawing.Size(90, 32);
            this._nudYears.TabIndex = 0;
            this._nudYears.ValueChanged += new System.EventHandler(this.PeriodYearsValueChanged);
            // 
            // _lblYearsUnit
            // 
            this._lblYearsUnit.AutoSize = true;
            this._lblYearsUnit.Location = new System.Drawing.Point(100, 10);
            this._lblYearsUnit.Margin = new System.Windows.Forms.Padding(4, 10, 12, 10);
            this._lblYearsUnit.Name = "_lblYearsUnit";
            this._lblYearsUnit.Size = new System.Drawing.Size(26, 21);
            this._lblYearsUnit.TabIndex = 1;
            this._lblYearsUnit.Text = "年";
            // 
            // _nudMonths
            // 
            this._nudMonths.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._nudMonths.Location = new System.Drawing.Point(141, 6);
            this._nudMonths.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._nudMonths.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this._nudMonths.Name = "_nudMonths";
            this._nudMonths.Size = new System.Drawing.Size(90, 32);
            this._nudMonths.TabIndex = 1;
            this._nudMonths.ValueChanged += new System.EventHandler(this.PeriodMonthsValueChanged);
            // 
            // _lblMonthsUnit
            // 
            this._lblMonthsUnit.AutoSize = true;
            this._lblMonthsUnit.Location = new System.Drawing.Point(238, 10);
            this._lblMonthsUnit.Margin = new System.Windows.Forms.Padding(4, 10, 0, 10);
            this._lblMonthsUnit.Name = "_lblMonthsUnit";
            this._lblMonthsUnit.Size = new System.Drawing.Size(39, 21);
            this._lblMonthsUnit.TabIndex = 2;
            this._lblMonthsUnit.Text = "か月";
            // 
            // _lblPeriodNote
            // 
            this._lblPeriodNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblPeriodNote.AutoSize = true;
            this._lblPeriodNote.Location = new System.Drawing.Point(758, 366);
            this._lblPeriodNote.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblPeriodNote.Name = "_lblPeriodNote";
            this._lblPeriodNote.Size = new System.Drawing.Size(91, 21);
            this._lblPeriodNote.TabIndex = 17;
            this._lblPeriodNote.Text = "1～600か月";
            // 
            // _lblDesiredMonthlyAmount
            // 
            this._lblDesiredMonthlyAmount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblDesiredMonthlyAmount.AutoSize = true;
            this._lblDesiredMonthlyAmount.Location = new System.Drawing.Point(3, 410);
            this._lblDesiredMonthlyAmount.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblDesiredMonthlyAmount.Name = "_lblDesiredMonthlyAmount";
            this._lblDesiredMonthlyAmount.Size = new System.Drawing.Size(129, 21);
            this._lblDesiredMonthlyAmount.TabIndex = 18;
            this._lblDesiredMonthlyAmount.Text = "毎月のお支払い額";
            // 
            // _txtDesiredMonthlyPayment
            // 
            this._txtDesiredMonthlyPayment.Dock = System.Windows.Forms.DockStyle.Left;
            this._txtDesiredMonthlyPayment.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._txtDesiredMonthlyPayment.Location = new System.Drawing.Point(203, 405);
            this._txtDesiredMonthlyPayment.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._txtDesiredMonthlyPayment.MaxLength = 20;
            this._txtDesiredMonthlyPayment.Name = "_txtDesiredMonthlyPayment";
            this._txtDesiredMonthlyPayment.Size = new System.Drawing.Size(280, 32);
            this._txtDesiredMonthlyPayment.TabIndex = 9;
            this._txtDesiredMonthlyPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtDesiredMonthlyPayment.Enter += new System.EventHandler(this.DesiredMonthlyPaymentEnter);
            this._txtDesiredMonthlyPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmountKeyPress);
            this._txtDesiredMonthlyPayment.Leave += new System.EventHandler(this.DesiredMonthlyPaymentLeave);
            // 
            // _lblMonthlyPaymentNote
            // 
            this._lblMonthlyPaymentNote.AutoEllipsis = true;
            this._lblMonthlyPaymentNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblMonthlyPaymentNote.Location = new System.Drawing.Point(758, 405);
            this._lblMonthlyPaymentNote.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._lblMonthlyPaymentNote.Name = "_lblMonthlyPaymentNote";
            this._lblMonthlyPaymentNote.Size = new System.Drawing.Size(304, 32);
            this._lblMonthlyPaymentNote.TabIndex = 19;
            this._lblMonthlyPaymentNote.Text = "円（元金＋利息）";
            this._lblMonthlyPaymentNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblPaymentDay
            // 
            this._lblPaymentDay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblPaymentDay.AutoSize = true;
            this._lblPaymentDay.Location = new System.Drawing.Point(3, 454);
            this._lblPaymentDay.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblPaymentDay.Name = "_lblPaymentDay";
            this._lblPaymentDay.Size = new System.Drawing.Size(103, 21);
            this._lblPaymentDay.TabIndex = 20;
            this._lblPaymentDay.Text = "毎月の返済日";
            // 
            // _nudPaymentDay
            // 
            this._nudPaymentDay.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._nudPaymentDay.Location = new System.Drawing.Point(203, 449);
            this._nudPaymentDay.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._nudPaymentDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this._nudPaymentDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudPaymentDay.Name = "_nudPaymentDay";
            this._nudPaymentDay.Size = new System.Drawing.Size(110, 32);
            this._nudPaymentDay.TabIndex = 10;
            this._nudPaymentDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudPaymentDay.ValueChanged += new System.EventHandler(this.PreviewValueChanged);
            // 
            // _lblPaymentDayNote
            // 
            this._lblPaymentDayNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblPaymentDayNote.AutoSize = true;
            this._lblPaymentDayNote.Location = new System.Drawing.Point(758, 454);
            this._lblPaymentDayNote.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblPaymentDayNote.Name = "_lblPaymentDayNote";
            this._lblPaymentDayNote.Size = new System.Drawing.Size(152, 21);
            this._lblPaymentDayNote.TabIndex = 21;
            this._lblPaymentDayNote.Text = "日（超過時は月末）";
            // 
            // _lblUseBonus
            // 
            this._lblUseBonus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblUseBonus.AutoSize = true;
            this._lblUseBonus.Location = new System.Drawing.Point(3, 497);
            this._lblUseBonus.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblUseBonus.Name = "_lblUseBonus";
            this._lblUseBonus.Size = new System.Drawing.Size(86, 21);
            this._lblUseBonus.TabIndex = 22;
            this._lblUseBonus.Text = "ボーナス払い";
            // 
            // _bonusFrequencyPanel
            // 
            this._bonusFrequencyPanel.AutoSize = true;
            this._bonusFrequencyPanel.Controls.Add(this._rdoBonusNone);
            this._bonusFrequencyPanel.Controls.Add(this._rdoBonusOnce);
            this._bonusFrequencyPanel.Controls.Add(this._rdoBonusTwice);
            this._bonusFrequencyPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this._bonusFrequencyPanel.Location = new System.Drawing.Point(200, 487);
            this._bonusFrequencyPanel.Margin = new System.Windows.Forms.Padding(0);
            this._bonusFrequencyPanel.Name = "_bonusFrequencyPanel";
            this._bonusFrequencyPanel.Size = new System.Drawing.Size(227, 41);
            this._bonusFrequencyPanel.TabIndex = 11;
            this._bonusFrequencyPanel.WrapContents = false;
            // 
            // _rdoBonusNone
            // 
            this._rdoBonusNone.AutoSize = true;
            this._rdoBonusNone.Checked = true;
            this._rdoBonusNone.Location = new System.Drawing.Point(3, 8);
            this._rdoBonusNone.Margin = new System.Windows.Forms.Padding(3, 8, 12, 8);
            this._rdoBonusNone.Name = "_rdoBonusNone";
            this._rdoBonusNone.Size = new System.Drawing.Size(53, 25);
            this._rdoBonusNone.TabIndex = 0;
            this._rdoBonusNone.TabStop = true;
            this._rdoBonusNone.Text = "なし";
            this._rdoBonusNone.UseVisualStyleBackColor = true;
            this._rdoBonusNone.CheckedChanged += new System.EventHandler(this.BonusPaymentFrequencyChanged);
            // 
            // _rdoBonusOnce
            // 
            this._rdoBonusOnce.AutoSize = true;
            this._rdoBonusOnce.Location = new System.Drawing.Point(71, 8);
            this._rdoBonusOnce.Margin = new System.Windows.Forms.Padding(3, 8, 12, 8);
            this._rdoBonusOnce.Name = "_rdoBonusOnce";
            this._rdoBonusOnce.Size = new System.Drawing.Size(69, 25);
            this._rdoBonusOnce.TabIndex = 1;
            this._rdoBonusOnce.Text = "年1回";
            this._rdoBonusOnce.UseVisualStyleBackColor = true;
            this._rdoBonusOnce.CheckedChanged += new System.EventHandler(this.BonusPaymentFrequencyChanged);
            // 
            // _rdoBonusTwice
            // 
            this._rdoBonusTwice.AutoSize = true;
            this._rdoBonusTwice.Location = new System.Drawing.Point(155, 8);
            this._rdoBonusTwice.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this._rdoBonusTwice.Name = "_rdoBonusTwice";
            this._rdoBonusTwice.Size = new System.Drawing.Size(69, 25);
            this._rdoBonusTwice.TabIndex = 2;
            this._rdoBonusTwice.Text = "年2回";
            this._rdoBonusTwice.UseVisualStyleBackColor = true;
            this._rdoBonusTwice.CheckedChanged += new System.EventHandler(this.BonusPaymentFrequencyChanged);
            // 
            // _lblUseBonusNote
            // 
            this._lblUseBonusNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblUseBonusNote.AutoSize = true;
            this._lblUseBonusNote.Location = new System.Drawing.Point(758, 497);
            this._lblUseBonusNote.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblUseBonusNote.Name = "_lblUseBonusNote";
            this._lblUseBonusNote.Size = new System.Drawing.Size(196, 21);
            this._lblUseBonusNote.TabIndex = 23;
            this._lblUseBonusNote.Text = "一括返済では使用できません";
            // 
            // _grpBonus
            // 
            this._fields.SetColumnSpan(this._grpBonus, 3);
            this._grpBonus.Controls.Add(this._bonusTable);
            this._grpBonus.Dock = System.Windows.Forms.DockStyle.Top;
            this._grpBonus.Location = new System.Drawing.Point(3, 531);
            this._grpBonus.MinimumSize = new System.Drawing.Size(0, 220);
            this._grpBonus.Name = "_grpBonus";
            this._grpBonus.Padding = new System.Windows.Forms.Padding(10);
            this._grpBonus.Size = new System.Drawing.Size(1059, 220);
            this._grpBonus.TabIndex = 12;
            this._grpBonus.TabStop = false;
            this._grpBonus.Text = "ボーナス払い設定";
            // 
            // _bonusTable
            // 
            this._bonusTable.ColumnCount = 2;
            this._bonusTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 310F));
            this._bonusTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._bonusTable.Controls.Add(this._lblBonusPrincipal, 0, 0);
            this._bonusTable.Controls.Add(this._txtBonusPrincipal, 1, 0);
            this._bonusTable.Controls.Add(this._lblBonusMonths, 0, 1);
            this._bonusTable.Controls.Add(this._bonusMonthsPanel, 1, 1);
            this._bonusTable.Controls.Add(this._lblBonusNote, 0, 2);
            this._bonusTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this._bonusTable.Location = new System.Drawing.Point(10, 32);
            this._bonusTable.Name = "_bonusTable";
            this._bonusTable.RowCount = 3;
            this._bonusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this._bonusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this._bonusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._bonusTable.Size = new System.Drawing.Size(1039, 178);
            this._bonusTable.TabIndex = 0;
            // 
            // _lblBonusPrincipal
            // 
            this._lblBonusPrincipal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblBonusPrincipal.AutoSize = true;
            this._lblBonusPrincipal.Location = new System.Drawing.Point(3, 15);
            this._lblBonusPrincipal.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this._lblBonusPrincipal.Name = "_lblBonusPrincipal";
            this._lblBonusPrincipal.Size = new System.Drawing.Size(244, 21);
            this._lblBonusPrincipal.TabIndex = 0;
            this._lblBonusPrincipal.Text = "ボーナス払い対象元金（1回あたり）";
            // 
            // _txtBonusPrincipal
            // 
            this._txtBonusPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this._txtBonusPrincipal.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._txtBonusPrincipal.Location = new System.Drawing.Point(313, 8);
            this._txtBonusPrincipal.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this._txtBonusPrincipal.MaxLength = 20;
            this._txtBonusPrincipal.Name = "_txtBonusPrincipal";
            this._txtBonusPrincipal.Size = new System.Drawing.Size(280, 32);
            this._txtBonusPrincipal.TabIndex = 0;
            this._txtBonusPrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtBonusPrincipal.Enter += new System.EventHandler(this.BonusPrincipalEnter);
            this._txtBonusPrincipal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmountKeyPress);
            this._txtBonusPrincipal.Leave += new System.EventHandler(this.BonusPrincipalLeave);
            // 
            // _lblBonusMonths
            // 
            this._lblBonusMonths.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblBonusMonths.AutoSize = true;
            this._lblBonusMonths.Location = new System.Drawing.Point(3, 67);
            this._lblBonusMonths.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this._lblBonusMonths.Name = "_lblBonusMonths";
            this._lblBonusMonths.Size = new System.Drawing.Size(102, 21);
            this._lblBonusMonths.TabIndex = 1;
            this._lblBonusMonths.Text = "ボーナス払い月";
            // 
            // _bonusMonthsPanel
            // 
            this._bonusMonthsPanel.AutoSize = true;
            this._bonusMonthsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._bonusMonthsPanel.Controls.Add(this._cmbBonusMonth1);
            this._bonusMonthsPanel.Controls.Add(this._lblBonusMonthsSeparator);
            this._bonusMonthsPanel.Controls.Add(this._cmbBonusMonth2);
            this._bonusMonthsPanel.Controls.Add(this._lblBonusMonthsSuffix);
            this._bonusMonthsPanel.Location = new System.Drawing.Point(310, 52);
            this._bonusMonthsPanel.Margin = new System.Windows.Forms.Padding(0);
            this._bonusMonthsPanel.MinimumSize = new System.Drawing.Size(0, 52);
            this._bonusMonthsPanel.Name = "_bonusMonthsPanel";
            this._bonusMonthsPanel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 12);
            this._bonusMonthsPanel.Size = new System.Drawing.Size(264, 52);
            this._bonusMonthsPanel.TabIndex = 1;
            // 
            // _cmbBonusMonth1
            // 
            this._cmbBonusMonth1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbBonusMonth1.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._cmbBonusMonth1.Location = new System.Drawing.Point(3, 8);
            this._cmbBonusMonth1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
            this._cmbBonusMonth1.Name = "_cmbBonusMonth1";
            this._cmbBonusMonth1.Size = new System.Drawing.Size(85, 33);
            this._cmbBonusMonth1.TabIndex = 0;
            this._cmbBonusMonth1.SelectedIndexChanged += new System.EventHandler(this.PreviewValueChanged);
            // 
            // _lblBonusMonthsSeparator
            // 
            this._lblBonusMonthsSeparator.AutoSize = true;
            this._lblBonusMonthsSeparator.Location = new System.Drawing.Point(96, 13);
            this._lblBonusMonthsSeparator.Margin = new System.Windows.Forms.Padding(5, 11, 5, 8);
            this._lblBonusMonthsSeparator.Name = "_lblBonusMonthsSeparator";
            this._lblBonusMonthsSeparator.Size = new System.Drawing.Size(41, 21);
            this._lblBonusMonthsSeparator.TabIndex = 1;
            this._lblBonusMonthsSeparator.Text = "月 と";
            // 
            // _cmbBonusMonth2
            // 
            this._cmbBonusMonth2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbBonusMonth2.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._cmbBonusMonth2.Location = new System.Drawing.Point(145, 8);
            this._cmbBonusMonth2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
            this._cmbBonusMonth2.Name = "_cmbBonusMonth2";
            this._cmbBonusMonth2.Size = new System.Drawing.Size(85, 33);
            this._cmbBonusMonth2.TabIndex = 1;
            this._cmbBonusMonth2.SelectedIndexChanged += new System.EventHandler(this.PreviewValueChanged);
            // 
            // _lblBonusMonthsSuffix
            // 
            this._lblBonusMonthsSuffix.AutoSize = true;
            this._lblBonusMonthsSuffix.Location = new System.Drawing.Point(238, 13);
            this._lblBonusMonthsSuffix.Margin = new System.Windows.Forms.Padding(5, 11, 0, 8);
            this._lblBonusMonthsSuffix.Name = "_lblBonusMonthsSuffix";
            this._lblBonusMonthsSuffix.Size = new System.Drawing.Size(26, 21);
            this._lblBonusMonthsSuffix.TabIndex = 2;
            this._lblBonusMonthsSuffix.Text = "月";
            // 
            // _lblBonusNote
            // 
            this._lblBonusNote.AutoSize = true;
            this._bonusTable.SetColumnSpan(this._lblBonusNote, 2);
            this._lblBonusNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblBonusNote.Location = new System.Drawing.Point(3, 112);
            this._lblBonusNote.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this._lblBonusNote.MinimumSize = new System.Drawing.Size(0, 56);
            this._lblBonusNote.Name = "_lblBonusNote";
            this._lblBonusNote.Size = new System.Drawing.Size(1033, 58);
            this._lblBonusNote.TabIndex = 2;
            this._lblBonusNote.Text = "指定した月ごとに、入力した元金額を通常返済へ上乗せします。金額を回数で分割することはありません。残高を超える場合は残高まで支払います。";
            // 
            // _lblMemo
            // 
            this._lblMemo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblMemo.AutoSize = true;
            this._lblMemo.Location = new System.Drawing.Point(3, 804);
            this._lblMemo.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblMemo.Name = "_lblMemo";
            this._lblMemo.Size = new System.Drawing.Size(33, 21);
            this._lblMemo.TabIndex = 24;
            this._lblMemo.Text = "メモ";
            // 
            // _txtMemo
            // 
            this._txtMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtMemo.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this._txtMemo.Location = new System.Drawing.Point(203, 760);
            this._txtMemo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._txtMemo.MaxLength = 2000;
            this._txtMemo.Multiline = true;
            this._txtMemo.Name = "_txtMemo";
            this._txtMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtMemo.Size = new System.Drawing.Size(549, 110);
            this._txtMemo.TabIndex = 13;
            // 
            // _lblMemoNote
            // 
            this._lblMemoNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblMemoNote.AutoSize = true;
            this._lblMemoNote.Location = new System.Drawing.Point(758, 804);
            this._lblMemoNote.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this._lblMemoNote.Name = "_lblMemoNote";
            this._lblMemoNote.Size = new System.Drawing.Size(0, 21);
            this._lblMemoNote.TabIndex = 25;
            // 
            // _lblPreview
            // 
            this._lblPreview.AutoSize = true;
            this._lblPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblPreview.Location = new System.Drawing.Point(15, 826);
            this._lblPreview.MinimumSize = new System.Drawing.Size(2, 118);
            this._lblPreview.Name = "_lblPreview";
            this._lblPreview.Padding = new System.Windows.Forms.Padding(10);
            this._lblPreview.Size = new System.Drawing.Size(1094, 118);
            this._lblPreview.TabIndex = 1;
            this._lblPreview.Text = "入力内容から返済額を計算します。";
            // 
            // _buttons
            // 
            this._buttons.AutoSize = true;
            this._buttons.Controls.Add(this._btnCancel);
            this._buttons.Controls.Add(this._btnSave);
            this._buttons.Controls.Add(this._btnCalculate);
            this._buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this._buttons.Location = new System.Drawing.Point(15, 947);
            this._buttons.Name = "_buttons";
            this._buttons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this._buttons.Size = new System.Drawing.Size(1094, 58);
            this._buttons.TabIndex = 2;
            // 
            // _btnCancel
            // 
            this._btnCancel.AutoSize = true;
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(971, 13);
            this._btnCancel.MinimumSize = new System.Drawing.Size(120, 42);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(120, 42);
            this._btnCancel.TabIndex = 2;
            this._btnCancel.Text = "キャンセル";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnSave
            // 
            this._btnSave.AutoSize = true;
            this._btnSave.Location = new System.Drawing.Point(845, 13);
            this._btnSave.MinimumSize = new System.Drawing.Size(120, 42);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(120, 42);
            this._btnSave.TabIndex = 1;
            this._btnSave.Text = "保存";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.SaveClicked);
            // 
            // _btnCalculate
            // 
            this._btnCalculate.AutoSize = true;
            this._btnCalculate.Location = new System.Drawing.Point(719, 13);
            this._btnCalculate.MinimumSize = new System.Drawing.Size(120, 42);
            this._btnCalculate.Name = "_btnCalculate";
            this._btnCalculate.Size = new System.Drawing.Size(120, 42);
            this._btnCalculate.TabIndex = 0;
            this._btnCalculate.Text = "再計算";
            this._btnCalculate.UseVisualStyleBackColor = true;
            this._btnCalculate.Click += new System.EventHandler(this.CalculateClicked);
            // 
            // LoanEditForm
            // 
            this.AcceptButton = this._btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(1124, 1020);
            this.Controls.Add(this._root);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.MinimumSize = new System.Drawing.Size(980, 740);
            this.Name = "LoanEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ローンを登録";
            this._root.ResumeLayout(false);
            this._root.PerformLayout();
            this._scrollPanel.ResumeLayout(false);
            this._scrollPanel.PerformLayout();
            this._fields.ResumeLayout(false);
            this._fields.PerformLayout();
            this._pnlPeriod.ResumeLayout(false);
            this._pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudMonths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudPaymentDay)).EndInit();
            this._bonusFrequencyPanel.ResumeLayout(false);
            this._bonusFrequencyPanel.PerformLayout();
            this._grpBonus.ResumeLayout(false);
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
