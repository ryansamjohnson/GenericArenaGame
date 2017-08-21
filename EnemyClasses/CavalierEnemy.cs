using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class CavalierEnemy : Character
    {
        public CavalierEnemy()
        {
            this.health = 145;
            this.attk = 35;
            this.def = 15;
            this.spd = 30;
            this.acc = 80;
            this.luck = 25;
        }
    }
}
