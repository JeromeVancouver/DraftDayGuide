using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DraftDayGuide
{

    public static class MysqlInterface
    {
        //private static Microsoft.Office.Interop.Excel.ApplicationClass appExcel;
        private static  MySqlConnection con = null;
        private static MySqlDataReader reader = null;


        public static string host = "sql3.freemysqlhosting.net";
        public static string user = "sql349366";
        public static string password = "aY9*bQ2%";
        public static string dbase = "sql349366";
        


        public static void SetConnectionInformation(string h, string u, string p, string d)
        {
            host = h;
            user = u;
            password = p;
            dbase = d;
        }

        public static MySqlConnection GetConnection()
        {
            return con;
        }

        public static bool ConnectionStatus()
        {

            if (con == null)
                return false;
            else if (con.State == ConnectionState.Closed)
                return false;
            else
                return true;
        }

        public static bool init()
        {

            String str = @"server=" + host;
            if(dbase != "" )
                str = str + ";database=" + dbase;
            str = str + ";userid=" + user + "; password=" + password + ";";
            con = null;
            int tries = 0;
            while (ConnectionStatus() == false)
            {
                if (tries > 10)
                {
                    MessageBox.Show("Unable to Connect to Database");
                    break;
                }
                tries++;
                try
                {
                    con = new MySqlConnection(str);
                    con.Open(); //open the connection
                }
                catch (MySqlException err)
                {
                    Console.WriteLine("Error: " + err.ToString());
                    return false;
                }
            }
            return true;
            SetWaitTimeout(200);
        }

        private static void SetWaitTimeout(int wait)
        {
            string qry = "set session wait_timeout = 200;";
            if (ConnectionStatus() == false || qry == "")
            {
                int i = 0;
                i = 1;
                i++;
            }
            else
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = qry;
                int numRowsUpdated = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public static void CloseReader()
        {
            if (reader != null)
                reader.Close();
        }

        public static void close()
        {

            if (con != null)
            {
                con.Close(); //close the connection
                con.Dispose();
            }
            if (reader != null)
                reader.Close();
        }
        //string stm = "SELECT id, description, purchase_price FROM part"

        public static MySqlDataReader DoQuery(string qry)
        {
            try
            {
                MysqlInterface.close();
                MysqlInterface.init();
                MySqlDataReader rdr = null;
                MySqlCommand cmd = new MySqlCommand(qry, con);
                rdr = cmd.ExecuteReader();
                cmd.Dispose();
                return rdr;
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
                return null;
            }

        }

        public static void ExecuteQuery(string qry)
        {


            //if (ConnectionStatus() == false || qry == "")
            //{
                MysqlInterface.close();
                MysqlInterface.init();
            //}

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = qry;
            int numRowsUpdated = cmd.ExecuteNonQuery();
            cmd.Dispose();
            
        }


        /*String query = "INSERT INTO part (id, description, qty_on_hand, purchase_price) VALUES(@part,@description,@qty_on_hand, @purchase_price)";
         */       
        public static void Insert(string query)
        {
            try
            {
                //This is the mysql command that we will query into the db.
                //It uses Prepared statements and the Placeholder is @name.
                //Using prepared statements is faster and secure.
                //TO INSERT values into the database using prepares statements
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Prepare();
                string part = "";
                string description = "";
                double qty_on_hand = 0.0;
                double purchase_price = 0.0;
                cmd.Parameters.AddWithValue("@part", part);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@qty_on_hand", qty_on_hand);
                cmd.Parameters.AddWithValue("@purchase_price", purchase_price);
                cmd.ExecuteNonQuery(); //execute the mysql command
                Console.WriteLine("Inserting data to the database. Done!\n");
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
        }
    }
}
