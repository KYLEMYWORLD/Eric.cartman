using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SQLiteHelpler
{
    public class SQLiteUtils
    {
        protected static string m_dbName = "data.sqlite";
        protected static string m_password = "1234";
        protected static string m_dbfile_folder = "";// @"\data\";
        private static int SQL_VERSION = 3;


        //设置数据库登陆密码
        public static void SetDbPaswd(String pasword)
        {
            m_password = pasword;
        }
        //返回连接数据库路径
        public static string GetConnectString()
        {
            SQLiteConnectionStringBuilder connstr = new SQLiteConnectionStringBuilder();
            connstr.DataSource = m_dbfile_folder + m_dbName;
            connstr.Version = SQL_VERSION;
            if (m_password != "")
                connstr.Password = m_password;
            return connstr.ToString();
        }

        //首次创建数据库，打开数据库
        public static void initSQLiteDB()
        {
            string path = System.Environment.CurrentDirectory + m_dbfile_folder;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string dbFileName = path +"/"+ m_dbName;
            if (!File.Exists(dbFileName))
            {
                SQLiteConnection.CreateFile(dbFileName);
                initCreateTables(new DianData());
            }
        }
        //在数据库初次创建的时候创建表
        public static void initCreateTables(params DataType[] dataType)
        {
            using (SQLiteConnection con = new SQLiteConnection())
            {
                con.ConnectionString = GetConnectString();

                con.Open();
                using (SQLiteCommand cmd = con.CreateCommand())
                {
                    foreach (DataType data in dataType)
                    {
                        cmd.CommandText = data.GetTableCreateSQL();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// 执行非查询的数据库操作
        /// </summary>
        /// <param name="sqlString">要执行的sql语句</param>
        /// <param name="parameters">参数列表</param>
        /// <returns>返回受影响的条数</returns>
        public static int ExecuteNonQuery(string sqlString, params SQLiteParameter[] parameters)
        {
            string conStr = GetConnectString();
            using (SQLiteConnection conn = new SQLiteConnection(conStr))
            {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlString;
                    foreach (SQLiteParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 执行非查询的数据库操作
        /// </summary>
        /// <param name="sqlString">要执行的sql语句</param>
        /// <param name="parameters">参数列表</param>
        /// <returns>返回受影响的条数</returns>
        public static int ExecuteNonQuery2(SQLiteCommand cmd, string sqlString, params SQLiteParameter[] parameters)
        {

            cmd.CommandText = sqlString;
            cmd.Parameters.Clear();
            foreach (SQLiteParameter parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 执行查询并返回查询结果第一行第一列
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <param name="sqlparams">参数列表</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sqlString, params SQLiteParameter[] parameters)
        {
            string conStr = GetConnectString();
            using (SQLiteConnection conn = new SQLiteConnection(conStr))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlString;
                    foreach (SQLiteParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 查询多条数据
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <param name="parameters">参数列表</param>
        /// <returns>返回查询的数据表</returns>
        public static DataTable GetDataTable(string sqlString, params SQLiteParameter[] parameters)
        {
            string conStr = GetConnectString();
            using (SQLiteConnection conn = new SQLiteConnection(conStr))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlString;
                    foreach (SQLiteParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    DataSet ds = new DataSet();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    adapter.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }

        /// <summary>
        /// 对插入到数据库中的空值进行处理
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDbValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// 对从数据库中读取的空值进行处理
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object FromDbValue(object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                return value;
            }
        }
    }
}
