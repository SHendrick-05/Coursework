using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Coursework.GUI
{
    internal partial class Main : Form
    {
        private void Drag(object sender, MouseEventArgs e)
        {
            // Ensure the button press was the left mouse button
            if (e.Button == MouseButtons.Left)
            {
                MouseDrag.DragForm(Handle);
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
                Hide();
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AccountSettings"] as AccountSettings == null)
            { 
                AccountSettings acSettings = new AccountSettings();
                acSettings.FormClosed += updateUserText;
                acSettings.Show();
                Hide();
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SongSelect"] as SongSelect == null)
            {
                SongSelect slct = new SongSelect();
                slct.Show();
                Hide();
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
            if (Application.OpenForms["SongEditor"] as SongEditor == null)
            {
                SongEditor editor = new SongEditor();
                editor.Show();
                Hide();
            }
        }
    }

    internal static class MouseDrag
    {
        // DLL Imports and consts for lower-level functions
        internal const int WM_NCLBUTTONDOWN = 0xA1;
        internal const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        internal static extern bool ReleaseCapture();

        /// <summary>
        /// A function to drag a form
        /// </summary>
        /// <param name="handle">The handle (HWND) of the form.</param>
        internal static void DragForm(IntPtr handle)
        {
            ReleaseCapture();
            SendMessage(handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }
}
