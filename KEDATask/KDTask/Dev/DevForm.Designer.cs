namespace KDTask
{
    partial class DevForm
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
            this.devListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.devIdTB = new System.Windows.Forms.TextBox();
            this.devNameTB = new System.Windows.Forms.TextBox();
            this.devtypeCB = new System.Windows.Forms.ComboBox();
            this.devAddEditBtn = new System.Windows.Forms.Button();
            this.addDevBtn = new System.Windows.Forms.Button();
            this.devDefCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.devIPTB = new System.Windows.Forms.TextBox();
            this.devPortTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.devTestConBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // devListView
            // 
            this.devListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.devListView.BackColor = System.Drawing.SystemColors.Window;
            this.devListView.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.devListView.FullRowSelect = true;
            this.devListView.GridLines = true;
            this.devListView.Location = new System.Drawing.Point(2, 41);
            this.devListView.MultiSelect = false;
            this.devListView.Name = "devListView";
            this.devListView.Size = new System.Drawing.Size(243, 464);
            this.devListView.TabIndex = 0;
            this.devListView.UseCompatibleStateImageBehavior = false;
            this.devListView.View = System.Windows.Forms.View.List;
            this.devListView.SelectedIndexChanged += new System.EventHandler(this.DevListView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(302, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "设备ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(302, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "设备名称:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(302, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "设备类型:";
            // 
            // devIdTB
            // 
            this.devIdTB.Location = new System.Drawing.Point(407, 97);
            this.devIdTB.Name = "devIdTB";
            this.devIdTB.Size = new System.Drawing.Size(121, 21);
            this.devIdTB.TabIndex = 2;
            // 
            // devNameTB
            // 
            this.devNameTB.Location = new System.Drawing.Point(407, 141);
            this.devNameTB.Name = "devNameTB";
            this.devNameTB.Size = new System.Drawing.Size(121, 21);
            this.devNameTB.TabIndex = 3;
            // 
            // devtypeCB
            // 
            this.devtypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devtypeCB.FormattingEnabled = true;
            this.devtypeCB.Location = new System.Drawing.Point(407, 49);
            this.devtypeCB.Name = "devtypeCB";
            this.devtypeCB.Size = new System.Drawing.Size(121, 20);
            this.devtypeCB.TabIndex = 1;
            // 
            // devAddEditBtn
            // 
            this.devAddEditBtn.Location = new System.Drawing.Point(407, 410);
            this.devAddEditBtn.Name = "devAddEditBtn";
            this.devAddEditBtn.Size = new System.Drawing.Size(121, 32);
            this.devAddEditBtn.TabIndex = 6;
            this.devAddEditBtn.Text = "修改";
            this.devAddEditBtn.UseVisualStyleBackColor = true;
            this.devAddEditBtn.Click += new System.EventHandler(this.DevDefAddEditBtn_Click);
            // 
            // addDevBtn
            // 
            this.addDevBtn.Location = new System.Drawing.Point(588, 15);
            this.addDevBtn.Name = "addDevBtn";
            this.addDevBtn.Size = new System.Drawing.Size(93, 38);
            this.addDevBtn.TabIndex = 7;
            this.addDevBtn.Text = "添加设备";
            this.addDevBtn.UseVisualStyleBackColor = true;
            this.addDevBtn.Click += new System.EventHandler(this.AddDevBtn_Click);
            // 
            // devDefCB
            // 
            this.devDefCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devDefCB.FormattingEnabled = true;
            this.devDefCB.Location = new System.Drawing.Point(12, 12);
            this.devDefCB.Name = "devDefCB";
            this.devDefCB.Size = new System.Drawing.Size(127, 20);
            this.devDefCB.TabIndex = 8;
            this.devDefCB.SelectedIndexChanged += new System.EventHandler(this.DevDefCB_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(304, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "IP:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(304, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "端口:";
            // 
            // devIPTB
            // 
            this.devIPTB.Location = new System.Drawing.Point(407, 269);
            this.devIPTB.Name = "devIPTB";
            this.devIPTB.Size = new System.Drawing.Size(121, 21);
            this.devIPTB.TabIndex = 4;
            // 
            // devPortTB
            // 
            this.devPortTB.Location = new System.Drawing.Point(407, 320);
            this.devPortTB.Name = "devPortTB";
            this.devPortTB.Size = new System.Drawing.Size(121, 21);
            this.devPortTB.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(304, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "设备连接信息";
            // 
            // devTestConBtn
            // 
            this.devTestConBtn.Location = new System.Drawing.Point(588, 269);
            this.devTestConBtn.Name = "devTestConBtn";
            this.devTestConBtn.Size = new System.Drawing.Size(75, 72);
            this.devTestConBtn.TabIndex = 15;
            this.devTestConBtn.Text = "测试连接";
            this.devTestConBtn.UseVisualStyleBackColor = true;
            this.devTestConBtn.Click += new System.EventHandler(this.devTestConBtn_Click);
            // 
            // DevForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 506);
            this.Controls.Add(this.devTestConBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.devPortTB);
            this.Controls.Add(this.devIPTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.devDefCB);
            this.Controls.Add(this.addDevBtn);
            this.Controls.Add(this.devAddEditBtn);
            this.Controls.Add(this.devtypeCB);
            this.Controls.Add(this.devNameTB);
            this.Controls.Add(this.devIdTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.devListView);
            this.MinimizeBox = false;
            this.Name = "DevForm";
            this.Text = "设备添加";
            this.Load += new System.EventHandler(this.DevForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView devListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox devIdTB;
        private System.Windows.Forms.TextBox devNameTB;
        private System.Windows.Forms.ComboBox devtypeCB;
        private System.Windows.Forms.Button devAddEditBtn;
        private System.Windows.Forms.Button addDevBtn;
        private System.Windows.Forms.ComboBox devDefCB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox devIPTB;
        private System.Windows.Forms.TextBox devPortTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button devTestConBtn;
    }
}