using DispatchAnmination.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using XMLHelper;

namespace DispatchAnmination
{
    public partial class AnminationForm : Form
    {
        Anmination anmination;
        XmlAnalyze xml;
        public AnminationForm()
        {
            InitializeComponent();
        }
        private void AnminationForm_Load(object sender, EventArgs e)
        {
            anmination = new Anmination(imageList);

            xml = new XmlAnalyze();
            xml.DoAnalyze();

            ModuleControl.AddLinesToModule(xml._lineDatas);
            LineDateCenter.AddLineData();
            //ModuleControl.AddAgvToModule(null);
            ModuleControl.AddAgvToModule("AGV001",23);
            ModuleControl.AddAgvToModule("AGV002",33);
            ModuleControl.AddAgvToModule("AGV003",23,50);
            ModuleControl.AddAgvToModule("AGV004",34);

        }

        private Point point = new Point(500, 500);

        /// <summary>
        /// 画面更新方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void anmination_picBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            anmination.Draw(graphics, point);
        }

        private void anminateTimer_Tick(object sender, EventArgs e)
        {
            point = Control.MousePosition;
            anminationPicBox.Invalidate();
            AgvSiteMaster.UpDateAgv("AGV001");
            AgvSiteMaster.UpDateAgv("AGV002");
            AgvSiteMaster.UpDateAgv("AGV003");
            AgvSiteMaster.UpDateAgv("AGV004");
        }

        private void LinePosNegBtn_Click(object sender, EventArgs e)
        {
            LineInfoForm.newInstance().Show();
        }

        private void DisplaySetBtn_Click(object sender, EventArgs e)
        {
            DisplaySetForm.newInstance().Show();
        }
    }
}
