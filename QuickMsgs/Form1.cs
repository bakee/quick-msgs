﻿using System;
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
                var control = new UserControlCopiedText(text, this) {Location = new Point(10, _position)};
                _position += 55;
                panelBottom.Controls.Add(control);
            }
        }

        public void AddText(string text)
        {
            var control = new UserControlCopiedText(text, this) {Location = new Point(10, _position)};
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

        private void Form1FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!_isExitRequested)
            {
                Hide();
                _isHidden = true;
                e.Cancel = true;
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