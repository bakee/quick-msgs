using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuickMsgs
{
    public partial class UserControlCopiedText : UserControl
    {
        private Form1 _form1;

        public UserControlCopiedText(string text, Form1 form1)
        {
            InitializeComponent();
            labelCopiedText.Text = text;            
            timer1.Stop();
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            BackColor = Color.White;
            _form1 = form1;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (BackColor == Color.YellowGreen)
            {
                BackColor = Color.Teal;
            }
            else if (BackColor == Color.Teal)
            {
                BackColor = Color.Violet;
            }
            else if (BackColor == Color.Violet)
            {
                timer1.Stop();
                BackColor = Color.White;
                _form1.UpdateStatus("Ready");
            }
        }

        private void labelCopiedText_Click(object sender, EventArgs e)
        {
            var label = (Label) sender;
            var text = label.Text;
            if(!ClipboardManager.Instance.CopyText(text))
            {
                _form1.UpdateStatus("Could not copy!");
                return;
            }

            BackColor = Color.YellowGreen;
            timer1.Start();

            _form1.UpdateStatus("Text copied!");
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var updateWindow = new UpdateText(labelCopiedText.Text);
            updateWindow.ShowDialog();
            _form1.RefreshCopiedTexts();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _form1.DeleteText(labelCopiedText.Text);
        }

        public string GetText()
        {
            return labelCopiedText.Text;
        }
    }
}
