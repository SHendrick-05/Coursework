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
    public partial class EditorOpenChart : Form
    {
        private static string selectedFolder;
        private static Label selectLabel;

        public EditorOpenChart()
        {
            InitializeComponent();
            selectLabel = selectedLabel;
        }

        private void EditorOpenChart_Load(object sender, EventArgs e)
        {
            foreach (Panel panel in SongLoading.loadCharts())
            {
                chartLayout.Controls.Add(panel);
            }
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openButton_Click(object sender, EventArgs e)
        {

        }
    }
}
