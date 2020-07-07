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
    public partial class TeamThis3 : Form
    {
        public TeamThis3(string team, string discipline)
        {
            InitializeComponent();
            label1.Text = discipline;
            label2.Text = team;
        }

        private void statButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
