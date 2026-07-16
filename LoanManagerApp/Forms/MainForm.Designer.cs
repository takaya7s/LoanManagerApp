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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this._shell = new System.Windows.Forms.TableLayoutPanel();
            this._toolbar = new System.Windows.Forms.ToolStrip();
            this._btnAddLoan = new System.Windows.Forms.ToolStripButton();
            this._btnEditLoan = new System.Windows.Forms.ToolStripButton();
            this._btnDeleteLoan = new System.Windows.Forms.ToolStripButton();
            this._toolbarSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._btnRefresh = new System.Windows.Forms.ToolStripButton();
            this._toolbarSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._btnOpenDataFolder = new System.Windows.Forms.ToolStripButton();
            this._mainSplit = new System.Windows.Forms.SplitContainer();
            this._loanGrid = new System.Windows.Forms.DataGridView();
            this._tabs = new System.Windows.Forms.TabControl();
            this._scheduleTab = new System.Windows.Forms.TabPage();
            this._scheduleRoot = new System.Windows.Forms.TableLayoutPanel();
            this._scheduleHeader = new System.Windows.Forms.TableLayoutPanel();
            this._scheduleTools = new System.Windows.Forms.FlowLayoutPanel();
            this._chkRemainingOnly = new System.Windows.Forms.CheckBox();
            this._btnFailure = new System.Windows.Forms.Button();
            this._simulationPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._lblSimulationState = new System.Windows.Forms.Label();
            this._lblSimulationDate = new System.Windows.Forms.Label();
            this._dtpSimulationDate = new System.Windows.Forms.DateTimePicker();
            this._btnResetSimulationDate = new System.Windows.Forms.Button();
            this._scheduleGrid = new System.Windows.Forms.DataGridView();
            this.schedulePaymentNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schedulePaymentDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleRepaymentAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schedulePaymentAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleInterestAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleRemainingBalanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleStatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleFailureNoteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._lblScheduleSummary = new System.Windows.Forms.Label();
            this._detailTab = new System.Windows.Forms.TabPage();
            this._txtDetails = new System.Windows.Forms.TextBox();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
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
            this._shell.SuspendLayout();
            this._toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mainSplit)).BeginInit();
            this._mainSplit.Panel1.SuspendLayout();
            this._mainSplit.Panel2.SuspendLayout();
            this._mainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._loanGrid)).BeginInit();
            this._tabs.SuspendLayout();
            this._scheduleTab.SuspendLayout();
            this._scheduleRoot.SuspendLayout();
            this._scheduleHeader.SuspendLayout();
            this._scheduleTools.SuspendLayout();
            this._simulationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._scheduleGrid)).BeginInit();
            this._detailTab.SuspendLayout();
            this._statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _shell
            // 
            this._shell.ColumnCount = 1;
            this._shell.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._shell.Controls.Add(this._toolbar, 0, 0);
            this._shell.Controls.Add(this._mainSplit, 0, 1);
            this._shell.Controls.Add(this._statusStrip, 0, 2);
            this._shell.Dock = System.Windows.Forms.DockStyle.Fill;
            this._shell.Location = new System.Drawing.Point(0, 0);
            this._shell.Margin = new System.Windows.Forms.Padding(0);
            this._shell.Name = "_shell";
            this._shell.RowCount = 3;
            this._shell.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._shell.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._shell.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._shell.Size = new System.Drawing.Size(1344, 841);
            this._shell.TabIndex = 0;
            // 
            // _toolbar
            // 
            this._toolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this._toolbar.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this._toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._toolbar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnAddLoan,
            this._btnEditLoan,
            this._btnDeleteLoan,
            this._toolbarSeparator1,
            this._btnRefresh,
            this._toolbarSeparator2,
            this._btnOpenDataFolder});
            this._toolbar.Location = new System.Drawing.Point(0, 0);
            this._toolbar.Name = "_toolbar";
            this._toolbar.Padding = new System.Windows.Forms.Padding(6);
            this._toolbar.Size = new System.Drawing.Size(1344, 40);
            this._toolbar.TabIndex = 0;
            // 
            // _btnAddLoan
            // 
            this._btnAddLoan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._btnAddLoan.Name = "_btnAddLoan";
            this._btnAddLoan.Size = new System.Drawing.Size(78, 25);
            this._btnAddLoan.Text = "新規登録";
            this._btnAddLoan.Click += new System.EventHandler(this.AddLoan);
            // 
            // _btnEditLoan
            // 
            this._btnEditLoan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._btnEditLoan.Name = "_btnEditLoan";
            this._btnEditLoan.Size = new System.Drawing.Size(46, 25);
            this._btnEditLoan.Text = "編集";
            this._btnEditLoan.Click += new System.EventHandler(this.EditLoan);
            // 
            // _btnDeleteLoan
            // 
            this._btnDeleteLoan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._btnDeleteLoan.Name = "_btnDeleteLoan";
            this._btnDeleteLoan.Size = new System.Drawing.Size(46, 25);
            this._btnDeleteLoan.Text = "削除";
            this._btnDeleteLoan.Click += new System.EventHandler(this.DeleteLoan);
            // 
            // _toolbarSeparator1
            // 
            this._toolbarSeparator1.Name = "_toolbarSeparator1";
            this._toolbarSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // _btnRefresh
            // 
            this._btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._btnRefresh.Name = "_btnRefresh";
            this._btnRefresh.Size = new System.Drawing.Size(90, 25);
            this._btnRefresh.Text = "再読み込み";
            this._btnRefresh.Click += new System.EventHandler(this.RefreshLoanList);
            // 
            // _toolbarSeparator2
            // 
            this._toolbarSeparator2.Name = "_toolbarSeparator2";
            this._toolbarSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // _btnOpenDataFolder
            // 
            this._btnOpenDataFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._btnOpenDataFolder.Name = "_btnOpenDataFolder";
            this._btnOpenDataFolder.Size = new System.Drawing.Size(97, 25);
            this._btnOpenDataFolder.Text = "データ保存先";
            this._btnOpenDataFolder.Click += new System.EventHandler(this.OpenDataFolder);
            // 
            // _mainSplit
            // 
            this._mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainSplit.Location = new System.Drawing.Point(3, 43);
            this._mainSplit.Name = "_mainSplit";
            this._mainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _mainSplit.Panel1
            // 
            this._mainSplit.Panel1.Controls.Add(this._loanGrid);
            // 
            // _mainSplit.Panel2
            // 
            this._mainSplit.Panel2.Controls.Add(this._tabs);
            this._mainSplit.Size = new System.Drawing.Size(1338, 773);
            this._mainSplit.SplitterDistance = 285;
            this._mainSplit.TabIndex = 1;
            // 
            // _loanGrid
            // 
            this._loanGrid.AllowUserToAddRows = false;
            this._loanGrid.AllowUserToDeleteRows = false;
            this._loanGrid.AllowUserToResizeRows = false;
            this._loanGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this._loanGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._loanGrid.ColumnHeadersHeight = 40;
            this._loanGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
            this._loanGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._loanGrid.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this._loanGrid.Location = new System.Drawing.Point(0, 0);
            this._loanGrid.MultiSelect = false;
            this._loanGrid.Name = "_loanGrid";
            this._loanGrid.ReadOnly = true;
            this._loanGrid.RowHeadersVisible = false;
            this._loanGrid.RowTemplate.Height = 34;
            this._loanGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._loanGrid.Size = new System.Drawing.Size(1338, 285);
            this._loanGrid.TabIndex = 0;
            this._loanGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LoanGridCellDoubleClick);
            this._loanGrid.SelectionChanged += new System.EventHandler(this.LoanSelectionChanged);
            // 
            // _tabs
            // 
            this._tabs.Controls.Add(this._scheduleTab);
            this._tabs.Controls.Add(this._detailTab);
            this._tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabs.Location = new System.Drawing.Point(0, 0);
            this._tabs.Name = "_tabs";
            this._tabs.SelectedIndex = 0;
            this._tabs.Size = new System.Drawing.Size(1338, 484);
            this._tabs.TabIndex = 0;
            // 
            // _scheduleTab
            // 
            this._scheduleTab.Controls.Add(this._scheduleRoot);
            this._scheduleTab.Location = new System.Drawing.Point(4, 30);
            this._scheduleTab.Name = "_scheduleTab";
            this._scheduleTab.Padding = new System.Windows.Forms.Padding(3);
            this._scheduleTab.Size = new System.Drawing.Size(1330, 450);
            this._scheduleTab.TabIndex = 0;
            this._scheduleTab.Text = "返済スケジュール";
            this._scheduleTab.UseVisualStyleBackColor = true;
            // 
            // _scheduleRoot
            // 
            this._scheduleRoot.ColumnCount = 1;
            this._scheduleRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._scheduleRoot.Controls.Add(this._scheduleHeader, 0, 0);
            this._scheduleRoot.Controls.Add(this._scheduleGrid, 0, 1);
            this._scheduleRoot.Controls.Add(this._lblScheduleSummary, 0, 2);
            this._scheduleRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scheduleRoot.Location = new System.Drawing.Point(3, 3);
            this._scheduleRoot.Name = "_scheduleRoot";
            this._scheduleRoot.Padding = new System.Windows.Forms.Padding(8);
            this._scheduleRoot.RowCount = 3;
            this._scheduleRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this._scheduleRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._scheduleRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._scheduleRoot.Size = new System.Drawing.Size(1324, 444);
            this._scheduleRoot.TabIndex = 0;
            // 
            // _scheduleHeader
            // 
            this._scheduleHeader.ColumnCount = 2;
            this._scheduleHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._scheduleHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._scheduleHeader.Controls.Add(this._scheduleTools, 0, 0);
            this._scheduleHeader.Controls.Add(this._simulationPanel, 1, 0);
            this._scheduleHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scheduleHeader.Location = new System.Drawing.Point(8, 8);
            this._scheduleHeader.Margin = new System.Windows.Forms.Padding(0);
            this._scheduleHeader.Name = "_scheduleHeader";
            this._scheduleHeader.RowCount = 1;
            this._scheduleHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._scheduleHeader.Size = new System.Drawing.Size(1308, 56);
            this._scheduleHeader.TabIndex = 0;
            // 
            // _scheduleTools
            // 
            this._scheduleTools.AutoSize = true;
            this._scheduleTools.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._scheduleTools.Controls.Add(this._chkRemainingOnly);
            this._scheduleTools.Controls.Add(this._btnFailure);
            this._scheduleTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scheduleTools.Location = new System.Drawing.Point(0, 0);
            this._scheduleTools.Margin = new System.Windows.Forms.Padding(0);
            this._scheduleTools.Name = "_scheduleTools";
            this._scheduleTools.Size = new System.Drawing.Size(345, 56);
            this._scheduleTools.TabIndex = 0;
            this._scheduleTools.WrapContents = false;
            // 
            // _chkRemainingOnly
            // 
            this._chkRemainingOnly.AutoSize = true;
            this._chkRemainingOnly.Checked = true;
            this._chkRemainingOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkRemainingOnly.Location = new System.Drawing.Point(3, 11);
            this._chkRemainingOnly.Margin = new System.Windows.Forms.Padding(3, 11, 16, 3);
            this._chkRemainingOnly.Name = "_chkRemainingOnly";
            this._chkRemainingOnly.Size = new System.Drawing.Size(160, 25);
            this._chkRemainingOnly.TabIndex = 0;
            this._chkRemainingOnly.Text = "残りの返済のみ表示";
            this._chkRemainingOnly.UseVisualStyleBackColor = true;
            this._chkRemainingOnly.CheckedChanged += new System.EventHandler(this.RemainingOnlyCheckedChanged);
            // 
            // _btnFailure
            // 
            this._btnFailure.AutoSize = true;
            this._btnFailure.Location = new System.Drawing.Point(182, 4);
            this._btnFailure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this._btnFailure.MinimumSize = new System.Drawing.Size(160, 42);
            this._btnFailure.Name = "_btnFailure";
            this._btnFailure.Size = new System.Drawing.Size(160, 42);
            this._btnFailure.TabIndex = 1;
            this._btnFailure.Text = "入金失敗を登録";
            this._btnFailure.UseVisualStyleBackColor = true;
            this._btnFailure.Click += new System.EventHandler(this.TogglePaymentFailure);
            // 
            // _simulationPanel
            // 
            this._simulationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._simulationPanel.AutoSize = true;
            this._simulationPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._simulationPanel.BackColor = System.Drawing.SystemColors.Control;
            this._simulationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._simulationPanel.Controls.Add(this._lblSimulationState);
            this._simulationPanel.Controls.Add(this._lblSimulationDate);
            this._simulationPanel.Controls.Add(this._dtpSimulationDate);
            this._simulationPanel.Controls.Add(this._btnResetSimulationDate);
            this._simulationPanel.Location = new System.Drawing.Point(822, 0);
            this._simulationPanel.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this._simulationPanel.Name = "_simulationPanel";
            this._simulationPanel.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this._simulationPanel.Size = new System.Drawing.Size(486, 52);
            this._simulationPanel.TabIndex = 1;
            this._simulationPanel.WrapContents = false;
            // 
            // _lblSimulationState
            // 
            this._lblSimulationState.AutoSize = true;
            this._lblSimulationState.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblSimulationState.Location = new System.Drawing.Point(9, 11);
            this._lblSimulationState.Margin = new System.Windows.Forms.Padding(3, 7, 10, 3);
            this._lblSimulationState.Name = "_lblSimulationState";
            this._lblSimulationState.Size = new System.Drawing.Size(74, 21);
            this._lblSimulationState.TabIndex = 0;
            this._lblSimulationState.Text = "本日基準";
            // 
            // _lblSimulationDate
            // 
            this._lblSimulationDate.AutoSize = true;
            this._lblSimulationDate.Location = new System.Drawing.Point(96, 11);
            this._lblSimulationDate.Margin = new System.Windows.Forms.Padding(3, 7, 6, 3);
            this._lblSimulationDate.Name = "_lblSimulationDate";
            this._lblSimulationDate.Size = new System.Drawing.Size(58, 21);
            this._lblSimulationDate.TabIndex = 1;
            this._lblSimulationDate.Text = "基準日";
            // 
            // _dtpSimulationDate
            // 
            this._dtpSimulationDate.CustomFormat = "yyyy年MM月dd日";
            this._dtpSimulationDate.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this._dtpSimulationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpSimulationDate.Location = new System.Drawing.Point(160, 7);
            this._dtpSimulationDate.Margin = new System.Windows.Forms.Padding(0, 3, 8, 3);
            this._dtpSimulationDate.Name = "_dtpSimulationDate";
            this._dtpSimulationDate.Size = new System.Drawing.Size(190, 29);
            this._dtpSimulationDate.TabIndex = 2;
            this._dtpSimulationDate.ValueChanged += new System.EventHandler(this.SimulationDateChanged);
            // 
            // _btnResetSimulationDate
            // 
            this._btnResetSimulationDate.AutoSize = true;
            this._btnResetSimulationDate.Location = new System.Drawing.Point(358, 5);
            this._btnResetSimulationDate.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this._btnResetSimulationDate.MinimumSize = new System.Drawing.Size(120, 40);
            this._btnResetSimulationDate.Name = "_btnResetSimulationDate";
            this._btnResetSimulationDate.Size = new System.Drawing.Size(120, 40);
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
            this._scheduleGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this._scheduleGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._scheduleGrid.ColumnHeadersHeight = 40;
            this._scheduleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._scheduleGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.schedulePaymentNumberColumn,
            this.schedulePaymentDateColumn,
            this.scheduleRepaymentAmountColumn,
            this.schedulePaymentAmountColumn,
            this.scheduleInterestAmountColumn,
            this.scheduleRemainingBalanceColumn,
            this.scheduleStatusColumn,
            this.scheduleFailureNoteColumn});
            this._scheduleGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scheduleGrid.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this._scheduleGrid.Location = new System.Drawing.Point(11, 67);
            this._scheduleGrid.MultiSelect = false;
            this._scheduleGrid.Name = "_scheduleGrid";
            this._scheduleGrid.ReadOnly = true;
            this._scheduleGrid.RowHeadersVisible = false;
            this._scheduleGrid.RowTemplate.Height = 34;
            this._scheduleGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._scheduleGrid.Size = new System.Drawing.Size(1302, 337);
            this._scheduleGrid.TabIndex = 1;
            this._scheduleGrid.SelectionChanged += new System.EventHandler(this.ScheduleSelectionChanged);
            // 
            // schedulePaymentNumberColumn
            // 
            this.schedulePaymentNumberColumn.DataPropertyName = "PaymentNumber";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "0";
            dataGridViewCellStyle8.NullValue = null;
            this.schedulePaymentNumberColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.schedulePaymentNumberColumn.HeaderText = "回";
            this.schedulePaymentNumberColumn.Name = "schedulePaymentNumberColumn";
            this.schedulePaymentNumberColumn.ReadOnly = true;
            this.schedulePaymentNumberColumn.Width = 55;
            // 
            // schedulePaymentDateColumn
            // 
            this.schedulePaymentDateColumn.DataPropertyName = "PaymentDateText";
            this.schedulePaymentDateColumn.HeaderText = "返済予定日";
            this.schedulePaymentDateColumn.Name = "schedulePaymentDateColumn";
            this.schedulePaymentDateColumn.ReadOnly = true;
            this.schedulePaymentDateColumn.Width = 105;
            // 
            // scheduleRepaymentAmountColumn
            // 
            this.scheduleRepaymentAmountColumn.DataPropertyName = "RepaymentAmount";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "#,##0円";
            dataGridViewCellStyle9.NullValue = null;
            this.scheduleRepaymentAmountColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.scheduleRepaymentAmountColumn.HeaderText = "返済額（元金）";
            this.scheduleRepaymentAmountColumn.Name = "scheduleRepaymentAmountColumn";
            this.scheduleRepaymentAmountColumn.ReadOnly = true;
            this.scheduleRepaymentAmountColumn.ToolTipText = "その回に返済する元金。残高から減る金額です。";
            this.scheduleRepaymentAmountColumn.Width = 135;
            // 
            // schedulePaymentAmountColumn
            // 
            this.schedulePaymentAmountColumn.DataPropertyName = "PaymentAmount";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "#,##0円";
            dataGridViewCellStyle10.NullValue = null;
            this.schedulePaymentAmountColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.schedulePaymentAmountColumn.HeaderText = "お支払い額";
            this.schedulePaymentAmountColumn.Name = "schedulePaymentAmountColumn";
            this.schedulePaymentAmountColumn.ReadOnly = true;
            this.schedulePaymentAmountColumn.ToolTipText = "返済額（元金）と利息の合計。ボーナス月はボーナス分も含みます。";
            this.schedulePaymentAmountColumn.Width = 135;
            // 
            // scheduleInterestAmountColumn
            // 
            this.scheduleInterestAmountColumn.DataPropertyName = "InterestAmount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "#,##0円";
            dataGridViewCellStyle11.NullValue = null;
            this.scheduleInterestAmountColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.scheduleInterestAmountColumn.HeaderText = "利息";
            this.scheduleInterestAmountColumn.Name = "scheduleInterestAmountColumn";
            this.scheduleInterestAmountColumn.ReadOnly = true;
            this.scheduleInterestAmountColumn.Width = 135;
            // 
            // scheduleRemainingBalanceColumn
            // 
            this.scheduleRemainingBalanceColumn.DataPropertyName = "RemainingBalance";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "#,##0円";
            dataGridViewCellStyle12.NullValue = null;
            this.scheduleRemainingBalanceColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.scheduleRemainingBalanceColumn.HeaderText = "残高";
            this.scheduleRemainingBalanceColumn.Name = "scheduleRemainingBalanceColumn";
            this.scheduleRemainingBalanceColumn.ReadOnly = true;
            this.scheduleRemainingBalanceColumn.Width = 135;
            // 
            // scheduleStatusColumn
            // 
            this.scheduleStatusColumn.DataPropertyName = "Status";
            this.scheduleStatusColumn.HeaderText = "状態";
            this.scheduleStatusColumn.Name = "scheduleStatusColumn";
            this.scheduleStatusColumn.ReadOnly = true;
            this.scheduleStatusColumn.Width = 90;
            // 
            // scheduleFailureNoteColumn
            // 
            this.scheduleFailureNoteColumn.DataPropertyName = "FailureNote";
            this.scheduleFailureNoteColumn.HeaderText = "入金失敗メモ";
            this.scheduleFailureNoteColumn.Name = "scheduleFailureNoteColumn";
            this.scheduleFailureNoteColumn.ReadOnly = true;
            this.scheduleFailureNoteColumn.Width = 220;
            // 
            // _lblScheduleSummary
            // 
            this._lblScheduleSummary.AutoSize = true;
            this._lblScheduleSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblScheduleSummary.Location = new System.Drawing.Point(11, 407);
            this._lblScheduleSummary.Name = "_lblScheduleSummary";
            this._lblScheduleSummary.Padding = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this._lblScheduleSummary.Size = new System.Drawing.Size(1302, 29);
            this._lblScheduleSummary.TabIndex = 2;
            this._lblScheduleSummary.Text = "ローンを選択してください。";
            // 
            // _detailTab
            // 
            this._detailTab.Controls.Add(this._txtDetails);
            this._detailTab.Location = new System.Drawing.Point(4, 30);
            this._detailTab.Name = "_detailTab";
            this._detailTab.Padding = new System.Windows.Forms.Padding(3);
            this._detailTab.Size = new System.Drawing.Size(1330, 450);
            this._detailTab.TabIndex = 1;
            this._detailTab.Text = "ローン詳細";
            this._detailTab.UseVisualStyleBackColor = true;
            // 
            // _txtDetails
            // 
            this._txtDetails.BackColor = System.Drawing.SystemColors.Window;
            this._txtDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtDetails.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this._txtDetails.Location = new System.Drawing.Point(3, 3);
            this._txtDetails.Multiline = true;
            this._txtDetails.Name = "_txtDetails";
            this._txtDetails.ReadOnly = true;
            this._txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtDetails.Size = new System.Drawing.Size(1324, 444);
            this._txtDetails.TabIndex = 0;
            // 
            // _statusStrip
            // 
            this._statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this._statusStrip.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._statusLabel});
            this._statusStrip.Location = new System.Drawing.Point(0, 819);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(1344, 22);
            this._statusStrip.TabIndex = 2;
            // 
            // _statusLabel
            // 
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(1329, 17);
            this._statusLabel.Spring = true;
            this._statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loanNameColumn
            // 
            this.loanNameColumn.DataPropertyName = "Name";
            this.loanNameColumn.HeaderText = "ローン名称";
            this.loanNameColumn.Name = "loanNameColumn";
            this.loanNameColumn.ReadOnly = true;
            this.loanNameColumn.Width = 260;
            // 
            // loanRepaymentTypeColumn
            // 
            this.loanRepaymentTypeColumn.DataPropertyName = "RepaymentTypeName";
            this.loanRepaymentTypeColumn.HeaderText = "返済方式";
            this.loanRepaymentTypeColumn.Name = "loanRepaymentTypeColumn";
            this.loanRepaymentTypeColumn.ReadOnly = true;
            this.loanRepaymentTypeColumn.Width = 125;
            // 
            // loanBonusPaymentColumn
            // 
            this.loanBonusPaymentColumn.DataPropertyName = "BonusPaymentName";
            this.loanBonusPaymentColumn.HeaderText = "ボーナス払い";
            this.loanBonusPaymentColumn.Name = "loanBonusPaymentColumn";
            this.loanBonusPaymentColumn.ReadOnly = true;
            // 
            // loanPrincipalAmountColumn
            // 
            this.loanPrincipalAmountColumn.DataPropertyName = "PrincipalAmount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "#,##0円";
            dataGridViewCellStyle1.NullValue = null;
            this.loanPrincipalAmountColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.loanPrincipalAmountColumn.HeaderText = "借入額";
            this.loanPrincipalAmountColumn.Name = "loanPrincipalAmountColumn";
            this.loanPrincipalAmountColumn.ReadOnly = true;
            this.loanPrincipalAmountColumn.Width = 135;
            // 
            // loanAnnualInterestRateColumn
            // 
            this.loanAnnualInterestRateColumn.DataPropertyName = "AnnualInterestRate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "0.##";
            dataGridViewCellStyle2.NullValue = null;
            this.loanAnnualInterestRateColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.loanAnnualInterestRateColumn.HeaderText = "年利(%)";
            this.loanAnnualInterestRateColumn.Name = "loanAnnualInterestRateColumn";
            this.loanAnnualInterestRateColumn.ReadOnly = true;
            this.loanAnnualInterestRateColumn.Width = 75;
            // 
            // loanNextPaymentDateColumn
            // 
            this.loanNextPaymentDateColumn.DataPropertyName = "NextPaymentDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "yyyy/MM/dd";
            dataGridViewCellStyle3.NullValue = null;
            this.loanNextPaymentDateColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.loanNextPaymentDateColumn.HeaderText = "次回返済日";
            this.loanNextPaymentDateColumn.Name = "loanNextPaymentDateColumn";
            this.loanNextPaymentDateColumn.ReadOnly = true;
            this.loanNextPaymentDateColumn.Width = 110;
            // 
            // loanNextPaymentAmountColumn
            // 
            this.loanNextPaymentAmountColumn.DataPropertyName = "NextPaymentAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0円";
            dataGridViewCellStyle4.NullValue = null;
            this.loanNextPaymentAmountColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.loanNextPaymentAmountColumn.HeaderText = "お支払い額";
            this.loanNextPaymentAmountColumn.Name = "loanNextPaymentAmountColumn";
            this.loanNextPaymentAmountColumn.ReadOnly = true;
            this.loanNextPaymentAmountColumn.ToolTipText = "次回返済日に支払う予定額です。";
            this.loanNextPaymentAmountColumn.Width = 135;
            // 
            // loanRemainingBalanceColumn
            // 
            this.loanRemainingBalanceColumn.DataPropertyName = "RemainingBalance";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0円";
            dataGridViewCellStyle5.NullValue = null;
            this.loanRemainingBalanceColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.loanRemainingBalanceColumn.HeaderText = "推定残高";
            this.loanRemainingBalanceColumn.Name = "loanRemainingBalanceColumn";
            this.loanRemainingBalanceColumn.ReadOnly = true;
            this.loanRemainingBalanceColumn.Width = 135;
            // 
            // loanRemainingPaymentCountColumn
            // 
            this.loanRemainingPaymentCountColumn.DataPropertyName = "RemainingPaymentCount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#,##0回";
            dataGridViewCellStyle6.NullValue = null;
            this.loanRemainingPaymentCountColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.loanRemainingPaymentCountColumn.HeaderText = "残回数";
            this.loanRemainingPaymentCountColumn.Name = "loanRemainingPaymentCountColumn";
            this.loanRemainingPaymentCountColumn.ReadOnly = true;
            this.loanRemainingPaymentCountColumn.Width = 75;
            // 
            // loanTotalPaymentAmountColumn
            // 
            this.loanTotalPaymentAmountColumn.DataPropertyName = "TotalPaymentAmount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "#,##0円";
            dataGridViewCellStyle7.NullValue = null;
            this.loanTotalPaymentAmountColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.loanTotalPaymentAmountColumn.HeaderText = "総お支払い額";
            this.loanTotalPaymentAmountColumn.Name = "loanTotalPaymentAmountColumn";
            this.loanTotalPaymentAmountColumn.ReadOnly = true;
            this.loanTotalPaymentAmountColumn.Width = 135;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1344, 841);
            this.Controls.Add(this._shell);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.MinimumSize = new System.Drawing.Size(1080, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ローン管理アプリ";
            this._shell.ResumeLayout(false);
            this._shell.PerformLayout();
            this._toolbar.ResumeLayout(false);
            this._toolbar.PerformLayout();
            this._mainSplit.Panel1.ResumeLayout(false);
            this._mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._mainSplit)).EndInit();
            this._mainSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._loanGrid)).EndInit();
            this._tabs.ResumeLayout(false);
            this._scheduleTab.ResumeLayout(false);
            this._scheduleRoot.ResumeLayout(false);
            this._scheduleRoot.PerformLayout();
            this._scheduleHeader.ResumeLayout(false);
            this._scheduleHeader.PerformLayout();
            this._scheduleTools.ResumeLayout(false);
            this._scheduleTools.PerformLayout();
            this._simulationPanel.ResumeLayout(false);
            this._simulationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._scheduleGrid)).EndInit();
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
        private DataGridViewTextBoxColumn loanNameColumn;
        private DataGridViewTextBoxColumn loanRepaymentTypeColumn;
        private DataGridViewTextBoxColumn loanBonusPaymentColumn;
        private DataGridViewTextBoxColumn loanPrincipalAmountColumn;
        private DataGridViewTextBoxColumn loanAnnualInterestRateColumn;
        private DataGridViewTextBoxColumn loanNextPaymentDateColumn;
        private DataGridViewTextBoxColumn loanNextPaymentAmountColumn;
        private DataGridViewTextBoxColumn loanRemainingBalanceColumn;
        private DataGridViewTextBoxColumn loanRemainingPaymentCountColumn;
        private DataGridViewTextBoxColumn loanTotalPaymentAmountColumn;
    }
}
