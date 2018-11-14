using KDTask.XML;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KDTask
{
    public partial class DevAttForm : Form
    {
        public static DevAttForm devAttForm;

        public DevAttForm()
        {
            InitializeComponent();
        }

        private void DevAttForm_Load(object sender, EventArgs e)
        {
            devAttListView.Columns.Add("设备ID",   80, HorizontalAlignment.Left);
            devAttListView.Columns.Add("设备名称", 80, HorizontalAlignment.Left);
            devAttListView.Columns.Add("设备类型", 78, HorizontalAlignment.Left);
            devAttListView.View = System.Windows.Forms.View.Details;
            ListViewRefresh();
            devAtttypeCB.Items.AddRange(XMLMaster.Devdefs.GetTypeStrings());
            devAttDefCB.Items.Add("ALL");
            devAttDefCB.Items.AddRange(XMLMaster.Devdefs.GetTypeStrings());
            devAttDefCB.SelectedIndex = 0;
        }


        public static DevAttForm NewInstance()
        {
            if (devAttForm == null || devAttForm.IsDisposed)
            {
                devAttForm = new DevAttForm();
            }
            return devAttForm;
        }

        public void ListViewRefresh(string type = "ALL")
        {
            List<Dev> devs = XMLMaster.Devs._devs;

            if (devs == null)
            {
                devAttListView.Clear();
                return;
            }

            devAttListView.Items.Clear();
            devAttListView.BeginUpdate();
            foreach (var data in devs)
            {
                if (type.Equals("ALL"))
                {
                    ListViewItem item = new ListViewItem(data.ID); //设备ID
                    item.SubItems.Add(data.Name);//设备名称
                    item.SubItems.Add(data.Type);//设备类型
                    devAttListView.Items.Add(item);
                }
                else if (data.Type.Equals(type))
                {
                    ListViewItem item = new ListViewItem(data.ID); //设备ID
                    item.SubItems.Add(data.Name);//设备名称
                    item.SubItems.Add(data.Type);//设备类型
                    devAttListView.Items.Add(item);
                }
            }
            // 结束数据处理
            devAttListView.EndUpdate();
        }
        private ListViewItem lastFocuse;
        private void DevListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (devAttListView.FocusedItem != null)
            {
                Dev dev= XMLMaster.Devs.FindDev(devAttListView.FocusedItem.Text);
                if (dev != null)
                {
                    devIdTB.Text = dev.ID;
                    devNameTB.Text = dev.Name;
                    devIPTB.Text = dev.IP;
                    devPortTB.Text = dev.Port;
                    devAtttypeCB.SelectedIndex = devAtttypeCB.FindString(dev.Type);
                    devAddEditBtn.Text = "修改";
                }
                if (lastFocuse != null) lastFocuse.BackColor = System.Drawing.Color.White;
                devAttListView.FocusedItem.BackColor = System.Drawing.Color.Gray;
                lastFocuse = devAttListView.FocusedItem;
            }
            
            
        }

        private void AddDevBtn_Click(object sender, EventArgs e)
        {
            devAddEditBtn.Text = "添加";
            devIdTB.Text = "";
            devNameTB.Text = "";
            devPortTB.Text = "";
            devIPTB.Text = "";
            devAtttypeCB.SelectedIndex = 0;
        }

        private void DevDefAddEditBtn_Click(object sender, EventArgs e)
        {
            Dev dev = new Dev
            {
                ID = devIdTB.Text,
                Name = devNameTB.Text,
                Type = devAtttypeCB.SelectedItem + "",
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
            ListViewRefresh(devAttDefCB.SelectedItem+"");
        }

        private void devTestConBtn_Click(object sender, EventArgs e)
        {

        }
    }

    
}
