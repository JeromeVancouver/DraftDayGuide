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

        private void GetStats(int id)
        {
            MySqlDataReader rdr = null;
            //pName = "Nathan MacKinnon";
            int i = 0;
            curgp = avggp = gp2014 = Globals.STAT2014_ARRAY[id, i++];
            curg = avgg = g2014 = Globals.STAT2014_ARRAY[id, i++];
            cura = avga = a2014 = Globals.STAT2014_ARRAY[id, i++];
            curp = avgp = p2014 = Globals.STAT2014_ARRAY[id, i++];
            curplus = avgplus = plus2014 = Globals.STAT2014_ARRAY[id, i++];
            curppg = avgppg = ppg2014 = Globals.STAT2014_ARRAY[id, i++];
            curppp = avgppp = ppp2014 = Globals.STAT2014_ARRAY[id, i++];
            avgppa = avgppp - avgg;
            curshg = avgshg = shg2014 = Globals.STAT2014_ARRAY[id, i++];
            curshp = shp2014 = Globals.STAT2014_ARRAY[id, i++];
            avgsha = shp2014 - shg2014;
            curgw = avggw = gw2014 = Globals.STAT2014_ARRAY[id, i++];
            curot = avgot = ot2014 = Globals.STAT2014_ARRAY[id, i++];

            i = 0;
            curgp = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++] * 1.7);
            curg = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++] * 1.7);
            cura = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++] * 1.7);
            curp = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++] * 1.7);
            curplus = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++] * 1.7);
            curppg = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++] * 1.7);
            curppp = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++] * 1.7);
            curshg = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++] * 1.7);
            curshp = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++] * 1.7);
            curgw = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++] * 1.7);
            curot = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++] * 1.7);
            AddToAvg();

            i = 0;
            curgp = Globals.STAT2012_ARRAY[id, i++];
            curg = Globals.STAT2012_ARRAY[id, i++];
            cura = Globals.STAT2012_ARRAY[id, i++];
            curp = Globals.STAT2012_ARRAY[id, i++];
            curplus = Globals.STAT2012_ARRAY[id, i++];
            curppg = Globals.STAT2012_ARRAY[id, i++];
            curppp = Globals.STAT2012_ARRAY[id, i++];
            curshg = Globals.STAT2012_ARRAY[id, i++];
            curshp = Globals.STAT2012_ARRAY[id, i++];
            curgw = Globals.STAT2012_ARRAY[id, i++];
            curot = Globals.STAT2012_ARRAY[id, i++];
            AddToAvg();

            i = 0;
            curgp = Globals.STAT2011_ARRAY[id, i++];
            curg = Globals.STAT2011_ARRAY[id, i++];
            cura = Globals.STAT2011_ARRAY[id, i++];
            curp = Globals.STAT2011_ARRAY[id, i++];
            curplus = Globals.STAT2011_ARRAY[id, i++];
            curppg = Globals.STAT2011_ARRAY[id, i++];
            curppp = Globals.STAT2011_ARRAY[id, i++];
            curshg = Globals.STAT2011_ARRAY[id, i++];
            curshp = Globals.STAT2011_ARRAY[id, i++];
            curgw = Globals.STAT2011_ARRAY[id, i++];
            curot = Globals.STAT2011_ARRAY[id, i++];
            AddToAvg();

            i = 0;
            curgp = Globals.STAT2010_ARRAY[id, i++];
            curg = Globals.STAT2010_ARRAY[id, i++];
            cura = Globals.STAT2010_ARRAY[id, i++];
            curp = Globals.STAT2010_ARRAY[id, i++];
            curplus = Globals.STAT2010_ARRAY[id, i++];
            curppg = Globals.STAT2010_ARRAY[id, i++];
            curppp = Globals.STAT2010_ARRAY[id, i++];
            curshg = Globals.STAT2010_ARRAY[id, i++];
            curshp = Globals.STAT2010_ARRAY[id, i++];
            curgw = Globals.STAT2010_ARRAY[id, i++];
            curot = Globals.STAT2010_ARRAY[id, i++];
            AddToAvg();

            i = 0;
            curgp = Globals.STAT2009_ARRAY[id, i++];
            curg = Globals.STAT2009_ARRAY[id, i++];
            cura = Globals.STAT2009_ARRAY[id, i++];
            curp = Globals.STAT2009_ARRAY[id, i++];
            curplus = Globals.STAT2009_ARRAY[id, i++];
            curppg = Globals.STAT2009_ARRAY[id, i++];
            curppp = Globals.STAT2009_ARRAY[id, i++];
            curshg = Globals.STAT2009_ARRAY[id, i++];
            curshp = Globals.STAT2009_ARRAY[id, i++];
            curgw = Globals.STAT2009_ARRAY[id, i++];
            curot = Globals.STAT2009_ARRAY[id, i++];
            AddToAvg();

        }

        public void CustomKeyPress()
        {
        }

        private void fmMain_Load(object sender, EventArgs e)
        {

            Hide();
            Globals.FM_SPLASH = new fmSplash();
            Globals.FM_SPLASH.Show();
            Globals.FM_SPLASH.Refresh();
            Globals.FM_SPLASH.ChangeText("Loading: Players . . . ");
            Globals.LoadPlayers();
            Globals.FM_SPLASH.ChangeText("Loading: Contracts . . . ");
            Globals.LoadContracts();
            Globals.FM_SPLASH.ChangeText("Loading: 2014 Stats . . . ");
            Globals.LoadStats("stat2014");
            Globals.FM_SPLASH.ChangeText("Loading: 2013 Stats . . . ");
            Globals.LoadStats("stat2013");
            Globals.FM_SPLASH.ChangeText("Loading: 2012 Stats . . . ");
            Globals.LoadStats("stat2012");
            Globals.FM_SPLASH.ChangeText("Loading: 2011 Stats . . . ");
            Globals.LoadStats("stat2011");
            Globals.FM_SPLASH.ChangeText("Loading: 2010 Stats . . . ");
            Globals.LoadStats("stat2010");
            Globals.FM_SPLASH.ChangeText("Loading: 2009 Stats . . . ");
            Globals.LoadStats("stat2009");

            Globals.FM_SPLASH.Hide();


            dgWatch.SortCompare += customSortCompare;
            AddColumn("Player", 125, dgWatch, true);
            AddColumn("Age", 25, dgWatch, true);
            AddColumn("2014 Total", 50, dgWatch, false);
            AddColumn("AVG Total", 50, dgWatch, false);
            AddColumn("P", 25, dgWatch, false);
            AddColumn("2014 GP", 50, dgWatch, false);
            AddColumn("2014 G", 50, dgWatch, false);
            AddColumn("2014 A", 50, dgWatch, false);
            AddColumn("2014 P", 50, dgWatch, false);
            AddColumn("2014 +/-", 50, dgWatch, false);
            AddColumn("2014 ppg", 50, dgWatch, false);
            AddColumn("2014 ppp", 50, dgWatch, false);
            AddColumn("2014 shg", 50, dgWatch, false);
            AddColumn("2014 shp", 50, dgWatch, false);
            AddColumn("2014 gw", 50, dgWatch, false);
            AddColumn("2014 ot", 50, dgWatch, false);
            AddColumn("AVG GP", 50, dgWatch, false);
            AddColumn("AVG G", 50, dgWatch, false);
            AddColumn("AVG A", 50, dgWatch, false);
            AddColumn("AVG P", 50, dgWatch, false);
            AddColumn("AVG +/-", 50, dgWatch, false);
            AddColumn("AVG ppg", 50, dgWatch, false);
            AddColumn("AVG ppp", 50, dgWatch, false);
            AddColumn("AVG shg", 50, dgWatch, false);
            AddColumn("AVG shp", 50, dgWatch, false);
            AddColumn("AVG gw", 50, dgWatch, false);
            AddColumn("AVG ot", 50, dgWatch, false);
            Show();
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
            int id;
            count = Globals.PLAYER_ARRAY.GetLength(0);
            for (int i = 0; i < count; i++)
            {
                id = Convert.ToInt32(Globals.PLAYER_ARRAY[i, 0]);
                p = Globals.PLAYER_ARRAY[i, 1];
                if (CheckSignedList(p))
                    continue;
                d = Globals.PLAYER_ARRAY[i, 2];
                a = Globals.PLAYER_ARRAY[i, 3];
                if ((chLeft.Checked == true && d == "L") || (chRight.Checked == true && d == "R") || (chCenter.Checked == true && d == "C") || (chDefense.Checked == true && d == "D"))
                {
                    GetStats(id);
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

        private void Update2014(int pID)
        {

            /*MySqlDataReader rdr = null;
            string qry = "select games, goals, assists, points, plusminus, ppg, ppp, shg, shp, gw, ot from stat2014 " +
                "where player = '" + pName + "';";
            rdr = MysqlInterface.DoQuery(qry);*/
            int index = 0;
            curgp = Globals.STAT2014_ARRAY[pID, index++];
            curg = Globals.STAT2014_ARRAY[pID, index++];
            cura = Globals.STAT2014_ARRAY[pID, index++];
            curp = Globals.STAT2014_ARRAY[pID, index++];
            curplus = Globals.STAT2014_ARRAY[pID, index++];
            curppg = Globals.STAT2014_ARRAY[pID, index++];
            curppp = Globals.STAT2014_ARRAY[pID, index++];
            curshg = Globals.STAT2014_ARRAY[pID, index++];
            curshp = Globals.STAT2014_ARRAY[pID, index++];
            curgw = Globals.STAT2014_ARRAY[pID, index++];
            curot = Globals.STAT2014_ARRAY[pID, index++];
            
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

        private void Update2013(int pID)
        {

            int index = 0;
            curgp = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++] * 1.7);
            curg = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++] * 1.7);
            cura = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++] * 1.7);
            curp = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++] * 1.7);
            curplus = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++] * 1.7);
            curppg = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++] * 1.7);
            curppp = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++] * 1.7);
            curshg = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++] * 1.7);
            curshp = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++] * 1.7);
            curgw = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++] * 1.7);
            curot = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++] * 1.7);

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

        private void Update2012(int pID)
        {

            int index = 0;
            curgp = Globals.STAT2012_ARRAY[pID, index++];
            curg = Globals.STAT2012_ARRAY[pID, index++];
            cura = Globals.STAT2012_ARRAY[pID, index++];
            curp = Globals.STAT2012_ARRAY[pID, index++];
            curplus = Globals.STAT2012_ARRAY[pID, index++];
            curppg = Globals.STAT2012_ARRAY[pID, index++];
            curppp = Globals.STAT2012_ARRAY[pID, index++];
            curshg = Globals.STAT2012_ARRAY[pID, index++];
            curshp = Globals.STAT2012_ARRAY[pID, index++];
            curgw = Globals.STAT2012_ARRAY[pID, index++];
            curot = Globals.STAT2012_ARRAY[pID, index++];

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

        private void Update2011(int pID)
        {

            int index = 0;
            curgp = Globals.STAT2011_ARRAY[pID, index++];
            curg = Globals.STAT2011_ARRAY[pID, index++];
            cura = Globals.STAT2011_ARRAY[pID, index++];
            curp = Globals.STAT2011_ARRAY[pID, index++];
            curplus = Globals.STAT2011_ARRAY[pID, index++];
            curppg = Globals.STAT2011_ARRAY[pID, index++];
            curppp = Globals.STAT2011_ARRAY[pID, index++];
            curshg = Globals.STAT2011_ARRAY[pID, index++];
            curshp = Globals.STAT2011_ARRAY[pID, index++];
            curgw = Globals.STAT2011_ARRAY[pID, index++];
            curot = Globals.STAT2011_ARRAY[pID, index++];

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

        private void Update2010(int pID)
        {

            int index = 0;
            curgp = Globals.STAT2010_ARRAY[pID, index++];
            curg = Globals.STAT2010_ARRAY[pID, index++];
            cura = Globals.STAT2010_ARRAY[pID, index++];
            curp = Globals.STAT2010_ARRAY[pID, index++];
            curplus = Globals.STAT2010_ARRAY[pID, index++];
            curppg = Globals.STAT2010_ARRAY[pID, index++];
            curppp = Globals.STAT2010_ARRAY[pID, index++];
            curshg = Globals.STAT2010_ARRAY[pID, index++];
            curshp = Globals.STAT2010_ARRAY[pID, index++];
            curgw = Globals.STAT2010_ARRAY[pID, index++];
            curot = Globals.STAT2010_ARRAY[pID, index++];


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

        private void Update2009(int pID)
        {

            int index = 0;
            curgp = Globals.STAT2009_ARRAY[pID, index++];
            curg = Globals.STAT2009_ARRAY[pID, index++];
            cura = Globals.STAT2009_ARRAY[pID, index++];
            curp = Globals.STAT2009_ARRAY[pID, index++];
            curplus = Globals.STAT2009_ARRAY[pID, index++];
            curppg = Globals.STAT2009_ARRAY[pID, index++];
            curppp = Globals.STAT2009_ARRAY[pID, index++];
            curshg = Globals.STAT2009_ARRAY[pID, index++];
            curshp = Globals.STAT2009_ARRAY[pID, index++];
            curgw = Globals.STAT2009_ARRAY[pID, index++];
            curot = Globals.STAT2009_ARRAY[pID, index++];

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

        public void UpdateCellSelected(string pName)
        {
            string tmpPlayer;
            int r = dgPlayer.Rows.Count;
            for (int i = 0; i < r; i++)
            {
                tmpPlayer = Convert.ToString(dgPlayer[0, i].Value);
                if (tmpPlayer == pName)
                {
                    dgPlayer.FirstDisplayedScrollingRowIndex = i;
                    dgPlayer.Rows[i].Selected = true;
                }
            }
        }

        public void UpdatePlayerInfo(string pName)
        {
            int count = Globals.PLAYER_ARRAY.GetLength(0);
            int pID = 0;

            for (int i = 0; i < count; i++)
            {
                if (pName == Globals.PLAYER_ARRAY[i, 1])
                {
                    pID = Convert.ToInt32(Globals.PLAYER_ARRAY[i, 0]);
                }
            }

            int index = 1;
            lbName.Text = "PLAYER: " + Globals.PLAYER_ARRAY[pID, index++];
            lbPos.Text = "POSITION: " + Globals.PLAYER_ARRAY[pID, index++];
            lbDOB.Text = "AGE: " + Globals.PLAYER_ARRAY[pID, index++];
            lbTeam.Text = "TEAM: " + Globals.PLAYER_ARRAY[pID, index++];
            lbCountry.Text = "COUNTRY: " + Globals.PLAYER_ARRAY[pID, index++];
            lbHeight.Text = "HEIGHT: " + Globals.PLAYER_ARRAY[pID, index++];
            lbWeight.Text = "WEIGHT: " + Globals.PLAYER_ARRAY[pID, index++];
            lbShoot.Text = "SHOOTS: " + Globals.PLAYER_ARRAY[pID, index++];
            




            avggp = avgg = avga = avgp = avgplus = avgppg = avgppp = avgppa = avgshg = avgsha = avggw = avgot = 0;
            Update2014(pID);
            AddToAvg();
            Update2013(pID);
            AddToAvg();
            Update2012(pID);
            AddToAvg();
            Update2011(pID);
            AddToAvg();
            Update2010(pID);
            AddToAvg();
            Update2009(pID);
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
            for (int i = 0; i < dgPlayer.SelectedCells.Count; i++)
            {
                int index = dgPlayer.SelectedCells[i].RowIndex;
                lbSigned.Items.Add(dgPlayer[0, index].Value.ToString());
                dgPlayer.Rows.RemoveAt(index);
            }
            
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
                    dgPlayer.Rows.RemoveAt(index);
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
                    index = dgPlayer.SelectedCells[i].RowIndex + 1; 
                    if (index >= dgPlayer.Rows.Count - 1)
                        return;
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

        private void addToWatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = 0;
            int i = 0;
            for (int j = 0; j < dgPlayer.SelectedCells.Count; j++)
                index = dgPlayer.SelectedCells[j].RowIndex;

            string[] row = { dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(),  
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(),  
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(),  
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString(), 
                            dgPlayer[i++, index].Value.ToString()};
            dgWatch.Rows.Add(row);

            if (CurrentContract(dgPlayer[0, index].Value.ToString()))
            {
                int r = dgWatch.RowCount - 2;
                dgWatch[0, r].Style.BackColor = Color.LightGreen;
            }            
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = tabControl1.SelectedIndex;
            int rows = dgWatch.Rows.Count-1;
            if (index == 1)
            {
                for (int i = 0; i < rows; i++)
                    if (CheckSignedList(dgWatch[0, i].Value.ToString()))
                    {
                        dgWatch.Rows.RemoveAt(i);
                        rows--;
                    }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = 0;
            for (int j = 0; j < dgWatch.SelectedCells.Count; j++)
                index = dgWatch.SelectedCells[j].RowIndex;

            dgWatch.Rows.RemoveAt(index);
        }

        private void dgWatch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r < 0)
                return;
            string name = dgWatch[0, r].Value.ToString();
            lbName.Text = "PLAYER: " + name;

            UpdatePlayerInfo(name);

        }

        private void dgWatch_KeyDown(object sender, KeyEventArgs e)
        {
            int index;
            if (e.KeyData == Keys.Down)
            {
                for (int i = 0; i < dgWatch.SelectedCells.Count; i++)
                {
                    index = dgWatch.SelectedCells[i].RowIndex + 1;
                    if (index >= dgWatch.Rows.Count-1)
                        return;
                    UpdatePlayerInfo(dgWatch[0, index].Value.ToString());
                }
            }
            if (e.KeyData == Keys.Up)
            {
                for (int i = 0; i < dgWatch.SelectedCells.Count; i++)
                {
                    index = dgWatch.SelectedCells[i].RowIndex - 1;
                    if (index < 0)
                        return;
                    UpdatePlayerInfo(dgWatch[0, index].Value.ToString());
                }
            }
        }


    }
}
