using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHWithDB

{
    public partial class Form1 : Form
    {
        int x = 0, y = 0, mouseX = 0, mouseY = 0;
        public Form1()
        {
            InitializeComponent();

            Thread t = new Thread(f);
            t.Start();
        }

        private void f ()
        {
            contentBox.Image = Properties.Resources.Main4;
            Thread.Sleep(10);
        }
  
      

        private void Form1_Load(object sender, EventArgs e)
        {
            x = this.Size.Width;
            y = this.Size.Height;
        }

        private void contentBox_Click_1(object sender, EventArgs e)
        {
            if ((mouseX > 0 && mouseX < x / 7) && (mouseY > 0 && mouseY < y / 2.7)) // Dota 2
            {
                openChildForm(new Form2("Dota 2", this, 5));
            }
            else if ((mouseX > x / 7 && mouseX < 2 * (x / 7)) && (mouseY > 0 && mouseY < y / 2.7)) // CS:GO
            {
                openChildForm(new Form2("CS:GO", this, 5));
            }
            else if ((mouseX > 2 * (x / 7) && mouseX < 3 * (x / 7)) && (mouseY > 0 && mouseY < y / 2.7)) // LOL
            {
                openChildForm(new Form2("LOL", this, 5));
            }
            else if ((mouseX > 3 * (x / 7) && mouseX < 4 * (x / 7)) && (mouseY > 0 && mouseY < y / 2.7)) // Valorant
            {
                openChildForm(new Form2("Valorant", this, 5));
            }
            else if ((mouseX > 4 * (x / 7) && mouseX < 5 * (x / 7)) && (mouseY > 0 && mouseY < y / 2.7)) // Smite
            {
                openChildForm(new Form2("Smite", this, 5));
            }
            else if ((mouseX > 5 * (x / 7) && mouseX < 6 * (x / 7)) && (mouseY > 0 && mouseY < y / 2.7)) // COD
            {
                openChildForm(new Form2("COD", this, 5));
            }
            else if ((mouseX > 6 * (x / 7) && mouseX < x) && (mouseY > 0 && mouseY < y / 2.7)) // Rainbow Six: Siege
            {
                openChildForm(new Form2("Rainbow Six: Siege", this, 5));
            }
            else if ((mouseX > 0 && mouseX < x / 7) && (mouseY > y / 2.7 && mouseY < y)) // Overwatch
            {
                openChildForm(new Form2("Overwatch", this, 6));
            }
            else if ((mouseX > (x / 7) && mouseX < 2 * (x / 7)) && (mouseY > y / 2.7 && mouseY < y)) // Warface
            {
                openChildForm(new Form2("Warface", this, 5));
            }
            else if ((mouseX > 2 * (x / 7) && mouseX < 3 * (x / 7)) && (mouseY > y / 2.7 && mouseY < y)) // Rocket League
            {
                openChildForm(new Form2("Rocket League", this, 3));
            }
            else if ((mouseX > 3 * (x / 7) && mouseX < 4 * (x / 7)) && (mouseY > y / 2.7 && mouseY < y)) // WOT
            {
                openChildForm(new Form2("WOT", this, 7));
            }
            else if ((mouseX > 4 * (x / 7) && mouseX < 5 * (x / 7)) && (mouseY > y / 2.7 && mouseY < y)) // PUBG
            {
                openChildForm(new Form2("PUBG", this, 4));
            }
            else if ((mouseX > 5 * (x / 7) && mouseX < 6 * (x / 7)) && (mouseY > y / 2.7 && mouseY < y)) // Apex Legends
            {
                openChildForm(new Form2("Apex Legends", this, 5));
            }
            else if ((mouseX > 6 * (x / 7) && mouseX < x) && (mouseY > y / 2.7 && mouseY < y)) // browse
            {
                Process.Start("IExplore.exe", "http://expert.ktsstudio.com/index/?system_id=237");
            }
        }

        private void contentBox_SizeChanged(object sender, EventArgs e)
        {
            x = this.Size.Width;
            y = this.Size.Height;
        }
        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button2_Click(object sender, EventArgs e)  // скрыть
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e) // фулл
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void statButton_Click(object sender, EventArgs e) // ехсит
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Enter(object sender, EventArgs e)
        {
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

            this.panel1.Refresh();

        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            button1.Visible = true;
        }

        private void statButton_Paint(object sender, PaintEventArgs e)
        {
            statButton.Visible = true;
            
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            button2.Visible = true;
        }

        private void contentBox_MouseMove_1(object sender, MouseEventArgs e)
        {
            this.mouseX = e.X;
            this.mouseY = e.Y;
        }


        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Hide();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            contentBox.Controls.Add(childForm);
            contentBox.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


    }
}
