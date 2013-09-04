using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
