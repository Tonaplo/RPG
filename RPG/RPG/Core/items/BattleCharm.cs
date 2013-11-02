using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Core.Items
{
    public class BattleCharm : Item
    {

        public BattleCharm(string _name, EnumItemType _itype, EnumItemQuality _iquality, int _itemLevel)
            : base(_name, _itype, _iquality, _itemLevel)
        {
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public BattleCharm()
        { }
    }
}
