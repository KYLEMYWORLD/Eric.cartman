using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLHelper
{
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
        public String _pointName { set; get; }

        /// <summary>
        /// 站点上方信息
        /// </summary>
        public String _pointUpName { set; get; }

        private int _rate;

        public int _direction;

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
        public SiteData(int id,int rate,int direction, String name ="",String upname="")
        {
            _pointId = id;
            _rate = rate;
            _direction = direction;
            _pointName = name;
            _pointUpName = upname;
        }
    }
}
