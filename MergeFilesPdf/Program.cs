﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergeFilesPdf
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

            Application.Run(new FRPrincipal());
            //if (frOpcoes.ShowDialog() == DialogResult.OK)
                //Application.Run(new FRPrincipal(frOpcoes.txtResultListBox));
            
        }
    }
}
