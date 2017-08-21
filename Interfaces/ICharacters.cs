using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    interface ICharacters
    {
        string name { get; set; }
        int health { get; set; }
        int attk { get; set; }
        int def { get; set; }
        int spd { get; set; }
        int acc { get; set; }
        int luck { get; set; }

        int Defend(Character character);
    }
}
