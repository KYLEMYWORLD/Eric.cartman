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

        public static void AddDevdef(Devdef devdef)
        {
            Devdefs.AddDevdef(devdef);
            SaveAndReload();
        }
       
        public static void EditeDevdef(Devdef devdef)
        {
            Devdefs.EditeDevdef(devdef);
            SaveAndReload();
        }
        public static void AddDev(Dev dev)
        {
            Devs.AddDev(dev);
            SaveAndReload();
        }
       
        public static void EditeDev(Dev dev)
        {
            Devs.EditeDev(dev);
            SaveAndReload();
        }
    }

    /// <summary>
    /// 设备定义信息
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
                _devdefs.Add(new Devdef(id, name, connecttype));
            }
        }



        public void AddDevdef(Devdef devdef)
        {
            _devdefs.Add(devdef);

            XmlElement devX = XMLMaster.XMLHelper._xmldoc.CreateElement("Devdef");
            devX.SetAttribute("id", devdef.ID);
            devX.SetAttribute("name", devdef.Name);
            devX.SetAttribute("connecttype", devdef.ConnetType);
            XMLMaster.XMLHelper.AddToDevdefs(devX);
        }

        public void EditeDevdef(Devdef dev)
        {
            XmlNodeList devList = XMLMaster.XMLHelper.GetXmlNodeList("Dev");
            if (devList != null)
            {
                foreach (XmlElement devx in devList)
                {
                    if (devx.GetAttribute("id").Equals(dev.ID))
                    {
                        devx.SetAttribute("name", dev.Name);
                        devx.SetAttribute("connecttype", dev.ConnetType);
                        return;
                    }
                }
            }
        }

        public Devdef FindDevdef(string id)
        {
            return _devdefs.Find(c => { return c.ID == id; });
        }

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
    /// 设备定义信息
    /// </summary>
    public class Devdef
    {
        public string ID;
        public string Name;
        public string ConnetType;
        public Devdef() { }
        public Devdef(string id, string name, string connnecttype)
        {
            ID = id;
            Name = name;
            ConnetType = connnecttype;
        }
    }



    /// <summary>
    /// 设备信息
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



        public void AddDev(Dev dev)
        {
            _devs.Add(dev);

            XmlElement devX = XMLMaster.XMLHelper._xmldoc.CreateElement("Dev");
            devX.SetAttribute("id", dev.ID);
            devX.SetAttribute("name", dev.Name);
            devX.SetAttribute("type", dev.Type);
            devX.SetAttribute("ip", dev.IP);
            devX.SetAttribute("port", dev.Port);
            XMLMaster.XMLHelper.AddToDevs(devX);
        }

        public void EditeDev(Dev dev)
        {
            XmlNodeList devList = XMLMaster.XMLHelper.GetXmlNodeList("Dev");
            if (devList != null)
            {
                foreach (XmlElement devx in devList)
                {
                    if (devx.GetAttribute("id").Equals(dev.ID))
                    {
                        devx.SetAttribute("name", dev.Name);
                        devx.SetAttribute("type", dev.Type);
                        devx.SetAttribute("ip", dev.IP);
                        devx.SetAttribute("port", dev.Port);
                        return;
                    }
                }
            }
        }

        public Dev FindDev(string id)
        {
            return _devs.Find(c => { return c.ID == id; });
        }
    }

    /// <summary>
    /// 设备信息
    /// </summary>
    public class Dev
    {
        public string ID;
        public string Name;
        public string Type;
        public string IP;
        public string Port;
        public Dev() { }
        public Dev(string id, string name, string type, string ip, string port)
        {
            ID = id;
            Name = name;
            Type = type;
            IP = ip;
            Port = port;
        }
    }


}
