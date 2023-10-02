using System;
using System.Windows.Forms;

namespace Coursework.GUI
{
    /// <summary>
    /// A pop-up form to adjust the settings of a form, where images and audio can be selected.
    /// </summary>
    public partial class SongEditorPopup : Form
    {
        private void Drag(object sender, MouseEventArgs e)
        {
            // Ensure the button press was the left mouse button
            if (e.Button == MouseButtons.Left)
            {
                MouseDrag.DragForm(Handle);
            }
        }

        /// <summary>
        /// The default constructor function.
        /// </summary>
        public SongEditorPopup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens a file selection menu to pick a song
        /// </summary>
        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = SongEditor.getDownloadsFolder();
            ofd.Filter = "Songs (*.mp3)|*.mp3";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                audioPath.Text = ofd.FileName;
            }
        }

        /// <summary>
        /// Sets new paths and title for the chart.
        /// </summary>
        private void OKbutton_Click(object sender, EventArgs e)
        {
            if (audioPath.Text != "...")
                SongEditor.audioPath = audioPath.Text;
            if (!string.IsNullOrWhiteSpace(titleBox.Text))
                SongEditor.editingChart.title = titleBox.Text;
            if (imagePath.Text != "...")
                SongEditor.imagePath = imagePath.Text;
            Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Gets the current paths and title of the chart.
        /// </summary>
        private void SongEditorPopup_Load(object sender, EventArgs e)
        {
            titleBox.Text = SongEditor.editingChart.title;
            if (!string.IsNullOrWhiteSpace(SongEditor.audioPath))
                audioPath.Text = SongEditor.audioPath;
            if (!string.IsNullOrWhiteSpace(SongEditor.imagePath))
                imagePath.Text = SongEditor.imagePath;
        }

        /// <summary>
        /// Opens a file editor to select an image
        /// </summary>
        private void browseImage_Click(object sender, EventArgs e)
        {
            // Prepare a dialog.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = SongEditor.getDownloadsFolder();

            // Get all the possible file extensions.
            ofd.Filter = "Images|*" + string.Join(";*", SongEditor.imageExtensions);
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;

            // If a file was successfully selected.
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagePath.Text = ofd.FileName;
            }
        }

        
    }
}
