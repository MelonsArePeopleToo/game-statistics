using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHWithDB
{
    class StatisticsUtils
    {
        #region -- Переменные --

        private List<List<string>> data;
        private List<int> sizeX;
        private const int sizeY = 1;
        private double X = 0, Y = 0; // изначальные размеры окна
        private double newX = 0, newY = 0; // измененные размеры окна 
        private double multiplierX = 1, multiplierY = 1; // множители измененного окна
        private const double normX = 5, normY = 20; // можители размеров лейблов изначального окна
        private const double spaceX = 5, spaceY = 5; // размеры отступов

        private double nowX = 0; // длина массива лейблов после отрисовки


        private Font font ()
        {
            if (multiplierX < 2)
                return new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            else
                return new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        }

        private Color backColor = Color.Transparent;
        private Color foreColor = Color.White;

        private List<Label> borderLabel; 
        private List<List<Label>> contentLabels;
        private List<Button> contentButtons;

        #endregion

        public StatisticsUtils()
        {
            data = new List<List<string>>();
            sizeX = new List<int>();

            borderLabel = new List<Label>();
            contentLabels = new List<List<Label>>();
            contentButtons = new List<Button>();

            for (int i = 0; i < 12; i++)
                data.Add(new List<string>());

            for (int i = 0; i < 12; i++)
                contentLabels.Add(new List<Label>());
        }

        #region -- Работа с информацией --

        public void getData(string sql, string discipline, string period, Panel panel)
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
                                if (tournamentParserByDate(reader.GetDateTime(9), reader.GetDateTime(10)) == period)
                                {
                                    fillListData(reader);
                                }
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

            changeDateSizeInList();
            getSizeOfStrinds();
            getTotalWigth();
        }

        private void fillListData(DbDataReader reader)
        {
            if (!reader.IsDBNull(1))
                data[0].Add(reader.GetString(1));
            else
                data[0].Add(" . . . ");
            ///----------------------------------------------------
            if (!reader.IsDBNull(2))
                data[1].Add(reader.GetString(2));
            else
                data[1].Add(" . . . ");
            ///----------------------------------------------------
            if (!reader.IsDBNull(3))
                data[2].Add(reader.GetString(3));
            else
                data[2].Add(" . . . ");
            ///----------------------------------------------------
            if (!reader.IsDBNull(4))
                data[3].Add(reader.GetString(4));
            else
                data[3].Add(" . . . ");
            ///----------------------------------------------------
            if (!reader.IsDBNull(5))
                data[4].Add(reader.GetString(5));
            else
                data[4].Add(" . . . ");
            ///----------------------------------------------------
            if (!reader.IsDBNull(6))
                data[5].Add(reader.GetString(6));
            else
                data[5].Add(" . . . ");
            ///----------------------------------------------------
            if (!reader.IsDBNull(7))
                data[6].Add(reader.GetString(7));
            else
                data[6].Add(" . . . ");
            ///----------------------------------------------------
            if (!reader.IsDBNull(8))
                data[7].Add(reader.GetString(8));
            else
                data[7].Add(" . . . ");
            ///----------------------------------------------------
            if (!reader.IsDBNull(9))
                data[8].Add(reader.GetString(9));
            else
                data[8].Add(" . . . ");
            ///----------------------------------------------------
            if (!reader.IsDBNull(10))
                data[9].Add(reader.GetString(10));
            else
                data[9].Add(" . . . ");
            ///----------------------------------------------------
            if (!reader.IsDBNull(11))
                data[10].Add(reader.GetString(11));
            else
                data[10].Add(" . . . ");
            ///----------------------------------------------------
            if (!reader.IsDBNull(12))
                data[11].Add(reader.GetString(12));
            else
                data[11].Add(" . . . ");
            ///----------------------------------------------------
        }

        private void changeDateSizeInList ()
        {
            for (int i = 0; i < data[8].Count; i++)
            {
                data[8][i] = getDateNoTime(data[8][i]);
            }
            for (int i = 0; i < data[9].Count; i++)
            {
                data[9][i] = getDateNoTime(data[9][i]);
            }
        }
        private string getDateNoTime(string data)
        {
            string newData = "";
            for (int i = 0; i < 10; i++)
            {
                newData += data[i];
            }
            return newData;
        }
        private string tournamentParserByDate(DateTime lhs, DateTime rhs)
        {
            DateTime thisDay = DateTime.Now;

            if (thisDay < lhs)
                return "Future";

            else if (thisDay > rhs)
                return "Last";

            else
                return "Now";


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

        #region -- Прорисовка окон для информации --

        public void getSizePicBox(PictureBox content)
        {
            this.X = content.Size.Width;
            this.Y = content.Size.Height;
        }
        public void getSizePicBoxIfChanged(PictureBox content)
        {
            this.newX = content.Size.Width;
            this.newY = content.Size.Height;

            getMultipliers();
        }

        private void getMultipliers()
        {
            multiplierX = newX / X;
            multiplierY = newY / Y;
        }

        public void drawLabels (PictureBox content)
        {
            int newPointX = 0, newPointY =  Convert.ToInt32( normY * multiplierY + spaceY);
            for (int i = 0; i < data[0].Count; i++)
            { 
                if ((newPointY + Convert.ToInt32(2 * (normY * multiplierY + spaceY))) < newY)
                    {
                    Label tourName = new Label();
                    tourName.Location = new Point(newPointX, newPointY);
                    tourName.AutoSize = false;
                    tourName.Size = new Size(Convert.ToInt32(sizeX[0] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                    tourName.BackColor = backColor;
                    tourName.ForeColor = foreColor;
                    tourName.Font = font();
                    content.Controls.Add(tourName);
                    newPointX += Convert.ToInt32(sizeX[0] * normX * multiplierX + spaceX);
                    contentLabels[0].Add(tourName);

                    Label stat = new Label();
                    stat.Location = new Point(newPointX, newPointY);
                    stat.AutoSize = false;
                    stat.Size = new Size(Convert.ToInt32(sizeX[1] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                    stat.BackColor = backColor;
                    stat.ForeColor = foreColor;
                    stat.Font = font();
                    content.Controls.Add(stat);
                    newPointX += Convert.ToInt32(sizeX[1] * normX * multiplierX + spaceX);
                    contentLabels[1].Add(stat);

                    Label city = new Label();
                    city.Location = new Point(newPointX, newPointY);
                    city.AutoSize = false;
                    city.Size = new Size(Convert.ToInt32(sizeX[2] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                    city.BackColor = backColor;
                    city.ForeColor = foreColor;
                    city.Font = font();
                    content.Controls.Add(city);
                    newPointX += Convert.ToInt32(sizeX[2] * normX * multiplierX + spaceX);
                    contentLabels[2].Add(city);



                    Button URL = new Button();
                    URL.Location = new Point(newPointX, newPointY);
                    URL.AutoSize = false;
                    URL.Size = new Size(Convert.ToInt32(sizeY * normY * multiplierY), Convert.ToInt32(sizeY * normY * multiplierY)); // TODO
                    content.Controls.Add(URL);
                    URL.Click += new EventHandler(URLButtonClick);
                    newPointX += Convert.ToInt32(sizeY * normY * multiplierY + spaceX);
                    URL.Name = data[0][i];
                    contentButtons.Add(URL);

                    void URLButtonClick(object sender, EventArgs e)
                    {
                        string name = (sender as Button).Name;
                        for (int k = 0; k < data[0].Count; k++)
                            if (data[0][k] == name && data[3][k] != " . . . ")
                                Process.Start("IExplore.exe", data[3][k]);
                    }

                    Button stream = new Button();
                    stream.Location = new Point(newPointX, newPointY);
                    stream.AutoSize = false;
                    stream.Size = new Size(Convert.ToInt32(sizeY * normY * multiplierY), Convert.ToInt32(sizeY * normY * multiplierY)); // TODO
                    content.Controls.Add(stream);
                    stream.Click += new EventHandler(streamButtonClick);
                    newPointX += Convert.ToInt32(sizeY * normY * multiplierY + spaceX);
                    stream.Name = data[0][i];
                    contentButtons.Add(stream);

                    void streamButtonClick(object sender, EventArgs e)
                    {
                        string name = (sender as Button).Name;
                        for (int k = 0; k < data[0].Count; k++)
                            if (data[0][k] == name && data[4][k] != " . . . ")
                                Process.Start("IExplore.exe", data[4][k]);
                    }

                    Label winner = new Label();
                    winner.Location = new Point(newPointX, newPointY);
                    winner.AutoSize = false;
                    winner.Size = new Size(Convert.ToInt32(sizeX[5] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                    winner.BackColor = backColor;
                    winner.ForeColor = foreColor;
                    winner.Font = font();
                    content.Controls.Add(winner);
                    newPointX += Convert.ToInt32(sizeX[5] * normX * multiplierX + spaceX);
                    contentLabels[5].Add(winner);

                    Label secPlace = new Label();
                    secPlace.Location = new Point(newPointX, newPointY);
                    secPlace.AutoSize = false;
                    secPlace.Size = new Size(Convert.ToInt32(sizeX[6] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                    secPlace.BackColor = backColor;
                    secPlace.ForeColor = foreColor;
                    secPlace.Font = font();
                    content.Controls.Add(secPlace);
                    newPointX += Convert.ToInt32(sizeX[6] * normX * multiplierX + spaceX);
                    contentLabels[6].Add(secPlace);

                    Label thirdPlace = new Label();
                    thirdPlace.Location = new Point(newPointX, newPointY);
                    thirdPlace.AutoSize = false;
                    thirdPlace.Size = new Size(Convert.ToInt32(sizeX[7] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                    thirdPlace.BackColor = backColor;
                    thirdPlace.ForeColor = foreColor;
                    thirdPlace.Font = font();
                    content.Controls.Add(thirdPlace);
                    newPointX += Convert.ToInt32(sizeX[7] * normX * multiplierX + spaceX);
                    contentLabels[7].Add(thirdPlace);

                    Label sDat = new Label();
                    sDat.Location = new Point(newPointX, newPointY);
                    sDat.AutoSize = false;
                    sDat.Size = new Size(Convert.ToInt32(sizeX[8] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                    sDat.BackColor = backColor;
                    sDat.ForeColor = foreColor;
                    sDat.Font = font();
                    content.Controls.Add(sDat);
                    newPointX += Convert.ToInt32(sizeX[8] * normX * multiplierX + spaceX);
                    contentLabels[8].Add(sDat);

                    Label end = new Label();
                    end.Location = new Point(newPointX, newPointY);
                    end.AutoSize = false;
                    end.Size = new Size(Convert.ToInt32(sizeX[9] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                    end.BackColor = backColor;
                    end.ForeColor = foreColor;
                    end.Font = font();
                    content.Controls.Add(end);
                    newPointX += Convert.ToInt32(sizeX[9] * normX * multiplierX + spaceX);
                    contentLabels[9].Add(end);

                    Label sponsor = new Label();
                    sponsor.Location = new Point(newPointX, newPointY);
                    sponsor.AutoSize = false;
                    sponsor.Size = new Size(Convert.ToInt32(sizeX[10] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                    sponsor.BackColor = backColor;
                    sponsor.ForeColor = foreColor;
                    sponsor.Font = font();
                    content.Controls.Add(sponsor);
                    newPointX += Convert.ToInt32(sizeX[10] * normX * multiplierX + spaceX);
                    contentLabels[10].Add(sponsor);

                    Label money = new Label();
                    money.Location = new Point(newPointX, newPointY);
                    money.AutoSize = false;
                    money.Size = new Size(Convert.ToInt32(sizeX[11] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                    money.BackColor = backColor;
                    money.ForeColor = foreColor;
                    money.Font = font();   
                    content.Controls.Add(money);
                    contentLabels[11].Add(money);

                    newPointY = Convert.ToInt32(newPointY + normY * multiplierY + spaceY);
                    newPointX = 0;
                }
            }
            fillData();
        }

        public void drawBorder(PictureBox content)
        {
            int newPointX = 0, newPointY = 0;

            if ((newPointY + Convert.ToInt32(2 * (normY * multiplierY + spaceY))) < newY)
            {
                Label tourName = new Label();
                tourName.Location = new Point(newPointX, newPointY);
                tourName.AutoSize = false;
                tourName.Size = new Size(Convert.ToInt32(sizeX[0] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                tourName.BackColor = backColor;
                tourName.ForeColor = foreColor;
                tourName.Font = font();
                content.Controls.Add(tourName);
                newPointX += Convert.ToInt32(sizeX[0] * normX * multiplierX + spaceX);
                borderLabel.Add(tourName);
                tourName.Text = "Название турнира";

                Label stat = new Label();
                stat.Location = new Point(newPointX, newPointY);
                stat.AutoSize = false;
                stat.Size = new Size(Convert.ToInt32(sizeX[1] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                stat.BackColor = backColor;
                stat.ForeColor = foreColor;
                stat.Font = font();
                content.Controls.Add(stat);
                newPointX += Convert.ToInt32(sizeX[1] * normX * multiplierX + spaceX);
                borderLabel.Add(stat);
                stat.Text = "Статус";

                Label city = new Label();
                city.Location = new Point(newPointX, newPointY);
                city.AutoSize = false;
                city.Size = new Size(Convert.ToInt32(sizeX[2] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                city.BackColor = backColor;
                city.ForeColor = foreColor;
                city.Font = font();
                content.Controls.Add(city);
                newPointX += Convert.ToInt32(sizeX[2] * normX * multiplierX + spaceX);
                borderLabel.Add(city);
                city.Text = "Город";

                if (data[0].Count != 0)
                {
                    Label URL = new Label();
                    URL.Location = new Point(newPointX, newPointY);
                    URL.AutoSize = false;
                    URL.Size = new Size(Convert.ToInt32(sizeY * normY * multiplierY), Convert.ToInt32(sizeY * normY * multiplierY));
                    URL.BackColor = backColor;
                    URL.ForeColor = foreColor;
                    URL.Font = font();
                    content.Controls.Add(URL);
                    newPointX += Convert.ToInt32(sizeY * normY * multiplierY + spaceX);
                    borderLabel.Add(URL);
                    URL.Text = "URL";

                    Label stream = new Label();
                    stream.Location = new Point(newPointX, newPointY);
                    stream.AutoSize = false;
                    stream.Size = new Size(Convert.ToInt32(sizeY * normY * multiplierY), Convert.ToInt32(sizeY * normY * multiplierY));
                    stream.BackColor = backColor;
                    stream.ForeColor = foreColor;
                    stream.Font = font();
                    content.Controls.Add(stream);
                    newPointX += Convert.ToInt32(sizeY * normY * multiplierY + spaceX);
                    borderLabel.Add(stream);
                    stream.Text = "Stream";

                }
                


                Label winner = new Label();
                winner.Location = new Point(newPointX, newPointY);
                winner.AutoSize = false;
                winner.Size = new Size(Convert.ToInt32(sizeX[5] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                winner.BackColor = backColor;
                winner.ForeColor = foreColor;
                winner.Font = font();
                content.Controls.Add(winner);
                newPointX += Convert.ToInt32(sizeX[5] * normX * multiplierX + spaceX);
                borderLabel.Add(winner);
                winner.Text = "Победитель";

                Label secPlace = new Label();
                secPlace.Location = new Point(newPointX, newPointY);
                secPlace.AutoSize = false;
                secPlace.Size = new Size(Convert.ToInt32(sizeX[6] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                secPlace.BackColor = backColor;
                secPlace.ForeColor = foreColor;
                secPlace.Font = font();
                content.Controls.Add(secPlace);
                newPointX += Convert.ToInt32(sizeX[6] * normX * multiplierX + spaceX);
                borderLabel.Add(secPlace);
                secPlace.Text = "2-е место";

                Label thirdPlace = new Label();
                thirdPlace.Location = new Point(newPointX, newPointY);
                thirdPlace.AutoSize = false;
                thirdPlace.Size = new Size(Convert.ToInt32(sizeX[7] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                thirdPlace.BackColor = backColor;
                thirdPlace.ForeColor = foreColor;
                thirdPlace.Font = font();
                content.Controls.Add(thirdPlace);
                newPointX += Convert.ToInt32(sizeX[7] * normX * multiplierX + spaceX);
                borderLabel.Add(thirdPlace);
                thirdPlace.Text = "3-е место";

                Label sDat = new Label();
                sDat.Location = new Point(newPointX, newPointY);
                sDat.AutoSize = false;
                sDat.Size = new Size(Convert.ToInt32(sizeX[8] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                sDat.BackColor = backColor;
                sDat.ForeColor = foreColor;
                sDat.Font = font();
                content.Controls.Add(sDat);
                newPointX += Convert.ToInt32(sizeX[8] * normX * multiplierX + spaceX);
                borderLabel.Add(sDat);
                sDat.Text = "Дата начала";

                Label end = new Label();
                end.Location = new Point(newPointX, newPointY);
                end.AutoSize = false;
                end.Size = new Size(Convert.ToInt32(sizeX[9] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                end.BackColor = backColor;
                end.ForeColor = foreColor;
                end.Font = font();
                content.Controls.Add(end);
                newPointX += Convert.ToInt32(sizeX[9] * normX * multiplierX + spaceX);
                borderLabel.Add(end);
                end.Text = "Дата окончания";

                Label sponsor = new Label();
                sponsor.Location = new Point(newPointX, newPointY);
                sponsor.AutoSize = false;
                sponsor.Size = new Size(Convert.ToInt32(sizeX[10] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                sponsor.BackColor = backColor;
                sponsor.ForeColor = foreColor;
                sponsor.Font = font();
                content.Controls.Add(sponsor);
                newPointX += Convert.ToInt32(sizeX[10] * normX * multiplierX + spaceX);
                borderLabel.Add(sponsor);
                sponsor.Text = "Спонсор";

                Label money = new Label();
                money.Location = new Point(newPointX, newPointY);
                money.AutoSize = false;
                money.Size = new Size(Convert.ToInt32(sizeX[11] * normX * multiplierX), Convert.ToInt32(sizeY * normY * multiplierY));
                money.BackColor = backColor;
                money.ForeColor = foreColor;
                money.Font = font();   
                content.Controls.Add(money);
                borderLabel.Add(money);
                money.Text = "Призовой фонд";
            }
        }

        private void getSizeOfStrinds ()
        {
            for (int i = 0; i < data.Count; i++)
            {
                string temp = "";
                for (int j = 0; j < data[i].Count; j++)
                {
                    if (temp.Length < data[i][j].Length)
                    {
                        temp = data[i][j];
                    }
                }
                sizeX.Add(temp.Length);
            }     
        }
        
        private void getTotalWigth ()
        {
            nowX = ( sizeX[0] * normX * multiplierX + spaceX +
                sizeX[1] * normX * multiplierX + spaceX +
                sizeX[2] * normX * multiplierX + spaceX +
                (sizeY * normY * multiplierY + spaceX) * 2 +
                sizeX[5] * normX * multiplierX + spaceX +
                sizeX[6] * normX * multiplierX + spaceX +
                sizeX[7] * normX * multiplierX + spaceX +
                sizeX[8] * normX * multiplierX + spaceX +
                sizeX[9] * normX * multiplierX + spaceX +
                sizeX[10] * normX * multiplierX + spaceX +
                sizeX[11] * normX * multiplierX + spaceX);

        }
        
        public void ifTotalWidthMoreThanPictureBox ()
        {
            if (newX < nowX)
            {
                multiplierX = newX / nowX;
            }
            else
            {
                multiplierX = newX / nowX;
            }
        }
        
        public void killLabels ()
        {
            foreach (Label b in borderLabel)
            {
                b.Dispose();
            }

            foreach (Button b in contentButtons)
            {
                b.Dispose();
            }

            foreach (List<Label> l in contentLabels)
            {
                foreach (Label b in l)
                {
                    b.Dispose();
                    
                }
                l.Clear();
            }
           
        }




        #endregion

        #region -- Заполнение окон информацией --

        private void fillData ()
        {
            for (int j = 0; j < contentLabels.Count; j++)
            {
                for (int i = 0; i < contentLabels[0].Count; i++)
                {

                    if (contentLabels[j].Count != 0)
                    {
                        contentLabels[j][i].Text = data[j][i];
                    }


                }
            }
        }



        #endregion

        #region -- Кнопки --

        int count = 0, check;

        public void top ()
        {
            if (data[0].Count > contentLabels[0].Count)
            {
                check = 0;
                //------------------------------------------------ проверяем является ли содержимое верхней строки лейблов первой строке иформации
                // можно ли двигаться наверх
                if (data[0].Count != 0)
                {
                    for (int j = 0; j < contentLabels.Count; j++)
                    {
                        if (contentLabels[j].Count != 0)
                        {
                            if (contentLabels[j][0].Text == data[j][0])
                            {
                                check++;
                            }
                        }
                    }
                }
                //------------------------------------------------
                if (check != 10)
                {
                    count--;
                }
                for (int j = 0; j < contentLabels.Count; j++)
                {
                    for (int i = 0; i < contentLabels[0].Count; i++)
                    {
                        if (data[0].Count > contentLabels[0].Count) // если строк отображено меньше чем есть строк информации
                        {
                            if (contentLabels[j].Count != 0)
                            {
                                if (data[j].Count > i + count)
                                    contentLabels[j][i].Text = data[j][i + count];
                            }
                        }
                    }
                }
            }
        }

        public void bottom ()
        {
            if (data[0].Count > contentLabels[0].Count)
            {
                check = 0;
                // можно ли двигаться вниз
                if (data[0].Count != 0)
                {
                    for (int j = 0; j < contentLabels.Count; j++)
                    {
                        if (contentLabels[j].Count != 0)
                        {
                            if (contentLabels[j][contentLabels[0].Count - 1].Text == data[j][data[0].Count - 1])
                            {
                                check++;
                            }
                        }
                    }
                }
                if (check != 10)
                {
                    count++;
                }
                //------------------------------------------------

                for (int j = 0; j < contentLabels.Count; j++)
                {
                    for (int i = 0; i < contentLabels[0].Count; i++)
                    {
                        //if (data[0].Count > contentLabels[0].Count) // если строк отображено меньше чем есть строк информации
                        {
                            if (contentLabels[j].Count != 0)
                            {
                                if (data[j].Count > i + count)
                                    contentLabels[j][i].Text = data[j][i + count];
                            }
                        }
                    }
                }
            }
        }


        #endregion

    }
}
