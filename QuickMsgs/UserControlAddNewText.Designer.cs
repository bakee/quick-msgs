namespace QuickMsgs
{
    partial class UserControlAddNewText
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxNewText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxNewText
            // 
            this.textBoxNewText.Location = new System.Drawing.Point(12, 16);
            this.textBoxNewText.MaxLength = 200;
            this.textBoxNewText.Name = "textBoxNewText";
            this.textBoxNewText.ReadOnly = true;
            this.textBoxNewText.Size = new System.Drawing.Size(324, 20);
            this.textBoxNewText.TabIndex = 0;
            this.textBoxNewText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxNewText_KeyUp);
            this.textBoxNewText.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxNewText_MouseDoubleClick);
            // 
            // UserControlAddNewText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.textBoxNewText);
            this.Name = "UserControlAddNewText";
            this.Size = new System.Drawing.Size(348, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNewText;
    }
}
