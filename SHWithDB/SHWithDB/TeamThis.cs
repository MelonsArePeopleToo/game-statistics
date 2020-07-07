using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHWithDB
{
    public partial class TeamThis : Form
    {
        List<string> players = new List<string>();

        public TeamThis(string team, string discipline)
        {
            InitializeComponent();
            label1.Text = discipline;
            label2.Text = team;

            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM teamInfo;";

                DbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        if (reader.GetString(2) == team)
                        {
                            {
                                players.Add(reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // createTextBoxIfException(panel, e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            label1.Text = players[0];
            label2.Text = players[1];
            label3.Text = players[2];
            label4.Text = players[3];
            label5.Text = players[4];
          

            try
            {
                pictureBox2.Image = Image.FromFile("..\\Players\\" + label1.Text + ".png");

            }
            catch
            {
                try
                {
                    pictureBox2.Image = Image.FromFile("..\\Players\\" + players[0] + ".jpg");

                }
                catch
                {
                    pictureBox2.Image = Image.FromFile("..\\Players\\" + "default" + ".png");

                }
            }

            try
            {
                pictureBox4.Image = Image.FromFile("..\\Players\\" + players[1] + ".png");

            }
            catch
            {
                try
                {
                    pictureBox4.Image = Image.FromFile("..\\Players\\" + players[1] + ".jpg");

                }
                catch
                {
                    pictureBox4.Image = Image.FromFile("..\\Players\\" + "default" + ".png");

                }
            }
            try
            {
                pictureBox5.Image = Image.FromFile("..\\Players\\" + players[2] + ".png");

            }
            catch
            {
                try
                {
                    pictureBox5.Image = Image.FromFile("..\\Players\\" + players[2] + ".jpg");

                }
                catch
                {
                    pictureBox5.Image = Image.FromFile("..\\Players\\" + "default" + ".png");

                }
            }
            try
            {
                pictureBox6.Image = Image.FromFile("..\\Players\\" + players[3] + ".png");

            }
            catch
            {
                try
                {
                    pictureBox6.Image = Image.FromFile("..\\Players\\" + players[3] + ".jpg");

                }
                catch
                {
                    pictureBox6.Image = Image.FromFile("..\\Players\\" + "default" + ".png");

                }
            }
            try
            {
                pictureBox7.Image = Image.FromFile("..\\Players\\" + players[4] + ".png");

            }
            catch
            {
                try
                {
                    pictureBox7.Image = Image.FromFile("..\\Players\\" + players[4] + ".jpg");

                }
                catch
                {
                    pictureBox7.Image = Image.FromFile("..\\Players\\" + "default" + ".png");

                }
            }

        }
    


        private void statButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Point lastPoint;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        
    }
}
