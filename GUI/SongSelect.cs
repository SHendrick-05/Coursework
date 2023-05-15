using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework.GUI
{
    internal partial class SongSelect : Form
    {
        internal SongSelect()
        {
            InitializeComponent();
        }

        // Runs the game upon clicking the button
        private void button1_Click(object sender, EventArgs e)
        {
            Thread gameThread = new Thread(startGame);
            gameThread.Start();
        }

        // A wrapper function to run the game on a separate thread.
        internal void startGame()
        {
            using (var game = new SongPlayer())
            {
                game.Run();
            }
        }
    }
}
