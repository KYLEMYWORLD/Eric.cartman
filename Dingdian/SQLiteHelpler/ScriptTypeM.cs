using System;
using System.Data;

namespace SQLiteHelpler
{
    public class ScriptTypeM : DataRow
    {

        protected internal ScriptTypeM(DataRowBuilder builder) : base(builder)
        {
        }

        public Guid ScriptTypeId { get; internal set; }
        public string ScriptType { get; internal set; }
        public bool IsUsing { get; internal set; }
    }
}