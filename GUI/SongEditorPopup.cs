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

        private void SongEditorPopup_Load(object sender, EventArgs e)
        {

        }

        private void browseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = SongEditor.getDownloadsFolder();
            ofd.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagePath.Text = ofd.FileName;
            }
        }

        
    }
}
