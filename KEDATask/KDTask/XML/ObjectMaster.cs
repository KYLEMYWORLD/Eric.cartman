using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KDTask.XML
{
    class ObjectMaster
    {
    }

    /// <summary>
    /// 设备定义信息
    /// </summary>
    public class Devdef
    {
        public string ID;
        public string Name;
        public string ConnetType;
        public List<DevAtt> DevAtts;
        public Devdef() { }
        public Devdef(string id, string name, string connnecttype)
        {
            ID = id;
            Name = name;
            ConnetType = connnecttype;
        }
        internal void AddDevAtt(DevAtt devAtt)
        {
            if (DevAtts == null) DevAtts = new List<DevAtt>();
            DevAtts.Add(devAtt);
        }
        /// <summary>
        /// 根据属性ID返回属性
        /// </summary>
        /// <param name="devattid"></param>
        /// <returns></returns>
        public DevAtt GetDevAttById(string devattid)
        {
            if (DevAtts == null) return null;
            return DevAtts.Find(c => { return c.ID.Equals(devattid); });
        }

    }
    /// <summary>
    /// 设备属性
    /// </summary>
    public class DevAtt
    {

        public string ID;
        public string Name;
        public int Start;
        public int End;
        internal List<AttDic> AttDics;
        public DevAtt() { }
        public DevAtt(string id, string name, int start, int end)
        {
            ID = id;
            Name = name;
            Start = start;
            End = end;
        }
        /// <summary>
        /// 返回字典列表
        /// </summary>
        /// <returns></returns>
        public List<AttDic> GetAttDics()
        {
            return AttDics;
        }

        /// <summary>
        /// 添加字典值
        /// </summary>
        /// <param name="attDic"></param>
        internal void AddAttDic(AttDic attDic)
        {
            if (AttDics == null) AttDics = new List<AttDic>();
            AttDics.Add(attDic);
        }

        /// <summary>
        /// 根据字典值返回内容
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public AttDic GetAttDicByKey(string key)
        {
            if (AttDics == null) return null;
            return AttDics.Find(c => { return c.Key.Equals(key); });
        }
    }

    /// <summary>
    /// 设备属性 值:意义 对关系
    /// </summary>
    public class AttDic
    {
        public string Key;
        public string Value;
        public AttDic() { }
        public AttDic(string key, string value)
        {
            Key = key;
            Value = value;
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
