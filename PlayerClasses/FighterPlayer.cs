using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class FighterPlayer : Character
    {
        public FighterPlayer()
        {
            this.Class = "Fighter";
            this.IsPromoted = false;
            this.attk = 25;
            this.health = 150;
            this.def = 20;
            this.spd = 12;
            this.acc = 75;
            this.luck = 15;
            this.UseableWeapons = new List<string>();
            this.UseableWeapons.Add("Axe");
            this.EquippedWeapon = new IronAxe();
        }

        public Character FighterSkill(Character player, Character enemy)
        {
            int tempAttk = player.attk;
            player.attk += tempAttk;
            Console.WriteLine("Using " + player.name + "'s Overwhelm attack!");
            Console.ReadLine();
            Console.WriteLine("Attack is raised by " + tempAttk + "!");
            Console.ReadLine();
            int damage = enemy.Defend(player) - enemy.tempHealth;
            enemy.tempHealth -= damage;
            Console.WriteLine("The enemy took " + damage + " damage!");
            return enemy;
        }
    }
}
