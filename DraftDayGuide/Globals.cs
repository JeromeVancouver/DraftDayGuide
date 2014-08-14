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
            int id = 0;
            string name = "";
            string age = "";
            int count = 0;
            rdr = MysqlInterface.DoQuery("SELECT count(name) FROM player");

            while (rdr.Read())
            {
                count = rdr.GetInt32(0);
            }

            Globals.PLAYER_ARRAY = new string[count+1, 9];

            rdr = MysqlInterface.DoQuery("SELECT id, name, position, dob, team, country, height, weight, shoot FROM player");

            while (rdr.Read())
            {
                int i = 0;
                id = rdr.GetInt32(i);
                Globals.PLAYER_ARRAY[id, i++] = id.ToString();

                name = rdr.GetString(i);
                Globals.PLAYER_ARRAY[id, i++] = name;
                
                name = rdr.GetString(i);
                Globals.PLAYER_ARRAY[id, i++] = name;

                age = rdr.GetString(i);
                string strage = age.Substring(8, age.Length - 8);
                int nAge = 100 - Convert.ToInt32(strage) + 14;
                Globals.PLAYER_ARRAY[id, i++] = nAge.ToString();

                name = rdr.GetString(i);
                Globals.PLAYER_ARRAY[id, i++] = name;
                name = rdr.GetString(i);
                Globals.PLAYER_ARRAY[id, i++] = name;
                name = rdr.GetString(i);
                Globals.PLAYER_ARRAY[id, i++] = name;
                name = rdr.GetString(i);
                Globals.PLAYER_ARRAY[id, i++] = name;
                name = rdr.GetString(i);
                Globals.PLAYER_ARRAY[id, i++] = name;



                i++;
            }
        }

        private static void EnterStat(string year, int index, int count, int value, bool nResult)
        {
            if (year == "stat2014")
                Globals.STAT2014_ARRAY[index, count] = value;

            if (nResult == true)
            {
                if(year == "stat2013")
                    value = Convert.ToInt32(Globals.STAT2014_ARRAY[index, count] / 1.7);
                if (year == "stat2012")
                    value = Convert.ToInt32(Globals.STAT2013_ARRAY[index, count] * 1.7);
                if (year == "stat2011")
                    value = Globals.STAT2012_ARRAY[index, count];
                if (year == "stat2010")
                    value = Globals.STAT2011_ARRAY[index, count];
                if (year == "stat2009")
                    value = Globals.STAT2010_ARRAY[index, count];
            }

            if (year == "stat2013")
                Globals.STAT2013_ARRAY[index, count] = value;
            if (year == "stat2012")
                Globals.STAT2012_ARRAY[index, count] = value;
            if (year == "stat2011")
                Globals.STAT2011_ARRAY[index, count] = value;
            if (year == "stat2010")
                Globals.STAT2010_ARRAY[index, count] = value;
            if (year == "stat2009")
                Globals.STAT2009_ARRAY[index, count] = value;
        }

        public static void LoadStats(string year)
        {
            MySqlDataReader rdr = null;
            int count = 0;
            int tempResult = -1;
            int ID = 0;
            rdr = MysqlInterface.DoQuery("SELECT count(name) FROM player;");

            while (rdr.Read())
            {
                count = rdr.GetInt32(0);
            }

            if(year == "stat2014")
                Globals.STAT2014_ARRAY = new int[count + 1, 11];
            if (year == "stat2013")
                Globals.STAT2013_ARRAY = new int[count + 1, 11];
            if (year == "stat2012")
                Globals.STAT2012_ARRAY = new int[count + 1, 11];
            if (year == "stat2011")
                Globals.STAT2011_ARRAY = new int[count + 1, 11];
            if (year == "stat2010")
                Globals.STAT2010_ARRAY = new int[count + 1, 11];
            if (year == "stat2009")
                Globals.STAT2009_ARRAY = new int[count + 1, 11];

            rdr = MysqlInterface.DoQuery
            ("select p.id, s.games, s.goals, s.assists, s.points, s.plusminus, s.ppg, s.ppp, s.shg, s.shp, s.gw, s.ot from player p left join " + year + " s on p.name = s.player;");
            int i = 0;
            bool nullResult;
            while (rdr.Read())
            {
                ID = rdr.GetInt32(0);
                for (int j = 0; j < 10; j++)
                {
                    nullResult = false;
                    if (!rdr.IsDBNull(j + 1))
                        tempResult = rdr.GetInt32(j + 1);
                    else
                        nullResult = true;
                    EnterStat(year, ID, j, tempResult, nullResult);
                }
            }
            int ti = 0;
            ti++;
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
        public static fmSplash FM_SPLASH;

        public static string[,] PART_ARRAY;
        public static int[,] STAT2014_ARRAY;
        public static int[,] STAT2013_ARRAY;
        public static int[,] STAT2012_ARRAY;
        public static int[,] STAT2011_ARRAY;
        public static int[,] STAT2010_ARRAY;
        public static int[,] STAT2009_ARRAY;
        public static string[,] PLAYER_ARRAY;
        public static string[] CONTRACT_ARRAY;
        public static int[] WATCH_ARRAY;

    }
}
