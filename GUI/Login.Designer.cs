namespace Coursework.GUI
{
    partial class Login
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleText = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.regPanel = new System.Windows.Forms.Panel();
            this.regError = new System.Windows.Forms.Label();
            this.regButton = new System.Windows.Forms.Button();
            this.regPassConfirmLabel = new System.Windows.Forms.Label();
            this.regPassLabel = new System.Windows.Forms.Label();
            this.regUserLabel = new System.Windows.Forms.Label();
            this.regPassConfirmBox = new System.Windows.Forms.TextBox();
            this.regLabel = new System.Windows.Forms.Label();
            this.regPassBox = new System.Windows.Forms.TextBox();
            this.regUserBox = new System.Windows.Forms.TextBox();
            this.logPanel = new System.Windows.Forms.Panel();
            this.logError = new System.Windows.Forms.Label();
            this.logButton = new System.Windows.Forms.Button();
            this.logPassLabel = new System.Windows.Forms.Label();
            this.logUserLabel = new System.Windows.Forms.Label();
            this.logLabel = new System.Windows.Forms.Label();
            this.logPassBox = new System.Windows.Forms.TextBox();
            this.logUserBox = new System.Windows.Forms.TextBox();
            this.regDisplayButton = new System.Windows.Forms.Button();
            this.logDisplayButton = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            this.regPanel.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.titleText);
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(944, 55);
            this.topPanel.TabIndex = 0;
            // 
            // titleText
            // 
            this.titleText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.titleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.titleText.Location = new System.Drawing.Point(0, 0);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(861, 55);
            this.titleText.TabIndex = 1;
            this.titleText.Text = "Login or Create an Account";
            this.titleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.closeButton.Location = new System.Drawing.Point(861, 0);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(83, 55);
            this.closeButton.TabIndex = 0;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // regPanel
            // 
            this.regPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.regPanel.Controls.Add(this.regError);
            this.regPanel.Controls.Add(this.regButton);
            this.regPanel.Controls.Add(this.regPassConfirmLabel);
            this.regPanel.Controls.Add(this.regPassLabel);
            this.regPanel.Controls.Add(this.regUserLabel);
            this.regPanel.Controls.Add(this.regPassConfirmBox);
            this.regPanel.Controls.Add(this.regLabel);
            this.regPanel.Controls.Add(this.regPassBox);
            this.regPanel.Controls.Add(this.regUserBox);
            this.regPanel.Location = new System.Drawing.Point(114, 133);
            this.regPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.regPanel.Name = "regPanel";
            this.regPanel.Size = new System.Drawing.Size(628, 466);
            this.regPanel.TabIndex = 1;
            // 
            // regError
            // 
            this.regError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.regError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.regError.Location = new System.Drawing.Point(171, 333);
            this.regError.Name = "regError";
            this.regError.Size = new System.Drawing.Size(286, 37);
            this.regError.TabIndex = 8;
            this.regError.Text = "Confirm Password";
            this.regError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.regError.Visible = false;
            // 
            // regButton
            // 
            this.regButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regButton.ForeColor = System.Drawing.SystemColors.Control;
            this.regButton.Location = new System.Drawing.Point(229, 400);
            this.regButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.regButton.Name = "regButton";
            this.regButton.Size = new System.Drawing.Size(171, 49);
            this.regButton.TabIndex = 7;
            this.regButton.Text = "Create Account";
            this.regButton.UseVisualStyleBackColor = true;
            // 
            // regPassConfirmLabel
            // 
            this.regPassConfirmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.regPassConfirmLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.regPassConfirmLabel.Location = new System.Drawing.Point(0, 267);
            this.regPassConfirmLabel.Name = "regPassConfirmLabel";
            this.regPassConfirmLabel.Size = new System.Drawing.Size(165, 37);
            this.regPassConfirmLabel.TabIndex = 6;
            this.regPassConfirmLabel.Text = "Confirm Password";
            this.regPassConfirmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // regPassLabel
            // 
            this.regPassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.regPassLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.regPassLabel.Location = new System.Drawing.Point(0, 204);
            this.regPassLabel.Name = "regPassLabel";
            this.regPassLabel.Size = new System.Drawing.Size(165, 33);
            this.regPassLabel.TabIndex = 5;
            this.regPassLabel.Text = "Password";
            this.regPassLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // regUserLabel
            // 
            this.regUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.regUserLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.regUserLabel.Location = new System.Drawing.Point(0, 132);
            this.regUserLabel.Name = "regUserLabel";
            this.regUserLabel.Size = new System.Drawing.Size(165, 37);
            this.regUserLabel.TabIndex = 4;
            this.regUserLabel.Text = "Username";
            this.regUserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // regPassConfirmBox
            // 
            this.regPassConfirmBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.regPassConfirmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.regPassConfirmBox.ForeColor = System.Drawing.SystemColors.Control;
            this.regPassConfirmBox.Location = new System.Drawing.Point(171, 267);
            this.regPassConfirmBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.regPassConfirmBox.Name = "regPassConfirmBox";
            this.regPassConfirmBox.Size = new System.Drawing.Size(285, 30);
            this.regPassConfirmBox.TabIndex = 3;
            // 
            // regLabel
            // 
            this.regLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.regLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.regLabel.Location = new System.Drawing.Point(0, 36);
            this.regLabel.Name = "regLabel";
            this.regLabel.Size = new System.Drawing.Size(629, 69);
            this.regLabel.TabIndex = 2;
            this.regLabel.Text = "Create an account";
            this.regLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // regPassBox
            // 
            this.regPassBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.regPassBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.regPassBox.ForeColor = System.Drawing.SystemColors.Control;
            this.regPassBox.Location = new System.Drawing.Point(171, 200);
            this.regPassBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.regPassBox.Name = "regPassBox";
            this.regPassBox.Size = new System.Drawing.Size(285, 30);
            this.regPassBox.TabIndex = 1;
            // 
            // regUserBox
            // 
            this.regUserBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.regUserBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.regUserBox.ForeColor = System.Drawing.SystemColors.Control;
            this.regUserBox.Location = new System.Drawing.Point(171, 133);
            this.regUserBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.regUserBox.Name = "regUserBox";
            this.regUserBox.Size = new System.Drawing.Size(285, 30);
            this.regUserBox.TabIndex = 0;
            // 
            // logPanel
            // 
            this.logPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logPanel.Controls.Add(this.logError);
            this.logPanel.Controls.Add(this.logButton);
            this.logPanel.Controls.Add(this.logPassLabel);
            this.logPanel.Controls.Add(this.logUserLabel);
            this.logPanel.Controls.Add(this.logLabel);
            this.logPanel.Controls.Add(this.logPassBox);
            this.logPanel.Controls.Add(this.logUserBox);
            this.logPanel.Location = new System.Drawing.Point(114, 133);
            this.logPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(628, 466);
            this.logPanel.TabIndex = 8;
            this.logPanel.Visible = false;
            // 
            // logError
            // 
            this.logError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.logError.Location = new System.Drawing.Point(171, 267);
            this.logError.Name = "logError";
            this.logError.Size = new System.Drawing.Size(286, 37);
            this.logError.TabIndex = 9;
            this.logError.Text = "Confirm Password";
            this.logError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.logError.Visible = false;
            // 
            // logButton
            // 
            this.logButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logButton.ForeColor = System.Drawing.SystemColors.Control;
            this.logButton.Location = new System.Drawing.Point(229, 333);
            this.logButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(171, 49);
            this.logButton.TabIndex = 7;
            this.logButton.Text = "Log in";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // logPassLabel
            // 
            this.logPassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logPassLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.logPassLabel.Location = new System.Drawing.Point(0, 204);
            this.logPassLabel.Name = "logPassLabel";
            this.logPassLabel.Size = new System.Drawing.Size(165, 33);
            this.logPassLabel.TabIndex = 5;
            this.logPassLabel.Text = "Password";
            this.logPassLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // logUserLabel
            // 
            this.logUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logUserLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.logUserLabel.Location = new System.Drawing.Point(0, 132);
            this.logUserLabel.Name = "logUserLabel";
            this.logUserLabel.Size = new System.Drawing.Size(165, 37);
            this.logUserLabel.TabIndex = 4;
            this.logUserLabel.Text = "Username";
            this.logUserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // logLabel
            // 
            this.logLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.logLabel.Location = new System.Drawing.Point(0, 36);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(629, 69);
            this.logLabel.TabIndex = 2;
            this.logLabel.Text = "Login to your account";
            this.logLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logPassBox
            // 
            this.logPassBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.logPassBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logPassBox.ForeColor = System.Drawing.SystemColors.Control;
            this.logPassBox.Location = new System.Drawing.Point(171, 200);
            this.logPassBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logPassBox.Name = "logPassBox";
            this.logPassBox.Size = new System.Drawing.Size(285, 30);
            this.logPassBox.TabIndex = 1;
            // 
            // logUserBox
            // 
            this.logUserBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.logUserBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logUserBox.ForeColor = System.Drawing.SystemColors.Control;
            this.logUserBox.Location = new System.Drawing.Point(171, 133);
            this.logUserBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logUserBox.Name = "logUserBox";
            this.logUserBox.Size = new System.Drawing.Size(285, 30);
            this.logUserBox.TabIndex = 0;
            // 
            // regDisplayButton
            // 
            this.regDisplayButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.regDisplayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regDisplayButton.ForeColor = System.Drawing.SystemColors.Control;
            this.regDisplayButton.Location = new System.Drawing.Point(114, 93);
            this.regDisplayButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.regDisplayButton.Name = "regDisplayButton";
            this.regDisplayButton.Size = new System.Drawing.Size(114, 41);
            this.regDisplayButton.TabIndex = 8;
            this.regDisplayButton.Text = "Register";
            this.regDisplayButton.UseVisualStyleBackColor = true;
            this.regDisplayButton.Click += new System.EventHandler(this.regDisplayButton_Click);
            // 
            // logDisplayButton
            // 
            this.logDisplayButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.logDisplayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logDisplayButton.ForeColor = System.Drawing.SystemColors.Control;
            this.logDisplayButton.Location = new System.Drawing.Point(229, 93);
            this.logDisplayButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logDisplayButton.Name = "logDisplayButton";
            this.logDisplayButton.Size = new System.Drawing.Size(114, 41);
            this.logDisplayButton.TabIndex = 9;
            this.logDisplayButton.Text = "Login";
            this.logDisplayButton.UseVisualStyleBackColor = true;
            this.logDisplayButton.Click += new System.EventHandler(this.logDisplayButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(944, 727);
            this.Controls.Add(this.logDisplayButton);
            this.Controls.Add(this.regDisplayButton);
            this.Controls.Add(this.logPanel);
            this.Controls.Add(this.regPanel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Login";
            this.Text = "Login";
            this.topPanel.ResumeLayout(false);
            this.regPanel.ResumeLayout(false);
            this.regPanel.PerformLayout();
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Panel regPanel;
        private System.Windows.Forms.Label regLabel;
        private System.Windows.Forms.TextBox regPassBox;
        private System.Windows.Forms.TextBox regUserBox;
        private System.Windows.Forms.Label regPassConfirmLabel;
        private System.Windows.Forms.Label regPassLabel;
        private System.Windows.Forms.Label regUserLabel;
        private System.Windows.Forms.TextBox regPassConfirmBox;
        private System.Windows.Forms.Button regButton;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.Button logButton;
        private System.Windows.Forms.Label logPassLabel;
        private System.Windows.Forms.Label logUserLabel;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.TextBox logPassBox;
        private System.Windows.Forms.TextBox logUserBox;
        private System.Windows.Forms.Button regDisplayButton;
        private System.Windows.Forms.Button logDisplayButton;
        private System.Windows.Forms.Label regError;
        private System.Windows.Forms.Label logError;
    }
}