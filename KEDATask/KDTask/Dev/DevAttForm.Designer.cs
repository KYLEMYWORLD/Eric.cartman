namespace KDTask
{
    partial class DevAttForm
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
            this.DevAttListView = new System.Windows.Forms.ListView();
            this.DevAttAddEditBtn = new System.Windows.Forms.Button();
            this.addDevAttBtn = new System.Windows.Forms.Button();
            this.devDefCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DevAttIDTB = new System.Windows.Forms.TextBox();
            this.DevAttNameTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AttDicListView = new System.Windows.Forms.ListView();
            this.AttDicAddEditBtn = new System.Windows.Forms.Button();
            this.AttDicAddBtn = new System.Windows.Forms.Button();
            this.AttDicKeyTB = new System.Windows.Forms.TextBox();
            this.AttDicVaueTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DevAttListView
            // 
            this.DevAttListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.DevAttListView.BackColor = System.Drawing.SystemColors.Window;
            this.DevAttListView.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DevAttListView.FullRowSelect = true;
            this.DevAttListView.GridLines = true;
            this.DevAttListView.Location = new System.Drawing.Point(2, 41);
            this.DevAttListView.MultiSelect = false;
            this.DevAttListView.Name = "DevAttListView";
            this.DevAttListView.Size = new System.Drawing.Size(153, 464);
            this.DevAttListView.TabIndex = 0;
            this.DevAttListView.UseCompatibleStateImageBehavior = false;
            this.DevAttListView.View = System.Windows.Forms.View.Details;
            this.DevAttListView.SelectedIndexChanged += new System.EventHandler(this.DevAttListView_SelectedIndexChanged);
            // 
            // DevAttAddEditBtn
            // 
            this.DevAttAddEditBtn.Location = new System.Drawing.Point(180, 365);
            this.DevAttAddEditBtn.Name = "DevAttAddEditBtn";
            this.DevAttAddEditBtn.Size = new System.Drawing.Size(121, 32);
            this.DevAttAddEditBtn.TabIndex = 6;
            this.DevAttAddEditBtn.Text = "修改";
            this.DevAttAddEditBtn.UseVisualStyleBackColor = true;
            this.DevAttAddEditBtn.Click += new System.EventHandler(this.DevAttAddEditBtn_Click);
            // 
            // addDevAttBtn
            // 
            this.addDevAttBtn.Location = new System.Drawing.Point(180, 12);
            this.addDevAttBtn.Name = "addDevAttBtn";
            this.addDevAttBtn.Size = new System.Drawing.Size(93, 38);
            this.addDevAttBtn.TabIndex = 7;
            this.addDevAttBtn.Text = "添加属性";
            this.addDevAttBtn.UseVisualStyleBackColor = true;
            this.addDevAttBtn.Click += new System.EventHandler(this.AddDevAttBtn_Click);
            // 
            // devDefCB
            // 
            this.devDefCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devDefCB.FormattingEnabled = true;
            this.devDefCB.Location = new System.Drawing.Point(2, 12);
            this.devDefCB.Name = "devDefCB";
            this.devDefCB.Size = new System.Drawing.Size(153, 20);
            this.devDefCB.TabIndex = 8;
            this.devDefCB.SelectedIndexChanged += new System.EventHandler(this.DevDefCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "属性ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "属性名称:";
            // 
            // DevAttIDTB
            // 
            this.DevAttIDTB.Enabled = false;
            this.DevAttIDTB.Location = new System.Drawing.Point(250, 153);
            this.DevAttIDTB.Name = "DevAttIDTB";
            this.DevAttIDTB.Size = new System.Drawing.Size(107, 21);
            this.DevAttIDTB.TabIndex = 11;
            // 
            // DevAttNameTB
            // 
            this.DevAttNameTB.Location = new System.Drawing.Point(250, 224);
            this.DevAttNameTB.Name = "DevAttNameTB";
            this.DevAttNameTB.Size = new System.Drawing.Size(107, 21);
            this.DevAttNameTB.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "字典值：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(439, 434);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "字典意：";
            // 
            // AttDicListView
            // 
            this.AttDicListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.AttDicListView.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AttDicListView.FullRowSelect = true;
            this.AttDicListView.GridLines = true;
            this.AttDicListView.Location = new System.Drawing.Point(443, 41);
            this.AttDicListView.MultiSelect = false;
            this.AttDicListView.Name = "AttDicListView";
            this.AttDicListView.Size = new System.Drawing.Size(165, 290);
            this.AttDicListView.TabIndex = 15;
            this.AttDicListView.UseCompatibleStateImageBehavior = false;
            this.AttDicListView.View = System.Windows.Forms.View.Details;
            this.AttDicListView.SelectedIndexChanged += new System.EventHandler(this.AttDicListView_SelectedIndexChanged);
            // 
            // AttDicAddEditBtn
            // 
            this.AttDicAddEditBtn.Location = new System.Drawing.Point(508, 471);
            this.AttDicAddEditBtn.Name = "AttDicAddEditBtn";
            this.AttDicAddEditBtn.Size = new System.Drawing.Size(75, 23);
            this.AttDicAddEditBtn.TabIndex = 16;
            this.AttDicAddEditBtn.Text = "修改";
            this.AttDicAddEditBtn.UseVisualStyleBackColor = true;
            this.AttDicAddEditBtn.Click += new System.EventHandler(this.AttDicAddEditBtn_Click);
            // 
            // AttDicAddBtn
            // 
            this.AttDicAddBtn.Location = new System.Drawing.Point(568, 337);
            this.AttDicAddBtn.Name = "AttDicAddBtn";
            this.AttDicAddBtn.Size = new System.Drawing.Size(39, 36);
            this.AttDicAddBtn.TabIndex = 17;
            this.AttDicAddBtn.Text = "添加";
            this.AttDicAddBtn.UseVisualStyleBackColor = true;
            this.AttDicAddBtn.Click += new System.EventHandler(this.AttDicAddBtn_Click);
            // 
            // AttDicKeyTB
            // 
            this.AttDicKeyTB.Enabled = false;
            this.AttDicKeyTB.Location = new System.Drawing.Point(508, 394);
            this.AttDicKeyTB.Name = "AttDicKeyTB";
            this.AttDicKeyTB.Size = new System.Drawing.Size(100, 21);
            this.AttDicKeyTB.TabIndex = 18;
            // 
            // AttDicVaueTB
            // 
            this.AttDicVaueTB.Location = new System.Drawing.Point(508, 434);
            this.AttDicVaueTB.Name = "AttDicVaueTB";
            this.AttDicVaueTB.Size = new System.Drawing.Size(100, 21);
            this.AttDicVaueTB.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(180, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "例：speed 速度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(443, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "属性值对应字典：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(441, 365);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "例：1  前进";
            // 
            // DevAttForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 506);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AttDicVaueTB);
            this.Controls.Add(this.AttDicKeyTB);
            this.Controls.Add(this.AttDicAddBtn);
            this.Controls.Add(this.AttDicAddEditBtn);
            this.Controls.Add(this.AttDicListView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DevAttNameTB);
            this.Controls.Add(this.DevAttIDTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.devDefCB);
            this.Controls.Add(this.addDevAttBtn);
            this.Controls.Add(this.DevAttAddEditBtn);
            this.Controls.Add(this.DevAttListView);
            this.MinimizeBox = false;
            this.Name = "DevAttForm";
            this.Text = "设备属性";
            this.Load += new System.EventHandler(this.DevAttForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView DevAttListView;
        private System.Windows.Forms.Button DevAttAddEditBtn;
        private System.Windows.Forms.Button addDevAttBtn;
        private System.Windows.Forms.ComboBox devDefCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DevAttIDTB;
        private System.Windows.Forms.TextBox DevAttNameTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView AttDicListView;
        private System.Windows.Forms.Button AttDicAddEditBtn;
        private System.Windows.Forms.Button AttDicAddBtn;
        private System.Windows.Forms.TextBox AttDicKeyTB;
        private System.Windows.Forms.TextBox AttDicVaueTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}