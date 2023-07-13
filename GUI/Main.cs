using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Coursework.GUI
{
    /// <summary>
    /// The main point of the GUI. Any other form being closed will lead to this instance.
    /// </summary>
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

        /// <summary>
        /// Opens the form to register or login to an account.
        /// </summary>
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

        /// <summary>
        /// Opens the form to edit the account settings, or delete an account.
        /// </summary>
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

        /// <summary>
        /// Opens the song select screen.
        /// </summary>
        private void playButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SongSelect"] as SongSelect == null)
            {
                SongSelect slct = new SongSelect();
                slct.Show();
                Hide();
            }
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Signs out of an accout.
        /// </summary>
        private void signOutButton_Click(object sender, EventArgs e)
        {
            currentUserLabel.Text = "Logged in as: No one!";
            Users.loggedInUser = null;
            signOutButton.Visible = false;
            settingsButton.Visible = false;
            songEditorButton.Visible = false;
            registerButton.Visible = true;
        }

        /// <summary>
        /// Updates the label that displays the currently logged in user.
        /// </summary>
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
                songEditorButton.Visible = true;
            }
            currentUserLabel.Text = $"Logged in as: {user}";
        }

        /// <summary>
        /// Opens the menu to edit an existing song, or create a new one.
        /// </summary>
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
