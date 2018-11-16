using KDTask.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace KDTask
{
    public partial class KDForm : Form
    {
        public static string FormName = "KEEKEKE";
        public KDForm()
        {
            InitializeComponent();
        }

        private void KDForm_Load(object sender, EventArgs e)
        {
            //初始化文档解析类
            XMLMaster.Init();
        }

        private void ToolTaskLab_Click(object sender, EventArgs e)
        {

        }

        private void ToolDevLab_Click(object sender, EventArgs e)
        {

        }

        private void ToolDevdefItem_Click(object sender, EventArgs e)
        {
            DevDefForm.NewInstance().Show();
        }

        private void ToolDevaddItem_Click(object sender, EventArgs e)
        {
            DevForm.NewInstance().Show();
        }

        private void toolDevstatusItem_Click(object sender, EventArgs e)
        {
            DevAttForm.NewInstance().Show();
        }

        private void toolCodedefItem_Click(object sender, EventArgs e)
        {
            //IPAddress.HostToNetworkOrder();
            //IPAddress.NetworkToHostOrder();
        }


        //UInt16 crc_chk_value(UInt16 data_value, int length)
        //{
        //    UInt16 crc_value = 0xFFFF;
        //    int i;
        //    while (length--)
        //    {
        //        crc_value ^=  data_value++;
        //        for (i = 0; i < 8; i++)
        //        {
        //            if (crc_value & 0x0001)
        //            {
        //                crc_value = (crc_value >> 1) ^ 0xa001;
        //            }
        //            else
        //            {
        //                crc_value = crc_value >> 1;
        //            }
        //        }
        //    }
        //    return (crc_value);
        //}

    }
}
