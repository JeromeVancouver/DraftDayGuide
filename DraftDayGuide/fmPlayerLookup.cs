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
    public partial class fmPlayerLookup : Form
    {
        private string part;

        public fmPlayerLookup()
        {
            part = "";
            InitializeComponent();
        }

        public fmPlayerLookup(string p)
        {
            part = p;
            InitializeComponent();
        }

        public void ClearPartGrid()
        {
            dgPart.Rows.Clear();
            dgPart.RowCount = 1;
            dgPart.Columns.Clear();

        }

        private void fmPartLookup_Load(object sender, EventArgs e)
        {

            ClearPartGrid();

            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            string column = "Part";
            col.HeaderText = column;
            col.Width = 200;
            col.Name = "f" + column;
            dgPart.Columns.Add(col);

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            column = "Description";
            col1.HeaderText = column;
            col1.Width = 200;
            col1.Name = "f" + column;
            dgPart.Columns.Add(col1);

            int count = 0;
            string p;
            string d;
            count = Globals.PLAYER_ARRAY.GetLength(0);
            for (int i = 1; i <= count; i++)
            {
                p = Globals.PLAYER_ARRAY[i, 1];
                int result = 0;
                result = p.IndexOf(part, 0);
                if (result >= 0)
                {
                    d = Globals.PLAYER_ARRAY[i, 2];
                    string[] row = { p, d };
                    dgPart.Rows.Add(row);
                }
            }
        }



        private void dgPart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int c = 0;
            int r = e.RowIndex;
            string p = dgPart.Rows[r].Cells[c].Value.ToString();
            Globals.FM_MAIN.UpdateCellSelected(p);
            Globals.FM_MAIN.UpdatePlayerInfo(p);
            Close();
        }

        private void dgPart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'C')
            {
            }
        }



    }
}
