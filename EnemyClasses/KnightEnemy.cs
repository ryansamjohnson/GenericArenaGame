using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class KnightEnemy : Character
    {
        public KnightEnemy()
        {
            this.health = 165;
            this.attk = 40;
            this.def = 25;
            this.spd = 10;
            this.acc = 60;
            this.luck = 15;
        }
    }
}
