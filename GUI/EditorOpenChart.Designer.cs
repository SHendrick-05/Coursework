namespace Coursework.GUI
{
    partial class EditorOpenChart
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
            this.openButton = new System.Windows.Forms.Button();
            this.songTitle = new System.Windows.Forms.Label();
            this.selectedLabel = new System.Windows.Forms.Label();
            this.chartLayout = new System.Windows.Forms.FlowLayoutPanel();
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
            this.topPanel.Size = new System.Drawing.Size(800, 36);
            this.topPanel.TabIndex = 23;
            this.topPanel.MouseMove += Drag;
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
            this.titleText.MouseMove += Drag;
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
            // openButton
            // 
            this.openButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openButton.ForeColor = System.Drawing.SystemColors.Control;
            this.openButton.Location = new System.Drawing.Point(596, 401);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(192, 43);
            this.openButton.TabIndex = 21;
            this.openButton.Text = "Edit";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // songTitle
            // 
            this.songTitle.Location = new System.Drawing.Point(0, 6);
            this.songTitle.Name = "songTitle";
            this.songTitle.Size = new System.Drawing.Size(100, 23);
            this.songTitle.TabIndex = 22;
            // 
            // selectedLabel
            // 
            this.selectedLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectedLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.selectedLabel.Location = new System.Drawing.Point(596, 48);
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.Size = new System.Drawing.Size(192, 350);
            this.selectedLabel.TabIndex = 25;
            this.selectedLabel.Text = "Chart selected:";
            this.selectedLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // chartLayout
            // 
            this.chartLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartLayout.Location = new System.Drawing.Point(12, 48);
            this.chartLayout.Name = "chartLayout";
            this.chartLayout.Size = new System.Drawing.Size(578, 396);
            this.chartLayout.TabIndex = 24;
            // 
            // EditorOpenChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.songTitle);
            this.Controls.Add(this.selectedLabel);
            this.Controls.Add(this.chartLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditorOpenChart";
            this.Text = "EditorOpenChart";
            this.Load += new System.EventHandler(this.EditorOpenChart_Load);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Label songTitle;
        private System.Windows.Forms.Label selectedLabel;
        private System.Windows.Forms.FlowLayoutPanel chartLayout;
    }
}