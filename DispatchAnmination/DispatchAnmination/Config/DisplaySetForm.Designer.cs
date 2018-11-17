namespace DispatchAnmination.Config
{
    partial class DisplaySetForm
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
            this.IsShowSiteNameCB = new System.Windows.Forms.CheckBox();
            this.IsShowSiteUpCB = new System.Windows.Forms.CheckBox();
            this.IsShowSitePointCB = new System.Windows.Forms.CheckBox();
            this.IsShowSiteCB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // IsShowSiteNameCB
            // 
            this.IsShowSiteNameCB.AutoSize = true;
            this.IsShowSiteNameCB.Checked = true;
            this.IsShowSiteNameCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsShowSiteNameCB.Location = new System.Drawing.Point(35, 89);
            this.IsShowSiteNameCB.Name = "IsShowSiteNameCB";
            this.IsShowSiteNameCB.Size = new System.Drawing.Size(108, 16);
            this.IsShowSiteNameCB.TabIndex = 0;
            this.IsShowSiteNameCB.Text = "展示正负卡信息";
            this.IsShowSiteNameCB.UseVisualStyleBackColor = true;
            this.IsShowSiteNameCB.CheckedChanged += new System.EventHandler(this.IsShowSiteNameCB_CheckedChanged);
            // 
            // IsShowSiteUpCB
            // 
            this.IsShowSiteUpCB.AutoSize = true;
            this.IsShowSiteUpCB.Checked = true;
            this.IsShowSiteUpCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsShowSiteUpCB.Location = new System.Drawing.Point(35, 130);
            this.IsShowSiteUpCB.Name = "IsShowSiteUpCB";
            this.IsShowSiteUpCB.Size = new System.Drawing.Size(120, 16);
            this.IsShowSiteUpCB.TabIndex = 1;
            this.IsShowSiteUpCB.Text = "展示站点顶部信息";
            this.IsShowSiteUpCB.UseVisualStyleBackColor = true;
            this.IsShowSiteUpCB.CheckedChanged += new System.EventHandler(this.IsShowSiteUpCB_CheckedChanged);
            // 
            // IsShowSitePointCB
            // 
            this.IsShowSitePointCB.AutoSize = true;
            this.IsShowSitePointCB.Checked = true;
            this.IsShowSitePointCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsShowSitePointCB.Location = new System.Drawing.Point(35, 172);
            this.IsShowSitePointCB.Name = "IsShowSitePointCB";
            this.IsShowSitePointCB.Size = new System.Drawing.Size(96, 16);
            this.IsShowSitePointCB.TabIndex = 2;
            this.IsShowSitePointCB.Text = "展示站点坐标";
            this.IsShowSitePointCB.UseVisualStyleBackColor = true;
            this.IsShowSitePointCB.CheckedChanged += new System.EventHandler(this.IsShowSitePointCB_CheckedChanged);
            // 
            // IsShowSiteCB
            // 
            this.IsShowSiteCB.AutoSize = true;
            this.IsShowSiteCB.Checked = true;
            this.IsShowSiteCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsShowSiteCB.Location = new System.Drawing.Point(35, 42);
            this.IsShowSiteCB.Name = "IsShowSiteCB";
            this.IsShowSiteCB.Size = new System.Drawing.Size(96, 16);
            this.IsShowSiteCB.TabIndex = 3;
            this.IsShowSiteCB.Text = "展示站点信息";
            this.IsShowSiteCB.UseVisualStyleBackColor = true;
            this.IsShowSiteCB.CheckedChanged += new System.EventHandler(this.IsShowSiteCB_CheckedChanged);
            // 
            // DisplaySetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 450);
            this.Controls.Add(this.IsShowSiteCB);
            this.Controls.Add(this.IsShowSitePointCB);
            this.Controls.Add(this.IsShowSiteUpCB);
            this.Controls.Add(this.IsShowSiteNameCB);
            this.Name = "DisplaySetForm";
            this.Text = "DisplaySetForm";
            this.Load += new System.EventHandler(this.DisplaySetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox IsShowSiteNameCB;
        private System.Windows.Forms.CheckBox IsShowSiteUpCB;
        private System.Windows.Forms.CheckBox IsShowSitePointCB;
        private System.Windows.Forms.CheckBox IsShowSiteCB;
    }
}