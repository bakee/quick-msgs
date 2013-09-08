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
        }

        private void textBoxNewText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var textBox = (TextBox) sender;
            textBox.ReadOnly = false;
        }

        private void textBoxNewText_KeyUp(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;
            if(textBox.ReadOnly == true) return;

            if (e.KeyCode == Keys.Escape)
            {
                textBox.Text = "";
                textBox.ReadOnly = true;
                return;
            }

            if (e.KeyCode != Keys.Enter) return;


            var text = textBox.Text.Trim();
            if(text.Length == 0)
            {
                textBox.Text = "";
                textBox.ReadOnly = true;
                return;                
            }

            ClipboardManager.Instance.AddText(text);
            textBox.Text = "";
            textBox.ReadOnly = true;

            _form.AddText(text);
        }
    }
}
