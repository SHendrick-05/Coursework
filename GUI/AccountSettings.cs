using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coursework.GUI
{
    /// <summary>
    /// The form where users can change settings about their account, or delete it.
    /// </summary>
    public partial class AccountSettings : Form
    {
        /// <summary>
        /// A function for draggable forms, which simply makes a call to the main function.
        /// </summary>
        private void Drag(object sender, MouseEventArgs e)
        {
            // Ensure the button press was the left mouse button
            if (e.Button == MouseButtons.Left)
            {
                MouseDrag.DragForm(Handle);
            }
        }

        /// <summary>
        /// The variable for debounce in updating passwords. Ensures it cannot be pressed twice in quick succession.
        /// </summary>
        internal static bool debounce = false;

        /// <summary>
        /// The base constructor function for the form.
        /// </summary>
        public AccountSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the form, and makes the Main form visible again.
        /// </summary>
        private void closeButton_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["Main"] as Main).Show();
            Close();
        }

        /// <summary>
        /// This function gets the username of the user that is currently logged in, and displays it on the screen.
        /// </summary>
        private void AccountSettings_Load(object sender, EventArgs e)
        {
            userLabel.Text = $"Logged in as: {Users.loggedInUser.username}";
        }

        /// <summary>
        /// The button click event for triggering the option for account deletion. Displays a confirmation button.
        /// </summary>
        private void deleteAccount_Click(object sender, EventArgs e)
        {
            deleteN.Visible = true;
            deleteWarning.Visible = true;
            deleteY.Visible = true;
        }
        
        /// <summary>
        /// The "no" option for account deletion. Cancels the account deletion process.
        /// </summary>
        private void deleteN_Click(object sender, EventArgs e)
        {
            deleteY.Visible = false;
            deleteN.Visible = false;
            deleteWarning.Visible = false;
        }

        /// <summary>
        /// The "yes" option for account deletion. This function will delete the currently logged in account when called.
        /// </summary>
        private void deleteY_Click(object sender, EventArgs e)
        {
            User toDelete = Users.loggedInUser;
            Users.loggedInUser = null;
            Users.deleteAccount(toDelete);
            Close();
        }

        /// <summary>
        /// The button click event for updating a user's password. This takes the input from two TextBoxes, and attempts to update the database with these values.
        /// </summary>
        /// <exception cref="Exception">The update function returned an error code that was not expected.</exception>
        private void updatePassword_Click(object sender, EventArgs e)
        {
            // Debounce variable to ensure that this function is not called while it is already running.
            if (debounce) return;
            debounce = true;

            // Get the username and intended update password.
            string username = Users.loggedInUser.username;
            string password = newPassBox.Text;

            // If the user did not confirm the new password properly, do not update the account, as they may have made a typo.
            if (password != newPassConfirmBox.Text)
            {
                newPassError.Visible = true;
                newPassError.Text = "Passwords do not match.";
                debounce = false;
                return;
            }

            // Call the function to update the password, and store the result code.
            int result = Security.Verification.attemptUpdate(username, password);

            // Display the result of the attempt to the user.
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

            // Allow this function to be called again.
            debounce = false;
        }

        /// <summary>
        /// Updates the user's scroll speed to the one currently in the number box.
        /// </summary>
        private void updateScrollSpeedButton_Click(object sender, EventArgs e)
        {
            // Gets the new scroll speed.
            int newSpeed = (int)Math.Round(scrollSpeedBox.Value);

            // Attempts to update the user account and gets the result.
            int result = Security.Verification.attemptUpdate(Users.loggedInUser.username, newSpeed);

            // Displays the results to the user.
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
