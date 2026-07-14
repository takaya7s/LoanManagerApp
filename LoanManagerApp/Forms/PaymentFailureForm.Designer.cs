using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LoanManagerApp.Forms
{
    partial class PaymentFailureForm
    {
        private IContainer components = null;
        private TableLayoutPanel _root;
        private Label _lblDescription;
        private TextBox _txtNote;
        private FlowLayoutPanel _buttons;
        private Button _btnCancel;
        private Button _btnOk;

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
            this._lblDescription = new Label();
            this._txtNote = new TextBox();
            this._buttons = new FlowLayoutPanel();
            this._btnCancel = new Button();
            this._btnOk = new Button();
            this._root.SuspendLayout();
            this._buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // _root
            // 
            this._root.ColumnCount = 1;
            this._root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this._root.Controls.Add(this._lblDescription, 0, 0);
            this._root.Controls.Add(this._txtNote, 0, 1);
            this._root.Controls.Add(this._buttons, 0, 2);
            this._root.Dock = DockStyle.Fill;
            this._root.Location = new Point(0, 0);
            this._root.Name = "_root";
            this._root.Padding = new Padding(12);
            this._root.RowCount = 3;
            this._root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this._root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this._root.Size = new Size(584, 281);
            this._root.TabIndex = 0;
            // 
            // _lblDescription
            // 
            this._lblDescription.AutoSize = true;
            this._lblDescription.Location = new Point(12, 12);
            this._lblDescription.Margin = new Padding(0, 0, 0, 8);
            this._lblDescription.Name = "_lblDescription";
            this._lblDescription.Size = new Size(436, 28);
            this._lblDescription.TabIndex = 0;
            this._lblDescription.Text = "入金失敗に関するメモを入力してください（省略可）。";
            // 
            // _txtNote
            // 
            this._txtNote.Dock = DockStyle.Fill;
            this._txtNote.Location = new Point(15, 51);
            this._txtNote.MaxLength = 1000;
            this._txtNote.Multiline = true;
            this._txtNote.Name = "_txtNote";
            this._txtNote.ScrollBars = ScrollBars.Vertical;
            this._txtNote.Size = new Size(554, 159);
            this._txtNote.TabIndex = 1;
            // 
            // _buttons
            // 
            this._buttons.AutoSize = true;
            this._buttons.Controls.Add(this._btnCancel);
            this._buttons.Controls.Add(this._btnOk);
            this._buttons.Dock = DockStyle.Fill;
            this._buttons.FlowDirection = FlowDirection.RightToLeft;
            this._buttons.Location = new Point(15, 216);
            this._buttons.Name = "_buttons";
            this._buttons.Padding = new Padding(0, 10, 0, 0);
            this._buttons.Size = new Size(554, 50);
            this._buttons.TabIndex = 2;
            // 
            // _btnCancel
            // 
            this._btnCancel.AutoSize = true;
            this._btnCancel.DialogResult = DialogResult.Cancel;
            this._btnCancel.Location = new Point(431, 13);
            this._btnCancel.MinimumSize = new Size(120, 42);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new Size(120, 42);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "キャンセル";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOk
            // 
            this._btnOk.AutoSize = true;
            this._btnOk.DialogResult = DialogResult.OK;
            this._btnOk.Location = new Point(305, 13);
            this._btnOk.MinimumSize = new Size(120, 42);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new Size(120, 42);
            this._btnOk.TabIndex = 0;
            this._btnOk.Text = "登録";
            this._btnOk.UseVisualStyleBackColor = true;
            // 
            // PaymentFailureForm
            // 
            this.AcceptButton = this._btnOk;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new Size(584, 281);
            this.Controls.Add(this._root);
            this.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.MinimumSize = new Size(520, 280);
            this.Name = "PaymentFailureForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "入金失敗を登録";
            this._root.ResumeLayout(false);
            this._root.PerformLayout();
            this._buttons.ResumeLayout(false);
            this._buttons.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
