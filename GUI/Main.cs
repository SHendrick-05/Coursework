using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Coursework.GUI
{
    internal partial class Main : Form
    {
        // DLL Imports and consts for lower-level functions
        internal const int WM_NCLBUTTONDOWN = 0xA1;
        internal const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        internal static extern bool ReleaseCapture();

        /// <summary>
        /// A function to allow form dragging by holding the mouse down and moving it.
        /// </summary>
        /// <param name="e">Arguments for the mouse, including mouse position and button presses</param>
        private void Drag(object sender, MouseEventArgs e)
        {
            // Ensure the button press was the left mouse button
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        internal Main()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Login"] as Login == null)
            {
                Login lgn = new Login();
                lgn.FormClosed += updateUserText;
                lgn.Show();
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AccountSettings"] as AccountSettings == null)
            { 
                AccountSettings acSettings = new AccountSettings();
                acSettings.FormClosed += updateUserText;
                acSettings.Show();
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SongSelect"] as SongSelect == null)
            {
                SongSelect slct = new SongSelect();
                slct.Show();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signOutButton_Click(object sender, EventArgs e)
        {
            currentUserLabel.Text = "Logged in as: No one!";
            Users.loggedInUser = null;
            signOutButton.Visible = false;
            settingsButton.Visible = false;
            registerButton.Visible = true;
        }

        private void updateUserText(object sender, FormClosedEventArgs e)
        {
            string user;
            if (Users.loggedInUser == null)
            {
                user = "No one!";
            }
            else
            {
                user = Users.loggedInUser.username;
                registerButton.Visible = false;
                settingsButton.Visible = true;
                signOutButton.Visible = true;
            }
            currentUserLabel.Text = $"Logged in as: {user}";
        }

        private void songEditorButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AccountSettings"] as AccountSettings != null) return;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "Songs (*.mp3)|*.mp3";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SongEditor editor = new SongEditor(ofd.FileName);
                editor.Show();
            }
        }
    }
}
