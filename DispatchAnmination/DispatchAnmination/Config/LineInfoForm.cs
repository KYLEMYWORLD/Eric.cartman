using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispatchAnmination
{
    public partial class LineInfoForm : Form
    {
        private static LineInfoForm lineInfoForm;
        public LineInfoForm()
        {
            InitializeComponent();
            LineInfoListView.Columns.Add("地标", 50, HorizontalAlignment.Left);
            LineInfoListView.Columns.Add("长度", 50, HorizontalAlignment.Left);
            LineInfoListView.Columns.Add("正负", 50, HorizontalAlignment.Left);
            LineInfoListView.Columns.Add("所有点", 500, HorizontalAlignment.Left);
        }
        public static LineInfoForm newInstance()
        {
            if(lineInfoForm == null || lineInfoForm.IsDisposed)
            {
                lineInfoForm = new LineInfoForm();
            }
            return lineInfoForm;
        }

        private void LineInfoForm_Load(object sender, EventArgs e)
        {

            LineInfoListView.BeginUpdate();
            LineInfoListView.Items.Clear();
            foreach (var line in LineDateCenter._linesPositive)
            {
                ListViewItem item = new ListViewItem(line.LineID + ""); // 任务信息
                item.SubItems.Add(line.Lenght+""); //站点信息
                item.SubItems.Add(line.Direction+""); //站点信息
                string appoint ="";
                foreach (var p in line._points)
                {
                    appoint = appoint +"("+ p.X + "," + p.Y+"), ";
                }
                item.SubItems.Add(appoint); //所有站点

                LineInfoListView.Items.Add(item);
            }
            foreach (var line in LineDateCenter._linesNagetivie)
            {
                ListViewItem item = new ListViewItem(line.LineID + ""); // 任务信息
                item.SubItems.Add(line.Lenght + ""); //站点信息
                item.SubItems.Add(line.Direction + ""); //站点信息
                string appoint = "";
                foreach (var p in line._points)
                {
                    appoint = appoint + "(" + p.X + "," + p.Y + "), ";
                }
                item.SubItems.Add(appoint); //所有站点

                LineInfoListView.Items.Add(item);
            }


            //// 结束数据处理
            LineInfoListView.EndUpdate();
        }
    }
}
