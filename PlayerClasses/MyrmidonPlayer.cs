using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class MyrmidonPlayer : Character
    {
        public MyrmidonPlayer()
        {
            this.Class = "Myrmidon";
            this.IsPromoted = false;
            this.health = 115;
            this.attk = 15;
            this.def = 10;
            this.spd = 30;
            this.acc = 90;
            this.luck = 30;
            this.UseableWeapons = new List<string>();
            this.UseableWeapons.Add("Sword");
            this.EquippedWeapon = new IronKatana();
        }

        public Character Skill(Character player, Character enemy)
        {
            Console.WriteLine("Using " + name + "'s Test Your Luck skill!");
            Console.ReadLine();
            Console.WriteLine("Heads or tails?");
            string choice = Console.ReadLine().Trim().ToLower();
            Random rand = new Random();
            int coinFlip = rand.Next(0, 2);
            if ((coinFlip == 0 && choice == "heads") || (coinFlip == 1 && choice == "tails"))
            {
                Console.WriteLine("You won the coin toss!");
                Console.ReadLine();
                int damage = enemy.Defend(player) - enemy.tempHealth;
                enemy.tempHealth -= damage * 3;
                Console.WriteLine("The enemy took " + (damage * 3) + " damage!");
                Console.ReadLine();
            }
            if ((coinFlip == 0 && choice == "tails") || (coinFlip == 1 && choice =="heads"))
            {
                Console.WriteLine("You lost the coin toss.");
                Console.ReadLine();
                Console.WriteLine("The enemy took no damage.");
                Console.ReadLine();
            }
            return enemy;
        }
    }
}
