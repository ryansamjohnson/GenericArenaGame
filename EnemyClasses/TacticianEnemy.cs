using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class TacticianEnemy : Character
    {
        public TacticianEnemy()
        {
            this.health = 140;
            this.attk = 20;
            this.def = 20;
            this.spd = 25;
            this.acc = 75;
            this.luck = 25;
        }
    }
}
