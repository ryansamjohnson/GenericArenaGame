using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTest
{
    public class Weapon : IWeapon
    {
        private int _id;
        private string _name;
        private string _weaponType;
        private int _baseDamage;
        private int _baseCost;
        private bool _isLegendary;
        private int _modAttk;
        private int _modSpd;
        private int _modDef;
        private int _modAcc;
        private int _modLuck;

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
        public string WeaponType
        {
            get { return _weaponType; }
            set { _weaponType = value; }
        }
        public int BaseDamage
        {
            get { return _baseDamage; }
            set { _baseDamage = value; }
        }
        public int BaseCost
        {
            get { return _baseCost; }
            set { _baseCost = value; }
        }
        public bool IsLegendary
        {
            get { return _isLegendary; }
            set { _isLegendary = value; }
        }
        public int ModAttk
        {
            get { return _modAttk; }
            set { _modAttk = value; }
        }
        public int ModSpd
        {
            get { return _modSpd; }
            set { _modSpd = value; }
        }
        public int ModDef
        {
            get { return _modDef; }
            set { _modDef = value; }
        }
        public int ModAcc
        {
            get { return _modAcc; }
            set { _modAcc = value; }
        }
        public int ModLuck
        {
            get { return _modLuck; }
            set { _modLuck = value; }
        }
    }
}
