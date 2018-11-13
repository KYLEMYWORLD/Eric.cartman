using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using XMLHelper;

namespace DispatchAnmination
{
    /// <summary>
    /// 模型数据控制类
    /// 用于转换xml数据到对应的Module数据
    /// </summary>
    public class ModuleControl
    {
        internal static List<AgvModule> _agvModules = new List<AgvModule>();

        internal static List<PlcModule> _plcModules = new List<PlcModule>();

        internal static List<LineModule> _lineModules= new List<LineModule>();

        private static MPoint point;
        /// <summary>
        /// 更新AGV当前所在位置
        /// </summary>
        /// <param name="name"></param>
        /// <param name="siteid"></param>
        /// <param name="rate"></param>
        public static void UpdateAgvSite(String name, int siteid, int rate)
        {
            AgvModule agv = _agvModules.Find(c => { return c._name.Equals(name); });
            if (agv != null)
            {
                point = LineDateCenter.GetMPointOnLine(siteid, rate);
                if(point != null)
                {
                    agv.update(new Point(point.x, point.y));
                }
            }
        }

        public static void AddAgvToModule(List<AgvData> agvDatas)
        {
            MPoint p = LineDateCenter.GetMPointOnLine(23, 0);
            MPoint p2 = LineDateCenter.GetMPointOnLine(34, 25);
            MPoint p3 = LineDateCenter.GetMPointOnLine(33, 100);

            if (p != null)
            {
                _agvModules.Add(new AgvModule("AGV001", new Point(p.x, p.y)));

            }
            if (p2 != null)
            {
                _agvModules.Add(new AgvModule("AGV002", new Point(p2.x, p2.y)));

            }
            if (p3 != null)
            {
                _agvModules.Add(new AgvModule("AGV003", new Point(p3.x, p3.y)));

            }
        }

        /// <summary>
        /// 将XML配置文档解析到线路配置添加到地图中
        /// </summary>
        /// <param name="lineDatas"></param>
        public static void AddLinesToModule(List<LineData> lineDatas)
        {
            foreach (LineData data in lineDatas)
            {
                _lineModules.Add(new LineModule(data));
            }
        }
    }

    /// <summary>
    /// 模型抽象类
    /// </summary>
    public abstract class Module
    {
        /// <summary>
        /// 模型名称
        /// </summary>
        internal String _name;

        /// <summary>
        /// 模型中心点
        /// </summary>
        internal Point _centerP;

        /// <summary>
        /// 尺寸比例：默认1
        /// </summary>
        internal int _scale = 1;

        /// <summary>
        /// 默认尺寸
        /// </summary>
        internal int _size = 20;

        /// <summary>
        /// 文字描述点
        /// </summary>
        internal Point _describP;

        /// <summary>
        /// 画笔
        /// </summary>
        internal Pen _pen = new Pen(new SolidBrush(Color.Black));

        internal Brush _brush = new SolidBrush(Color.Black);
        internal Brush _brushRed = new SolidBrush(Color.OrangeRed);

        internal Font _font = new Font("宋体", 10);
        internal Font _fontMin = new Font("宋体", 8);
        internal Font _fontMax = new Font("宋体", 15);

        /// <summary>
        /// 更新模型中心点
        /// </summary>
        /// <param name="centerPoint"></param>
        public abstract void update(Point centerPoint);

        /// <summary>
        /// 将模型画用GUI画出来
        /// </summary>
        /// <param name="g">GUI绘画图面</param>
        public abstract void Draw(Graphics g);
    }
}
