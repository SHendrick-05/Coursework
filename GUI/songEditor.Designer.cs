﻿namespace Coursework.GUI
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
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bpmBox)).BeginInit();
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
            this.noteCreator.Location = new System.Drawing.Point(420, 149);
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
            this.generationLabel.Location = new System.Drawing.Point(385, 116);
            this.generationLabel.Name = "generationLabel";
            this.generationLabel.Size = new System.Drawing.Size(140, 30);
            this.generationLabel.TabIndex = 10;
            this.generationLabel.Text = "Notes generated!";
            this.generationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.generationLabel.Visible = false;
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(450, 42);
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
            this.saveButton.Location = new System.Drawing.Point(420, 197);
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
            this.bpmBox.Location = new System.Drawing.Point(595, 203);
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
            this.label1.Location = new System.Drawing.Point(595, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 30);
            this.label1.TabIndex = 22;
            this.label1.Text = "BPM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SongEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bpmBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.noteCreator);
            this.Controls.Add(this.generationLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SongEditor";
            this.Text = "songEditor";
            this.Load += new System.EventHandler(this.SongEditor_Load);
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bpmBox)).EndInit();
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
    }
}