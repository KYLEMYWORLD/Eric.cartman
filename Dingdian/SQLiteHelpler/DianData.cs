using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteHelpler
{
    public class DianData : DataType
    {
        public static String M_TABLENAME = "dian_tb";
        public static String M_DIANID = "dianid";
        public static String M_DIANNAME = "dianname";
        public static String M_DIANURL = "dianurl";
        public static String M_DIANCONTENT = "diancontent";
        public static String Colums_Name = M_DIANNAME+","+M_DIANURL+","+M_DIANCONTENT;
        public static String Colums_Values = "@"+M_DIANNAME + ",@" + M_DIANURL + ",@" + M_DIANCONTENT;

        public string DianID { get; set; }
        public string DianName { get; set; }
        public string DianUrl { get; set; }
        public string DianContent { get; set; }

        public string GetTableCreateSQL()
        {
            return "create table "+M_TABLENAME+
                "("+M_DIANID+ " INTEGER PRIMARY KEY AUTOINCREMENT," +
                M_DIANNAME+ " VARCHAR,"+
                M_DIANURL+ " VARCHAR," +
                M_DIANCONTENT+ " TEXT )";
        }
    }
}
