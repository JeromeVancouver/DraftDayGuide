﻿using System;
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

        double goals2014, goalw2014, goall2014, goalot2014, goalsa2014, goalga2014, goalsaves2014, goalgaa2014, goalsp2014, goalso2014, goala2014;
        double goalsAVG, goalwAVG, goallAVG, goalotAVG, goalsaAVG, goalgaAVG, goalsavesAVG, goalgaaAVG, goalspAVG, goalsoAVG, goalaAVG;
        double goalsCUR, goalwCUR, goallCUR, goalotCUR, goalsaCUR, goalgaCUR, goalsavesCUR, goalgaaCUR, goalspCUR, goalsoCUR, goalaCUR;

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


        private void AddToGAvg()
        {
            goalsAVG += goalsCUR;
            goalwAVG += goalwCUR;
            goallAVG += goallCUR;
            goalotAVG += goalotCUR;
            goalsaAVG += goalsaCUR;
            goalgaAVG += goalgaCUR;
            goalsavesAVG += goalsaCUR;
            goalgaaAVG += goalgaaCUR;
            goalspAVG += goalspCUR;
            goalsoAVG += goalsoCUR;
            goalaAVG += goalaCUR;
        }

        private void GetGStats(int id)
        {
            MySqlDataReader rdr = null;
            int i = 0;
            goalsCUR = goalsAVG = goals2014 = Globals.GSTAT2014_ARRAY[id, i++];
            goalwCUR = goalwAVG = goalw2014 = Globals.GSTAT2014_ARRAY[id, i++];
            goallCUR = goallAVG = goall2014 = Globals.GSTAT2014_ARRAY[id, i++];
            goalotCUR = goalotAVG = goalot2014 = Globals.GSTAT2014_ARRAY[id, i++];
            goalsaCUR = goalsaAVG = goalsa2014 = Globals.GSTAT2014_ARRAY[id, i++];
            goalgaCUR = goalgaAVG = goalga2014 = Globals.GSTAT2014_ARRAY[id, i++];

            goalsavesCUR = goalsavesAVG = goalsaves2014 = Globals.GSTAT2014_ARRAY[id, i++];
            goalgaaCUR = goalgaaAVG = goalgaa2014 = Globals.GSTAT2014_ARRAY[id, i++];

            goalspCUR = goalspAVG = goalsp2014 = Globals.GSTAT2014_ARRAY[id, i++];
            goalsoCUR = goalsoAVG = goalso2014 = Globals.GSTAT2014_ARRAY[id, i++];
            goalaCUR = goalaAVG = goala2014 = Globals.GSTAT2014_ARRAY[id, i++];

            i = 0;
            goalsCUR = Globals.GSTAT2013_ARRAY[id, i++];
            goalwCUR = Globals.GSTAT2013_ARRAY[id, i++];
            goallCUR = Globals.GSTAT2013_ARRAY[id, i++];
            goalotCUR = Globals.GSTAT2013_ARRAY[id, i++];
            goalsaCUR = Globals.GSTAT2013_ARRAY[id, i++];
            goalgaCUR = Globals.GSTAT2013_ARRAY[id, i++];

            goalsavesCUR = Globals.GSTAT2013_ARRAY[id, i++];
            goalgaaCUR = Globals.GSTAT2013_ARRAY[id, i++];

            goalspCUR = Globals.GSTAT2013_ARRAY[id, i++];
            goalsoCUR = Globals.GSTAT2013_ARRAY[id, i++];
            goalaCUR = Globals.GSTAT2013_ARRAY[id, i++];
            AddToGAvg();

            i = 0;
            goalsCUR = Globals.GSTAT2012_ARRAY[id, i++];
            goalwCUR = Globals.GSTAT2012_ARRAY[id, i++];
            goallCUR = Globals.GSTAT2012_ARRAY[id, i++];
            goalotCUR = Globals.GSTAT2012_ARRAY[id, i++];
            goalsaCUR = Globals.GSTAT2012_ARRAY[id, i++];
            goalgaCUR = Globals.GSTAT2012_ARRAY[id, i++];

            goalsavesCUR = Globals.GSTAT2012_ARRAY[id, i++];
            goalgaaCUR = Globals.GSTAT2012_ARRAY[id, i++];

            goalspCUR = Globals.GSTAT2012_ARRAY[id, i++];
            goalsoCUR = Globals.GSTAT2012_ARRAY[id, i++];
            goalaCUR = Globals.GSTAT2012_ARRAY[id, i++];
            AddToGAvg();

            i = 0;
            goalsCUR = Globals.GSTAT2011_ARRAY[id, i++];
            goalwCUR = Globals.GSTAT2011_ARRAY[id, i++];
            goallCUR = Globals.GSTAT2011_ARRAY[id, i++];
            goalotCUR = Globals.GSTAT2011_ARRAY[id, i++];
            goalsaCUR = Globals.GSTAT2011_ARRAY[id, i++];
            goalgaCUR = Globals.GSTAT2011_ARRAY[id, i++];

            goalsavesCUR = Globals.GSTAT2011_ARRAY[id, i++];
            goalgaaCUR = Globals.GSTAT2011_ARRAY[id, i++];

            goalspCUR = Globals.GSTAT2011_ARRAY[id, i++];
            goalsoCUR = Globals.GSTAT2011_ARRAY[id, i++];
            goalaCUR = Globals.GSTAT2011_ARRAY[id, i++];
            AddToGAvg();

            i = 0;
            goalsCUR = Globals.GSTAT2010_ARRAY[id, i++];
            goalwCUR = Globals.GSTAT2010_ARRAY[id, i++];
            goallCUR = Globals.GSTAT2010_ARRAY[id, i++];
            goalotCUR = Globals.GSTAT2010_ARRAY[id, i++];
            goalsaCUR = Globals.GSTAT2010_ARRAY[id, i++];
            goalgaCUR = Globals.GSTAT2010_ARRAY[id, i++];

            goalsavesCUR = Globals.GSTAT2010_ARRAY[id, i++];
            goalgaaCUR = Globals.GSTAT2010_ARRAY[id, i++];

            goalspCUR = Globals.GSTAT2010_ARRAY[id, i++];
            goalsoCUR = Globals.GSTAT2010_ARRAY[id, i++];
            goalaCUR = Globals.GSTAT2010_ARRAY[id, i++];
            AddToGAvg();

            i = 0;
            goalsCUR = Globals.GSTAT2009_ARRAY[id, i++];
            goalwCUR = Globals.GSTAT2009_ARRAY[id, i++];
            goallCUR = Globals.GSTAT2009_ARRAY[id, i++];
            goalotCUR = Globals.GSTAT2009_ARRAY[id, i++];
            goalsaCUR = Globals.GSTAT2009_ARRAY[id, i++];
            goalgaCUR = Globals.GSTAT2009_ARRAY[id, i++];

            goalsavesCUR = Globals.GSTAT2009_ARRAY[id, i++];
            goalgaaCUR = Globals.GSTAT2009_ARRAY[id, i++];

            goalspCUR = Globals.GSTAT2009_ARRAY[id, i++];
            goalsoCUR = Globals.GSTAT2009_ARRAY[id, i++];
            goalaCUR = Globals.GSTAT2009_ARRAY[id, i++];
            AddToGAvg();

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
            curgp = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++]);
            curg = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++]);
            cura = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++]);
            curp = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++]);
            curplus = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++]);
            curppg = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++]);
            curppp = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++]);
            curshg = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++]);
            curshp = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++]);
            curgw = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++]);
            curot = Convert.ToInt32(Globals.STAT2013_ARRAY[id, i++]);
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
            Globals.FM_SPLASH.ChangeText("Loading: Goalies . . . ");
            Globals.LoadGoalies();
            Globals.LoadGoalieStats("gstat2014");
            Globals.FM_SPLASH.ChangeText("Loading: Contracts . . . ");
            Globals.LoadContracts();
            Globals.FM_SPLASH.ChangeText("Loading: Sportsnet Predictions . . . ");
            Globals.LoadSportsnet();
            Globals.FM_SPLASH.ChangeText("Loading: 2014 Stats . . . ");
            Globals.LoadStats("stat2014");

            Globals.FM_SPLASH.Hide();


            dgWatch.SortCompare += customSortCompare;
            AddColumn("Player", 100, dgWatch, true);
            AddColumn("Age", 25, dgWatch, true);
            AddColumn("2014 Total", 40, dgWatch, false);
            AddColumn("AVG Total", 40, dgWatch, false);
            AddColumn("P", 25, dgWatch, false);
            AddColumn("2014 GP", 40, dgWatch, false);
            AddColumn("2014 G", 40, dgWatch, false);
            AddColumn("2014 A", 40, dgWatch, false);
            AddColumn("2014 P", 40, dgWatch, false);
            AddColumn("2014 +/-", 40, dgWatch, false);
            AddColumn("2014 ppg", 40, dgWatch, false);
            AddColumn("2014 ppp", 40, dgWatch, false);
            AddColumn("2014 shg", 40, dgWatch, false);
            AddColumn("2014 shp", 40, dgWatch, false);
            AddColumn("2014 gw", 40, dgWatch, false);
            AddColumn("2014 ot", 40, dgWatch, false);
            AddColumn("AVG GP", 40, dgWatch, false);
            AddColumn("AVG G", 40, dgWatch, false);
            AddColumn("AVG A", 40, dgWatch, false);
            AddColumn("AVG P", 40, dgWatch, false);
            AddColumn("AVG +/-", 40, dgWatch, false);
            AddColumn("AVG ppg", 40, dgWatch, false);
            AddColumn("AVG ppp", 40, dgWatch, false);
            AddColumn("AVG shg", 40, dgWatch, false);
            AddColumn("AVG shp", 40, dgWatch, false);
            AddColumn("AVG gw", 40, dgWatch, false);
            AddColumn("AVG ot", 40, dgWatch, false);
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

        private string CurrentSportsnet(string pName)
        {
            int count = Globals.SPORTSNET_ARRAY.GetLength(0);
            for (int i = 0; i < count; i++)
            {
                if (Globals.SPORTSNET_ARRAY[i, 0] == pName)
                    return Globals.SPORTSNET_ARRAY[i, 1];
            }
            return "";
        }

        private int CurrentFakeHockey(string pName)
        {
            int count = Globals.FAKEHOCKEY_ARRAY.Length;
            for (int i = 0; i < count; i++)
            {
                if (Globals.FAKEHOCKEY_ARRAY[i] == pName)
                    return 1;
            }
            return 0;
        }

        private string CurrentInjury(string pName)
        {
            int count = Globals.INJURY_ARRAY.GetLength(0);
            for (int i = 0; i < count; i++)
            {
                if (Globals.INJURY_ARRAY[i, 0] == pName)
                    return Globals.INJURY_ARRAY[i, 1];
            }
            return "";
        }

        private string addLineBreaks(string s, int n)
        {
            char t = ' ';
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t)
                {
                    count++;
                    if (count == n)
                    {
                        StringBuilder sb = new StringBuilder(s);
                        sb[i] = '\n';
                        s = sb.ToString();
                        return addLineBreaks(s, n+10);
                    }
                }
            }
            return s;
        }

        private void UpdateGoalie()
        {

            ClearPartGrid();
            dgPlayer.SortCompare += customSortCompare;
            AddColumn("Player", 100, dgPlayer, true);
            AddColumn("Age", 25, dgPlayer, true);
            AddColumn("2014 Starts", 40, dgPlayer, false);
            AddColumn("2014 Wins", 40, dgPlayer, false);
            AddColumn("2014 Loss", 40, dgPlayer, false);
            AddColumn("2014 OTL", 40, dgPlayer, false);
            AddColumn("2014 Shots", 40, dgPlayer, false);
            AddColumn("2014 GA", 40, dgPlayer, false);
            AddColumn("2014 Saves", 40, dgPlayer, false);
            AddColumn("2014 GAA", 40, dgPlayer, false);
            AddColumn("2014 S%", 40, dgPlayer, false);
            AddColumn("2014 S/O", 40, dgPlayer, false);
            AddColumn("2014 Assists", 40, dgPlayer, false);
            AddColumn("AVG Starts", 40, dgPlayer, false);
            AddColumn("AVG Wins", 40, dgPlayer, false);
            AddColumn("AVG Loss", 40, dgPlayer, false);
            AddColumn("AVG OTL", 40, dgPlayer, false);
            AddColumn("AVG Shots", 40, dgPlayer, false);
            AddColumn("AVG GA", 40, dgPlayer, false);
            AddColumn("AVG Saves", 40, dgPlayer, false);
            AddColumn("AVG GAA", 40, dgPlayer, false);
            AddColumn("AVG S%", 40, dgPlayer, false);
            AddColumn("AVG S/O", 40, dgPlayer, false);
            AddColumn("AVG Assists", 40, dgPlayer, false);
            
            int count = 0;
            string p;
            string d;
            string a;
            int id;
            count = Globals.GOALIE_ARRAY.GetLength(0);
            for (int i = 0; i < count - 1; i++)
            {
                    id = Convert.ToInt32(Globals.PLAYER_ARRAY[i, 0]);
                    p = Globals.GOALIE_ARRAY[i, 1];
                    if (CheckSignedList(p))
                        continue;
                    d = Globals.GOALIE_ARRAY[i, 2];
                    a = Globals.GOALIE_ARRAY[i, 3];

                    GetGStats(id);

                    goalsAVG = goalsAVG / 6;
                    goalwAVG = goalwAVG / 6;
                    goallAVG = goallAVG / 6;
                    goalotAVG = goalotAVG / 6;
                    goalsaAVG = goalsaAVG / 6;
                    goalgaAVG = goalgaAVG / 6;
                    goalsavesAVG = goalsavesAVG / 6;
                    goalgaaAVG = goalgaaAVG / 6;
                    goalspAVG = goalspAVG / 6;
                    goalsoAVG = goalsoAVG / 6;
                    goalaCUR = goalaCUR / 6;


                    string[] row = { p, a, goals2014.ToString(), goalw2014.ToString(), goall2014.ToString(), goalot2014.ToString(), 
                                       goalsa2014.ToString(), goalga2014.ToString(), goalsaves2014.ToString(), goalgaa2014.ToString(), goalsp2014.ToString(), goalso2014.ToString(), goala2014.ToString(),
                                   Convert.ToString(Convert.ToInt32(goalsAVG)), Convert.ToString(Convert.ToInt32(goalwAVG)), 
                                   Convert.ToString(Convert.ToInt32(goallAVG)), Convert.ToString(Convert.ToInt32(goalotAVG)), Convert.ToString(Convert.ToInt32(goalsaAVG)), 
                                   Convert.ToString(Convert.ToInt32(goalgaAVG)), Convert.ToString(Convert.ToInt32(goalsavesAVG)), Convert.ToString(goalgaaAVG),
                                   Convert.ToString(goalspAVG), Convert.ToString(Convert.ToInt32(goalsoAVG)), Convert.ToInt32(goalaCUR).ToString()};

                    dgPlayer.Rows.Add(row);
                    int r = dgPlayer.RowCount - 2;
                    Color c = Color.White;

                    string listedInfo = "";
                    string tTip = "";
                    listedInfo = CurrentSportsnet(p);

                    if (listedInfo != "")
                    {
                        listedInfo = "Sportsnet: \n\n" + listedInfo;
                        listedInfo = addLineBreaks(listedInfo, 10);
                        Font nf = new Font("Ariel", 8, FontStyle.Bold);
                        dgPlayer[0, r].Style.Font = nf;
                        tTip += listedInfo;
                        tTip += "\n";
                    }
                    string injuryInfo = "";
                    injuryInfo = CurrentInjury(p);
                    tTip += injuryInfo;
                    dgPlayer[0, r].ToolTipText = tTip;
                    if (CurrentContract(p))
                        c = Color.GreenYellow;
                    if (injuryInfo != "")
                        c = Color.Tomato;

                    dgPlayer[0, r].Style.BackColor = c;
                

            }
            
        }

        private void UpdatePlayer()
        {
            ClearPartGrid();
            dgPlayer.SortCompare += customSortCompare;
            AddColumn("Player", 100, dgPlayer, true);
            AddColumn("Age", 25, dgPlayer, true);
            AddColumn("2014 Total", 40, dgPlayer, false);
            AddColumn("AVG Total", 40, dgPlayer, false);
            AddColumn("P", 25, dgPlayer, false);
            AddColumn("2014 GP", 40, dgPlayer, false);
            AddColumn("2014 G", 40, dgPlayer, false);
            AddColumn("2014 A", 40, dgPlayer, false);
            AddColumn("2014 P", 40, dgPlayer, false);
            AddColumn("2014 +/-", 40, dgPlayer, false);
            AddColumn("2014 ppg", 40, dgPlayer, false);
            AddColumn("2014 ppp", 40, dgPlayer, false);
            AddColumn("2014 shg", 40, dgPlayer, false);
            AddColumn("2014 shp", 40, dgPlayer, false);
            AddColumn("2014 gw", 40, dgPlayer, false);
            AddColumn("2014 ot", 40, dgPlayer, false);
            AddColumn("AVG GP", 40, dgPlayer, false);
            AddColumn("AVG G", 40, dgPlayer, false);
            AddColumn("AVG A", 40, dgPlayer, false);
            AddColumn("AVG P", 40, dgPlayer, false);
            AddColumn("AVG +/-", 40, dgPlayer, false);
            AddColumn("AVG ppg", 40, dgPlayer, false);
            AddColumn("AVG ppp", 40, dgPlayer, false);
            AddColumn("AVG shg", 40, dgPlayer, false);
            AddColumn("AVG shp", 40, dgPlayer, false);
            AddColumn("AVG gw", 40, dgPlayer, false);
            AddColumn("AVG ot", 40, dgPlayer, false);

            int count = 0;
            string p;
            string d;
            string a;
            int id;
            count = Globals.PLAYER_ARRAY.GetLength(0);
            for (int i = 0; i < count - 1; i++)
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
                    int avgtotal = (avgg + avga + avgp + avgplus + avgppg + avgppp + (avgppp - avgppg) + avgshg + avgsha + avggw) / 6;
                    int total = g2014 + a2014 + p2014 + plus2014 + ppg2014 + ppp2014 + (ppp2014 - ppg2014) + shg2014 +
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
                    int r = dgPlayer.RowCount - 2;
                    Color c = Color.White;

                    string listedInfo = "";
                    string tTip = "";
                    listedInfo = CurrentSportsnet(p);

                    if (listedInfo != "")
                    {
                        listedInfo = "Sportsnet: \n\n" + listedInfo;
                        listedInfo = addLineBreaks(listedInfo, 10);
                        Font nf = new Font("Ariel", 8, FontStyle.Bold);
                        dgPlayer[0, r].Style.Font = nf;
                        tTip += listedInfo;
                        tTip += "\n";
                    }
                    string injuryInfo = "";
                    injuryInfo = CurrentInjury(p);
                    tTip += injuryInfo;
                    dgPlayer[0, r].ToolTipText = tTip;
                    if (CurrentContract(p))
                        c = Color.GreenYellow;
                    if (injuryInfo != "")
                        c = Color.Tomato;

                    dgPlayer[0, r].Style.BackColor = c;
                }

            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (rbPlayer.Checked)
                UpdatePlayer();
            else
                UpdateGoalie();
        }

        private void UpdateTextBox(Label l, string year, string points)
        {
            l.Text = year + points;
        }

        private void Update2014(int pID)
        {

            UpdateCurStats(Globals.STAT2014_ARRAY, pID);
            
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
        }

        private void Update2013(int pID)
        {

            int index = 0;
            curgp = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++]);
            curg = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++]);
            cura = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++]);
            curp = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++]);
            curplus = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++]);
            curppg = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++]);
            curppp = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++]);
            curshg = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++]);
            curshp = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++]);
            curgw = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++]);
            curot = Convert.ToInt32(Globals.STAT2013_ARRAY[pID, index++]);

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
        }

        private void Update2012(int pID)
        {

            UpdateCurStats(Globals.STAT2012_ARRAY, pID);

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

        }

        private void Update2011(int pID)
        {

            UpdateCurStats(Globals.STAT2011_ARRAY, pID);

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

        }

        private void Update2010(int pID)
        {

            UpdateCurStats(Globals.STAT2010_ARRAY, pID);

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

        }

        private void Update2009(int pID)
        {

            UpdateCurStats(Globals.STAT2009_ARRAY, pID);

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

        private void UpdateG2009(int pID)
        {
            UpdateCurGStats(Globals.GSTAT2009_ARRAY, pID);

            UpdateTextBox(lbGP2009, "2009: ", goalsCUR.ToString());
            UpdateTextBox(lbG2009, "2009: ", goalwCUR.ToString());
            UpdateTextBox(lbA2009, "2009: ", goallCUR.ToString());
            UpdateTextBox(lbP2009, "2009: ", goalotCUR.ToString());
            UpdateTextBox(lbPM2009, "2009: ", goalsaCUR.ToString());
            UpdateTextBox(lbPPG2009, "2009: ", goalgaCUR.ToString());

            UpdateTextBox(lbPPA2009, "2009: ", goalsavesCUR.ToString());
            UpdateTextBox(lbPPP2009, "2009: ", goalgaaCUR.ToString());

            UpdateTextBox(lbSHG2009, "2009: ", goalspCUR.ToString());
            UpdateTextBox(lbSHP2009, "2009: ", goalsoCUR.ToString());
            UpdateTextBox(lbOT2009, "2009: ", goalaCUR.ToString());
            UpdateTextBox(lbGW2009, "", "");
            int total = Convert.ToInt32(goalwCUR + goalsoCUR - goalgaaCUR + goalspCUR);
            UpdateTextBox(lbTOTAL2009, "2009: ", total.ToString());
        }

        private void UpdateG2010(int pID)
        {

            UpdateCurGStats(Globals.GSTAT2010_ARRAY, pID);

            UpdateTextBox(lbGP2010, "2010: ", goalsCUR.ToString());
            UpdateTextBox(lbG2010, "2010: ", goalwCUR.ToString());
            UpdateTextBox(lbA2010, "2010: ", goallCUR.ToString());
            UpdateTextBox(lbP2010, "2010: ", goalotCUR.ToString());
            UpdateTextBox(lbPM2010, "2010: ", goalsaCUR.ToString());
            UpdateTextBox(lbPPG2010, "2010: ", goalgaCUR.ToString());

            UpdateTextBox(lbPPA2010, "2010: ", goalsavesCUR.ToString());
            UpdateTextBox(lbPPP2010, "2010: ", goalgaaCUR.ToString());

            UpdateTextBox(lbSHG2010, "2010: ", goalspCUR.ToString());
            UpdateTextBox(lbSHP2010, "2010: ", goalsoCUR.ToString());
            UpdateTextBox(lbOT2010, "2010: ", goalaCUR.ToString());
            UpdateTextBox(lbGW2010, "", "");
            int total = Convert.ToInt32(goalwCUR + goalsoCUR - goalgaaCUR + goalspCUR);
            UpdateTextBox(lbTOTAL2010, "2010: ", total.ToString());
        }

        private void UpdateG2011(int pID)
        {

            UpdateCurGStats(Globals.GSTAT2011_ARRAY, pID);

            UpdateTextBox(lbGP2011, "2011: ", goalsCUR.ToString());
            UpdateTextBox(lbG2011, "2011: ", goalwCUR.ToString());
            UpdateTextBox(lbA2011, "2011: ", goallCUR.ToString());
            UpdateTextBox(lbP2011, "2011: ", goalotCUR.ToString());
            UpdateTextBox(lbPM2011, "2011: ", goalsaCUR.ToString());
            UpdateTextBox(lbPPG2011, "2011: ", goalgaCUR.ToString());

            UpdateTextBox(lbPPA2011, "2011: ", goalsavesCUR.ToString());
            UpdateTextBox(lbPPP2011, "2011: ", goalgaaCUR.ToString());

            UpdateTextBox(lbSHG2011, "2011: ", goalspCUR.ToString());
            UpdateTextBox(lbSHP2011, "2011: ", goalsoCUR.ToString());
            UpdateTextBox(lbOT2011, "2011: ", goalaCUR.ToString());
            UpdateTextBox(lbGW2011, "", "");
            int total = Convert.ToInt32(goalwCUR + goalsoCUR - goalgaaCUR + goalspCUR);
            UpdateTextBox(lbTOTAL2011, "2011: ", total.ToString());
        }


        private void UpdateG2012(int pID)
        {


            UpdateCurGStats(Globals.GSTAT2012_ARRAY, pID);

            UpdateTextBox(lbGP2012, "2012: ", goalsCUR.ToString());
            UpdateTextBox(lbG2012, "2012: ", goalwCUR.ToString());
            UpdateTextBox(lbA2012, "2012: ", goallCUR.ToString());
            UpdateTextBox(lbP2012, "2012: ", goalotCUR.ToString());
            UpdateTextBox(lbPM2012, "2012: ", goalsaCUR.ToString());
            UpdateTextBox(lbPPG2012, "2012: ", goalgaCUR.ToString());

            UpdateTextBox(lbPPA2012, "2012: ", goalsavesCUR.ToString());
            UpdateTextBox(lbPPP2012, "2012: ", goalgaaCUR.ToString());

            UpdateTextBox(lbSHG2012, "2012: ", goalspCUR.ToString());
            UpdateTextBox(lbSHP2012, "2012: ", goalsoCUR.ToString());
            UpdateTextBox(lbOT2012, "2012: ", goalaCUR.ToString());
            UpdateTextBox(lbGW2012, "", "");
            int total = Convert.ToInt32(goalwCUR + goalsoCUR - goalgaaCUR + goalspCUR);
            UpdateTextBox(lbTOTAL2012, "2012: ", total.ToString());
        }

        private void UpdateG2013(int pID)
        {

            UpdateCurGStats(Globals.GSTAT2013_ARRAY, pID);

            UpdateTextBox(lbGP2013, "2013: ", goalsCUR.ToString());
            UpdateTextBox(lbG2013, "2013: ", goalwCUR.ToString());
            UpdateTextBox(lbA2013, "2013: ", goallCUR.ToString());
            UpdateTextBox(lbP2013, "2013: ", goalotCUR.ToString());
            UpdateTextBox(lbPM2013, "2013: ", goalsaCUR.ToString());
            UpdateTextBox(lbPPG2013, "2013: ", goalgaCUR.ToString());

            UpdateTextBox(lbPPA2013, "2013: ", goalsavesCUR.ToString());
            UpdateTextBox(lbPPP2013, "2013: ", goalgaaCUR.ToString());

            UpdateTextBox(lbSHG2013, "2013: ", goalspCUR.ToString());
            UpdateTextBox(lbSHP2013, "2013: ", goalsoCUR.ToString());
            UpdateTextBox(lbOT2013, "2013: ", goalaCUR.ToString());
            UpdateTextBox(lbGW2013, "", "");
            int total = Convert.ToInt32(goalwCUR + goalsoCUR - goalgaaCUR + goalspCUR);
            UpdateTextBox(lbTOTAL2013, "2013: ", total.ToString());
        }

        private void UpdateG2014(int pID)
        {

            UpdateCurGStats(Globals.GSTAT2014_ARRAY, pID);

            UpdateTextBox(lbGP2014, "2014: ", goalsCUR.ToString());
            UpdateTextBox(lbG2014, "2014: ", goalwCUR.ToString());
            UpdateTextBox(lbA2014, "2014: ", goallCUR.ToString());
            UpdateTextBox(lbP2014, "2014: ", goalotCUR.ToString());
            UpdateTextBox(lbPM2014, "2014: ", goalsaCUR.ToString());
            UpdateTextBox(lbPPG2014, "2014: ", goalgaCUR.ToString());

            UpdateTextBox(lbPPA2014, "2014: ", goalsavesCUR.ToString());
            UpdateTextBox(lbPPP2014, "2014: ", goalgaaCUR.ToString());

            UpdateTextBox(lbSHG2014, "2014: ", goalspCUR.ToString());
            UpdateTextBox(lbSHP2014, "2014: ", goalsoCUR.ToString());
            UpdateTextBox(lbOT2014, "2014: ", goalaCUR.ToString());
            UpdateTextBox(lbGW2014, "", "");
            int total = Convert.ToInt32(goalwCUR + goalsoCUR - goalgaaCUR + goalspCUR);
            UpdateTextBox(lbTOTAL2014, "2014: ", total.ToString());
        }

        private void UpdateCurGStats(double[,] arr, int pID)
        {

            int index = 0;
            goalsCUR = arr[pID, index++];
            goalwCUR = arr[pID, index++];
            goallCUR = arr[pID, index++];
            goalotCUR = arr[pID, index++];
            goalsaCUR = arr[pID, index++];
            goalgaCUR = arr[pID, index++];

            goalsavesCUR = arr[pID, index++];
            goalgaaCUR = arr[pID, index++];

            goalspCUR = arr[pID, index++];
            goalsoCUR = arr[pID, index++];
            goalaCUR = arr[pID, index++];
        }

        private void UpdateCurStats(int[,] arr, int pID)
        {
            int index = 0; 
            curgp = arr[pID, index++];
            curg = arr[pID, index++];
            cura = arr[pID, index++];
            curp = arr[pID, index++];
            curplus = arr[pID, index++];
            curppg = arr[pID, index++];
            curppp = arr[pID, index++];
            curshg = arr[pID, index++];
            curshp = arr[pID, index++];
            curgw = arr[pID, index++];
            curot = arr[pID, index++];
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

        public void UpdateGoalieInfo(string pName)
        {
            int count = Globals.GOALIE_ARRAY.GetLength(0);
            int pID = 0;

            for (int i = 0; i < count; i++)
            {
                if (pName == Globals.GOALIE_ARRAY[i, 1])
                {
                    pID = Convert.ToInt32(Globals.GOALIE_ARRAY[i, 0]);
                }
            }

            int index = 1;
            lbName.Text = "PLAYER: " + Globals.GOALIE_ARRAY[pID, index++];
            lbPos.Text = "POSITION: " + Globals.GOALIE_ARRAY[pID, index++];
            lbDOB.Text = "AGE: " + Globals.GOALIE_ARRAY[pID, index++];
            lbTeam.Text = "TEAM: " + Globals.GOALIE_ARRAY[pID, index++];
            lbCountry.Text = "COUNTRY: " + Globals.GOALIE_ARRAY[pID, index++];
            lbHeight.Text = "HEIGHT: " + Globals.GOALIE_ARRAY[pID, index++];
            lbWeight.Text = "WEIGHT: " + Globals.GOALIE_ARRAY[pID, index++];
            lbShoot.Text = "SHOOTS: " + Globals.GOALIE_ARRAY[pID, index++];
            goalsAVG = goalwAVG = goallAVG = goalotAVG = goalsaAVG = goalgaAVG = goalsavesAVG = goalgaaAVG = goalspAVG = goalsoAVG = goalaAVG = 0;
        

            UpdateG2014(pID);
            AddToGAvg();
            UpdateG2013(pID);
            AddToGAvg();
            UpdateG2012(pID);
            AddToGAvg();
            UpdateG2011(pID);
            AddToGAvg();
            UpdateG2010(pID);
            AddToGAvg();
            UpdateG2009(pID);
            AddToGAvg();

            goalsAVG = goalsAVG / 6;
            goalwAVG = goalwAVG / 6;
            goallAVG = goallAVG / 6;
            goalotAVG = goalotAVG / 6;
            goalsaAVG = goalsaAVG / 6;
            goalgaAVG = goalgaAVG / 6;
            goalsavesAVG = goalsavesAVG / 6;
            goalgaaAVG = goalgaaAVG / 6;
            goalspAVG = goalspAVG / 6;
            goalsoAVG = goalsoAVG / 6;
            goalaCUR = goalaCUR / 6;

            UpdateTextBox(lbGPAVG, "AVG: ", Convert.ToInt32(goalsAVG).ToString());
            UpdateTextBox(lbGAVG, "AVG: ", Convert.ToInt32(goalwAVG).ToString());
            UpdateTextBox(lbAAVG, "AVG: ", Convert.ToInt32(goallAVG).ToString());
            UpdateTextBox(lbPAVG, "AVG: ", Convert.ToInt32(goalotAVG).ToString());
            UpdateTextBox(lbPMAVG, "AVG: ", Convert.ToInt32(goalsaAVG).ToString());
            UpdateTextBox(lbPPGAVG, "AVG: ", Convert.ToInt32(goalgaAVG).ToString());
            UpdateTextBox(lbPPAAVG, "AVG: ", Convert.ToInt32(goalsavesAVG).ToString());
            UpdateTextBox(lbPPPAVG, "AVG: ", Math.Round(goalgaaAVG,2).ToString());
            UpdateTextBox(lbSHGAVG, "AVG: ", Math.Round(goalspAVG,2).ToString());
            UpdateTextBox(lbSHPAVG, "AVG: ", Convert.ToInt32(goalsoAVG).ToString());
            UpdateTextBox(lbOTAVG, "AVG: ",Convert.ToInt32( goalaCUR).ToString());
            UpdateTextBox(lbGWAVG, "", "");
            int total = Convert.ToInt32(goalwCUR + goalsoCUR - goalgaaCUR + goalspCUR);
            UpdateTextBox(lbTOTALAVG, "AVG: ", total.ToString());


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
            if (rbPlayer.Checked)
                UpdatePlayerInfo(name);
            else
                UpdateGoalieInfo(name);


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
                    if(rbPlayer.Checked)
                        UpdatePlayerInfo(dgPlayer[0, index].Value.ToString());
                    else
                        UpdateGoalieInfo(dgPlayer[0, index].Value.ToString());
                }
            } 
            if (e.KeyData == Keys.Up)
            {
                for (int i = 0; i < dgPlayer.SelectedCells.Count; i++)
                {
                    index = dgPlayer.SelectedCells[i].RowIndex - 1;
                    if (index < 0)
                        return;
                    if (rbPlayer.Checked)
                        UpdatePlayerInfo(dgPlayer[0, index].Value.ToString());
                    else
                        UpdateGoalieInfo(dgPlayer[0, index].Value.ToString());
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

            int r = dgWatch.RowCount - 2;
            string p = dgWatch[0, r].Value.ToString();


            Color c = Color.White;

            string listedInfo = "";
            string tTip = "";
            listedInfo = CurrentSportsnet(p);

            if (listedInfo != "")
            {
                listedInfo = "Sportsnet: \n\n" + listedInfo;
                listedInfo = addLineBreaks(listedInfo, 10);
                Font nf = new Font("Ariel", 8, FontStyle.Bold);
                dgWatch[0, r].Style.Font = nf;
                tTip += listedInfo;
                tTip += "\n";
            }
            string injuryInfo = "";
            injuryInfo = CurrentInjury(p);
            tTip += injuryInfo;
            dgWatch[0, r].ToolTipText = tTip;
            if (CurrentContract(p))
                c = Color.GreenYellow;
            if (injuryInfo != "")
                c = Color.Tomato;

            dgWatch[0, r].Style.BackColor = c;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.btImport_Click();
        }

        private void TogglePlayerDetails()
        {
            lbGP.Text = "GAMES PLAYED";
            lbGOALS.Text = "GOALS";
            lbASSISTS.Text = "ASSISTS";
            lbPOINTS.Text = "POINTS";
            lbPM.Text = "+/-";
            lbPPG.Text = "PPG";
            lbPPA.Text = "PPA";
            lbPPP.Text = "PPP";
            lbSHG.Text = "SHG";
            lbSHA.Text = "SHA";
            lbOT.Text = "OT";
            lbGW.Text = "GW";
            UpdateTextBox(lbGW2014, "2014:", "");
            UpdateTextBox(lbGW2013, "2013:", "");
            UpdateTextBox(lbGW2012, "2012:", "");
            UpdateTextBox(lbGW2011, "2011:", "");
            UpdateTextBox(lbGW2010, "2010:", "");
            UpdateTextBox(lbGW2009, "2009:", "");
            UpdateTextBox(lbGWAVG, "AVG:", "");

        }

        private void ToggleGoalieDetails()
        {

            lbGP.Text = "STARTS";
            lbGOALS.Text = "WINS";
            lbASSISTS.Text = "LOSSES";
            lbPOINTS.Text = "OT LOSS";
            lbPM.Text = "SHOTS";
            lbPPG.Text = "GA";
            lbPPA.Text = "SAVES";
            lbPPP.Text = "GAA";
            lbSHG.Text = "S%";
            lbSHA.Text = "S/O";
            lbOT.Text = "ASSISTS";
            lbGW.Text = "";
            UpdateTextBox(lbGW2014, "", "");
            UpdateTextBox(lbGW2013, "", "");
            UpdateTextBox(lbGW2012, "", "");
            UpdateTextBox(lbGW2011, "", "");
            UpdateTextBox(lbGW2010, "", "");
            UpdateTextBox(lbGW2009, "", "");
            UpdateTextBox(lbGWAVG, "", "");

        }

        private void rbGoalie_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGoalie.Checked)
            {
                chDefense.Enabled = false;
                chRight.Enabled = false;
                chLeft.Enabled = false;
                chCenter.Enabled = false;
                rbPlayer.Checked = false;
                ToggleGoalieDetails();
            }
        }

        private void rbPlayer_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPlayer.Checked)
            {
                chDefense.Enabled = true;
                chRight.Enabled = true;
                chLeft.Enabled = true;
                chCenter.Enabled = true;
                rbGoalie.Checked = false;
                TogglePlayerDetails();
            }
        }

    }
}
