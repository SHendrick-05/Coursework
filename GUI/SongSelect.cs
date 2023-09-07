using Coursework.Gameplay;
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
        private static FlowLayoutPanel scorePanel;
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
            scorePanel = scoresPanel;
        }

        // Runs the game upon clicking the button
        private void playButton_Click(object sender, EventArgs e)
        {
            // Ensure the game isn't started with no song to play
            if (string.IsNullOrWhiteSpace(selectedFolder)) return;

            Thread gameThread = new Thread(startGame);
            gameThread.Start();
        }

        // A wrapper function to run the game on a separate thread.
        internal void startGame()
        {
            using (var game = new songPlayer(selectedFolder))
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
            (Application.OpenForms["Main"] as Main).Show();
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

            foreach(Panel pnl in SongLoading.LoadScores(selectedFolder))
            {
                scorePanel.Controls.Add(pnl);
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
            Chart chart = null;
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

            // Load the IDs

            // Get a template panel.
            Panel template = getTemplate(i, true);
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
        /// Loads all the scores for a chart.
        /// </summary>
        /// <param name="folderPath">The relative path of the folder containing the chart to load scores for.</param>
        /// <returns>A list of panels of all scores for the chart.</returns>
        internal static List<Panel> LoadScores(string folderPath)
        {
            Chart chart = new Chart();
            foreach (string file in Directory.EnumerateFiles(folderPath))
            {
                if (Path.GetExtension(file) == ".json")
                {
                    string chartText = File.ReadAllText(file);
                    chart = JsonConvert.DeserializeObject<Chart>(chartText);
                }
            }
                List<Score> scores = Scores.scoreDict[chart.ID];
            List<Panel> result = new List<Panel>();
            for(int i = 0; i < scores.Count; i++)
            {
                result.Add(LoadScore(scores[i], i));
            }
            return result;
        }

        /// <summary>
        /// Loads a specific score
        /// </summary>
        /// <param name="score">The score to load</param>
        /// <param name="i">The order of the score in the list</param>
        /// <returns>A panel representing the score.</returns>
        private static Panel LoadScore(Score score, int i)
        {
            Panel pnl = getScoreTemplate(i);
            // Get the relevant information
            pnl.Controls[0].Text = GameHandler.gradeStrings[(int)score.grade];
            pnl.Controls[0].ForeColor = GameHandler.gradeColors[(int)score.grade];
            pnl.Controls[1].Text = score.User;
            pnl.Controls[2].Text = string.Format("{0:00.00}%", 100 * GameHandler.accuracy) + $" - {score.Judgements[0]}/{score.Judgements[1]}/{score.Judgements[2]}/{score.Judgements[3]}/{score.Judgements[4]}/{score.Judgements[5]}";
            return pnl;
        }

        private static Panel getScoreTemplate(int i)
        {
            Panel scorePanel = new Panel();
            Label gradeLabel = new Label();
            Label userLabel = new Label();
            Label judgementsLabel = new Label();

            // 
            // scorePanel
            // 
            scorePanel.BorderStyle = BorderStyle.FixedSingle;
            scorePanel.Controls.Add(gradeLabel);
            scorePanel.Controls.Add(userLabel);
            scorePanel.Controls.Add(judgementsLabel);
            scorePanel.Name = "chart" + i.ToString();
            scorePanel.Size = new Size(285, 100);
            scorePanel.TabIndex = 20;
            //
            // gradeLabel
            //
            gradeLabel.Dock = DockStyle.Left;
            gradeLabel.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            gradeLabel.Location = new Point(0, 0);
            gradeLabel.Name = "label1";
            gradeLabel.Size = new Size(40, 62);
            gradeLabel.TabIndex = 0;
            gradeLabel.Text = "A";
            gradeLabel.TextAlign = ContentAlignment.MiddleLeft;
            //
            // userLabel
            //
            userLabel.Dock = DockStyle.Top;
            userLabel.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            userLabel.ForeColor = SystemColors.Control;
            userLabel.Location = new Point(40, 0);
            userLabel.Name = "label2";
            userLabel.Size = new Size(245, 25);
            userLabel.TabIndex = 1;
            userLabel.Text = "SpinShootscore";
            userLabel.TextAlign = ContentAlignment.MiddleLeft;
            //
            // judgementsLabel
            //
            judgementsLabel.Dock = DockStyle.Bottom;
            judgementsLabel.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            judgementsLabel.ForeColor = SystemColors.Control;
            judgementsLabel.Location = new Point(40, 37);
            judgementsLabel.Name = "label3";
            judgementsLabel.Size = new Size(245, 25);
            judgementsLabel.TabIndex = 2;
            judgementsLabel.Text = "95%";
            judgementsLabel.TextAlign = ContentAlignment.MiddleLeft;

            return scorePanel;

        }

        /// <summary>
        /// Gets an empty template panel to create a chart panel from
        /// </summary>
        /// <param name="i">The order of the panel to appear</param>
        /// <param name="select">Whether this template is for song selection for gameplay or editing. True = gameplay, False = editing.</param>
        /// <returns>A template panel to be filled in.</returns>
        private static Panel getTemplate(int i, bool select)
        {
            Panel chartPanel = new Panel();
            PictureBox chartPicture = new PictureBox();
            Label chartTitle = new Label();
            Label chartBPM = new Label();
            Label authorLabel = new Label();

            if (select)
            {
                chartPanel.Click += SongSelect.SelectSong;
                chartTitle.Click += SongSelect.SelectSong;
                authorLabel.Click += SongSelect.SelectSong;
                chartPicture.Click += SongSelect.SelectSong;
                chartBPM.Click += SongSelect.SelectSong;
            }
            else
            {
                chartPanel.Click += EditorOpenChart.SelectSong;
                chartTitle.Click += EditorOpenChart.SelectSong;
                authorLabel.Click += EditorOpenChart.SelectSong;
                chartPicture.Click += EditorOpenChart.SelectSong;
                chartBPM.Click += EditorOpenChart.SelectSong;
            }

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
            chartPicture.Name = "songPicture" + i.ToString();
            chartPicture.Size = new Size(167, 94);
            chartPicture.TabIndex = 0;
            chartPicture.TabStop = false;
            chartPicture.SizeMode = PictureBoxSizeMode.Zoom;
            
            // 
            // songBPM
            // 
            chartBPM.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chartBPM.ForeColor = SystemColors.Control;
            chartBPM.Location = new Point(176, 33);
            chartBPM.Name = "songBPM" + i.ToString();
            chartBPM.Size = new Size(156, 25);
            chartBPM.TabIndex = 18;
            chartBPM.TextAlign = ContentAlignment.MiddleLeft;
            

            return chartPanel;
        }
    }
}
