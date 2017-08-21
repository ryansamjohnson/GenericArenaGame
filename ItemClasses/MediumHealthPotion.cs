using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class MediumHealthPotion : Item
    {
        public MediumHealthPotion()
        {
            this.ID = 31035;
            this.Name = "Medium Health Potion";
            this.BaseCost = 50;
            this.Quantity = 1;
        }
        public override Character Effect(Character player)
        {
            player.tempHealth += 200;
            if (player.tempHealth > player.health)
            {
                player.tempHealth = player.health;
            }
            this.Quantity -= 1;
            return player;
        }
    }
}
