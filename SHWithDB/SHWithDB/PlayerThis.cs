using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHWithDB
{
    public partial class PlayerThis : Form
    {
        public PlayerThis(string nick, string FIO, string date, string rang, string club, string strana)
        {
            InitializeComponent();
            label1.Parent = pictureBox3;
            label2.Parent = pictureBox3;
            label3.Parent = pictureBox3;
            label4.Parent = pictureBox3;
            label5.Parent = pictureBox3;
            label6.Parent = pictureBox3;
            label7.Parent = pictureBox3;
            label8.Parent = pictureBox3;
            label9.Parent = pictureBox3;
            label10.Parent = pictureBox3;
            label11.Parent = pictureBox3;
            label12.Parent = pictureBox3;

            
                string newData = "";
                for (int i = 0; i < 10; i++)
                {
                    newData += date[i];
                }
               
            

            label1.Text = nick;
            label2.Text = FIO;
            label3.Text = (newData);
            label4.Text = (rang);
            label5.Text = club;
            label6.Text = strana;

            try
            {
                pictureBox2.Image = Image.FromFile("..\\Players\\" + nick + ".png");

            }
            catch
            {
                try
                {
                    pictureBox2.Image = Image.FromFile("..\\Players\\" + nick + ".jpg");
                }
                catch
                {
                    pictureBox2.Image = Image.FromFile("..\\Players\\" + "default" + ".png");
                }

            }

        }

        private void PlayerThis_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void statButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Point lastPoint;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
