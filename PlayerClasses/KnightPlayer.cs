using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class KnightPlayer : Character
    {
        public KnightPlayer()
        {
            this.Class = "Knight";
            this.IsPromoted = false;
            this.health = 165;
            this.attk = 20;
            this.def = 25;
            this.spd = 10;
            this.acc = 70;
            this.luck = 15;
            this.UseableWeapons = new List<string>();
            this.UseableWeapons.Add("Lance");
            this.EquippedWeapon = new IronLance();
        }

        public Character Skill(Character player, Character enemy)
        {
            Console.WriteLine("Using " + name + "'s Great Shield skill!");
            Console.ReadLine();
            player.def = player.def * 2;
            Console.WriteLine("Player defense is raised for 3 turns!");
            Console.ReadLine();
            return player;
        }
    }
}
