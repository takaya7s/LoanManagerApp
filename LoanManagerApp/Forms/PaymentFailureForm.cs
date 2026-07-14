using System.ComponentModel;
using System.Windows.Forms;

namespace LoanManagerApp.Forms
{
    [DesignerCategory("Form")]
    public sealed partial class PaymentFailureForm : Form
    {
        public string FailureNote
        {
            get { return _txtNote.Text.Trim(); }
        }

        // Visual Studioデザイナー用。
        public PaymentFailureForm()
        {
            InitializeComponent();
        }

        public PaymentFailureForm(string currentNote)
            : this()
        {
            _txtNote.Text = currentNote ?? string.Empty;
        }
    }
}
