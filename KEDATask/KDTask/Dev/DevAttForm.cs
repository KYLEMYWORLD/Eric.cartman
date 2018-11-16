using KDTask.XML;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KDTask
{
    public partial class DevAttForm : Form
    {
        public static DevAttForm devAttForm;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DevAttForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DevAttForm_Load(object sender, EventArgs e)
        {
            DevAttListView.Columns.Add("属性ID",   65, HorizontalAlignment.Left);
            DevAttListView.Columns.Add("属性名称", 80, HorizontalAlignment.Left);

            AttDicListView.Columns.Add("字典值", 80, HorizontalAlignment.Left);
            AttDicListView.Columns.Add("字典意", 80, HorizontalAlignment.Left);
            
            devDefCB.Items.AddRange(XMLMaster.Devdefs.GetTypeStrings());
            devDefCB.SelectedIndex = 0;
            DevAttListViewRefresh();
        }

        /// <summary>
        /// 创建窗口
        /// </summary>
        /// <returns></returns>
        public static DevAttForm NewInstance()
        {
            if (devAttForm == null || devAttForm.IsDisposed)
            {
                devAttForm = new DevAttForm();
            }
            return devAttForm;
        }


        /// <summary>
        /// 设备属性更新列表
        /// </summary>
        /// <param name="type"></param>
        public void DevAttListViewRefresh()
        {
            devdef = XMLMaster.Devdefs.FindDevdef(devDefCB.SelectedItem + "");

            if (devdef == null || devdef.DevAtts == null)
            {
                DevAttListView.Items.Clear();
                AttDicListView.Items.Clear();
                Clear(2);
                return;
            }

            DevAttListView.Items.Clear();
            AttDicListView.Items.Clear();
            DevAttListView.BeginUpdate();
            foreach (var data in devdef.DevAtts)
            {

                ListViewItem item = new ListViewItem(data.ID); //设备ID
                item.SubItems.Add(data.Name);//设备名称
                DevAttListView.Items.Add(item);
            }
            // 结束数据处理
            DevAttListView.EndUpdate();

        }

        /// <summary>
        /// 清除输入框内容
        /// </summary>
        /// <param name="type"></param>
        private void Clear(int type)
        {
            switch (type)
            {
                case 0:
                    DevAttIDTB.Text = "";
                    DevAttNameTB.Text = "";
                    break;
                case 1:
                    AttDicKeyTB.Text = "";
                    AttDicVaueTB.Text = "";
                    break;
                case 2:
                    DevAttIDTB.Text = "";
                    DevAttNameTB.Text = "";
                    AttDicKeyTB.Text = "";
                    AttDicVaueTB.Text = "";
                    break;
            }
        }


        /// <summary>
        /// 属性字典值列表刷新
        /// </summary>
        /// <param name="attDics"></param>
        public void AttDicListViewRefresh()
        {
            if (devAtt == null || devAtt.GetAttDics()==null)
            {
                AttDicListView.Items.Clear();
                Clear(1);
                return;
            }

            AttDicListView.Items.Clear();
            AttDicListView.BeginUpdate();
            foreach (var data in devAtt.GetAttDics())
            {

                ListViewItem item = new ListViewItem(data.Key); //字典值
                item.SubItems.Add(data.Value);//字典意
                
                AttDicListView.Items.Add(item);
            }
            // 结束数据处理
            AttDicListView.EndUpdate();
        }
        /// <summary>
        /// 设备信息
        /// </summary>
        private Devdef devdef;
        private ListViewItem devAttLastItem;
        /// <summary>
        /// 设备属性列表选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DevAttListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DevAttListView.FocusedItem != null)
            {
                if (devdef != null)
                {
                    devAtt = devdef.GetDevAttById(DevAttListView.FocusedItem.Text);

                    DevAttIDTB.Enabled = false;
                    DevAttIDTB.Text = devAtt.ID;
                    DevAttNameTB.Text = devAtt.Name;
                    DevAttAddEditBtn.Text = "修改";
                    AttDicListViewRefresh();
                }
                if (devAttLastItem != null) devAttLastItem.BackColor = System.Drawing.Color.White;
                DevAttListView.FocusedItem.BackColor = System.Drawing.Color.Gray;
                devAttLastItem = DevAttListView.FocusedItem;
            }
        }

        private DevAtt devAtt;
        private ListViewItem attDicLastItem;
        /// <summary>
        /// 属性字典选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttDicListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AttDicListView.FocusedItem != null)
            {
                if (devAtt != null)
                {
                    AttDic attDic = devAtt.GetAttDicByKey(AttDicListView.FocusedItem.Text);


                    AttDicKeyTB.Enabled = false;
                    AttDicKeyTB.Text = attDic.Key;
                    AttDicVaueTB.Text = attDic.Value;
                    AttDicAddEditBtn.Text = "修改";
                }
                if (attDicLastItem != null) attDicLastItem.BackColor = System.Drawing.Color.White;
                AttDicListView.FocusedItem.BackColor = System.Drawing.Color.Gray;
                attDicLastItem = AttDicListView.FocusedItem;
            }
        }

        /// <summary>
        /// 设备类型下拉框选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DevDefCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevAttListViewRefresh();
        }

        
        /// <summary>
        /// 属性添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDevAttBtn_Click(object sender, EventArgs e)
        {
            if (devdef == null)
            {
                MessageBox.Show("还没有设备定义的信息！");
                return;
            }
            DevAttIDTB.Enabled = true;
            DevAttAddEditBtn.Text = "添加";
            Clear(0);
        }


        /// <summary>
        /// 属性字典添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttDicAddBtn_Click(object sender, EventArgs e)
        {
            if (devAtt == null)
            {
                MessageBox.Show("请先选择属性！");
                return;
            }
            AttDicKeyTB.Enabled = true;
            AttDicAddEditBtn.Text = "添加";
            Clear(1);
        }


        /// <summary>
        /// 属性修改/添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DevAttAddEditBtn_Click(object sender, EventArgs e)
        {
            DevAtt devAtt = new DevAtt
            {
                ID = DevAttIDTB.Text,
                Name = DevAttNameTB.Text,
                Start = 0,
                End = 0
            };
            if (DevAttAddEditBtn.Text.Equals("添加"))
            {
                XMLMaster.AddDevAtt(devdef.ID, devAtt);
            }
            else
            {
                XMLMaster.EditeDevAtt(devdef.ID, devAtt);
            }
            DevAttListViewRefresh();
        }

        /// <summary>
        /// 属性字典值添加/修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttDicAddEditBtn_Click(object sender, EventArgs e)
        {
            AttDic attDic = new AttDic
            {
                Key = AttDicKeyTB.Text,
                Value = AttDicVaueTB.Text
            };

            if (AttDicAddEditBtn.Text.Equals("添加"))
            {
                XMLMaster.AddAttDic(devdef.ID, devAtt.ID, attDic);
            }
            else
            {
                XMLMaster.EditeAttDic(devdef.ID, devAtt.ID, attDic);
            }
            devdef = XMLMaster.Devdefs.FindDevdef(devDefCB.SelectedItem + "");
            devAtt = devdef.GetDevAttById(DevAttListView.FocusedItem.Text);
            AttDicListViewRefresh();
        }
    }

    
}
