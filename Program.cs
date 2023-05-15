using Coursework.GUI;
using System.Windows.Forms;
using System.IO;

// Initialise the Storage folder, as multiple files will depend on this

if (!Directory.Exists("Storage"))
{
    Directory.CreateDirectory("Storage");
}

Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);
Application.Run(new Main());

/*
using var game = new Coursework.Game1();
game.Run();
*/