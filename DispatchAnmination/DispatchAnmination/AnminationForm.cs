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
        public AnminationForm()
        {
            InitializeComponent();
        }
        private void AnminationForm_Load(object sender, EventArgs e)
        {
            anmination = new Anmination(imageList);

            XmlAnalyze xml = new XmlAnalyze();
            xml.DoAnalyze();

            ModuleControl.AddLinesToModule(xml._lineDatas);
            LineDateCenter.AddLineData();
            ModuleControl.AddAgvToModule(null);

            // new XmlHelper().Test();
            //XmlHelper xmlHelper = new XmlHelper();
            //xmlHelper.CreateOrLoadXMLFile("x.xml");

            //XmlNodeList lines = xmlHelper.GetXmlNodeList("Line");
            //foreach(XmlElement node in lines)
            //{
            //    node.SetAttribute("id","44");

            //    if(node.ChildNodes != null)
            //    {
            //        foreach (XmlElement site in node.ChildNodes)
            //        {
            //           String startX =  site.GetAttribute("startX");

            //        }
            //    }

            //}
            //XmlElement elementLines = xmlHelper.GetXmlElementById("lines");

            //xmlHelper.SaveXMLFile("x.xml");


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
            ModuleControl.UpdateAgvSite("AGV001", GetLine(), GetIndex());
        }
        private int[] lines = { 23,33,15,13,
                               21,11,22,34,
            24,
            14 };
        private int[] rates = { 0,5,10,15,20,25,30,35,40,45,50,55,60,65,70,75,80,85,90,95,100};
        private int index = 0,lineindex =0;
        private int GetIndex()
        {
            if(index < rates.Length-1)
            {
                index++;
                return rates[index];
            }
            else
            {
                index = 0;
                lineindex++;
                if (lineindex == lines.Length)
                {
                    lineindex = 0;
                }
                return rates[rates.Length - 1];
            }
        }
        private int GetLine()
        {
            return lines[lineindex];
        }
    }
}
