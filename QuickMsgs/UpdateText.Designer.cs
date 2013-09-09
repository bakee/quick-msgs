namespace QuickMsgs
{
    partial class UpdateText
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxNewTextValue = new System.Windows.Forms.TextBox();
            this.labelNewText = new System.Windows.Forms.Label();
            this.labelOldTextValue = new System.Windows.Forms.Label();
            this.labelOldText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(68, 61);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(120, 23);
            this.buttonUpdate.TabIndex = 9;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // textBoxNewTextValue
            // 
            this.textBoxNewTextValue.Location = new System.Drawing.Point(68, 35);
            this.textBoxNewTextValue.MaxLength = 200;
            this.textBoxNewTextValue.Name = "textBoxNewTextValue";
            this.textBoxNewTextValue.Size = new System.Drawing.Size(318, 20);
            this.textBoxNewTextValue.TabIndex = 8;
            // 
            // labelNewText
            // 
            this.labelNewText.AutoSize = true;
            this.labelNewText.Location = new System.Drawing.Point(6, 38);
            this.labelNewText.Name = "labelNewText";
            this.labelNewText.Size = new System.Drawing.Size(56, 13);
            this.labelNewText.TabIndex = 7;
            this.labelNewText.Text = "New Text:";
            // 
            // labelOldTextValue
            // 
            this.labelOldTextValue.AutoSize = true;
            this.labelOldTextValue.Location = new System.Drawing.Point(62, 10);
            this.labelOldTextValue.Name = "labelOldTextValue";
            this.labelOldTextValue.Size = new System.Drawing.Size(0, 13);
            this.labelOldTextValue.TabIndex = 6;
            // 
            // labelOldText
            // 
            this.labelOldText.AutoSize = true;
            this.labelOldText.Location = new System.Drawing.Point(6, 10);
            this.labelOldText.Name = "labelOldText";
            this.labelOldText.Size = new System.Drawing.Size(50, 13);
            this.labelOldText.TabIndex = 5;
            this.labelOldText.Text = "Old Text:";
            // 
            // UpdateText
            // 
            this.AcceptButton = this.buttonUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 97);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.textBoxNewTextValue);
            this.Controls.Add(this.labelNewText);
            this.Controls.Add(this.labelOldTextValue);
            this.Controls.Add(this.labelOldText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdateText";
            this.Text = "Update Text";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxNewTextValue;
        private System.Windows.Forms.Label labelNewText;
        private System.Windows.Forms.Label labelOldTextValue;
        private System.Windows.Forms.Label labelOldText;
    }
}