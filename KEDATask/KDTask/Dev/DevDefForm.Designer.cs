namespace KDTask
{
    partial class DevDefForm
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
            this.devNetCB = new System.Windows.Forms.ComboBox();
            this.devDefAddEditBtn = new System.Windows.Forms.Button();
            this.addDevBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // devListView
            // 
            this.devListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.devListView.BackColor = System.Drawing.SystemColors.Window;
            this.devListView.Dock = System.Windows.Forms.DockStyle.Left;
            this.devListView.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.devListView.FullRowSelect = true;
            this.devListView.GridLines = true;
            this.devListView.Location = new System.Drawing.Point(0, 0);
            this.devListView.MultiSelect = false;
            this.devListView.Name = "devListView";
            this.devListView.Size = new System.Drawing.Size(136, 450);
            this.devListView.TabIndex = 0;
            this.devListView.UseCompatibleStateImageBehavior = false;
            this.devListView.View = System.Windows.Forms.View.List;
            this.devListView.SelectedIndexChanged += new System.EventHandler(this.DevListView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "设备ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "设备名称:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "通讯类型:";
            // 
            // devIdTB
            // 
            this.devIdTB.Location = new System.Drawing.Point(284, 157);
            this.devIdTB.Name = "devIdTB";
            this.devIdTB.Size = new System.Drawing.Size(121, 21);
            this.devIdTB.TabIndex = 4;
            // 
            // devNameTB
            // 
            this.devNameTB.Location = new System.Drawing.Point(284, 216);
            this.devNameTB.Name = "devNameTB";
            this.devNameTB.Size = new System.Drawing.Size(121, 21);
            this.devNameTB.TabIndex = 5;
            // 
            // devNetCB
            // 
            this.devNetCB.FormattingEnabled = true;
            this.devNetCB.Items.AddRange(new object[] {
            "客户端",
            "服务端"});
            this.devNetCB.Location = new System.Drawing.Point(284, 272);
            this.devNetCB.Name = "devNetCB";
            this.devNetCB.Size = new System.Drawing.Size(121, 20);
            this.devNetCB.TabIndex = 6;
            // 
            // devDefAddEditBtn
            // 
            this.devDefAddEditBtn.Location = new System.Drawing.Point(284, 349);
            this.devDefAddEditBtn.Name = "devDefAddEditBtn";
            this.devDefAddEditBtn.Size = new System.Drawing.Size(121, 32);
            this.devDefAddEditBtn.TabIndex = 7;
            this.devDefAddEditBtn.Text = "修改";
            this.devDefAddEditBtn.UseVisualStyleBackColor = true;
            this.devDefAddEditBtn.Click += new System.EventHandler(this.DevDefAddEditBtn_Click);
            // 
            // addDevBtn
            // 
            this.addDevBtn.Location = new System.Drawing.Point(179, 55);
            this.addDevBtn.Name = "addDevBtn";
            this.addDevBtn.Size = new System.Drawing.Size(75, 23);
            this.addDevBtn.TabIndex = 8;
            this.addDevBtn.Text = "添加设备";
            this.addDevBtn.UseVisualStyleBackColor = true;
            this.addDevBtn.Click += new System.EventHandler(this.AddDevBtn_Click);
            // 
            // DevDefForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 450);
            this.Controls.Add(this.addDevBtn);
            this.Controls.Add(this.devDefAddEditBtn);
            this.Controls.Add(this.devNetCB);
            this.Controls.Add(this.devNameTB);
            this.Controls.Add(this.devIdTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.devListView);
            this.MinimizeBox = false;
            this.Name = "DevDefForm";
            this.Text = "设备定义";
            this.Load += new System.EventHandler(this.DevDefForm_Load);
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
        private System.Windows.Forms.ComboBox devNetCB;
        private System.Windows.Forms.Button devDefAddEditBtn;
        private System.Windows.Forms.Button addDevBtn;
    }
}