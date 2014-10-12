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
            xlInterface.init("player.xls");
            string[] cName;

            string table = "Sheet1$";
            string qry = "SELECT * FROM " + "[" + table + "];";
            DataTable dt = xlInterface.DoQuery(qry);
            cName = new string[dt.Columns.Count];
            int i = 0;
            foreach (DataColumn c in dt.Columns)
            {
                cName[i++] = c.ColumnName;
            }


            string sString;
            xlList = new List<xlData>();

            int rows = cName.Length + 1;

            sString = "select ";
            for (i = 0; i < rows - 1; i++)
            {
                if (i > 0)
                    sString += ", ";
                xlData id = new xlData();
                id.ID = cName[i];
                xlList.Add(id);
                sString += cName[i];
                sString += " ";

            }

            sString += " from [Sheet1$];";
            //dt = xlInterface.DoQuery(sString);
            int lSize = dt.Rows.Count;
            Globals.PLAYER_ARRAY = new string[lSize, 9];
            string pid = "";
            int pi = 0;
            foreach (DataRow drow in dt.Rows)
            {
                for (int j = 0; j < xlList.Count; j++)
                {
                    pid = drow[xlList[j].ID].ToString();
                    if (j == 3)
                    {
                        int age;
                        pid = drow[xlList[j].ID].ToString().Substring(8);
                        age = (100 - Convert.ToInt32(pid)) + 14;
                        pid = age.ToString();
                    }
                    Globals.PLAYER_ARRAY[pi, j] = pid;
                }

                pi++;
            }

        }

        public static void LoadGoalies()
        {
            xlInterface.init("goalie.xls");
            string[] cName;

            string table = "Sheet1$";
            string qry = "SELECT * FROM " + "[" + table + "];";
            DataTable dt = xlInterface.DoQuery(qry);
            cName = new string[dt.Columns.Count];
            int i = 0;
            foreach (DataColumn c in dt.Columns)
            {
                cName[i++] = c.ColumnName;
            }


            string sString;
            xlList = new List<xlData>();

            int rows = cName.Length + 1;

            sString = "select ";
            for (i = 0; i < rows - 1; i++)
            {
                if (i > 0)
                    sString += ", ";
                xlData id = new xlData();
                id.ID = cName[i];
                xlList.Add(id);
                sString += cName[i];
                sString += " ";

            }

            sString += " from [Sheet1$];";
            //dt = xlInterface.DoQuery(sString);
            int lSize = dt.Rows.Count;
            Globals.GOALIE_ARRAY = new string[lSize, 9];
            string pid = "";
            int pi = 0;
            foreach (DataRow drow in dt.Rows)
            {
                for (int j = 0; j < xlList.Count; j++)
                {
                    pid = drow[xlList[j].ID].ToString();
                    if (j == 3)
                    {
                        int age;
                        pid = drow[xlList[j].ID].ToString().Substring(8);
                        age = (100 - Convert.ToInt32(pid)) + 14;
                        pid = age.ToString();
                    }
                    Globals.GOALIE_ARRAY[pi, j] = pid;
                }

                pi++;
            }

        }

        private static void CarryStats(int[,] fromArray, int[,] toArray, int index, float d)
        {
            for (int i = 0; i < 10; i++)
                toArray[index, i] = Convert.ToInt32(fromArray[index, i] / d);
        }

        private static void CarryGStats(double[,] fromArray, double[,] toArray, int index, float d)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 7 || i == 8)
                    toArray[index, i] = fromArray[index, i];
                toArray[index, i] = fromArray[index, i] / d;
            }
        }

        public static void LoadStats(string year)
        {
            xlInterface.init("stat2014.xls");
            int pi;
            xlList = new List<xlData>();
            string sString = "";
            int pCount = Globals.PLAYER_ARRAY.GetLength(0);
            Globals.STAT2014_ARRAY = new int[pCount, 11];
            for (int pc = 0; pc < pCount; pc++)
            {
                sString = "select * from [Sheet1$] where player = '";
                sString += Globals.PLAYER_ARRAY[pc, 1];
                sString += "'";
                DataTable dp = xlInterface.DoQuery(sString);
                int tempid = 0;
                pi = 0;
                foreach (DataRow drow in dp.Rows)
                {

                    tempid = Convert.ToInt32(drow["games"].ToString());
                    Globals.STAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["goals"].ToString());
                    Globals.STAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["assists"].ToString());
                    Globals.STAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["points"].ToString());
                    Globals.STAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["plusminus"].ToString());
                    Globals.STAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["ppg"].ToString());
                    Globals.STAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["ppp"].ToString());
                    Globals.STAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["shg"].ToString());
                    Globals.STAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["shp"].ToString());
                    Globals.STAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["gw"].ToString());
                    Globals.STAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["ot"].ToString());
                    Globals.STAT2014_ARRAY[pc, pi++] = tempid;
                }
            }
                Globals.FM_SPLASH.ChangeText("Loading: 2013 Stats . . . ");
                xlInterface.init("stat2013.xls");

                xlList = new List<xlData>();

                Globals.STAT2013_ARRAY = new int[pCount, 11];
                for (int pc = 0; pc < pCount; pc++)
                {
                    sString = "select * from [Sheet1$] where player = '";
                    sString += Globals.PLAYER_ARRAY[pc, 1];
                    sString += "'";
                    DataTable dp = xlInterface.DoQuery(sString);
                    int tempid = 0;
                    pi = 0;
                    if (dp.Rows.Count == 0)
                        CarryStats(Globals.STAT2014_ARRAY, Globals.STAT2013_ARRAY, pc, 1.7f);
                    foreach (DataRow drow in dp.Rows)
                    {

                        tempid = Convert.ToInt32(drow["games"].ToString());
                        Globals.STAT2013_ARRAY[pc, pi++] = Convert.ToInt32(tempid * 1.7);
                        tempid = Convert.ToInt32(drow["goals"].ToString());
                        Globals.STAT2013_ARRAY[pc, pi++] = Convert.ToInt32(tempid * 1.7);
                        tempid = Convert.ToInt32(drow["assists"].ToString());
                        Globals.STAT2013_ARRAY[pc, pi++] = Convert.ToInt32(tempid * 1.7);
                        tempid = Convert.ToInt32(drow["points"].ToString());
                        Globals.STAT2013_ARRAY[pc, pi++] = Convert.ToInt32(tempid * 1.7);
                        tempid = Convert.ToInt32(drow["plusminus"].ToString());
                        Globals.STAT2013_ARRAY[pc, pi++] = Convert.ToInt32(tempid * 1.7);
                        tempid = Convert.ToInt32(drow["ppg"].ToString());
                        Globals.STAT2013_ARRAY[pc, pi++] = Convert.ToInt32(tempid * 1.7);
                        tempid = Convert.ToInt32(drow["ppp"].ToString());
                        Globals.STAT2013_ARRAY[pc, pi++] = Convert.ToInt32(tempid * 1.7);
                        tempid = Convert.ToInt32(drow["shg"].ToString());
                        Globals.STAT2013_ARRAY[pc, pi++] = Convert.ToInt32(tempid * 1.7);
                        tempid = Convert.ToInt32(drow["shp"].ToString());
                        Globals.STAT2013_ARRAY[pc, pi++] = Convert.ToInt32(tempid * 1.7);
                        tempid = Convert.ToInt32(drow["gw"].ToString());
                        Globals.STAT2013_ARRAY[pc, pi++] = Convert.ToInt32(tempid * 1.7);
                        tempid = Convert.ToInt32(drow["ot"].ToString());
                        Globals.STAT2013_ARRAY[pc, pi++] = Convert.ToInt32(tempid * 1.7);
                    }
                }
                Globals.FM_SPLASH.ChangeText("Loading: 2012 Stats . . . ");
                xlInterface.init("stat2012.xls");

                xlList = new List<xlData>();

                Globals.STAT2012_ARRAY = new int[pCount, 11];
                for (int pc = 0; pc < pCount; pc++)
                {
                    sString = "select * from [Sheet1$] where player = '";
                    sString += Globals.PLAYER_ARRAY[pc, 1];
                    sString += "'";
                    DataTable dp = xlInterface.DoQuery(sString);
                    int tempid = 0;
                    pi = 0;
                    if (dp.Rows.Count == 0)
                        CarryStats(Globals.STAT2013_ARRAY, Globals.STAT2012_ARRAY, pc, 1.0f);
                    foreach (DataRow drow in dp.Rows)
                    {

                        tempid = Convert.ToInt32(drow["games"].ToString());
                        Globals.STAT2012_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["goals"].ToString());
                        Globals.STAT2012_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["assists"].ToString());
                        Globals.STAT2012_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["points"].ToString());
                        Globals.STAT2012_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["plusminus"].ToString());
                        Globals.STAT2012_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["ppg"].ToString());
                        Globals.STAT2012_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["ppp"].ToString());
                        Globals.STAT2012_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["shg"].ToString());
                        Globals.STAT2012_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["shp"].ToString());
                        Globals.STAT2012_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["gw"].ToString());
                        Globals.STAT2012_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["ot"].ToString());
                        Globals.STAT2012_ARRAY[pc, pi++] = tempid;
                    }
                }

                Globals.FM_SPLASH.ChangeText("Loading: 2011 Stats . . . ");
                xlInterface.init("stat2011.xls");

                xlList = new List<xlData>();

                Globals.STAT2011_ARRAY = new int[pCount, 11];
                for (int pc = 0; pc < pCount; pc++)
                {
                    sString = "select * from [Sheet1$] where player = '";
                    sString += Globals.PLAYER_ARRAY[pc, 1];
                    sString += "'";
                    DataTable dp = xlInterface.DoQuery(sString);
                    int tempid = 0;
                    pi = 0;
                    if (dp.Rows.Count == 0)
                        CarryStats(Globals.STAT2012_ARRAY, Globals.STAT2011_ARRAY, pc, 1.0f);
                    foreach (DataRow drow in dp.Rows)
                    {

                        tempid = Convert.ToInt32(drow["games"].ToString());
                        Globals.STAT2011_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["goals"].ToString());
                        Globals.STAT2011_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["assists"].ToString());
                        Globals.STAT2011_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["points"].ToString());
                        Globals.STAT2011_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["plusminus"].ToString());
                        Globals.STAT2011_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["ppg"].ToString());
                        Globals.STAT2011_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["ppp"].ToString());
                        Globals.STAT2011_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["shg"].ToString());
                        Globals.STAT2011_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["shp"].ToString());
                        Globals.STAT2011_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["gw"].ToString());
                        Globals.STAT2011_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["ot"].ToString());
                        Globals.STAT2011_ARRAY[pc, pi++] = tempid;
                    }
                }
                Globals.FM_SPLASH.ChangeText("Loading: 2010 Stats . . . ");
                xlInterface.init("stat2010.xls");

                xlList = new List<xlData>();

                Globals.STAT2010_ARRAY = new int[pCount, 11];
                for (int pc = 0; pc < pCount; pc++)
                {
                    sString = "select * from [Sheet1$] where player = '";
                    sString += Globals.PLAYER_ARRAY[pc, 1];
                    sString += "'";
                    DataTable dp = xlInterface.DoQuery(sString);
                    int tempid = 0;
                    pi = 0;
                    if (dp.Rows.Count == 0)
                        CarryStats(Globals.STAT2011_ARRAY, Globals.STAT2010_ARRAY, pc, 1.0f);
                    foreach (DataRow drow in dp.Rows)
                    {

                        tempid = Convert.ToInt32(drow["games"].ToString());
                        Globals.STAT2010_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["goals"].ToString());
                        Globals.STAT2010_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["assists"].ToString());
                        Globals.STAT2010_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["points"].ToString());
                        Globals.STAT2010_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["plusminus"].ToString());
                        Globals.STAT2010_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["ppg"].ToString());
                        Globals.STAT2010_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["ppp"].ToString());
                        Globals.STAT2010_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["shg"].ToString());
                        Globals.STAT2010_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["shp"].ToString());
                        Globals.STAT2010_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["gw"].ToString());
                        Globals.STAT2010_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["ot"].ToString());
                        Globals.STAT2010_ARRAY[pc, pi++] = tempid;
                    }
                }
                Globals.FM_SPLASH.ChangeText("Loading: 2009 Stats . . . ");
                xlInterface.init("stat2009.xls");

                xlList = new List<xlData>();

                Globals.STAT2009_ARRAY = new int[pCount, 11];
                for (int pc = 0; pc < pCount; pc++)
                {
                    sString = "select * from [Sheet1$] where player = '";
                    sString += Globals.PLAYER_ARRAY[pc, 1];
                    sString += "'";
                    DataTable dp = xlInterface.DoQuery(sString);
                    int tempid = 0;
                    pi = 0;
                    if (dp.Rows.Count == 0)
                        CarryStats(Globals.STAT2010_ARRAY, Globals.STAT2009_ARRAY, pc, 1.0f);
                    foreach (DataRow drow in dp.Rows)
                    {

                        tempid = Convert.ToInt32(drow["games"].ToString());
                        Globals.STAT2009_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["goals"].ToString());
                        Globals.STAT2009_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["assists"].ToString());
                        Globals.STAT2009_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["points"].ToString());
                        Globals.STAT2009_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["plusminus"].ToString());
                        Globals.STAT2009_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["ppg"].ToString());
                        Globals.STAT2009_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["ppp"].ToString());
                        Globals.STAT2009_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["shg"].ToString());
                        Globals.STAT2009_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["shp"].ToString());
                        Globals.STAT2009_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["gw"].ToString());
                        Globals.STAT2009_ARRAY[pc, pi++] = tempid;
                        tempid = Convert.ToInt32(drow["ot"].ToString());
                        Globals.STAT2009_ARRAY[pc, pi++] = tempid;
                    }
                }
            


        }


        public static void LoadGoalieStats(string year)
        {
            xlInterface.init("g2014.xls");
            int pi;
            xlList = new List<xlData>();
            string sString = "";
            int pCount = Globals.GOALIE_ARRAY.GetLength(0);
            Globals.GSTAT2014_ARRAY = new double[pCount, 12];
            for (int pc = 0; pc < pCount; pc++)
            {
                sString = "select * from [Sheet1$] where player = '";
                sString += Globals.GOALIE_ARRAY[pc, 1];
                sString += "'";
                DataTable dp = xlInterface.DoQuery(sString);
                double tempid = 0;
                pi = 0;
                foreach (DataRow drow in dp.Rows)
                {

                    tempid = Convert.ToDouble(drow["starts"].ToString());
                    Globals.GSTAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["wins"].ToString());
                    Globals.GSTAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["loss"].ToString());
                    Globals.GSTAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["ot"].ToString());
                    Globals.GSTAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["sa"].ToString());
                    Globals.GSTAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["ga"].ToString());
                    Globals.GSTAT2014_ARRAY[pc, pi++] = tempid;

                    Globals.GSTAT2014_ARRAY[pc, pi++] = Globals.GSTAT2014_ARRAY[pc, 4] - Globals.GSTAT2014_ARRAY[pc, 5];

                    tempid = Convert.ToDouble(drow["goalsavg"].ToString());
                    Globals.GSTAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["svp"].ToString());
                    Globals.GSTAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["so"].ToString());
                    Globals.GSTAT2014_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["assists"].ToString());
                    Globals.GSTAT2014_ARRAY[pc, pi++] = tempid; 
                }
            }


            xlInterface.init("g2013.xls");
            xlList = new List<xlData>();
            sString = "";
            pCount = Globals.GOALIE_ARRAY.GetLength(0);
            Globals.GSTAT2013_ARRAY = new double[pCount, 12];
            for (int pc = 0; pc < pCount; pc++)
            {
                sString = "select * from [Sheet1$] where player = '";
                sString += Globals.GOALIE_ARRAY[pc, 1];
                sString += "'";
                DataTable dp = xlInterface.DoQuery(sString);
                double tempid = 0;
                pi = 0; 
                if (dp.Rows.Count == 0)
                    CarryGStats(Globals.GSTAT2014_ARRAY, Globals.GSTAT2013_ARRAY, pc, 1.7f);

                foreach (DataRow drow in dp.Rows)
                {
                    tempid = Convert.ToDouble(drow["starts"].ToString());
                    Globals.GSTAT2013_ARRAY[pc, pi++] = tempid * 1.7;
                    tempid = Convert.ToDouble(drow["wins"].ToString());
                    Globals.GSTAT2013_ARRAY[pc, pi++] = tempid * 1.7;
                    tempid = Convert.ToDouble(drow["loss"].ToString());
                    Globals.GSTAT2013_ARRAY[pc, pi++] = tempid * 1.7;
                    tempid = Convert.ToDouble(drow["ot"].ToString());
                    Globals.GSTAT2013_ARRAY[pc, pi++] = tempid * 1.7;
                    tempid = Convert.ToDouble(drow["sa"].ToString());
                    Globals.GSTAT2013_ARRAY[pc, pi++] = tempid * 1.7;
                    tempid = Convert.ToDouble(drow["ga"].ToString());
                    Globals.GSTAT2013_ARRAY[pc, pi++] = tempid * 1.7;

                    Globals.GSTAT2013_ARRAY[pc, pi++] = Globals.GSTAT2013_ARRAY[pc, 4] - Globals.GSTAT2013_ARRAY[pc, 5];
                    
                    tempid = Convert.ToDouble(drow["goalsavg"].ToString());
                    Globals.GSTAT2013_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["svp"].ToString());
                    Globals.GSTAT2013_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["so"].ToString());
                    Globals.GSTAT2013_ARRAY[pc, pi++] = tempid * 1.7;
                    tempid = Convert.ToInt32(drow["assists"].ToString());
                    Globals.GSTAT2013_ARRAY[pc, pi++] = tempid * 1.7;
                }
            }


            xlInterface.init("g2012.xls");
            xlList = new List<xlData>();
            sString = "";
            pCount = Globals.GOALIE_ARRAY.GetLength(0);
            Globals.GSTAT2012_ARRAY = new double[pCount, 11];
            for (int pc = 0; pc < pCount; pc++)
            {
                sString = "select * from [Sheet1$] where player = '";
                sString += Globals.GOALIE_ARRAY[pc, 1];
                sString += "'";
                DataTable dp = xlInterface.DoQuery(sString);
                double tempid = 0;
                pi = 0; 
                if (dp.Rows.Count == 0)
                    CarryGStats(Globals.GSTAT2013_ARRAY, Globals.GSTAT2012_ARRAY, pc, 1.0f);
                foreach (DataRow drow in dp.Rows)
                {

                    tempid = Convert.ToDouble(drow["starts"].ToString());
                    Globals.GSTAT2012_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["wins"].ToString());
                    Globals.GSTAT2012_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["loss"].ToString());
                    Globals.GSTAT2012_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["ot"].ToString());
                    Globals.GSTAT2012_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["sa"].ToString());
                    Globals.GSTAT2012_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["ga"].ToString());
                    Globals.GSTAT2012_ARRAY[pc, pi++] = tempid;

                    Globals.GSTAT2012_ARRAY[pc, pi++] = Globals.GSTAT2012_ARRAY[pc, 4] - Globals.GSTAT2012_ARRAY[pc, 5];

                    tempid = Convert.ToDouble(drow["goalsavg"].ToString());
                    Globals.GSTAT2012_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["svp"].ToString());
                    Globals.GSTAT2012_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["so"].ToString());
                    Globals.GSTAT2012_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["assists"].ToString());
                    Globals.GSTAT2012_ARRAY[pc, pi++] = tempid;
                }
            }


            xlInterface.init("g2011.xls");
            xlList = new List<xlData>();
            sString = "";
            pCount = Globals.GOALIE_ARRAY.GetLength(0);
            Globals.GSTAT2011_ARRAY = new double[pCount, 12];
            for (int pc = 0; pc < pCount; pc++)
            {
                sString = "select * from [Sheet1$] where player = '";
                sString += Globals.GOALIE_ARRAY[pc, 1];
                sString += "'";
                DataTable dp = xlInterface.DoQuery(sString);
                double tempid = 0;
                pi = 0;
                if (dp.Rows.Count == 0)
                    CarryGStats(Globals.GSTAT2012_ARRAY, Globals.GSTAT2011_ARRAY, pc, 1.0f);
                foreach (DataRow drow in dp.Rows)
                {

                    tempid = Convert.ToDouble(drow["starts"].ToString());
                    Globals.GSTAT2011_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["wins"].ToString());
                    Globals.GSTAT2011_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["loss"].ToString());
                    Globals.GSTAT2011_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["ot"].ToString());
                    Globals.GSTAT2011_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["sa"].ToString());
                    Globals.GSTAT2011_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["ga"].ToString());
                    Globals.GSTAT2011_ARRAY[pc, pi++] = tempid;

                    Globals.GSTAT2011_ARRAY[pc, pi++] = Globals.GSTAT2011_ARRAY[pc, 4] - Globals.GSTAT2011_ARRAY[pc, 5];

                    tempid = Convert.ToDouble(drow["goalsavg"].ToString());
                    Globals.GSTAT2011_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["svp"].ToString());
                    Globals.GSTAT2011_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["so"].ToString());
                    Globals.GSTAT2011_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["assists"].ToString());
                    Globals.GSTAT2011_ARRAY[pc, pi++] = tempid;
                }
            }


            xlInterface.init("g2010.xls");
            xlList = new List<xlData>();
            sString = "";
            pCount = Globals.GOALIE_ARRAY.GetLength(0);
            Globals.GSTAT2010_ARRAY = new double[pCount, 12];
            for (int pc = 0; pc < pCount; pc++)
            {
                sString = "select * from [Sheet1$] where player = '";
                sString += Globals.GOALIE_ARRAY[pc, 1];
                sString += "'";
                DataTable dp = xlInterface.DoQuery(sString);
                double tempid = 0;
                pi = 0;
                if (dp.Rows.Count == 0)
                    CarryGStats(Globals.GSTAT2011_ARRAY, Globals.GSTAT2010_ARRAY, pc, 1.0f);
                foreach (DataRow drow in dp.Rows)
                {

                    tempid = Convert.ToDouble(drow["starts"].ToString());
                    Globals.GSTAT2010_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["wins"].ToString());
                    Globals.GSTAT2010_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["loss"].ToString());
                    Globals.GSTAT2010_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["ot"].ToString());
                    Globals.GSTAT2010_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["sa"].ToString());
                    Globals.GSTAT2010_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["ga"].ToString());
                    Globals.GSTAT2010_ARRAY[pc, pi++] = tempid;

                    Globals.GSTAT2010_ARRAY[pc, pi++] = Globals.GSTAT2010_ARRAY[pc, 4] - Globals.GSTAT2010_ARRAY[pc, 5];

                    tempid = Convert.ToDouble(drow["goalsavg"].ToString());
                    Globals.GSTAT2010_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["svp"].ToString());
                    Globals.GSTAT2010_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["so"].ToString());
                    Globals.GSTAT2010_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["assists"].ToString());
                    Globals.GSTAT2010_ARRAY[pc, pi++] = tempid;
                }
            }


            xlInterface.init("g2009.xls");
            xlList = new List<xlData>();
            sString = "";
            pCount = Globals.GOALIE_ARRAY.GetLength(0);
            Globals.GSTAT2009_ARRAY = new double[pCount, 12];
            for (int pc = 0; pc < pCount; pc++)
            {
                sString = "select * from [Sheet1$] where player = '";
                sString += Globals.GOALIE_ARRAY[pc, 1];
                sString += "'";
                DataTable dp = xlInterface.DoQuery(sString);
                double tempid = 0;
                pi = 0;
                if (dp.Rows.Count == 0)
                    CarryGStats(Globals.GSTAT2010_ARRAY, Globals.GSTAT2009_ARRAY, pc, 1.0f);
                foreach (DataRow drow in dp.Rows)
                {

                    tempid = Convert.ToDouble(drow["starts"].ToString());
                    Globals.GSTAT2009_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["wins"].ToString());
                    Globals.GSTAT2009_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["loss"].ToString());
                    Globals.GSTAT2009_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["ot"].ToString());
                    Globals.GSTAT2009_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["sa"].ToString());
                    Globals.GSTAT2009_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["ga"].ToString());
                    Globals.GSTAT2009_ARRAY[pc, pi++] = tempid;

                    Globals.GSTAT2009_ARRAY[pc, pi++] = Globals.GSTAT2009_ARRAY[pc, 4] - Globals.GSTAT2009_ARRAY[pc, 5];

                    tempid = Convert.ToDouble(drow["goalsavg"].ToString());
                    Globals.GSTAT2009_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["svp"].ToString());
                    Globals.GSTAT2009_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToDouble(drow["so"].ToString());
                    Globals.GSTAT2009_ARRAY[pc, pi++] = tempid;
                    tempid = Convert.ToInt32(drow["assists"].ToString());
                    Globals.GSTAT2009_ARRAY[pc, pi++] = tempid;
                }
            }


        }

        static List<xlData> xlList;

        public static void LoadContracts()
        {

            xlInterface.init("contract.xls");
            string cName = "";
            string table = "Sheet1$";
            string qry = "SELECT * FROM " + "[" + table + "];";
            DataTable dt = xlInterface.DoQuery(qry);
            foreach (DataColumn c in dt.Columns)
            {
                cName = c.ColumnName;
            }


            string sString;
            xlList = new List<xlData>();

            int rows = 2;

            sString = "select ";
            for (int i = 0; i < rows - 1; i++)
            {
                if (i > 0)
                    sString += ", ";
                xlData id = new xlData();
                id.ID = cName;
                xlList.Add(id);
                sString += cName;
                sString += " ";

            }

            sString += " from [Sheet1$];";
            dt = xlInterface.DoQuery(sString);
            int lSize = dt.Rows.Count;
            Globals.CONTRACT_ARRAY = new string[lSize];
            string pid = "";
            int pi = 0;
            foreach (DataRow drow in dt.Rows)
            {
                for (int j = 0; j < xlList.Count; j++)
                {
                    pid = drow[xlList[j].ID].ToString();
                    Globals.CONTRACT_ARRAY[pi] = pid;
                    pi++;
                }
            }
        }


        public static void btImport_Click()
        {

        }

        public static void LoadSportsnet()
        {

            xlInterface.init("sportsnet.xls");
            string[] cName;
            
            string table = "Sheet1$";
            string qry = "SELECT * FROM " + "[" + table + "];";
            DataTable dt = xlInterface.DoQuery(qry);
            cName = new string[dt.Columns.Count];
            int i = 0;
            foreach (DataColumn c in dt.Columns)
            {
                cName[i++] = c.ColumnName;
            }


            string sString;
            xlList = new List<xlData>();

            int rows = cName.Length + 1;

            sString = "select ";
            for (i = 0; i < rows - 1; i++)
            {
                if (i > 0)
                    sString += ", ";
                xlData id = new xlData();
                id.ID = cName[i];
                xlList.Add(id);
                sString += cName[i];
                sString += " ";

            }

            sString += " from [Sheet1$];";
            dt = xlInterface.DoQuery(sString);
            int lSize = dt.Rows.Count;
            Globals.SPORTSNET_ARRAY = new string[lSize, 2];
            string pid = "";
            int pi = 0;
            foreach (DataRow drow in dt.Rows)
            {
                for (int j = 0; j < xlList.Count; j++)
                {
                    pid = drow[xlList[j].ID].ToString();
                    Globals.SPORTSNET_ARRAY[pi, j] = pid; 
                }

                pi++;
            }

            xlInterface.init("injury.xls");

            table = "Sheet1$";
            qry = "SELECT * FROM " + "[" + table + "];";
            dt = xlInterface.DoQuery(qry);
            cName = new string[dt.Columns.Count];
            i = 0;
            foreach (DataColumn c in dt.Columns)
            {
                cName[i++] = c.ColumnName;
            }

            xlList = new List<xlData>();

            rows = cName.Length + 1;

            sString = "select ";
            for (i = 0; i < rows - 1; i++)
            {
                if (i > 0)
                    sString += ", ";
                xlData id = new xlData();
                id.ID = cName[i];
                xlList.Add(id);
                sString += cName[i];
                sString += " ";

            }

            sString += " from [Sheet1$];";
            dt = xlInterface.DoQuery(sString);
            lSize = dt.Rows.Count;
            Globals.INJURY_ARRAY = new string[lSize, 2];
            pid = "";
            pi = 0;
            foreach (DataRow drow in dt.Rows)
            {
                for (int j = 0; j < xlList.Count; j++)
                {
                    pid = drow[xlList[j].ID].ToString();
                    Globals.INJURY_ARRAY[pi, j] = pid;
                }

                pi++;
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

        public static double[,] GSTAT2014_ARRAY;
        public static double[,] GSTAT2013_ARRAY;
        public static double[,] GSTAT2012_ARRAY;
        public static double[,] GSTAT2011_ARRAY;
        public static double[,] GSTAT2010_ARRAY;
        public static double[,] GSTAT2009_ARRAY;
        public static string[,] GOALIE_ARRAY;


        public static string[,] INJURY_ARRAY;
        public static string[] CONTRACT_ARRAY;
        public static string[,] SPORTSNET_ARRAY;
        public static string[] FAKEHOCKEY_ARRAY;
        public static int[] WATCH_ARRAY;

    }
}
