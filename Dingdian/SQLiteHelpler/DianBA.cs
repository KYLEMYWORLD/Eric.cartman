using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteHelpler
{
    public class DianBA
    {
        public DianData ToDianData(DataRow row)
        {
            DianData dian = new DianData();
            dian.DianID = (string)row[DianData.M_DIANID];
            dian.DianName = (string)row[DianData.M_DIANNAME];
            dian.DianUrl = (string)row[DianData.M_DIANURL];
            return dian;
        }
        //插入数据
        public void insert(params DianData[] dians)
        {
            string conStr = SQLiteUtils.GetConnectString();
            using (SQLiteConnection conn = new SQLiteConnection(conStr))
            {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    foreach (DianData dian in dians)
                    {
                        SQLiteHelpler.SQLiteUtils.ExecuteNonQuery2(cmd,"insert into " + DianData.M_TABLENAME + "("+DianData.Colums_Name+") values(" + DianData.Colums_Values + " )",
                                                    new SQLiteParameter(DianData.M_DIANNAME, dian.DianName),
                                                    new SQLiteParameter(DianData.M_DIANURL, dian.DianUrl),
                                                    new SQLiteParameter(DianData.M_DIANCONTENT,dian.DianContent)
                                                    );

                    }
                }
            }
            
        }
        
    }
}
