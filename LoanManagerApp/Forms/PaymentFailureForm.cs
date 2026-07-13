using System.Drawing;
using System.Windows.Forms;

namespace LoanManagerApp.Forms
{
    public sealed class PaymentFailureForm : Form
    {
        private readonly TextBox _txtNote;

        public string FailureNote
        {
            get { return _txtNote.Text.Trim(); }
        }

        public PaymentFailureForm(string currentNote)
        {
            Text = "入金失敗を登録";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(600, 320);
            MinimumSize = new Size(520, 280);
            Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);

            TableLayoutPanel root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(12),
                RowCount = 3,
                ColumnCount = 1
            };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            Controls.Add(root);

            root.Controls.Add(new Label
            {
                Text = "入金失敗に関するメモを入力してください（省略可）。",
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 8)
            }, 0, 0);

            _txtNote = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                MaxLength = 1000,
                Text = currentNote ?? string.Empty
            };
            root.Controls.Add(_txtNote, 0, 1);

            FlowLayoutPanel buttons = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(0, 10, 0, 0)
            };
            Button cancel = new Button
            {
                Text = "キャンセル",
                DialogResult = DialogResult.Cancel,
                AutoSize = true,
                MinimumSize = new Size(120, 42)
            };
            Button ok = new Button
            {
                Text = "登録",
                DialogResult = DialogResult.OK,
                AutoSize = true,
                MinimumSize = new Size(120, 42)
            };
            buttons.Controls.Add(cancel);
            buttons.Controls.Add(ok);
            root.Controls.Add(buttons, 0, 2);
            AcceptButton = ok;
            CancelButton = cancel;
        }
    }
}
