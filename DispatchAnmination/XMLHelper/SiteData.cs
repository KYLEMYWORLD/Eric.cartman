using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLHelper
{
    public enum SiteType
    {
        /// <summary>
        /// 窑头，窑尾地标
        /// </summary>
        HeadTialSite = 0,
        /// <summary>
        /// 等待点
        /// </summary>
        WaiteSite = 1,

        /// <summary>
        /// 转弯点
        /// </summary>
        SwerveSite = 2,

        /// <summary>
        /// 充电完成回来掉头点
        /// </summary>
        TrunRoundSite = 3,

        /// <summary>
        /// 充电点
        /// </summary>
        ChargeSite = 4,

        /// <summary>
        /// 交通管制点
        /// </summary>
        TrafficSite =5,

        /// <summary>
        /// 非交通管制点
        /// </summary>
        NotTrafficSite = 6
    }

    /// <summary>
    /// 站点信息结构
    /// </summary>
    public class SiteData
    {
        private int _pointId;
        /// <summary>
        /// 站点ID
        /// </summary>
        public int Id {
            set { _pointId = value; }
            get { return _pointId; }
        }

        /// <summary>
        /// 站点名称
        /// </summary>
        public string _pointName { set; get; }

        /// <summary>
        /// 站点上方信息
        /// </summary>
        public string _pointUpName { set; get; }

        private int _rate;

        public int _direction;

        public SiteType _siteType;

        /// <summary>
        /// 站点在线上的比例(0-100)
        /// 0 在线路起点
        /// 100 在线路终点
        /// </summary>
        public int Rate {
            set
            {
                if (value < 0)
                {
                    _rate = 0;
                }
                else if (value > 100)
                {
                    _rate = 100;
                }
            }
            get {
                return _rate;
            }
        }
        /// <summary>
        /// 站点无参构造函数
        /// </summary>
        public SiteData() { }

        /// <summary>
        /// 站点有参构造函数
        /// </summary>
        /// <param name="x">地标点X</param>
        /// <param name="y">地标点Y</param>
        /// <param name="id">地标ID</param>
        /// <param name="name">地标名称</param>
        public SiteData(int id,int rate,int direction,int sitetype, string name ="",string upname="")
        {
            _pointId = id;
            _rate = rate;
            _direction = direction;
            _pointName = name;
            _pointUpName = upname;

            _siteType = (SiteType)sitetype;
        }
    }
}
