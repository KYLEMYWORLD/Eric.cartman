namespace KDTask
{
    partial class KDForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KDForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolDevBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolDevdefItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDevaddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDevstatusItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCodedefItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCodeanyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTaskBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolTaskdefItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTasklogicItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDevBtn,
            this.toolStripSeparator1,
            this.toolTaskBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolDevBtn
            // 
            this.toolDevBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDevdefItem,
            this.toolDevaddItem,
            this.toolDevstatusItem,
            this.toolCodedefItem,
            this.toolCodeanyItem});
            this.toolDevBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolDevBtn.Image")));
            this.toolDevBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDevBtn.Name = "toolDevBtn";
            this.toolDevBtn.Size = new System.Drawing.Size(85, 22);
            this.toolDevBtn.Text = "设备管理";
            // 
            // toolDevdefItem
            // 
            this.toolDevdefItem.Name = "toolDevdefItem";
            this.toolDevdefItem.Size = new System.Drawing.Size(180, 22);
            this.toolDevdefItem.Text = "设备定义";
            this.toolDevdefItem.Click += new System.EventHandler(this.ToolDevdefItem_Click);
            // 
            // toolDevaddItem
            // 
            this.toolDevaddItem.Name = "toolDevaddItem";
            this.toolDevaddItem.Size = new System.Drawing.Size(180, 22);
            this.toolDevaddItem.Text = "设备添加";
            this.toolDevaddItem.Click += new System.EventHandler(this.ToolDevaddItem_Click);
            // 
            // toolDevstatusItem
            // 
            this.toolDevstatusItem.Name = "toolDevstatusItem";
            this.toolDevstatusItem.Size = new System.Drawing.Size(180, 22);
            this.toolDevstatusItem.Text = "设备属性";
            // 
            // toolCodedefItem
            // 
            this.toolCodedefItem.Name = "toolCodedefItem";
            this.toolCodedefItem.Size = new System.Drawing.Size(180, 22);
            this.toolCodedefItem.Text = "指令定义";
            // 
            // toolCodeanyItem
            // 
            this.toolCodeanyItem.Name = "toolCodeanyItem";
            this.toolCodeanyItem.Size = new System.Drawing.Size(180, 22);
            this.toolCodeanyItem.Text = "指令解析";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolTaskBtn
            // 
            this.toolTaskBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTaskdefItem,
            this.toolTasklogicItem});
            this.toolTaskBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolTaskBtn.Image")));
            this.toolTaskBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTaskBtn.Name = "toolTaskBtn";
            this.toolTaskBtn.Size = new System.Drawing.Size(85, 22);
            this.toolTaskBtn.Text = "任务管理";
            // 
            // toolTaskdefItem
            // 
            this.toolTaskdefItem.Name = "toolTaskdefItem";
            this.toolTaskdefItem.Size = new System.Drawing.Size(124, 22);
            this.toolTaskdefItem.Text = "任务定义";
            // 
            // toolTasklogicItem
            // 
            this.toolTasklogicItem.Name = "toolTasklogicItem";
            this.toolTasklogicItem.Size = new System.Drawing.Size(124, 22);
            this.toolTasklogicItem.Text = "任务逻辑";
            // 
            // KDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Name = "KDForm";
            this.Text = "KD任务控制系统";
            this.Load += new System.EventHandler(this.KDForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolTaskBtn;
        private System.Windows.Forms.ToolStripMenuItem toolTaskdefItem;
        private System.Windows.Forms.ToolStripDropDownButton toolDevBtn;
        private System.Windows.Forms.ToolStripMenuItem toolDevdefItem;
        private System.Windows.Forms.ToolStripMenuItem toolDevaddItem;
        private System.Windows.Forms.ToolStripMenuItem toolDevstatusItem;
        private System.Windows.Forms.ToolStripMenuItem toolCodedefItem;
        private System.Windows.Forms.ToolStripMenuItem toolCodeanyItem;
        private System.Windows.Forms.ToolStripMenuItem toolTasklogicItem;
    }
}

