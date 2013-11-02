using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Core
{
    public class Item
    {
        #region Fields
        string itemName;
        int itemLevel;
        EnumItemType itemType;
        EnumItemQuality itemQuality;
        public List<UnitAttribute> stats = new List<UnitAttribute>();
        #endregion

        #region Properties

        public string InventoryDisplay
        {
            get 
            {
                string temp = this.itemName; 
                return temp;
                
            }
        }

        public string ItemName
        {
            get { return itemName;}
            set {itemName = value;}
        }

        public EnumItemType ItemType
        {
            get { return itemType; }
            set { itemType = value; }
        }

        public EnumItemQuality ItemQuality
        {
            get { return itemQuality; }
            set { itemQuality = value; }
        }

        public int ItemLevel
        {
            get { return itemLevel; }
            set { itemLevel = value; }
        }
        
        #endregion

        public Item(string _name, EnumItemType _itype, EnumItemQuality _iquality, int _itemLevel)
        {
            this.itemName = _name;
            this.itemType = _itype;
            this.itemLevel = _itemLevel;
            this.itemQuality = _iquality;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public Item()
        {
        }

        /// <summary>
        /// This function adds an Attribute to an item. Weapons and Armor can have 3 Attribute + their AttackDamage/Armor. BattleCharms can have 4 Attributes
        /// </summary>
        /// <param name="type">The type of Attribute being added</param>
        /// <param name="value">The value of the Attribute being added</param>
        public void AddAttributeToItem(EnumAttributeType type, int value)
        {
            if (value == 0)
                value = 1;

            if (this.stats.Count < 4 && !this.stats.Any(p => p.Type.Equals(type)))
                this.stats.Add(new UnitAttribute(type, value));
            else if (this.stats.Count >= 4)
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("This item has too many attributes. The item is called " + this.itemName);
                mes.ShowDialog();
            }
        }

        #region Functions

        #endregion
    }
}
