using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHWithDB
{
    public partial class Teams : Form
    {
        private const int iconSize = 200;
        TeamsUtils tpu;
        string sql = "SELECT * FROM teamByDiscipline;";
        

        public Teams(string discipline, Panel panel)
        {

            InitializeComponent();

            tpu = new TeamsUtils(iconSize, sql, discipline, panel);

            tpu.getData();

            pictureBox1.Image = Pictures.setPict(discipline);
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            tpu.killIcons();
            tpu.getSize(pictureBox1);
            tpu.drawIcons(pictureBox1);
        }


        private void leftButton_Click(object sender, EventArgs e)
        {
            tpu.left();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            tpu.right();
        }
    }
}
