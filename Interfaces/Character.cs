using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class Character : ICharacters
    {
        private string _name;
        private string _class;
        private bool _isPromoted;
        private int _health;
        private int _tempHealth;
        private int _attk;
        private int _def;
        private int _spd;
        private int _acc;
        private int _luck;
        private int _energy;
        private int _gold;
        private List<Item> _inventory;
        private List<Weapon> _invWeapons;
        private List<string> _usableWeapons;
        private Weapon _equippedWeapon;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Class
        {
            get { return _class; }
            set { _class = value; }
        }
        public bool IsPromoted
        {
            get { return _isPromoted; }
            set { _isPromoted = value; }
        }
        public int health
        {
            get { return _health; }
            set { _health = value; }
        }
        public int tempHealth
        {
            get { return _tempHealth; }
            set { _tempHealth = value; }
        }
        public int attk
        {
            get { return _attk; }
            set { _attk = value; }
        }
        public int def
        {
            get { return _def; }
            set { _def = value; }
        }
        public int spd
        {
            get { return _spd; }
            set { _spd = value; }
        }
        public int luck
        {
            get { return _luck; }
            set { _luck = value; }
        }
        public int acc
        {
            get { return _acc; }
            set { _acc = value; }
        }

        public int Defend(Character attacker)
        {
            int newHealth = tempHealth + def - attacker.attk;
            return newHealth;
        }
        public int energy
        {
            get { return _energy; }
            set { _energy = value; }
        }
        public int gold
        {
            get { return _gold; }
            set { _gold = value; }
        }
        public List<Item> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        public List<Weapon> InvWeapons
        {
            get { return _invWeapons; }
            set { _invWeapons = value; }
        }
        public List<string> UseableWeapons
        {
            get { return _usableWeapons; }
            set { _usableWeapons = value; }
        }
        public Weapon EquippedWeapon
        {
            get { return _equippedWeapon; }
            set { _equippedWeapon = value; }
        }

        public int CalculateHit(Character defender)
        {
            int Hit = acc + spd - (defender.spd + defender.luck / 10);
            return Hit;
        }

        public void DisplayStats()
        {
            Console.WriteLine(name + " current stats are:");
            Console.WriteLine("Health:      " + health);
            Console.WriteLine("Attack:      " + attk);
            Console.WriteLine("Defense:     " + def);
            Console.WriteLine("Speed:       " + spd);
            Console.WriteLine("Luck:        " + luck);
            Console.WriteLine("Accuracy:    " + acc);
            Console.WriteLine("Gold:        " + gold);
            Console.WriteLine("Weapon:      " + EquippedWeapon.Name);
            Console.ReadLine();
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Current weapon: " + this.EquippedWeapon);
            Console.WriteLine();
            Console.WriteLine("Weapons:");
            foreach (Weapon weapon in this.InvWeapons)
            {
                Console.WriteLine(weapon.Name);
            }
            if (this.Inventory != null)
            {
                foreach (Item item in this.Inventory)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine("No items!");
            }
            Console.ReadLine();
        }
    }
}
