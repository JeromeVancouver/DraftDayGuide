using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DraftDayGuide
{

    public static class xlInterface
    {
        //private static Microsoft.Office.Interop.Excel.ApplicationClass appExcel;
        private static OleDbConnection conn;
        private static OleDbDataAdapter da;

        public static void init(string filename)
        {
            //string dir = AppDomain.CurrentDomain.BaseDirectory + filename;
            string dir = filename;
            string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+dir+";Extended Properties=Excel 8.0";
            conn = new OleDbConnection(@connstr);
            conn.Open();
        }

        public static DataTable GetSchema()
        {
            return conn.GetSchema("Tables"); ;
        }

        public static void close()
        {
            conn.Close();
        }

        public static DataTable DoQuery(string qry)
        {
            try
            {
                da = new OleDbDataAdapter(qry, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception err)
            {

                Console.WriteLine("Error: {0}", err.ToString());
                return null;
            }
        }
    }
}
