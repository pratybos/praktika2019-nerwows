using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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

            resetFormElements();
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
            if (_Value == 0)
            {
                picturebox_heart1.Hide();
                picturebox_heart2.Hide();
                picturebox_heart3.Hide();
                picturebox_heart4.Hide();
                picturebox_heart5.Hide();
                gameEnd();
            }
            if (_Value == 1)
            {
                picturebox_heart1.Show();
                picturebox_heart2.Hide();
                picturebox_heart3.Hide();
                picturebox_heart4.Hide();
                picturebox_heart5.Hide();
                new ToolTip().Show("Man reikia nedelsiant pasigydyti, gal bėgam?!", pictureBox_city_character, 2000);
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

        void gameEnd()
        {
            MessageBox.Show("Jūsų žaidimas baigtas. Jūs mirėte. Jūsų statusai:" +
                "\n• Žaidėjo nickas:" + _Character.Name +
                "\n• Patirties taškai: " + _Character.Experience +
                "\n• Auksas: " + _Character.Money +
                "\n• Nužudyta zombių: " + _Character.killCount +
                "\n• Apvogta automobilių: " + _Character.carCount +
                "\n• Atidaryta dėžių: " + _Character.lootboxCount
                );

            Application.Exit();
        }

        #endregion

        #region "World update + Player update"

        void zombieClick()
        {
            new ToolTip().Show("Nužudžiau zombį! Įgavau +" + _CFG.EXPERIENCE_ZOMBIE_CLICK + " patirties!\nRadau " + _CFG.MONEY_ZOMBIE_CLICK + " aukso!", pictureBox_city_character, 2000);
            _Character.Experience += _CFG.EXPERIENCE_ZOMBIE_CLICK;
            _Character.Money += _CFG.MONEY_ZOMBIE_CLICK;
            _Character.killCount++;
            label_gold.Text = _Character.Money.ToString();
        }

        void carClick()
        {
            new ToolTip().Show("Apvogiau mašiną! Įgavau +" + _CFG.EXPERIENCE_CAR_CLICK + " patirties!\nRadau " + _CFG.MONEY_CAR_CLICK + " aukso!", pictureBox_city_character, 2000);
            _Character.Money += _CFG.EXPERIENCE_CAR_CLICK;
            _Character.Experience += _CFG.EXPERIENCE_CAR_CLICK;
            _Character.carCount++;
            label_gold.Text = _Character.Money.ToString();
        }

        void randomZombieHitMe()
        {
            if (new Random(DateTime.Now.Millisecond).Next(0, 2) == 1)
            {
                new ToolTip().Show("Auč, zombis mane sužalojo!", pictureBox_city_character, 2000);
                setPlayerHealth(_Character.Health - 1);
            }
        }

        #endregion

        void resetFormElements()
        {
            pictureBox_car1.Hide();
            pictureBox_car2.Hide();
            pictureBox_car3.Hide();

            pictureBox_zombie1.Hide();
            pictureBox_zombie2.Hide();
            pictureBox_zombie3.Hide();
            pictureBox_zombie4.Hide();

            pictureBox_fire1.Hide();
            pictureBox_fire2.Hide();
            pictureBox_fire3.Hide();
            pictureBox_fire4.Hide();

            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;
            progressBar1.Maximum = 100;
            progressBar2.Maximum = 100;
            progressBar3.Maximum = 100;
            progressBar4.Maximum = 100;
            progressBar1.Hide();
            progressBar2.Hide();
            progressBar3.Hide();
            progressBar4.Hide();

            pictureBox_supplycrate.Hide();

            panel_inventory.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _Character.charID = 0;
            _Character.hasGlock = true;
            _Character.hasKnife = true;
            _Character.currentlyEqquiped = 0;

            pictureBox_mapChar.Image = GA_1.Properties.Resources.vagis2;
            pictureBox_city_character.Image = GA_1.Properties.Resources.vagis2;
            panel_Map.Show();

            string input = Interaction.InputBox("Įveskite žaidėjo vardą:", "Žaidėjo vardas", DateTime.Now.ToLocalTime().ToString(), -1, -1);
            _Character.Name = input;
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

            string input = Interaction.InputBox("Įveskite žaidėjo vardą:", "Žaidėjo vardas", DateTime.Now.ToLocalTime().ToString(), -1, -1);
            _Character.Name = input;
        }

        private void button_cPolicininkas_Click(object sender, EventArgs e)
        {
            _Character.charID = 2;
            _Character.hasBat = true;
            _Character.currentlyEqquiped = 1;

            pictureBox_mapChar.Image = GA_1.Properties.Resources.policija;
            pictureBox_city_character.Image = GA_1.Properties.Resources.policija;
            panel_Map.Show();

            string input = Interaction.InputBox("Įveskite žaidėjo vardą:", "Žaidėjo vardas", DateTime.Now.ToLocalTime().ToString(), -1, -1);
            _Character.Name = input;
        }

        private void button_cGaisrininkas_Click(object sender, EventArgs e)
        {
            _Character.charID = 3;
            _Character.hasAxe = true;
            _Character.currentlyEqquiped = 2;

            pictureBox_mapChar.Image = GA_1.Properties.Resources.ugniagesys;
            pictureBox_city_character.Image = GA_1.Properties.Resources.ugniagesys;
            panel_Map.Show();

            string input = Interaction.InputBox("Įveskite žaidėjo vardą:", "Žaidėjo vardas", DateTime.Now.ToLocalTime().ToString(), -1, -1);
            _Character.Name = input;
        }


        int[] ZOMBIE_HEALTH = new int[4];
        Point[] ZOMBIE_POS = new Point[4];

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Miesto pictureboxas virsuj desinej
            resetFormElements();

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

            for (int i = 0; i < 4; i++)
            {
                ZOMBIE_APPEAR_CHANCE[i] = new Random(DateTime.Now.Millisecond).Next(0, 2);
                Thread.Sleep(10);
                ZOMBIE_POS[i] = new Point(new Random(DateTime.Now.Millisecond).Next(46, 681), 526);
                Thread.Sleep(10);
                ZOMBIE_HEALTH[i] = new Random(DateTime.Now.Millisecond).Next(3, 10);
                Thread.Sleep(10);
            }

            if (ZOMBIE_APPEAR_CHANCE[0] == 0)
            {
                pictureBox_zombie1.Location = ZOMBIE_POS[0];
                progressBar1.Location = new Point(ZOMBIE_POS[0].X, 502);
                pictureBox_zombie1.Show();
            }
            if (ZOMBIE_APPEAR_CHANCE[1] == 1)
            {
                pictureBox_zombie2.Location = ZOMBIE_POS[1];
                progressBar2.Location = new Point(ZOMBIE_POS[1].X, 502);
                pictureBox_zombie2.Show();
            }
            if (ZOMBIE_APPEAR_CHANCE[2] == 0)
            {
                pictureBox_zombie3.Location = ZOMBIE_POS[2];
                progressBar3.Location = new Point(ZOMBIE_POS[2].X, 502);
                pictureBox_zombie3.Show();
            }
            if (ZOMBIE_APPEAR_CHANCE[3] == 1)
            {
                pictureBox_zombie4.Location = ZOMBIE_POS[3];
                progressBar4.Location = new Point(ZOMBIE_POS[3].X, 502);
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
            {
                _Character.hasDeagle = true;
                pictureBox_shop_deagle.Enabled = false;
                pictureBox_shop_deagle.BackColor = Color.Green;
            }
            else if (itemid == 1)
            {
                _Character.hasSMG = true;
                pictureBox_shop_smg.Enabled = false;
                pictureBox_shop_smg.BackColor = Color.Green;
            }
            else if (itemid == 2)
            {
                _Character.hasAK47 = true;
                pictureBox_shop_ak47.Enabled = false;
                pictureBox_shop_ak47.BackColor = Color.Green;
            }
            else if (itemid == 3)
            {
                _Character.hasMinigun = true;
                pictureBox_shop_minigun.Enabled = false;
                pictureBox_shop_minigun.BackColor = Color.Green;
            }
            else if (itemid == 4)
            {
                _Character.hasBazooka = true;
                pictureBox_shop_bazooka.Enabled = false;
                pictureBox_shop_bazooka.BackColor = Color.Green;
            }
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

            _Character.lootboxCount++;
        }



        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            //Atgal į slėptuvę iš parduotuvės
            progressBar1.Hide();
            progressBar2.Hide();
            progressBar3.Hide();
            progressBar4.Hide();
            panelHUD.Hide();
            panel_city.Hide();
        }

        private void pictureBox_city_character_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_zombie1_Click(object sender, EventArgs e)
        {
            if (_Character.currentlyEqquiped == 0 || _Character.currentlyEqquiped == 1 || _Character.currentlyEqquiped == 2)
            {
                progressBar1.Show();
                progressBar1.Maximum = ZOMBIE_HEALTH[0];
                progressBar1.Value += 1;

                randomZombieHitMe();

                if (progressBar1.Maximum == progressBar1.Value)
                {
                    zombieClick();
                    pictureBox_zombie1.Hide();
                    progressBar1.Hide();
                }
            }
            else
            {
                if (_Character.Ammo > 0)
                {
                    setPlayerAmmo(_Character.Ammo - 1);
                    zombieClick();

                    if (_Character.currentlyEqquiped == 7 || _Character.currentlyEqquiped == 8)
                    {
                        pictureBox_fire1.Location = new Point(ZOMBIE_POS[0].X, ZOMBIE_POS[0].Y);
                        pictureBox_fire1.Show();
                    }

                    pictureBox_zombie1.Hide();
                }
                else
                    new ToolTip().Show("Man baigėsi kulkos!\nReikia grįžti į inventorių ir pasirinkti kitą ginklą arba gauti kulkų!", pictureBox_city_character, 2000);
            }
        }

        private void pictureBox_zombie2_Click(object sender, EventArgs e)
        {
            if (_Character.currentlyEqquiped == 0 || _Character.currentlyEqquiped == 1 || _Character.currentlyEqquiped == 2)
            {
                progressBar2.Show();
                progressBar2.Maximum = ZOMBIE_HEALTH[1];
                progressBar2.Value += 1;

                randomZombieHitMe();

                if (progressBar2.Maximum == progressBar2.Value)
                {
                    zombieClick();
                    pictureBox_zombie2.Hide();
                    progressBar2.Hide();
                }
            }
            else
            {
                if (_Character.Ammo > 0)
                {
                    setPlayerAmmo(_Character.Ammo - 1);
                    zombieClick();

                    if (_Character.currentlyEqquiped == 7 || _Character.currentlyEqquiped == 8)
                    {
                        pictureBox_fire2.Location = new Point(ZOMBIE_POS[1].X, ZOMBIE_POS[1].Y);
                        pictureBox_fire2.Show();
                    }

                    pictureBox_zombie2.Hide();
                }
                else
                    new ToolTip().Show("Man baigėsi kulkos!\nReikia grįžti į inventorių ir pasirinkti kitą ginklą arba gauti kulkų!", pictureBox_city_character, 2000);
            }
        }

        private void pictureBox_zombie3_Click(object sender, EventArgs e)
        {
            if (_Character.currentlyEqquiped == 0 || _Character.currentlyEqquiped == 1 || _Character.currentlyEqquiped == 2)
            {
                progressBar3.Show();
                progressBar3.Maximum = ZOMBIE_HEALTH[2];
                progressBar3.Value += 1;

                randomZombieHitMe();

                if (progressBar3.Maximum == progressBar3.Value)
                {
                    zombieClick();
                    pictureBox_zombie3.Hide();
                    progressBar3.Hide();
                }
            }
            else
            {
                if (_Character.Ammo > 0)
                {
                    setPlayerAmmo(_Character.Ammo - 1);
                    zombieClick();

                    if (_Character.currentlyEqquiped == 7 || _Character.currentlyEqquiped == 8)
                    {
                        pictureBox_fire3.Location = new Point(ZOMBIE_POS[2].X, ZOMBIE_POS[2].Y);
                        pictureBox_fire3.Show();
                    }

                    pictureBox_zombie3.Hide();
                }
                else
                    new ToolTip().Show("Man baigėsi kulkos!\nReikia grįžti į inventorių ir pasirinkti kitą ginklą arba gauti kulkų!", pictureBox_city_character, 2000);
            }
        }

        private void pictureBox_zombie4_Click(object sender, EventArgs e)
        {
            if (_Character.currentlyEqquiped == 0 || _Character.currentlyEqquiped == 1 || _Character.currentlyEqquiped == 2)
            {
                progressBar4.Show();
                progressBar4.Maximum = ZOMBIE_HEALTH[3];
                progressBar4.Value += 1;

                randomZombieHitMe();

                if (progressBar4.Maximum == progressBar4.Value)
                {
                    zombieClick();
                    pictureBox_zombie4.Hide();
                    progressBar4.Hide();
                }
            }
            else
            {
                if (_Character.Ammo > 0)
                {
                    setPlayerAmmo(_Character.Ammo - 1);
                    zombieClick();

                    if (_Character.currentlyEqquiped == 7 || _Character.currentlyEqquiped == 8)
                    {
                        pictureBox_fire4.Location = new Point(ZOMBIE_POS[3].X, ZOMBIE_POS[3].Y);
                        pictureBox_fire4.Show();
                    }

                    pictureBox_zombie4.Hide();
                }
                else
                    new ToolTip().Show("Man baigėsi kulkos!\nReikia grįžti į inventorių ir pasirinkti kitą ginklą arba gauti kulkų!", pictureBox_city_character, 2000);
            }
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

            if (_Character.hasDeagle)
            {
                pictureBox_shop_deagle.Enabled = false;
                pictureBox_shop_deagle.BackColor = Color.Green;
            }


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

        void setPlayerAmmo(int _Value)
        {
            _Character.Ammo = _Value;
            label_ammo.Text = _Character.Ammo.ToString();
        }

        private void pictureBox_shop_deagle_Click(object sender, EventArgs e)
        {
            if (hasEnoughMoney(_CFG.SHOP_DEAGLE_PRICE))
            {
                MessageBox.Show("Sėkmingai nusipirkai Deagle!\nJį pradėti naudoti gali per inventorių!");
                setPlayerMoney(_Character.Money - _CFG.SHOP_DEAGLE_PRICE);
                _Character.hasDeagle = true;
                pictureBox_shop_deagle.BackColor = Color.Green;
            }
        }

        private void pictureBox_shop_smg_Click(object sender, EventArgs e)
        {
            if (hasEnoughMoney(_CFG.SHOP_SMG_PRICE))
            {
                MessageBox.Show("Sėkmingai nusipirkai SMG!\nJį pradėti naudoti gali per inventorių!");
                setPlayerMoney(_Character.Money - _CFG.SHOP_SMG_PRICE);
                _Character.hasSMG = true;
                pictureBox_shop_smg.BackColor = Color.Green;
            }
        }

        private void pictureBox_shop_minigun_Click_1(object sender, EventArgs e)
        {
            if (hasEnoughMoney(_CFG.SHOP_MINIGUN_PRICE))
            {
                MessageBox.Show("Sėkmingai nusipirkai Minigun!\nJį pradėti naudoti gali per inventorių!");
                setPlayerMoney(_Character.Money - _CFG.SHOP_MINIGUN_PRICE);
                _Character.hasMinigun = true;
                pictureBox_shop_minigun.BackColor = Color.Green;
            }
        }

        private void pictureBox_shop_ak47_Click_1(object sender, EventArgs e)
        {
            //if (hasEnoughMoney(_CFG.SHOP_BAZOOKA_PRICE))
            //{
            //    MessageBox.Show("Sėkmingai nusipirkai AK47!\nJį pradėti naudoti gali per inventorių!");
            //    setPlayerMoney(_Character.Money - _CFG.SHOP_AK47_PRICE);
            //    _Character.hasAK47 = true;
            //    pictureBox_shop_ak47.BackColor = Color.Green;
            //}
        }

        private void pictureBox_shop_bazooka_Click(object sender, EventArgs e)
        {
            if (hasEnoughMoney(_CFG.SHOP_BAZOOKA_PRICE))
            {
                MessageBox.Show("Sėkmingai nusipirkai Bazooka!\nJį pradėti naudoti gali per inventorių!");
                setPlayerMoney(_Character.Money - _CFG.SHOP_BAZOOKA_PRICE);
                _Character.hasBazooka = true;
                pictureBox_shop_bazooka.BackColor = Color.Green;
            }
        }

        private void pictureBox_shop_ammo_Click(object sender, EventArgs e)
        {
            if (hasEnoughMoney(_CFG.SHOP_AMMO_PRICE))
            {
                MessageBox.Show("Sėkmingai nusipirkai AMMO!");
                setPlayerMoney(_Character.Money - _CFG.SHOP_AMMO_PRICE);
                setPlayerAmmo(_Character.Ammo + 15);
            }
        }

        private void pictureBox_shop_healthpack_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_inventory_GOBACK_Click(object sender, EventArgs e)
        {
            panel_city.Hide();
            panel_shop.Hide();
            panel_inventory.Hide();
            panel_Map.Show();
        }

        #region "Inventory related"

        void setInventoryPictureboxesBordersToNone()
        {
            pictureBox_invnetory_knife.BorderStyle = BorderStyle.None;
            pictureBox_invnetory_baton.BorderStyle = BorderStyle.None;
            pictureBox_invnetory_axe.BorderStyle = BorderStyle.None;
            pictureBox_invnetory_glock.BorderStyle = BorderStyle.None;
            pictureBox_invnetory_deagle.BorderStyle = BorderStyle.None;
            pictureBox_invnetory_minigun.BorderStyle = BorderStyle.None;
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

        #endregion

        private void panel_city_Paint(object sender, PaintEventArgs e)
        {

        }

        void buyGun(int gunPrice, ref bool boolPointer, PictureBox gunPictureBox, string gunName)
        {
            if (hasEnoughMoney(gunPrice))
            {
                DialogResult result = MessageBox.Show("Tikrai nori pirkti " + gunName + "?", "Patvirtinimas", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Sėkmingai nusipirkai " + gunName + "!\nJį pradėti naudoti gali per inventorių!");
                    setPlayerMoney(_Character.Money - gunPrice);
                    boolPointer = true;
                    gunPictureBox.BackColor = Color.Green;
                }
            }
        }

        //https://stackoverflow.com/questions/35528548/detect-right-click-on-every-picturebox-on-the-form
        private void pictureBox_shop_ak47_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        bool a = _Character.hasAK47;
                        buyGun(_CFG.SHOP_AK47_PRICE, ref a, pictureBox_shop_ak47, "AK-47");
                        _Character.hasAK47 = a;
                        break;
                    }
                case MouseButtons.Right:
                    {
                        if (_Character.hasAK47)
                        {
                            DialogResult result = MessageBox.Show("Tikrai nori parduoti AK-47?", "Patvirtinimas", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                _Character.hasAK47 = false;
                                setPlayerMoney(_Character.Money + _CFG.SHOP_AK47_PRICE);
                                pictureBox_shop_ak47.BackColor = Color.Transparent;
                            }
                        }
                        break;
                    }
            }
        }
    }
}
