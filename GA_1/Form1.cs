using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GA_1
{
    public partial class Form1 : Form
    {
        Character _Character = new Character();
        Treasure _Treasure = new Treasure();
        gameConfig _CFG = new gameConfig();

        public Form1()
        {
            InitializeComponent();

            panel2.Hide();

            //KAINU NUSTATYMAI SHOPUJ
            label_deagle_price.Text = "Kaina: " + _CFG.SHOP_DEAGLE_PRICE.ToString();
            label_smg_price.Text = "Kaina: " + _CFG.SHOP_SMG_PRICE.ToString();
            label_ak_price.Text = "Kaina: " + _CFG.SHOP_AK47_PRICE.ToString();
            label_minigun_price.Text = "Kaina: " + _CFG.SHOP_MINIGUN_PRICE.ToString();
            label_bazooka_price.Text = "Kaina: " + _CFG.SHOP_BAZOOKA_PRICE.ToString();
            label_ammo_price.Text = "Kaina: " + _CFG.SHOP_AMMO_PRICE.ToString();

            label7.Text = "Turi:\n• Vaistinėlę\n• Peilį";
            label8.Text = "Turi:\n• Bananą";
            label9.Text = "Turi:\n• Kirvį";
        }

        #region "Main menu"

        private void button1_Click(object sender, EventArgs e)
        {
            //panel1.Hide();
            panel_Map.Hide();
            panelHUD.Hide();
            panel_city.Hide();
            panel_shop.Hide();
            panel2.Show();
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
            _Character.Health = _Value;
        }

        #endregion

        #region "Player stats update"

        void zombieClick()
        {
            new ToolTip().Show("Nužudžiau zombį! Įgavau +" + _CFG.EXPERIENCE_ZOMBIE_CLICK + " patirties!\nRadau " + _CFG.MONEY_ZOMBIE_CLICK + " aukso!", pictureBox_city_character, 2000);
            _Character.Experience += _CFG.EXPERIENCE_ZOMBIE_CLICK;
            _Character.Money += _CFG.MONEY_ZOMBIE_CLICK;
            label_gold.Text = _Character.Money.ToString();
        }

        void carClick()
        {
            new ToolTip().Show("Apvogiau mašiną! Įgavau +" + _CFG.EXPERIENCE_CAR_CLICK + " patirties!\nRadau " + _CFG.MONEY_CAR_CLICK + " aukso!", pictureBox_city_character, 2000);
            _Character.Money += _CFG.EXPERIENCE_CAR_CLICK;
            _Character.Experience += _CFG.EXPERIENCE_CAR_CLICK;
            label_gold.Text = _Character.Money.ToString();
        }

        #endregion



        private void button1_Click_1(object sender, EventArgs e)
        {
            _Character.charID = 0;
            _Character.hasGlock = true;
            _Character.hasKnife = true;
            _Character.currentlyEqquiped = 0;

            pictureBox_mapChar.Image = GA_1.Properties.Resources.vagis2;
            pictureBox_city_character.Image = GA_1.Properties.Resources.vagis2;
            panel_Map.Show();
        }

        private void button_cMedikas_Click(object sender, EventArgs e)
        {
            _Character.charID = 1;
            _Character.healthPack = 1;
            _Character.hasKnife = true;
            _Character.currentlyEqquiped = 0;

            pictureBox_mapChar.Image = GA_1.Properties.Resources.medikas;
            pictureBox_city_character.Image = GA_1.Properties.Resources.medikas;
            panel_Map.Show();
        }

        private void button_cPolicininkas_Click(object sender, EventArgs e)
        {
            _Character.charID = 2;
            _Character.hasBat = true;

            pictureBox_mapChar.Image = GA_1.Properties.Resources.policija;
            pictureBox_city_character.Image = GA_1.Properties.Resources.policija;
            panel_Map.Show();
        }

        private void button_cGaisrininkas_Click(object sender, EventArgs e)
        {
            _Character.charID = 3;
            _Character.hasAxe = true;

            pictureBox_mapChar.Image = GA_1.Properties.Resources.ugniagesys;
            pictureBox_city_character.Image = GA_1.Properties.Resources.ugniagesys;
            panel_Map.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Miesto pictureboxas virsuj desinej
            pictureBox_car1.Hide();
            pictureBox_car2.Hide();
            pictureBox_car3.Hide();

            pictureBox_zombie1.Hide();
            pictureBox_zombie2.Hide();
            pictureBox_zombie3.Hide();
            pictureBox_zombie4.Hide();

            progressBar1.Hide();
            progressBar2.Hide();
            progressBar3.Hide();
            progressBar4.Hide();

            pictureBox_supplycrate.Hide();

            var Lock_1 = new Random(DateTime.Now.Millisecond).Next(0, 3);
            Thread.Sleep(10);

            if (Lock_1 == 1)
            {
                int[] CAR_APPEAR_CHANCE = new int[3];
                Point[] CAR_POS = new Point[3];

                for (int i = 0; i < 3; i++)
                {
                    CAR_APPEAR_CHANCE[i] = new Random(DateTime.Now.Millisecond).Next(0, 3);
                    Thread.Sleep(10);
                    CAR_POS[i] = new Point(new Random(DateTime.Now.Millisecond).Next(46, 681), 526);
                    Thread.Sleep(10);
                }

                if (CAR_APPEAR_CHANCE[0] == 0)
                {
                    pictureBox_car1.Location = CAR_POS[0];
                    pictureBox_car1.Show();
                }
                if (CAR_APPEAR_CHANCE[1] == 0)
                {
                    pictureBox_car2.Location = CAR_POS[1];
                    pictureBox_car2.Show();
                }
                if (CAR_APPEAR_CHANCE[2] == 0)
                {
                    pictureBox_car3.Location = CAR_POS[2];
                    pictureBox_car3.Show();
                }
            }



            //Šansai, kad dėžė iškris maži turi būt
            int[] BOX_APPEAR_CHANCE = new int[2];

            for (int i = 0; i < 2; i++)
            {
                BOX_APPEAR_CHANCE[i] = new Random(DateTime.Now.Millisecond).Next(0, 3);
                Thread.Sleep(10);
            }

            if (BOX_APPEAR_CHANCE[0] == BOX_APPEAR_CHANCE[1])
            {
                pictureBox_supplycrate.Location = new Point(new Random(DateTime.Now.Millisecond).Next(46, 681), 526); //Kaip ir bmw išmėtom
                pictureBox_supplycrate.Show();
            }



            //Spawninam zombius
            int[] ZOMBIE_APPEAR_CHANCE = new int[4];
            Point[] ZOMBIE_POS = new Point[4];

            for (int i = 0; i < 4; i++)
            {
                ZOMBIE_APPEAR_CHANCE[i] = new Random(DateTime.Now.Millisecond).Next(0, 2);
                Thread.Sleep(10);
                ZOMBIE_POS[i] = new Point(new Random(DateTime.Now.Millisecond).Next(46, 681), 526);
                Thread.Sleep(10);
            }

            if (ZOMBIE_APPEAR_CHANCE[0] == 0)
            {
                pictureBox_zombie1.Location = ZOMBIE_POS[0];
                progressBar1.Location = new Point(ZOMBIE_POS[0].X, 42);
                pictureBox_zombie1.Show();
            }
            if (ZOMBIE_APPEAR_CHANCE[1] == 1)
            {
                pictureBox_zombie2.Location = ZOMBIE_POS[1];
                progressBar1.Location = new Point(ZOMBIE_POS[0].X, 42);
                pictureBox_zombie2.Show();
            }
            if (ZOMBIE_APPEAR_CHANCE[2] == 0)
            {
                pictureBox_zombie3.Location = ZOMBIE_POS[2];
                progressBar1.Location = new Point(ZOMBIE_POS[0].X, 42);
                pictureBox_zombie3.Show();
            }
            if (ZOMBIE_APPEAR_CHANCE[3] == 1)
            {
                pictureBox_zombie4.Location = ZOMBIE_POS[3];
                progressBar1.Location = new Point(ZOMBIE_POS[0].X, 42);
                pictureBox_zombie4.Show();
            }

            //Pasiruošę rodyt miestą
            panel_city.Show();
            panelHUD.Show();

            new ToolTip().Show("Aš čia!", pictureBox_city_character, 2000);
        }

        private void pictureBox_car1_Click(object sender, EventArgs e)
        {
            carClick();
            pictureBox_car1.Hide();
        }

        private void pictureBox_car2_Click(object sender, EventArgs e)
        {
            carClick();
            pictureBox_car2.Hide();
        }

        private void pictureBox_car3_Click(object sender, EventArgs e)
        {
            carClick();
            pictureBox_car3.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Supply crate picbox
            int itemid = new Random(DateTime.Now.Millisecond).Next(0, 9);

            string tName = _Treasure.Treasures[itemid];

            if (itemid == 0)
                _Character.hasDeagle = true;
            else if (itemid == 1)
                _Character.hasSMG = true;
            else if (itemid == 2)
                _Character.hasAK47 = true;
            else if (itemid == 3)
                _Character.hasMinigun = true;
            else if (itemid == 4)
                _Character.hasBazooka = true;
            else if (itemid == 5)
                _Character.Ammo += _CFG.AMMO_BOX_CLICK;
            else if (itemid == 6)
                _Character.Money += _CFG.MONEY_BOX_CLICK;
            else if (itemid == 7)
                _Character.Experience += _CFG.EXPERIENCE_BOX_CLICK;
            else if (itemid == 8)
                _Character.healthPack += _CFG.HEALTHPACK_BOX_CLICK;

            new ToolTip().Show("Oho! Reta dėžė! Radau " + tName + "!", pictureBox_city_character, 2000);

            label_ammo.Text = _Character.Ammo.ToString();

            pictureBox_supplycrate.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            //Atgal į slėptuvę
            panelHUD.Hide();
            panel_city.Hide();
        }

        private void pictureBox_city_character_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_zombie1_Click(object sender, EventArgs e)
        {
            zombieClick();
            pictureBox_zombie1.Hide();
        }

        private void pictureBox_zombie2_Click(object sender, EventArgs e)
        {
            zombieClick();
            pictureBox_zombie2.Hide();
        }

        private void pictureBox_zombie3_Click(object sender, EventArgs e)
        {
            zombieClick();
            pictureBox_zombie3.Hide();
        }

        private void pictureBox_zombie4_Click(object sender, EventArgs e)
        {
            zombieClick();
            pictureBox_zombie4.Hide();
        }

        private void pictureBox_mapChar_Click(object sender, EventArgs e)
        {
            //for (int y = pictureBox_mapChar.Location.Y; y < pictureBox_city.Location.Y; y++)
            //{
            //    for (int x = pictureBox_mapChar.Location.X; x < pictureBox_city.Location.X; x++)
            //    {
            //        pictureBox_mapChar.Location = new Point(x, y);
            //        Thread.Sleep(100);
            //    }
            //}

            panel_city.Show();
            panel_shop.Show();
            panel_inventory.Show();

            pictureBox_invnetory_knife.Hide();
            pictureBox_invnetory_baton.Hide();
            pictureBox_invnetory_axe.Hide();
            pictureBox_invnetory_glock.Hide();
            pictureBox_invnetory_deagle.Hide();
            pictureBox_invnetory_smg.Hide();
            pictureBox_invnetory_ak47.Hide();
            pictureBox_invnetory_minigun.Hide();
            pictureBox_invnetory_bazooka.Hide();
            pictureBox_invnetory_bloodpack.Hide();

            if (_Character.hasKnife)
                pictureBox_invnetory_knife.Show();
            if (_Character.hasBat)
                pictureBox_invnetory_baton.Show();
            if (_Character.hasAxe)
                pictureBox_invnetory_axe.Show();
            if (_Character.hasGlock)
                pictureBox_invnetory_glock.Show();
            if (_Character.hasDeagle)
                pictureBox_invnetory_deagle.Show();
            if (_Character.hasSMG)
                pictureBox_invnetory_smg.Show();
            if (_Character.hasAK47)
                pictureBox_invnetory_ak47.Show();
            if (_Character.hasMinigun)
                pictureBox_invnetory_minigun.Show();
            if (_Character.hasBazooka)
                pictureBox_invnetory_bazooka.Show();
            if (_Character.healthPack > 0)
                pictureBox_invnetory_bloodpack.Show();

        }

        private void pictureBox_shop_Click(object sender, EventArgs e)
        {
            panel_city.Show();
            panel_shop.Show();

            pictureBox_shop_gold.Show();
            label_shop_gold.Text = _Character.Money.ToString();
        }

        private void pictureBox_shopGOBACK_Click(object sender, EventArgs e)
        {
            panel_city.Hide();
            panel_shop.Hide();
            panel_Map.Show();
        }

        bool hasEnoughMoney(int Price)
        {
            if (_Character.Money < Price)
            {
                MessageBox.Show("Tau nepakanka aukso!");
                return false;
            }
            else
                return true;
        }

        void setPlayerMoney(int _Value)
        {
            _Character.Money = _Value;
            label_shop_gold.Text = _Character.Money.ToString();
            label_gold.Text = _Character.Money.ToString();
        }

        private void pictureBox_shop_deagle_Click(object sender, EventArgs e)
        {
            if (hasEnoughMoney(_CFG.SHOP_DEAGLE_PRICE))
            {
                MessageBox.Show("Sėkmingai nusipirkai Deagle!\nJį pradėti naudoti gali per inventorių!");
                setPlayerMoney(_Character.Money - _CFG.SHOP_DEAGLE_PRICE);
                _Character.hasDeagle = true;
            }
        }

        private void pictureBox_shop_smg_Click(object sender, EventArgs e)
        {
            if (hasEnoughMoney(_CFG.SHOP_SMG_PRICE))
            {
                MessageBox.Show("Sėkmingai nusipirkai SMG!\nJį pradėti naudoti gali per inventorių!");
                setPlayerMoney(_Character.Money - _CFG.SHOP_SMG_PRICE);
                _Character.hasSMG = true;
            }
        }

        private void pictureBox_shop_ak47_Click(object sender, EventArgs e)
        {
            if(hasEnoughMoney(_CFG.SHOP_AK47_PRICE))
            {
                MessageBox.Show("Sėkmingai nusipirkai AK47!\nJį pradėti naudoti gali per inventorių!");
                setPlayerMoney(_Character.Money - _CFG.SHOP_AK47_PRICE);
                _Character.hasAK47 = true;
            }
        }

        private void pictureBox_shop_minigun_Click(object sender, EventArgs e)
        {
            if(hasEnoughMoney(_CFG.SHOP_MINIGUN_PRICE))
            {
                MessageBox.Show("Sėkmingai nusipirkai Minigun!\nJį pradėti naudoti gali per inventorių!");
                setPlayerMoney(_Character.Money - _CFG.SHOP_MINIGUN_PRICE);
                _Character.hasMinigun = true;
            }
        }

        private void pictureBox_shop_bazooka_Click(object sender, EventArgs e)
        {
            if(hasEnoughMoney(_CFG.SHOP_BAZOOKA_PRICE))
            {
                MessageBox.Show("Sėkmingai nusipirkai Bazooka!\nJį pradėti naudoti gali per inventorių!");
                setPlayerMoney(_Character.Money - _CFG.SHOP_BAZOOKA_PRICE);
                _Character.hasBazooka = true;
            }
        }

        private void pictureBox_shop_ammo_Click(object sender, EventArgs e)
        {
            if (hasEnoughMoney(_CFG.SHOP_AMMO_PRICE))
            {
                MessageBox.Show("Sėkmingai nusipirkai AMMO!");
                setPlayerMoney(_Character.Money - _CFG.SHOP_AMMO_PRICE);
                _Character.Ammo += 15;
            }
        }

        private void pictureBox_inventory_GOBACK_Click(object sender, EventArgs e)
        {
            panel_city.Hide();
            panel_shop.Hide();
            panel_inventory.Hide();
            panel_Map.Show();
        }

        void setInventoryPictureboxesBordersToNone()
        {
            pictureBox_invnetory_knife.BorderStyle = BorderStyle.None;
            pictureBox_invnetory_baton.BorderStyle = BorderStyle.None;
            pictureBox_invnetory_axe.BorderStyle = BorderStyle.None;
            pictureBox_invnetory_glock.BorderStyle = BorderStyle.None;
            pictureBox_invnetory_deagle.BorderStyle = BorderStyle.None;
            pictureBox_invnetory_smg.BorderStyle = BorderStyle.None;
            pictureBox_invnetory_ak47.BorderStyle = BorderStyle.None;
            pictureBox_invnetory_bazooka.BorderStyle = BorderStyle.None;
            pictureBox_invnetory_bloodpack.BorderStyle = BorderStyle.None;
        }

        private void pictureBox_invnetory_knife_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_knife.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 0;
        }

        private void pictureBox_invnetory_baton_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_baton.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 1;
        }

        private void pictureBox_invnetory_axe_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_axe.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 2;
        }

        private void pictureBox_invnetory_glock_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_glock.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 3;
        }

        private void pictureBox_invnetory_deagle_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_deagle.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 4;
        }

        private void pictureBox_invnetory_smg_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_smg.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 5;
        }

        private void pictureBox_invnetory_ak47_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_ak47.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 6;
        }

        private void pictureBox_invnetory_minigun_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_minigun.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 7;
        }

        private void pictureBox_invnetory_bazooka_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_bazooka.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 8;
        }

        private void pictureBox_invnetory_bloodpack_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_bloodpack.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 9;
        }

        private void panel_city_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
