using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class Poleaxe : Weapon
    {
        public Poleaxe()
        {
            this.ID = 12235;
            this.Name = "Poleaxe";
            this.WeaponType = "Lance";
            this.IsLegendary = false;
            this.ModAttk = 0;
            this.ModDef = 4;
            this.ModSpd = 3;
            this.ModAcc = 0;
            this.ModLuck = 0;
            this.BaseCost = 300;
            this.BaseDamage = 15;
        }
    }
}
