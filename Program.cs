using Coursework.GUI;
using System.Windows.Forms;
using System.IO;
using System;



namespace Coursework 
{ 
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialise the Storage folder, as multiple files will depend on this
            if (!Directory.Exists("Storage"))
            {
                Directory.CreateDirectory("Storage");
            }
            if (!Directory.Exists("Songs"))
            {
                Directory.CreateDirectory("Songs");
            }
            // Run the game.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }

}
