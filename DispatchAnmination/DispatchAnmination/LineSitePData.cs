using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XMLHelper;

namespace DispatchAnmination
{
    /// <summary>
    /// 线路站点，地图坐标范围
    /// 根据AGV所在站点获取所在地图线路站点的位置
    /// </summary>
    public class LineDateCenter
    {
        /// <summary>
        /// 线路列表
        /// </summary>
        public static List<Line> _linesPositive = new List<Line>();
        public static List<Line> _linesNagetivie = new List<Line>();

        /// <summary>
        /// 获取AGV所在的地标
        /// </summary>
        /// <param name="lineid"></param>
        /// <param name="rate"></param>
        /// <returns></returns>
        public static MPoint GetMPointOnLine(int lineid,int rate)
        {
            foreach(Line line in _linesPositive)
            {
                if(line.LineID == lineid)
                {
                    return line.GetPositionPOnRate(rate);
                }
            }

            return null;
        }
        private static MPoint FirstP,SecconP;
        private static Boolean First = true;
        public static void AddLineData()
        {
            foreach(LineModule lineM in ModuleControl._lineModules)
            {
                //有站点
                if(lineM.SitePos != null && lineM.SitePos.Count()>0)
                {
                    foreach (SitePos site in lineM.SitePos)
                    {
                        if (First)
                        {

                            if (site._rate == 0)
                            {
                                FirstP = new MPoint(site._siteP.X, site._siteP.Y);
                                
                            }
                            else
                            {
                                FirstP = new MPoint(lineM._centerP.X, lineM._centerP.Y);
                                SecconP = new MPoint(site._siteP.X, site._siteP.Y);
                            }
                            First = false;
                        }
                        if (site._direction == (int)Direction.positive || site._direction == (int)Direction.both)//正卡
                        {
                            Line line = new Line();
                            line.Direction = Direction.positive;
                            line.LineID = site.ID;
                            line.AddPoint(new MPoint(site._siteP.X, site._siteP.Y));
                            if (_linesPositive.Count() > 0)
                            {
                                _linesPositive[_linesPositive.Count() - 1].AddPoint(new MPoint(site._siteP.X, site._siteP.Y));
                            }
                            _linesPositive.Add(line);
                        }

                        if (site._direction == (int)Direction.negative || site._direction == (int)Direction.both)//反卡
                        {
                            Line line = new Line();
                            line.Direction = Direction.positive;
                            line.LineID = site.ID;
                            line.AddPoint(new MPoint(site._siteP.X, site._siteP.Y));
                            if (_linesNagetivie.Count() > 0)
                            {
                                _linesNagetivie[_linesNagetivie.Count() - 1].AddPoint(new MPoint(site._siteP.X, site._siteP.Y));
                            }
                            _linesNagetivie.Add(line);
                        }
                    }
                }
                else//没站点，只是一条线
                {
                    if (_linesPositive.Count() > 0)
                    {
                        _linesPositive[_linesPositive.Count()-1].AddPoint(new MPoint(lineM._centerP.X, lineM._centerP.Y));
                        _linesPositive[_linesPositive.Count()- 1].AddPoint(new MPoint(lineM._endP.X, lineM._endP.Y));

                    }
                    else if (_linesNagetivie.Count() > 0)
                    {

                    }
                }
                
            }

            //处理第一个点和最后一个点连起来
            if (FirstP != null) _linesPositive[_linesPositive.Count() - 1].AddPoint(FirstP);
            if (SecconP != null) _linesPositive[_linesPositive.Count() - 1].AddPoint(SecconP);
        }
    }

    /// <summary>
    /// 站点对应的后面线路
    /// </summary>
    public class Line
    {
        /// <summary>
        /// 地标
        /// </summary>
        public int LineID { set; get; }
        /// <summary>
        /// 地标的正负信息
        /// 0 负卡 1 正卡 2正负卡
        /// </summary>
        internal Direction Direction { set; get; }
        public int Lenght { set; get; }
        public List<MPoint> _points = new List<MPoint>();
        public void AddPoint(MPoint point)
        {
            point.ID = _points.Count();
            _points.Add(point);
            if (_points.Count > 1)
            {
                Lenght = Lenght + Line.GetLenght(_points[_points.Count() - 2], _points[_points.Count() - 1]);
            }
        }

        /// <summary>
        /// 获取两点间的距离
        /// </summary>
        /// <returns></returns>
        public static int GetLenght(MPoint p1, MPoint p2)
        {
            int x = p1.x - p2.x;
            int y = p1.y - p2.y;
            return (int)Math.Sqrt((double)(x * x) + (double)(y * y));
        }


        /// <summary>
        /// 根据百分比获取当前所在地方地标
        /// </summary>
        /// <param name="rate"></param>
        public MPoint GetPositionPOnRate(int rate)
        {
            int rateleng = (int)(rate / (float)100 * (float)Lenght);
            foreach (MPoint p in _points)
            {
                if (p.ID==0)
                {continue;}
                else
                {
                    int len = Line.GetLenght(_points[p.ID - 1], p);
                    rateleng = rateleng - len;
                    if(rateleng > 0)//还需判断下个点
                    {
                        continue;
                    }
                    else
                    {
                        rateleng = rateleng + len;//源剩下长度

                        double rateP =Convert.ToDouble(rateleng) / Convert.ToDouble(len);
                        return GetMP(rateP, _points[p.ID - 1], p);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public MPoint GetMP(double rate, MPoint p1, MPoint p2)
        {
            int x = ((int)((double)rate * (p2.x - p1.x)) + p1.x);
            int y = ((int)((double)rate * (p2.y - p1.y)) + p1.y);
            return new MPoint(x, y);
        }
    }

    

    /// <summary>
    /// 地图上的坐标点
    /// </summary>
    public class MPoint
    {
        /// <summary>
        /// 
        /// </summary>
        internal int id { set; get; }
        public int ID
        {
            set
            {
                id = value; 
            }
            get
            {
                return id;
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public MPoint(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        internal int x { set; get; }
        internal int y { set; get; }
    }

    /// <summary>
    /// 正负卡常量
    /// </summary>
    enum Direction : int
    {
        /// <summary>
        /// 负卡
        /// </summary>
        negative = 0,
        /// <summary>
        /// 正卡
        /// </summary>
        positive = 1,
        /// <summary>
        /// 正负卡
        /// </summary>
        both = 2
    }
}
