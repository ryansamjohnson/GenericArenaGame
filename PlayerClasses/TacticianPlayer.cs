using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class TacticianPlayer : Character
    {
        public TacticianPlayer()
        {
            this.Class = "Tactician";
            this.IsPromoted = false;
            this.health = 140;
            this.attk = 20;
            this.def = 20;
            this.spd = 25;
            this.acc = 75;
            this.luck = 25;
            this.UseableWeapons = new List<string>();
            this.UseableWeapons.Add("Sword");
            this.EquippedWeapon = new IronSword();
        }

        public Character Skill(Character player, Character enemy)
        {
            Console.WriteLine("Using " + name + "'s Strategy skill!");
            Console.ReadLine();
            int tempAttk = enemy.attk / 2;
            int tempAcc = enemy.acc / 2;
            int tempSpd = enemy.spd / 2;
            player.attk += tempAttk;
            player.def += tempAcc;
            player.spd += tempSpd;
            Console.WriteLine(name + " is using the enemy's weakness to attack.");
            Console.ReadLine();
            int damage = enemy.Defend(player) - enemy.tempHealth;
            enemy.tempHealth -= damage;
            Console.WriteLine("The enemy took " + damage + " damage!");
            Console.ReadLine();
            return enemy;
        }
    }
}
