﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuickMsgs
{
    public class ClipboardManager
    {
        private static ClipboardManager _instance = null;

        public static ClipboardManager Instance
        {
            get { return _instance ?? (_instance = new ClipboardManager()); }
        }

        private readonly string _dataFilePath;
        private readonly XDocument _document;
        
        private const string NodeName = "CBT";

        private ClipboardManager()
        {                        
            _dataFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Data.xml");
            _document = XDocument.Load(_dataFilePath);
        }

        private bool IsTextExists(string text)
        {
            var cbts = _document.Root.Descendants();

            return (from c in cbts where c.Value == text select c).Any();
        }

        public void AddText(string text)
        {
            text = text.Trim();

            if (IsTextExists(text)) return;            
            
            var element = new XElement(NodeName) {Value = text};

            var rootElement = _document.Root;
            rootElement.AddFirst(element);
           _document.Save(_dataFilePath);
        }

        public void UpdateText(string oldText, string newText)
        {
            oldText = oldText.Trim();
            newText = newText.Trim();

            if (!IsTextExists(oldText)) return;

            if (IsTextExists(newText))
            {
                DeleteText(oldText);
            }
            else
            {
                var element = (from e in _document.Root.Descendants() where e.Value == oldText select e).FirstOrDefault();
                element.Value = newText;
                _document.Save(_dataFilePath);
            }
        }

        public void DeleteText(string text)
        {
            text = text.Trim();
            if (!IsTextExists(text)) return;

            var xElements = _document.Root.Descendants();
            var element = (from e in xElements where e.Value == text select e).FirstOrDefault();
            element.Remove();
            _document.Save(_dataFilePath);
        }

        public bool CopyText(string text)
        {
            try
            {
                Clipboard.SetText(text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<string> GetAllTexts()
        {
            var cbts = _document.Root.Descendants();
            return (from c in cbts select c.Value.Trim()).ToList();
        }
    }
}