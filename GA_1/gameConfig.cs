using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_1
{
    class gameConfig
    {
        public gameConfig()
        {
            //new Random(DateTime.Now.Millisecond).Next(1, 5);

            EXPERIENCE_CAR_CLICK = 100; //Rare
            EXPERIENCE_BOX_CLICK = 200; //Even more rare
            EXPERIENCE_ZOMBIE_CLICK = 5; //Often, casual

            EXPERIENCE_BOX_REWARDGIVES = new Random(DateTime.Now.Millisecond).Next(1, 999);

            MONEY_CAR_CLICK = 250;
            MONEY_BOX_CLICK = 1000;
            MONEY_ZOMBIE_CLICK = 15;

            AMMO_BOX_CLICK = 10;

            HEALTHPACK_BOX_CLICK += 4;


            SHOP_DEAGLE_PRICE = 150;
            SHOP_SMG_PRICE = 300;
            SHOP_AK47_PRICE = 600;
            SHOP_MINIGUN_PRICE = 1200;
            SHOP_BAZOOKA_PRICE = 2400;
            SHOP_AMMO_PRICE = 15;
        }

        public int EXPERIENCE_CAR_CLICK { get; }
        public int EXPERIENCE_BOX_CLICK { get; }
        public int EXPERIENCE_BOX_REWARDGIVES { get; }
        public int EXPERIENCE_ZOMBIE_CLICK { get; }

        public int MONEY_CAR_CLICK { get; }
        public int MONEY_BOX_CLICK { get; }
        public int MONEY_ZOMBIE_CLICK { get; }

        public int AMMO_BOX_CLICK { get; }

        public int HEALTHPACK_BOX_CLICK { get; }

        public int Health { get; }
        public int healthPack { get; }



        public int SHOP_DEAGLE_PRICE { get; }
        public int SHOP_SMG_PRICE { get; }
        public int SHOP_AK47_PRICE { get; }
        public int SHOP_MINIGUN_PRICE { get; }
        public int SHOP_BAZOOKA_PRICE { get; }
        public int SHOP_AMMO_PRICE { get; }
    }
}
