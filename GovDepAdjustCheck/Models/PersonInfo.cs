using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel;
using LinqToExcel.Attributes;
//using Remotion.Data.Linq;

namespace GovDepAdjustCheck.Models
{
    public class PersonInfo
    {
        [ExcelColumn("单位代码")]
        public string UnitCode { get; set; }

        [ExcelColumn("单位名称")]
        public string UnitName { get; set; }

        [ExcelColumn(@"人员|姓名")]
        public string Name { get; set; }

        [ExcelColumn(@"人员|身份证")]
        public string IdCard { get; set; }

        [ExcelColumn("类别")]
        public string UnitType { get; set; }

        [ExcelColumn("住房公积金缴费工资合计")]
        public double Salary { get; set; }

        [ExcelColumn(@"住房公积金(12%)")]
        public decimal Render { get; set; } 
    }
}
