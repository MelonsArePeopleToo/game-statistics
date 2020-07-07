using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHWithDB
{
    public partial class Players : Form
    {
        private const int iconSize = 120;
        PlayersUtils pu;
        string sql = "SELECT * FROM playerinfo;";

        public Players(string discipline, Panel panel, int numOfPlayers  )
        {
            InitializeComponent();

            pu = new PlayersUtils(iconSize, sql, discipline, panel);

            pu.getData();

            pictureBox1.Image = Pictures.setPict(discipline);
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            pu.killIcons();
            pu.getSize(pictureBox1);
            pu.drawIcons(pictureBox1);
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            pu.left();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            pu.right();
        }
    }
}
