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
        private void Drag(object sender, MouseEventArgs e)
        {
            // Ensure the button press was the left mouse button
            if (e.Button == MouseButtons.Left)
            {
                MouseDrag.DragForm(Handle);
            }
        }
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
            using (var game = new Gameplay.SongPlayer())
            {
                game.Run();
            }
        }

        private void SongSelect_Load(object sender, EventArgs e)
        {
            Panel panll = SongLoading.loadChart(new Chart(), 0);
            panll.Location = new Point(100, 100);
            Controls.Add(panll);
        }


    }

    internal static class SongLoading
    {
        internal static Panel loadChart(Chart chart, int i)
        {
            return getTemplate(i);
        }

        internal static Panel getTemplate(int i)
        {
            Panel chartPanel = new Panel();
            PictureBox chartPicture = new PictureBox();
            Label chartTitle = new Label();
            Label chartBPM = new Label();
            Label authorLabel = new Label();

            // 
            // specimenChart
            // 
            chartPanel.BorderStyle = BorderStyle.FixedSingle;
            chartPanel.Controls.Add(authorLabel);
            chartPanel.Controls.Add(chartBPM);
            chartPanel.Controls.Add(chartPicture);
            chartPanel.Controls.Add(chartTitle);
            chartPanel.Name = "chart" + i.ToString();
            chartPanel.Size = new Size(509, 100);
            chartPanel.TabIndex = 20;

            // 
            // chartTitle
            // 
            chartTitle.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            chartTitle.ForeColor = SystemColors.Control;
            chartTitle.Location = new Point(176, 3);
            chartTitle.Name = "songTitle" + i.ToString();
            chartTitle.Size = new Size(330, 30);
            chartTitle.TabIndex = 17;
            chartTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // songAuthor
            // 
            authorLabel.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            authorLabel.ForeColor = SystemColors.Control;
            authorLabel.Location = new Point(176, 58);
            authorLabel.Name = "songAuthor" + i.ToString();
            authorLabel.Size = new Size(156, 25);
            authorLabel.TabIndex = 19;
            authorLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // songPicture
            // 
            chartPicture.Location = new Point(3, 3);
            chartPicture.Name = "songPicture";
            chartPicture.Size = new Size(167, 94);
            chartPicture.TabIndex = 0;
            chartPicture.TabStop = false;
            // 
            // songBPM
            // 
            chartBPM.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chartBPM.ForeColor = SystemColors.Control;
            chartBPM.Location = new Point(176, 33);
            chartBPM.Name = "songBPM";
            chartBPM.Size = new Size(156, 25);
            chartBPM.TabIndex = 18;
            chartBPM.Text = "BPM: 000";
            chartBPM.TextAlign = ContentAlignment.MiddleLeft;

            return chartPanel;
        }
    }
}
