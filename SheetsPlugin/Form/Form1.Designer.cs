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
            this.DuplicateViewsDataGridView = new System.Windows.Forms.DataGridView();
            this.ColCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DuplicateViewsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DuplicateViewsDataGridView
            // 
            this.DuplicateViewsDataGridView.AllowUserToAddRows = false;
            this.DuplicateViewsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DuplicateViewsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCheck});
            this.DuplicateViewsDataGridView.Location = new System.Drawing.Point(122, 77);
            this.DuplicateViewsDataGridView.Name = "DuplicateViewsDataGridView";
            this.DuplicateViewsDataGridView.RowHeadersWidth = 51;
            this.DuplicateViewsDataGridView.RowTemplate.Height = 24;
            this.DuplicateViewsDataGridView.Size = new System.Drawing.Size(297, 200);
            this.DuplicateViewsDataGridView.TabIndex = 0;
            // 
            // ColCheck
            // 
            this.ColCheck.HeaderText = "";
            this.ColCheck.MinimumWidth = 6;
            this.ColCheck.Name = "ColCheck";
            this.ColCheck.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 338);
            this.Controls.Add(this.DuplicateViewsDataGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DuplicateViewsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DuplicateViewsDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCheck;
    }
}