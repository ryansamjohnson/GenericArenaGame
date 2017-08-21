using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    interface IWeapon
    {
        int ID { get; set; }
        string Name { get; set; }
        string WeaponType { get; set; }
        int BaseDamage { get; set; }
        int BaseCost { get; set; }
        bool IsLegendary { get; set; }
        int ModAttk { get; set; }
        int ModSpd { get; set; }
        int ModDef { get; set; }
        int ModAcc { get; set; }
        int ModLuck { get; set; }
    }
}
