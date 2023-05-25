using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Coursework.GUI
{
    internal partial class SongSelect : Form
    {
        private static string selectedFolder;
        private static Label selectLabel;
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
            selectedFolder = "";
            InitializeComponent();
            selectLabel = selectedLabel;
        }

        // Runs the game upon clicking the button
        private void button1_Click(object sender, EventArgs e)
        {
            // Ensure the game isn't started with no song to play
            if (string.IsNullOrWhiteSpace(selectedFolder)) return;

            Thread gameThread = new Thread(startGame);
            gameThread.Start();
        }

        // A wrapper function to run the game on a separate thread.
        internal void startGame()
        {
            using (var game = new Gameplay.SongPlayer(selectedFolder))
            {
                game.Run();
            }
        }

        private void SongSelect_Load(object sender, EventArgs e)
        {
            foreach(Panel panel in SongLoading.loadCharts())
            {
                chartLayout.Controls.Add(panel);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        internal static void SelectSong(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl.GetType() == typeof(Panel))
            {
                selectedFolder = (string)ctrl.Tag;
                selectLabel.Text = "Selected song: " + ctrl.Controls[3].Text;
            }
            else 
            { 
                selectedFolder = (string)ctrl.Parent.Tag;
                selectLabel.Text = "Selected song: " + ctrl.Parent.Controls[3].Text;
            }

        }
    }

    internal static class SongLoading
    {
        /// <summary>
        /// Gets every chart and creates a panel for each.
        /// </summary>
        /// <returns>A list of panels of all charts</returns>
        internal static List<Panel> loadCharts()
        {
            // Get every available chart, and load it.
            int i = 0;
            List<Panel> result = new List<Panel>();
            foreach (string chart in Directory.EnumerateDirectories("Songs"))
            {
                Panel panel = loadChart(chart, i++);
                result.Add(panel);
            }
            return result;
        }
        /// <summary>
        /// Creates a panel for song selection for a chart.
        /// </summary>
        /// <param name="folderPath">A path to the folder containing the chart files</param>
        /// <param name="i">The order of the chart</param>
        /// <returns>A panel representing the chart for use in selection</returns>
        private static Panel loadChart(string folderPath, int i)
        {
            Chart chart = new Chart();
            Image image = null;
            // Get the chart and image.
            foreach(string file in Directory.EnumerateFiles(folderPath))
            {                if (Path.GetExtension(file) == ".json")
                {
                    string chartText = File.ReadAllText(file);
                    chart = JsonConvert.DeserializeObject<Chart>(chartText);
                }
                else if (Path.GetExtension(file) != ".mp3")
                        image = Image.FromFile(file);
            }

            // Get a template panel.
            Panel template = getTemplate(i);
            // Fill it in with relevant information.
            template.Tag = folderPath;
            template.Controls[0].Text = $"Charted by {chart.author}";
            template.Controls[1].Text = $"BPM: {chart.BPM}";
            (template.Controls[2] as PictureBox).Image = image;
            template.Controls[3].Text = chart.title;
            // Return the completed panel.
            return template;
        }

        /// <summary>
        /// Gets an empty template panel to create a chart panel from
        /// </summary>
        /// <param name="i">The order of the panel to appear</param>
        /// <returns>A template panel to be filled in.</returns>
        private static Panel getTemplate(int i)
        {
            Panel chartPanel = new Panel();
            PictureBox chartPicture = new PictureBox();
            Label chartTitle = new Label();
            Label chartBPM = new Label();
            Label authorLabel = new Label();

            // 
            // chartPanel
            // 
            chartPanel.BorderStyle = BorderStyle.FixedSingle;
            chartPanel.Controls.Add(authorLabel);
            chartPanel.Controls.Add(chartBPM);
            chartPanel.Controls.Add(chartPicture);
            chartPanel.Controls.Add(chartTitle);
            chartPanel.Name = "chart" + i.ToString();
            chartPanel.Size = new Size(509, 100);
            chartPanel.TabIndex = 20;
            chartPanel.Click += SongSelect.SelectSong;
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
            chartTitle.Click += SongSelect.SelectSong;
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
            authorLabel.Click += SongSelect.SelectSong;
            // 
            // songPicture
            // 
            chartPicture.Location = new Point(3, 3);
            chartPicture.Name = "songPicture";
            chartPicture.Size = new Size(167, 94);
            chartPicture.TabIndex = 0;
            chartPicture.TabStop = false;
            chartPicture.SizeMode = PictureBoxSizeMode.Zoom;
            chartPicture.Click += SongSelect.SelectSong;
            // 
            // songBPM
            // 
            chartBPM.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chartBPM.ForeColor = SystemColors.Control;
            chartBPM.Location = new Point(176, 33);
            chartBPM.Name = "songBPM";
            chartBPM.Size = new Size(156, 25);
            chartBPM.TabIndex = 18;
            chartBPM.TextAlign = ContentAlignment.MiddleLeft;
            chartBPM.Click += SongSelect.SelectSong;

            return chartPanel;
        }
    }
}
