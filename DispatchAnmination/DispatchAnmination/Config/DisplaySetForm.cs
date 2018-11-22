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

        public static DisplaySetForm NewInstance()
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

        private void IsShowHeadTialSiteCB_CheckedChanged(object sender, EventArgs e)
        {
            ConstBA.IsShow_HeadTialSite = IsShowHeadTialSiteCB.Checked;
        }

        private void IsShowWaiteSiteCB_CheckedChanged(object sender, EventArgs e)
        {
            ConstBA.IsShow_WaiteSite = IsShowWaiteSiteCB.Checked;
        }

        private void IsShowSwerveSiteCB_CheckedChanged(object sender, EventArgs e)
        {
            ConstBA.IsShow_SwerveSite = IsShowSwerveSiteCB.Checked;
        }

        private void IsShowTrunRoundSiteCB_CheckedChanged(object sender, EventArgs e)
        {
            ConstBA.IsShow_TrunRoundSite = IsShowTrunRoundSiteCB.Checked;
        }

        private void IsShowChargeSiteCB_CheckedChanged(object sender, EventArgs e)
        {
            ConstBA.IsShow_ChargeSite = IsShowChargeSiteCB.Checked;
        }

        private void IsShowTrafficSiteCB_CheckedChanged(object sender, EventArgs e)
        {
            ConstBA.IsShow_TrafficSite = IsShowTrafficSiteCB.Checked;
        }

        private void IsShowNotTrafficSiteCB_CheckedChanged(object sender, EventArgs e)
        {
            ConstBA.IsShow_NotTrafficSite = IsShowNotTrafficSiteCB.Checked;
        }

        private void IsShowSiteFinishCB_CheckedChanged(object sender, EventArgs e)
        {
            ConstBA.IsShow_FinishSite = IsShowSiteFinishCB.Checked;
        }

        private void IsShowIncreCB_CheckedChanged(object sender, EventArgs e)
        {
            ConstBA.IsShow_IncreSite = IsShowIncreCB.Checked;
        }
    }
}
