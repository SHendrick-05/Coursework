using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coursework.GUI
{
    public partial class AccountSettings : Form
    {
        private void Drag(object sender, MouseEventArgs e)
        {
            // Ensure the button press was the left mouse button
            if (e.Button == MouseButtons.Left)
            {
                MouseDrag.DragForm(Handle);
            }
        }

        internal static bool debounce = false;
        public AccountSettings()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["Main"] as Main).Show();
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
            (Application.OpenForms["Main"] as Main).Show();
            Close();
        }

        private void updateScrollSpeedButton_Click(object sender, EventArgs e)
        {
            int newSpeed = (int)Math.Round(scrollSpeedBox.Value);
            int result = Security.Verification.attemptUpdate(Users.loggedInUser.username, newSpeed);
            ssErrorLabel.Visible = true;
            if (result == 0)
            {
                ssErrorLabel.ForeColor = Color.FromArgb(44, 192, 51);
                ssErrorLabel.Text = "Scroll speed updated!";
            }
            else
            {
                ssErrorLabel.ForeColor = Color.FromArgb(192, 44, 51);
                ssErrorLabel.Text = "Error updating scroll speed.";
            }
        }
    }
}
