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
    class PlayersUtils
    {
        int iconSize = 0;
        int X = 0, Y = 0; // размеры сетки
        int countGridX = 0, countGridY = 0; //количество ячеек сетки

        List<PictureBox> icons;
        List<List<string>> data;
        List<Button> buttons;
        List<Label> labels;
        string sql;
        string discipline;
        Panel panel;
       // string s = "Navi";

        public PlayersUtils(int iconSize, string sql, string discipline, Panel panel )
        {
            this.iconSize = iconSize;

            icons = new List<PictureBox>();

            data = new List<List<string>>();

            for (int i = 0; i < 6; i++)
                data.Add(new List<string>());

            buttons = new List<Button>();

            this.sql = sql;

            this.discipline = discipline;

            this.panel = panel;

            labels = new List<Label>();
     
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
                        string temp = reader.GetString(5);  
                        if (temp.Contains( discipline))
                        {
                            if (!reader.IsDBNull(1))
                                data[0].Add(reader.GetString(1));
                            else
                                data[0].Add(" . . . ");
                            
                            if (!reader.IsDBNull(2))
                                data[1].Add(reader.GetString(2));
                            else
                                data[1].Add(" . . . ");

                            if (!reader.IsDBNull(3))
                                data[2].Add(reader.GetString(3));
                            else
                                data[2].Add(" . . . ");

                            if (!reader.IsDBNull(4))
                                data[3].Add(reader.GetString(4));
                            else
                                data[3].Add(" . . . ");
   
                            data[4].Add(temp);

                            if (!reader.IsDBNull(6))
                                data[5].Add(reader.GetString(6));
                            else
                                data[5].Add(" . . . ");
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

        #region -- Графика --
        public void drawIcons(PictureBox content)
        {
            int startX = X / 10, startY = Y / 10;
            int counter = 0;

            for (int j = 0; j < countGridY; j++)
            {
                startX = X / 10;

                for (int i = 0; i < countGridX; i++)
                {
                    if (counter < data[0].Count)
                    {
                        PictureBox icon = new PictureBox();
                        icon.Location = new Point(startX, startY);
                        icon.Size = new Size(X * 8 / 10, Y * 7 / 10);
                        content.Controls.Add(icon);
                  
                        icon.BackColor = Color.White;
                        icon.SizeMode = PictureBoxSizeMode.StretchImage;
                        icon.Name = data[0][counter];
                        try
                        {
                            icon.Image = Image.FromFile("..\\Players\\" + icon.Name + ".png");

                        }
                        catch
                        {
                            try
                            {
                                icon.Image = Image.FromFile("..\\Players\\" + icon.Name + ".jpg");
                            }
                            catch
                            {
                                icon.Image = Image.FromFile("..\\Players\\" + "default" + ".png");
                            }
                            
                        }
                        icons.Add(icon);
                        icon.Click += new EventHandler(clc);
                        

                        Label l = new Label();
                        l.Location = new Point(startX, startY + Y * 7 / 10);
                        l.Size = new Size(X * 8 / 10, Y  / 10 + 10);
                        l.Name = data[0][counter];
                        l.Text = l.Name;                                        
                        l.Parent = content;
                        l.TextAlign = ContentAlignment.MiddleCenter;
                        l.BackColor = Color.FromArgb(150,0,0,0);                // задний цвет лейбла с ником игрока ( 1 - прозрачность 2-4 - ргб )
                        l.ForeColor = Color.White;                              // цвет текста либо можно через .FromArgb как на строке выше
                        l.Font = new Font("Times New Roman", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        content.Controls.Add(l);
                        labels.Add(l);


                        startX += X;
                        counter++;
                    }
                }
                startY += Y - 10;
            }
        }
        void clc(object sender, EventArgs e)
        {
            string name = (sender as PictureBox).Name;
            for (int k = 0; k < data[0].Count; k++)
                if (data[0][k] == name)
                /* MessageBox.Show("Ник : " + data[0][k] + "\n" + 
                     "ФИО : " + data[1][k] + "\n" +
                     "Дата рождения :" + data[2][k] + "\n" +
                     "Ранг :" + data[3][k] + "\n" +
                     "Клуб :" + data[4][k] + "\n" +
                     "Страна : " + data[5][k] 
                     );*/
                {
                    PlayerThis st = new PlayerThis(data[0][k], data[1][k], data[2][k], data[3][k], data[4][k], data[5][k]);
                    st.Show();
                }
            
        }

        public void getSize(PictureBox content)
        {
            X = content.Size.Width;
            Y = content.Size.Height;

            setGrid();

            X = X / countGridX;
            Y = Y / countGridY;
        }

        private void setGrid()
        {
            countGridX = X / iconSize;
            countGridY = Y / iconSize;
        }

        public void killIcons()
        {
            foreach (PictureBox p in icons)
            {
                p.Dispose();
            }
            icons.Clear();

            foreach (Label p in labels)
            {
                p.Dispose();
            }
            labels.Clear();

        }
        #endregion


        int count = 0;
        int checkIf;

        public void left()
        {
            if (data[0].Count > icons.Count)
            {
                checkIf = 0;

                if (data[0].Count != 0)
                {
                    if (data[0][0] != icons[0].Name)
                    {
                        checkIf++;
                    }
                }

                if (checkIf != 0)
                {
                    count--;
                }

                for (int i = 0; i < icons.Count; i++)
                {
                    if (data[0].Count > i + count)
                        icons[i].Name = data[0][i + count];
                    try
                    {
                        icons[i].Image = Image.FromFile("..\\Players\\" + icons[i].Name + ".png");

                    }
                    catch
                    {
                        try
                        {
                            icons[i].Image = Image.FromFile("..\\Players\\" + icons[i].Name + ".jpg");
                        }
                        catch
                        {
                            icons[i].Image = Image.FromFile("..\\Players\\" + "default" + ".png");
                        }
                    }
                    labels[i].Text = icons[i].Name;
                }
            }
        }

        public void right()
        {
            if (data[0].Count > icons.Count)
            {
                checkIf = 0;

                if (data[0].Count != 0)
                {
                    if (data[0][data[0].Count - 1] != icons[icons.Count - 1].Name)
                    {
                        checkIf++;
                    }
                }

                if (checkIf != 0)
                {
                    count++;
                }

                for (int i = 0; i < icons.Count; i++)
                {
                    if (data[0].Count > i + count)
                        icons[i].Name = data[0][i + count];
                    try
                    {
                        icons[i].Image = Image.FromFile("..\\Players\\" + icons[i].Name + ".png");

                    }
                    catch
                    {
                        try
                        {
                            icons[i].Image = Image.FromFile("..\\Players\\" + icons[i].Name + ".jpg");
                        }
                        catch
                        {
                            icons[i].Image = Image.FromFile("..\\Players\\" + "default" + ".png");
                        }
                    }
                    labels[i].Text = icons[i].Name;

                }


            }
        }



    }
}
