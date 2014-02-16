using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using RPG.Core.Units;

namespace RPG.Core.Abilities
{
    public class BuffsAndDebuffs : Ability
    {
        public BuffsAndDebuffs(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char ,_name, _description, _icon, _classReq)
        {

        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public BuffsAndDebuffs()
        { }
    }

    #region All Classes Buffs
    public class Empowered : BuffsAndDebuffs
    {
        public Empowered(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            int buff = (int)(_char.BuffedAgility.IntValue*0.2);
            string stat = "Agility";

            if(_char.BuffedAgility.IntValue < _char.BuffedIntellingence.IntValue)
            {
                buff = (int)(_char.BuffedIntellingence.IntValue*0.2);
                stat = "Intellect";
                if(_char.BuffedIntellingence.IntValue < _char.BuffedStrength.IntValue)
                {
                    buff = (int)(_char.BuffedStrength.IntValue*0.2);
                    stat = "Strength";
                }
            }
            else if(_char.BuffedAgility.IntValue < _char.BuffedStrength.IntValue)
            {
                buff = (int)(_char.BuffedStrength.IntValue * 0.2);
                stat = "Strength";
            }

            this.AbilityName = "Empowered";
            this.Description = _char.UnitName + " has had its " + stat + " increased by " + buff + "!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public Empowered()
        { }
    }

    public class Invigorated : BuffsAndDebuffs
    {
        public Invigorated(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            int buff = (int)(_char.BuffedAgility.IntValue * 0.2);
            string stat = "Agility";

            if (_char.BuffedAgility.IntValue < _char.BuffedIntellingence.IntValue)
            {
                buff = (int)(_char.BuffedIntellingence.IntValue * 0.2);
                stat = "Intellect";
                if (_char.BuffedIntellingence.IntValue < _char.BuffedStrength.IntValue)
                {
                    buff = (int)(_char.BuffedStrength.IntValue * 0.2);
                    stat = "Strength";
                }
            }
            else if (_char.BuffedAgility.IntValue < _char.BuffedStrength.IntValue)
            {
                buff = (int)(_char.BuffedStrength.IntValue * 0.2);
                stat = "Strength";
            }

            this.AbilityName = "Invigorated";
            this.Description = _char.UnitName + " is Invigorated and has " + buff + " more health, 20% of its " + stat + "!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public Invigorated()
        { }
    }

    public class Oportunist : BuffsAndDebuffs
    {
        public Oportunist(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {

            this.AbilityName = "Oportunist";
            this.Description = _char.UnitName + " has had a random stat increased by 50%!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public Oportunist()
        { }
    }

    public class Ascended : BuffsAndDebuffs
    {
        public Ascended(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = "Ascended";
            this.Description = _char.UnitName + " has had all its stats, including health and attack, increased by 15!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public Ascended()
        { }
    }

    #endregion

    #region Warrior buffs
    public class Roared : BuffsAndDebuffs
    {
        public Roared(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            int buff = (int)(_char.BuffedStrength.IntValue * 0.4);
            this.AbilityName = "Roared";
            this.Description = _char.UnitName + " has Roared, increasing his Strength by " + buff + "!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public Roared()
        { }
    }

    public class Infuriated : BuffsAndDebuffs
    {
        public Infuriated(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            int buff = (int)((_char.BuffedHP.IntValue - _char.CurrentHP.IntValue)*0.25);
            this.AbilityName = "Infuriated";
            this.Description = _char.UnitName + " is Infuriated and has " + buff + " more Attack Damage!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public Infuriated()
        { }
    }
    #endregion

    #region Paladin Buffs
    public class InPrayer : BuffsAndDebuffs
    {
        public InPrayer(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            int strBuff = (int)(_char.BuffedStrength.IntValue*0.2);
            int intBuff = (int)(_char.BuffedIntellingence.IntValue * 0.2);
            this.AbilityName = "In Prayer";
            this.Description = _char.UnitName + " is In Prayer and has " + strBuff + " increased Strength and " + intBuff + " increased Intellect!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public InPrayer()
        { }
    }

    public class Blessed : BuffsAndDebuffs
    {
        public Blessed(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            int buff = (int)(_char.BuffedAgility.IntValue * 0.4);
            string stat = "Agility";

            if (_char.BuffedAgility.IntValue < _char.BuffedIntellingence.IntValue)
            {
                buff = (int)(_char.BuffedIntellingence.IntValue * 0.4);
                stat = "Intellect";
                if (_char.BuffedIntellingence.IntValue < _char.BuffedStrength.IntValue)
                {
                    buff = (int)(_char.BuffedStrength.IntValue * 0.4);
                    stat = "Strength";
                }
            }
            else if (_char.BuffedAgility.IntValue < _char.BuffedStrength.IntValue)
            {
                buff = (int)(_char.BuffedStrength.IntValue * 0.4);
                stat = "Strength";
            }

            this.AbilityName = "Blessed";
            this.Description = _char.UnitName + " was Blessed by a Paladin and has its " + stat + " increased by " + buff + "!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public Blessed()
        { }
    }
    #endregion

    #region Wizard Buffs
    public class Brilliant : BuffsAndDebuffs
    {
        public Brilliant(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            int buff = (int)(_char.BuffedIntellingence.IntValue * 0.4);
            this.AbilityName = "Brilliant";
            this.Description = _char.UnitName + " is Brilliant and has " + buff + " more Intellect!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public Brilliant()
        { }
    }

    public class Transformed : BuffsAndDebuffs
    {
        public Transformed(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            int buff = (int)(_char.BuffedIntellingence.IntValue*3);
            int debuff = (int)(_char.BuffedHP.IntValue * 0.6);
            this.AbilityName = "Transformed";
            this.Description = _char.UnitName + " is an Archon and has " + buff + " more Intellect, but " + debuff + " less maximum health!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public Transformed()
        { }
    }
    #endregion

    #region Thief Buffs
    public class Swift : BuffsAndDebuffs
    {
        public Swift(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            int buff = (int)(_char.BuffedAgility.IntValue * 0.4);
            this.AbilityName = "Swift";
            this.Description = _char.UnitName + " is Swift and has " + buff + " more Agility!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public Swift()
        { }
    }

    public class Venomous : BuffsAndDebuffs
    {
        public Venomous(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            int buff = (int)(_char.BuffedAttackDamage.IntValue*0.5);
            this.AbilityName = "Venomous";
            this.Description = _char.UnitName + " is Venomous and has " + buff + " more Attack!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public Venomous()
        { }
    }
    #endregion

    #region Caretaker Buffs
    public class InAction : BuffsAndDebuffs
    {
        public InAction(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            int agiBuff = (int)(_char.BuffedAgility.IntValue*0.2);
            int strBuff = (int)(_char.BuffedStrength.IntValue * 0.2);
            this.AbilityName = "In Action";
            this.Description = _char.UnitName + " is In Action and has " + strBuff + " more Strength and " + agiBuff + " more Agility!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public InAction()
        { }
    }
    #endregion

    #region Synergist Buffs

    public class Balanced : BuffsAndDebuffs
    {
        public Balanced(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            string highest = "Agility";
            string lowest = "Intellect";
            int highbuff = _char.BuffedAgility.IntValue;
            int lowbuff = _char.BuffedIntellingence.IntValue;

            if (_char.BuffedIntellingence.IntValue > _char.BuffedAgility.IntValue)
            {
                highest = "Intellect";
                lowest = "Agility";
                highbuff = _char.BuffedIntellingence.IntValue;
                lowbuff = _char.BuffedAgility.IntValue;
            }



            this.AbilityName = "Balanced";
            this.Description = _char.UnitName + " is Balanced and has " + highest + " increased by " + highbuff + " and " + lowest + " increased by " + lowbuff + "!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public Balanced()
        { }
    }

    public class Aligned : BuffsAndDebuffs
    {
        public Aligned(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            int agiBuff = (int)(_char.BuffedAgility.IntValue * 0.2);
            int intBuff = (int)(_char.BuffedIntellingence.IntValue * 0.2);
            this.AbilityName = "Aligned";
            this.Description = _char.UnitName  +" is Aligned and has " + agiBuff + " more Agility and " + intBuff + " more Intellect!";
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
        }

        /// <summary>
        /// Used only for XML Serialization.
        /// </summary>
        public Aligned()
        { }
    }
    #endregion
}
