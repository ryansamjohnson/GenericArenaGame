using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class FighterEnemy : Character
    {
        public FighterEnemy()
        {
            this.attk = 45;
            this.health = 150;
            this.def = 20;
            this.spd = 12;
            this.acc = 75;
            this.luck = 15;
        }
    }
}
