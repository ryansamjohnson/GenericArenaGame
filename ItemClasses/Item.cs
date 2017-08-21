using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class Item : IItem
    {
        private int _id;
        private string _name;
        private int _baseCost;
        private int _quantity;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int BaseCost
        {
            get { return _baseCost; }
            set { _baseCost = value; }
        }
        public double SellPrice
        {
            get { return Math.Floor((double)(this.BaseCost / 2)); }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public virtual Character Effect(Character player)
        {
            return player;
        }
    }
}
