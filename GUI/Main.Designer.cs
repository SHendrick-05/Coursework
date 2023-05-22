namespace Coursework.GUI
{
    partial class Main
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
            this.registerButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleText = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.currentUserLabel = new System.Windows.Forms.Label();
            this.signOutButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.songEditorButton = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // registerButton
            // 
            this.registerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerButton.ForeColor = System.Drawing.SystemColors.Control;
            this.registerButton.Location = new System.Drawing.Point(435, 75);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(176, 30);
            this.registerButton.TabIndex = 0;
            this.registerButton.Text = "Login or Create an account";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // playButton
            // 
            this.playButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.ForeColor = System.Drawing.SystemColors.Control;
            this.playButton.Location = new System.Drawing.Point(258, 137);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(105, 42);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "Play!";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.topPanel.Controls.Add(this.titleText);
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(623, 36);
            this.topPanel.TabIndex = 2;
            // 
            // titleText
            // 
            this.titleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.titleText.Location = new System.Drawing.Point(0, 0);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(548, 36);
            this.titleText.TabIndex = 1;
            this.titleText.Text = "Game";
            this.titleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // closeButton
            // 
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.FlatAppearance.BorderSize = 2;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closeButton.Location = new System.Drawing.Point(548, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 36);
            this.closeButton.TabIndex = 0;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // currentUserLabel
            // 
            this.currentUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentUserLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.currentUserLabel.Location = new System.Drawing.Point(12, 42);
            this.currentUserLabel.Name = "currentUserLabel";
            this.currentUserLabel.Size = new System.Drawing.Size(599, 30);
            this.currentUserLabel.TabIndex = 3;
            this.currentUserLabel.Text = "Logged in as: No one!";
            this.currentUserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // signOutButton
            // 
            this.signOutButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.signOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signOutButton.ForeColor = System.Drawing.SystemColors.Control;
            this.signOutButton.Location = new System.Drawing.Point(523, 111);
            this.signOutButton.Name = "signOutButton";
            this.signOutButton.Size = new System.Drawing.Size(88, 30);
            this.signOutButton.TabIndex = 4;
            this.signOutButton.Text = "Sign out";
            this.signOutButton.UseVisualStyleBackColor = true;
            this.signOutButton.Visible = false;
            this.signOutButton.Click += new System.EventHandler(this.signOutButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.settingsButton.Location = new System.Drawing.Point(484, 75);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(127, 30);
            this.settingsButton.TabIndex = 5;
            this.settingsButton.Text = "Account Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Visible = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // songEditorButton
            // 
            this.songEditorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.songEditorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.songEditorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.songEditorButton.Location = new System.Drawing.Point(258, 185);
            this.songEditorButton.Name = "songEditorButton";
            this.songEditorButton.Size = new System.Drawing.Size(105, 42);
            this.songEditorButton.TabIndex = 6;
            this.songEditorButton.Text = "Create a song";
            this.songEditorButton.UseVisualStyleBackColor = true;
            this.songEditorButton.Click += new System.EventHandler(this.songEditorButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(623, 270);
            this.Controls.Add(this.songEditorButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.signOutButton);
            this.Controls.Add(this.currentUserLabel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.registerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Main";
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Label currentUserLabel;
        private System.Windows.Forms.Button signOutButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button songEditorButton;
    }
}