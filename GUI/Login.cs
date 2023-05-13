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
    public partial class Login : Form
    {
        // DLL Imports and consts for lower-level functions
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

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

        public Login()
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
            logError.Text = result.ToString();
        }

        // Register an account
        private void regButton_Click(object sender, EventArgs e)
        {
            string username = regUserBox.Text;
            string password = regPassBox.Text;
            int result = Verification.attemptRegister(username, password);
        }
    }
}
