using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteHelpler
{
    public interface DataType
    {
        //获取模块的数据库表创建语句
        String GetTableCreateSQL();
    }
}
