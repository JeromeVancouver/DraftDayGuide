using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace DraftDayGuide
{


    public partial class fmImport : Form
    {
        string cwColumn;
        string xlColumn;


        public fmImport()
        {
            InitializeComponent();
        }

        private void fmImport_Load(object sender, EventArgs e)
        {

            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            string column = "Columns";
            col.HeaderText = column;
            col.Name = "f" + column;
            dgXLTable.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = column;
            col.Name = "f" + column;
            dgXLTransfer.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = column;
            col.Name = "f" + column;
            dgCWTransfer.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = column;
            col.Name = "f" + column;
            dgCWTable.Columns.Add(col);

            try
            {

                MySqlDataReader rdr = null;
                string table = "";

                rdr = MysqlInterface.DoQuery("SHOW TABLES;");

                while (rdr.Read())
                {
                    table = rdr.GetString(0);
                    cbTable.Items.Add(table);
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                MysqlInterface.close();
            }
        }

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            dgCWTable.RowCount = 1;
            dgCWTable.Rows.Clear();
            dgCWTable.Columns.Clear();
            dgCWTable.AutoGenerateColumns = false;
            try
            {

                MySqlDataReader rdr = null;
                string table = cbTable.Text;
                string column = "";

                rdr = MysqlInterface.DoQuery("SHOW COLUMNS FROM " + table + ";");
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                column = "Columns";
                col.HeaderText = column;
                col.Name = "f" + column;
                dgCWTable.Columns.Add(col);


                while (rdr.Read())
                {
                    column = rdr.GetString(0);
                    string[] row = { column };
                    dgCWTable.Rows.Add(row);
                }


            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                MysqlInterface.close();
            }
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            odExcelFile.InitialDirectory = Directory.GetCurrentDirectory();
            odExcelFile.ShowDialog();
            xlInterface.init(odExcelFile.FileName);
            tbFileName.Text = odExcelFile.FileName;
            string sString;
            string cName = "part";


            sString = "select id, description, qty_on_hand, purchase_price from [" + cName + "$]";
            /*DataTable dt = xlInterface.GetSchema();
            string part;
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                
            col.HeaderText = "Part";
            col.Name = "f" + "Part";
            dgExcel.Columns.Add(col);

            foreach (DataRow drow in dt.Rows)
            {
                part = drow["TABLE_NAME"].ToString();
                cbExcelTable.Items.Add(part);
            }*/
            string part = "Sheet1$";
            cbExcelTable.Items.Add(part);


        }

        private void cbExcelTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            string table = cbExcelTable.Text;
            DataTable dt = xlInterface.DoQuery("SELECT * FROM " + "[" + table + "];");

            foreach (DataColumn c in dt.Columns)
            {
                dgXLTable.Rows.Add(c.ColumnName);
            }

            /*foreach (DataRow drow in dt.Rows)
            {
                column = drow[0].ToString();
                string[] row = { column };
                dgExcel.Rows.Add(row);
            }*/
        }

        private void dgExcel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string tID;
            if (e.RowIndex >= 0)
            {
                tID = dgXLTable.Rows[e.RowIndex].Cells[0].Value as string;
                try
                {
                    xlColumn = tID;
                }
                catch (Exception)
                {
                    xlColumn = "";
                }
            }
        }

        private void btXLTransfer_Click(object sender, EventArgs e)
        {
            dgXLTransfer.Rows.Add(xlColumn);
        }

        private void dgCWTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string tID;
            cwColumn = "";
            if (e.RowIndex >= 0)
            {
                tID = dgCWTable.Rows[e.RowIndex].Cells[0].Value as string;
                try
                {
                    cwColumn = tID;
                }
                catch (Exception)
                {
                    cwColumn = "";
                }
            }
        }

        private void btCWTransfer_Click(object sender, EventArgs e)
        {
            dgCWTransfer.Rows.Add(cwColumn);
        }

        List<xlData> xlList;
        List<xlData> cwList;

        private void btImport_Click(object sender, EventArgs e)
        {
            xlInterface.init(odExcelFile.FileName);

            string sString;
            string rName = "part";
            xlList = new List<xlData>();

            int rows = dgXLTransfer.RowCount;

            sString = "select ";
            for (int i = 0; i < rows-1; i++)
            {
                if (i > 0)
                    sString += ", ";
                rName = dgXLTransfer.Rows[i].Cells[0].Value as string;
                xlData id = new xlData();
                id.ID = rName;
                xlList.Add(id);
                sString +=  rName;
                sString += " ";

            }

            sString += " from [Sheet1$];";
            DataTable dt = xlInterface.DoQuery(sString);
            foreach (DataRow drow in dt.Rows)
            {
                for (int j = 0; j < xlList.Count; j++)
                {
                    xlList[j].Data = drow[xlList[j].ID].ToString();
                }
                
                 /*part = drow["id"].ToString();
                 description = drow["description"].ToString();
                 qty_on_hand = Convert.ToDouble(drow["qty_on_hand"].ToString());
                 purchase_price = Convert.ToDouble(drow["purchase_price"].ToString());*/
                 EnterData();
            }
        }

        void EnterData()
        {



            cwList = new List<xlData>();

            int rows = dgCWTransfer.RowCount;
            string sString;
            string rName;
            sString = "INSERT INTO ";
            sString += tbName.Text + " ("; 
            for (int i = 0; i < rows-1; i++)
            {
                if (i > 0)
                    sString += ", ";
                rName = dgCWTransfer.Rows[i].Cells[0].Value as string;
                xlData id = new xlData();
                id.ID = rName;
                id.Data = xlList[i].Data;
                cwList.Add(id);
                sString += rName;
                sString += " ";

            }

            sString += ") VALUES ( ";

            for (int i = 0; i < rows-1; i++)
            {
                if (i > 0)
                    sString += ", ";
                sString += "@";
                sString += cwList[i].ID;
                sString +=  " ";

            }
            sString += " );";
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            try
            {
                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open(); //open the connection

                //This is the mysql command that we will query into the db.
                //It uses Prepared statements and the Placeholder is @name.
                //Using prepared statements is faster and secure.
                //TO INSERT values into the database using prepares statements
                //String cmdText = "INSERT INTO part (id, description, qty_on_hand, purchase_price) VALUES(@part,@description,@qty_on_hand, @purchase_price)";
                MySqlCommand cmd = new MySqlCommand(sString, con);
                cmd.Prepare();
                for (int i = 0; i < rows - 1; i++)
                {
                    cmd.Parameters.AddWithValue("@" + cwList[i].ID, cwList[i].Data);
                }
                /*
                cmd.Parameters.AddWithValue("@part", part);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@qty_on_hand", qty_on_hand);
                cmd.Parameters.AddWithValue("@purchase_price", purchase_price);*/
                cmd.ExecuteNonQuery(); //execute the mysql command
                Console.WriteLine("Inserting data to the database. Done!\n");
            
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
                if (con != null)
                {
                    con.Close(); //close the connection
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }

    public class xlData
    {
        public string ID { get; set; }
        public string Data { get; set; }
    }
}
