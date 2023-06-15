using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Coursework.GUI
{
    public partial class SongEditor : Form
    {
        private void Drag(object sender, MouseEventArgs e)
        {
            // Ensure the button press was the left mouse button
            if (e.Button == MouseButtons.Left)
            {
                MouseDrag.DragForm(Handle);
            }
        }

        internal static string audioPath;
        internal static string imagePath;
        internal static Chart editingChart;


        public SongEditor()
        {
            InitializeComponent();
        }

        private void SongEditor_Load(object sender, EventArgs e)
        {
            
        }


        private void songEditorButton_Click(object sender, EventArgs e)
        {
            var audioFile = TagLib.File.Create(audioPath);
            double length = audioFile.Properties.Duration.TotalMinutes;
            int measures = (int)Math.Floor(0.25 * length * editingChart.BPM);
            int notes;
            int minePct = mineBar.Value;
            Difficulty diff;
            
            if (difficultyBox.Text == "Easy")
            {
                diff = Difficulty.EASY;
                notes = 8 * measures;
            }
            else if (difficultyBox.Text == "Medium")
            {
                diff = Difficulty.MEDIUM;
                notes = 16 * measures;
            }
            else
            {
                diff = Difficulty.HARD;
                notes = 24 * measures;
            }
            Random rnd = new Random();

            // Generate notes
            for (int i = 0; i < measures; i++)
            {
                Dictionary<int, songNoteType>[] measure = generateMeasure(diff);
                editingChart.measures.Add(measure);
            }

            // Generate mines
            for (int i = 0; i < Math.Floor(notes * minePct / 100f); i++)
            {
                int meas = rnd.Next(editingChart.measures.Count);
                int col = rnd.Next(4);
                int div;
                do
                {
                    div = rnd.Next(32);
                }
                while (editingChart.measures[meas][col].ContainsKey(div * 30));
                editingChart.measures[meas][col][div * 30] = songNoteType.MINE;
            }
            generationLabel.Visible = true;
        }

        /// <summary>
        /// Creates a randomly-generated measure for use in a chart.
        /// </summary>
        /// <param name="diff">The difficulty with which to generate the measure</param>
        /// <returns>A measure with the appropriate difficulty.</returns>
        private Dictionary<int, songNoteType>[] generateMeasure(Difficulty diff)
        {
            // Init a RNG for the generation.
            Random rnd = new Random();
            // Create an empty measure first.
            Dictionary<int, songNoteType>[] measure = new Dictionary<int, songNoteType>[4];
            for (int i = 0; i < 4; i++)
            {
                measure[i] = new Dictionary<int, songNoteType>();
            }

            // Populate it depending on the difficulty
            switch (diff)
            {
                // Easy = 1/2 streams.
                case Difficulty.EASY:
                    for(int i = 0; i < 8; i++)
                    {
                        int gen = rnd.Next(4);
                        measure[gen].Add(i * 120, songNoteType.HIT);
                    }
                    return measure;
                // 1/4 streams
                case Difficulty.MEDIUM:
                    for (int i = 0; i < 16; i++)
                    {
                        int gen = rnd.Next(4);
                        measure[gen].Add(i * 60, songNoteType.HIT);
                    }
                    return measure;
                // 1/8 JS
                case Difficulty.HARD:
                    
                    return measure;
                default:
                    throw new Exception("Invalid difficulty");
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SongEditorPopup popup = new SongEditorPopup();
            popup.ShowDialog();
            titleLabel.Text = "Currently editing: " + editingChart.title;
        }

        /// <summary>
        /// Saves a song to the appropriate folder.
        /// </summary>
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Ensure the title is not empty
            if (!string.IsNullOrWhiteSpace(editingChart.title))
            {
                // Get the BPM and path
                string path = @$"Songs\{editingChart.title}";
                editingChart.folderPath = path;
                editingChart.BPM = (double)bpmBox.Value;
                // Creates the folder if it does not already exist.
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                // Copy audio
                if (File.Exists(path+@"\audio.mp3"))
                {
                    File.Delete(path + @"\audio.mp3");
                }
                File.Copy(audioPath, path + @"\audio.mp3");
                // Copy image
                if (imagePath != null)
                {
                    string ext = Path.GetExtension(imagePath);
                    if (File.Exists(path + @"\image" + ext))
                    {
                        File.Delete(path + @"\image" + ext);
                    }
                    File.Copy(imagePath, path + @"\image" + ext);
                }
                // Serialize and save the chart.
                string chart = JsonConvert.SerializeObject(editingChart);
                File.WriteAllText(path + @"\chart.json", chart);
            }
        }

        private void createSong_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = getDownloadsFolder();
            ofd.Filter = "Songs (*.mp3)|*.mp3";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                editingChart = new Chart();
                editingChart.title = "Song";
                editingChart.BPM = 110;
                bpmBox.Value = 110;
                audioPath = ofd.FileName;
                titleLabel.Text = "Currently editing: " + editingChart.title;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["Main"] as Main).Show();
            Close();
        }

        /// <summary>
        /// Gets the path to the current user's downloads folder.
        /// </summary>
        /// <returns>An absolute path to the downloads folder</returns>
        internal static string getDownloadsFolder()
        {
            Guid downloadsGuid = new("374DE290-123F-4565-9164-39C4925E467B");
            return SHGetKnownFolderPath(downloadsGuid, 0);
        }
        [DllImport("shell32", CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
        private static extern string SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, nint hToken = 0);
    }
}
