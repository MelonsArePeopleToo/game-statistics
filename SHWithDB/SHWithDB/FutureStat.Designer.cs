namespace SHWithDB
{
    partial class FutureStat
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.leftButton);
            this.panel1.Controls.Add(this.rightButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 426);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 24);
            this.panel1.TabIndex = 2;
            // 
            // leftButton
            // 
            this.leftButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.leftButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.leftButton.FlatAppearance.BorderSize = 0;
            this.leftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.leftButton.Location = new System.Drawing.Point(680, 0);
            this.leftButton.Name = "leftButton";
            this.leftButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.leftButton.Size = new System.Drawing.Size(60, 24);
            this.leftButton.TabIndex = 3;
            this.leftButton.Text = "<--";
            this.leftButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.leftButton.UseVisualStyleBackColor = false;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.rightButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightButton.FlatAppearance.BorderSize = 0;
            this.rightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rightButton.Location = new System.Drawing.Point(740, 0);
            this.rightButton.Name = "rightButton";
            this.rightButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.rightButton.Size = new System.Drawing.Size(60, 24);
            this.rightButton.TabIndex = 2;
            this.rightButton.Text = "-->";
            this.rightButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rightButton.UseVisualStyleBackColor = false;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // FutureStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FutureStat";
            this.Text = "FutureStat";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
    }
}