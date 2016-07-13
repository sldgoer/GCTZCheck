using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using lxbExcel;

namespace GovDepAdjustCheck.DAO
{
    class StanderFileRows:IEnumerable<DataRow>
    {
        private string _standarfilename;
        private string _excelsheetname;
        public StanderFileRows(string standarfilename,string excelsheetname) 
        { 
            _standarfilename = standarfilename;
            _excelsheetname = excelsheetname;
        }

        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }

        public IEnumerator<DataRow> GetEnumerator()
        {
            var sqlcommnadtext = AssemblySqlCommnandText(_excelsheetname);
            return GetEnumerator(delegate{
                return ExcelHelper.ExecuteDataTable(ExcelHelper.CreateConnection(_standarfilename, ExcelHelper.ExcelVerion.Excel2003), sqlcommnadtext);
            });
        }
        public IEnumerator<DataRow> GetEnumerator(Func<DataTable> provider)
        {
            using (DataTable dt = provider())
            {
                foreach(DataRow dr in dt.Rows)
                {
                    yield return dr;
                }
            }
        }

        private string AssemblySqlCommnandText(string excelsheetname)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from ");
            sb.Append(excelsheetname);

            return sb.ToString();

        }

    }
}
