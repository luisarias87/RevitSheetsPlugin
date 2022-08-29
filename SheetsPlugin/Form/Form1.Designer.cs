namespace SheetsPlugin.Form
{
    partial class Form1
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
            this.BtnSheets = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnSheets
            // 
            this.BtnSheets.Location = new System.Drawing.Point(124, 128);
            this.BtnSheets.Name = "BtnSheets";
            this.BtnSheets.Size = new System.Drawing.Size(202, 68);
            this.BtnSheets.TabIndex = 0;
            this.BtnSheets.Text = "Sheets Test";
            this.BtnSheets.UseVisualStyleBackColor = true;
            this.BtnSheets.Click += new System.EventHandler(this.BtnSheets_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 338);
            this.Controls.Add(this.BtnSheets);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSheets;
    }
}