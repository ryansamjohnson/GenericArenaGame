using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class IronKatana : Weapon
    {
        public IronKatana()
        {
            this.ID = 10235;
            this.Name = "Iron Katana";
            this.WeaponType = "Sword";
            this.IsLegendary = false;
            this.ModAttk = 0;
            this.ModSpd = 10;
            this.ModDef = 0;
            this.ModAcc = 0;
            this.ModLuck = 0;
            this.BaseCost = 300;
            this.BaseDamage = 6;
        }
    }
}
