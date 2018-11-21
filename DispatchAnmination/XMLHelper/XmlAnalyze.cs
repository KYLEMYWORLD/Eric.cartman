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

            AgvLineList = new List<AgvLineData>();
        }

        /// <summary>
        /// 解析文档，初始化图像数据
        /// </summary>
        public void DoAnalyze(string fileName = "conf.xml")//"mapconf.xml" 地图配置保存的文件明
        {
            _xmlHepler.CreateOrLoadXMLFile(fileName);
            if (_xmlHepler.GetXmlNodeList("Lines").Count == 0)
            {
                XmlElement lines = _xmlHepler.CreateElement("Lines");
                lines.SetAttribute("id", "lines");
                _xmlHepler.AddToNode("Config", lines);
                _xmlHepler.SaveXMLFile(fileName);
                _xmlHepler.CreateOrLoadXMLFile(fileName);
            }
            if (_xmlHepler.GetXmlNodeList("AgvLine").Count == 0)
            {
                CreateAgvLineNote();
                _xmlHepler.SaveXMLFile(fileName);
                _xmlHepler.CreateOrLoadXMLFile(fileName);
            }

            AnalyzeLineMoveSize(_xmlHepler.GetXmlNodeList("Size"));
            AnalyzeLines(_xmlHepler.GetXmlNodeList("Line"));
            AnalyzeAgvLine(_xmlHepler.GetXmlNodeList("AgvLine"));
        }

        /// <summary>
        /// 用于AGV线路配置
        /// </summary>
        /// <param name="fileName"></param>
        public void DoAgvLineAnalyze(string fileName = "conf.xml")
        {
            _xmlHepler.CreateOrLoadXMLFile(fileName);
            if (_xmlHepler.GetXmlNodeList("AgvLine").Count == 0)
            {
                CreateAgvLineNote();
                _xmlHepler.SaveXMLFile(fileName);
                _xmlHepler.CreateOrLoadXMLFile(fileName);
            }
            AnalyzeAgvLine(_xmlHepler.GetXmlNodeList("AgvLine"));
        }
        private void CreateAgvLineNote()
        {
            XmlElement agvlines = _xmlHepler.CreateElement("AgvLines");
            agvlines.SetAttribute("id", "agvlines");
            _xmlHepler.AddToNode("Config", agvlines);
        }

        public List<AgvLineData> AgvLineList;
        /// <summary>
        /// 解析Agv行走线路
        /// </summary>
        /// <param name="agvLineList"></param>
        public void AnalyzeAgvLine(XmlNodeList agvLineList)
        {
            if (agvLineList.Count == 0) return;
            AgvLineList.Clear();
            foreach (XmlElement a in agvLineList)
            {
                int nowsite = int.Parse(a.GetAttribute("nowsite"));
                int isspecial = int.Parse(a.GetAttribute("isspecial"));
                int dessite = int.Parse(a.GetAttribute("dessite"));
                float movesize = float.Parse(a.GetAttribute("movesize"));
                AgvLineData agvLineData = new AgvLineData
                {
                    NowSite = nowsite,
                    IsSpecial = isspecial == 1 ? true : false,
                    DesSite = dessite,
                    MoveSize = movesize
                };

                XmlNodeList points = a.GetElementsByTagName("Point");
                if (points != null)
                {
                    foreach (XmlElement p in points)
                    {
                        int x = int.Parse(p.GetAttribute("x"));
                        int y = int.Parse(p.GetAttribute("y"));
                        agvLineData.AddPoint(new AgvPoint { X = x, Y = y });
                    }
                }
                AgvLineList.Add(agvLineData);
            }
        }

        public void AnalyzeLineMoveSize(XmlNodeList nodeList)
        {
            if (nodeList.Count == 0) return;
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
            if (lineXml.Count == 0) return;
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
        /// <summary>
        /// 保存线路信息
        /// </summary>
        public void SaveLineToFile(List<LineData> lineDatas)
        {
            XmlElement linex = _xmlHepler.GetSingleElement("Config/Lines");
            if (linex != null)
            {
                linex.RemoveAll();
                _xmlHepler.SaveXMLFile("mapconf.xml");
                DoAnalyze("mapconf.xml");
                linex = _xmlHepler.GetSingleElement("Config/Lines");
            }

            foreach (var line in lineDatas)
            {
                XmlElement lineX = _xmlHepler.CreateElement("Line");
                lineX.SetAttribute("startx", line._startX + "");
                lineX.SetAttribute("starty", line._startY + "");
                lineX.SetAttribute("endx", line._endX + "");
                lineX.SetAttribute("endy", line._endY + "");
                lineX.SetAttribute("id", line._id + "");
                foreach(var site in line._siteDatas)
                {
                    XmlElement siteX = _xmlHepler.CreateElement("Site");
                    siteX.SetAttribute("id",site.Id+"");
                    siteX.SetAttribute("name", site._pointName);
                    siteX.SetAttribute("upname", site._pointUpName);
                    siteX.SetAttribute("rate", site.Rate+"");
                    siteX.SetAttribute("direction", site._direction+"");
                    siteX.SetAttribute("type", (int)site._siteType+"");
                    lineX.AppendChild(siteX);
                }
                _xmlHepler.AddToNode("Config/Lines", lineX);
            }

            _xmlHepler.SaveXMLFile("mapconf.xml");
        }

        public void SaveMapConfigFile(string filename = "mapconf.xml")
        {
            _xmlHepler.SaveXMLFile(filename);
        }

        public void SaveAgvLineToFile(List<AgvLineData> agvLine)
        {
            XmlElement agvlines = _xmlHepler.GetSingleElement("Config/AgvLines");
            if (agvlines == null)
            {
                CreateAgvLineNote();
            }
            else
            {
                agvlines.RemoveAll();
                _xmlHepler.SaveXMLFile("conf.xml");
                DoAgvLineAnalyze();
                agvlines = _xmlHepler.GetSingleElement("Config/AgvLines");
            }
            foreach(AgvLineData line in agvLine)
            {
                XmlElement agvline = _xmlHepler.CreateElement("AgvLine");
                agvline.SetAttribute("nowsite", line.NowSite + "");
                agvline.SetAttribute("isspecial", line.IsSpecial ? "1" : "0");
                agvline.SetAttribute("dessite", line.DesSite + "");
                agvline.SetAttribute("movesize", line.MoveSize + "");
                foreach(AgvPoint p in line.Points)
                {
                    XmlElement point = _xmlHepler.CreateElement("Point");
                    point.SetAttribute("x", p.X + "");
                    point.SetAttribute("y", p.Y + "");
                    agvline.AppendChild(point);
                }
                _xmlHepler.AddToNode("Config/AgvLines", agvline);
            }
            _xmlHepler.SaveXMLFile("conf.xml");
        }
    }
}
