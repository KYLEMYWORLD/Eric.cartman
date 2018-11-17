using DispatchAnmination.Const;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using XMLHelper;

namespace DispatchAnmination
{
    /// <summary>
    /// 线路模型
    /// 包含：线路起点，线路终点，行车方向，站点
    /// </summary>
    public class LineModule : Module
    {
        /// <summary>
        /// 线路终点
        /// </summary>
        internal Point _endP;

        /// <summary>
        /// 站点信息
        /// </summary>
        private List<SitePos> _sitePos;

        public List<SitePos> SitePos
        {
            get
            {
                return _sitePos;
            }
        }
        /// <summary>
        /// 站点圆直径
        /// </summary>
        private int _siteCircleSize = 10;

        /// <summary>
        /// 线路初始画
        /// </summary>
        /// <param name="startP">线路开始点</param>
        /// <param name="endP">线路结束点</param>
        /// <param name="sitePosSize">站点个数</param>
        public LineModule(Point startP, Point endP)
        {
            _centerP = startP;
            _endP = endP;

            _sitePos = new List<SitePos>();
        }

        /// <summary>
        /// 将XML解析的XML数据解析为
        /// </summary>
        /// <param name="lineData"></param>
        public LineModule(LineData lineData)
        {
            _centerP = new Point(lineData._startX, lineData._startY);
            _endP = new Point(lineData._endX, lineData._endY);
            _sitePos = new List<SitePos>();

            foreach(SiteData site in lineData._siteDatas)
            {
                AddSitePos(site.Id, site.Rate,site._direction, site._pointName,site._pointUpName);
            }
        }

        /// <summary>
        /// 添加站点
        /// </summary>
        /// <param name="index">第几个站点</param>
        /// <param name="name">站点名称</param>
        /// <param name="id">站点ID</param>
        /// <param name="rate">站点在线路上的位置比例(0-100)</param>
        public void AddSitePos(int id,int rate,int direction, String name ="站点",String upName = "")
        {
            _sitePos.Add(new SitePos(id, GetSiteP(rate), direction,rate, name,upName ));
        }

        public Point GetSiteP(int rate)
        {
            int x = ((int)((double)rate /100 * (_endP.X - _centerP.X))+_centerP.X);
            int y = ((int)((double)rate /100 * (_endP.Y - _centerP.Y)) +_centerP.Y);
            return new Point(x, y);
        }

        /// <summary>
        /// 将模型画用GUI画出来
        /// </summary>
        /// <param name="g">GUI绘画图面</param>
        public override void Draw(Graphics g)
        {
            g.DrawLine(_pen, _centerP, _endP);

            if (_sitePos.Count() > 0 && ConstBA.IsShow_Site)
            {
                foreach(SitePos site in _sitePos)
                {
                    g.FillEllipse(_brush,site._siteP.X - _siteCircleSize/2,site._siteP.Y - _siteCircleSize / 2, _siteCircleSize, _siteCircleSize);
                    if(ConstBA.IsShow_SitePoint) g.DrawString("(" + site._siteP.X + "," + site._siteP.Y + ")", _font, _brush, site._siteP.X - 10, site._siteP.Y - 40);
                    if(ConstBA.IsShow_SiteUpName) g.DrawString(site.UpName, _font, _brushRed, site._siteP.X -10, site._siteP.Y - 20);//+"("+ site._siteP.X+","+ site._siteP.Y+")"
                    if(ConstBA.IsShow_SiteName) g.DrawString(site.Name, _fontMin, _brush, site._siteP.X - 10, site._siteP.Y + 10);
                }
            }
        }

        public override void update(Point centerPoint)
        {

        }
    }

    /// <summary>
    /// 站点信息类
    /// </summary>
    public class SitePos
    {
        /// <summary>
        /// 正反卡
        /// </summary>
        internal int _direction;
        /// <summary>
        /// 站点位置
        /// </summary>
        internal Point _siteP { get; }

        /// <summary>
        /// 站点ID
        /// </summary>
        private int _id;
        public int ID
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// 站点名称
        /// </summary>
        private String _name;
        public String Name {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// 站点上方信息
        /// </summary>
        private String _upName;
        public String UpName
        {
            get
            {
                return _upName;
            }
        }

        public int _rate;

        public SitePos(int id, Point point, int direction, int rate, String name,String upName)
        {
            
            _id = id;

            _siteP = point;

            _direction = direction;

            _rate = rate;

            _name = name;

            _upName = upName;
        }
    }

}
