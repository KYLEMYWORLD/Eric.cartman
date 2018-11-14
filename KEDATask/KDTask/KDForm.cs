using KDTask.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
