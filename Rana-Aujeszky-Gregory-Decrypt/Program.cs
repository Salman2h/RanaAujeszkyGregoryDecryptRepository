using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Rana_Aujeszky_Gregory_Decrypt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // an L-symbol challenge ciphertext 
            // key  may depend on j, L and the length of the list on that row.

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserInput());
        }
    }
}
