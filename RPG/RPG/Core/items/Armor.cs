using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Core.Items
{
    public class Armor : Item
    {
        EnumArmorType armorType;

        public EnumArmorType ArmorType
        {
            get { return armorType; }
            set { armorType = value; }
        }
        

        public Armor(string _name, EnumItemType _itype, EnumItemQuality _iquality, int _itemLevel, EnumArmorType _atype, int _armor):base(_name, _itype, _iquality, _itemLevel)
        {
            this.armorType = _atype;
            this.stats.Add(new UnitAttribute(EnumAttributeType.Armor, _armor));
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public Armor()
        { }
    }

    public enum EnumArmorType
    {
        Chestarmor,
        Legarmor,
        Headarmor,
        Null
    }
}
