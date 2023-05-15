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
            this.closeButton = new System.Windows.Forms.Button();
            this.deleteY = new System.Windows.Forms.Button();
            this.deleteN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(334, 79);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(74, 15);
            this.userLabel.TabIndex = 0;
            this.userLabel.Text = "Logged in as";
            // 
            // deleteAccount
            // 
            this.deleteAccount.Location = new System.Drawing.Point(375, 215);
            this.deleteAccount.Name = "deleteAccount";
            this.deleteAccount.Size = new System.Drawing.Size(140, 23);
            this.deleteAccount.TabIndex = 1;
            this.deleteAccount.Text = "Delete account";
            this.deleteAccount.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(163, 176);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(140, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // deleteY
            // 
            this.deleteY.Location = new System.Drawing.Point(348, 271);
            this.deleteY.Name = "deleteY";
            this.deleteY.Size = new System.Drawing.Size(75, 23);
            this.deleteY.TabIndex = 3;
            this.deleteY.Text = "button1";
            this.deleteY.UseVisualStyleBackColor = true;
            this.deleteY.Click += new System.EventHandler(this.deleteY_Click);
            // 
            // deleteN
            // 
            this.deleteN.Location = new System.Drawing.Point(440, 271);
            this.deleteN.Name = "deleteN";
            this.deleteN.Size = new System.Drawing.Size(75, 23);
            this.deleteN.TabIndex = 4;
            this.deleteN.Text = "button3";
            this.deleteN.UseVisualStyleBackColor = true;
            // 
            // AccountSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteN);
            this.Controls.Add(this.deleteY);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.deleteAccount);
            this.Controls.Add(this.userLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccountSettings";
            this.Text = "AccountSettings";
            this.Load += new System.EventHandler(this.AccountSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button deleteAccount;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button deleteY;
        private System.Windows.Forms.Button deleteN;
    }
}