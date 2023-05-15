using Coursework.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework.GUI
{
    internal partial class Main : Form
    {
        internal Main()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            Login lgn = new Login();
            lgn.FormClosed += updateUserText;
            lgn.Show();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            AccountSettings acSettings = new AccountSettings();
            acSettings.FormClosed += updateUserText;
            acSettings.Show();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            SongSelect slct = new SongSelect();
            slct.Show();
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
    }
}
