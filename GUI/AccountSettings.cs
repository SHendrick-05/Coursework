using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework.GUI
{
    public partial class AccountSettings : Form
    {
        // DLL Imports and consts for lower-level functions
        internal const int WM_NCLBUTTONDOWN = 0xA1;
        internal const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        internal static extern bool ReleaseCapture();

        internal static bool debounce = false;
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
        public AccountSettings()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void AccountSettings_Load(object sender, EventArgs e)
        {
            userLabel.Text = $"Logged in as: {Users.loggedInUser.username}";
        }

        // Functions handling account deletion
        private void deleteAccount_Click(object sender, EventArgs e)
        {
            deleteN.Visible = true;
            deleteWarning.Visible = true;
            deleteY.Visible = true;
        }
        private void deleteN_Click(object sender, EventArgs e)
        {
            deleteY.Visible = false;
            deleteN.Visible = false;
            deleteWarning.Visible = false;
        }
        private void deleteY_Click(object sender, EventArgs e)
        {
            User toDelete = Users.loggedInUser;
            Users.loggedInUser = null;
            Users.deleteAccount(toDelete);
            Close();
        }

        private void updatePassword_Click(object sender, EventArgs e)
        {
            if (debounce) return;
            debounce = true;
            string username = Users.loggedInUser.username;
            string password = newPassBox.Text;
            if (password != newPassConfirmBox.Text)
            {
                newPassError.Visible = true;
                newPassError.Text = "Passwords do not match.";
                debounce = false;
                return;
            }
            int result = Security.Verification.attemptUpdate(username, password);

            newPassError.Visible = true;
            newPassError.ForeColor = Color.FromArgb(192, 44, 51);
            switch(result)
            {
                case 0:
                    newPassError.ForeColor = Color.FromArgb(44, 192, 51);
                    newPassError.Text = "Password updated!";
                    break;
                case 1:
                    newPassError.Text = "One or more fields are empty.";
                    break;
                default:
                    throw new Exception();
            }
            debounce = false;
        }

        private void closeButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
