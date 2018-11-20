using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XMLHelper;

namespace DispatchAnmination
{
    public partial class LineInfoForm : Form
    {
        private static LineInfoForm lineInfoForm;
        private XmlAnalyze xml;
        private List<AgvLineData> AgvLineDatas;
        private int AgvLineSelectedIndex = -1;
        public LineInfoForm()
        {
            InitializeComponent();
            AgvLineListView.Columns.Add("开始点", 80, HorizontalAlignment.Left);
            AgvLineListView.Columns.Add("特殊", 80, HorizontalAlignment.Left);
            AgvLineListView.Columns.Add("目标点", 80, HorizontalAlignment.Left);

            LinePointListView.Columns.Add("X", 50, HorizontalAlignment.Center);
            LinePointListView.Columns.Add("Y", 50, HorizontalAlignment.Center);

            xml = new XmlAnalyze();
            AgvLineDatas = new List<AgvLineData>();
        }
        public static LineInfoForm NewInstance()
        {
            if(lineInfoForm == null || lineInfoForm.IsDisposed)
            {
                lineInfoForm = new LineInfoForm();
            }
            return lineInfoForm;
        }

        private void LineInfoForm_Load(object sender, EventArgs e)
        {
            xml.DoAgvLineAnalyze();
            AgvLineDatas = xml.AgvLineList;
            AgvLineListViewRefresh();
        }

        /// <summary>
        /// Agv线路选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AgvLineListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            AgvLineSelectedIndex = AgvLineListView.FocusedItem.Index;
            LinePointListViewRefresh();
            LineNowSiteTB.Text = AgvLineDatas[AgvLineSelectedIndex].NowSite + "";
            LineSpecialCB.Checked = AgvLineDatas[AgvLineSelectedIndex].IsSpecial;
            LineDesSiteCB.SelectedIndex = GetDestSiteIndex(AgvLineDatas[AgvLineSelectedIndex].DesSite);

        }


        /// <summary>
        /// Agv线路更新
        /// </summary>
        private void AgvLineListViewRefresh()
        {
            AgvLineListView.Items.Clear();
            LinePointListView.Items.Clear();
            if (AgvLineDatas.Count == 0) return;
            AgvLineListView.BeginUpdate();
            foreach (var agvline in AgvLineDatas)
            {
                ListViewItem item = new ListViewItem(agvline.NowSite + ""); // 起始地标
                item.SubItems.Add(agvline.IsSpecial ? "是":"否"); //特殊节点
                item.SubItems.Add(agvline.DesSite + ""); //目标站点
                AgvLineListView.Items.Add(item);
            }
            //// 结束数据处理
            AgvLineListView.EndUpdate();
            AgvLineSelectedIndex = -1;
        }


        /// <summary>
        /// 线路坐标更新
        /// </summary>
        private void LinePointListViewRefresh()
        {
            if (AgvLineSelectedIndex == -1)
            {
                MessageBox.Show("请先选择线路！");
                return;
            }

            LinePointListView.Items.Clear();
            LinePointListView.BeginUpdate();
            foreach (var point in AgvLineDatas[AgvLineSelectedIndex].Points)
            {
                ListViewItem item = new ListViewItem(point.X + ""); // 起始地标
                item.SubItems.Add(point.Y + ""); //特殊节点
                LinePointListView.Items.Add(item);
            }
            //// 结束数据处理
            LinePointListView.EndUpdate();
        }

        /// <summary>
        /// 使用地图解析的初步地标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UseXmlAnBtn_Click(object sender, EventArgs e)
        {
            AgvLineDatas.Clear();
            foreach(Line line in LineDateCenter._linesPositive)
            {
                AgvLineData data = new AgvLineData
                {
                   NowSite = line.LineID
                };
                foreach( var p in line._points)
                {
                    data.Points.Add(new AgvPoint { X = p.X, Y = p.Y });
                }
                AgvLineDatas.Add(data);
            }

            AgvLineListViewRefresh();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAgvLineBtn_Click(object sender, EventArgs e)
        {
            xml.SaveAgvLineToFile(AgvLineDatas);
            xml.DoAgvLineAnalyze();
            AgvLineDatas = xml.AgvLineList;
            AgvLineListViewRefresh();
        }

        /// <summary>
        /// 添加线路
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLineBtn_Click(object sender, EventArgs e)
        {
            if (LineNowSiteTB.Text.Length == 0)
            {
                MessageBox.Show("请先填写信息");
                return;
            }
            AgvLineData line = new AgvLineData
            {
                NowSite = int.Parse(LineNowSiteTB.Text),
                IsSpecial = LineSpecialCB.Checked,
                DesSite = GetDestSite(LineDesSiteCB.SelectedIndex)
            };

            AgvLineDatas.Add(line);
            AgvLineListViewRefresh();
        }
        /// <summary>
        /// 1号站点(11地标)
        //4号站点(14地标)
        //32等待点
        //33等待点
        //51充电点
        //52充电点
        /// </summary>
        private int[] DesSite = {0,4,32,33,51,52 };
        public int GetDestSite(int index)
        {
            if (index >= DesSite.Length) return 0;
            return DesSite[index];
        }

        public int GetDestSiteIndex(int dessite)
        {
            for(int i = 0; i< DesSite.Length; i++)
            {
                if (DesSite[i] == dessite)
                {
                    return i;
                }
            }
            return 0;
        }

        private void EditeLineBtn_Click(object sender, EventArgs e)
        {
            if (AgvLineSelectedIndex == -1)
            {
                MessageBox.Show("请先选择线路！");
                return;
            }
            AgvLineDatas[AgvLineSelectedIndex].NowSite = int.Parse(LineNowSiteTB.Text);
            AgvLineDatas[AgvLineSelectedIndex].DesSite = GetDestSite(LineDesSiteCB.SelectedIndex);
            AgvLineDatas[AgvLineSelectedIndex].IsSpecial = LineSpecialCB.Checked;
            AgvLineListViewRefresh();
        }
    }
}
