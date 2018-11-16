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
            ModuleControl.AddAgvToModule(null);
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
            AgvUpdateClass.UpDateAgv("AGV001");
            AgvUpdateClass.UpDateAgv("AGV002");
            AgvUpdateClass.UpDateAgv("AGV003");
        }

        private void LinePosNegBtn_Click(object sender, EventArgs e)
        {
            LineInfoForm.newInstance().Show();
        }
    }
}
