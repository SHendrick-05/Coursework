using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Coursework.Security;

namespace Coursework.GUI
{
    internal partial class Login : Form
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

        internal Login()
        {
            InitializeComponent();
        }

        // Closes the form when the button is clicked.
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        // If the login panel isn't already visible, display it.
        private void logDisplayButton_Click(object sender, EventArgs e)
        {
            if (logPanel.Visible == false)
            {
                logPanel.Visible = true;
                regPanel.Visible = false;
            }
        }

        // If the register panel isn't already visible, display it.
        private void regDisplayButton_Click(object sender, EventArgs e)
        {
            if (regPanel.Visible == false)
            {
                logPanel.Visible = false;
                regPanel.Visible = true;
            }
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            string username = logUserBox.Text;
            string password = logPassBox.Text;
            int result = Verification.attemptLogin(username, password);
            logError.Visible = true;

            // Handle the attempt
            switch(result)
            {
                // Success
                case 0:
                    logError.Visible = false;
                    Users.loggedInUser = Database.getUser(username);
                    Close();
                    break;
                case 1:
                    logError.Text = "One or more fields are empty.";
                    break;
                case 2:
                    logError.Text = "No account with that username found.";
                    break;
                case 3:
                    logError.Text = "Invalid password.";
                    break;
                default:
                    throw new Exception("Invalid login code");
            }
        }

        // Register an account
        private void regButton_Click(object sender, EventArgs e)
        {
            string username = regUserBox.Text;
            string password = regPassBox.Text;

            if (password != regPassConfirmBox.Text)
            {
                regError.Visible = true;
                regError.Text = "Passwords do not match.";
            }

            int result = Verification.attemptRegister(username, password);

            regError.ForeColor = Color.FromArgb(192, 44, 51);
            regError.Visible = true;
            // Handle the attempt
            switch(result)
            {
                // Success
                case 0:
                    regError.ForeColor = Color.FromArgb(44, 192, 51);
                    regError.Text = "Register successful!";
                    break;
                case 1:
                    regError.Text = "One or more fields are empty.";
                    break;
                case 2:
                    regError.Text = "An account with that username already exists.";
                    break;
                default:
                    throw new Exception("Invalid register code");
            }
        }
    }
}
