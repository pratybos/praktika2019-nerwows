namespace GA_1
{
    class Character
    {
        public Character()
        {
            hasKnife = false;
            hasBat = false;
            hasGlock = false;
            hasDeagle = false;
            hasSMG = false;
            hasAK47 = false;
            hasMinigun = false;
            hasBazooka = false;
        }

        //Weapons
        public bool hasKnife { get; set; }
        public bool hasBat { get; set; }
        public bool hasGlock { get; set; }
        public bool hasDeagle { get; set; }
        public bool hasSMG { get; set; }
        public bool hasAK47 { get; set; }
        public bool hasMinigun { get; set; }
        public bool hasBazooka { get; set; }
        
        public int Ammo { get; set; }
        public int Money { get; set; }
        public int Experience { get; set; }

        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/classes
    }
}
