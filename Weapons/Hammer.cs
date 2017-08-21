using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class Hammer : Weapon
    {
        public Hammer()
        {
            this.ID = 11235;
            this.Name = "Iron Hammer";
            this.WeaponType = "Axe";
            this.IsLegendary = false;
            this.ModAttk = 0;
            this.ModDef = 8;
            this.ModSpd = 0;
            this.ModAcc = 0;
            this.ModLuck = 0;
            this.BaseCost = 250;
            this.BaseDamage = 23;
        }
    }
}
