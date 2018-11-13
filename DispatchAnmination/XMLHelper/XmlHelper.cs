using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLHelper
{
    public class XmlHelper
    {
        private XmlDocument _xmldoc;

        public XmlHelper()
        {

        }

        public void CreateOrLoadXMLFile(String fileName = "conf.xml")
        {
            if (!File.Exists(fileName))
            {
                XmlDocument xmldoc = new XmlDocument();
                //加入XML的声明段落,<?xml version="1.0" encoding="gb2312"?>
                XmlDeclaration xmldecl;
                xmldecl = xmldoc.CreateXmlDeclaration("1.0", "gb2312", null);
                xmldoc.AppendChild(xmldecl);

                //加入一个根元素
                XmlElement xmlelem = xmldoc.CreateElement("", "conf", "");
                xmldoc.AppendChild(xmlelem);
                //保存创建好的XML文档
                xmldoc.Save(fileName);

            }
            _xmldoc = new XmlDocument();
            _xmldoc.Load(fileName);
        }

        public void SaveXMLFile(String fileName = "conf.xml")
        {
            _xmldoc.Save(fileName);
        }

        public XmlElement GetXmlElementById(String elementid)
        {
            return _xmldoc.GetElementById(elementid);
        }

        public XmlNodeList GetXmlNodeList(String elemengName)
        {
            return _xmldoc.GetElementsByTagName(elemengName);
        }

        public String GetAttributeValue(XmlElement xmlElement,String name)
        {
            return xmlElement.GetAttribute(name);
        }

        public void SetAttributeValue(XmlElement xmlElement,String name ,String value)
        {
            xmlElement.SetAttribute(name, value);
        }

        public void AddElement(XmlElement xmlElement,XmlElement xml)
        {
            xmlElement.AppendChild(xml);
        }

        public XmlElement CreateElement(String name)
        {
            return _xmldoc.CreateElement(name);
        }

        public void AddToNode(XmlElement xml)
        {
            _xmldoc.SelectSingleNode("conf").AppendChild(xml);

        }

        /// <summary>
        /// 测试专用
        /// </summary>
        public void Test()
        {
            XmlDocument xmldoc = new XmlDocument();
            //加入XML的声明段落,<?xml version="1.0" encoding="gb2312"?>
            XmlDeclaration xmldecl;
            xmldecl = xmldoc.CreateXmlDeclaration("1.0", "gb2312", null);
            xmldoc.AppendChild(xmldecl);

            //加入一个根元素
            XmlElement xmlelem = xmldoc.CreateElement("", "Employees", "");
            xmldoc.AppendChild(xmlelem);
            //加入另外一个元素
            for (int i = 1; i < 3; i++)
            {

                XmlNode root = xmldoc.SelectSingleNode("Employees");//查找<Employees>
                XmlElement xe1 = xmldoc.CreateElement("Node");//创建一个<Node>节点
                xe1.SetAttribute("genre", "李赞红");//设置该节点genre属性
                xe1.SetAttribute("ISBN", "2-3631-4");//设置该节点ISBN属性

                XmlElement xesub1 = xmldoc.CreateElement("title");
                xesub1.InnerText = "CS从入门到精通";//设置文本节点
                xe1.AppendChild(xesub1);//添加到<Node>节点中
                XmlElement xesub2 = xmldoc.CreateElement("author");
                xesub2.InnerText = "候捷";
                xe1.AppendChild(xesub2);
                XmlElement xesub3 = xmldoc.CreateElement("price");
                xesub3.InnerText = "58.3";
                xe1.AppendChild(xesub3);
                root.AppendChild(xe1);//添加到<Employees>节点中
                
            }
            
            //保存创建好的XML文档
            xmldoc.Save("data.xml");
        }
    }
}
