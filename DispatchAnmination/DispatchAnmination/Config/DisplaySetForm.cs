using DispatchAnmination.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispatchAnmination.Config
{
    public partial class DisplaySetForm : Form
    {
        private static DisplaySetForm _DisplaSetForm;
        public DisplaySetForm()
        {
            InitializeComponent();
        }

        public static DisplaySetForm newInstance()
        {
            if(_DisplaSetForm==null || _DisplaSetForm.IsDisposed)
            {
                _DisplaSetForm = new DisplaySetForm();
            }
            return _DisplaSetForm;
        }
        /// <summary>
        /// 是否展示站点名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsShowSiteNameCB_CheckedChanged(object sender, EventArgs e)
        {
            ConstBA.IsShow_SiteName = IsShowSiteNameCB.Checked;
        }

        private void IsShowSitePointCB_CheckedChanged(object sender, EventArgs e)
        {
            ConstBA.IsShow_SitePoint = IsShowSitePointCB.Checked;
        }

        private void IsShowSiteUpCB_CheckedChanged(object sender, EventArgs e)
        {
            ConstBA.IsShow_SiteUpName = IsShowSiteUpCB.Checked;

        }

        private void IsShowSiteCB_CheckedChanged(object sender, EventArgs e)
        {
            ConstBA.IsShow_Site = IsShowSiteCB.Checked;
        }

        private void DisplaySetForm_Load(object sender, EventArgs e)
        {
            IsShowSiteUpCB.Checked = ConstBA.IsShow_SiteUpName;
            IsShowSiteCB.Checked = ConstBA.IsShow_Site; 
            IsShowSitePointCB.Checked = ConstBA.IsShow_SitePoint;
            IsShowSiteNameCB.Checked = ConstBA.IsShow_SiteName;
        }
    }
}
