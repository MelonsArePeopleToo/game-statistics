namespace SHWithDB
{
    partial class Form2
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
            this.content = new System.Windows.Forms.Panel();
            this.childContent = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.helpButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.newRequestButton = new System.Windows.Forms.Button();
            this.playersButton = new System.Windows.Forms.Button();
            this.comandsButton = new System.Windows.Forms.Button();
            this.statSubMenu = new System.Windows.Forms.Panel();
            this.futureStatButton = new System.Windows.Forms.Button();
            this.nowStatButton = new System.Windows.Forms.Button();
            this.lastStatButton = new System.Windows.Forms.Button();
            this.statButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.childContent)).BeginInit();
            this.panel3.SuspendLayout();
            this.statSubMenu.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.Controls.Add(this.childContent);
            this.content.Controls.Add(this.panel3);
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(0, 0);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(800, 450);
            this.content.TabIndex = 1;
            // 
            // childContent
            // 
            this.childContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.childContent.Location = new System.Drawing.Point(190, 0);
            this.childContent.Name = "childContent";
            this.childContent.Size = new System.Drawing.Size(610, 450);
            this.childContent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.childContent.TabIndex = 2;
            this.childContent.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.panel3.Controls.Add(this.helpButton);
            this.panel3.Controls.Add(this.exitButton);
            this.panel3.Controls.Add(this.newRequestButton);
            this.panel3.Controls.Add(this.playersButton);
            this.panel3.Controls.Add(this.comandsButton);
            this.panel3.Controls.Add(this.statSubMenu);
            this.panel3.Controls.Add(this.statButton);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(190, 450);
            this.panel3.TabIndex = 1;
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(30)))));
            this.helpButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.helpButton.FlatAppearance.BorderSize = 0;
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helpButton.ForeColor = System.Drawing.SystemColors.Window;
            this.helpButton.Location = new System.Drawing.Point(0, 380);
            this.helpButton.Name = "helpButton";
            this.helpButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.helpButton.Size = new System.Drawing.Size(190, 35);
            this.helpButton.TabIndex = 5;
            this.helpButton.Text = "О приложении";
            this.helpButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(30)))));
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.Window;
            this.exitButton.Location = new System.Drawing.Point(0, 415);
            this.exitButton.Name = "exitButton";
            this.exitButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.exitButton.Size = new System.Drawing.Size(190, 35);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Обратно";
            this.exitButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // newRequestButton
            // 
            this.newRequestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(30)))));
            this.newRequestButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.newRequestButton.FlatAppearance.BorderSize = 0;
            this.newRequestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newRequestButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newRequestButton.ForeColor = System.Drawing.SystemColors.Window;
            this.newRequestButton.Location = new System.Drawing.Point(0, 307);
            this.newRequestButton.Name = "newRequestButton";
            this.newRequestButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.newRequestButton.Size = new System.Drawing.Size(190, 67);
            this.newRequestButton.TabIndex = 3;
            this.newRequestButton.Text = "Подать заявку на участие";
            this.newRequestButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newRequestButton.UseVisualStyleBackColor = false;
            this.newRequestButton.Click += new System.EventHandler(this.newRequestButton_Click);
            // 
            // playersButton
            // 
            this.playersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(30)))));
            this.playersButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.playersButton.FlatAppearance.BorderSize = 0;
            this.playersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playersButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playersButton.ForeColor = System.Drawing.SystemColors.Window;
            this.playersButton.Location = new System.Drawing.Point(0, 272);
            this.playersButton.Name = "playersButton";
            this.playersButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.playersButton.Size = new System.Drawing.Size(190, 35);
            this.playersButton.TabIndex = 2;
            this.playersButton.Text = "Игроки";
            this.playersButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playersButton.UseVisualStyleBackColor = false;
            this.playersButton.Click += new System.EventHandler(this.playersButton_Click);
            // 
            // comandsButton
            // 
            this.comandsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(30)))));
            this.comandsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.comandsButton.FlatAppearance.BorderSize = 0;
            this.comandsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comandsButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comandsButton.ForeColor = System.Drawing.SystemColors.Window;
            this.comandsButton.Location = new System.Drawing.Point(0, 237);
            this.comandsButton.Name = "comandsButton";
            this.comandsButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.comandsButton.Size = new System.Drawing.Size(190, 35);
            this.comandsButton.TabIndex = 1;
            this.comandsButton.Text = "Команды";
            this.comandsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.comandsButton.UseVisualStyleBackColor = false;
            this.comandsButton.Click += new System.EventHandler(this.comandsButton_Click);
            // 
            // statSubMenu
            // 
            this.statSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.statSubMenu.Controls.Add(this.futureStatButton);
            this.statSubMenu.Controls.Add(this.nowStatButton);
            this.statSubMenu.Controls.Add(this.lastStatButton);
            this.statSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.statSubMenu.Location = new System.Drawing.Point(0, 140);
            this.statSubMenu.Name = "statSubMenu";
            this.statSubMenu.Size = new System.Drawing.Size(190, 97);
            this.statSubMenu.TabIndex = 1;
            // 
            // futureStatButton
            // 
            this.futureStatButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.futureStatButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.futureStatButton.FlatAppearance.BorderSize = 0;
            this.futureStatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.futureStatButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.futureStatButton.ForeColor = System.Drawing.SystemColors.Window;
            this.futureStatButton.Location = new System.Drawing.Point(0, 50);
            this.futureStatButton.Name = "futureStatButton";
            this.futureStatButton.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.futureStatButton.Size = new System.Drawing.Size(190, 25);
            this.futureStatButton.TabIndex = 3;
            this.futureStatButton.Text = "Будущие";
            this.futureStatButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.futureStatButton.UseVisualStyleBackColor = false;
            this.futureStatButton.Click += new System.EventHandler(this.futureStatButton_Click);
            // 
            // nowStatButton
            // 
            this.nowStatButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.nowStatButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.nowStatButton.FlatAppearance.BorderSize = 0;
            this.nowStatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nowStatButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nowStatButton.ForeColor = System.Drawing.SystemColors.Window;
            this.nowStatButton.Location = new System.Drawing.Point(0, 25);
            this.nowStatButton.Name = "nowStatButton";
            this.nowStatButton.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.nowStatButton.Size = new System.Drawing.Size(190, 25);
            this.nowStatButton.TabIndex = 2;
            this.nowStatButton.Text = "Текущие";
            this.nowStatButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nowStatButton.UseVisualStyleBackColor = false;
            this.nowStatButton.Click += new System.EventHandler(this.nowStatButton_Click);
            // 
            // lastStatButton
            // 
            this.lastStatButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.lastStatButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.lastStatButton.FlatAppearance.BorderSize = 0;
            this.lastStatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lastStatButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastStatButton.ForeColor = System.Drawing.SystemColors.Window;
            this.lastStatButton.Location = new System.Drawing.Point(0, 0);
            this.lastStatButton.Name = "lastStatButton";
            this.lastStatButton.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.lastStatButton.Size = new System.Drawing.Size(190, 25);
            this.lastStatButton.TabIndex = 1;
            this.lastStatButton.Text = "Прошедшие";
            this.lastStatButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lastStatButton.UseVisualStyleBackColor = false;
            this.lastStatButton.Click += new System.EventHandler(this.lastStatButton_Click);
            // 
            // statButton
            // 
            this.statButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(9)))), ((int)(((byte)(30)))));
            this.statButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.statButton.FlatAppearance.BorderSize = 0;
            this.statButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.statButton.Location = new System.Drawing.Point(0, 92);
            this.statButton.Name = "statButton";
            this.statButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.statButton.Size = new System.Drawing.Size(190, 48);
            this.statButton.TabIndex = 1;
            this.statButton.Text = "Статистика";
            this.statButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statButton.UseVisualStyleBackColor = false;
            this.statButton.Click += new System.EventHandler(this.statButton_Click_1);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(190, 92);
            this.panel5.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::SHWithDB.Properties.Resources.cyber_sport_neon__2_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.content);
            this.Name = "Form2";
            this.Text = "Form2";
            this.content.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.childContent)).EndInit();
            this.panel3.ResumeLayout(false);
            this.statSubMenu.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel content;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button newRequestButton;
        private System.Windows.Forms.Button playersButton;
        private System.Windows.Forms.Button comandsButton;
        private System.Windows.Forms.Panel statSubMenu;
        private System.Windows.Forms.Button futureStatButton;
        private System.Windows.Forms.Button nowStatButton;
        private System.Windows.Forms.Button lastStatButton;
        private System.Windows.Forms.Button statButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox childContent;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}