using Microsoft.Xna.Framework.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
            editingChart.BPM = 110;
            editingChart.title = "Song";
            audioPath = path;
            InitializeComponent();
        }

        private void SongEditor_Load(object sender, EventArgs e)
        {
            
        }

        private void songEditorButton_Click(object sender, EventArgs e)
        {
            int difficulty = 30;
            var audioFile = TagLib.File.Create(audioPath);
            double length = audioFile.Properties.Duration.TotalMinutes;
            double measures = 4.0 * length * editingChart.BPM;

            Random rnd = new Random();
            for (int i = 0; i < Math.Floor(measures); i++)
            {
                songNoteType[,] measure = new songNoteType[16, 4];
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 16; k++)
                    {
                        songNoteType note = rnd.Next(difficulty) == 0 ? songNoteType.HIT : songNoteType.NONE;
                        measure[k, j] = note;
                    }
                }
                editingChart.measures.Add(measure);
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
                File.Copy(audioPath, path + @"\audio.mp3");
                if (imagePath != null)
                {
                    string ext = Path.GetExtension(imagePath);
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
    }
}
