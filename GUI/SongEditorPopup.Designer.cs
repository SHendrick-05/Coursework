namespace Coursework.GUI
{
    partial class SongEditorPopup
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
            this.OKbutton = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.audioPath = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.descLabel = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.browseImage = new System.Windows.Forms.Button();
            this.imagePath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.topPanel.Controls.Add(this.titleText);
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(446, 36);
            this.topPanel.TabIndex = 15;
            // 
            // titleText
            // 
            this.titleText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(39)))), ((int)(((byte)(44)))));
            this.titleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.titleText.Location = new System.Drawing.Point(0, 0);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(371, 36);
            this.titleText.TabIndex = 1;
            this.titleText.Text = "Editing song...";
            this.titleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.titleText.MouseMove += Drag;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(39)))), ((int)(((byte)(44)))));
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.FlatAppearance.BorderSize = 2;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closeButton.Location = new System.Drawing.Point(371, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 36);
            this.closeButton.TabIndex = 0;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // OKbutton
            // 
            this.OKbutton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.OKbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKbutton.ForeColor = System.Drawing.SystemColors.Control;
            this.OKbutton.Location = new System.Drawing.Point(112, 244);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(322, 42);
            this.OKbutton.TabIndex = 17;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.pathLabel.Location = new System.Drawing.Point(30, 42);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(76, 30);
            this.pathLabel.TabIndex = 16;
            this.pathLabel.Text = "Audio:";
            this.pathLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // titleBox
            // 
            this.titleBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.titleBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleBox.ForeColor = System.Drawing.SystemColors.Control;
            this.titleBox.Location = new System.Drawing.Point(112, 110);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(322, 27);
            this.titleBox.TabIndex = 19;
            // 
            // audioPath
            // 
            this.audioPath.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.audioPath.ForeColor = System.Drawing.SystemColors.Control;
            this.audioPath.Location = new System.Drawing.Point(112, 42);
            this.audioPath.Name = "audioPath";
            this.audioPath.Size = new System.Drawing.Size(226, 30);
            this.audioPath.TabIndex = 20;
            this.audioPath.Text = "...";
            // 
            // browseButton
            // 
            this.browseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.browseButton.Location = new System.Drawing.Point(344, 42);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(90, 30);
            this.browseButton.TabIndex = 21;
            this.browseButton.Text = "Browse..";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.titleLabel.Location = new System.Drawing.Point(30, 110);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(76, 27);
            this.titleLabel.TabIndex = 22;
            this.titleLabel.Text = "Title:";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // descLabel
            // 
            this.descLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.descLabel.Location = new System.Drawing.Point(5, 143);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(101, 50);
            this.descLabel.TabIndex = 24;
            this.descLabel.Text = "Description:";
            this.descLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // descriptionBox
            // 
            this.descriptionBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.descriptionBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descriptionBox.ForeColor = System.Drawing.SystemColors.Control;
            this.descriptionBox.Location = new System.Drawing.Point(112, 143);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(322, 95);
            this.descriptionBox.TabIndex = 23;
            // 
            // browseImage
            // 
            this.browseImage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.browseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseImage.ForeColor = System.Drawing.SystemColors.Control;
            this.browseImage.Location = new System.Drawing.Point(344, 78);
            this.browseImage.Name = "browseImage";
            this.browseImage.Size = new System.Drawing.Size(90, 30);
            this.browseImage.TabIndex = 27;
            this.browseImage.Text = "Browse..";
            this.browseImage.UseVisualStyleBackColor = true;
            this.browseImage.Click += new System.EventHandler(this.browseImage_Click);
            // 
            // imagePath
            // 
            this.imagePath.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.imagePath.ForeColor = System.Drawing.SystemColors.Control;
            this.imagePath.Location = new System.Drawing.Point(112, 78);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(226, 30);
            this.imagePath.TabIndex = 26;
            this.imagePath.Text = "...";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(30, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 30);
            this.label2.TabIndex = 25;
            this.label2.Text = "Image:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SongEditorPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(446, 296);
            this.Controls.Add(this.browseImage);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.audioPath);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.pathLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SongEditorPopup";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SongEditorPopup_Load);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Label audioPath;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Button browseImage;
        private System.Windows.Forms.Label imagePath;
        private System.Windows.Forms.Label label2;
    }
}