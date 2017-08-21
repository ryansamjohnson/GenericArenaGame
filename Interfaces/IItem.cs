using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public interface IItem
    {
        int ID { get; set; }
        string Name { get; set; }
        int BaseCost { get; set; }
        double SellPrice { get; }
        int Quantity { get; set; }
        Character Effect(Character character);
    }
}
