using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LoanManagerApp.Forms
{
    partial class MainForm
    {


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Windows Forms デザイナーで生成される初期化処理です。
        /// コードエディターから直接変更せず、可能な限りデザイナーを使用してください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.components = new System.ComponentModel.Container();
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
            this.loanNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanRepaymentTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanBonusPaymentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanPrincipalAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanAnnualInterestRateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanNextPaymentDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanNextPaymentAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanRemainingBalanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanRemainingPaymentCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanTotalPaymentAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.schedulePaymentNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schedulePaymentDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleRepaymentAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schedulePaymentAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleInterestAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleRemainingBalanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleStatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleFailureNoteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this._loanGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loanNameColumn,
            this.loanRepaymentTypeColumn,
            this.loanBonusPaymentColumn,
            this.loanPrincipalAmountColumn,
            this.loanAnnualInterestRateColumn,
            this.loanNextPaymentDateColumn,
            this.loanNextPaymentAmountColumn,
            this.loanRemainingBalanceColumn,
            this.loanRemainingPaymentCountColumn,
            this.loanTotalPaymentAmountColumn});
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
            // loanNameColumn
            // 
            this.loanNameColumn.DataPropertyName = "Name";
            this.loanNameColumn.HeaderText = "ローン名称";
            this.loanNameColumn.Name = "loanNameColumn";
            this.loanNameColumn.ReadOnly = true;
            this.loanNameColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.loanNameColumn.Width = 260;
            // 
            // loanRepaymentTypeColumn
            // 
            this.loanRepaymentTypeColumn.DataPropertyName = "RepaymentTypeName";
            this.loanRepaymentTypeColumn.HeaderText = "返済方式";
            this.loanRepaymentTypeColumn.Name = "loanRepaymentTypeColumn";
            this.loanRepaymentTypeColumn.ReadOnly = true;
            this.loanRepaymentTypeColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.loanRepaymentTypeColumn.Width = 125;
            // 
            // loanBonusPaymentColumn
            // 
            this.loanBonusPaymentColumn.DataPropertyName = "BonusPaymentName";
            this.loanBonusPaymentColumn.HeaderText = "ボーナス払い";
            this.loanBonusPaymentColumn.Name = "loanBonusPaymentColumn";
            this.loanBonusPaymentColumn.ReadOnly = true;
            this.loanBonusPaymentColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.loanBonusPaymentColumn.Width = 115;
            // 
            // loanPrincipalAmountColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "#,##0円";
            dataGridViewCellStyle1.NullValue = null;
            this.loanPrincipalAmountColumn.DataPropertyName = "PrincipalAmount";
            this.loanPrincipalAmountColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.loanPrincipalAmountColumn.HeaderText = "借入額";
            this.loanPrincipalAmountColumn.Name = "loanPrincipalAmountColumn";
            this.loanPrincipalAmountColumn.ReadOnly = true;
            this.loanPrincipalAmountColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.loanPrincipalAmountColumn.Width = 135;
            // 
            // loanAnnualInterestRateColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "0.##";
            dataGridViewCellStyle2.NullValue = null;
            this.loanAnnualInterestRateColumn.DataPropertyName = "AnnualInterestRate";
            this.loanAnnualInterestRateColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.loanAnnualInterestRateColumn.HeaderText = "年利(%)";
            this.loanAnnualInterestRateColumn.Name = "loanAnnualInterestRateColumn";
            this.loanAnnualInterestRateColumn.ReadOnly = true;
            this.loanAnnualInterestRateColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.loanAnnualInterestRateColumn.Width = 75;
            // 
            // loanNextPaymentDateColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "yyyy/MM/dd";
            dataGridViewCellStyle3.NullValue = null;
            this.loanNextPaymentDateColumn.DataPropertyName = "NextPaymentDate";
            this.loanNextPaymentDateColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.loanNextPaymentDateColumn.HeaderText = "次回返済日";
            this.loanNextPaymentDateColumn.Name = "loanNextPaymentDateColumn";
            this.loanNextPaymentDateColumn.ReadOnly = true;
            this.loanNextPaymentDateColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.loanNextPaymentDateColumn.Width = 110;
            // 
            // loanNextPaymentAmountColumn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0円";
            dataGridViewCellStyle4.NullValue = null;
            this.loanNextPaymentAmountColumn.DataPropertyName = "NextPaymentAmount";
            this.loanNextPaymentAmountColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.loanNextPaymentAmountColumn.HeaderText = "お支払い額";
            this.loanNextPaymentAmountColumn.Name = "loanNextPaymentAmountColumn";
            this.loanNextPaymentAmountColumn.ReadOnly = true;
            this.loanNextPaymentAmountColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.loanNextPaymentAmountColumn.ToolTipText = "次回返済日に支払う予定額です。";
            this.loanNextPaymentAmountColumn.Width = 135;
            // 
            // loanRemainingBalanceColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0円";
            dataGridViewCellStyle5.NullValue = null;
            this.loanRemainingBalanceColumn.DataPropertyName = "RemainingBalance";
            this.loanRemainingBalanceColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.loanRemainingBalanceColumn.HeaderText = "推定残高";
            this.loanRemainingBalanceColumn.Name = "loanRemainingBalanceColumn";
            this.loanRemainingBalanceColumn.ReadOnly = true;
            this.loanRemainingBalanceColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.loanRemainingBalanceColumn.Width = 135;
            // 
            // loanRemainingPaymentCountColumn
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#,##0回";
            dataGridViewCellStyle6.NullValue = null;
            this.loanRemainingPaymentCountColumn.DataPropertyName = "RemainingPaymentCount";
            this.loanRemainingPaymentCountColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.loanRemainingPaymentCountColumn.HeaderText = "残回数";
            this.loanRemainingPaymentCountColumn.Name = "loanRemainingPaymentCountColumn";
            this.loanRemainingPaymentCountColumn.ReadOnly = true;
            this.loanRemainingPaymentCountColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.loanRemainingPaymentCountColumn.Width = 80;
            // 
            // loanTotalPaymentAmountColumn
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "#,##0円";
            dataGridViewCellStyle7.NullValue = null;
            this.loanTotalPaymentAmountColumn.DataPropertyName = "TotalPaymentAmount";
            this.loanTotalPaymentAmountColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.loanTotalPaymentAmountColumn.HeaderText = "総お支払い額";
            this.loanTotalPaymentAmountColumn.Name = "loanTotalPaymentAmountColumn";
            this.loanTotalPaymentAmountColumn.ReadOnly = true;
            this.loanTotalPaymentAmountColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.loanTotalPaymentAmountColumn.Width = 135;
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
            this._scheduleGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.schedulePaymentNumberColumn,
            this.schedulePaymentDateColumn,
            this.scheduleRepaymentAmountColumn,
            this.schedulePaymentAmountColumn,
            this.scheduleInterestAmountColumn,
            this.scheduleRemainingBalanceColumn,
            this.scheduleStatusColumn,
            this.scheduleFailureNoteColumn});
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
            // schedulePaymentNumberColumn
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "0";
            dataGridViewCellStyle8.NullValue = null;
            this.schedulePaymentNumberColumn.DataPropertyName = "PaymentNumber";
            this.schedulePaymentNumberColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.schedulePaymentNumberColumn.HeaderText = "回";
            this.schedulePaymentNumberColumn.Name = "schedulePaymentNumberColumn";
            this.schedulePaymentNumberColumn.ReadOnly = true;
            this.schedulePaymentNumberColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.schedulePaymentNumberColumn.Width = 55;
            // 
            // schedulePaymentDateColumn
            // 
            this.schedulePaymentDateColumn.DataPropertyName = "PaymentDateText";
            this.schedulePaymentDateColumn.HeaderText = "返済予定日";
            this.schedulePaymentDateColumn.Name = "schedulePaymentDateColumn";
            this.schedulePaymentDateColumn.ReadOnly = true;
            this.schedulePaymentDateColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.schedulePaymentDateColumn.Width = 105;
            // 
            // scheduleRepaymentAmountColumn
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "#,##0円";
            dataGridViewCellStyle9.NullValue = null;
            this.scheduleRepaymentAmountColumn.DataPropertyName = "RepaymentAmount";
            this.scheduleRepaymentAmountColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.scheduleRepaymentAmountColumn.HeaderText = "返済額（元金）";
            this.scheduleRepaymentAmountColumn.Name = "scheduleRepaymentAmountColumn";
            this.scheduleRepaymentAmountColumn.ReadOnly = true;
            this.scheduleRepaymentAmountColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.scheduleRepaymentAmountColumn.ToolTipText = "その回に返済する元金。残高から減る金額です。";
            this.scheduleRepaymentAmountColumn.Width = 135;
            // 
            // schedulePaymentAmountColumn
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "#,##0円";
            dataGridViewCellStyle10.NullValue = null;
            this.schedulePaymentAmountColumn.DataPropertyName = "PaymentAmount";
            this.schedulePaymentAmountColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.schedulePaymentAmountColumn.HeaderText = "お支払い額";
            this.schedulePaymentAmountColumn.Name = "schedulePaymentAmountColumn";
            this.schedulePaymentAmountColumn.ReadOnly = true;
            this.schedulePaymentAmountColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.schedulePaymentAmountColumn.ToolTipText = "返済額（元金）と利息の合計。ボーナス月はボーナス分も含みます。";
            this.schedulePaymentAmountColumn.Width = 135;
            // 
            // scheduleInterestAmountColumn
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "#,##0円";
            dataGridViewCellStyle11.NullValue = null;
            this.scheduleInterestAmountColumn.DataPropertyName = "InterestAmount";
            this.scheduleInterestAmountColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.scheduleInterestAmountColumn.HeaderText = "利息";
            this.scheduleInterestAmountColumn.Name = "scheduleInterestAmountColumn";
            this.scheduleInterestAmountColumn.ReadOnly = true;
            this.scheduleInterestAmountColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.scheduleInterestAmountColumn.Width = 135;
            // 
            // scheduleRemainingBalanceColumn
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "#,##0円";
            dataGridViewCellStyle12.NullValue = null;
            this.scheduleRemainingBalanceColumn.DataPropertyName = "RemainingBalance";
            this.scheduleRemainingBalanceColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.scheduleRemainingBalanceColumn.HeaderText = "残高";
            this.scheduleRemainingBalanceColumn.Name = "scheduleRemainingBalanceColumn";
            this.scheduleRemainingBalanceColumn.ReadOnly = true;
            this.scheduleRemainingBalanceColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.scheduleRemainingBalanceColumn.Width = 135;
            // 
            // scheduleStatusColumn
            // 
            this.scheduleStatusColumn.DataPropertyName = "Status";
            this.scheduleStatusColumn.HeaderText = "状態";
            this.scheduleStatusColumn.Name = "scheduleStatusColumn";
            this.scheduleStatusColumn.ReadOnly = true;
            this.scheduleStatusColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.scheduleStatusColumn.Width = 90;
            // 
            // scheduleFailureNoteColumn
            // 
            this.scheduleFailureNoteColumn.DataPropertyName = "FailureNote";
            this.scheduleFailureNoteColumn.HeaderText = "入金失敗メモ";
            this.scheduleFailureNoteColumn.Name = "scheduleFailureNoteColumn";
            this.scheduleFailureNoteColumn.ReadOnly = true;
            this.scheduleFailureNoteColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            this.scheduleFailureNoteColumn.Width = 220;
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

        #endregion

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel _shell;
        private System.Windows.Forms.ToolStrip _toolbar;
        private System.Windows.Forms.ToolStripButton _btnAddLoan;
        private System.Windows.Forms.ToolStripButton _btnEditLoan;
        private System.Windows.Forms.ToolStripButton _btnDeleteLoan;
        private System.Windows.Forms.ToolStripSeparator _toolbarSeparator1;
        private System.Windows.Forms.ToolStripButton _btnRefresh;
        private System.Windows.Forms.ToolStripSeparator _toolbarSeparator2;
        private System.Windows.Forms.ToolStripButton _btnOpenDataFolder;
        private System.Windows.Forms.SplitContainer _mainSplit;
        private System.Windows.Forms.DataGridView _loanGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanRepaymentTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanBonusPaymentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanPrincipalAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanAnnualInterestRateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanNextPaymentDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanNextPaymentAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanRemainingBalanceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanRemainingPaymentCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanTotalPaymentAmountColumn;
        private System.Windows.Forms.TabControl _tabs;
        private System.Windows.Forms.TabPage _scheduleTab;
        private System.Windows.Forms.TabPage _detailTab;
        private System.Windows.Forms.TableLayoutPanel _scheduleRoot;
        private System.Windows.Forms.TableLayoutPanel _scheduleHeader;
        private System.Windows.Forms.FlowLayoutPanel _scheduleTools;
        private System.Windows.Forms.CheckBox _chkRemainingOnly;
        private System.Windows.Forms.Button _btnFailure;
        private System.Windows.Forms.FlowLayoutPanel _simulationPanel;
        private System.Windows.Forms.Label _lblSimulationState;
        private System.Windows.Forms.Label _lblSimulationDate;
        private System.Windows.Forms.DateTimePicker _dtpSimulationDate;
        private System.Windows.Forms.Button _btnResetSimulationDate;
        private System.Windows.Forms.DataGridView _scheduleGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn schedulePaymentNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn schedulePaymentDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduleRepaymentAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn schedulePaymentAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduleInterestAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduleRemainingBalanceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduleStatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduleFailureNoteColumn;
        private System.Windows.Forms.Label _lblScheduleSummary;
        private System.Windows.Forms.TextBox _txtDetails;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _statusLabel;
    }
}
