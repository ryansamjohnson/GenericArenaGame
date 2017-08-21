using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class CavalierPlayer : Character
    {
        public CavalierPlayer()
        {
            this.Class = "Cavalier";
            this.IsPromoted = false;
            this.health = 145;
            this.attk = 25;
            this.def = 15;
            this.spd = 25;
            this.acc = 80;
            this.luck = 25;
            this.UseableWeapons = new List<string>();
            this.UseableWeapons.Add("Lance");
            this.UseableWeapons.Add("Sword");
            Console.WriteLine("What kind of weapon do you want? Lance/Sword");
            string response = Console.ReadLine().Trim().ToLower();
            if (response == "lance")
                this.EquippedWeapon = new IronLance();
            else if (response == "sword")
                this.EquippedWeapon = new IronSword();
            else
                Console.WriteLine("Couldn't read what weapon you wanted. You got a lance.");
                this.EquippedWeapon = new IronLance();
        }
        
        public Character Skill(Character player, Character enemy)
        {
            Console.WriteLine("Using " + name + "'s Swift Movement skill!");
            Console.ReadLine();
            player.spd = player.spd * 2;
            Console.WriteLine("Player speed is raised for 3 turns!");
            Console.ReadLine();
            return player;
        }
    }
}
