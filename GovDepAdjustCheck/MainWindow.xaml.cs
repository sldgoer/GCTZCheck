using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GovDepAdjustCheck.DAO;
using GovDepAdjustCheck.Linq;
using GovDepAdjustCheck.Models;
using LxbXml;

namespace GovDepAdjustCheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        StandarFileCfg sfc=new StandarFileCfg(@"CFG\AppCfg.xml");
        string _excelfilename;

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            //ofd.DefaultExt = XMLHelper.GetXmlAttribute(@"CFG/AppCfg.xml", "//Configurations//SourceDBCfg//connection", "connectionstring").Value;
            ofd.InitialDirectory=@"c:\";
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
            ofd.Filter = "Excel 97-2003(*.xls)|*.xls|Excel 2007-2010(*.xlsx)|*.xlsx";
            ofd.ShowDialog();
                        
            //StanderFileRows sfr;
            if(System.IO.File.Exists(ofd.FileName))
            {
                _excelfilename = ofd.FileName;

            }
            else
            {
                MessageBox.Show("Invalid filename!");
            }

        }
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            //var sfr = new StanderFileRows(_excelfilename,"[Sheet1$]");
            ////sfc=new StandarFileCfg()
            //DataTable dt = new DataTable();
            //foreach (var c in sfc)
            //{
            //    dt.Columns.Add(c.ColumnName, c.ValueType);
            //}

            //foreach (DataRow dr in sfr)
            //{
            //    //dr.Table = dt;
            //    dt.Rows.Add(dr.ItemArray);
            //}

          //20160630 Notes
            //Add the check process code here;
            //sfr is a datarows iterator from excel sheet1 including the column captions; 
            //sfc is a columname iterator from configuration file that need to check;
            //It should show the check result and export to excel file;

            var pg = new PersonsOfGov(_excelfilename);
            
            foreach (var pi in pg)
            {
                Console.WriteLine(pi.ToString());
            }
        }        

        //private DataTable GetTableFromExcel(string filename)
        //{
        //    if (sfc == null) { GetStandarFileConfig(); }
        //    return GetTableFromExcel(filename, sfc);
        //}
        //private DataTable GetTableFromExcel(string filename, StandarFileCfg columnsinfo)
        //{
        //    var verion = System.IO.Path.GetExtension(filename) == ".xls" ? lxbExcel.ExcelHelper.ExcelVerion.Excel2003 : lxbExcel.ExcelHelper.ExcelVerion.Excel2007;
        //    var conn = lxbExcel.ExcelHelper.CreateConnection(filename,verion);
        //    var sqltext = AssemblySqlCommnandText("[Sheet1]", columnsinfo);

        //    return lxbExcel.ExcelHelper.ExecuteDataTable(conn, sqltext);
        //}

        private void GetStandarFileConfig(string filename = @"CFG\AppCfg.xml")
        {
            sfc = new StandarFileCfg(filename);
        }

    }
}
