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

            charID = -1;
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
        
        public int Ammo { get; set; }
        public int Money { get; set; }
        public int Experience { get; set; }
        public int Health { get; set; }
        public int healthPack { get; set; }

        public int currentlyEqquiped { get; set; }

        public int charID = -1; //0 - vagis, 1 - medikas, 2 - policija, 3 - gaisrine, -1 error

        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/classes
    }
}
