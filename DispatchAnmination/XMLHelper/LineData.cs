using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLHelper
{
    /// <summary>
    /// 线路数据结构
    /// </summary>
    public class LineData
    {
        /// <summary>
        /// 线路起点X
        /// </summary>
        public int _startX { internal set; get; }

        /// <summary>
        /// 线路起点Y
        /// </summary>
        public int _startY { internal set; get; }

        /// <summary>
        /// 线路终点X
        /// </summary>
        public int _endX { internal set; get; }

        /// <summary>
        /// 线路终点Y
        /// </summary>
        public int _endY { internal set; get; }

        /// <summary>
        /// 线路ID
        /// </summary>
        public int _id { internal set; get; }

        /// <summary>
        /// 站点列表
        /// </summary>
        public List<SiteData> _siteDatas { internal set; get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="startx">线路起点X</param>
        /// <param name="starty">线路起点Y</param>
        /// <param name="endx">线路终点X</param>
        /// <param name="endy">线路终点Y</param>
        public LineData(int startx,int starty,int endx,int endy,int id)
        {
            _startX = startx;
            _startY = starty;
            _endX = endx;
            _endY = endy;
            _id = id;
            _siteDatas = new List<SiteData>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteData"></param>
        public void AddSite(SiteData siteData)
        {
            _siteDatas.Add(siteData);
        }

    }
}
