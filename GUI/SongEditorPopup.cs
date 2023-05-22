using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework.GUI
{
    public partial class SongEditorPopup : Form
    {
        public SongEditorPopup()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "Songs (*.mp3)|*.mp3";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                audioPath.Text = ofd.FileName;
            }
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            if (audioPath.Text != "...")
                SongEditor.audioPath = audioPath.Text;
            if (!string.IsNullOrWhiteSpace(titleBox.Text))
                SongEditor.editingChart.title = titleBox.Text;
            if (!string.IsNullOrWhiteSpace(descriptionBox.Text))
                SongEditor.editingChart.description = descriptionBox.Text;
            Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SongEditorPopup_Load(object sender, EventArgs e)
        {

        }
    }
}
