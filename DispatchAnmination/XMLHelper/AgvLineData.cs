using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLHelper
{
    public class AgvLineData
    {
        public int NowSite;
        public bool IsSpecial;
        public int DesSite;
        public List<AgvPoint> Points = new List<AgvPoint>();

        public int Lenght { set; get; }
        
        public void AddPoint(AgvPoint point)
        {
            Points.Add(point);
            if (Points.Count > 1)
            {
                Lenght += GetLenght(Points[Points.Count - 1], point);
            }
        }
        /// <summary>
        /// 获取两点间的距离
        /// </summary>
        /// <returns></returns>
        public int GetLenght(AgvPoint p1, AgvPoint p2)
        {
            int x = p1.X - p2.X;
            int y = p1.Y - p2.Y;
            return (int)Math.Sqrt((double)(x * x) + (double)(y * y));
        }

        private bool FirstP = false;
        private int Index = 0;
        /// <summary>
        /// 根据百分比获取当前所在地方地标
        /// </summary>
        /// <param name="rate"></param>
        public AgvPoint GetPositionPOnRate(float rate)
        {
            int rateleng = (int)(rate / (float)100 * (float)Lenght);
            foreach (AgvPoint p in Points)
            {
                if (Index==0)
                {
                    Index = 1;
                    continue;
                }
                else
                {
                    int len = GetLenght(Points[Index - 1], p);
                    rateleng = rateleng - len;
                    if (rateleng > 0)//还需判断下个点
                    {
                        Index++;
                        continue;
                    }
                    else
                    {
                        rateleng = rateleng + len;//源剩下长度
                        double rateP = Convert.ToDouble(rateleng) / Convert.ToDouble(len);
                        Index = 0;
                        return GetMP(rateP, Points[Index - 1], p);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 根据百分比获取两个点直接的百分比的坐标值
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public AgvPoint GetMP(double rate, AgvPoint p1, AgvPoint p2)
        {
            int x = ((int)((double)rate * (p2.X - p1.X)) + p1.X);
            int y = ((int)((double)rate * (p2.Y - p1.Y)) + p1.Y);
            return new AgvPoint { X=x,Y=y};
        }
    }


    public class AgvPoint
    {
        public int X;
        public int Y;
    }
}
