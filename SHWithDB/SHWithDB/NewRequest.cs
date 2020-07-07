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
    public partial class NewRequest : Form
    {
        RequestUtils ut;

        string sql1 = "SELECT * FROM disc;",
            sql2 = "SELECT * FROM esport.new_zayavka;";


        public NewRequest(PictureBox panel, string discipline)
        {
            ut = new RequestUtils(panel, discipline);
            InitializeComponent();

            ut.getConn(sql1);
            ut.getConn(sql2);

            ut.fillComboBox(comboBox1);

            //pictureBox1.Image = Pictures.setStartPict(discipline);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ut.buttonClc(comboBox1, textBox1, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox2);
        }

    }
}
