namespace DispatchAnmination.MapConfig
{
    partial class MapConfigForm
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
            this.components = new System.ComponentModel.Container();
            this.MapConfigPB = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AddNewLineBtn = new System.Windows.Forms.Button();
            this.MapTimer = new System.Windows.Forms.Timer(this.components);
            this.AddNewSiteBtn = new System.Windows.Forms.Button();
            this.SiteIDTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SiteRateTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SiteDirecationCB = new System.Windows.Forms.ComboBox();
            this.SiteTypeCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SiteNameTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SiteUpNameTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MapConfigPB)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapConfigPB
            // 
            this.MapConfigPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapConfigPB.Location = new System.Drawing.Point(0, 0);
            this.MapConfigPB.Name = "MapConfigPB";
            this.MapConfigPB.Size = new System.Drawing.Size(965, 546);
            this.MapConfigPB.TabIndex = 0;
            this.MapConfigPB.TabStop = false;
            this.MapConfigPB.Paint += new System.Windows.Forms.PaintEventHandler(this.MapConfigPB_Paint);
            this.MapConfigPB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapConfigPB_MouseDown);
            this.MapConfigPB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapConfigPB_MouseMove);
            this.MapConfigPB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapConfigPB_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SiteUpNameTB);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.SiteNameTB);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.SiteTypeCB);
            this.panel1.Controls.Add(this.SiteDirecationCB);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.SiteRateTB);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SiteIDTB);
            this.panel1.Controls.Add(this.AddNewSiteBtn);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.AddNewLineBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 546);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 257);
            this.panel1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(429, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(497, 87);
            this.textBox1.TabIndex = 3;
            // 
            // AddNewLineBtn
            // 
            this.AddNewLineBtn.Location = new System.Drawing.Point(12, 4);
            this.AddNewLineBtn.Name = "AddNewLineBtn";
            this.AddNewLineBtn.Size = new System.Drawing.Size(75, 23);
            this.AddNewLineBtn.TabIndex = 2;
            this.AddNewLineBtn.Text = "添加线路";
            this.AddNewLineBtn.UseVisualStyleBackColor = true;
            this.AddNewLineBtn.Click += new System.EventHandler(this.AddNewLineBtn_Click);
            // 
            // MapTimer
            // 
            this.MapTimer.Enabled = true;
            this.MapTimer.Interval = 1000;
            this.MapTimer.Tick += new System.EventHandler(this.MapTimer_Tick);
            // 
            // AddNewSiteBtn
            // 
            this.AddNewSiteBtn.Location = new System.Drawing.Point(12, 33);
            this.AddNewSiteBtn.Name = "AddNewSiteBtn";
            this.AddNewSiteBtn.Size = new System.Drawing.Size(75, 23);
            this.AddNewSiteBtn.TabIndex = 4;
            this.AddNewSiteBtn.Text = "添加站点";
            this.AddNewSiteBtn.UseVisualStyleBackColor = true;
            this.AddNewSiteBtn.Click += new System.EventHandler(this.AddNewSiteBtn_Click);
            // 
            // SiteIDTB
            // 
            this.SiteIDTB.Location = new System.Drawing.Point(61, 62);
            this.SiteIDTB.Name = "SiteIDTB";
            this.SiteIDTB.Size = new System.Drawing.Size(121, 21);
            this.SiteIDTB.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "rate";
            // 
            // SiteRateTB
            // 
            this.SiteRateTB.Location = new System.Drawing.Point(61, 94);
            this.SiteRateTB.Name = "SiteRateTB";
            this.SiteRateTB.Size = new System.Drawing.Size(121, 21);
            this.SiteRateTB.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "dire";
            // 
            // SiteDirecationCB
            // 
            this.SiteDirecationCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SiteDirecationCB.FormattingEnabled = true;
            this.SiteDirecationCB.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.SiteDirecationCB.Location = new System.Drawing.Point(61, 128);
            this.SiteDirecationCB.Name = "SiteDirecationCB";
            this.SiteDirecationCB.Size = new System.Drawing.Size(121, 20);
            this.SiteDirecationCB.TabIndex = 10;
            // 
            // SiteTypeCB
            // 
            this.SiteTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SiteTypeCB.FormattingEnabled = true;
            this.SiteTypeCB.Items.AddRange(new object[] {
            "0 窑头窑尾",
            "1 等待点",
            "2 转弯点",
            "3 掉头点",
            "4 充电点",
            "5 交通管制点",
            "6 非交通管制点"});
            this.SiteTypeCB.Location = new System.Drawing.Point(61, 158);
            this.SiteTypeCB.Name = "SiteTypeCB";
            this.SiteTypeCB.Size = new System.Drawing.Size(121, 20);
            this.SiteTypeCB.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "type";
            // 
            // SiteNameTB
            // 
            this.SiteNameTB.Location = new System.Drawing.Point(61, 188);
            this.SiteNameTB.Name = "SiteNameTB";
            this.SiteNameTB.Size = new System.Drawing.Size(121, 21);
            this.SiteNameTB.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "upname";
            // 
            // SiteUpNameTB
            // 
            this.SiteUpNameTB.Location = new System.Drawing.Point(61, 233);
            this.SiteUpNameTB.Name = "SiteUpNameTB";
            this.SiteUpNameTB.Size = new System.Drawing.Size(121, 21);
            this.SiteUpNameTB.TabIndex = 16;
            // 
            // MapConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 803);
            this.Controls.Add(this.MapConfigPB);
            this.Controls.Add(this.panel1);
            this.Name = "MapConfigForm";
            this.Text = "地图配置";
            ((System.ComponentModel.ISupportInitialize)(this.MapConfigPB)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MapConfigPB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddNewLineBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer MapTimer;
        private System.Windows.Forms.Button AddNewSiteBtn;
        private System.Windows.Forms.TextBox SiteIDTB;
        private System.Windows.Forms.TextBox SiteRateTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SiteNameTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SiteTypeCB;
        private System.Windows.Forms.ComboBox SiteDirecationCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SiteUpNameTB;
        private System.Windows.Forms.Label label6;
    }
}