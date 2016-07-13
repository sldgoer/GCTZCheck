using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovDepAdjustCheck.Models
{
    class StandarFileColumnInfo
    {
        public string ColumnName { get; private set; }
        //public char? Spliter { get; private set; }
        public Type ValueType { get; private set; }

        public StandarFileColumnInfo() { }
        public StandarFileColumnInfo(string columnname, Type valuetype)
        {
            this.ColumnName = columnname;
            //this.Spliter = spliter;
            this.ValueType = valuetype;

        }

        public override string ToString()
        {
            //return base.ToString();
            //return string.Format("ColumnName:{0}; Spliter:{1}; ValueType:{2};", ColumnName, (Spliter == null ? ' ' : Spliter), ValueType.ToString());
            return string.Format("ColumnName:{0};  ValueType:{1};", ColumnName, ValueType.ToString());

        }
    }
}
