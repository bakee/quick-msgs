using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuickMsgs
{
    public partial class Form1 : Form
    {
        private int _position;
        private bool _isExitRequested;
        private bool _isHidden;

        public Form1()
        {
            InitializeComponent();
            _isExitRequested = false;
        }

        private void Form1Load(object sender, EventArgs e)
        {
            RefreshCopiedTexts();
        }

        public void RefreshCopiedTexts()
        {
            var allTexts = ClipboardManager.Instance.GetAllTexts();
            _position = 10;
            panelBottom.Controls.Clear();
            foreach (var text in allTexts)
            {
                var control = new UserControlCopiedText(text, this) {Location = new Point(10, _position)};
                _position += 55;
                panelBottom.Controls.Add(control);
            }

            var userControlAddNewText = new UserControlAddNewText(this) {Location = new Point(10, _position)};
            panelBottom.Controls.Add(userControlAddNewText);            
        }

        public void AddText(string text)
        {
            RefreshCopiedTexts();
            UpdateStatus("New msg added");
        }

        public void DeleteText(string text)
        {
            if (panelBottom.Controls.Count > 1)
                for (int index = 0; index < panelBottom.Controls.Count - 1; index++)
                {
                    var userControlCopiedText = (UserControlCopiedText) panelBottom.Controls[index];
                    if (text == userControlCopiedText.GetText())
                    {
                        ClipboardManager.Instance.DeleteText(text);
                        panelBottom.Controls.Remove(userControlCopiedText);
                    }
                }

            RefreshCopiedTexts();
            UpdateStatus("msg deleted");
        }

        public void UpdateStatus(string text)
        {
            toolStripStatusLabel1.Text = text;
        }

        private void Form1FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!_isExitRequested)
            {
                Hide();
                _isHidden = true;
                e.Cancel = true;
            }
            else
            {
                if (MessageBox.Show("This will close the application. Are you sure to do that ?", "Exit Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    _isExitRequested = false;
                    e.Cancel = true;
                }
            }
        }

        private void ShowHideToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (_isHidden)
            {
                Show();
                _isHidden = false;
            }
            else
            {
                Hide();
                _isHidden = true;
            }
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            _isExitRequested = true;
            Close();
        }

        private void NotifyIcon1MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_isHidden)
            {
                Show();
                _isHidden = false;
            }
        }
    }
}