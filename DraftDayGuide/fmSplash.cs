using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DraftDayGuide
{
    public partial class fmSplash : Form
    {
        public fmSplash()
        {
            InitializeComponent();
        }

        public void ChangeText(string text)
        {
            lbLoading.Text = text;
            Refresh();
        }
    }
}
