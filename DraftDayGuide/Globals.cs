using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DraftDayGuide
{
    public static class Globals
    {
        public static int GetCurrentBox()
        {
            MySqlDataReader rdr = null;
            int id = 0;
            string qry = "SELECT box_id FROM current_values;";
            rdr = MysqlInterface.DoQuery(qry);
            while (rdr.Read())
            {
                id = rdr.GetInt32(0);
            }
            return id;
        }

        public static string CreateNewTruck(string desc, string carrier)
        {
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            string tId = "";

            try
            {

                string qry = "SELECT truck_id FROM current_values;";
                reader = MysqlInterface.DoQuery(qry);
                while (reader.Read())
                {
                    tId = reader.GetString(0);
                }

                string host = MysqlInterface.host;
                string dbase = MysqlInterface.dbase;
                string user = MysqlInterface.user;
                string password = MysqlInterface.password;

                String str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open(); //open the connection

                string cmdText = "INSERT INTO truck (id, description, shipper_id)" +
                "VALUES(@id, @description, @shipper_id)";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", tId);
                cmd.Parameters.AddWithValue("@description", desc);
                cmd.Parameters.AddWithValue("@shipper_id", carrier);
                cmd.ExecuteNonQuery();


                str = @"server=" + host + ";database=" + dbase + ";userid=" + user + "; password=" + password + ";";

                con = new MySqlConnection(str);
                con.Open();

                string newTId;
                newTId = (Convert.ToInt32(tId) + 1).ToString();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE current_values SET truck_id = '" + newTId + "';";
                int numRowsUpdated = cmd.ExecuteNonQuery();


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

            return tId;
        }


        public static void LoadPlayers()
        {
            MySqlDataReader rdr = null;
            string id = "";
            string name = "";
            string age = "";
            int count = 0;
            rdr = MysqlInterface.DoQuery("SELECT count(name) FROM player");

            while (rdr.Read())
            {
                count = rdr.GetInt32(0);
            }

            Globals.PLAYER_ARRAY = new string[count, 3];

            rdr = MysqlInterface.DoQuery("SELECT name, position, dob FROM player");
            int i = 0;
            while (rdr.Read())
            {
                id = rdr.GetString(0);
                Globals.PLAYER_ARRAY[i, 0] = id;

                name = rdr.GetString(1);
                Globals.PLAYER_ARRAY[i, 1] = name;

                age = rdr.GetString(2);
                string strage = age.Substring(8, age.Length - 8);
                int nAge = 100 - Convert.ToInt32(strage) + 14;
                Globals.PLAYER_ARRAY[i, 2] = nAge.ToString();


                i++;
            }
        }

        public static void LoadContracts()
        {
            MySqlDataReader rdr = null;
            string id = "";
            string name = "";
            int count = 0;
            rdr = MysqlInterface.DoQuery("SELECT count(name) FROM contract2014");

            while (rdr.Read())
            {
                count = rdr.GetInt32(0);
            }

            Globals.CONTRACT_ARRAY = new string[count];

            rdr = MysqlInterface.DoQuery("SELECT name FROM contract2014");
            int i = 0;
            while (rdr.Read())
            {
                id = rdr.GetString(0);
                Globals.CONTRACT_ARRAY[i] = id;
                i++;
            }
        }

        public static void LoadParts()
        {
            MySqlDataReader rdr = null;
            string id = "";
            int count = 0;
            string desc = "";
            string qty = "";
            string pp = "";
            string sp = "";
            rdr = MysqlInterface.DoQuery("SELECT count(id) FROM part");

            while (rdr.Read())
            {
                count = rdr.GetInt32(0);
            }

            Globals.PART_ARRAY = new string[count, 5];

            rdr = MysqlInterface.DoQuery("SELECT id, description, qty_on_hand, purchase_price, selling_price FROM part");
            int i = 0;
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(0)) id = rdr.GetString(0); else id = "";
                Globals.PART_ARRAY[i, 0] = id;
                if (!rdr.IsDBNull(1)) desc = rdr.GetString(1); else desc = "";
                Globals.PART_ARRAY[i, 1] = desc;
                if (!rdr.IsDBNull(2)) qty = rdr.GetString(2); else qty = "";
                Globals.PART_ARRAY[i, 2] = qty;
                if (!rdr.IsDBNull(3)) pp = rdr.GetString(3); else pp = "";
                Globals.PART_ARRAY[i, 3] = pp;
                if (!rdr.IsDBNull(4)) sp = rdr.GetString(4); else sp = "";
                Globals.PART_ARRAY[i, 4] = sp;
                i++;
            }
        }

        public static string part;
        public static string qry;
        public static int column;
        public static int row;
        public static bool partSelected;
        public static string USER;
        public static string USER_NAME;

        public static fmImport FM_IMPORT;
        public static fmMain FM_MAIN;
        public static fmPlayerLookup FM_LOOKUP;

        public static string[,] PART_ARRAY;
        public static string[,] CUSTOMER_ARRAY;
        public static string[,] PLAYER_ARRAY;
        public static string[] CONTRACT_ARRAY;

    }
}
