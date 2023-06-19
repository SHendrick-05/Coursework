using System;
using System.Drawing;
using System.Windows.Forms;
using Coursework.Security;

namespace Coursework.GUI
{
    internal partial class Login : Form
    {
        private void Drag(object sender, MouseEventArgs e)
        {
            // Ensure the button press was the left mouse button
            if (e.Button == MouseButtons.Left)
            {
                MouseDrag.DragForm(Handle);
            }
        }

        internal Login()
        {
            InitializeComponent();
        }

        // Closes the form when the button is clicked.
        private void closeButton_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["Main"] as Main).Show();
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
                    (Application.OpenForms["Main"] as Main).Show();
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
