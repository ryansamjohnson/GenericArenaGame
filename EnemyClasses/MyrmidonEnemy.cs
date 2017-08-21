using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class MyrmidonEnemy : Character
    {
        public MyrmidonEnemy()
        {
            this.health = 115;
            this.attk = 25;
            this.def = 10;
            this.spd = 30;
            this.acc = 90;
            this.luck = 30;
        }
        
    }
}
