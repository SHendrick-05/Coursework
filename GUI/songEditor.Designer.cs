namespace Coursework.GUI
{
    partial class SongEditor
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
            this.noteCreator = new System.Windows.Forms.Button();
            this.generationLabel = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.bpmBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.createSong = new System.Windows.Forms.Button();
            this.difficultyBox = new System.Windows.Forms.ComboBox();
            this.creationPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.mineBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.editErrorLabel = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bpmBox)).BeginInit();
            this.creationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mineBar)).BeginInit();
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
            this.topPanel.Size = new System.Drawing.Size(800, 36);
            this.topPanel.TabIndex = 9;
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
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // noteCreator
            // 
            this.noteCreator.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.noteCreator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noteCreator.ForeColor = System.Drawing.SystemColors.Control;
            this.noteCreator.Location = new System.Drawing.Point(55, 33);
            this.noteCreator.Name = "noteCreator";
            this.noteCreator.Size = new System.Drawing.Size(105, 42);
            this.noteCreator.TabIndex = 13;
            this.noteCreator.Text = "Generate notes!";
            this.noteCreator.UseVisualStyleBackColor = true;
            this.noteCreator.Click += new System.EventHandler(this.songEditorButton_Click);
            // 
            // generationLabel
            // 
            this.generationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.generationLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.generationLabel.Location = new System.Drawing.Point(20, 0);
            this.generationLabel.Name = "generationLabel";
            this.generationLabel.Size = new System.Drawing.Size(140, 30);
            this.generationLabel.TabIndex = 10;
            this.generationLabel.Text = "Notes generated!";
            this.generationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.generationLabel.Visible = false;
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(629, 78);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(75, 23);
            this.settingsButton.TabIndex = 14;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.ForeColor = System.Drawing.SystemColors.Control;
            this.saveButton.Location = new System.Drawing.Point(55, 81);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(105, 42);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Save and exit";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // bpmBox
            // 
            this.bpmBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.bpmBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bpmBox.DecimalPlaces = 2;
            this.bpmBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bpmBox.ForeColor = System.Drawing.SystemColors.Control;
            this.bpmBox.Location = new System.Drawing.Point(234, 92);
            this.bpmBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.bpmBox.Name = "bpmBox";
            this.bpmBox.Size = new System.Drawing.Size(120, 31);
            this.bpmBox.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(234, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 30);
            this.label1.TabIndex = 22;
            this.label1.Text = "BPM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.titleLabel.Location = new System.Drawing.Point(0, 39);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(800, 30);
            this.titleLabel.TabIndex = 23;
            this.titleLabel.Text = "Currently editing: ";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createSong
            // 
            this.createSong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.createSong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createSong.ForeColor = System.Drawing.SystemColors.Control;
            this.createSong.Location = new System.Drawing.Point(205, 78);
            this.createSong.Name = "createSong";
            this.createSong.Size = new System.Drawing.Size(105, 42);
            this.createSong.TabIndex = 24;
            this.createSong.Text = "Create new song";
            this.createSong.UseVisualStyleBackColor = true;
            this.createSong.Click += new System.EventHandler(this.createSong_Click);
            // 
            // difficultyBox
            // 
            this.difficultyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficultyBox.FormattingEnabled = true;
            this.difficultyBox.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.difficultyBox.Location = new System.Drawing.Point(233, 33);
            this.difficultyBox.Name = "difficultyBox";
            this.difficultyBox.Size = new System.Drawing.Size(121, 23);
            this.difficultyBox.TabIndex = 25;
            // 
            // creationPanel
            // 
            this.creationPanel.Controls.Add(this.label3);
            this.creationPanel.Controls.Add(this.mineBar);
            this.creationPanel.Controls.Add(this.label2);
            this.creationPanel.Controls.Add(this.noteCreator);
            this.creationPanel.Controls.Add(this.difficultyBox);
            this.creationPanel.Controls.Add(this.generationLabel);
            this.creationPanel.Controls.Add(this.label1);
            this.creationPanel.Controls.Add(this.bpmBox);
            this.creationPanel.Controls.Add(this.saveButton);
            this.creationPanel.Location = new System.Drawing.Point(205, 149);
            this.creationPanel.Name = "creationPanel";
            this.creationPanel.Size = new System.Drawing.Size(400, 250);
            this.creationPanel.TabIndex = 26;
            this.creationPanel.Visible = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(55, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 30);
            this.label3.TabIndex = 28;
            this.label3.Text = "Mines";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mineBar
            // 
            this.mineBar.Location = new System.Drawing.Point(55, 193);
            this.mineBar.Name = "mineBar";
            this.mineBar.Size = new System.Drawing.Size(299, 45);
            this.mineBar.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(233, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 30);
            this.label2.TabIndex = 26;
            this.label2.Text = "Difficulty";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editButton
            // 
            this.editButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(127)))));
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.ForeColor = System.Drawing.SystemColors.Control;
            this.editButton.Location = new System.Drawing.Point(316, 78);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(115, 42);
            this.editButton.TabIndex = 27;
            this.editButton.Text = "Edit existing song";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // editErrorLabel
            // 
            this.editErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.editErrorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(41)))), ((int)(((byte)(44)))));
            this.editErrorLabel.Location = new System.Drawing.Point(439, 78);
            this.editErrorLabel.Name = "editErrorLabel";
            this.editErrorLabel.Size = new System.Drawing.Size(166, 42);
            this.editErrorLabel.TabIndex = 28;
            this.editErrorLabel.Text = "Invalid folder selected!";
            this.editErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editErrorLabel.Visible = false;
            // 
            // SongEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.editErrorLabel);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.creationPanel);
            this.Controls.Add(this.createSong);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SongEditor";
            this.Text = "songEditor";
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bpmBox)).EndInit();
            this.creationPanel.ResumeLayout(false);
            this.creationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mineBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button noteCreator;
        private System.Windows.Forms.Label generationLabel;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.NumericUpDown bpmBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button createSong;
        private System.Windows.Forms.ComboBox difficultyBox;
        private System.Windows.Forms.Panel creationPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar mineBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label editErrorLabel;
    }
}