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
    public partial class LastStat : Form
    {
        StatisticsUtils ut;

        string discipline;
        string sql = "SELECT * FROM tournamentinfo;";
        string period = "Last";
        Panel panel;
        int X = 0;
        int newX = 0;

        public LastStat(string discipline, Panel panel)
        {
            ut = new StatisticsUtils();
            ut.getData(sql, discipline, period, panel);

            this.discipline = discipline;
            this.panel = panel;

            InitializeComponent();

            pictureBox1.Image = Pictures.setPict(discipline);


            ut.getSizePicBox(pictureBox1); // начальный размер экрана

            X = pictureBox1.Size.Width;


        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            newX = pictureBox1.Size.Width;
            ut.killLabels();
            ut.getSizePicBoxIfChanged(pictureBox1); // измененный
            ut.ifTotalWidthMoreThanPictureBox();
            ut.drawBorder(pictureBox1);
            ut.drawLabels(pictureBox1);
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            ut.top();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            
            ut.bottom();
        }
    }

}
