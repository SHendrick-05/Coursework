namespace Coursework.GUI
{
    partial class AccountSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userLabel = new System.Windows.Forms.Label();
            this.deleteAccount = new System.Windows.Forms.Button();
            this.deleteY = new System.Windows.Forms.Button();
            this.deleteN = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.titleText = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.deleteWarning = new System.Windows.Forms.Label();
            this.newPassLabel = new System.Windows.Forms.Label();
            this.newPassBox = new System.Windows.Forms.TextBox();
            this.newPassConfirmLabel = new System.Windows.Forms.Label();
            this.newPassConfirmBox = new System.Windows.Forms.TextBox();
            this.updatePassword = new System.Windows.Forms.Button();
            this.newPassError = new System.Windows.Forms.Label();
            this.updatePasswordPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteAccountPanel = new System.Windows.Forms.Panel();
            this.scrollSpeedPanel = new System.Windows.Forms.Panel();
            this.scrollSpeedBox = new System.Windows.Forms.NumericUpDown();
            this.scrollSpeedLabel = new System.Windows.Forms.Label();
            this.sSpeedLabel = new System.Windows.Forms.Label();
            this.updateScrollSpeedButton = new System.Windows.Forms.Button();
            this.ssErrorLabel = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            this.updatePasswordPanel.SuspendLayout();
            this.deleteAccountPanel.SuspendLayout();
            this.scrollSpeedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrollSpeedBox)).BeginInit();
            this.SuspendLayout();
            // 
            // userLabel
            // 
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.userLabel.Location = new System.Drawing.Point(0, 39);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(800, 57);
            this.userLabel.TabIndex = 0;
            this.userLabel.Text = "Logged in as";
            this.userLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deleteAccount
            // 
            this.deleteAccount.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.deleteAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteAccount.ForeColor = System.Drawing.SystemColors.Control;
            this.deleteAccount.Location = new System.Drawing.Point(21, 3);
            this.deleteAccount.Name = "deleteAccount";
            this.deleteAccount.Size = new System.Drawing.Size(167, 39);
            this.deleteAccount.TabIndex = 1;
            this.deleteAccount.Text = "Delete account";
            this.deleteAccount.UseVisualStyleBackColor = true;
            this.deleteAccount.Click += new System.EventHandler(this.deleteAccount_Click);
            // 
            // deleteY
            // 
            this.deleteY.Location = new System.Drawing.Point(21, 100);
            this.deleteY.Name = "deleteY";
            this.deleteY.Size = new System.Drawing.Size(75, 23);
            this.deleteY.TabIndex = 3;
            this.deleteY.Text = "Yes";
            this.deleteY.UseVisualStyleBackColor = true;
            this.deleteY.Click += new System.EventHandler(this.deleteY_Click);
            // 
            // deleteN
            // 
            this.deleteN.Location = new System.Drawing.Point(113, 100);
            this.deleteN.Name = "deleteN";
            this.deleteN.Size = new System.Drawing.Size(75, 23);
            this.deleteN.TabIndex = 4;
            this.deleteN.Text = "No";
            this.deleteN.UseVisualStyleBackColor = true;
            this.deleteN.Click += new System.EventHandler(this.deleteN_Click);
            // 
            // closeButton
            // 
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.FlatAppearance.BorderSize = 2;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closeButton.Location = new System.Drawing.Point(725, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 36);
            this.closeButton.TabIndex = 0;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click_1);
            // 
            // titleText
            // 
            this.titleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.titleText.Location = new System.Drawing.Point(0, 0);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(725, 36);
            this.titleText.TabIndex = 1;
            this.titleText.Text = "Game";
            this.titleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.topPanel.Controls.Add(this.titleText);
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(800, 36);
            this.topPanel.TabIndex = 5;
            // 
            // deleteWarning
            // 
            this.deleteWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteWarning.ForeColor = System.Drawing.SystemColors.Control;
            this.deleteWarning.Location = new System.Drawing.Point(21, 45);
            this.deleteWarning.Name = "deleteWarning";
            this.deleteWarning.Size = new System.Drawing.Size(167, 52);
            this.deleteWarning.TabIndex = 6;
            this.deleteWarning.Text = "Are you sure? This cannot be undone!";
            this.deleteWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newPassLabel
            // 
            this.newPassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newPassLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.newPassLabel.Location = new System.Drawing.Point(3, 35);
            this.newPassLabel.Name = "newPassLabel";
            this.newPassLabel.Size = new System.Drawing.Size(136, 25);
            this.newPassLabel.TabIndex = 8;
            this.newPassLabel.Text = "New Password";
            this.newPassLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // newPassBox
            // 
            this.newPassBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.newPassBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newPassBox.ForeColor = System.Drawing.SystemColors.Control;
            this.newPassBox.Location = new System.Drawing.Point(142, 35);
            this.newPassBox.Name = "newPassBox";
            this.newPassBox.Size = new System.Drawing.Size(253, 26);
            this.newPassBox.TabIndex = 7;
            // 
            // newPassConfirmLabel
            // 
            this.newPassConfirmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newPassConfirmLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.newPassConfirmLabel.Location = new System.Drawing.Point(0, 68);
            this.newPassConfirmLabel.Name = "newPassConfirmLabel";
            this.newPassConfirmLabel.Size = new System.Drawing.Size(136, 25);
            this.newPassConfirmLabel.TabIndex = 10;
            this.newPassConfirmLabel.Text = "Confirm";
            this.newPassConfirmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // newPassConfirmBox
            // 
            this.newPassConfirmBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.newPassConfirmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newPassConfirmBox.ForeColor = System.Drawing.SystemColors.Control;
            this.newPassConfirmBox.Location = new System.Drawing.Point(142, 67);
            this.newPassConfirmBox.Name = "newPassConfirmBox";
            this.newPassConfirmBox.Size = new System.Drawing.Size(253, 26);
            this.newPassConfirmBox.TabIndex = 9;
            // 
            // updatePassword
            // 
            this.updatePassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.updatePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updatePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.updatePassword.ForeColor = System.Drawing.SystemColors.Control;
            this.updatePassword.Location = new System.Drawing.Point(142, 127);
            this.updatePassword.Name = "updatePassword";
            this.updatePassword.Size = new System.Drawing.Size(134, 43);
            this.updatePassword.TabIndex = 11;
            this.updatePassword.Text = "Update";
            this.updatePassword.UseVisualStyleBackColor = true;
            this.updatePassword.Click += new System.EventHandler(this.updatePassword_Click);
            // 
            // newPassError
            // 
            this.newPassError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newPassError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.newPassError.Location = new System.Drawing.Point(0, 96);
            this.newPassError.Name = "newPassError";
            this.newPassError.Size = new System.Drawing.Size(395, 28);
            this.newPassError.TabIndex = 12;
            this.newPassError.Text = "Confirm Password";
            this.newPassError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newPassError.Visible = false;
            // 
            // updatePasswordPanel
            // 
            this.updatePasswordPanel.Controls.Add(this.label1);
            this.updatePasswordPanel.Controls.Add(this.newPassBox);
            this.updatePasswordPanel.Controls.Add(this.newPassConfirmLabel);
            this.updatePasswordPanel.Controls.Add(this.newPassError);
            this.updatePasswordPanel.Controls.Add(this.newPassLabel);
            this.updatePasswordPanel.Controls.Add(this.newPassConfirmBox);
            this.updatePasswordPanel.Controls.Add(this.updatePassword);
            this.updatePasswordPanel.Location = new System.Drawing.Point(12, 133);
            this.updatePasswordPanel.Name = "updatePasswordPanel";
            this.updatePasswordPanel.Size = new System.Drawing.Size(395, 180);
            this.updatePasswordPanel.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 32);
            this.label1.TabIndex = 14;
            this.label1.Text = "Change password";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deleteAccountPanel
            // 
            this.deleteAccountPanel.Controls.Add(this.deleteAccount);
            this.deleteAccountPanel.Controls.Add(this.deleteWarning);
            this.deleteAccountPanel.Controls.Add(this.deleteY);
            this.deleteAccountPanel.Controls.Add(this.deleteN);
            this.deleteAccountPanel.Location = new System.Drawing.Point(478, 297);
            this.deleteAccountPanel.Name = "deleteAccountPanel";
            this.deleteAccountPanel.Size = new System.Drawing.Size(200, 141);
            this.deleteAccountPanel.TabIndex = 14;
            // 
            // scrollSpeedPanel
            // 
            this.scrollSpeedPanel.Controls.Add(this.ssErrorLabel);
            this.scrollSpeedPanel.Controls.Add(this.scrollSpeedBox);
            this.scrollSpeedPanel.Controls.Add(this.scrollSpeedLabel);
            this.scrollSpeedPanel.Controls.Add(this.sSpeedLabel);
            this.scrollSpeedPanel.Controls.Add(this.updateScrollSpeedButton);
            this.scrollSpeedPanel.Location = new System.Drawing.Point(413, 133);
            this.scrollSpeedPanel.Name = "scrollSpeedPanel";
            this.scrollSpeedPanel.Size = new System.Drawing.Size(312, 158);
            this.scrollSpeedPanel.TabIndex = 15;
            // 
            // scrollSpeedBox
            // 
            this.scrollSpeedBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.scrollSpeedBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scrollSpeedBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scrollSpeedBox.ForeColor = System.Drawing.SystemColors.Control;
            this.scrollSpeedBox.Location = new System.Drawing.Point(145, 35);
            this.scrollSpeedBox.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.scrollSpeedBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scrollSpeedBox.Name = "scrollSpeedBox";
            this.scrollSpeedBox.Size = new System.Drawing.Size(120, 31);
            this.scrollSpeedBox.TabIndex = 22;
            this.scrollSpeedBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // scrollSpeedLabel
            // 
            this.scrollSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scrollSpeedLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.scrollSpeedLabel.Location = new System.Drawing.Point(3, 0);
            this.scrollSpeedLabel.Name = "scrollSpeedLabel";
            this.scrollSpeedLabel.Size = new System.Drawing.Size(306, 32);
            this.scrollSpeedLabel.TabIndex = 14;
            this.scrollSpeedLabel.Text = "Update scroll speed";
            this.scrollSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sSpeedLabel
            // 
            this.sSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sSpeedLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.sSpeedLabel.Location = new System.Drawing.Point(3, 35);
            this.sSpeedLabel.Name = "sSpeedLabel";
            this.sSpeedLabel.Size = new System.Drawing.Size(136, 25);
            this.sSpeedLabel.TabIndex = 8;
            this.sSpeedLabel.Text = "Scroll speed";
            this.sSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // updateScrollSpeedButton
            // 
            this.updateScrollSpeedButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.updateScrollSpeedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateScrollSpeedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.updateScrollSpeedButton.ForeColor = System.Drawing.SystemColors.Control;
            this.updateScrollSpeedButton.Location = new System.Drawing.Point(100, 112);
            this.updateScrollSpeedButton.Name = "updateScrollSpeedButton";
            this.updateScrollSpeedButton.Size = new System.Drawing.Size(134, 43);
            this.updateScrollSpeedButton.TabIndex = 11;
            this.updateScrollSpeedButton.Text = "Update";
            this.updateScrollSpeedButton.UseVisualStyleBackColor = true;
            this.updateScrollSpeedButton.Click += new System.EventHandler(this.updateScrollSpeedButton_Click);
            // 
            // ssErrorLabel
            // 
            this.ssErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ssErrorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ssErrorLabel.Location = new System.Drawing.Point(3, 84);
            this.ssErrorLabel.Name = "ssErrorLabel";
            this.ssErrorLabel.Size = new System.Drawing.Size(306, 25);
            this.ssErrorLabel.TabIndex = 23;
            this.ssErrorLabel.Text = "Error updating scroll speed.";
            this.ssErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ssErrorLabel.Visible = false;
            // 
            // AccountSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scrollSpeedPanel);
            this.Controls.Add(this.deleteAccountPanel);
            this.Controls.Add(this.updatePasswordPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.userLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccountSettings";
            this.Text = "AccountSettings";
            this.Load += new System.EventHandler(this.AccountSettings_Load);
            this.topPanel.ResumeLayout(false);
            this.updatePasswordPanel.ResumeLayout(false);
            this.updatePasswordPanel.PerformLayout();
            this.deleteAccountPanel.ResumeLayout(false);
            this.scrollSpeedPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scrollSpeedBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button deleteAccount;
        private System.Windows.Forms.Button deleteY;
        private System.Windows.Forms.Button deleteN;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label deleteWarning;
        private System.Windows.Forms.Label newPassLabel;
        private System.Windows.Forms.TextBox newPassBox;
        private System.Windows.Forms.Label newPassConfirmLabel;
        private System.Windows.Forms.TextBox newPassConfirmBox;
        private System.Windows.Forms.Button updatePassword;
        private System.Windows.Forms.Label newPassError;
        private System.Windows.Forms.Panel updatePasswordPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel deleteAccountPanel;
        private System.Windows.Forms.Panel scrollSpeedPanel;
        private System.Windows.Forms.Label scrollSpeedLabel;
        private System.Windows.Forms.Label sSpeedLabel;
        private System.Windows.Forms.Button updateScrollSpeedButton;
        private System.Windows.Forms.NumericUpDown scrollSpeedBox;
        private System.Windows.Forms.Label ssErrorLabel;
    }
}