using DispatchAnmination.AgvLine;
using DispatchAnmination.Config;
using DispatchAnmination.MapConfig;
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
            AgvLineMaster.AddLine(xml.AgvLineList);

            LineDateCenter.AddLineData();




            ModuleControl.AddAgvToModuleNew("AGV011", 12, 1);
            ModuleControl.AddAgvToModuleNew("AGV012", 12, 5, 22);
            ModuleControl.AddAgvToModuleNew("AGV013", 12, 2, 50);
            ModuleControl.AddAgvToModuleNew("AGV014", 12, 3, 70);
            ModuleControl.AddAgvToModuleNew("AGV02", 15, 1);
            ModuleControl.AddAgvToModuleNew("AGV03", 15, 8, 30);
            ModuleControl.AddAgvToModuleNew("AGV04", 15, 6, 40);
            ModuleControl.AddAgvToModuleNew("AGV05", 15, 71, 55);


        }


        private Point point = new Point(500, 500);

        /// <summary>
        /// 画面更新方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Anmination_picBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            anmination.Draw(graphics, point);
        }
        private void Test()
        {
            ModuleControl.UpdateAgvSiteNew("AGV011", 12,5);
            ModuleControl.UpdateAgvSiteNew("AGV012", 12,1);
            ModuleControl.UpdateAgvSiteNew("AGV013", 12,12);
            ModuleControl.UpdateAgvSiteNew("AGV014", 12,78);
            ModuleControl.UpdateAgvSiteNew("AGV02", 15);
            //ModuleControl.UpdateAgvSiteNew("AGV03", 15);
            ModuleControl.UpdateAgvSiteNew("AGV04", 15);
            ModuleControl.UpdateAgvSiteNew("AGV05", 15);
        }

        private void AnminateTimer_Tick(object sender, EventArgs e)
        {
            point = Control.MousePosition;

            //AgvSiteMaster.UpDateAgv("AGV001");
            //AgvSiteMaster.UpDateAgv("AGV002");
            //AgvSiteMaster.UpDateAgv("AGV003");
            //AgvSiteMaster.UpDateAgv("AGV004");
            Test();

            anminationPicBox.Invalidate();
        }

        private void LinePosNegBtn_Click(object sender, EventArgs e)
        {
            LineInfoForm.NewInstance().Show();
        }

        private void DisplaySetBtn_Click(object sender, EventArgs e)
        {
            DisplaySetForm.NewInstance().Show();
        }

        private void MapConfigBtn_Click(object sender, EventArgs e)
        {
            MapConfigForm.NewInstance().Show();
        }

        private void ReReadConfBtn_Click(object sender, EventArgs e)
        {
            anminateTimer.Enabled = false;
            xml = new XmlAnalyze();
            xml.DoAnalyze();

            ModuleControl.AddLinesToModule(xml._lineDatas);
            AgvLineMaster.AddLine(xml.AgvLineList);

            LineDateCenter.AddLineData();
            anminateTimer.Enabled = true;
        }
    }
}
