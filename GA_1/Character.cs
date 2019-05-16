namespace GA_1
{
    class Character
    {
        public Character()
        {
            hasKnife = false;
            hasBat = false;
            hasAxe = false;
            hasGlock = false;
            hasDeagle = false;
            hasSMG = false;
            hasAK47 = false;
            hasMinigun = false;
            hasBazooka = false;
            currentlyEqquiped = -1;

            Ammo = 0;
            Money = 0;
            Experience = 0;
            Health = 5;

            carCount = 0;
            killCount = 0;
            lootboxCount = 0;
            healthPack = 0;

            charID = -1;

            Name = "";

            achievement_Welcome = false;
            achievement_firstTimeCity = false;
            achievement_firstTimeShop = false;
            achievement_firstTimeInventory = false;
            achievement_firstCar = false;
            achievement_firstZombie = false;
            achievement_firstLootbox = false;
            achievement_firstBuy = false;
            achievement_firstSell = false;
            achievement_firstEquip = false;
            achievement_firstHeavyWeapon = false;
            achievement_5car = false;
            achievement_5zombie = false;
            achievement_5lootbox = false;
            achievement_blastingFire = false;
        }

        //Weapons
        public bool hasKnife { get; set; } //0
        public bool hasBat { get; set; } //1
        public bool hasAxe { get; set; } //2
        public bool hasGlock { get; set; } //3
        public bool hasDeagle { get; set; } //4
        public bool hasSMG { get; set; } //5
        public bool hasAK47 { get; set; } //6
        public bool hasMinigun { get; set; } //7
        public bool hasBazooka { get; set; } //8

        //
        public string Name { get; set; }

        public int Ammo { get; set; }
        public int Money { get; set; }
        public int Experience { get; set; }
        public int Health { get; set; }
        public int healthPack { get; set; }
        public int killCount { get; set; }
        public int lootboxCount { get; set; }
        public int carCount { get; set; }

        public int currentlyEqquiped { get; set; }

        public int charID = -1; //0 - vagis, 1 - medikas, 2 - policija, 3 - gaisrine, -1 error

        public bool achievement_Welcome { get; set; }
        public bool achievement_firstTimeCity { get; set; }
        public bool achievement_firstTimeShop { get; set; }
        public bool achievement_firstTimeInventory { get; set; }
        public bool achievement_firstCar { get; set; }
        public bool achievement_firstZombie { get; set; }
        public bool achievement_firstLootbox { get; set; }
        public bool achievement_firstBuy { get; set; }
        public bool achievement_firstSell { get; set; }
        public bool achievement_firstEquip { get; set; }
        public bool achievement_firstHeavyWeapon { get; set; }
        public bool achievement_5car { get; set; }
        public bool achievement_5zombie { get; set; }
        public bool achievement_5lootbox { get; set; }
        public bool achievement_blastingFire { get; set; }


        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/classes
    }
}
