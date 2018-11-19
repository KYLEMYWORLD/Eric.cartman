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
                textBox1.AppendText("Down：" + MousePosition.X + "," + MousePosition.Y);
            }
        }

        private void AddNewLineBtn_Click(object sender, EventArgs e)
        {
            IsNewLine = true;
        }

        LineModule line;

        private void MapConfigPB_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsNewLine)
            {
                LineEndP = new Point(e.X, e.Y);
                _lineModule.Add(line = new LineModule(LineStartP, LineEndP));
                textBox1.AppendText("Up：" + MousePosition.X + "," + MousePosition.Y);
                IsNewLine = false;
            }else if (IsNewSite)
            {

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
            line.AddSitePos(int.Parse(SiteIDTB.Text), int.Parse(SiteRateTB.Text),
                SiteDirecationCB.SelectedIndex,(SiteType) SiteTypeCB.SelectedIndex, SiteNameTB.Text,SiteUpNameTB.Text);
        }

        private void MapConfigPB_MouseMove(object sender, MouseEventArgs e)
        {
            LineEndP = new Point(e.X,e.Y);
        }

        private void MapTimer_Tick(object sender, EventArgs e)
        {
            MapTimer.Enabled = false;
            MapConfigPB.Invalidate();
            MapTimer.Enabled = true;
        }

    }
}
