using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHWithDB
{
    class TeamsUtils
    {
        int iconSize = 0;
        int X = 0, Y = 0; // размеры сетки
        int countGridX = 0, countGridY = 0; //количество ячеек сетки

        List<PictureBox> icons;
        List<string> data;
        string sql;
        string discipline;
        Panel panel;
        string s = "Navi";

        public TeamsUtils(int iconSize, string sql, string discipline, Panel panel )
        {
            this.iconSize = iconSize;

            icons = new List<PictureBox>();

            data = new List<string>();

            this.sql = sql;

            this.discipline = discipline;

            this.panel = panel;
        }

        #region -- Работа с информацией --

        public void getData()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;

                DbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == discipline)
                        {

                            if (!reader.IsDBNull(1))
                                data.Add(reader.GetString(1));
                            else
                                data.Add(" . . . ");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                createTextBoxIfException(panel, e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void createTextBoxIfException(Panel content, string mess)
        {
            TextBox tb = new TextBox();
            tb.Location = new Point(0, 0);
            tb.Size = new Size(100, 30);
            content.Controls.Add(tb);
            tb.Text = mess;
        }

        #endregion

        public void drawIcons (PictureBox content)
        {
            int startX = X / 10, startY = Y / 10;
            int counter = 0;

            for (int j = 0; j < countGridY; j ++)
            {
                startX = X / 10;

                for (int i = 0; i < countGridX; i++)
                {
                    if (counter < data.Count)
                    {
                        PictureBox icon = new PictureBox();
                        icon.Location = new Point(startX, startY);
                        icon.Size = new Size(X * 8 / 10, Y * 8 / 10);
                        content.Controls.Add(icon);
                        startX += X;
                        icon.BackColor = Color.White;
                        icon.SizeMode = PictureBoxSizeMode.StretchImage;
                        icon.Name = data[counter];
                        string kostil = icon.Name;
                        int kek = kostil.Length - discipline.Length - 1; 
                        string lol = kostil.Remove(kek);
                        try
                        {
                            icon.Image = Image.FromFile("..\\TeamsLogo\\" + lol + ".png");

                        }
                        catch
                        {
                            icon.Image = Image.FromFile("..\\TeamsLogo\\" + "default" + ".png");
                        }
                        icons.Add(icon);
                        icon.Click += new EventHandler(testClick); // TODO убрать евент
                        counter++;
                    }
                }
                startY += Y;
            }
        }
        private void testClick (object sender, EventArgs e)
        {
           string name = (sender as PictureBox).Name;

            if (name == "Overwatch") // 6
            {
                
            } 
            else if (name == "Rocket League" || name== "Apex Legends") // 3
            {
                TeamThis3 tt3 = new TeamThis3(name, discipline);
                tt3.Show();
            } 
            else if (name == "PUBG") // 4
            {

            }
            else if (name == "WOT") //7
            {

            }
            else
            {
                TeamThis tt = new TeamThis(name, discipline);
                tt.Show();
            }
           
            // PlayerThis st = new PlayerThis(data[0][k], data[1][k], data[2][k], data[3][k], data[4][k], data[5][k]

                   
        }

        public void getSize (PictureBox content)
        {
            X = content.Size.Width;
            Y = content.Size.Height;

            setGrid();

            X = X / countGridX;
            Y = Y / countGridY;
        }

        private void setGrid ()
        {
            countGridX = X / iconSize;
            countGridY = Y / iconSize;
        }

        public void killIcons ()
        {
            foreach (PictureBox p in icons)
            {
                p.Dispose();
            }
            icons.Clear();
        }


        int count = 0;
        int checkIf;

        public void left ()
        {
            if (data.Count > icons.Count)
            {
                checkIf = 0;

                if (data.Count != 0)
                {
                    if (data[0] != icons[0].Name)
                    {
                        checkIf ++;
                    }
                }

                if (checkIf != 0)
                {
                    count--;
                }

                for (int i = 0; i < icons.Count; i++)
                {
                    if (data.Count > i + count)
                        icons[i].Name = data[i + count];

                    string kostil = icons[i].Name;
                    int kek = kostil.Length - discipline.Length - 1;
                    string lol = kostil.Remove(kek);

                    try
                    {
                        icons[i].Image = Image.FromFile("..\\TeamsLogo\\" + lol + ".png");

                    }
                    catch
                    {
                        icons[i].Image = Image.FromFile("..\\TeamsLogo\\" + "default" + ".png");
                    }
                }
            }

        }

        public void right ()
        {
            if(data.Count > icons.Count)
            {
                checkIf = 0;

                if (data.Count != 0)
                {
                    if (data[data.Count - 1] != icons[icons.Count - 1].Name)
                    {
                        checkIf ++;
                    }
                }

                if (checkIf != 0)
                {
                    count++;
                }

                for (int i = 0; i < icons.Count; i++)
                {
                    if (data.Count > i + count)
                        icons[i].Name = data[i + count];

                    string kostil = icons[i].Name;
                    int kek = kostil.Length - discipline.Length - 1;
                    string lol = kostil.Remove(kek);

                    try
                    {
                        icons[i].Image = Image.FromFile("..\\TeamsLogo\\" + lol + ".png");

                    }
                    catch
                    {
                        icons[i].Image = Image.FromFile("..\\TeamsLogo\\" + "default" + ".png");
                    }
                }


            }
        }
    }
}
