using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class IronAxe : Weapon
    {
        public IronAxe()
        {
            this.ID = 11234;
            this.Name = "Iron Axe";
            this.WeaponType = "Axe";
            this.IsLegendary = false;
            this.ModAttk = 0;
            this.ModSpd = 0;
            this.ModDef = 6;
            this.ModAcc = 0;
            this.ModLuck = 0;
            this.BaseCost = 250;
            this.BaseDamage = 15;
        }
    }
}
