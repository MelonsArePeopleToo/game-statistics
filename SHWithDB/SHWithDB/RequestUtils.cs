using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHWithDB
{
    class RequestUtils
    {
        PictureBox panel;
        Dictionary<string, int> data;
        string discipline;
        int counter = 0;

        public RequestUtils(PictureBox panel, string discipline)
        {
            this.panel = panel;
            data = new Dictionary<string, int>();
            this.discipline = discipline;
        }

        public void getConn(string sql)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            try
            {
                if (data.Count == 0)
                {
                    getSqlData(sql, conn);
                }
                else
                {
                    getAnotherSqlData(sql, conn);
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
        private void getAnotherSqlData(string sql, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            DbDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    if (id > counter)
                        counter = id;
                }
            }
        }


        private void createTextBoxIfException(PictureBox content, string mess)
        {
            TextBox tb = new TextBox();
            tb.Location = new Point(0, 0);
            tb.Size = new Size(100, 30);
            content.Controls.Add(tb);
            tb.Text = mess;
        }

        private void getSqlData(string sql, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            DbDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int type = reader.GetInt32(3);
                    DateTime date = reader.GetDateTime(4);
                    string str = reader.GetString(1);
                    int id = reader.GetInt32(0);
                    string strDis = reader.GetString(2);

                    if (tournamentParserByDate(date) == "Future")
                    {
                        if (type == 1 || type == 4) // 1 || 2
                        {
                            if (strDis == discipline)
                            {
                                data.Add(str, id);
                            }
                           
                        }
                    }
                }
            }
        }

        private string tournamentParserByDate(DateTime lhs)
        {
            DateTime thisDay = DateTime.Now;

            if (thisDay < lhs)
                return "Future";
            else
                return "kek";
        }

        public void fillComboBox(ComboBox cb)
        {
            foreach (KeyValuePair<string, int> s in data)
            {
                cb.Items.Add(s.Key);
            }
        }

        public void buttonClc(ComboBox cb, TextBox tb, TextBox tb1, TextBox tb2, TextBox tb3, TextBox tb4, TextBox tb5, TextBox tb6, TextBox tb7, TextBox tb8)
        {

            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                string sql = "Insert into esport.new_zayavka (newid ,newteamname, capitan, player2, player3, player4, player5, player6, player7, mailcapitana, status_zayavki_idstatus_zayavki, tournament_idtournament) "
                            + " values (@o,@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k) ";

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                cmd.Parameters.Add("@o", MySqlDbType.Int32).Value = counter + 1;
                counter++;
                cmd.Parameters.Add("@a", MySqlDbType.VarChar).Value = tb.Text;
                cmd.Parameters.Add("@b", MySqlDbType.VarChar).Value = tb1.Text;
                cmd.Parameters.Add("@c", MySqlDbType.VarChar).Value = tb2.Text;
                cmd.Parameters.Add("@d", MySqlDbType.VarChar).Value = tb3.Text;
                cmd.Parameters.Add("@e", MySqlDbType.VarChar).Value = tb4.Text;
                cmd.Parameters.Add("@f", MySqlDbType.VarChar).Value = tb5.Text;
                cmd.Parameters.Add("@g", MySqlDbType.VarChar).Value = tb6.Text;
                cmd.Parameters.Add("@h", MySqlDbType.VarChar).Value = tb7.Text;
                cmd.Parameters.Add("@i", MySqlDbType.VarChar).Value = tb8.Text;
                cmd.Parameters.Add("@j", MySqlDbType.Int32).Value = 3;
                cmd.Parameters.Add("@k", MySqlDbType.Int32).Value = data[cb.Text];

                cmd.ExecuteNonQuery();
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
    }

}
