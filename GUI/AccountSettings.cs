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
    public partial class AccountSettings : Form
    {
        public AccountSettings()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteY_Click(object sender, EventArgs e)
        {
            User toDelete = Users.loggedInUser;
            Users.loggedInUser = null;
            Users.deleteAccount(toDelete);
            Close();
        }

        private void AccountSettings_Load(object sender, EventArgs e)
        {
            userLabel.Text = $"Logged in as: {Users.loggedInUser.username}";
        }
    }
}
