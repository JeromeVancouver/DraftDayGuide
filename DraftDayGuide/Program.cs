using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DraftDayGuide
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Globals.FM_MAIN = new fmMain();
            Application.Run(Globals.FM_MAIN);
        }
    }
}
