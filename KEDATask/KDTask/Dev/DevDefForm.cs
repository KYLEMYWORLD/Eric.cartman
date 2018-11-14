using KDTask.XML;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KDTask
{
    public partial class DevDefForm : Form
    {
        public static DevDefForm devDefForm;

        public DevDefForm()
        {
            InitializeComponent();
        }

        private void DevDefForm_Load(object sender, EventArgs e)
        {
            devListView.Columns.Add("设备ID", 130, HorizontalAlignment.Left);
            ListViewRefresh();
        }


        public static DevDefForm NewInstance()
        {
            if (devDefForm == null || devDefForm.IsDisposed)
            {
                devDefForm = new DevDefForm();
            }
            return devDefForm;
        }

        public void ListViewRefresh()
        {
            List<Devdef> devs = XMLMaster.Devdefs._devdefs;

            if (devs == null)
            {
                devListView.Clear();
                return;
            }

            devListView.Items.Clear();
            devListView.BeginUpdate();
            foreach (var data in devs)
            {
                ListViewItem item = new ListViewItem(data.ID); // AGV名称
                devListView.Items.Add(item);
            }
            // 结束数据处理
            devListView.EndUpdate();
        }
        private ListViewItem lastFocuse;
        private void DevListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (devListView.FocusedItem != null)
            {
                Devdef devdef = XMLMaster.Devdefs.FindDevdef(devListView.FocusedItem.Text);
                if (devdef != null)
                {
                    devIdTB.Text = devdef.ID;
                    devNameTB.Text = devdef.Name;
                    devNetCB.SelectedIndex = int.Parse(devdef.ConnetType);
                    devDefAddEditBtn.Text = "修改";
                }
                if (lastFocuse != null) lastFocuse.BackColor = System.Drawing.Color.White;
                devListView.FocusedItem.BackColor = System.Drawing.Color.Gray;
                lastFocuse = devListView.FocusedItem;
            }
            
            
        }

        private void AddDevBtn_Click(object sender, EventArgs e)
        {
            devDefAddEditBtn.Text = "添加";
            devIdTB.Text = "";
            devNameTB.Text = "";
            devNetCB.SelectedIndex = 0;
        }

        private void DevDefAddEditBtn_Click(object sender, EventArgs e)
        {
            Devdef devdef = new Devdef
            {
                ID = devIdTB.Text,
                Name = devNameTB.Text,
                ConnetType = devNetCB.SelectedIndex + ""
            };
            if (devDefAddEditBtn.Text.Equals("添加"))
            {
                XMLMaster.AddDevdef(devdef);
            }
            else
            {
                XMLMaster.EditeDevdef(devdef);
            }

            ListViewRefresh();
        }
    }

    
}
