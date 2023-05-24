using Newtonsoft.Json;
using System;
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


        public SongEditor(string path)
        {
            editingChart = new Chart();
            editingChart.BPM = 119;
            editingChart.title = "Song";
            audioPath = path;
            InitializeComponent();
        }

        private void SongEditor_Load(object sender, EventArgs e)
        {
            
        }


        private void songEditorButton_Click(object sender, EventArgs e)
        {
            var audioFile = TagLib.File.Create(audioPath);
            double length = audioFile.Properties.Duration.TotalMinutes;
            double measures = 4.0 * length * editingChart.BPM;

            Random rnd = new Random();
            for (int i = 0; i < Math.Floor(measures); i++)
            {
                songNoteType[,] measure = generateMeasure(Difficulty.HARD);
                editingChart.measures.Add(measure);
            }
        }

        /// <summary>
        /// Creates a randomly-generated measure for use in a chart.
        /// </summary>
        /// <param name="diff">The difficulty with which to generate the measure</param>
        /// <returns>A measure with the appropriate difficulty.</returns>
        private songNoteType[,] generateMeasure(Difficulty diff)
        {
            // Init a RNG for the generation.
            Random rnd = new Random();
            // Create an empty measure first.
            songNoteType[,] measure = new songNoteType[16, 4];
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    measure[i,j] = songNoteType.NONE;
                }
            }

            // Populate it depending on the difficulty
            switch(diff)
            {
                // Easy = 1/4 streams.
                case Difficulty.EASY:
                    for (int i = 0; i < 16; i++)
                    {
                        if (i % 4 == 0)
                            measure[i, rnd.Next(4)] = rnd.Next(2) == 0 ? songNoteType.HIT : songNoteType.MINE;
                    }
                    return measure;
                // 1/8 streams
                case Difficulty.MEDIUM:
                    for (int i = 0; i < 16; i++)
                    {
                        if (i % 2 == 0)
                            measure[i, rnd.Next(4)] = songNoteType.HIT;
                    }
                    return measure;
                // 1/8 JS
                case Difficulty.HARD:
                    for (int i = 0; i < 16; i++)
                    {
                        int gen = rnd.Next(4);
                        if (i % 2 == 0)
                            measure[i, gen] = songNoteType.HIT;
                        if (i % 4 == 0)
                        {
                            int gen2;
                            do
                            {
                                gen2 = rnd.Next(4);
                                measure[i, gen2] = songNoteType.HIT;
                            } while (gen2 == gen);
                        }
                    }
                    return measure;
                default:
                    throw new Exception("Invalid difficulty");
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SongEditorPopup popup = new SongEditorPopup();
            popup.ShowDialog();
        }

        /// <summary>
        /// Saves a song to the appropriate folder.
        /// </summary>
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(editingChart.title))
            {
                string path = @$"Songs\{editingChart.title}";
                // Creates the folder if it does not already exist.
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                // Save the audio and image.
                if (File.Exists(path+@"\audio.mp3"))
                {
                    File.Delete(path + @"\audio.mp3");
                }
                File.Copy(audioPath, path + @"\audio.mp3");
                //Copy image
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
