using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;

namespace GA_1
{
    public partial class Form1 : Form
    {
        Character _Character = new Character();
        Treasure _Treasure = new Treasure();
        gameConfig _CFG = new gameConfig();

        void switchPanels(Panel _Panel1, Panel _Panel2)
        {
            _Panel1.Location = new Point(1000, 1000);
            _Panel2.Location = new Point(0, 0);
        }

        public Form1()
        {
            InitializeComponent();

            panel_settings.Location = new Point(1000, 1000);

            //KAINU NUSTATYMAI SHOPUJ
            label_deagle_price.Text = "Kaina: " + _CFG.SHOP_DEAGLE_PRICE.ToString();
            label_smg_price.Text = "Kaina: " + _CFG.SHOP_SMG_PRICE.ToString();
            label_ak_price.Text = "Kaina: " + _CFG.SHOP_AK47_PRICE.ToString();
            label_minigun_price.Text = "Kaina: " + _CFG.SHOP_MINIGUN_PRICE.ToString();
            label_bazooka_price.Text = "Kaina: " + _CFG.SHOP_BAZOOKA_PRICE.ToString();
            label_ammo_price.Text = "Kaina: " + _CFG.SHOP_AMMO_PRICE.ToString();
            label_healthpack_price.Text = "Kaina: " + _CFG.SHOP_HEALTHPACK_PRICE.ToString();

            label7.Text = "Turi:\n• Vaistinėlę\n• Peilį";
            label8.Text = "Turi:\n• Bananą";
            label9.Text = "Turi:\n• Kirvį";

            notifyIcon1.Visible = true;
            //notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Pasiekimo tekstas.", ToolTipIcon.Info);

            this.Size = new Size(800, 600);
            this.MaximumSize = new Size(800, 600);
            this.MinimumSize = new Size(800, 600);

            Size panelSize = new Size(784, 561);

            panel1.Size = panelSize;
            panel_achievements.Size = panelSize;
            panel_city.Size = panelSize;
            panel_settings.Size = panelSize;

            resetCityFormElements();
        }

        #region "Main menu"

        private void button1_Click(object sender, EventArgs e)
        {
            switchPanels(panel1, panel2);
        }

        //private void bContinueOldGame_Click(object sender, EventArgs e)
        //{

        //}

        #endregion

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

        void setPlayerExperience(int _Value)
        {
            _Character.Experience = _Value;
            label_hud_experience.Text = "Patirtis: " + _Character.Experience.ToString();
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

        void gameEnd()
        {
            MessageBox.Show("Jūs mirėte. Jūsų žaidimas baigtas.");
            string input = Interaction.InputBox("Įveskite skaičių:\n1 - Z-A pagal sumą\n2 - Z-A pagal patirtį\n3 - Z-A pagal auksą\n4 - Z-A pagal nužudytus zombius\n5 - Z-A pagal apvogtus automobilius\n6 - Z-A pagal atidarytas dėžes", "", "1", -1, -1);
            OutPut(Convert.ToInt32(input));
            Application.Exit();
        }

        #endregion

        #region "Panel 2: Choose character"

        void playerCharacterChoose(Bitmap _Bitmap, int charID, int gunEquippedID)
        {
            _Character.charID = charID;
            _Character.currentlyEqquiped = gunEquippedID;

            pictureBox_mapChar.Image = _Bitmap;
            pictureBox_city_character.Image = _Bitmap;

            switchPanels(panel2, panel_Map);

            string input = Interaction.InputBox("Įveskite žaidėjo vardą:", "Žaidėjo vardas", DateTime.Now.ToLocalTime().ToString(), -1, -1);
            _Character.Name = input;

            achievement_Welcome();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            _Character.hasGlock = true;
            _Character.hasKnife = true;

            playerCharacterChoose(GA_1.Properties.Resources.vagis2, 0, 0);
        }

        private void button_cMedikas_Click(object sender, EventArgs e)
        {
            _Character.healthPack = 1;
            _Character.hasKnife = true;

            playerCharacterChoose(GA_1.Properties.Resources.medikas, 1, 0);
        }

        private void button_cPolicininkas_Click(object sender, EventArgs e)
        {
            _Character.hasBat = true;

            playerCharacterChoose(GA_1.Properties.Resources.policija, 2, 1);
        }

        private void button_cGaisrininkas_Click(object sender, EventArgs e)
        {
            _Character.hasAxe = true;

            playerCharacterChoose(GA_1.Properties.Resources.ugniagesys, 3, 2);
        }

        #endregion

        #region "panel_city stuff"

        int[] ZOMBIE_HEALTH = new int[4];
        Point[] ZOMBIE_POS = new Point[4];

        void zombieKill()
        {
            new ToolTip().Show("Nužudžiau zombį! Įgavau +" + _CFG.EXPERIENCE_ZOMBIE_CLICK + " patirties!\nRadau " + _CFG.MONEY_ZOMBIE_CLICK + " aukso!", pictureBox_city_character, 2000);
            setPlayerExperience(_Character.Experience + _CFG.EXPERIENCE_ZOMBIE_CLICK);
            setPlayerMoney(_Character.Money + _CFG.MONEY_ZOMBIE_CLICK);
            _Character.killCount++;
            label_gold.Text = _Character.Money.ToString();

            achievement_firstZombie();
            achievement_5zombie();

            achievement_blastingFire();
        }

        void carClick()
        {
            new ToolTip().Show("Apvogiau mašiną! Įgavau +" + _CFG.EXPERIENCE_CAR_CLICK + " patirties!\nRadau " + _CFG.MONEY_CAR_CLICK + " aukso!", pictureBox_city_character, 2000);
            setPlayerExperience(_Character.Experience + _CFG.EXPERIENCE_CAR_CLICK);
            setPlayerMoney(_Character.Money + _CFG.MONEY_CAR_CLICK);
            _Character.carCount++;
            label_gold.Text = _Character.Money.ToString();

            achievement_firstCar();
            achievement_5car();
        }

        void randomZombieHitMe()
        {
            if (new Random(DateTime.Now.Millisecond).Next(0, 2) == 1)
            {
                new ToolTip().Show("Auč, zombis mane sužalojo!", pictureBox_city_character, 2000);
                setPlayerHealth(_Character.Health - 1);
            }
        }

        void gotoCity()
        {
            achievement_firstTimeCity();

            var Lock_1 = new Random(DateTime.Now.Millisecond).Next(0, 3);

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
            switchPanels(panel_Map, panel_city);

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
                pictureBox_shop_deagle.BackColor = Color.Green;
            }
            else if (itemid == 1)
            {
                _Character.hasSMG = true;
                pictureBox_shop_smg.BackColor = Color.Green;
            }
            else if (itemid == 2)
            {
                _Character.hasAK47 = true;
                pictureBox_shop_ak47.BackColor = Color.Green;
            }
            else if (itemid == 3)
            {
                _Character.hasMinigun = true;
                pictureBox_shop_minigun.BackColor = Color.Green;
            }
            else if (itemid == 4)
            {
                _Character.hasBazooka = true;
                pictureBox_shop_bazooka.BackColor = Color.Green;
            }
            else if (itemid == 5)
                setPlayerAmmo(_Character.Ammo + _CFG.AMMO_BOX_CLICK);
            else if (itemid == 6)
                setPlayerExperience(_Character.Experience + _CFG.MONEY_BOX_CLICK);
            else if (itemid == 7)
                setPlayerExperience(_Character.Experience + _CFG.EXPERIENCE_BOX_CLICK);
            else if (itemid == 8)
                _Character.healthPack += _CFG.HEALTHPACK_BOX_CLICK;

            new ToolTip().Show("Oho! Reta dėžė! Radau " + tName + "!", pictureBox_city_character, 2000);

            label_ammo.Text = _Character.Ammo.ToString();

            pictureBox_supplycrate.Hide();

            _Character.lootboxCount++;

            achievement_firstLootbox();
            achievement_5lootbox();
        }

        void resetCityFormElements()
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
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            //Atgal į slėptuvę iš parduotuvės
            //Resetinam elementus dar...

            switchPanels(panel_city, panel_Map);

            resetCityFormElements();
        }

        private void pictureBox_city_character_Click(object sender, EventArgs e)
        {

        }

        void zombieClick(ProgressBar _ProgressBar, int zombieHealth, PictureBox _PictureBoxZombie, PictureBox _PictureBoxFire, Point zombieLocation)
        {
            if (_Character.currentlyEqquiped == -1 || _Character.currentlyEqquiped == 0 || _Character.currentlyEqquiped == 1 || _Character.currentlyEqquiped == 2)
            {
                _ProgressBar.Show();
                _ProgressBar.Maximum = zombieHealth;
                _ProgressBar.Value += 1;

                randomZombieHitMe();

                if (_ProgressBar.Maximum == _ProgressBar.Value)
                {
                    zombieKill();
                    _PictureBoxZombie.Hide();
                    _ProgressBar.Hide();
                }
            }
            else
            {
                if (_Character.Ammo > 0)
                {
                    setPlayerAmmo(_Character.Ammo - 1);
                    zombieKill();

                    if (_Character.currentlyEqquiped == 7 || _Character.currentlyEqquiped == 8)
                    {
                        _PictureBoxFire.Location = new Point(zombieLocation.X, zombieLocation.Y);
                        _PictureBoxFire.Show();
                    }

                    _PictureBoxZombie.Hide();
                }
                else
                    new ToolTip().Show("Man baigėsi kulkos!\nReikia grįžti į inventorių ir pasirinkti kitą ginklą arba gauti kulkų!", pictureBox_city_character, 2000);
            }
        }

        private void pictureBox_zombie1_Click(object sender, EventArgs e)
        {
            zombieClick(progressBar1, ZOMBIE_HEALTH[0], pictureBox_zombie1, pictureBox_fire1, ZOMBIE_POS[0]);
        }

        private void pictureBox_zombie2_Click(object sender, EventArgs e)
        {
            zombieClick(progressBar2, ZOMBIE_HEALTH[1], pictureBox_zombie2, pictureBox_fire2, ZOMBIE_POS[1]);
        }

        private void pictureBox_zombie3_Click(object sender, EventArgs e)
        {
            zombieClick(progressBar3, ZOMBIE_HEALTH[2], pictureBox_zombie3, pictureBox_fire3, ZOMBIE_POS[2]);
        }

        private void pictureBox_zombie4_Click(object sender, EventArgs e)
        {
            zombieClick(progressBar4, ZOMBIE_HEALTH[3], pictureBox_zombie4, pictureBox_fire4, ZOMBIE_POS[3]);
        }

        #endregion

        #region "panel_Map stuff"

        private void pictureBox_mapChar_Click(object sender, EventArgs e)
        {
            achievement_firstTimeInventory();

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

            switchPanels(panel_Map, panel_inventory);
        }

        private void pictureBox_city_Click(object sender, EventArgs e)
        {
            gotoCity();
        }

        private void pictureBox_shop_Click(object sender, EventArgs e)
        {
            achievement_firstTimeShop();

            switchPanels(panel_Map, panel_shop);

            label_shop_gold.Text = _Character.Money.ToString();
        }

        private void pictureBox_leavegame_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tikrai norite baigti žaidimą?", "Patvirtinimas", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string input = Interaction.InputBox("Įveskite skaičių:\n1 - A-Z pagal sumą\n2 - A-Z pagal patirtį\n3 - A-Z pagal auksą\n4 - A-Z pagal nužudytus zombius\n5 - A-Z pagal apvogtus automobilius\n6 - A-Z pagal atidarytas dėžes", "", "1", -1, -1);
                OutPut(Convert.ToInt32(input));
                Application.Exit();
            }
        }

        #endregion

        #region "Inventory related"

        private void pictureBox_inventory_GOBACK_Click(object sender, EventArgs e)
        {
            switchPanels(panel_inventory, panel_Map);
        }

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

            if (_Character.charID == 0)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.vags_knife;

            if (_Character.charID == 1)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.medikas_knife;

            achievement_firstEquip();
        }

        private void pictureBox_invnetory_baton_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_baton.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 1;

            if (_Character.charID == 2)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.policija_baton;

            achievement_firstEquip();
        }

        private void pictureBox_invnetory_axe_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_axe.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 2;

            if (_Character.charID == 3)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.ugniagesys_axe;

            achievement_firstEquip();
        }

        private void pictureBox_invnetory_glock_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_glock.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 3;

            if (_Character.charID == 0)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.vagis_glock;

            achievement_firstEquip();
        }

        private void pictureBox_invnetory_deagle_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_deagle.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 4;

            if (_Character.charID == 0)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.vagis_deagle;
            if (_Character.charID == 1)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.medikas_deagle;
            if (_Character.charID == 2)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.policija_deagle;
            if (_Character.charID == 3)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.ugniagesys_deagle;

            achievement_firstEquip();
        }

        private void pictureBox_invnetory_smg_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_smg.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 5;

            if (_Character.charID == 0)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.vagis_smg;
            if (_Character.charID == 1)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.medikas_smg;
            if (_Character.charID == 2)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.policija_smg;
            if (_Character.charID == 3)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.ugniagesys_smg;

            achievement_firstEquip();
        }

        private void pictureBox_invnetory_ak47_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_ak47.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 6;

            if (_Character.charID == 0)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.vagis_ak47;
            if (_Character.charID == 1)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.medikas_ak47;
            if (_Character.charID == 2)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.policija_ak47;
            if (_Character.charID == 3)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.ugniagesys_ak47;

            achievement_firstEquip();
        }

        private void pictureBox_invnetory_minigun_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_minigun.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 7;

            if (_Character.charID == 0)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.vagis_minigun;
            if (_Character.charID == 1)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.medikas_minigun;
            if (_Character.charID == 2)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.policija_minigun;
            if (_Character.charID == 3)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.ugniagesys_minigun;

            achievement_firstEquip();
        }

        private void pictureBox_invnetory_bazooka_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_bazooka.BorderStyle = BorderStyle.Fixed3D;
            _Character.currentlyEqquiped = 8;

            if (_Character.charID == 0)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.vagis_bazooka;
            if (_Character.charID == 1)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.medikas_bazooka;
            if (_Character.charID == 2)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.policija_bazooka;
            if (_Character.charID == 3)
                pictureBox_mapChar.Image = GA_1.Properties.Resources.ugniagesys_bazooka;

            achievement_firstEquip();
        }

        private void pictureBox_invnetory_bloodpack_Click(object sender, EventArgs e)
        {
            setInventoryPictureboxesBordersToNone();
            pictureBox_invnetory_bloodpack.BorderStyle = BorderStyle.Fixed3D;

            if (_Character.Health != 5)
            {
                setPlayerHealth(_Character.Health + 1);
                _Character.healthPack--;

                if (_Character.healthPack < 1)
                    pictureBox_invnetory_bloodpack.Hide();
            }
            else
                MessageBox.Show("Tu jau turi max gyvybių!");
        }

        #endregion

        #region "Shop"

        #region "Unused"

        private void pictureBox_shop_deagle_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox_shop_smg_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox_shop_minigun_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox_shop_ak47_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox_shop_bazooka_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox_shop_ammo_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox_shop_healthpack_Click(object sender, EventArgs e)
        {
        }

        #endregion

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

                    achievement_firstBuy();
                }
            }
        }

        void sellGun(int gunPrice, ref bool boolPointer, PictureBox gunPictureBox, string gunName)
        {
            if (boolPointer)
            {
                DialogResult result = MessageBox.Show("Tikrai nori parduoti " + gunName + "?", "Patvirtinimas", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    boolPointer = false;
                    setPlayerMoney(_Character.Money + gunPrice);
                    gunPictureBox.BackColor = Color.Transparent;

                    achievement_firstSell();


                    if ((_Character.currentlyEqquiped == 4 && gunName == "Deagle") ||
                        (_Character.currentlyEqquiped == 5 && gunName == "SMG") ||
                        (_Character.currentlyEqquiped == 6 && gunName == "AK-47") ||
                        (_Character.currentlyEqquiped == 7 && gunName == "Minigun") ||
                        (_Character.currentlyEqquiped == 8 && gunName == "Bazooka")
                       )
                    {
                        if (_Character.charID == 0)
                        {
                            pictureBox_mapChar.Image = GA_1.Properties.Resources.vagis2;
                            _Character.currentlyEqquiped = -1;
                        }
                        if (_Character.charID == 1)
                        {
                            pictureBox_mapChar.Image = GA_1.Properties.Resources.medikas;
                            _Character.currentlyEqquiped = -1;
                        }
                        if (_Character.charID == 2)
                        {
                            pictureBox_mapChar.Image = GA_1.Properties.Resources.policija;
                            _Character.currentlyEqquiped = -1;
                        }
                        if (_Character.charID == 3)
                        {
                            pictureBox_mapChar.Image = GA_1.Properties.Resources.ugniagesys;
                            _Character.currentlyEqquiped = -1;
                        }
                    }
                }
            }
        }

        //https://stackoverflow.com/questions/35528548/detect-right-click-on-every-picturebox-on-the-form
        //https://stackoverflow.com/questions/3653588/c-sharp-pointers-in-a-methods-arguments
        private void pictureBox_shop_deagle_MouseClick(object sender, MouseEventArgs e)
        {
            bool a = _Character.hasDeagle;

            switch (e.Button)
            {
                case MouseButtons.Left:
                {
                    buyGun(_CFG.SHOP_DEAGLE_PRICE, ref a, pictureBox_shop_deagle, "Deagle");
                    break;
                }
                case MouseButtons.Right:
                {
                    sellGun(_CFG.SHOP_DEAGLE_PRICE, ref a, pictureBox_shop_deagle, "Deagle");
                    break;
                }
            }

            _Character.hasDeagle = a;
        }

        private void pictureBox_shop_ak47_MouseClick(object sender, MouseEventArgs e)
        {
            bool a = _Character.hasAK47;

            switch (e.Button)
            {
                case MouseButtons.Left:
                {
                    buyGun(_CFG.SHOP_AK47_PRICE, ref a, pictureBox_shop_ak47, "AK-47");
                    break;
                }
                case MouseButtons.Right:
                {
                    sellGun(_CFG.SHOP_AK47_PRICE, ref a, pictureBox_shop_ak47, "AK-47");
                    break;
                }
            }

            _Character.hasAK47 = a;
        }

        private void pictureBox_shop_smg_MouseClick(object sender, MouseEventArgs e)
        {
            bool a = _Character.hasSMG;

            switch (e.Button)
            {
                case MouseButtons.Left:
                {
                    buyGun(_CFG.SHOP_SMG_PRICE, ref a, pictureBox_shop_smg, "SMG");
                    break;
                }
                case MouseButtons.Right:
                {
                    sellGun(_CFG.SHOP_SMG_PRICE, ref a, pictureBox_shop_smg, "SMG");
                    break;
                }
            }

            _Character.hasSMG = a;
        }

        private void pictureBox_shop_minigun_MouseClick(object sender, MouseEventArgs e)
        {
            bool a = _Character.hasMinigun;

            switch (e.Button)
            {
                case MouseButtons.Left:
                {
                    buyGun(_CFG.SHOP_MINIGUN_PRICE, ref a, pictureBox_shop_minigun, "Minigun");
                    break;
                }
                case MouseButtons.Right:
                {
                    sellGun(_CFG.SHOP_MINIGUN_PRICE, ref a, pictureBox_shop_minigun, "Minigun");
                    break;
                }
            }

            _Character.hasMinigun = a;

            achievement_firstHeavyWeapon();
        }

        private void pictureBox_shop_bazooka_MouseClick(object sender, MouseEventArgs e)
        {
            bool a = _Character.hasBazooka;

            switch (e.Button)
            {
                case MouseButtons.Left:
                {
                    buyGun(_CFG.SHOP_BAZOOKA_PRICE, ref a, pictureBox_shop_bazooka, "Bazooka");
                    break;
                }
                case MouseButtons.Right:
                {
                    sellGun(_CFG.SHOP_BAZOOKA_PRICE, ref a, pictureBox_shop_bazooka, "Bazooka");
                    break;
                }
            }

            _Character.hasBazooka = a;

            achievement_firstHeavyWeapon();
        }

        private void pictureBox_shop_ammo_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                {
                    if (hasEnoughMoney(_CFG.SHOP_AMMO_PRICE))
                    {
                        DialogResult result = MessageBox.Show("Tikrai nori pirkti kulkų?", "Patvirtinimas", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            MessageBox.Show("Sėkmingai nusipirkai kulkų!");
                            setPlayerMoney(_Character.Money - _CFG.SHOP_AMMO_PRICE);
                            setPlayerAmmo(_Character.Ammo + 15);
                        }
                    }
                    break;
                }
                case MouseButtons.Right:
                {
                    MessageBox.Show("Parduotuvė nesuperka kulkų!");
                    break;
                }
            }
        }

        private void pictureBox_shop_healthpack_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                {
                    if (hasEnoughMoney(_CFG.SHOP_HEALTHPACK_PRICE))
                    {
                        DialogResult result = MessageBox.Show("Tikrai nori pirkti vaistinėlę?", "Patvirtinimas", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            MessageBox.Show("Sėkmingai nusipirkai vaistinėlę!");
                            setPlayerMoney(_Character.Money - _CFG.SHOP_HEALTHPACK_PRICE);
                            _Character.healthPack += 1;
                        }
                    }
                    break;
                }
                case MouseButtons.Right:
                {
                    MessageBox.Show("Parduotuvė nesuperka vaistinėlių!");
                    break;
                }
            }
        }

        private void pictureBox_shopGOBACK_Click(object sender, EventArgs e)
        {
            switchPanels(panel_shop, panel_Map);
        }

        #endregion

        #region "Achivement voids"

        void achievement_Welcome()
        {
            if (_Character.achievement_Welcome == false)
            {
                notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Sveiki atvykę į zombieLand!", ToolTipIcon.Info);
                _Character.achievement_Welcome = true;
            }
        }

        void achievement_firstTimeCity()
        {
            if (_Character.achievement_firstTimeCity == false)
            {
                notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Pirmas apsilankymas mieste!", ToolTipIcon.Info);
                _Character.achievement_firstTimeCity = true;
            }
        }

        void achievement_firstTimeShop()
        {
            if (_Character.achievement_firstTimeShop == false)
            {
                notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Pirmas apsilankymas parduotuvėje!", ToolTipIcon.Info);
                _Character.achievement_firstTimeShop = true;
            }
        }

        void achievement_firstTimeInventory()
        {
            if (_Character.achievement_firstTimeInventory == false)
            {
                notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Pirmas apsilankymas inventoriuje!", ToolTipIcon.Info);
                _Character.achievement_firstTimeInventory = true;
            }
        }

        void achievement_firstCar()
        {
            if (_Character.achievement_firstCar == false)
            {
                notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Pirma apvogta mašina!", ToolTipIcon.Info);
                _Character.achievement_firstCar = true;
            }
        }

        void achievement_firstZombie()
        {
            if (_Character.achievement_firstZombie == false)
            {
                notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Pirmas nužudytas zombis!", ToolTipIcon.Info);
                _Character.achievement_firstZombie = true;
            }
        }

        void achievement_firstLootbox()
        {
            if (_Character.achievement_firstLootbox == false)
            {
                notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Atidaryta pirma dėžė!", ToolTipIcon.Info);
                _Character.achievement_firstLootbox = true;
            }
        }

        void achievement_firstBuy()
        {
            if (_Character.achievement_firstBuy == false)
            {
                notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Pirmas nusipirktas daiktas!", ToolTipIcon.Info);
                _Character.achievement_firstBuy = true;
            }
        }

        void achievement_firstSell()
        {
            if (_Character.achievement_firstSell == false)
            {
                notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Pirmas parduotas daiktas!", ToolTipIcon.Info);
                _Character.achievement_firstSell = true;
            }
        }

        void achievement_firstEquip()
        {
            if (_Character.achievement_firstEquip == false)
            {
                notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Pirmą kartą išbandote naują ginklą!", ToolTipIcon.Info);
                _Character.achievement_firstEquip = true;
            }
        }

        void achievement_firstHeavyWeapon()
        {
            if (_Character.achievement_firstHeavyWeapon == false)
            {
                notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Sunkioji artilerija: Pirmas kartas!", ToolTipIcon.Info);
                _Character.achievement_firstHeavyWeapon = true;
            }
        }

        void achievement_5car()
        {
            if (_Character.carCount >= 5 && _Character.achievement_5car == false)
            {
                notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Pirmąkart apvogei 5 mašinas!", ToolTipIcon.Info);
                _Character.achievement_5car = true;
            }
        }

        void achievement_5zombie()
        {
            if (_Character.killCount >= 5 && _Character.achievement_5zombie == false)
            {
                notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Pirmąkart nužudei 5 zombius!", ToolTipIcon.Info);
                _Character.achievement_5zombie = true;
            }
        }

        void achievement_5lootbox()
        {
            if (_Character.lootboxCount >= 5 && _Character.achievement_5lootbox == false)
            {
                notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Pirmąkart atidarei 5 dėžes!", ToolTipIcon.Info);
                _Character.achievement_5lootbox = true;
            }
        }

        void achievement_blastingFire()
        {
            if (_Character.achievement_blastingFire == false)
            {
                if (_Character.currentlyEqquiped == 7 || _Character.currentlyEqquiped == 8)
                {
                    notifyIcon1.ShowBalloonTip(2000, "Naujas pasiekimas!", "Ištaškai zombius ugnimi!", ToolTipIcon.Info);
                    _Character.achievement_blastingFire = true;
                }
            }
        }
        #endregion

        #region "panel_achievements functionality"

        private void pictureBox_achievements_Click(object sender, EventArgs e)
        {
            label_achievements.Text = "";

            if (_Character.achievement_Welcome)
                label_achievements.Text += "[+] Sveikas atvykęs!\n";
            else
                label_achievements.Text += "[-] Sveikas atvykęs!\n";

            if (_Character.achievement_firstTimeCity)
                label_achievements.Text += "[+] Pirmą kartą apsilankei mieste!\n";
            else
                label_achievements.Text += "[-] Pirmą kartą apsilankei mieste!\n";

            if (_Character.achievement_firstTimeShop)
                label_achievements.Text += "[+] Pirmą kartą apsilankei parduotuvėje!\n";
            else
                label_achievements.Text += "[-] Pirmą kartą apsilankei parduotuvėje!\n";

            if (_Character.achievement_firstTimeInventory)
                label_achievements.Text += "[+] Pirmą kartą apsilankei inventoriuje!\n";
            else
                label_achievements.Text += "[-] Pirmą kartą apsilankei inventoriuje!\n";

            if (_Character.achievement_firstCar)
                label_achievements.Text += "[+] Pirmą kartą apvogei mašiną!\n";
            else
                label_achievements.Text += "[-] Pirmą kartą apvogei mašiną!\n";

            if (_Character.achievement_firstZombie)
                label_achievements.Text += "[+] Pirmą kartą nužudei zombį!\n";
            else
                label_achievements.Text += "[-] Pirmą kartą nužudei zombį!\n";

            if (_Character.achievement_firstLootbox)
                label_achievements.Text += "[+] Pirmą kartą atidarei dėžę!\n";
            else
                label_achievements.Text += "[-] Pirmą kartą atidarei dėžę!\n";

            if (_Character.achievement_firstBuy)
                label_achievements.Text += "[+] Pirmą kartą apsipirkai parduotuvėje!\n";
            else
                label_achievements.Text += "[-] Pirmą kartą apsipirkai parduotuvėje!\n";

            if (_Character.achievement_firstSell)
                label_achievements.Text += "[+] Pirmą kartą kažką pardavei parduotuvei!\n";
            else
                label_achievements.Text += "[-] Pirmą kartą kažką pardavei parduotuvei!\n";

            if (_Character.achievement_firstEquip)
                label_achievements.Text += "[+] Pirmą kartą išbandei naują ginklą!\n";
            else
                label_achievements.Text += "[-] Pirmą kartą išbandei naują ginklą!\n";

            if (_Character.achievement_firstHeavyWeapon)
                label_achievements.Text += "[+] Pirmą kartą išbandei sunkiąją artileriją!\n";
            else
                label_achievements.Text += "[-] Pirmą kartą išbandei sunkiąją artileriją!\n";

            if (_Character.achievement_5car)
                label_achievements.Text += "[+] Apvogei 5 mašinas!\n";
            else
                label_achievements.Text += "[-] Apvogei 5 mašinas!\n";

            if (_Character.achievement_5zombie)
                label_achievements.Text += "[+] Nužudei 5 zombius!\n";
            else
                label_achievements.Text += "[-] Nužudei 5 zombius!\n";

            if (_Character.achievement_5lootbox)
                label_achievements.Text += "[+] Atidarei 5 dėžes!\n";
            else
                label_achievements.Text += "[-] Atidarei 5 dėžes!\n";

            if (_Character.achievement_blastingFire)
                label_achievements.Text += "[+] Ištaškai zombius ugnimi!\n";
            else
                label_achievements.Text += "[-] Ištaškai zombius ugnimi!\n";

            switchPanels(panel_Map, panel_achievements);
        }

        private void pictureBox_achievements_GOBACK_Click(object sender, EventArgs e)
        {
            switchPanels(panel_achievements, panel_Map);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_achievements.Text = "";

            if (comboBox1.SelectedIndex == 0)
            {
                if (_Character.achievement_Welcome)
                    label_achievements.Text += "[+] Sveikas atvykęs!\n";
                else
                    label_achievements.Text += "[-] Sveikas atvykęs!\n";

                if (_Character.achievement_firstTimeCity)
                    label_achievements.Text += "[+] Pirmą kartą apsilankei mieste!\n";
                else
                    label_achievements.Text += "[-] Pirmą kartą apsilankei mieste!\n";

                if (_Character.achievement_firstTimeShop)
                    label_achievements.Text += "[+] Pirmą kartą apsilankei parduotuvėje!\n";
                else
                    label_achievements.Text += "[-] Pirmą kartą apsilankei parduotuvėje!\n";

                if (_Character.achievement_firstTimeInventory)
                    label_achievements.Text += "[+] Pirmą kartą apsilankei inventoriuje!\n";
                else
                    label_achievements.Text += "[-] Pirmą kartą apsilankei inventoriuje!\n";

                if (_Character.achievement_firstCar)
                    label_achievements.Text += "[+] Pirmą kartą apvogei mašiną!\n";
                else
                    label_achievements.Text += "[-] Pirmą kartą apvogei mašiną!\n";

                if (_Character.achievement_firstZombie)
                    label_achievements.Text += "[+] Pirmą kartą nužudei zombį!\n";
                else
                    label_achievements.Text += "[-] Pirmą kartą nužudei zombį!\n";

                if (_Character.achievement_firstLootbox)
                    label_achievements.Text += "[+] Pirmą kartą atidarei dėžę!\n";
                else
                    label_achievements.Text += "[-] Pirmą kartą atidarei dėžę!\n";

                if (_Character.achievement_firstBuy)
                    label_achievements.Text += "[+] Pirmą kartą apsipirkai parduotuvėje!\n";
                else
                    label_achievements.Text += "[-] Pirmą kartą apsipirkai parduotuvėje!\n";

                if (_Character.achievement_firstSell)
                    label_achievements.Text += "[+] Pirmą kartą kažką pardavei parduotuvei!\n";
                else
                    label_achievements.Text += "[-] Pirmą kartą kažką pardavei parduotuvei!\n";

                if (_Character.achievement_firstEquip)
                    label_achievements.Text += "[+] Pirmą kartą išbandei naują ginklą!\n";
                else
                    label_achievements.Text += "[-] Pirmą kartą išbandei naują ginklą!\n";

                if (_Character.achievement_firstHeavyWeapon)
                    label_achievements.Text += "[+] Pirmą kartą išbandei sunkiąją artileriją!\n";
                else
                    label_achievements.Text += "[-] Pirmą kartą išbandei sunkiąją artileriją!\n";

                if (_Character.achievement_5car)
                    label_achievements.Text += "[+] Apvogei 5 mašinas!\n";
                else
                    label_achievements.Text += "[-] Apvogei 5 mašinas!\n";

                if (_Character.achievement_5zombie)
                    label_achievements.Text += "[+] Nužudei 5 zombius!\n";
                else
                    label_achievements.Text += "[-] Nužudei 5 zombius!\n";

                if (_Character.achievement_5lootbox)
                    label_achievements.Text += "[+] Atidarei 5 dėžes!\n";
                else
                    label_achievements.Text += "[-] Atidarei 5 dėžes!\n";

                if (_Character.achievement_blastingFire)
                    label_achievements.Text += "[+] Ištaškai zombius ugnimi!\n";
                else
                    label_achievements.Text += "[-] Ištaškai zombius ugnimi!\n";
            }

            if (comboBox1.SelectedIndex == 1)
            {
                if (_Character.achievement_Welcome)
                    label_achievements.Text += "[+]  Sveikas atvykęs!\n";

                if (_Character.achievement_firstTimeCity)
                    label_achievements.Text += "[+] Pirmą kartą apsilankei mieste!\n";

                if (_Character.achievement_firstTimeShop)
                    label_achievements.Text += "[+] Pirmą kartą apsilankei parduotuvėje!\n";

                if (_Character.achievement_firstTimeInventory)
                    label_achievements.Text += "[+] Pirmą kartą apsilankei inventoriuje!\n";

                if (_Character.achievement_firstCar)
                    label_achievements.Text += "[+] Pirmą kartą apvogei mašiną!\n";

                if (_Character.achievement_firstZombie)
                    label_achievements.Text += "[+] Pirmą kartą nužudei zombį!\n";

                if (_Character.achievement_firstLootbox)
                    label_achievements.Text += "[+] Pirmą kartą atidarei dėžę!\n";

                if (_Character.achievement_firstBuy)
                    label_achievements.Text += "[+] Pirmą kartą apsipirkai parduotuvėje!\n";

                if (_Character.achievement_firstSell)
                    label_achievements.Text += "[+] Pirmą kartą kažką pardavei parduotuvei!\n";

                if (_Character.achievement_firstEquip)
                    label_achievements.Text += "[+] Pirmą kartą išbandei naują ginklą!\n";

                if (_Character.achievement_firstHeavyWeapon)
                    label_achievements.Text += "[+] Pirmą kartą išbandei sunkiąją artileriją!\n";

                if (_Character.achievement_5car)
                    label_achievements.Text += "[+] Apvogei 5 mašinas!\n";

                if (_Character.achievement_5zombie)
                    label_achievements.Text += "[+] Nužudei 5 zombius!\n";

                if (_Character.achievement_5lootbox)
                    label_achievements.Text += "[+] Atidarei 5 dėžes!\n";

                if (_Character.achievement_blastingFire)
                    label_achievements.Text += "[+] Ištaškai zombius ugnimi!\n";
            }

            if (comboBox1.SelectedIndex == 2)
            {
                if (!_Character.achievement_Welcome)
                    label_achievements.Text += "[-]  Sveikas atvykęs!\n";

                if (!_Character.achievement_firstTimeCity)
                    label_achievements.Text += "[-] Pirmą kartą apsilankei mieste!\n";

                if (!_Character.achievement_firstTimeShop)
                    label_achievements.Text += "[-] Pirmą kartą apsilankei parduotuvėje!\n";

                if (!_Character.achievement_firstTimeInventory)
                    label_achievements.Text += "[-] Pirmą kartą apsilankei inventoriuje!\n";

                if (!_Character.achievement_firstCar)
                    label_achievements.Text += "[-] Pirmą kartą apvogei mašiną!\n";

                if (!_Character.achievement_firstZombie)
                    label_achievements.Text += "[-] Pirmą kartą nužudei zombį!\n";

                if (!_Character.achievement_firstLootbox)
                    label_achievements.Text += "[-] Pirmą kartą atidarei dėžę!\n";

                if (!_Character.achievement_firstBuy)
                    label_achievements.Text += "[-] Pirmą kartą apsipirkai parduotuvėje!\n";

                if (!_Character.achievement_firstSell)
                    label_achievements.Text += "[-] Pirmą kartą kažką pardavei parduotuvei!\n";

                if (!_Character.achievement_firstEquip)
                    label_achievements.Text += "[-] Pirmą kartą išbandei naują ginklą!\n";

                if (!_Character.achievement_firstHeavyWeapon)
                    label_achievements.Text += "[-] Pirmą kartą išbandei sunkiąją artileriją!\n";

                if (!_Character.achievement_5car)
                    label_achievements.Text += "[-] Apvogei 5 mašinas!\n";

                if (!_Character.achievement_5zombie)
                    label_achievements.Text += "[-] Nužudei 5 zombius!\n";

                if (!_Character.achievement_5lootbox)
                    label_achievements.Text += "[-] Atidarei 5 dėžes!\n";

                if (!_Character.achievement_blastingFire)
                    label_achievements.Text += "[-] Ištaškai zombius ugnimi!\n";
            }
        }

        #endregion

        #region "TOP export"

        struct TOP
        {
            public string Name;
            public int Experience, Money, killCount, carCount, lootboxCount, Sum;
        }

        void OutPut(int filterType)
        {
            TOP[] _TOP = new TOP[101];
            int cTOP_ID = 0;

            if (File.Exists("OUTPUT.HTML"))
            {
                string[] pLines = File.ReadAllLines("OUTPUT.HTML");

                for (int i = 0; i < pLines.Length; i++)
                {
                    if (pLines[i].Contains("<tr><td>"))
                    {
                        string[] lineData = pLines[i].Split(new string[] { "</td><td>" }, StringSplitOptions.None);

                        lineData[0] = lineData[0].Replace("<tr><td>", "");
                        lineData[lineData.Length - 1] = lineData[lineData.Length - 1].Replace("</td></tr>", "");

                        _TOP[cTOP_ID].Name = lineData[0];
                        _TOP[cTOP_ID].Experience = Convert.ToInt32(lineData[1]);
                        _TOP[cTOP_ID].Money = Convert.ToInt32(lineData[2]);
                        _TOP[cTOP_ID].killCount = Convert.ToInt32(lineData[3]);
                        _TOP[cTOP_ID].carCount = Convert.ToInt32(lineData[4]);
                        _TOP[cTOP_ID].lootboxCount = Convert.ToInt32(lineData[5]);
                        _TOP[cTOP_ID].Sum = _TOP[cTOP_ID].Experience + _TOP[cTOP_ID].Money + _TOP[cTOP_ID].killCount + _TOP[cTOP_ID].carCount + _TOP[cTOP_ID].lootboxCount;

                        cTOP_ID++;
                    }
                }

                _TOP[cTOP_ID].Name = _Character.Name;
                _TOP[cTOP_ID].Experience = _Character.Experience;
                _TOP[cTOP_ID].Money = _Character.Money;
                _TOP[cTOP_ID].killCount = _Character.killCount;
                _TOP[cTOP_ID].carCount = _Character.carCount;
                _TOP[cTOP_ID].lootboxCount = _Character.lootboxCount;
                _TOP[cTOP_ID].Sum = _Character.Experience + _Character.Money + _Character.killCount + _Character.carCount + _Character.lootboxCount;

                cTOP_ID++;

                //Rikiavimas

                for (int a = 0; a < cTOP_ID; a++)
                {
                    for (int b = 0; b < cTOP_ID; b++)
                    {
                        int firstVal = 0;
                        int secondVal = 0;

                        if (filterType == 1)
                        {
                            firstVal = _TOP[a].Sum;
                            secondVal = _TOP[b].Sum;
                        }
                        if (filterType == 2)
                        {
                            firstVal = _TOP[a].Experience;
                            secondVal = _TOP[b].Experience;
                        }
                        if (filterType == 3)
                        {
                            firstVal = _TOP[a].Money;
                            secondVal = _TOP[b].Money;
                        }
                        if (filterType == 4)
                        {
                            firstVal = _TOP[a].killCount;
                            secondVal = _TOP[b].killCount;
                        }
                        if (filterType == 5)
                        {
                            firstVal = _TOP[a].carCount;
                            secondVal = _TOP[b].carCount;
                        }
                        if (filterType == 6)
                        {
                            firstVal = _TOP[a].lootboxCount;
                            secondVal = _TOP[b].lootboxCount;
                        }

                        if (firstVal > secondVal)
                        {
                            TOP tmpTop = new TOP()
                            {
                                Name = _TOP[b].Name,
                                Experience = _TOP[b].Experience,
                                Money = _TOP[b].Money,
                                killCount = _TOP[b].killCount,
                                carCount = _TOP[b].carCount,
                                lootboxCount = _TOP[b].lootboxCount,
                                Sum = _TOP[b].Sum
                            };

                            _TOP[b] = _TOP[a];
                            _TOP[a] = tmpTop;
                        }
                    }
                }

                string output = GA_1.Properties.Resources.html;

                for (int i = 0; i < cTOP_ID; i++)
                    output += "<tr><td>" +
                    _TOP[i].Name + "</td><td>" +
                    _TOP[i].Experience + "</td><td>" +
                    _TOP[i].Money + "</td><td>" +
                    _TOP[i].killCount + "</td><td>" +
                    _TOP[i].carCount + "</td><td>" +
                    _TOP[i].lootboxCount + "</td><td>" +
                    (_TOP[i].Experience + _TOP[i].Money + _TOP[i].killCount + _TOP[i].carCount + _TOP[i].lootboxCount) + "</td></tr>\n";

                output += "</table></body></html>";

                File.WriteAllText("OUTPUT.HTML", output);
            }
            else
            {
                string output = GA_1.Properties.Resources.html;

                    output += "<tr><td>" +
                    _Character.Name + "</td><td>" +
                    _Character.Experience + "</td><td>" +
                    _Character.Money + "</td><td>" +
                    _Character.killCount + "</td><td>" +
                    _Character.carCount + "</td><td>" +
                    _Character.lootboxCount + "</td><td>" +
                    (_Character.Experience + _Character.Money + _Character.killCount + _Character.carCount + _Character.lootboxCount) + "</td></tr>\n";

                output += "</table></body></html>";

                File.WriteAllText("OUTPUT.HTML", output);
            }


            Process.Start("OUTPUT.HTML");
        }

        #endregion

        #region "JSON import"

        void LoadCFG(string fPath)
        {
            try
            {
                string sJSON = File.ReadAllText(fPath);

                dynamic JSON_DATA = JObject.Parse(sJSON);

                string cityMapImage = JSON_DATA.cityMapImage;
                string zombieModel_1 = JSON_DATA.zombieModel_1;
                string zombieModel_2 = JSON_DATA.zombieModel_2;
                string zombieModel_3 = JSON_DATA.zombieModel_3;
                string zombieModel_4 = JSON_DATA.zombieModel_4;
                string carModel_1 = JSON_DATA.carModel_1;
                string carModel_2 = JSON_DATA.carModel_2;
                string carModel_3 = JSON_DATA.carModel_3;
                string lootboxModel = JSON_DATA.lootboxModel;
                string fireModel = JSON_DATA.fireModel;

                //MessageBox.Show(cityMapImage);
                //MessageBox.Show(zombieModel_1);
                //MessageBox.Show(fireModel);

                if (cityMapImage != "")
                {
                    Bitmap bmp = new Bitmap(cityMapImage);
                    panel_city.BackgroundImage = bmp;
                }
                if (zombieModel_1 != "")
                {
                    Bitmap bmp = new Bitmap(zombieModel_1);
                    pictureBox_zombie1.Image = bmp;
                }
                if (zombieModel_2 != "")
                {
                    Bitmap bmp = new Bitmap(zombieModel_2);
                    pictureBox_zombie2.Image = bmp;
                }
                if (zombieModel_3 != "")
                {
                    Bitmap bmp = new Bitmap(zombieModel_3);
                    pictureBox_zombie3.Image = bmp;
                }
                if (zombieModel_4 != "")
                {
                    Bitmap bmp = new Bitmap(zombieModel_4);
                    pictureBox_zombie4.Image = bmp;
                }
                if (carModel_1 != "")
                {
                    Bitmap bmp = new Bitmap(carModel_1);
                    pictureBox_car1.Image = bmp;
                }
                if (carModel_2 != "")
                {
                    Bitmap bmp = new Bitmap(carModel_2);
                    pictureBox_car2.Image = bmp;
                }
                if (carModel_3 != "")
                {
                    Bitmap bmp = new Bitmap(carModel_3);
                    pictureBox_car3.Image = bmp;
                }
                if (lootboxModel != "")
                {
                    Bitmap bmp = new Bitmap(lootboxModel);
                    pictureBox_supplycrate.Image = bmp;
                }
                if (fireModel != "")
                {
                    Bitmap bmp = new Bitmap(fireModel);
                    pictureBox_fire1.Image = bmp;
                    pictureBox_fire2.Image = bmp;
                    pictureBox_fire3.Image = bmp;
                    pictureBox_fire4.Image = bmp;
                }
                notifyIcon1.ShowBalloonTip(2000, "Nustatymai užkrauti!", "Sėkmingai užkrovei nustatymus!", ToolTipIcon.Info);

                switchPanels(panel_settings, panel1);
            }
            catch
            {
                notifyIcon1.ShowBalloonTip(2000, "KLAIDA!", "Nepavyko užkrauti nustatymų!\nBandyk dar kartą.", ToolTipIcon.Error);
            }
        }

        void saveCFG()
        {
            dynamic d = JObject.Parse("{number:1000, str:'string', array: [1,2,3,4,5,6]}");

            string a = d.number;
            string b = d.str;
            int c = d.array.Count;

            MessageBox.Show(a);
            MessageBox.Show(b);
            MessageBox.Show(c.ToString());
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel_city_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            switchPanels(panel1, panel_settings);
        }

        private void button_settings_load_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    LoadCFG(openFileDialog1.FileName);
            }
            catch
            {
                notifyIcon1.ShowBalloonTip(2000, "KLAIDA!", "Įvyko klaida atidarant nustatymų failą.", ToolTipIcon.Error);
            }
        }

        private void button1_settings_create_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Daugelį šio žaidimo veikėjų, modelių, paveikslėlių galima pakeisti savais.\n" +
                                "Po šios žinutės seks langų serija, kuriuose turėsi nurodyti kelią iki savo modelių.\n" +
                                "Jeigu kažkurio iš modelių nenori pakeisti, tiesiog palik tuščią laukelį ir spausk ENTER / OK.");

                string cityMapImage = Interaction.InputBox("Nurodyk kelią iki savo norimo miesto paveikslėlio:\nRekomenduojamas dydis: 800x600", "", "", -1, -1);
                string zombieModel_1 = Interaction.InputBox("Nurodyk kelią iki savo norimo 1-ojo zombio paveikslėlio:\nRekomenduojamas dydis: 31x42", "", "", -1, -1);
                string zombieModel_2 = Interaction.InputBox("Nurodyk kelią iki savo norimo 2-ojo zombio paveikslėlio:\nRekomenduojamas dydis: 31x42", "", "", -1, -1);
                string zombieModel_3 = Interaction.InputBox("Nurodyk kelią iki savo norimo 3-ojo zombio paveikslėlio:\nRekomenduojamas dydis: 31x42", "", "", -1, -1);
                string zombieModel_4 = Interaction.InputBox("Nurodyk kelią iki savo norimo 4-ojo zombio paveikslėlio:\nRekomenduojamas dydis: 31x42", "", "", -1, -1);
                string carModel_1 = Interaction.InputBox("Nurodyk kelią iki savo norimo 1-ojo mašinos paveikslėlio:\nRekomenduojamas dydis: 101x35", "", "", -1, -1);
                string carModel_2 = Interaction.InputBox("Nurodyk kelią iki savo norimo 2-ojo mašinos paveikslėlio:\nRekomenduojamas dydis: 101x35", "", "", -1, -1);
                string carModel_3 = Interaction.InputBox("Nurodyk kelią iki savo norimo 3-ojo mašinos paveikslėlio:\nRekomenduojamas dydis: 101x35", "", "", -1, -1);
                string lootboxModel = Interaction.InputBox("Nurodyk kelią iki savo norimo dėžės paveikslėlio:\nRekomenduojamas dydis: 35x35", "", "", -1, -1);
                string fireModel = Interaction.InputBox("Nurodyk kelią iki savo norimo ugnies paveikslėlio:\nRekomenduojamas dydis: 31x42", "", "", -1, -1);

                JObject Output =
        new JObject(
                    new JProperty("cityMapImage", cityMapImage),
                    new JProperty("zombieModel_1", zombieModel_1),
                    new JProperty("zombieModel_2", zombieModel_2),
                    new JProperty("zombieModel_3", zombieModel_3),
                    new JProperty("zombieModel_4", zombieModel_4),
                    new JProperty("carModel_1", carModel_1),
                    new JProperty("carModel_2", carModel_2),
                    new JProperty("carModel_3", carModel_3),
                    new JProperty("lootboxModel", lootboxModel),
                    new JProperty("fireModel", fireModel)
                    );

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JSON file|*.json";
                saveFileDialog1.Title = "Save an JSON file";
                saveFileDialog1.ShowDialog();

                string savePath = "";

                if (saveFileDialog1.FileName != "")
                {
                    File.WriteAllText(saveFileDialog1.FileName, Output.ToString());
                    savePath = saveFileDialog1.FileName;
                }


                notifyIcon1.ShowBalloonTip(2000, "Nustatymai išsaugoti!", "Sėkmingai išsaugojai nustatymus!", ToolTipIcon.Info);

                DialogResult result = MessageBox.Show("Ar norite užkrauti savo ką tik išsaugotus nustatymus?", "Patvirtinimas", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                    LoadCFG(savePath);

                switchPanels(panel_settings, panel1);
            }
            catch
            {
                notifyIcon1.ShowBalloonTip(2000, "KLAIDA!", "Nepavyko sukurti ir išsaugoti nustatymų!", ToolTipIcon.Error);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            switchPanels(panel_settings, panel1);
        }
    }
}
////https://stackoverflow.com/questions/612516/visual-studio-switch-statement-formatting