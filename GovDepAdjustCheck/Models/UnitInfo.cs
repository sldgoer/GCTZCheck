using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovDepAdjustCheck.Models
{
    class UnitInfo
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string UnitType { get; set; }
        public long Amount { get; set; }
        public double TotalSalary { get; set; }
        public double TotalRender { get; set; }
    }
}
