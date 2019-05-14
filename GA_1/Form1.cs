using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GA_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            panel2.Hide();
        }

        #region "Main menu"

        private void button1_Click(object sender, EventArgs e)
        {
            //panel1.Hide();
            panel2.Show();
            panelHUD.Hide();
        }

        private void bContinueOldGame_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void label2_Click(object sender, EventArgs e)
        {

        }

        #region "Player related functions"

        void setPlayerHealth(int _Value)
        {
            if (_Value == 1)
            {
                picturebox_heart1.Show();
                picturebox_heart2.Hide();
                picturebox_heart3.Hide();
                picturebox_heart4.Hide();
                picturebox_heart5.Hide();
            }
            else if (_Value == 2)
            {
                picturebox_heart1.Show();
                picturebox_heart2.Show();
                picturebox_heart3.Hide();
                picturebox_heart4.Hide();
                picturebox_heart5.Hide();
            }
            else if (_Value == 3)
            {
                picturebox_heart1.Show();
                picturebox_heart2.Show();
                picturebox_heart3.Show();
                picturebox_heart4.Hide();
                picturebox_heart5.Hide();
            }
            else if (_Value == 4)
            {
                picturebox_heart1.Show();
                picturebox_heart2.Show();
                picturebox_heart3.Show();
                picturebox_heart4.Show();
                picturebox_heart5.Hide();
            }
            else if (_Value == 5)
            {
                picturebox_heart1.Show();
                picturebox_heart2.Show();
                picturebox_heart3.Show();
                picturebox_heart4.Show();
                picturebox_heart5.Show();
            }
        }

        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button_cMedikas_Click(object sender, EventArgs e)
        {

        }

        private void button_cPolicininkas_Click(object sender, EventArgs e)
        {

        }

        private void button_cGaisrininkas_Click(object sender, EventArgs e)
        {

        }
    }
}
