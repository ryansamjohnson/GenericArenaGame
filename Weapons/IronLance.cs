using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class IronLance : Weapon
    {
        public IronLance()
        {
            this.ID = 12234;
            this.Name = "Iron Lance";
            this.WeaponType = "Lance";
            this.IsLegendary = false;
            this.ModAttk = 0;
            this.ModSpd = 5;
            this.ModDef = 3;
            this.ModAcc = 0;
            this.ModLuck = 0;
            this.BaseCost = 200;
            this.BaseDamage = 15;
        }
    }
}
