using System.Drawing;
using System.Windows.Forms;

namespace QuickMsgs
{
    public partial class UserControlAddNewText : UserControl
    {
        private Form1 _form;
        public UserControlAddNewText(Form1 form)
        {
            InitializeComponent();
            _form = form;
            MakeReadOnly();
        }

        private void MakeReadOnly()
        {            
            textBoxNewText.Text = "Double click to add new msg";
            textBoxNewText.ForeColor = Color.DarkGray;
            textBoxNewText.ReadOnly = true;
        }

        private void MakeEditable()
        {
            textBoxNewText.ReadOnly = false;
            textBoxNewText.Text = "";
            textBoxNewText.ForeColor = Color.LimeGreen;
        }

        private void textBoxNewText_MouseDoubleClick(object sender, MouseEventArgs e)
        {            
            MakeEditable();
        }

        private void textBoxNewText_KeyUp(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;
            if(textBox.ReadOnly) return;

            if (e.KeyCode == Keys.Escape)
            {
                MakeReadOnly();
            }

            if (e.KeyCode != Keys.Enter) return;


            var text = textBox.Text.Trim();
            if(text.Length == 0)
            {
                MakeReadOnly();
                return;                
            }

            ClipboardManager.Instance.AddText(text);
            MakeReadOnly();

            _form.AddText(text);
        }
    }
}
