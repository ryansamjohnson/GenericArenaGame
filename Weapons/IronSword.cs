using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class IronSword : Weapon
    {
        public IronSword()
        {
            this.ID = 10234;
            this.Name = "Iron Sword";
            this.WeaponType = "Sword";
            this.IsLegendary = false;
            this.ModAttk = 0;
            this.ModDef = 5;
            this.ModSpd = 0;
            this.ModAcc = 0;
            this.ModLuck = 0;
            this.BaseCost = 200;
            this.BaseDamage = 12;
        }
    }
}
