using Microsoft.Xna.Framework.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework.GUI
{
    public partial class SongEditor : Form
    {
        internal static string audioPath;
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(editingChart.title))
            {
                string path = @$"Songs\{editingChart.title}";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    File.Copy(audioPath, path + @"\audio.mp3");
                    string chart = JsonConvert.SerializeObject(editingChart);
                    File.WriteAllText(path + @"\chart.json", chart);
                }
            }
        }
    }
}
