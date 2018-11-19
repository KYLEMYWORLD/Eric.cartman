using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLHelper
{
    /// <summary>
    /// 解析XML配置文档
    /// </summary>
    public class XmlAnalyze
    {
        /// <summary>
        /// xml解析类
        /// </summary>
        private XmlHelper _xmlHepler;

        /// <summary>
        /// 线路转换后的信息
        /// </summary>
        public List<LineData> _lineDatas { get; set; }

        
        /// <summary>
        /// 构造函数
        /// </summary>
        public XmlAnalyze()
        {
            _xmlHepler = new XmlHelper();

            _lineDatas = new List<LineData>();
        }

        /// <summary>
        /// 解析文档，初始化图像数据
        /// </summary>
        public void DoAnalyze()
        {
            _xmlHepler.CreateOrLoadXMLFile();
            AnalyzeLineMoveSize(_xmlHepler.GetXmlNodeList("Size"));
            AnalyzeLines(_xmlHepler.GetXmlNodeList("Line"));


        }
        public void AnalyzeLineMoveSize(XmlNodeList nodeList)
        {
            if (nodeList == null) return;
            LineMoveSize._lineMoveSize.Clear();
            foreach (XmlElement size in nodeList)
            {
                int id = int.Parse(size.GetAttribute("id"));
                float value = float.Parse(size.GetAttribute("value"));
                LineMoveSize._lineMoveSize.Add(new LineMoveSize(id, value));
            }
        }

        /// <summary>
        /// 解析线路信息XML
        /// </summary>
        public void AnalyzeLines(XmlNodeList lineXml)
        {
            if (lineXml == null) return;
            foreach(XmlElement e in lineXml)
            {
                int startx = int.Parse(e.GetAttribute("startx"));
                int starty = int.Parse(e.GetAttribute("starty"));
                int endx = int.Parse(e.GetAttribute("endx"));
                int endy = int.Parse(e.GetAttribute("endy"));
                int id = int.Parse(e.GetAttribute("id"));
                LineData lineData = new LineData(startx, starty, endx, endy, id);

                XmlNodeList nodeList =  e.GetElementsByTagName("Site");
                if(nodeList != null)
                {
                    foreach(XmlElement s in nodeList)
                    {
                        int sid = int.Parse(s.GetAttribute("id"));
                        string name = s.GetAttribute("name");
                        string upname = s.GetAttribute("upname");
                        int rate = int.Parse(s.GetAttribute("rate"));
                        int direction = int.Parse(s.GetAttribute("direction"));
                        int type = int.Parse(s.GetAttribute("type"));
                        lineData.AddSite(new SiteData(sid,rate,direction,type,name,upname));
                    }
                }

                _lineDatas.Add(lineData);
            }
        }
    }
}
