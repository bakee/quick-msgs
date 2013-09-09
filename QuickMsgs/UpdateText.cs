using System;
using System.Windows.Forms;

namespace QuickMsgs
{
    public partial class UpdateText : Form
    {
        public UpdateText(String oldText)
        {
            InitializeComponent();
            labelOldTextValue.Text = oldText;
            textBoxNewTextValue.Text = oldText;
            textBoxNewTextValue.MaxLength = Constants.MaximumMessageLength;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string text = textBoxNewTextValue.Text.Trim();
            if (labelOldTextValue.Text != text)
            {
                ClipboardManager.Instance.UpdateText(labelOldTextValue.Text, text);
            }

            Close();
        }
    }
}
