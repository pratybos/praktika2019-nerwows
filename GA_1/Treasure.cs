using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_1
{
    class Treasure
    {
        public Treasure()
        {
            //Treasures[0] = "Deagle";
            //Treasures[1] = "SMG";
            //Treasures[2] = "AK47";
            //Treasures[3] = "MiniGun";
            //Treasures[4] = "Bazooka";
            //Treasures[5] = "Kulkų";
            //Treasures[6] = "Aukso";
            //Treasures[7] = "Patirties taškų";
            //Treasures[8] = "Vaistinėlę";

            Treasures = new string[] { "Deagle", "SMG", "AK47", "MiniGun", "Bazooka", "Kulkų", "Aukso", "Patirties taškų", "Vaistinėlę" };
        }

        public string[] Treasures { get; }
    }
}
