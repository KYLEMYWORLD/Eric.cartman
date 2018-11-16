using KDTask.XML;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KDTask
{
    public partial class DevForm : Form
    {
        public static DevForm devForm;

        public DevForm()
        {
            InitializeComponent();
        }

        private void DevForm_Load(object sender, EventArgs e)
        {
            devListView.Columns.Add("设备ID",   80, HorizontalAlignment.Left);
            devListView.Columns.Add("设备名称", 80, HorizontalAlignment.Left);
            devListView.Columns.Add("设备类型", 78, HorizontalAlignment.Left);

            ListViewRefresh();
            devtypeCB.Items.AddRange(XMLMaster.Devdefs.GetTypeStrings());
            devDefCB.Items.Add("ALL");
            devDefCB.Items.AddRange(XMLMaster.Devdefs.GetTypeStrings());
            devDefCB.SelectedIndex = 0;
        }


        public static DevForm NewInstance()
        {
            if (devForm == null || devForm.IsDisposed)
            {
                devForm = new DevForm();
            }
            return devForm;
        }

        public void ListViewRefresh(string type = "ALL")
        {
            List<Dev> devs = XMLMaster.Devs._devs;

            if (devs == null)
            {
                devListView.Items.Clear();
                return;
            }

            devListView.Items.Clear();
            devListView.BeginUpdate();
            foreach (var data in devs)
            {
                if (type.Equals("ALL"))
                {
                    ListViewItem item = new ListViewItem(data.ID); //设备ID
                    item.SubItems.Add(data.Name);//设备名称
                    item.SubItems.Add(data.Type);//设备类型
                    devListView.Items.Add(item);
                }
                else if (data.Type.Equals(type))
                {
                    ListViewItem item = new ListViewItem(data.ID); //设备ID
                    item.SubItems.Add(data.Name);//设备名称
                    item.SubItems.Add(data.Type);//设备类型
                    devListView.Items.Add(item);
                }
            }
            // 结束数据处理
            devListView.EndUpdate();
        }
        private ListViewItem lastFocuse;
        private void DevListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (devListView.FocusedItem != null)
            {
                Dev dev= XMLMaster.Devs.FindDev(devListView.FocusedItem.Text);
                if (dev != null)
                {
                    devIdTB.Enabled = false;
                    devIdTB.Text = dev.ID;
                    devNameTB.Text = dev.Name;
                    devIPTB.Text = dev.IP;
                    devPortTB.Text = dev.Port;
                    devtypeCB.SelectedIndex = devtypeCB.FindString(dev.Type);
                    devAddEditBtn.Text = "修改";
                }
                if (lastFocuse != null) lastFocuse.BackColor = System.Drawing.Color.White;
                devListView.FocusedItem.BackColor = System.Drawing.Color.Gray;
                lastFocuse = devListView.FocusedItem;
            }
            
            
        }

        private void AddDevBtn_Click(object sender, EventArgs e)
        {
            devAddEditBtn.Text = "添加";
            devIdTB.Enabled = true;
            devIdTB.Text = "";
            devNameTB.Text = "";
            devPortTB.Text = "";
            devIPTB.Text = "";
            devtypeCB.SelectedIndex = 0;
        }

        private void DevDefAddEditBtn_Click(object sender, EventArgs e)
        {
            Dev dev = new Dev
            {
                ID = devIdTB.Text,
                Name = devNameTB.Text,
                Type = devtypeCB.SelectedItem + "",
                IP = devIPTB.Text,
                Port = devPortTB.Text
            };
            if (devAddEditBtn.Text.Equals("添加"))
            {
                XMLMaster.AddDev(dev);
            }
            else
            {
                XMLMaster.EditeDev(dev);
            }

            ListViewRefresh();
        }

        private void DevDefCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewRefresh(devDefCB.SelectedItem+"");
        }

        private void devTestConBtn_Click(object sender, EventArgs e)
        {

        }
    }

    
}
