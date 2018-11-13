namespace DispatchAnmination
{
    partial class AnminationForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnminationForm));
            this.anminationPicBox = new System.Windows.Forms.PictureBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.anminateTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.anminationPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // anminationPicBox
            // 
            this.anminationPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.anminationPicBox.Location = new System.Drawing.Point(0, 0);
            this.anminationPicBox.Name = "anminationPicBox";
            this.anminationPicBox.Size = new System.Drawing.Size(984, 761);
            this.anminationPicBox.TabIndex = 0;
            this.anminationPicBox.TabStop = false;
            this.anminationPicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.anmination_picBox_Paint);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "icon.ico");
            this.imageList.Images.SetKeyName(1, "agv_car.png");
            this.imageList.Images.SetKeyName(2, "agv_load.png");
            this.imageList.Images.SetKeyName(3, "car.png");
            // 
            // anminateTimer
            // 
            this.anminateTimer.Enabled = true;
            this.anminateTimer.Interval = 50;
            this.anminateTimer.Tick += new System.EventHandler(this.anminateTimer_Tick);
            // 
            // AnminationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.anminationPicBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnminationForm";
            this.Text = "DispatchAnmination";
            this.Load += new System.EventHandler(this.AnminationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.anminationPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox anminationPicBox;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Timer anminateTimer;
    }
}

