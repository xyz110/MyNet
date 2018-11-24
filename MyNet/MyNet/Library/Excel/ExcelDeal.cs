using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using NPOI.HSSF;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace MyNet.Library.Excel
{
    public class ExcelDeal
    {
        public DataTable ExcelToTable(string Path)
        {
            OleDbConnection conn = null;
            try
            {
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
                conn = new OleDbConnection(strConn);
                conn.Open();
                string strExcel = "";
                OleDbDataAdapter  adapter = new OleDbDataAdapter(strExcel, strConn);
                strExcel = "select * from [sheet1$]";
                DataTable table = new DataTable();
                adapter.Fill(table, "table");
                return table;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public void TableToExcel(DataTable table, string path)
        {

        }
    }
}
