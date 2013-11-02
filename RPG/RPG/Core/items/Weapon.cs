using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Core.Items
{
    public class Weapon : Item
    {
        private EnumWeaponType weaponType;

        public EnumWeaponType WeaponType
        {
            get { return weaponType; }
            set { weaponType = value; }
        }

        /// <summary>
        /// The main contructor to create a new weapon
        /// </summary>
        /// <param name="_name">The name of the Weapon</param>
        /// <param name="_itype">The Item type of the weapon. NOTE: This will always be EnumItemType.Weapon</param>
        /// <param name="_iquality">The quality of the weapon.</param>
        /// <param name="_itemLevel">The Itemlevel of the Weapon. NOTE: This will also be the base damage of the weapon</param>
        public Weapon(string _name, EnumItemType _itype, EnumItemQuality _iquality, int _itemLevel, EnumWeaponType _wtype, int _damage)
            : base(_name, _itype, _iquality, _itemLevel)
        {
            this.weaponType = _wtype;
            this.stats.Add(new UnitAttribute(EnumAttributeType.Attackdamage, _damage));
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public Weapon()
        { }
    }

    public enum EnumWeaponType
    {
        Sword,
        Axe,
        Mace,
        Staff,
        Bow,
        Dagger,
        Null
    }
}
