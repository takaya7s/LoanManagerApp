using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LoanManagerApp.Forms
{
    partial class MainForm
    {
        private IContainer components = null;

        private TableLayoutPanel _shell;
        private ToolStrip _toolbar;
        private ToolStripButton _btnAddLoan;
        private ToolStripButton _btnEditLoan;
        private ToolStripButton _btnDeleteLoan;
        private ToolStripSeparator _toolbarSeparator1;
        private ToolStripButton _btnRefresh;
        private ToolStripSeparator _toolbarSeparator2;
        private ToolStripButton _btnOpenDataFolder;
        private SplitContainer _mainSplit;
        private DataGridView _loanGrid;
        private DataGridViewTextBoxColumn _colLoanName;
        private DataGridViewTextBoxColumn _colLoanRepaymentType;
        private DataGridViewTextBoxColumn _colLoanBonusPayment;
        private DataGridViewTextBoxColumn _colLoanPrincipalAmount;
        private DataGridViewTextBoxColumn _colLoanAnnualInterestRate;
        private DataGridViewTextBoxColumn _colLoanNextPaymentDate;
        private DataGridViewTextBoxColumn _colLoanNextPaymentAmount;
        private DataGridViewTextBoxColumn _colLoanRemainingBalance;
        private DataGridViewTextBoxColumn _colLoanRemainingPaymentCount;
        private DataGridViewTextBoxColumn _colLoanTotalPaymentAmount;
        private TabControl _tabs;
        private TabPage _scheduleTab;
        private TabPage _detailTab;
        private TableLayoutPanel _scheduleRoot;
        private TableLayoutPanel _scheduleHeader;
        private FlowLayoutPanel _scheduleTools;
        private CheckBox _chkRemainingOnly;
        private Button _btnFailure;
        private FlowLayoutPanel _simulationPanel;
        private Label _lblSimulationState;
        private Label _lblSimulationDate;
        private DateTimePicker _dtpSimulationDate;
        private Button _btnResetSimulationDate;
        private DataGridView _scheduleGrid;
        private DataGridViewTextBoxColumn _colSchedulePaymentNumber;
        private DataGridViewTextBoxColumn _colScheduleTargetMonth;
        private DataGridViewTextBoxColumn _colScheduleBaseDueDate;
        private DataGridViewTextBoxColumn _colSchedulePaymentDate;
        private DataGridViewTextBoxColumn _colScheduleRepaymentAmount;
        private DataGridViewTextBoxColumn _colSchedulePaymentAmount;
        private DataGridViewTextBoxColumn _colScheduleInterestAmount;
        private DataGridViewTextBoxColumn _colScheduleRemainingBalance;
        private DataGridViewTextBoxColumn _colScheduleStatus;
        private DataGridViewTextBoxColumn _colScheduleFailureNote;
        private Label _lblScheduleSummary;
        private TextBox _txtDetails;
        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _statusLabel;

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
            this._shell = new TableLayoutPanel();
            this._toolbar = new ToolStrip();
            this._btnAddLoan = new ToolStripButton();
            this._btnEditLoan = new ToolStripButton();
            this._btnDeleteLoan = new ToolStripButton();
            this._toolbarSeparator1 = new ToolStripSeparator();
            this._btnRefresh = new ToolStripButton();
            this._toolbarSeparator2 = new ToolStripSeparator();
            this._btnOpenDataFolder = new ToolStripButton();
            this._mainSplit = new SplitContainer();
            this._loanGrid = new DataGridView();
            this._colLoanName = new DataGridViewTextBoxColumn();
            this._colLoanRepaymentType = new DataGridViewTextBoxColumn();
            this._colLoanBonusPayment = new DataGridViewTextBoxColumn();
            this._colLoanPrincipalAmount = new DataGridViewTextBoxColumn();
            this._colLoanAnnualInterestRate = new DataGridViewTextBoxColumn();
            this._colLoanNextPaymentDate = new DataGridViewTextBoxColumn();
            this._colLoanNextPaymentAmount = new DataGridViewTextBoxColumn();
            this._colLoanRemainingBalance = new DataGridViewTextBoxColumn();
            this._colLoanRemainingPaymentCount = new DataGridViewTextBoxColumn();
            this._colLoanTotalPaymentAmount = new DataGridViewTextBoxColumn();
            this._tabs = new TabControl();
            this._scheduleTab = new TabPage();
            this._scheduleRoot = new TableLayoutPanel();
            this._scheduleHeader = new TableLayoutPanel();
            this._scheduleTools = new FlowLayoutPanel();
            this._chkRemainingOnly = new CheckBox();
            this._btnFailure = new Button();
            this._simulationPanel = new FlowLayoutPanel();
            this._lblSimulationState = new Label();
            this._lblSimulationDate = new Label();
            this._dtpSimulationDate = new DateTimePicker();
            this._btnResetSimulationDate = new Button();
            this._scheduleGrid = new DataGridView();
            this._colSchedulePaymentNumber = new DataGridViewTextBoxColumn();
            this._colScheduleTargetMonth = new DataGridViewTextBoxColumn();
            this._colScheduleBaseDueDate = new DataGridViewTextBoxColumn();
            this._colSchedulePaymentDate = new DataGridViewTextBoxColumn();
            this._colScheduleRepaymentAmount = new DataGridViewTextBoxColumn();
            this._colSchedulePaymentAmount = new DataGridViewTextBoxColumn();
            this._colScheduleInterestAmount = new DataGridViewTextBoxColumn();
            this._colScheduleRemainingBalance = new DataGridViewTextBoxColumn();
            this._colScheduleStatus = new DataGridViewTextBoxColumn();
            this._colScheduleFailureNote = new DataGridViewTextBoxColumn();
            this._lblScheduleSummary = new Label();
            this._detailTab = new TabPage();
            this._txtDetails = new TextBox();
            this._statusStrip = new StatusStrip();
            this._statusLabel = new ToolStripStatusLabel();
            this._shell.SuspendLayout();
            this._toolbar.SuspendLayout();
            ((ISupportInitialize)(this._mainSplit)).BeginInit();
            this._mainSplit.Panel1.SuspendLayout();
            this._mainSplit.Panel2.SuspendLayout();
            this._mainSplit.SuspendLayout();
            ((ISupportInitialize)(this._loanGrid)).BeginInit();
            this._tabs.SuspendLayout();
            this._scheduleTab.SuspendLayout();
            this._scheduleRoot.SuspendLayout();
            this._scheduleHeader.SuspendLayout();
            this._scheduleTools.SuspendLayout();
            this._simulationPanel.SuspendLayout();
            ((ISupportInitialize)(this._scheduleGrid)).BeginInit();
            this._detailTab.SuspendLayout();
            this._statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _shell
            // 
            this._shell.ColumnCount = 1;
            this._shell.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this._shell.Controls.Add(this._toolbar, 0, 0);
            this._shell.Controls.Add(this._mainSplit, 0, 1);
            this._shell.Controls.Add(this._statusStrip, 0, 2);
            this._shell.Dock = DockStyle.Fill;
            this._shell.Location = new Point(0, 0);
            this._shell.Margin = new Padding(0);
            this._shell.Name = "_shell";
            this._shell.RowCount = 3;
            this._shell.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._shell.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this._shell.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._shell.Size = new Size(1344, 841);
            this._shell.TabIndex = 0;
            // 
            // _toolbar
            // 
            this._toolbar.Dock = DockStyle.Fill;
            this._toolbar.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this._toolbar.GripStyle = ToolStripGripStyle.Hidden;
            this._toolbar.ImageScalingSize = new Size(24, 24);
            this._toolbar.Items.AddRange(new ToolStripItem[] {
            this._btnAddLoan,
            this._btnEditLoan,
            this._btnDeleteLoan,
            this._toolbarSeparator1,
            this._btnRefresh,
            this._toolbarSeparator2,
            this._btnOpenDataFolder});
            this._toolbar.Location = new Point(0, 0);
            this._toolbar.Name = "_toolbar";
            this._toolbar.Padding = new Padding(6);
            this._toolbar.Size = new Size(1344, 46);
            this._toolbar.TabIndex = 0;
            // 
            // _btnAddLoan
            // 
            this._btnAddLoan.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this._btnAddLoan.Name = "_btnAddLoan";
            this._btnAddLoan.Size = new Size(76, 31);
            this._btnAddLoan.Text = "新規登録";
            this._btnAddLoan.Click += new System.EventHandler(this.AddLoan);
            // 
            // _btnEditLoan
            // 
            this._btnEditLoan.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this._btnEditLoan.Name = "_btnEditLoan";
            this._btnEditLoan.Size = new Size(50, 31);
            this._btnEditLoan.Text = "編集";
            this._btnEditLoan.Click += new System.EventHandler(this.EditLoan);
            // 
            // _btnDeleteLoan
            // 
            this._btnDeleteLoan.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this._btnDeleteLoan.Name = "_btnDeleteLoan";
            this._btnDeleteLoan.Size = new Size(50, 31);
            this._btnDeleteLoan.Text = "削除";
            this._btnDeleteLoan.Click += new System.EventHandler(this.DeleteLoan);
            // 
            // _toolbarSeparator1
            // 
            this._toolbarSeparator1.Name = "_toolbarSeparator1";
            this._toolbarSeparator1.Size = new Size(6, 34);
            // 
            // _btnRefresh
            // 
            this._btnRefresh.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this._btnRefresh.Name = "_btnRefresh";
            this._btnRefresh.Size = new Size(90, 31);
            this._btnRefresh.Text = "再読み込み";
            this._btnRefresh.Click += new System.EventHandler(this.RefreshLoanList);
            // 
            // _toolbarSeparator2
            // 
            this._toolbarSeparator2.Name = "_toolbarSeparator2";
            this._toolbarSeparator2.Size = new Size(6, 34);
            // 
            // _btnOpenDataFolder
            // 
            this._btnOpenDataFolder.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this._btnOpenDataFolder.Name = "_btnOpenDataFolder";
            this._btnOpenDataFolder.Size = new Size(102, 31);
            this._btnOpenDataFolder.Text = "データ保存先";
            this._btnOpenDataFolder.Click += new System.EventHandler(this.OpenDataFolder);
            // 
            // _mainSplit
            // 
            this._mainSplit.Dock = DockStyle.Fill;
            this._mainSplit.Location = new Point(3, 49);
            this._mainSplit.Name = "_mainSplit";
            this._mainSplit.Orientation = Orientation.Horizontal;
            // 
            // _mainSplit.Panel1
            // 
            this._mainSplit.Panel1.Controls.Add(this._loanGrid);
            // 
            // _mainSplit.Panel2
            // 
            this._mainSplit.Panel2.Controls.Add(this._tabs);
            this._mainSplit.Size = new Size(1338, 758);
            this._mainSplit.SplitterDistance = 280;
            this._mainSplit.TabIndex = 1;
            // 
            // _loanGrid
            // 
            this._loanGrid.AllowUserToAddRows = false;
            this._loanGrid.AllowUserToDeleteRows = false;
            this._loanGrid.AllowUserToResizeRows = false;
            this._loanGrid.AutoGenerateColumns = false;
            this._loanGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this._loanGrid.BackgroundColor = SystemColors.Window;
            this._loanGrid.BorderStyle = BorderStyle.Fixed3D;
            this._loanGrid.ColumnHeadersHeight = 40;
            this._loanGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._loanGrid.Columns.AddRange(new DataGridViewColumn[] {
            this._colLoanName,
            this._colLoanRepaymentType,
            this._colLoanBonusPayment,
            this._colLoanPrincipalAmount,
            this._colLoanAnnualInterestRate,
            this._colLoanNextPaymentDate,
            this._colLoanNextPaymentAmount,
            this._colLoanRemainingBalance,
            this._colLoanRemainingPaymentCount,
            this._colLoanTotalPaymentAmount});
            this._loanGrid.Dock = DockStyle.Fill;
            this._loanGrid.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this._loanGrid.Location = new Point(0, 0);
            this._loanGrid.MultiSelect = false;
            this._loanGrid.Name = "_loanGrid";
            this._loanGrid.ReadOnly = true;
            this._loanGrid.RowHeadersVisible = false;
            this._loanGrid.RowTemplate.Height = 34;
            this._loanGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this._loanGrid.Size = new Size(1338, 280);
            this._loanGrid.TabIndex = 0;
            this._loanGrid.SelectionChanged += new System.EventHandler(this.LoanSelectionChanged);
            this._loanGrid.CellDoubleClick += new DataGridViewCellEventHandler(this.LoanGridCellDoubleClick);
            // 
            // _colLoanName
            // 
            this._colLoanName.DataPropertyName = "Name";
            this._colLoanName.HeaderText = "ローン名称";
            this._colLoanName.Name = "_colLoanName";
            this._colLoanName.ReadOnly = true;
            this._colLoanName.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colLoanName.Width = 190;
            // 
            // _colLoanRepaymentType
            // 
            this._colLoanRepaymentType.DataPropertyName = "RepaymentTypeName";
            this._colLoanRepaymentType.HeaderText = "返済方式";
            this._colLoanRepaymentType.Name = "_colLoanRepaymentType";
            this._colLoanRepaymentType.ReadOnly = true;
            this._colLoanRepaymentType.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colLoanRepaymentType.Width = 170;
            // 
            // _colLoanBonusPayment
            // 
            this._colLoanBonusPayment.DataPropertyName = "BonusPaymentName";
            this._colLoanBonusPayment.HeaderText = "ボーナス払い";
            this._colLoanBonusPayment.Name = "_colLoanBonusPayment";
            this._colLoanBonusPayment.ReadOnly = true;
            this._colLoanBonusPayment.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colLoanBonusPayment.Width = 105;
            // 
            // _colLoanPrincipalAmount
            // 
            this._colLoanPrincipalAmount.DataPropertyName = "PrincipalAmount";
            this._colLoanPrincipalAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this._colLoanPrincipalAmount.DefaultCellStyle.Format = "#,##0円";
            this._colLoanPrincipalAmount.HeaderText = "借入額";
            this._colLoanPrincipalAmount.Name = "_colLoanPrincipalAmount";
            this._colLoanPrincipalAmount.ReadOnly = true;
            this._colLoanPrincipalAmount.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colLoanPrincipalAmount.Width = 120;
            // 
            // _colLoanAnnualInterestRate
            // 
            this._colLoanAnnualInterestRate.DataPropertyName = "AnnualInterestRate";
            this._colLoanAnnualInterestRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this._colLoanAnnualInterestRate.DefaultCellStyle.Format = "0.##";
            this._colLoanAnnualInterestRate.HeaderText = "年利(%)";
            this._colLoanAnnualInterestRate.Name = "_colLoanAnnualInterestRate";
            this._colLoanAnnualInterestRate.ReadOnly = true;
            this._colLoanAnnualInterestRate.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colLoanAnnualInterestRate.Width = 75;
            // 
            // _colLoanNextPaymentDate
            // 
            this._colLoanNextPaymentDate.DataPropertyName = "NextPaymentDate";
            this._colLoanNextPaymentDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this._colLoanNextPaymentDate.DefaultCellStyle.Format = "yyyy/MM/dd";
            this._colLoanNextPaymentDate.HeaderText = "次回返済日";
            this._colLoanNextPaymentDate.Name = "_colLoanNextPaymentDate";
            this._colLoanNextPaymentDate.ReadOnly = true;
            this._colLoanNextPaymentDate.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colLoanNextPaymentDate.Width = 110;
            // 
            // _colLoanNextPaymentAmount
            // 
            this._colLoanNextPaymentAmount.DataPropertyName = "NextPaymentAmount";
            this._colLoanNextPaymentAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this._colLoanNextPaymentAmount.DefaultCellStyle.Format = "#,##0円";
            this._colLoanNextPaymentAmount.HeaderText = "お支払い額";
            this._colLoanNextPaymentAmount.Name = "_colLoanNextPaymentAmount";
            this._colLoanNextPaymentAmount.ReadOnly = true;
            this._colLoanNextPaymentAmount.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colLoanNextPaymentAmount.ToolTipText = "次回返済日に支払う予定額です。";
            this._colLoanNextPaymentAmount.Width = 120;
            // 
            // _colLoanRemainingBalance
            // 
            this._colLoanRemainingBalance.DataPropertyName = "RemainingBalance";
            this._colLoanRemainingBalance.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this._colLoanRemainingBalance.DefaultCellStyle.Format = "#,##0円";
            this._colLoanRemainingBalance.HeaderText = "推定残高";
            this._colLoanRemainingBalance.Name = "_colLoanRemainingBalance";
            this._colLoanRemainingBalance.ReadOnly = true;
            this._colLoanRemainingBalance.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colLoanRemainingBalance.Width = 120;
            // 
            // _colLoanRemainingPaymentCount
            // 
            this._colLoanRemainingPaymentCount.DataPropertyName = "RemainingPaymentCount";
            this._colLoanRemainingPaymentCount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this._colLoanRemainingPaymentCount.DefaultCellStyle.Format = "#,##0回";
            this._colLoanRemainingPaymentCount.HeaderText = "残回数";
            this._colLoanRemainingPaymentCount.Name = "_colLoanRemainingPaymentCount";
            this._colLoanRemainingPaymentCount.ReadOnly = true;
            this._colLoanRemainingPaymentCount.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colLoanRemainingPaymentCount.Width = 75;
            // 
            // _colLoanTotalPaymentAmount
            // 
            this._colLoanTotalPaymentAmount.DataPropertyName = "TotalPaymentAmount";
            this._colLoanTotalPaymentAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this._colLoanTotalPaymentAmount.DefaultCellStyle.Format = "#,##0円";
            this._colLoanTotalPaymentAmount.HeaderText = "総お支払い額";
            this._colLoanTotalPaymentAmount.Name = "_colLoanTotalPaymentAmount";
            this._colLoanTotalPaymentAmount.ReadOnly = true;
            this._colLoanTotalPaymentAmount.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colLoanTotalPaymentAmount.Width = 135;
            // 
            // _tabs
            // 
            this._tabs.Controls.Add(this._scheduleTab);
            this._tabs.Controls.Add(this._detailTab);
            this._tabs.Dock = DockStyle.Fill;
            this._tabs.Location = new Point(0, 0);
            this._tabs.Name = "_tabs";
            this._tabs.SelectedIndex = 0;
            this._tabs.Size = new Size(1338, 474);
            this._tabs.TabIndex = 0;
            // 
            // _scheduleTab
            // 
            this._scheduleTab.Controls.Add(this._scheduleRoot);
            this._scheduleTab.Location = new Point(4, 37);
            this._scheduleTab.Name = "_scheduleTab";
            this._scheduleTab.Padding = new Padding(3);
            this._scheduleTab.Size = new Size(1330, 433);
            this._scheduleTab.TabIndex = 0;
            this._scheduleTab.Text = "返済スケジュール";
            this._scheduleTab.UseVisualStyleBackColor = true;
            // 
            // _scheduleRoot
            // 
            this._scheduleRoot.ColumnCount = 1;
            this._scheduleRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this._scheduleRoot.Controls.Add(this._scheduleHeader, 0, 0);
            this._scheduleRoot.Controls.Add(this._scheduleGrid, 0, 1);
            this._scheduleRoot.Controls.Add(this._lblScheduleSummary, 0, 2);
            this._scheduleRoot.Dock = DockStyle.Fill;
            this._scheduleRoot.Location = new Point(3, 3);
            this._scheduleRoot.Name = "_scheduleRoot";
            this._scheduleRoot.Padding = new Padding(8);
            this._scheduleRoot.RowCount = 3;
            this._scheduleRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            this._scheduleRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this._scheduleRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._scheduleRoot.Size = new Size(1324, 427);
            this._scheduleRoot.TabIndex = 0;
            // 
            // _scheduleHeader
            // 
            this._scheduleHeader.ColumnCount = 2;
            this._scheduleHeader.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this._scheduleHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this._scheduleHeader.Controls.Add(this._scheduleTools, 0, 0);
            this._scheduleHeader.Controls.Add(this._simulationPanel, 1, 0);
            this._scheduleHeader.Dock = DockStyle.Fill;
            this._scheduleHeader.Location = new Point(8, 8);
            this._scheduleHeader.Margin = new Padding(0);
            this._scheduleHeader.Name = "_scheduleHeader";
            this._scheduleHeader.RowCount = 1;
            this._scheduleHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this._scheduleHeader.Size = new Size(1308, 56);
            this._scheduleHeader.TabIndex = 0;
            // 
            // _scheduleTools
            // 
            this._scheduleTools.AutoSize = true;
            this._scheduleTools.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this._scheduleTools.Controls.Add(this._chkRemainingOnly);
            this._scheduleTools.Controls.Add(this._btnFailure);
            this._scheduleTools.Dock = DockStyle.Fill;
            this._scheduleTools.Location = new Point(0, 0);
            this._scheduleTools.Margin = new Padding(0);
            this._scheduleTools.Name = "_scheduleTools";
            this._scheduleTools.Size = new Size(743, 56);
            this._scheduleTools.TabIndex = 0;
            this._scheduleTools.WrapContents = false;
            // 
            // _chkRemainingOnly
            // 
            this._chkRemainingOnly.AutoSize = true;
            this._chkRemainingOnly.Checked = true;
            this._chkRemainingOnly.CheckState = CheckState.Checked;
            this._chkRemainingOnly.Location = new Point(3, 11);
            this._chkRemainingOnly.Margin = new Padding(3, 11, 16, 3);
            this._chkRemainingOnly.Name = "_chkRemainingOnly";
            this._chkRemainingOnly.Size = new Size(178, 32);
            this._chkRemainingOnly.TabIndex = 0;
            this._chkRemainingOnly.Text = "残りの返済のみ表示";
            this._chkRemainingOnly.UseVisualStyleBackColor = true;
            this._chkRemainingOnly.CheckedChanged += new System.EventHandler(this.RemainingOnlyCheckedChanged);
            // 
            // _btnFailure
            // 
            this._btnFailure.AutoSize = true;
            this._btnFailure.Location = new Point(200, 4);
            this._btnFailure.Margin = new Padding(3, 4, 3, 3);
            this._btnFailure.MinimumSize = new Size(160, 42);
            this._btnFailure.Name = "_btnFailure";
            this._btnFailure.Size = new Size(160, 42);
            this._btnFailure.TabIndex = 1;
            this._btnFailure.Text = "入金失敗を登録";
            this._btnFailure.UseVisualStyleBackColor = true;
            this._btnFailure.Click += new System.EventHandler(this.TogglePaymentFailure);
            // 
            // _simulationPanel
            // 
            this._simulationPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this._simulationPanel.AutoSize = true;
            this._simulationPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this._simulationPanel.BackColor = SystemColors.Control;
            this._simulationPanel.BorderStyle = BorderStyle.FixedSingle;
            this._simulationPanel.Controls.Add(this._lblSimulationState);
            this._simulationPanel.Controls.Add(this._lblSimulationDate);
            this._simulationPanel.Controls.Add(this._dtpSimulationDate);
            this._simulationPanel.Controls.Add(this._btnResetSimulationDate);
            this._simulationPanel.Location = new Point(749, 0);
            this._simulationPanel.Margin = new Padding(6, 0, 0, 0);
            this._simulationPanel.Name = "_simulationPanel";
            this._simulationPanel.Padding = new Padding(6, 4, 6, 4);
            this._simulationPanel.Size = new Size(559, 56);
            this._simulationPanel.TabIndex = 1;
            this._simulationPanel.WrapContents = false;
            // 
            // _lblSimulationState
            // 
            this._lblSimulationState.AutoSize = true;
            this._lblSimulationState.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this._lblSimulationState.Location = new Point(9, 11);
            this._lblSimulationState.Margin = new Padding(3, 7, 10, 3);
            this._lblSimulationState.Name = "_lblSimulationState";
            this._lblSimulationState.Size = new Size(81, 28);
            this._lblSimulationState.TabIndex = 0;
            this._lblSimulationState.Text = "本日基準";
            // 
            // _lblSimulationDate
            // 
            this._lblSimulationDate.AutoSize = true;
            this._lblSimulationDate.Location = new Point(103, 11);
            this._lblSimulationDate.Margin = new Padding(3, 7, 6, 3);
            this._lblSimulationDate.Name = "_lblSimulationDate";
            this._lblSimulationDate.Size = new Size(65, 28);
            this._lblSimulationDate.TabIndex = 1;
            this._lblSimulationDate.Text = "基準日";
            // 
            // _dtpSimulationDate
            // 
            this._dtpSimulationDate.CustomFormat = "yyyy年MM月dd日";
            this._dtpSimulationDate.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this._dtpSimulationDate.Format = DateTimePickerFormat.Custom;
            this._dtpSimulationDate.Location = new Point(177, 7);
            this._dtpSimulationDate.Margin = new Padding(0, 3, 8, 3);
            this._dtpSimulationDate.Name = "_dtpSimulationDate";
            this._dtpSimulationDate.Size = new Size(190, 34);
            this._dtpSimulationDate.TabIndex = 2;
            this._dtpSimulationDate.ValueChanged += new System.EventHandler(this.SimulationDateChanged);
            // 
            // _btnResetSimulationDate
            // 
            this._btnResetSimulationDate.AutoSize = true;
            this._btnResetSimulationDate.Location = new Point(375, 5);
            this._btnResetSimulationDate.Margin = new Padding(0, 1, 0, 1);
            this._btnResetSimulationDate.MinimumSize = new Size(120, 40);
            this._btnResetSimulationDate.Name = "_btnResetSimulationDate";
            this._btnResetSimulationDate.Size = new Size(120, 40);
            this._btnResetSimulationDate.TabIndex = 3;
            this._btnResetSimulationDate.Text = "本日に戻す";
            this._btnResetSimulationDate.UseVisualStyleBackColor = true;
            this._btnResetSimulationDate.Click += new System.EventHandler(this.ResetSimulationDate);
            // 
            // _scheduleGrid
            // 
            this._scheduleGrid.AllowUserToAddRows = false;
            this._scheduleGrid.AllowUserToDeleteRows = false;
            this._scheduleGrid.AllowUserToResizeRows = false;
            this._scheduleGrid.AutoGenerateColumns = false;
            this._scheduleGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this._scheduleGrid.BackgroundColor = SystemColors.Window;
            this._scheduleGrid.BorderStyle = BorderStyle.Fixed3D;
            this._scheduleGrid.ColumnHeadersHeight = 40;
            this._scheduleGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._scheduleGrid.Columns.AddRange(new DataGridViewColumn[] {
            this._colSchedulePaymentNumber,
            this._colScheduleTargetMonth,
            this._colScheduleBaseDueDate,
            this._colSchedulePaymentDate,
            this._colScheduleRepaymentAmount,
            this._colSchedulePaymentAmount,
            this._colScheduleInterestAmount,
            this._colScheduleRemainingBalance,
            this._colScheduleStatus,
            this._colScheduleFailureNote});
            this._scheduleGrid.Dock = DockStyle.Fill;
            this._scheduleGrid.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this._scheduleGrid.Location = new Point(11, 67);
            this._scheduleGrid.MultiSelect = false;
            this._scheduleGrid.Name = "_scheduleGrid";
            this._scheduleGrid.ReadOnly = true;
            this._scheduleGrid.RowHeadersVisible = false;
            this._scheduleGrid.RowTemplate.Height = 34;
            this._scheduleGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this._scheduleGrid.Size = new Size(1302, 297);
            this._scheduleGrid.TabIndex = 1;
            this._scheduleGrid.SelectionChanged += new System.EventHandler(this.ScheduleSelectionChanged);
            // 
            // _colSchedulePaymentNumber
            // 
            this._colSchedulePaymentNumber.DataPropertyName = "PaymentNumber";
            this._colSchedulePaymentNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this._colSchedulePaymentNumber.DefaultCellStyle.Format = "0";
            this._colSchedulePaymentNumber.HeaderText = "回";
            this._colSchedulePaymentNumber.Name = "_colSchedulePaymentNumber";
            this._colSchedulePaymentNumber.ReadOnly = true;
            this._colSchedulePaymentNumber.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colSchedulePaymentNumber.Width = 55;
            // 
            // _colScheduleTargetMonth
            // 
            this._colScheduleTargetMonth.DataPropertyName = "TargetMonthText";
            this._colScheduleTargetMonth.HeaderText = "返済対象月";
            this._colScheduleTargetMonth.Name = "_colScheduleTargetMonth";
            this._colScheduleTargetMonth.ReadOnly = true;
            this._colScheduleTargetMonth.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colScheduleTargetMonth.Width = 100;
            // 
            // _colScheduleBaseDueDate
            // 
            this._colScheduleBaseDueDate.DataPropertyName = "BaseDueDateText";
            this._colScheduleBaseDueDate.HeaderText = "調整前";
            this._colScheduleBaseDueDate.Name = "_colScheduleBaseDueDate";
            this._colScheduleBaseDueDate.ReadOnly = true;
            this._colScheduleBaseDueDate.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colScheduleBaseDueDate.Width = 100;
            // 
            // _colSchedulePaymentDate
            // 
            this._colSchedulePaymentDate.DataPropertyName = "PaymentDateText";
            this._colSchedulePaymentDate.HeaderText = "返済予定日";
            this._colSchedulePaymentDate.Name = "_colSchedulePaymentDate";
            this._colSchedulePaymentDate.ReadOnly = true;
            this._colSchedulePaymentDate.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colSchedulePaymentDate.Width = 105;
            // 
            // _colScheduleRepaymentAmount
            // 
            this._colScheduleRepaymentAmount.DataPropertyName = "RepaymentAmount";
            this._colScheduleRepaymentAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this._colScheduleRepaymentAmount.DefaultCellStyle.Format = "#,##0円";
            this._colScheduleRepaymentAmount.HeaderText = "返済額（元金）";
            this._colScheduleRepaymentAmount.Name = "_colScheduleRepaymentAmount";
            this._colScheduleRepaymentAmount.ReadOnly = true;
            this._colScheduleRepaymentAmount.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colScheduleRepaymentAmount.ToolTipText = "その回に返済する元金。残高から減る金額です。";
            this._colScheduleRepaymentAmount.Width = 135;
            // 
            // _colSchedulePaymentAmount
            // 
            this._colSchedulePaymentAmount.DataPropertyName = "PaymentAmount";
            this._colSchedulePaymentAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this._colSchedulePaymentAmount.DefaultCellStyle.Format = "#,##0円";
            this._colSchedulePaymentAmount.HeaderText = "お支払い額";
            this._colSchedulePaymentAmount.Name = "_colSchedulePaymentAmount";
            this._colSchedulePaymentAmount.ReadOnly = true;
            this._colSchedulePaymentAmount.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colSchedulePaymentAmount.ToolTipText = "返済額（元金）と利息の合計。ボーナス月はボーナス分も含みます。";
            this._colSchedulePaymentAmount.Width = 125;
            // 
            // _colScheduleInterestAmount
            // 
            this._colScheduleInterestAmount.DataPropertyName = "InterestAmount";
            this._colScheduleInterestAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this._colScheduleInterestAmount.DefaultCellStyle.Format = "#,##0円";
            this._colScheduleInterestAmount.HeaderText = "利息";
            this._colScheduleInterestAmount.Name = "_colScheduleInterestAmount";
            this._colScheduleInterestAmount.ReadOnly = true;
            this._colScheduleInterestAmount.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colScheduleInterestAmount.Width = 100;
            // 
            // _colScheduleRemainingBalance
            // 
            this._colScheduleRemainingBalance.DataPropertyName = "RemainingBalance";
            this._colScheduleRemainingBalance.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this._colScheduleRemainingBalance.DefaultCellStyle.Format = "#,##0円";
            this._colScheduleRemainingBalance.HeaderText = "残高";
            this._colScheduleRemainingBalance.Name = "_colScheduleRemainingBalance";
            this._colScheduleRemainingBalance.ReadOnly = true;
            this._colScheduleRemainingBalance.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colScheduleRemainingBalance.Width = 115;
            // 
            // _colScheduleStatus
            // 
            this._colScheduleStatus.DataPropertyName = "Status";
            this._colScheduleStatus.HeaderText = "状態";
            this._colScheduleStatus.Name = "_colScheduleStatus";
            this._colScheduleStatus.ReadOnly = true;
            this._colScheduleStatus.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colScheduleStatus.Width = 90;
            // 
            // _colScheduleFailureNote
            // 
            this._colScheduleFailureNote.DataPropertyName = "FailureNote";
            this._colScheduleFailureNote.HeaderText = "入金失敗メモ";
            this._colScheduleFailureNote.Name = "_colScheduleFailureNote";
            this._colScheduleFailureNote.ReadOnly = true;
            this._colScheduleFailureNote.SortMode = DataGridViewColumnSortMode.Automatic;
            this._colScheduleFailureNote.Width = 220;
            // 
            // _lblScheduleSummary
            // 
            this._lblScheduleSummary.AutoSize = true;
            this._lblScheduleSummary.Dock = DockStyle.Fill;
            this._lblScheduleSummary.Location = new Point(11, 367);
            this._lblScheduleSummary.Name = "_lblScheduleSummary";
            this._lblScheduleSummary.Padding = new Padding(4, 8, 4, 0);
            this._lblScheduleSummary.Size = new Size(1302, 52);
            this._lblScheduleSummary.TabIndex = 2;
            this._lblScheduleSummary.Text = "ローンを選択してください。";
            // 
            // _detailTab
            // 
            this._detailTab.Controls.Add(this._txtDetails);
            this._detailTab.Location = new Point(4, 37);
            this._detailTab.Name = "_detailTab";
            this._detailTab.Padding = new Padding(3);
            this._detailTab.Size = new Size(1330, 433);
            this._detailTab.TabIndex = 1;
            this._detailTab.Text = "ローン詳細";
            this._detailTab.UseVisualStyleBackColor = true;
            // 
            // _txtDetails
            // 
            this._txtDetails.BackColor = SystemColors.Window;
            this._txtDetails.BorderStyle = BorderStyle.None;
            this._txtDetails.Dock = DockStyle.Fill;
            this._txtDetails.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this._txtDetails.Location = new Point(3, 3);
            this._txtDetails.Multiline = true;
            this._txtDetails.Name = "_txtDetails";
            this._txtDetails.ReadOnly = true;
            this._txtDetails.ScrollBars = ScrollBars.Vertical;
            this._txtDetails.Size = new Size(1324, 427);
            this._txtDetails.TabIndex = 0;
            // 
            // _statusStrip
            // 
            this._statusStrip.Dock = DockStyle.Fill;
            this._statusStrip.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this._statusStrip.Items.AddRange(new ToolStripItem[] {
            this._statusLabel});
            this._statusStrip.Location = new Point(0, 810);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new Size(1344, 31);
            this._statusStrip.TabIndex = 2;
            // 
            // _statusLabel
            // 
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new Size(1329, 25);
            this._statusLabel.Spring = true;
            this._statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.ClientSize = new Size(1344, 841);
            this.Controls.Add(this._shell);
            this.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.MinimumSize = new Size(1080, 700);
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ローン管理アプリ";
            this._shell.ResumeLayout(false);
            this._shell.PerformLayout();
            this._toolbar.ResumeLayout(false);
            this._toolbar.PerformLayout();
            this._mainSplit.Panel1.ResumeLayout(false);
            this._mainSplit.Panel2.ResumeLayout(false);
            ((ISupportInitialize)(this._mainSplit)).EndInit();
            this._mainSplit.ResumeLayout(false);
            ((ISupportInitialize)(this._loanGrid)).EndInit();
            this._tabs.ResumeLayout(false);
            this._scheduleTab.ResumeLayout(false);
            this._scheduleRoot.ResumeLayout(false);
            this._scheduleRoot.PerformLayout();
            this._scheduleHeader.ResumeLayout(false);
            this._scheduleTools.ResumeLayout(false);
            this._scheduleTools.PerformLayout();
            this._simulationPanel.ResumeLayout(false);
            this._simulationPanel.PerformLayout();
            ((ISupportInitialize)(this._scheduleGrid)).EndInit();
            this._detailTab.ResumeLayout(false);
            this._detailTab.PerformLayout();
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
