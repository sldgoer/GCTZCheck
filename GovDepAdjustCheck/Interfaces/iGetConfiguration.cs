using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovDepAdjustCheck.Interfaces
{
    interface iGetConfiguration<T>
    {
        //private T datatype;
        //public string CfgFileName { private get; set; }
        T ReadConfiguration(string filename);

        //public T GetConf<T>(T ConfigurationClass){}
    }
}
