using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class SmallHealthPotion : Item
    {
        public SmallHealthPotion()
        {
            this.ID = 31034;
            this.Name = "Small Health Potion";
            this.BaseCost = 25;
            this.Quantity = 1;
        }
        public override Character Effect(Character player)
        {
            player.tempHealth += 100;
            if (player.tempHealth > player.health)
            {
                player.tempHealth = player.health;
            }
            this.Quantity -= 1;
            return player;
        }
    }
}
