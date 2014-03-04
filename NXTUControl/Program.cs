using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RoboticsChallenge
{
    static class Program
    {
        public static Form1 form1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();
            Application.Run(form1);
        }
    }
}
