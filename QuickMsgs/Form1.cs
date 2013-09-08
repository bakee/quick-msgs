using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuickMsgs
{
    public partial class Form1 : Form
    {
        private int _position;
        private bool _isWindowShown;
        private bool _isExitRequested;
        private bool _isHidden;

        public Form1()
        {
            InitializeComponent();
            _isWindowShown = true;
            _isExitRequested = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelTop.Controls.Clear();
            panelTop.Controls.Add(new UserControlAddNewText(this));
            RefreshCopiedTexts();
        }

        public void RefreshCopiedTexts()
        {
            var allTexts = ClipboardManager.Instance.GetAllTexts();
            _position = 10;
            panelBottom.Controls.Clear();
            foreach (var text in allTexts)
            {
                var control = new UserControlCopiedText(text, this);
                control.Location = new Point(10, _position);
                _position += 55;
                panelBottom.Controls.Add(control);
            }
        }

        public void AddText(string text)
        {
            var control = new UserControlCopiedText(text, this);
            control.Location = new Point(10, _position);
            _position += 55;
            panelBottom.Controls.Add(control);
        }

        public void DeleteText(string text)
        {
            if (panelBottom.Controls.Count > 0)
                foreach (UserControlCopiedText userControlCopiedText in panelBottom.Controls)
                    if (text == userControlCopiedText.GetText())
                    {
                        ClipboardManager.Instance.DeleteText(text);
                        panelBottom.Controls.Remove(userControlCopiedText);
                    }

            RefreshCopiedTexts();
        }

        public void UpdateStatus(string text)
        {
            toolStripStatusLabel1.Text = text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!_isExitRequested)
            {
                this.Hide();
                _isHidden = true;
                e.Cancel = true;
            }
        }

        private void showHideToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isExitRequested = true;
            Close();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_isHidden)
            {
                Show();
                _isHidden = false;
            }
        }
    }
}
