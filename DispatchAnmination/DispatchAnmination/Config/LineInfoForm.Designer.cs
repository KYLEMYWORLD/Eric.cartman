namespace DispatchAnmination
{
    partial class LineInfoForm
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
            this.LineInfoListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // LineInfoListView
            // 
            this.LineInfoListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineInfoListView.GridLines = true;
            this.LineInfoListView.Location = new System.Drawing.Point(0, 0);
            this.LineInfoListView.Name = "LineInfoListView";
            this.LineInfoListView.Size = new System.Drawing.Size(698, 542);
            this.LineInfoListView.TabIndex = 1;
            this.LineInfoListView.UseCompatibleStateImageBehavior = false;
            this.LineInfoListView.View = System.Windows.Forms.View.Details;
            // 
            // LineInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 542);
            this.Controls.Add(this.LineInfoListView);
            this.Name = "LineInfoForm";
            this.Text = "线路信息";
            this.Load += new System.EventHandler(this.LineInfoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView LineInfoListView;
    }
}