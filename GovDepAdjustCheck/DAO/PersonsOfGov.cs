using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GovDepAdjustCheck.Models;
using LinqToExcel;
using LinqToExcel.Query;

namespace GovDepAdjustCheck.DAO
{
    class PersonsOfGov : IEnumerable<PersonInfo>
    {
        public string _excelFileName;
        public PersonsOfGov(string excelfilename)
        {
            _excelFileName = excelfilename;
        }

        public IEnumerable GetPersonsByUintCode(string unitcode)
        {
            var excel = new ExcelQueryFactory(_excelFileName);
            excel.TrimSpaces = TrimSpacesType.Both;
            var persons = from p in excel.Worksheet<PersonInfo>(0)
                          where p.Name.Length > 0 && p.UnitCode==unitcode
                          select p;

            foreach (var p in persons)
            {
                yield return p;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<PersonInfo> GetEnumerator()
        {
            var excel = new ExcelQueryFactory(_excelFileName);
            excel.TrimSpaces = TrimSpacesType.Both;
            var persons = from p in excel.Worksheet<PersonInfo>("住房公积金个人缴款明细表")
                          where p.Name !=""
                          select p;

            foreach (var p in persons)
            {
                yield return p;
            }
        }
                 
    }
}
