using System;
using System.Collections.Generic;
using System.Xml;

namespace KDTask.XML
{
    /// <summary>
    /// XML文件用于记录设备信息，和任务信息
    /// </summary>
    public class XMLMaster
    {
        public static XMLHelper XMLHelper;
        public static Devdefs Devdefs;
        public static Devs Devs;
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            XMLHelper = new XMLHelper();
            Devdefs = new Devdefs();
            Devs = new Devs();
            LoadAndAnalyze();
        }

        /// <summary>
        /// 保存文档
        /// </summary>
        public static void SaveAndReload()
        {
            XMLHelper.SaveXMLFile();
            LoadAndAnalyze();
        }

        /// <summary>
        /// 加载文档并解析
        /// </summary>
        public static void LoadAndAnalyze()
        {
            //加载文档
            XMLHelper.CreateOrLoadXMLFile();
            //解析设备信息
            Devdefs.Analyze(XMLHelper.GetXmlNodeList("Devdef"));
            Devs.Analyze(XMLHelper.GetXmlNodeList("Dev"));
        }

        /// <summary>
        /// 添加设备定义
        /// </summary>
        /// <param name="devdef">设备类型信息</param>
        public static void AddDevdef(Devdef devdef)
        {
            Devdefs.AddDevdef(devdef);
            SaveAndReload();
        }

        /// <summary>
        /// 修改设备定义的信息
        /// </summary>
        /// <param name="devdef">设备类型信息</param>
        public static void EditeDevdef(Devdef devdef)
        {
            Devdefs.EditeDevdef(devdef);
            SaveAndReload();
        }

        /// <summary>
        /// 添加设备信息
        /// </summary>
        /// <param name="dev">设备信息</param>
        public static void AddDev(Dev dev)
        {
            Devs.AddDev(dev);
            SaveAndReload();
        }
        
        /// <summary>
        /// 修改设备信息
        /// </summary>
        /// <param name="dev"></param>
        public static void EditeDev(Dev dev)
        {
            Devs.EditeDev(dev);
            SaveAndReload();
        }

        /// <summary>
        /// 添加设备属性
        /// </summary>
        /// <param name="devdefid">所属设备类型</param>
        /// <param name="devAtt">属性信息</param>
        public static void AddDevAtt(string devdefid, DevAtt devAtt)
        {
            Devdefs.AddDevAtt(devdefid, devAtt);
            SaveAndReload();
        }
        /// <summary>
        /// 修改设备属性
        /// </summary>
        /// <param name="devdefid">所属设备类型</param>
        /// <param name="devAtt">属性信息</param>
        public static void EditeDevAtt(string devdefid, DevAtt devAtt)
        {
            Devdefs.EditeDevAtt(devdefid, devAtt);
            SaveAndReload();
        }
        /// <summary>
        /// 添加属性字典值
        /// </summary>
        /// <param name="devdefid">所属设备类型</param>
        /// <param name="devattid">所属设备属性</param>
        /// <param name="attDic">字典信息</param>
        public static void AddAttDic(string devdefid,string devattid,AttDic attDic)
        {
            Devdefs.AddAttDic(devdefid, devattid, attDic);
            SaveAndReload();
        }
        /// <summary>
        /// 修改属性字典值
        /// </summary>
        /// <param name="devdefid">所属设备类型</param>
        /// <param name="devattid">所属设备属性</param>
        /// <param name="attDic">字典信息</param>
        public static void EditeAttDic(string devdefid,string devattid,AttDic attDic)
        {
            Devdefs.EditeAttDic(devdefid, devattid, attDic);
            SaveAndReload();
        }

    }

    /// <summary>
    /// 设备定义信息操作类
    /// </summary>
    public class Devdefs
    {
        
        public List<Devdef> _devdefs = new List<Devdef>();
        /// <summary>
        /// 解析XML的设备信息
        /// </summary>
        /// <param name="xmlNodeList"></param>
        internal void Analyze(XmlNodeList xmlNodeList)
        {
            _devdefs.Clear();
            if (xmlNodeList == null || xmlNodeList.Count==0)
            {
                Console.WriteLine("没有设备信息可以进行解析");
                return;
            }
            foreach (XmlElement e in xmlNodeList)
            {
                string id = e.GetAttribute("id");
                string name = e.GetAttribute("name");
                string connecttype = e.GetAttribute("connecttype");
                Devdef devdef = new Devdef(id, name, connecttype);
                foreach(XmlElement a in e.ChildNodes)
                {
                    string attid = a.GetAttribute("id");
                    string attname = a.GetAttribute("name");
                    int start = int.Parse(a.GetAttribute("start"));
                    int ent = int.Parse(a.GetAttribute("end"));
                    DevAtt devAtt = new DevAtt(attid, attname, start, ent);
                    foreach(XmlElement d in a.ChildNodes)
                    {
                        string key = d.GetAttribute("key");
                        string value = d.GetAttribute("value");
                        AttDic attDic = new AttDic(key, value);
                        devAtt.AddAttDic(attDic);
                    }
                    devdef.AddDevAtt(devAtt);
                }
                _devdefs.Add(devdef);
            }
        }


        /// <summary>
        /// 添加设备定义操作类
        /// </summary>
        /// <param name="devdef"></param>
        public void AddDevdef(Devdef devdef)
        {

            XmlElement devX = XMLMaster.XMLHelper._xmldoc.CreateElement("Devdef");
            devX.SetAttribute("id", devdef.ID);
            devX.SetAttribute("name", devdef.Name);
            devX.SetAttribute("connecttype", devdef.ConnetType);
            XMLMaster.XMLHelper.AddToNode("//Config/Devdefs", devX);
        }


        /// <summary>
        /// 添加设备定义
        /// </summary>
        /// <param name="devdef"></param>
        internal void AddDevAtt(string devdefid,DevAtt devatt)
        {

            XmlElement devattX = XMLMaster.XMLHelper._xmldoc.CreateElement("Att");

            devattX.SetAttribute("id", devatt.ID);
            devattX.SetAttribute("name", devatt.Name);
            devattX.SetAttribute("start", devatt.Start+"");
            devattX.SetAttribute("end", devatt.End+"");
            XMLMaster.XMLHelper.AddToNode("//Config/Devdefs/Devdef[@id='" + devdefid+"']", devattX);
        }

        /// <summary>
        /// 添加属性字典值
        /// </summary>
        /// <param name="devdefid">所属设备类型</param>
        /// <param name="devattid">所属设备属性</param>
        /// <param name="attDic">字典信息</param>
        internal void AddAttDic(string devdefid, string devattid, AttDic attDic)
        {
            XmlElement attDicX = XMLMaster.XMLHelper._xmldoc.CreateElement("Dic");

            attDicX.SetAttribute("key", attDic.Key);
            attDicX.SetAttribute("value", attDic.Value);
            XMLMaster.XMLHelper.AddToNode("//Config/Devdefs/Devdef[@id='" + devdefid + "']" +
                "/Att[@id='"+devattid+"']", attDicX);
        }

        /// <summary>
        /// 修改设备定义
        /// </summary>
        /// <param name="devdef"></param>
        public void EditeDevdef(Devdef devdef)
        {
            ////Config/Devdefs/Devdef[id='AGV']
            XmlElement devdefx = XMLMaster.XMLHelper.GetSingleNode("//Config/Devdefs/Devdef[@id='" + devdef.ID + "']");
            if (devdefx != null)
            {
                if (devdefx.GetAttribute("id").Equals(devdef.ID))
                {
                    devdefx.SetAttribute("name", devdef.Name);
                    devdefx.SetAttribute("connecttype", devdef.ConnetType);
                }
            }
        }

        /// <summary>
        /// 修改对应设备定义的属性
        /// </summary>
        /// <param name="devdevid"></param>
        /// <param name="devatt"></param>
        public void EditeDevAtt(string devdevid, DevAtt devatt)
        {
            
            XmlElement devattX= XMLMaster.XMLHelper.GetSingleNode("//Config/Devdefs/Devdef[@id='"
                + devdevid + "']/Att[@id='"+devatt.ID+"']");
            if (devattX != null)
            {
                devattX.SetAttribute("name", devatt.Name);
                devattX.SetAttribute("start", devatt.Start + "");
                devattX.SetAttribute("end", devatt.End + "");
            }
        }
        /// <summary>
        /// 修改属性字典值
        /// </summary>
        /// <param name="devdefid">所属设备类型</param>
        /// <param name="devattid">所属设备属性</param>
        /// <param name="attDic">字典信息</param>
        internal void EditeAttDic(string devdefid, string devattid, AttDic attDic)
        {
            XmlElement attdicX = XMLMaster.XMLHelper.GetSingleNode("//Config/Devdefs/Devdef[@id='" + devdefid + "']" +
                "/Att[@id='" + devattid + "']/Dic[@key='"+attDic.Key+"']");
            if (attdicX != null)
            {
                attdicX.SetAttribute("value", attDic.Value);
            }
        }

        /// <summary>
        /// 根据设备ID查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Devdef FindDevdef(string id)
        {
            return _devdefs.Find(c => { return c.ID == id; });
        }

        /// <summary>
        /// 获取设备ID名称队列
        /// </summary>
        /// <returns></returns>
        public string[] GetTypeStrings()
        {
            string[] types = new string[_devdefs.Count];
            for(int i =0; i<_devdefs.Count; i ++)
            {
                types[i] = _devdefs[i].ID;
            }

            return types;
        }
    }

    /// <summary>
    /// 设备信息操作类
    /// </summary>
    public class Devs
    {
        
        public List<Dev> _devs = new List<Dev>();
        /// <summary>
        /// 解析XML的设备信息
        /// </summary>
        /// <param name="xmlNodeList"></param>
        internal void Analyze(XmlNodeList xmlNodeList)
        {
            _devs.Clear();
            if (xmlNodeList == null || xmlNodeList.Count == 0)
            {
                Console.WriteLine("没有设备信息可以进行解析");
                return;
            }
            foreach (XmlElement e in xmlNodeList)
            {
                string id = e.GetAttribute("id");
                string name = e.GetAttribute("name");
                string type = e.GetAttribute("type");
                string ip = e.GetAttribute("ip");
                string port = e.GetAttribute("port");
                _devs.Add(new Dev(id, name, type, ip, port));
            }
        }


        /// <summary>
        /// 添加设备信息
        /// </summary>
        /// <param name="dev"></param>
        public void AddDev(Dev dev)
        {
            XmlElement devX = XMLMaster.XMLHelper._xmldoc.CreateElement("Dev");
            devX.SetAttribute("id", dev.ID);
            devX.SetAttribute("name", dev.Name);
            devX.SetAttribute("type", dev.Type);
            devX.SetAttribute("ip", dev.IP);
            devX.SetAttribute("port", dev.Port);
            XMLMaster.XMLHelper.AddToNode("//Config/Devs",devX);
        }

        /// <summary>
        /// 修改设备信息
        /// </summary>
        /// <param name="dev"></param>
        public void EditeDev(Dev dev)
        {
            XmlElement devx = XMLMaster.XMLHelper.GetSingleNode("//Config/Devs/Dev[@id='" + dev.ID + "']");
            if (devx != null)
            {
                devx.SetAttribute("name", dev.Name);
                devx.SetAttribute("type", dev.Type);
                devx.SetAttribute("ip", dev.IP);
                devx.SetAttribute("port", dev.Port);
            }
        }

        /// <summary>
        /// 根据设备ID查找设备信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Dev FindDev(string id)
        {
            if (_devs == null) return null;
            return _devs.Find(c => { return c.ID == id; });
        }
    }
}
