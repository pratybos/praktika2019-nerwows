namespace GA_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bContinueOldGame = new System.Windows.Forms.Button();
            this.bStartNewGame = new System.Windows.Forms.Button();
            this.panelHUD = new System.Windows.Forms.Panel();
            this.picturebox_heart1 = new System.Windows.Forms.PictureBox();
            this.picturebox_heart2 = new System.Windows.Forms.PictureBox();
            this.picturebox_heart3 = new System.Windows.Forms.PictureBox();
            this.picturebox_heart4 = new System.Windows.Forms.PictureBox();
            this.picturebox_heart5 = new System.Windows.Forms.PictureBox();
            this.picturebox_gold = new System.Windows.Forms.PictureBox();
            this.label_gold = new System.Windows.Forms.Label();
            this.picturebox_ammo = new System.Windows.Forms.PictureBox();
            this.label_ammo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_cVagis = new System.Windows.Forms.Button();
            this.button_cPolicininkas = new System.Windows.Forms.Button();
            this.button_cGaisrininkas = new System.Windows.Forms.Button();
            this.button_cMedikas = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelHUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_heart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_heart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_heart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_heart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_heart5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_gold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_ammo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::GA_1.Properties.Resources.zombieland;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bContinueOldGame);
            this.panel1.Controls.Add(this.bStartNewGame);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 561);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(96, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Zombieland";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bContinueOldGame
            // 
            this.bContinueOldGame.Location = new System.Drawing.Point(256, 309);
            this.bContinueOldGame.Name = "bContinueOldGame";
            this.bContinueOldGame.Size = new System.Drawing.Size(327, 75);
            this.bContinueOldGame.TabIndex = 1;
            this.bContinueOldGame.Text = "Tęsti seną žaidimą";
            this.bContinueOldGame.UseVisualStyleBackColor = true;
            this.bContinueOldGame.Click += new System.EventHandler(this.bContinueOldGame_Click);
            // 
            // bStartNewGame
            // 
            this.bStartNewGame.Location = new System.Drawing.Point(256, 228);
            this.bStartNewGame.Name = "bStartNewGame";
            this.bStartNewGame.Size = new System.Drawing.Size(327, 75);
            this.bStartNewGame.TabIndex = 0;
            this.bStartNewGame.Text = "Pradėti naują žaidimą";
            this.bStartNewGame.UseVisualStyleBackColor = true;
            this.bStartNewGame.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelHUD
            // 
            this.panelHUD.Controls.Add(this.label_ammo);
            this.panelHUD.Controls.Add(this.picturebox_ammo);
            this.panelHUD.Controls.Add(this.label_gold);
            this.panelHUD.Controls.Add(this.picturebox_gold);
            this.panelHUD.Controls.Add(this.picturebox_heart5);
            this.panelHUD.Controls.Add(this.picturebox_heart4);
            this.panelHUD.Controls.Add(this.picturebox_heart3);
            this.panelHUD.Controls.Add(this.picturebox_heart2);
            this.panelHUD.Controls.Add(this.picturebox_heart1);
            this.panelHUD.Location = new System.Drawing.Point(221, 499);
            this.panelHUD.Name = "panelHUD";
            this.panelHUD.Size = new System.Drawing.Size(560, 59);
            this.panelHUD.TabIndex = 0;
            // 
            // picturebox_heart1
            // 
            this.picturebox_heart1.Image = global::GA_1.Properties.Resources.heart;
            this.picturebox_heart1.Location = new System.Drawing.Point(287, 3);
            this.picturebox_heart1.Name = "picturebox_heart1";
            this.picturebox_heart1.Size = new System.Drawing.Size(49, 50);
            this.picturebox_heart1.TabIndex = 0;
            this.picturebox_heart1.TabStop = false;
            // 
            // picturebox_heart2
            // 
            this.picturebox_heart2.Image = global::GA_1.Properties.Resources.heart;
            this.picturebox_heart2.Location = new System.Drawing.Point(342, 3);
            this.picturebox_heart2.Name = "picturebox_heart2";
            this.picturebox_heart2.Size = new System.Drawing.Size(49, 50);
            this.picturebox_heart2.TabIndex = 1;
            this.picturebox_heart2.TabStop = false;
            // 
            // picturebox_heart3
            // 
            this.picturebox_heart3.Image = global::GA_1.Properties.Resources.heart;
            this.picturebox_heart3.Location = new System.Drawing.Point(397, 3);
            this.picturebox_heart3.Name = "picturebox_heart3";
            this.picturebox_heart3.Size = new System.Drawing.Size(49, 50);
            this.picturebox_heart3.TabIndex = 2;
            this.picturebox_heart3.TabStop = false;
            // 
            // picturebox_heart4
            // 
            this.picturebox_heart4.Image = global::GA_1.Properties.Resources.heart;
            this.picturebox_heart4.Location = new System.Drawing.Point(452, 3);
            this.picturebox_heart4.Name = "picturebox_heart4";
            this.picturebox_heart4.Size = new System.Drawing.Size(49, 50);
            this.picturebox_heart4.TabIndex = 3;
            this.picturebox_heart4.TabStop = false;
            // 
            // picturebox_heart5
            // 
            this.picturebox_heart5.Image = global::GA_1.Properties.Resources.heart;
            this.picturebox_heart5.Location = new System.Drawing.Point(507, 3);
            this.picturebox_heart5.Name = "picturebox_heart5";
            this.picturebox_heart5.Size = new System.Drawing.Size(49, 50);
            this.picturebox_heart5.TabIndex = 4;
            this.picturebox_heart5.TabStop = false;
            // 
            // picturebox_gold
            // 
            this.picturebox_gold.Image = global::GA_1.Properties.Resources.gold;
            this.picturebox_gold.Location = new System.Drawing.Point(166, 3);
            this.picturebox_gold.Name = "picturebox_gold";
            this.picturebox_gold.Size = new System.Drawing.Size(49, 47);
            this.picturebox_gold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox_gold.TabIndex = 5;
            this.picturebox_gold.TabStop = false;
            // 
            // label_gold
            // 
            this.label_gold.AutoSize = true;
            this.label_gold.Location = new System.Drawing.Point(221, 20);
            this.label_gold.Name = "label_gold";
            this.label_gold.Size = new System.Drawing.Size(35, 13);
            this.label_gold.TabIndex = 6;
            this.label_gold.Text = "label2";
            this.label_gold.Click += new System.EventHandler(this.label2_Click);
            // 
            // picturebox_ammo
            // 
            this.picturebox_ammo.Image = global::GA_1.Properties.Resources.bullet;
            this.picturebox_ammo.Location = new System.Drawing.Point(3, 3);
            this.picturebox_ammo.Name = "picturebox_ammo";
            this.picturebox_ammo.Size = new System.Drawing.Size(49, 47);
            this.picturebox_ammo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox_ammo.TabIndex = 7;
            this.picturebox_ammo.TabStop = false;
            // 
            // label_ammo
            // 
            this.label_ammo.AutoSize = true;
            this.label_ammo.Location = new System.Drawing.Point(58, 20);
            this.label_ammo.Name = "label_ammo";
            this.label_ammo.Size = new System.Drawing.Size(35, 13);
            this.label_ammo.TabIndex = 8;
            this.label_ammo.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(665, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pasirinkite (spustelėkite) veikėją, su kuriuo tesite visą likusį žaidimą:";
            // 
            // button_cVagis
            // 
            this.button_cVagis.BackColor = System.Drawing.Color.White;
            this.button_cVagis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cVagis.Image = global::GA_1.Properties.Resources.vagis2;
            this.button_cVagis.Location = new System.Drawing.Point(10, 126);
            this.button_cVagis.Name = "button_cVagis";
            this.button_cVagis.Size = new System.Drawing.Size(186, 253);
            this.button_cVagis.TabIndex = 2;
            this.button_cVagis.UseVisualStyleBackColor = false;
            this.button_cVagis.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button_cPolicininkas
            // 
            this.button_cPolicininkas.BackColor = System.Drawing.Color.White;
            this.button_cPolicininkas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cPolicininkas.Image = global::GA_1.Properties.Resources.policija;
            this.button_cPolicininkas.Location = new System.Drawing.Point(395, 126);
            this.button_cPolicininkas.Name = "button_cPolicininkas";
            this.button_cPolicininkas.Size = new System.Drawing.Size(186, 253);
            this.button_cPolicininkas.TabIndex = 3;
            this.button_cPolicininkas.UseVisualStyleBackColor = false;
            this.button_cPolicininkas.Click += new System.EventHandler(this.button_cPolicininkas_Click);
            // 
            // button_cGaisrininkas
            // 
            this.button_cGaisrininkas.BackColor = System.Drawing.Color.White;
            this.button_cGaisrininkas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cGaisrininkas.Image = global::GA_1.Properties.Resources.ugniagesys;
            this.button_cGaisrininkas.Location = new System.Drawing.Point(587, 126);
            this.button_cGaisrininkas.Name = "button_cGaisrininkas";
            this.button_cGaisrininkas.Size = new System.Drawing.Size(186, 253);
            this.button_cGaisrininkas.TabIndex = 4;
            this.button_cGaisrininkas.UseVisualStyleBackColor = false;
            this.button_cGaisrininkas.Click += new System.EventHandler(this.button_cGaisrininkas_Click);
            // 
            // button_cMedikas
            // 
            this.button_cMedikas.BackColor = System.Drawing.Color.White;
            this.button_cMedikas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cMedikas.Image = global::GA_1.Properties.Resources.medikas;
            this.button_cMedikas.Location = new System.Drawing.Point(202, 126);
            this.button_cMedikas.Name = "button_cMedikas";
            this.button_cMedikas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_cMedikas.Size = new System.Drawing.Size(186, 253);
            this.button_cMedikas.TabIndex = 5;
            this.button_cMedikas.UseVisualStyleBackColor = false;
            this.button_cMedikas.Click += new System.EventHandler(this.button_cMedikas_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Klasė: Vagis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(235, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Klasė: Medikas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(419, 392);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Klasė: Policininkas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(41, 436);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 60);
            this.label6.TabIndex = 9;
            this.label6.Text = "Turi:\r\n• Glock pistoletą\r\n• Peilį\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(235, 436);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 40);
            this.label7.TabIndex = 10;
            this.label7.Text = "Turi:\r\n• Vaistinėlę\r\n";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(419, 436);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 60);
            this.label8.TabIndex = 11;
            this.label8.Text = "Turi:\r\n• Kevlaras\r\n• Bananą";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(614, 392);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Klasė: Gaisrininkas";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(614, 436);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 40);
            this.label9.TabIndex = 13;
            this.label9.Text = "Turi:\r\n• Kirvis";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button_cMedikas);
            this.panel2.Controls.Add(this.button_cGaisrininkas);
            this.panel2.Controls.Add(this.button_cPolicininkas);
            this.panel2.Controls.Add(this.button_cVagis);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panelHUD);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 561);
            this.panel2.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "zombieLand";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelHUD.ResumeLayout(false);
            this.panelHUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_heart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_heart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_heart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_heart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_heart5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_gold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_ammo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bStartNewGame;
        private System.Windows.Forms.Button bContinueOldGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_cMedikas;
        private System.Windows.Forms.Button button_cGaisrininkas;
        private System.Windows.Forms.Button button_cPolicininkas;
        private System.Windows.Forms.Button button_cVagis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelHUD;
        private System.Windows.Forms.Label label_ammo;
        private System.Windows.Forms.PictureBox picturebox_ammo;
        private System.Windows.Forms.Label label_gold;
        private System.Windows.Forms.PictureBox picturebox_gold;
        private System.Windows.Forms.PictureBox picturebox_heart5;
        private System.Windows.Forms.PictureBox picturebox_heart4;
        private System.Windows.Forms.PictureBox picturebox_heart3;
        private System.Windows.Forms.PictureBox picturebox_heart2;
        private System.Windows.Forms.PictureBox picturebox_heart1;
    }
}

