using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHWithDB
{
    public partial class Form2 : Form
    {
        Form parentForm;
        string discipline;
        int numOfPlayers;
        public Form2(string discipline, Form parentForm, int numOfPlayers)
        {
            this.numOfPlayers = numOfPlayers;
            InitializeComponent();
            statSubMenu.Visible = false;
            this.parentForm = parentForm;
            this.discipline = discipline;

            loadImage(discipline);

            //childContent.Image = Pictures.setStartPict(discipline);
        }
        private void loadImage(string discipline)
        {
            childContent.Image = Pictures.setStartPict(discipline);
        }

        private void hideSubMenu()
        {
            statSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childContent.Controls.Add(childForm);
            childContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void statButton_Click_1(object sender, EventArgs e)
        {
            showSubMenu(statSubMenu);
        }

        private void lastStatButton_Click(object sender, EventArgs e)
        {
           
            openChildForm(new LastStat(discipline, panel5));
        }

        private void nowStatButton_Click(object sender, EventArgs e)
        {
            openChildForm(new NowStat(discipline, panel5));
        }

        private void futureStatButton_Click(object sender, EventArgs e)
        {
            openChildForm(new FutureStat(discipline, panel5));
        }

        private void comandsButton_Click(object sender, EventArgs e)
        {
            openChildForm(new Teams(discipline, panel5));
        }

        private void playersButton_Click(object sender, EventArgs e)
        {
            openChildForm(new Players(discipline, panel5, numOfPlayers));
        }

        private void newRequestButton_Click(object sender, EventArgs e)
        {
            openChildForm(new NewRequest(pictureBox1, discipline));
        }

        private void helpButton_Click(object sender, EventArgs e)  //TODO
        {
            MessageBox.Show("О приложении \n" +
                "Данное приложение разработано в 2020г. \n" +
                "с использованием С#, VisualStudio, Windows Forms");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            parentForm.Show();
        }
    }
}
