using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XMLHelper;

namespace DispatchAnmination.MapConfig
{
    public partial class MapConfigForm : Form
    {
        public MapConfigForm()
        {
            InitializeComponent();
            LineListView.Columns.Add("Index", 20, HorizontalAlignment.Center);
            LineListView.Columns.Add("SX", 80, HorizontalAlignment.Center);
            LineListView.Columns.Add("SY", 80, HorizontalAlignment.Center);
            LineListView.Columns.Add("EX", 80, HorizontalAlignment.Center);
            LineListView.Columns.Add("EY", 80, HorizontalAlignment.Center);

            LineSiteListView.Columns.Add("ID", 80, HorizontalAlignment.Center);
            LineSiteListView.Columns.Add("Rate", 80, HorizontalAlignment.Center);
        }
        private static MapConfigForm _form;
        public static MapConfigForm NewInstance()
        {
            if(_form==null || _form.IsDisposed)
            {
                _form = new MapConfigForm();
            }
            return _form;
        }

        private bool IsNewLine = false, IsNewSite = false;
        private Point SiteP;
        private Point LineStartP, LineEndP;

        private List<LineModule> _lineModule = new List<LineModule>();

        private void MapConfigPB_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsNewLine)
            {
                LineStartP = new Point(e.X, e.Y);
            }
        }

        private void AddNewLineBtn_Click(object sender, EventArgs e)
        {
            IsNewLine = true;
        }


        private void MapConfigPB_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsNewLine)
            {
                LineEndP = new Point(e.X, e.Y);
                _lineModule.Add(new LineModule(LineStartP, LineEndP));
                LineListViewRefresh();
                IsNewLine = false;
            }
        }

        private void MapConfigPB_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach(var line in _lineModule)
            {
                line.Draw(g);
            }
        }

        private void AddNewSiteBtn_Click(object sender, EventArgs e)
        {
            if (LineSelectedIndex == -1)
            {
                MessageBox.Show("请选择线路！");
                return;
            } else if (SiteIDTB.Text.Length == 0 || SiteRateTB.Text.Length==0 ||
                SiteTypeCB.SelectedIndex == -1 || SiteDirecationCB.SelectedIndex==-1)
            {
                MessageBox.Show("请先填写和选择站点信息");
                return;
            }
            _lineModule[LineSelectedIndex].AddSitePos(int.Parse(SiteIDTB.Text), int.Parse(SiteRateTB.Text),
                SiteDirecationCB.SelectedIndex,(SiteType) SiteTypeCB.SelectedIndex, SiteNameTB.Text,SiteUpNameTB.Text);
            LineSiteListViewRefresh();
        }

        private void MapConfigPB_MouseMove(object sender, MouseEventArgs e)
        {
            LineEndP = new Point(e.X,e.Y);
        }
        LineModule module;
        private void LineListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            LineSelectedIndex = LineListView.FocusedItem.Index;
            module = _lineModule[LineSelectedIndex];
            LineStartPxTB.Text = module._centerP.X + "";
            LineStartPyTB.Text = module._centerP.Y + "";
            LineEndPxTB.Text = module._endP.X + "";
            LineEndPyTB.Text = module._endP.Y + "";

            LineSiteListViewRefresh();
        }

        private void MapTimer_Tick(object sender, EventArgs e)
        {
            MapTimer.Enabled = false;
            MapConfigPB.Invalidate();
            MapTimer.Enabled = true;
        }

        private void LineListViewRefresh()
        {
            LineListView.Items.Clear();
            LineSiteListView.Items.Clear();
            if (_lineModule.Count == 0)
            {
                return;
            }

            LineListView.BeginUpdate();
            foreach(var line in _lineModule)
            {
                ListViewItem item = new ListViewItem(_lineModule.IndexOf(line) + "");
                item.SubItems.Add(line._centerP.X + "");
                item.SubItems.Add(line._centerP.Y + "");
                item.SubItems.Add(line._endP.X + "");
                item.SubItems.Add(line._endP.Y + "");
                LineListView.Items.Add(item);
            }
            LineListView.EndUpdate();
            ClearLineSite();
            ClearLine();
        }

        private void LineSiteListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SitePos site = _lineModule[LineSelectedIndex].SitePos[LineSiteListView.FocusedItem.Index];
            SiteIDTB.Text = site.ID + "";
            SiteNameTB.Text = site.Name;
            SiteRateTB.Text = site._rate + "";
            SiteUpNameTB.Text = site.UpName;
            SiteDirecationCB.SelectedIndex = site._direction;
            SiteTypeCB.SelectedIndex = (int)site._type;
        }

        private int LineSelectedIndex = 0;

        private void EditLineBtn_Click(object sender, EventArgs e)
        {
            _lineModule[LineSelectedIndex]._centerP.X = int.Parse(LineStartPxTB.Text);
            _lineModule[LineSelectedIndex]._centerP.Y = int.Parse(LineStartPyTB.Text);
            _lineModule[LineSelectedIndex]._endP.X = int.Parse(LineEndPxTB.Text);
            _lineModule[LineSelectedIndex]._endP.Y = int.Parse(LineEndPyTB.Text);

        }

        private void DeleteLineBtn_Click(object sender, EventArgs e)
        {
            _lineModule.RemoveAt(LineSelectedIndex);
            LineSelectedIndex = -1;
            LineListViewRefresh();
            ClearLine();
        }

        private void LineSiteListViewRefresh()
        {
            LineSiteListView.Items.Clear();
            if (_lineModule.Count < LineSelectedIndex)
            {
                return;
            }

            LineSiteListView.BeginUpdate();
            foreach (var site in _lineModule[LineSelectedIndex].SitePos)
            {
                ListViewItem item = new ListViewItem(site.ID+ "");
                item.SubItems.Add(site._rate + "");
                LineSiteListView.Items.Add(item);
            }
            LineSiteListView.EndUpdate();
            ClearLineSite();
        }

        private void ClearLineSite()
        {
            SiteIDTB.Text = "";
            SiteNameTB.Text = "";
            SiteRateTB.Text =  "";
            SiteUpNameTB.Text = "";
            SiteDirecationCB.SelectedIndex =0;
            SiteTypeCB.SelectedIndex =0;
        }

        private void ClearLine()
        {
            LineStartPxTB.Text = "";
            LineStartPyTB.Text =  "";
            LineEndPxTB.Text = "";
            LineEndPyTB.Text = "";
        }
    }
}
