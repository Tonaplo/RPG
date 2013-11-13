using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Core
{
    public class Unit
    {
        #region Fields

        string unitName;
        int unitLevel;
        UnitType typeOfUnit;
        System.Drawing.Image portrait;
        UnitAttribute baseHP = new UnitAttribute(EnumAttributeType.Health);
        UnitAttribute buffedHP = new UnitAttribute(EnumAttributeType.Health);
        UnitAttribute currentHP = new UnitAttribute(EnumAttributeType.Health);
        //The Passive abilities, Active Abilities, Debuffs and DoTs/HoTs of the unit.
        //Passive abilites are applied as soon as combat begins.
        //Debuffs are applid during combat as they are taken.
        //DoTs/HoTs tick after a turn of a unit - HoTs are applied before DoTs
        //DoTs/HoTs and Debuffs are defined in the unit class.
        List<Abilities.ActiveAbility> unitActiveAbilities;
        List<Abilities.ActiveAbility> unitPassiveAbilities;
        List<Abilities.BuffsAndDebuffs> unitBuffsAndDebuffs;
        // TODO: Need to add passives and DHoTs
        // The Inventory and Gear of the Character.

        #endregion

        #region Properties

        public string UnitName
        {
            get { return unitName; }
            set { unitName = value; }
        }

        public int UnitLevel
        {
            get { return unitLevel; }
            set
            {
                if (value >= 0)
                    unitLevel = value;
                else
                    unitLevel = 1;

            }
        }

        public UnitType TypeOfUnit
        {
            get { return typeOfUnit; }
            set { typeOfUnit = value; }
        }

        public System.Drawing.Image Portrait
        {
            get { return portrait; }
            set { portrait = value; }
        }

        public UnitAttribute BaseHP
        {
            get { return baseHP; }
            set {
                if (value.IntValue < 1)
                    baseHP.IntValue = 1;
                else
                    baseHP = value; 
                }
        }

        public UnitAttribute BuffedHP
        {
            get { return buffedHP; }
            set 
            {
                if (value.IntValue < 1)
                    buffedHP.IntValue = 1;
                else
                    buffedHP = value; 
            }

        }

        public UnitAttribute CurrentHP
        {
            get { return currentHP; }
            set 
            {
                if (value.IntValue < 1)
                    currentHP.IntValue = 1;
                else if (value.IntValue > buffedHP.IntValue)
                {
                     int temp = buffedHP.IntValue;
                     currentHP.IntValue = temp;
                }
                else
                    currentHP = value; 
            }
        }

        public List<Abilities.ActiveAbility> UnitPassiveAbilities
        {
            get { return unitPassiveAbilities; }
            set { unitPassiveAbilities = value; }
        }

        public List<Abilities.ActiveAbility> UnitActiveAbilities
        {
            get { return unitActiveAbilities; }
            set { unitActiveAbilities = value; }
        }

        public List<Abilities.BuffsAndDebuffs> UnitBuffsAndDebuffs
        {
            get { return unitBuffsAndDebuffs; }
            set { unitBuffsAndDebuffs = value; }
        }

        #endregion

        public Unit(string _name, int _level, int _basehp, int _curhp)
        {
            this.unitName = _name;
            this.UnitLevel = _level;
            this.baseHP.IntValue = _basehp;
            this.buffedHP.IntValue = _basehp;
            this.currentHP.IntValue = _curhp;
            this.unitActiveAbilities = new List<Abilities.ActiveAbility>();
            this.unitPassiveAbilities = new List<Abilities.ActiveAbility>();
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public Unit()
        { }

        #region Functions

        #region Ability Adding and Removal
        /// <summary>
        /// This function adds an Active Ability to the unit
        /// </summary>
        /// <param name="acab">The active ability to be added to the unit</param>
        public void AddActiveAbility(Abilities.ActiveAbility acab)
        {
            if (this.TypeOfUnit == UnitType.Character && this.unitActiveAbilities.Count() == 4)
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("You have 4 active abilities already!" + Environment.NewLine + "Click 'Change Abilities' to change your active ones!");
                mes.ShowDialog();
            }
            else
            {
                this.unitActiveAbilities.Add(acab);
            }
        }

        /// <summary>
        /// This function removes an actice ability from a unit and reorders the remaining abilities.
        /// </summary>
        /// <param name="acab">The ability to be removed</param>
        public void RemoveActiveAbility(Abilities.ActiveAbility acab)
        {
            if (this.unitActiveAbilities.Contains(acab))
            {
                this.unitActiveAbilities.Remove(acab);
            }
        }

        /// <summary>
        /// This function adds a Passive Ability to the character
        /// </summary>
        /// <param name="acab">The passive ability to be added to the character</param>
        public void AddPassiveAbility(Abilities.ActiveAbility pasab)
        {
                this.unitPassiveAbilities.Add(pasab);
        }

        /// <summary>
        /// This function removes an passive ability from a character and reorders the remaining abilities.
        /// </summary>
        /// <param name="acab">The ability to be removed</param>
        public void RemovePassiveAbility(Abilities.ActiveAbility paab)
        {
            if (this.unitPassiveAbilities.Contains(paab))
            {
                this.unitPassiveAbilities.Remove(paab);
            }
        }
        #endregion

        #endregion

        public enum UnitType
        {
            Character,
            Npc
        }
    }
}
