using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DispatchAnmination
{
    /// <summary>
    /// AGV模型
    /// 长方形：100 x 200
    /// </summary>
    public class AgvModule : Module
    {

        /// <summary>
        /// AGV的线条
        /// </summary>
        private Point[] _lines;

        /// <summary>
        /// AGV的左右轮子
        /// </summary>
        private Rectangle[] _rectangle;

        /// <summary>
        /// 当前站点
        /// </summary>
        public int Site;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="centerPoint"></param>
        public AgvModule(String name, Point centerPoint,int site)
        {
            _name = name;

            _centerP = centerPoint;

            _pen = new Pen(new SolidBrush(Color.Black));

            _lines = new Point[5];

            _rectangle = new Rectangle[2];

            Site = site;

            update(centerPoint);
        }
        /// <summary>
        /// 更新模型中心点,同时更新其他边线的点位置
        /// </summary>
        /// <param name="centerPoint"></param>
        public override void update(Point centerPoint)
        {
            _centerP = centerPoint;
            //左上点
            _lines[0].X = _centerP.X - _size * _scale;
            _lines[0].Y = _centerP.Y - _size * _scale;

            //左下点
            _lines[1].X = _centerP.X - _size * _scale;
            _lines[1].Y = _centerP.Y + _size * _scale;

            //右下点
            _lines[2].X = _centerP.X + _size * _scale;
            _lines[2].Y = _centerP.Y + _size * _scale;

            //右上点
            _lines[3].X = _centerP.X + _size * _scale;
            _lines[3].Y = _centerP.Y - _size * _scale;

            //左上点
            _lines[4] = _lines[0];


            //左轮子
            _rectangle[0].X = _centerP.X - _size * _scale;
            _rectangle[0].Y = _centerP.Y + _size * _scale;
            _rectangle[0].Width = _size * _scale / 2;
            _rectangle[0].Height = _size * _scale / 2;

            //右轮子
            _rectangle[1].X = _centerP.X + _size * _scale / 2;
            _rectangle[1].Y = _centerP.Y + _size * _scale;
            _rectangle[1].Width = _size * _scale / 2;
            _rectangle[1].Height = _size * _scale / 2;

            //模型描述文字中心点
            _describP.X = _centerP.X - _size * _scale;
            _describP.Y = _centerP.Y + 2 * _size * _scale;
        }

        /// <summary>
        /// 将模型画用GUI画出来
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            g.DrawLines(_pen, _lines);

            g.DrawEllipse(_pen, _rectangle[0]);

            g.DrawEllipse(_pen, _rectangle[1]);

            g.DrawString(_name, _font, Brushes.Black, _describP);
        }
    }
}
