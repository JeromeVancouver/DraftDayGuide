using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace DraftDayGuide
{
    public partial class fmMain : Form
    {

        int gp2014, g2014, a2014, p2014, plus2014, ppg2014, ppp2014, shg2014, shp2014, gw2014, ot2014;
        int avggp, avgg, avga, avgp, avgplus, avgppg, avgppp, avgppa, avgshg, avgsha, avggw, avgot;
        int curgp, curg, cura, curp, curplus, curppg, curppp, curshg, curshp, curgw, curot;

        public fmMain()
        {
            InitializeComponent();
        }

        public void ClearPartGrid()
        {
            dgPlayer.Rows.Clear();
            dgPlayer.RowCount = 1;
            dgPlayer.Columns.Clear();

        }

        private void AddToAvg()
        {
            avggp += curgp;
            avgg += curg;
            avga += cura;
            avgp += curp;
            avgplus += curplus;
            avgppg += curppg;
            avgppp += curppp;
            avgppa += (curppp - curppg);
            avgshg += curshg;
            avgsha += (curshp - curshg);
            avggw += curgw;
            avgot += curot;
        }

        private void GetStats(string pName)
        {
            MySqlDataReader rdr = null;
            //pName = "Nathan MacKinnon";
            rdr = MysqlInterface.DoQuery("SELECT games, goals, assists, points, plusminus, ppg, ppp, shg, shp, gw, ot" + 
            " FROM stat2014 where player = '" + pName + "';");

            while (rdr.Read())
            {
                curgp = avggp = gp2014 = rdr.GetInt32(0);
                curg = avgg = g2014 = rdr.GetInt32(1);
                cura = avga = a2014 = rdr.GetInt32(2);
                curp = avgp = p2014 = rdr.GetInt32(3);
                curplus = avgplus = plus2014 = rdr.GetInt32(4);
                curppg = avgppg = ppg2014 = rdr.GetInt32(5);
                curppp = avgppp = ppp2014 = rdr.GetInt32(6);
                avgppa = avgppp - avgg;
                curshg = avgshg = shg2014 = rdr.GetInt32(7);
                curshp  =shp2014 = rdr.GetInt32(8);
                avgsha = shp2014 - shg2014;
                curgw = avggw = gw2014 = rdr.GetInt32(9);
                curot = avgot = ot2014 = rdr.GetInt32(10);
            }

            rdr = MysqlInterface.DoQuery("SELECT games, goals, assists, points, plusminus, ppg, ppp, shg, shp, gw, ot" +
            " FROM stat2013 where player = '" + pName + "';");
            int index = 0;
            while (rdr.Read())
            {
                curgp = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curg = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                cura = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curp = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curplus = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curppg = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curppp = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curshg = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curshp = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curgw = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curot = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
            }
            AddToAvg();
            rdr = MysqlInterface.DoQuery("SELECT games, goals, assists, points, plusminus, ppg, ppp, shg, shp, gw, ot" +
            " FROM stat2012 where player = '" + pName + "';");
            index = 0;
            while (rdr.Read())
            {
                curgp = Convert.ToInt32(rdr.GetDouble(index++));
                curg = Convert.ToInt32(rdr.GetDouble(index++));
                cura = Convert.ToInt32(rdr.GetDouble(index++));
                curp = Convert.ToInt32(rdr.GetDouble(index++));
                curplus = Convert.ToInt32(rdr.GetDouble(index++));
                curppg = Convert.ToInt32(rdr.GetDouble(index++));
                curppp = Convert.ToInt32(rdr.GetDouble(index++));
                curshg = Convert.ToInt32(rdr.GetDouble(index++));
                curshp = Convert.ToInt32(rdr.GetDouble(index++));
                curgw = Convert.ToInt32(rdr.GetDouble(index++));
                curot = Convert.ToInt32(rdr.GetDouble(index++));
            }
            AddToAvg();
            rdr = MysqlInterface.DoQuery("SELECT games, goals, assists, points, plusminus, ppg, ppp, shg, shp, gw, ot" +
            " FROM stat2011 where player = '" + pName + "';");
            index = 0;
            while (rdr.Read())
            {
                curgp = Convert.ToInt32(rdr.GetDouble(index++));
                curg = Convert.ToInt32(rdr.GetDouble(index++));
                cura = Convert.ToInt32(rdr.GetDouble(index++));
                curp = Convert.ToInt32(rdr.GetDouble(index++));
                curplus = Convert.ToInt32(rdr.GetDouble(index++));
                curppg = Convert.ToInt32(rdr.GetDouble(index++));
                curppp = Convert.ToInt32(rdr.GetDouble(index++));
                curshg = Convert.ToInt32(rdr.GetDouble(index++));
                curshp = Convert.ToInt32(rdr.GetDouble(index++));
                curgw = Convert.ToInt32(rdr.GetDouble(index++));
                curot = Convert.ToInt32(rdr.GetDouble(index++));
            }
            AddToAvg();
            rdr = MysqlInterface.DoQuery("SELECT games, goals, assists, points, plusminus, ppg, ppp, shg, shp, gw, ot" +
            " FROM stat2010 where player = '" + pName + "';");
            index = 0;
            while (rdr.Read())
            {
                curgp = Convert.ToInt32(rdr.GetDouble(index++));
                curg = Convert.ToInt32(rdr.GetDouble(index++));
                cura = Convert.ToInt32(rdr.GetDouble(index++));
                curp = Convert.ToInt32(rdr.GetDouble(index++));
                curplus = Convert.ToInt32(rdr.GetDouble(index++));
                curppg = Convert.ToInt32(rdr.GetDouble(index++));
                curppp = Convert.ToInt32(rdr.GetDouble(index++));
                curshg = Convert.ToInt32(rdr.GetDouble(index++));
                curshp = Convert.ToInt32(rdr.GetDouble(index++));
                curgw = Convert.ToInt32(rdr.GetDouble(index++));
                curot = Convert.ToInt32(rdr.GetDouble(index++));
            }
            AddToAvg();
            rdr = MysqlInterface.DoQuery("SELECT games, goals, assists, points, plusminus, ppg, ppp, shg, shp, gw, ot" +
            " FROM stat2009 where player = '" + pName + "';");
            index = 0;
            while (rdr.Read())
            {
                curgp = Convert.ToInt32(rdr.GetDouble(index++));
                curg = Convert.ToInt32(rdr.GetDouble(index++));
                cura = Convert.ToInt32(rdr.GetDouble(index++));
                curp = Convert.ToInt32(rdr.GetDouble(index++));
                curplus = Convert.ToInt32(rdr.GetDouble(index++));
                curppg = Convert.ToInt32(rdr.GetDouble(index++));
                curppp = Convert.ToInt32(rdr.GetDouble(index++));
                curshg = Convert.ToInt32(rdr.GetDouble(index++));
                curshp = Convert.ToInt32(rdr.GetDouble(index++));
                curgw = Convert.ToInt32(rdr.GetDouble(index++));
                curot = Convert.ToInt32(rdr.GetDouble(index++));
            }
            AddToAvg();


        }

        public void CustomKeyPress()
        {
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            Globals.LoadPlayers();
            Globals.LoadContracts();
            //dgPlayer.KeyPress CustomKeyPress;
        }

        private void customSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            int temp;
            bool isNumeric = int.TryParse(e.CellValue1.ToString(), out temp);
            if (!isNumeric)
                return;
            int a = int.Parse(e.CellValue1.ToString()), b = int.Parse(e.CellValue2.ToString());

            // If the cell value is already an integer, just cast it instead of parsing

            e.SortResult = a.CompareTo(b);

            e.Handled = true;
        }

        private void AddColumn(string name, int width, DataGridView dg, bool str)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            string column = name;
            col.HeaderText = column;
            col.Width = width;
            col.Name = "f" + column;
            if (str)
                col.ValueType = typeof(string);
            else
                col.ValueType = typeof(Double);
            dg.Columns.Add(col);
        }

        private bool CheckSignedList(string pName)
        {
            for (int i = 0; i < lbSigned.Items.Count; i++)
            {
                if (pName == lbSigned.Items[i].ToString())
                    return true;
            }
            return false;
        }

        private bool CurrentContract(string pName)
        {
            int count = Globals.CONTRACT_ARRAY.Length;
            for (int i = 0; i < count; i++)
            {
                if(Globals.CONTRACT_ARRAY[i] == pName)
                    return true;
            }
            return false;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {

            ClearPartGrid();
            dgPlayer.SortCompare += customSortCompare;
            AddColumn("Player", 125, dgPlayer, true);
            AddColumn("Age", 25, dgPlayer, true);
            AddColumn("2014 Total", 50, dgPlayer, false);
            AddColumn("AVG Total", 50, dgPlayer, false);
            AddColumn("P", 25, dgPlayer, false);
            AddColumn("2014 GP", 50, dgPlayer, false);
            AddColumn("2014 G", 50, dgPlayer, false);
            AddColumn("2014 A", 50, dgPlayer, false);
            AddColumn("2014 P", 50, dgPlayer, false);
            AddColumn("2014 +/-", 50, dgPlayer, false);
            AddColumn("2014 ppg", 50, dgPlayer, false);
            AddColumn("2014 ppp", 50, dgPlayer, false);
            AddColumn("2014 shg", 50, dgPlayer, false);
            AddColumn("2014 shp", 50, dgPlayer, false);
            AddColumn("2014 gw", 50, dgPlayer, false);
            AddColumn("2014 ot", 50, dgPlayer, false);
            AddColumn("AVG GP", 50, dgPlayer, false);
            AddColumn("AVG G", 50, dgPlayer, false);
            AddColumn("AVG A", 50, dgPlayer, false);
            AddColumn("AVG P", 50, dgPlayer, false);
            AddColumn("AVG +/-", 50, dgPlayer, false);
            AddColumn("AVG ppg", 50, dgPlayer, false);
            AddColumn("AVG ppp", 50, dgPlayer, false);
            AddColumn("AVG shg", 50, dgPlayer, false);
            AddColumn("AVG shp", 50, dgPlayer, false);
            AddColumn("AVG gw", 50, dgPlayer, false);
            AddColumn("AVG ot", 50, dgPlayer, false);

            int count = 0;
            string p;
            string d;
            string a;
            count = Globals.PLAYER_ARRAY.GetLength(0);
            for (int i = 0; i < count; i++)
            {
                p = Globals.PLAYER_ARRAY[i, 0];
                if (CheckSignedList(p))
                    continue;
                d = Globals.PLAYER_ARRAY[i, 1];
                a = Globals.PLAYER_ARRAY[i, 2];
                if ((chLeft.Checked == true && d == "L") || (chRight.Checked == true && d == "R") || (chCenter.Checked == true && d == "C") || (chDefense.Checked == true && d == "D"))
                {
                    GetStats(p);
                    int avgtotal = (avgg + avga + avgp + avgplus + avgppg + avgppp + (avgppp - avgppg) + avgshg + avgsha + avggw)/6;
                    int total = g2014 + a2014 + p2014 + plus2014 +ppg2014 + ppp2014 + (ppp2014 - ppg2014) + shg2014 + 
                        (shp2014 - shg2014) + gw2014;

                    avggp = avggp / 6;
                    avgg = avgg / 6;
                    avga = avga / 6;
                    avgp = avgp / 6;
                    avgplus = avgplus / 6;
                    avgppg = avgppg / 6;
                    avgppp = avgppp / 6;
                    avgppa = avgppa / 6;
                    avgshg = avgshg / 6;
                    avgsha = avgsha / 6;
                    avggw = avggw / 6;
                    avgot = avgot / 6;

                    string[] row = { p, a, total.ToString(), avgtotal.ToString(), d, gp2014.ToString(), g2014.ToString(), a2014.ToString(), p2014.ToString(), plus2014.ToString(), ppg2014.ToString(), ppp2014.ToString(), shg2014.ToString(), shp2014.ToString(), gw2014.ToString(), ot2014.ToString(),
                                   Convert.ToString(avggp) , Convert.ToString(avgg), Convert.ToString(avga), 
                                   Convert.ToString(avgp), Convert.ToString(avgplus), Convert.ToString(avgppg), 
                                   Convert.ToString(avgppp), Convert.ToString(avgshg), Convert.ToString(avgsha), 
                                   Convert.ToString(avggw), Convert.ToString(avgot)};
                    dgPlayer.Rows.Add(row);

                    if (CurrentContract(p))
                    {
                        int r = dgPlayer.RowCount-2;
                        dgPlayer[0, r].Style.BackColor = Color.LightGreen;
                    }
                }

            }
        }

        private void UpdateTextBox(Label l, string year, string points)
        {
            l.Text = year + points;
        }

        private void Update2014(string pName)
        {

            MySqlDataReader rdr = null;
            string qry = "select games, goals, assists, points, plusminus, ppg, ppp, shg, shp, gw, ot from stat2014 " +
                "where player = '" + pName + "';";
            rdr = MysqlInterface.DoQuery(qry);
            int index = 0;
            while (rdr.Read())
            {
                curgp = Convert.ToInt32(rdr.GetDouble(index++));
                curg = Convert.ToInt32(rdr.GetDouble(index++));
                cura = Convert.ToInt32(rdr.GetDouble(index++));
                curp = Convert.ToInt32(rdr.GetDouble(index++));
                curplus = Convert.ToInt32(rdr.GetDouble(index++));
                curppg = Convert.ToInt32(rdr.GetDouble(index++));
                curppp = Convert.ToInt32(rdr.GetDouble(index++));
                curshg = Convert.ToInt32(rdr.GetDouble(index++));
                curshp = Convert.ToInt32(rdr.GetDouble(index++));
                curgw = Convert.ToInt32(rdr.GetDouble(index++));
                curot = Convert.ToInt32(rdr.GetDouble(index++));
            }
            //lbGAVG.Text = "AVG: " + rdr.GetString(index++);
            UpdateTextBox(lbGP2014, "2014: ", curgp.ToString());
            UpdateTextBox(lbG2014, "2014: ", curg.ToString());
            UpdateTextBox(lbA2014, "2014: ", cura.ToString());
            UpdateTextBox(lbP2014, "2014: ", curp.ToString());
            UpdateTextBox(lbPM2014, "2014: ", curplus.ToString());
            UpdateTextBox(lbPPG2014, "2014: ", curppg.ToString());
            UpdateTextBox(lbPPA2014, "2014: ", (curppp - curppg).ToString());
            UpdateTextBox(lbPPP2014, "2014: ", curppp.ToString());
            UpdateTextBox(lbSHG2014, "2014: ", curshg.ToString());
            UpdateTextBox(lbSHP2014, "2014: ", (curshp - curshg).ToString());
            UpdateTextBox(lbGW2014, "2014: ", curgw.ToString());
            UpdateTextBox(lbOT2014, "2014: ", curot.ToString());
            int total = curg + cura + curp + curplus + curppg + curppp + (curppp - curppg) + curshg + (curshp - curshg) + curgw;
            UpdateTextBox(lbTOTAL2014, "2014: ", total.ToString());
            index = 0;
        }

        private void Update2013(string pName)
        {

            MySqlDataReader rdr = null;
            string qry = "select games, goals, assists, points, plusminus, ppg, ppp, shg, shp, gw, ot from stat2013 " +
                "where player = '" + pName + "';";
            rdr = MysqlInterface.DoQuery(qry);
            int index = 0;
            while (rdr.Read())
            {
                curgp = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curg = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                cura = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curp = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curplus = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curppg = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curppp = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curshg = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curshp = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curgw = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                curot = Convert.ToInt32(rdr.GetDouble(index++) * 1.7);
                //lbGAVG.Text = "AVG: " + rdr.GetString(index++);
            }
            UpdateTextBox(lbGP2013, "2013: ", curgp.ToString());
            UpdateTextBox(lbG2013, "2013: ", curg.ToString());
            UpdateTextBox(lbA2013, "2013: ", cura.ToString());
            UpdateTextBox(lbP2013, "2013: ", curp.ToString());
            UpdateTextBox(lbPM2013, "2013: ", curplus.ToString());
            UpdateTextBox(lbPPG2013, "2013: ", curppg.ToString());
            UpdateTextBox(lbPPA2013, "2013: ", (curppp - curppg).ToString());
            UpdateTextBox(lbPPP2013, "2013: ", curppp.ToString());
            UpdateTextBox(lbSHG2013, "2013: ", curshg.ToString());
            UpdateTextBox(lbSHP2013, "2013: ", (curshp - curshg).ToString());
            UpdateTextBox(lbGW2013, "2013: ", curgw.ToString());
            UpdateTextBox(lbOT2013, "2013: ", curot.ToString());
            int total = curg + cura + curp + curplus + curppg + curppp + (curppp - curppg) + curshg + (curshp - curshg) + curgw;
            UpdateTextBox(lbTOTAL2013, "2013: ", total.ToString());
            index = 0;
        }

        private void Update2012(string pName)
        {

            MySqlDataReader rdr = null;
            string qry = "select games, goals, assists, points, plusminus, ppg, ppp, shg, shp, gw, ot from stat2012 " +
                "where player = '" + pName + "';";
            rdr = MysqlInterface.DoQuery(qry);
            int index = 0;
            while (rdr.Read())
            {
                curgp = Convert.ToInt32(rdr.GetDouble(index++));
                curg = Convert.ToInt32(rdr.GetDouble(index++));
                cura = Convert.ToInt32(rdr.GetDouble(index++));
                curp = Convert.ToInt32(rdr.GetDouble(index++));
                curplus = Convert.ToInt32(rdr.GetDouble(index++));
                curppg = Convert.ToInt32(rdr.GetDouble(index++));
                curppp = Convert.ToInt32(rdr.GetDouble(index++));
                curshg = Convert.ToInt32(rdr.GetDouble(index++));
                curshp = Convert.ToInt32(rdr.GetDouble(index++));
                curgw = Convert.ToInt32(rdr.GetDouble(index++));
                curot = Convert.ToInt32(rdr.GetDouble(index++));
                //lbGAVG.Text = "AVG: " + rdr.GetString(index++);
            }
            UpdateTextBox(lbGP2012, "2012: ", curgp.ToString());
            UpdateTextBox(lbG2012, "2012: ", curg.ToString());
            UpdateTextBox(lbA2012, "2012: ", cura.ToString());
            UpdateTextBox(lbP2012, "2012: ", curp.ToString());
            UpdateTextBox(lbPM2012, "2012: ", curplus.ToString());
            UpdateTextBox(lbPPG2012, "2012: ", curppg.ToString());
            UpdateTextBox(lbPPA2012, "2012: ", (curppp - curppg).ToString());
            UpdateTextBox(lbPPP2012, "2012: ", curppp.ToString());
            UpdateTextBox(lbSHG2012, "2012: ", curshg.ToString());
            UpdateTextBox(lbSHP2012, "2012: ", (curshp - curshg).ToString());
            UpdateTextBox(lbGW2012, "2012: ", curgw.ToString());
            UpdateTextBox(lbOT2012, "2012: ", curot.ToString());
            int total = curg + cura + curp + curplus + curppg + curppp + (curppp - curppg) + curshg + (curshp - curshg) + curgw;
            UpdateTextBox(lbTOTAL2012, "2012: ", total.ToString());
            index = 0;
        }

        private void Update2011(string pName)
        {

            MySqlDataReader rdr = null;
            string qry = "select games, goals, assists, points, plusminus, ppg, ppp, shg, shp, gw, ot from stat2011 " +
                "where player = '" + pName + "';";
            rdr = MysqlInterface.DoQuery(qry);
            int index = 0;
            while (rdr.Read())
            {
                curgp = Convert.ToInt32(rdr.GetDouble(index++));
                curg = Convert.ToInt32(rdr.GetDouble(index++));
                cura = Convert.ToInt32(rdr.GetDouble(index++));
                curp = Convert.ToInt32(rdr.GetDouble(index++));
                curplus = Convert.ToInt32(rdr.GetDouble(index++));
                curppg = Convert.ToInt32(rdr.GetDouble(index++));
                curppp = Convert.ToInt32(rdr.GetDouble(index++));
                curshg = Convert.ToInt32(rdr.GetDouble(index++));
                curshp = Convert.ToInt32(rdr.GetDouble(index++));
                curgw = Convert.ToInt32(rdr.GetDouble(index++));
                curot = Convert.ToInt32(rdr.GetDouble(index++));
                //lbGAVG.Text = "AVG: " + rdr.GetString(index++);
            }
            UpdateTextBox(lbGP2011, "2011: ", curgp.ToString());
            UpdateTextBox(lbG2011, "2011: ", curg.ToString());
            UpdateTextBox(lbA2011, "2011: ", cura.ToString());
            UpdateTextBox(lbP2011, "2011: ", curp.ToString());
            UpdateTextBox(lbPM2011, "2011: ", curplus.ToString());
            UpdateTextBox(lbPPG2011, "2011: ", curppg.ToString());
            UpdateTextBox(lbPPA2011, "2011: ", (curppp - curppg).ToString());
            UpdateTextBox(lbPPP2011, "2011: ", curppp.ToString());
            UpdateTextBox(lbSHG2011, "2011: ", curshg.ToString());
            UpdateTextBox(lbSHP2011, "2011: ", (curshp - curshg).ToString());
            UpdateTextBox(lbGW2011, "2011: ", curgw.ToString());
            UpdateTextBox(lbOT2011, "2011: ", curot.ToString());
            int total = curg + cura + curp + curplus + curppg + curppp + (curppp - curppg) + curshg + (curshp - curshg) + curgw;
            UpdateTextBox(lbTOTAL2011, "2011: ", total.ToString());
            index = 0;
        }

        private void Update2010(string pName)
        {

            MySqlDataReader rdr = null;
            string qry = "select games, goals, assists, points, plusminus, ppg, ppp, shg, shp, gw, ot from stat2010 " +
                "where player = '" + pName + "';";
            rdr = MysqlInterface.DoQuery(qry);
            int index = 0;
            while (rdr.Read())
            {
                curgp = Convert.ToInt32(rdr.GetDouble(index++));
                curg = Convert.ToInt32(rdr.GetDouble(index++));
                cura = Convert.ToInt32(rdr.GetDouble(index++));
                curp = Convert.ToInt32(rdr.GetDouble(index++));
                curplus = Convert.ToInt32(rdr.GetDouble(index++));
                curppg = Convert.ToInt32(rdr.GetDouble(index++));
                curppp = Convert.ToInt32(rdr.GetDouble(index++));
                curshg = Convert.ToInt32(rdr.GetDouble(index++));
                curshp = Convert.ToInt32(rdr.GetDouble(index++));
                curgw = Convert.ToInt32(rdr.GetDouble(index++));
                curot = Convert.ToInt32(rdr.GetDouble(index++));
                //lbGAVG.Text = "AVG: " + rdr.GetString(index++);
            }
            UpdateTextBox(lbGP2010, "2010: ", curgp.ToString());
            UpdateTextBox(lbG2010, "2010: ", curg.ToString());
            UpdateTextBox(lbA2010, "2010: ", cura.ToString());
            UpdateTextBox(lbP2010, "2010: ", curp.ToString());
            UpdateTextBox(lbPM2010, "2010: ", curplus.ToString());
            UpdateTextBox(lbPPG2010, "2010: ", curppg.ToString());
            UpdateTextBox(lbPPA2010, "2010: ", (curppp - curppg).ToString());
            UpdateTextBox(lbPPP2010, "2010: ", curppp.ToString());
            UpdateTextBox(lbSHG2010, "2010: ", curshg.ToString());
            UpdateTextBox(lbSHP2010, "2010: ", (curshp - curshg).ToString());
            UpdateTextBox(lbGW2010, "2010: ", curgw.ToString());
            UpdateTextBox(lbOT2010, "2010: ", curot.ToString());
            int total = curg + cura + curp + curplus + curppg + curppp + (curppp - curppg) + curshg + (curshp - curshg) + curgw;
            UpdateTextBox(lbTOTAL2010, "2010: ", total.ToString());
            index = 0;
        }

        private void Update2009(string pName)
        {

            MySqlDataReader rdr = null;
            string qry = "select games, goals, assists, points, plusminus, ppg, ppp, shg, shp, gw, ot from stat2009 " +
                "where player = '" + pName + "';";
            rdr = MysqlInterface.DoQuery(qry);
            int index = 0;
            while (rdr.Read())
            {
                curgp = Convert.ToInt32(rdr.GetDouble(index++));
                curg = Convert.ToInt32(rdr.GetDouble(index++));
                cura = Convert.ToInt32(rdr.GetDouble(index++));
                curp = Convert.ToInt32(rdr.GetDouble(index++));
                curplus = Convert.ToInt32(rdr.GetDouble(index++));
                curppg = Convert.ToInt32(rdr.GetDouble(index++));
                curppp = Convert.ToInt32(rdr.GetDouble(index++));
                curshg = Convert.ToInt32(rdr.GetDouble(index++));
                curshp = Convert.ToInt32(rdr.GetDouble(index++));
                curgw = Convert.ToInt32(rdr.GetDouble(index++));
                curot = Convert.ToInt32(rdr.GetDouble(index++));
                //lbGAVG.Text = "AVG: " + rdr.GetString(index++);
                index = 0;
            }
            UpdateTextBox(lbGP2009, "2009: ", curgp.ToString());
            UpdateTextBox(lbG2009, "2009: ", curg.ToString());
            UpdateTextBox(lbA2009, "2009: ", cura.ToString());
            UpdateTextBox(lbP2009, "2009: ", curp.ToString());
            UpdateTextBox(lbPM2009, "2009: ", curplus.ToString());
            UpdateTextBox(lbPPG2009, "2009: ", curppg.ToString());
            UpdateTextBox(lbPPA2009, "2009: ", (curppp - curppg).ToString());
            UpdateTextBox(lbPPP2009, "2009: ", curppp.ToString());
            UpdateTextBox(lbSHG2009, "2009: ", curshg.ToString());
            UpdateTextBox(lbSHP2009, "2009: ", (curshp - curshg).ToString());
            UpdateTextBox(lbGW2009, "2009: ", curgw.ToString());
            UpdateTextBox(lbOT2009, "2009: ", curot.ToString());
            int total = curg + cura + curp + curplus + curppg + curppp + (curppp - curppg) + curshg + (curshp - curshg) + curgw;
            UpdateTextBox(lbTOTAL2009, "2009: ", total.ToString());
        }

        public void UpdatePlayerInfo(string pName)
        {

            MySqlDataReader rdr = null;
            rdr = MysqlInterface.DoQuery("SELECT position, dob, team, country, height, weight, shoot" +
            " FROM player where name = '" + pName + "';");
            int index = 0;
            lbName.Text = "PLAYER: " + pName;
            while (rdr.Read())
            {
                lbPos.Text = "POSITION: " + rdr.GetString(index++);
                lbDOB.Text = "DOB: " + rdr.GetString(index++);
                lbTeam.Text = "TEAM: " + rdr.GetString(index++);
                lbCountry.Text = "COUNTRY: " + rdr.GetString(index++);
                lbHeight.Text = "HEIGHT: " + rdr.GetString(index++);
                lbWeight.Text = "WEIGHT: " + rdr.GetString(index++);
                lbShoot.Text = "SHOOTS: " + rdr.GetString(index++);
            }

            avggp = avgg = avga = avgp = avgplus = avgppg = avgppp = avgppa = avgshg = avgsha = avggw = avgot = 0;
            Update2014(pName);
            AddToAvg();
            Update2013(pName);
            AddToAvg();
            Update2012(pName);
            AddToAvg();
            Update2011(pName);
            AddToAvg();
            Update2010(pName);
            AddToAvg();
            Update2009(pName);
            AddToAvg();

            avggp = avggp / 6;
            avgg = avgg / 6;
            avga = avga / 6;
            avgp = avgp / 6;
            avgplus = avgplus / 6;
            avgppg = avgppg / 6;
            avgppp = avgppp / 6;
            avgppa = avgppa / 6;
            avgshg = avgshg / 6;
            avgsha = avgsha / 6;
            avggw = avggw / 6;
            avgot = avgot / 6;

            UpdateTextBox(lbGPAVG, "AVG: ", avggp.ToString());
            UpdateTextBox(lbGAVG, "AVG: ", avgg.ToString());
            UpdateTextBox(lbAAVG, "AVG: ", avga.ToString());
            UpdateTextBox(lbPAVG, "AVG: ", avgp.ToString());
            UpdateTextBox(lbPMAVG, "AVG: ", avgplus.ToString());
            UpdateTextBox(lbPPGAVG, "AVG: ", avgppg.ToString());
            UpdateTextBox(lbPPAAVG, "AVG: ", (avgppp - avgppg).ToString());
            UpdateTextBox(lbPPPAVG, "AVG: ", avgppp.ToString());
            UpdateTextBox(lbSHGAVG, "AVG: ", avgshg.ToString());
            UpdateTextBox(lbSHPAVG, "AVG: ", avgsha.ToString());
            UpdateTextBox(lbGWAVG, "AVG: ", avggw.ToString());
            UpdateTextBox(lbOTAVG, "AVG: ", avgot.ToString());
            int total = avgg + avga + avgp + avgplus + avgppg + avgppp + (avgppp - avgppg) + avgshg + avgsha + avggw;
            UpdateTextBox(lbTOTALAVG, "AVG: ", total.ToString());
        }

        private void dgPlayer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r < 0)
                return;
            string name = dgPlayer[0, r].Value.ToString();
            lbName.Text = "PLAYER: " + name;

            UpdatePlayerInfo(name);


        }

        private void btSigned_Click(object sender, EventArgs e)
        {
            lbSigned.Items.Add(lbName.Text.Substring(8, lbName.Text.Length - 8));
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            lbSigned.Items.RemoveAt(lbSigned.SelectedIndex);
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            string searchStr = tbSearch.Text;

            Globals.FM_LOOKUP = new fmPlayerLookup(searchStr);
            Globals.FM_LOOKUP.ShowDialog();
            Globals.FM_LOOKUP.BringToFront();
        }

        private void dgPlayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            int index;
            if (e.KeyChar == (char)Keys.Enter)
            {
                for (int i = 0; i < dgPlayer.SelectedCells.Count; i++)
                {
                    index = dgPlayer.SelectedCells[i].RowIndex - 1;
                    lbSigned.Items.Add(dgPlayer[0, index].Value.ToString());
                }
            }

        }

        private void dgPlayer_KeyDown(object sender, KeyEventArgs e)
        {
            int index;
            if (e.KeyData == Keys.Down)
            {
                for (int i = 0; i < dgPlayer.SelectedCells.Count; i++)
                {
                    index = dgPlayer.SelectedCells[i].RowIndex+1;
                    UpdatePlayerInfo(dgPlayer[0, index].Value.ToString());
                }
            } 
            if (e.KeyData == Keys.Up)
            {
                for (int i = 0; i < dgPlayer.SelectedCells.Count; i++)
                {
                    index = dgPlayer.SelectedCells[i].RowIndex - 1;
                    if (index < 0)
                        return;
                    UpdatePlayerInfo(dgPlayer[0, index].Value.ToString());
                }
            }
        }
    }
}
