using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using RPG.Core;
using RPG.Core.Units;

namespace RPG.Core.Abilities
{
    /// <summary>
    /// All ActiveAbilities have a function UseAbility that must be overridden by the abilities you create.
    /// </summary>
    public class ActiveAbility : Ability
    {
        int numberOfTargets;
        string chatString = "";
        int turnPointCost = 0;
        EnumActiveAbilityType damageOrHealing;
        public ActiveAbility(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq) 
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.Icon = this.SetIcon(_icon);
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public ActiveAbility()
        { }

        public virtual void UseAbility(Units.NPC _caster, List<Units.Character> _targets) { }
        public virtual void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _target) { }

        #region Properties

        public string ChatString
        {
            get { return chatString; }
            set { chatString = value; }
        }

        public int NumberOfTargets
        {
            get { return numberOfTargets; }
            set { numberOfTargets = value; }
        }

        public int TurnPointCost
        {
            get { return turnPointCost; }
            set { turnPointCost = value; }
        }

        public EnumActiveAbilityType DamageOrHealing
        {
            get { return damageOrHealing; }
            set { damageOrHealing = value; }
        }
        #endregion
    }

    #region character Abilities

    #region Any class abilities
    /// <summary>
    /// Melee Attack: "Deal damage to the target for 100% of the units attack."
    /// </summary>
    public class MeleeAttack : ActiveAbility
    {
        public MeleeAttack(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleAnyMeleeAttack;
            this.Description = Properties.Resources.AbilitiesDescriptionAnyMeleeAttack;
            this.NumberOfTargets = 1;
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
            this.TurnPointCost = 1;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public MeleeAttack()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _target)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)((_caster.BuffedAttackDamage.IntValue * 1.0) * critModifier);
            if (damage == 0)
                damage = 1;
            _target.CurrentHP.IntValue -= damage;

            if(critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _target.UnitName + ", dealing " + damage + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _target.UnitName + ", critting for " + damage + " damage!";
        }
    }

    /// <summary>
    /// Battle Regeneration: "Heals the caster for 100% of the casters level."
    /// </summary>
    public class BattleRegeneration : ActiveAbility
    {
        public BattleRegeneration(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleAnyBattleRegeneration;
            this.Description = Properties.Resources.AbilitiesDescriptionAnyBattleRegeneration;
            this.NumberOfTargets = 1;
            this.Icon = this.SetIcon(Properties.Resources.meleeattack);
            this.TurnPointCost = 1;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public BattleRegeneration()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _target)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int heal = (int)(_caster.UnitLevel * critModifier);
            int index = alliesIndexes[0];


            if ((_allies[index].CurrentHP.IntValue + (int)(heal) > _allies[index].BuffedHP.IntValue))
                _allies[index].CurrentHP.IntValue = _allies[index].BuffedHP.IntValue;
            else
                _allies[index].CurrentHP.IntValue += (int)(heal);

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[index].UnitName + " healing for " + heal + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[index].UnitName + " critically healing for " + heal + "!";
        }
    }

    /// <summary>
    /// Empowerment: "Increase the highest stat of the caster by 20%."
    /// </summary>
    public class Empowerment : ActiveAbility
    {
        public Empowerment(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleAnyEmpowerment;
            this.Description = Properties.Resources.AbilitiesDescriptionAnyEmpowerment;
            this.NumberOfTargets = 1;
            this.Icon = this.Icon = this.SetIcon(Properties.Resources.meleeattack);
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public Empowerment()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _target)
        {
            int index = alliesIndexes[0];

            if (!_allies[index].UnitBuffsAndDebuffs.Any(x => x.AbilityName == "Empowered"))
            {
                _allies[index].UnitBuffsAndDebuffs.Add(new Empowered(_allies[index], null, null, null, EnumAbilityClassReq.ANY));
                int statCaster = _caster.BuffedStrength.IntValue;
                int statTarget = _allies[index].BuffedStrength.IntValue;
                EnumAttributeType typeCaster = EnumAttributeType.Strength;
                EnumAttributeType typeTarget = EnumAttributeType.Strength;

                if (_caster.BuffedAgility.IntValue > statCaster)
                {
                    statCaster = _caster.BuffedAgility.IntValue;
                    typeCaster = EnumAttributeType.Agility;
                }

                if (_caster.BuffedIntellingence.IntValue > statCaster)
                {
                    statCaster = _caster.BuffedIntellingence.IntValue;
                    typeCaster = EnumAttributeType.Intellect;
                }

                if (_allies[index].BuffedAgility.IntValue > statTarget)
                {
                    statTarget = _caster.BuffedAgility.IntValue;
                    typeTarget = EnumAttributeType.Agility;
                }

                if (_allies[index].BuffedIntellingence.IntValue > statTarget)
                {
                    statTarget = _caster.BuffedIntellingence.IntValue;
                    typeTarget = EnumAttributeType.Intellect;
                }

                switch (typeTarget)
                {
                    case EnumAttributeType.Strength:
                        _allies[index].BuffedStrength.IntValue += (int)(statCaster * 0.2);
                        _allies[index].BuffedHP.IntValue += (int)(statCaster * 0.2 * 0.3);
                        break;
                    case EnumAttributeType.Agility:
                        _allies[index].BuffedAgility.IntValue += (int)(statCaster * 0.2);
                        _allies[index].BuffedSpeed.IntValue += (int)(statCaster * 0.2 * 0.3);
                        break;
                    case EnumAttributeType.Intellect:
                        _allies[index].BuffedIntellingence.IntValue += (int)(statCaster * 0.2);
                        _allies[index].BuffedCrit.IntValue += (int)(statCaster * 0.2 * 0.3);
                        break;
                    case EnumAttributeType.Health:
                        break;
                    case EnumAttributeType.Attackdamage:
                        break;
                    case EnumAttributeType.Armor:
                        break;
                    case EnumAttributeType.Turnpoints:
                        break;
                    default:
                        break;
                }

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " (" + typeCaster + "), increasing " + typeTarget.ToString().ToLower() + " of " + _allies[index].UnitName + " by " + (int)(statCaster * 0.2) + "!";
            }
            else
            {
                this.ChatString = _allies[index].UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    /// <summary>
    /// Invigorate: "Increase the maximum health of the caster by 20% of the casters highest stat."
    /// </summary>
    public class Invigorate : ActiveAbility
    {
        public Invigorate(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleAnyInvigorate;
            this.Description = Properties.Resources.AbilitiesDescriptionAnyInvigorate;
            this.NumberOfTargets = 1;
            this.Icon = this.SetIcon(Properties.Resources.meleeattack);
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public Invigorate()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _target)
        {
            int index = alliesIndexes[0];
            if (!_allies[index].UnitBuffsAndDebuffs.Any(x => x.AbilityName == "Invigorated"))
            {
                _allies[index].UnitBuffsAndDebuffs.Add(new Invigorated(_allies[index], null, null, null, EnumAbilityClassReq.ANY));
                int stat = _caster.BuffedStrength.IntValue;

                if (_caster.BuffedAgility.IntValue > stat)
                    stat = _caster.BuffedAgility.IntValue;

                if (_caster.BuffedIntellingence.IntValue > stat)
                    stat = _caster.BuffedIntellingence.IntValue;


                _allies[index].BuffedHP.IntValue += (int)(stat * 0.2);

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[index].UnitName + ", increasing maxmimum health by " + (int)(stat * 0.2) + "!";
            }
            else
            {
                this.ChatString = _allies[index].UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    /// <summary>
    /// Double Swing: "Deal damage equal to 315% of the units attack."
    /// </summary>
    public class DoubleSwing : ActiveAbility
    {
        public DoubleSwing(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleAnyDoubleSwing;
            this.Description = Properties.Resources.AbilitiesDescriptionAnyDoubleSwing;
            this.NumberOfTargets = 1;
            this.Icon = this.SetIcon(Properties.Resources.meleeattack);
            this.TurnPointCost = 3;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public DoubleSwing()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _target)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);

            int damage = (int)((_caster.BuffedAttackDamage.IntValue * 3.15)*critModifier);
            _target.CurrentHP.IntValue -= damage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " dealing " + damage + " to " + _target.UnitName + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " critting " + _target.UnitName + " for " + damage + "!";
        }
    }

    /// <summary>
    /// Opportunity: "Increases a random of your stats by 50%."
    /// </summary>
    public class Opportunity : ActiveAbility
    {
        public Opportunity(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleAnyOpportunity;
            this.Description = Properties.Resources.AbilitiesDescriptionAnyOpportunity;
            this.NumberOfTargets = 1;
            this.Icon = this.SetIcon(Properties.Resources.meleeattack);
            this.TurnPointCost = 4;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public Opportunity()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _target)
        {
            int index = alliesIndexes[0];
            if (!_allies[index].UnitBuffsAndDebuffs.Any(x => x.AbilityName == "Oportunist"))
            {
                _allies[index].UnitBuffsAndDebuffs.Add(new Oportunist(_allies[index], null, null, null, EnumAbilityClassReq.ANY));
                Random r = new Random();
                EnumAttributeType type = EnumAttributeType.Agility;
                int buff = 0;

                switch (r.Next(0,2))
                {
                    case 0:
                        buff = (int)(_allies[index].BuffedAgility.IntValue * 0.5);
                        _allies[index].BuffedAgility.IntValue += buff;
                        _allies[index].BuffedSpeed.IntValue += (int)(buff * 0.3);
                        type = EnumAttributeType.Agility;
                        break;
                    case 1:
                        buff = (int)(_allies[index].BuffedIntellingence.IntValue * 0.5);
                        _allies[index].BuffedIntellingence.IntValue += buff;
                        _allies[index].BuffedCrit.IntValue += (int)(buff * 0.3);
                        type = EnumAttributeType.Intellect;
                        break;
                    case 2:
                        buff = (int)(_allies[index].BuffedStrength.IntValue * 0.5);
                        _allies[index].BuffedStrength.IntValue += buff;
                        _allies[index].BuffedHP.IntValue += (int)(buff * 0.3);
                        type = EnumAttributeType.Strength;
                        break;
                    default:
                        break;
                }

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[index].UnitName + ", increasing " + type.ToString().ToLower() + " by " + buff + "!";
            }
            else
            {
                this.ChatString = _allies[index].UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    /// <summary>
    /// Totalitarism: "Deals all of the units stats combined in damage."
    /// </summary>
    public class Totalitarism : ActiveAbility
    {
        public Totalitarism(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleAnyTotalitarism;
            this.Description = Properties.Resources.AbilitiesDescriptionAnyTotalitarism;
            this.NumberOfTargets = 1;
            this.Icon = this.SetIcon(Properties.Resources.meleeattack);
            this.TurnPointCost = 5;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public Totalitarism()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _target)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);

            int damage = (int)((_caster.BuffedAgility.IntValue + _caster.BuffedIntellingence.IntValue + _caster.BuffedStrength.IntValue) * critModifier);
            _target.CurrentHP.IntValue -= damage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " dealing " + damage + " to " + _target.UnitName + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " critting " + _target.UnitName + " for " + damage + "!";
        }
    }

    /// <summary>
    /// Ascend: "Increases all of the units stats by 15, including max health and attack."
    /// </summary>
    public class Ascend : ActiveAbility
    {
        public Ascend(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleAnyAscend;
            this.Description = Properties.Resources.AbilitiesDescriptionAnyAscend;
            this.NumberOfTargets = 1;
            this.Icon = this.SetIcon(Properties.Resources.meleeattack);
            this.TurnPointCost = 5;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public Ascend()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _target)
        {
            int index = alliesIndexes[0];
            if (!_allies[index].UnitBuffsAndDebuffs.Any(x => x.AbilityName == "Ascended"))
            {
                _allies[index].UnitBuffsAndDebuffs.Add(new Ascended(_allies[index], null, null, null, EnumAbilityClassReq.ANY));
                _allies[index].BuffedAttackDamage.IntValue += 15;
                _allies[index].BuffedAgility.IntValue += 15;
                _allies[index].BuffedHP.IntValue += 15;
                _allies[index].BuffedIntellingence.IntValue += 15;
                _allies[index].BuffedStrength.IntValue += 15;

                _allies[index].BuffedHP.IntValue += (int)(15 * 0.3);
                _allies[index].BuffedSpeed.IntValue += (int)(15 * 0.3);
                _allies[index].BuffedCrit.IntValue += (int)(15 * 0.3);

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[index].UnitName + " increasing all stats by 15!";
            }
            else
            {
                this.ChatString = _allies[index].UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    #endregion

    #region Warrior Abilities

    /// <summary>
    /// Strength: "Deal damage to the target based on the 50% of the strength of the Warrior."
    /// </summary>
    public class WarriorStrength : ActiveAbility
    {
        public WarriorStrength(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleWarriorStrength;
            this.Description = Properties.Resources.AbilitiesDescriptionWarriorStrength;
            this.NumberOfTargets = 1;
            this.Icon = this.SetIcon(Properties.Resources.strength);
            this.TurnPointCost = 1;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WarriorStrength()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);

            int damage = (int)((_caster.BuffedStrength.IntValue * 0.5) * critModifier);
            _targets.CurrentHP.IntValue -= damage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", dealing " + damage + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", critting for " + damage + " damage!";
        }
    }

    /// <summary>
    /// Power Strike: "Deal damage to the target based on 90% attack damage and 10% of the Warriors strength."
    /// </summary>
    public class WarriorPowerStrike : ActiveAbility
    {
        public WarriorPowerStrike(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleWarriorPowerStrike;
            this.Description = Properties.Resources.AbilitiesDescriptionWarriorPowerStrike;
            this.NumberOfTargets = 1;
            this.Icon = this.SetIcon(Properties.Resources.strength);
            this.TurnPointCost = 1;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WarriorPowerStrike()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);

            int damage = (int)(((_caster.BuffedStrength.IntValue * 0.1) + (_caster.BuffedAttackDamage.IntValue * 0.9)) * critModifier);
            _targets.CurrentHP.IntValue -= damage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", dealing " + damage + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", critting for " + damage + " damage!";
        }
    }

    /// <summary>
    /// Blind Rage: "Deals anywhere between 175 and 75% of the Warriors strength in damage."
    /// </summary>
    public class WarriorBlindRage : ActiveAbility
    {
        public WarriorBlindRage(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleWarriorBlindRage;
            this.Description = Properties.Resources.AbilitiesDescriptionWarriorBlindRage;
            this.NumberOfTargets = 1;
            this.Icon = this.SetIcon(Properties.Resources.strength);
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WarriorBlindRage()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            Random r = new Random();
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            double modifier = ((double)r.Next(60, 175) / (double)100);
            int damage = (int)((_caster.BuffedStrength.IntValue * modifier) * critModifier);
            _targets.CurrentHP.IntValue -= damage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", dealing " + damage + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", critting for " + damage + " damage!";
        }
    }

    /// <summary>
    /// Rampage: "The Warriors deals 150% of his  strength in damage, but takes 10% damage of the damage himself."
    /// </summary>
    public class WarriorRampage : ActiveAbility
    {
        public WarriorRampage(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleWarriorRampage;
            this.Description = Properties.Resources.AbilitiesDescriptionWarriorRampage;
            this.Icon = this.SetIcon(Properties.Resources.strength);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WarriorRampage()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)((_caster.BuffedStrength.IntValue * 1.50) * critModifier);
            int damageSelf = (int)(0.1 * damage);
            _targets.CurrentHP.IntValue -= damage;
            _caster.CurrentHP.IntValue -= damageSelf;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", dealing " + damage + ", but takes " + damageSelf + " himself!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", critting for " + damage + ", but takes " + damageSelf + " himself!";
        }
    }

    /// <summary>
    /// Roar : "Increases the strength of the Warrior by 40%."
    /// </summary>
    public class WarriorRoar : ActiveAbility
    {
        public WarriorRoar(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleWarriorRoar;
            this.Description = Properties.Resources.AbilitiesDescriptionWarriorRoar;
            this.NumberOfTargets = 1;
            this.Icon = this.SetIcon(Properties.Resources.strength);
            this.TurnPointCost = 3;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WarriorRoar()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            if (!_caster.UnitBuffsAndDebuffs.Any(x => x.AbilityName == "Roared"))
            {
                _caster.UnitBuffsAndDebuffs.Add(new Roared(_caster, null, null, null, EnumAbilityClassReq.ANY));
                int buff = (int)(_caster.BuffedStrength.IntValue * 0.4);
                _caster.BuffedStrength.IntValue += buff;
                _caster.BuffedHP.IntValue += (int)(buff * 0.3);

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", increasing Strength by " + buff + "!";
            }
            else
            {
                this.ChatString = _caster.UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    /// <summary>
    /// Infuriate: "Increases the Warriors attack by 25% of the Warriors health deficit."
    /// </summary>
    public class WarriorInfuriate : ActiveAbility
    {
        public WarriorInfuriate(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleWarriorInfuriate;
            this.Description = Properties.Resources.AbilitiesDescriptionWarriorInfuriate;
            this.NumberOfTargets = 1;
            this.Icon = this.SetIcon(Properties.Resources.strength);
            this.TurnPointCost = 4;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WarriorInfuriate()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            if (!_caster.UnitBuffsAndDebuffs.Any(x => x.AbilityName == "Infuriated"))
            {
                _caster.UnitBuffsAndDebuffs.Add(new Infuriated(_caster, null, null, null, EnumAbilityClassReq.ANY));
                int buff = (int)((_caster.BuffedHP.IntValue - _caster.CurrentHP.IntValue)*0.25);
                _caster.BuffedAttackDamage.IntValue += buff;

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", increasing Attack by " + buff + "!";
            }
            else
            {
                this.ChatString = _caster.UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    /// <summary>
    /// Execution: "Deals 750% attack damage if the target dies from this. Otherwise, deals 150% Weapon Damage."
    /// </summary>
    public class WarriorExecution : ActiveAbility
    {
        public WarriorExecution(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleWarriorExecution;
            this.Description = Properties.Resources.AbilitiesDescriptionWarriorExecution;
            this.Icon = this.SetIcon(Properties.Resources.strength);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 5;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WarriorExecution()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)((_caster.BuffedAttackDamage.IntValue * 7.5) * critModifier);


            if (_targets.CurrentHP.IntValue - damage < 1)
            {
                _targets.CurrentHP.IntValue = 0;
                if (critModifier == 1.0)
                    this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", dealing " + damage + " and killing " + _targets.UnitName + " instantly!";
                else
                    this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", critting for " + damage + " and killing " + _targets.UnitName + " instantly!";
            }
            else
            {
                damage = (int)((_caster.BuffedAttackDamage.IntValue * 1.5) * critModifier);
                _targets.CurrentHP.IntValue -= damage;
                if (critModifier == 1.0)
                    this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", but it wasnt enough! " + damage + " was dealt to " + _targets.UnitName + " instead!";
                else
                    this.ChatString = _caster.UnitName + " uses a critting " + this.AbilityName + ", but it wasnt enough! " + damage + " was dealt to " + _targets.UnitName + " instead!";
            }
        }
    }

    /// <summary>
    /// Insanity: "The Warrior deals 300% of his strength in damage to the target, but injures of his allies for 15% of the damage dealt."
    /// </summary>
    public class WarriorInsanity : ActiveAbility
    {
        public WarriorInsanity(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleWarriorInsanity;
            this.Description = Properties.Resources.AbilitiesDescriptionWarriorInsanity;
            this.Icon = this.SetIcon(Properties.Resources.strength);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 5;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WarriorInsanity()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)((_caster.BuffedStrength.IntValue * 3.5) * critModifier);
            int damageFriendly = (int)((damage * 0.15) / _allies.Count);

            _targets.CurrentHP.IntValue -= damage;

            foreach (var item in _allies)
            {
                _caster.CurrentHP.IntValue -= damageFriendly;
            }

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", dealing a massive " + damage + " to " + _targets.UnitName + ", but injures all allies for " + damageFriendly + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", dealing a massive " + damage + " to " + _targets.UnitName + ", but injures all allies for " + damageFriendly + "!";
            
        }
    }

    #endregion

    #region Paladin Abilities

    /// <summary>
    /// Wrath: "Deals 50% of the Paladins strength in damage."
    /// </summary>
    public class PaladinWrath : ActiveAbility
    {
        public PaladinWrath(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            AbilityName = Properties.Resources.AbilitiesTitlePaladinWrath; 
            Description = Properties.Resources.AbilitiesDescriptionPaladinWrath;
            this.Icon = this.SetIcon(Properties.Resources.wrath);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 1;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public PaladinWrath()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);

            int damageValue = 0;
            damageValue = (int)((_caster.BuffedStrength.IntValue * 0.5) * critModifier);
            _targets.CurrentHP.IntValue -= damageValue;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " for " + damageValue + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting for " + damageValue + " damage!";
        }
    }

    /// <summary>
    /// Justice: "Deals 40% of the Paladins strength in damage and heals him for 30% of his intellect."
    /// </summary>
    public class PaladinJustice : ActiveAbility
    {
        public PaladinJustice(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitlePaladinJustice;
            this.Description = Properties.Resources.AbilitiesDescriptionPaladinJustice;
            this.Icon = this.SetIcon(Properties.Resources.wrath);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 1;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public PaladinJustice()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);

            int damage = (int)((_caster.BuffedStrength.IntValue * 0.4) * critModifier);
            _targets.CurrentHP.IntValue -= damage;

            int heal = (int)((_caster.BuffedIntellingence.IntValue * 0.3) * critModifier);
            
            if ((_caster.CurrentHP.IntValue + heal) > _caster.BuffedHP.IntValue)
                _caster.CurrentHP.IntValue = _caster.BuffedHP.IntValue;
            else
                _caster.CurrentHP.IntValue += heal;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " for " + damage + " and heals self for " + heal + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting for " + damage + " damage and heals self for " + heal + "!";
        }
    }

    /// <summary>
    /// Serenity: "Heals a random ally and deals damage to the target for 40% of the Paladins intellect."
    /// </summary>
    public class PaladinSerenity : ActiveAbility
    {
        public PaladinSerenity(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitlePaladinSerenity;
            this.Description = Properties.Resources.AbilitiesDescriptionPaladinSerenity;
            this.Icon = this.SetIcon(Properties.Resources.wrath);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public PaladinSerenity()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            Random r = new Random();
            int heal = (int)((_caster.BuffedIntellingence.IntValue * 0.4) * critModifier);
            int index = r.Next(0,_allies.Count);

            while (_allies[index].CurrentHP.IntValue < 1)
            {
                index = r.Next(0,_allies.Count);
            }

            _targets.CurrentHP.IntValue -= heal;


            if ((_allies[index].CurrentHP.IntValue + heal) > _allies[index].BuffedHP.IntValue)
                _allies[index].CurrentHP.IntValue = _allies[index].BuffedHP.IntValue;
            else
                _allies[index].CurrentHP.IntValue += heal;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " for " + heal + " and heals " + _allies[index].UnitName + " for " + heal + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", critting for " + heal + " and healing " + _allies[index].UnitName + " for " + heal + "!";
        }
    }

    /// <summary>
    /// Raise Spirit: "The Paladin heals the target for 25% of his combined strength and intellect."
    /// </summary>
    public class PaladinRaiseSpirit : ActiveAbility
    {
        public PaladinRaiseSpirit(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitlePaladinRaiseSpirit;
            this.Description = Properties.Resources.AbilitiesDescriptionPaladinRaiseSpirit;
            this.Icon = this.SetIcon(Properties.Resources.wrath);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public PaladinRaiseSpirit()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int heal = (int)(((_caster.BuffedIntellingence.IntValue + _caster.BuffedStrength.IntValue) * 0.25) * critModifier);
            int targetindex = 0;

            foreach (var index in alliesIndexes)
            {
                if (_allies[index].CurrentHP.IntValue > 0)
                {
                    targetindex = index;
                    if ((_allies[index].CurrentHP.IntValue + heal) > _allies[index].BuffedHP.IntValue)
                        _allies[index].CurrentHP.IntValue = _allies[index].BuffedHP.IntValue;
                    else
                        _allies[index].CurrentHP.IntValue += heal;
                    break;
                }
            }

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[targetindex].UnitName + ", healing for " + heal + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[targetindex].UnitName + ", critically healing for " + heal + "!";
        }
    }

    /// <summary>
    /// Prayer: "Increases the strength and intellect of the Paladin by 20%."
    /// </summary>
    public class PaladinPrayer : ActiveAbility
    {
        public PaladinPrayer(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitlePaladinPrayer;
            this.Description = Properties.Resources.AbilitiesDescriptionPaladinPrayer;
            this.Icon = this.SetIcon(Properties.Resources.wrath);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 3;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public PaladinPrayer()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            if (!_caster.UnitBuffsAndDebuffs.Any(x => x.AbilityName == "In Prayer"))
            {
                _caster.UnitBuffsAndDebuffs.Add(new InPrayer(_caster, null, null, null, EnumAbilityClassReq.ANY));
                int strBuff = (int)(_caster.BuffedStrength.IntValue*0.2);
                int intBuff = (int)(_caster.BuffedIntellingence.IntValue * 0.2);
                _caster.BuffedStrength.IntValue += strBuff;
                _caster.BuffedIntellingence.IntValue += intBuff;

                _caster.BuffedHP.IntValue += (int)(strBuff * 0.3);
                _caster.BuffedCrit.IntValue += (int)(intBuff * 0.3);

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", increasing Strength by " + strBuff + " and Intellect by " + intBuff + "!";
            }
            else
            {
                this.ChatString = _caster.UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    /// <summary>
    /// Blessing: "Increases the target allys' highest stat by 40%:"
    /// </summary>
    public class PaladinBlessing : ActiveAbility
    {
        public PaladinBlessing(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitlePaladinBlessing;
            this.Description = Properties.Resources.AbilitiesDescriptionPaladinBlessing;
            this.Icon = this.SetIcon(Properties.Resources.wrath);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 4;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public PaladinBlessing()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            int index = 0;
            EnumAttributeType stat = EnumAttributeType.Agility;
            int best = 0;
            int buff = 0;

            foreach (var item in alliesIndexes)
            {
                if (_allies[item].CurrentHP.IntValue > 0)
                {
                    index = item;
                    break;
                }
            }

            if (!_allies[index].UnitBuffsAndDebuffs.Any(x => x.AbilityName == "Blessed"))
            {
                _allies[index].UnitBuffsAndDebuffs.Add(new Blessed(_allies[index], null, null, null, EnumAbilityClassReq.ANY));

                if (_allies[index].BuffedAgility.IntValue > best)
                {
                    stat = EnumAttributeType.Agility;
                    best = _allies[index].BuffedAgility.IntValue;
                }

                if (_allies[index].BuffedIntellingence.IntValue > best)
                {
                    stat = EnumAttributeType.Intellect;
                    best = _allies[index].BuffedIntellingence.IntValue;
                }

                if (_allies[index].BuffedStrength.IntValue > best)
                {
                    stat = EnumAttributeType.Strength;
                    best = _allies[index].BuffedStrength.IntValue;
                }

                switch (stat)
                {
                    case EnumAttributeType.Strength:
                        buff = (int)(_allies[index].BuffedStrength.IntValue*0.4);
                        _allies[index].BuffedStrength.IntValue += buff;
                        _allies[index].BuffedHP.IntValue += (int)(buff * 0.3);
                        break;
                    case EnumAttributeType.Agility:
                        buff = (int)(_allies[index].BuffedAgility.IntValue * 0.4);
                        _allies[index].BuffedAgility.IntValue += buff;
                        _allies[index].BuffedSpeed.IntValue += (int)(buff * 0.3);
                        break;
                    case EnumAttributeType.Intellect:
                        buff = (int)(_allies[index].BuffedIntellingence.IntValue * 0.4);
                        _allies[index].BuffedIntellingence.IntValue += buff;
                        _allies[index].BuffedCrit.IntValue += (int)(buff * 0.3);
                        break;
                    case EnumAttributeType.Health:
                        break;
                    case EnumAttributeType.Attackdamage:
                        break;
                    case EnumAttributeType.Armor:
                        break;
                    case EnumAttributeType.Turnpoints:
                        break;
                    default:
                        break;
                }

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[index].UnitName + ", increasing " + stat.ToString().ToLower() + " by " + buff + "!";
            }
            else
            {
                this.ChatString = _allies[index].UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    /// <summary>
    /// Desperate Plea: "Heals the target for 75% of their maximum health, but decreases their maximum health by 20%."
    /// </summary>
    public class PaladinDesperatePlea : ActiveAbility
    {
        public PaladinDesperatePlea(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitlePaladinDesperatePlea;
            this.Description = Properties.Resources.AbilitiesDescriptionPaladinDesperatePlea;
            this.Icon = this.SetIcon(Properties.Resources.wrath);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 5;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public PaladinDesperatePlea()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            int newMax = 0;
            int heal = 0;
            int targetIndex = 0;

            foreach (var item in alliesIndexes)
            {
                if (_allies[item].CurrentHP.IntValue > 0)
                {
                    targetIndex = item;
                    heal = (int)(_allies[item].BuffedHP.IntValue * 0.75);
                    newMax = (int)(_allies[item].BuffedHP.IntValue * 0.80);

                    _allies[item].BuffedHP.IntValue = newMax;

                    if (heal + _allies[item].CurrentHP.IntValue > newMax)
                        _allies[item].CurrentHP.IntValue = newMax;
                    else
                        _allies[item].CurrentHP.IntValue += heal;

                    break;
                }
            }

            this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[targetIndex].UnitName + ", healing for " + heal + " but decreasing their maximum health to " + newMax + "!";
        }
    }

    /// <summary>
    /// The Power of Faith: "Heals the paladin to full health, but reduces all his stats by 10%."
    /// </summary>
    public class PaladinThePowerOfFaith : ActiveAbility
    {
        public PaladinThePowerOfFaith(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitlePaladinThePowerOfFaith;
            this.Description = Properties.Resources.AbilitiesDescriptionPaladinThePowerOfFaith;
            this.Icon = this.SetIcon(Properties.Resources.wrath);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 5;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public PaladinThePowerOfFaith()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            _caster.BuffedStrength.IntValue -= (int)(_caster.BuffedStrength.IntValue * 0.10);
            _caster.BuffedIntellingence.IntValue -= (int)(_caster.BuffedIntellingence.IntValue * 0.10);
            _caster.BuffedAgility.IntValue -= (int)(_caster.BuffedAgility.IntValue * 0.10);

            _caster.BuffedHP.IntValue -= (int)(_caster.BuffedStrength.IntValue * 0.10 * 0.3);
            _caster.BuffedSpeed.IntValue -= (int)(_caster.BuffedAgility.IntValue * 0.10 * 0.3);
            _caster.BuffedCrit.IntValue -= (int)(_caster.BuffedIntellingence.IntValue * 0.10 * 0.3);

            int heal = _caster.BuffedHP.IntValue;
            _caster.CurrentHP.IntValue = heal;

            this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _caster.UnitName + ", healing for " + heal + ", but reduces his stats by 10%!";
        }
    }

    #endregion

    #region Wizard Abilties
    /// <summary>
    /// Fireball: "This ability deals damage to the 1 target, based on 50% of the Wizards intellect."
    /// </summary>
    public class WizardFireball : ActiveAbility
    {
        public WizardFireball(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            AbilityName = Properties.Resources.AbilitiesTitleWizardFireball;
            Description = Properties.Resources.AbilitiesDescriptionWizardFireball;
            this.Icon = this.SetIcon(Properties.Resources.fireball);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 1;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WizardFireball()
        { }

        decimal damageValue = 0.0m;
        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            damageValue = (int)((_caster.BuffedIntellingence.IntValue * 0.5) * critModifier);
            _targets.CurrentHP.IntValue -= (int)damageValue;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", dealing " + damageValue + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", critting for " + damageValue + " damage!";
        }
    }

    /// <summary>
    /// Heal: "This Ability heals the target player for an amount equal to 25% of the Wizards Intellect."
    /// </summary>
    public class WizardHeal : ActiveAbility
    {
        public WizardHeal(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            AbilityName = Properties.Resources.AbilitiesTitleWizardHeal;
            Description = Properties.Resources.AbilitiesDescriptionWizardHeal;
            this.Icon = this.SetIcon(Properties.Resources.heal);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 1;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WizardHeal()
        { }

        
        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _target)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int healValue = 0;
            int index = 0;
            healValue = (int)((_caster.BuffedIntellingence.IntValue * 0.25) * critModifier);

            foreach (var item in alliesIndexes)
            {
                if (_allies[item].CurrentHP.IntValue > 0)
                {
                    index = item;
                    if ((_allies[item].CurrentHP.IntValue + healValue) > _allies[item].BuffedHP.IntValue)
                        _allies[item].CurrentHP.IntValue = _allies[item].BuffedHP.IntValue;
                    else
                        _allies[item].CurrentHP.IntValue += healValue;
                    break;
                }
            }

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[index].UnitName + ", healing for " + healValue + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[index].UnitName + ", critically healing for " + healValue + "!";
        }
    }

    /// <summary>
    /// Flame Comet: "Deals damage to the target for 100% of the Wizards intellect."
    /// </summary>
    public class WizardFlameComet : ActiveAbility
    {
        public WizardFlameComet(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            AbilityName = Properties.Resources.AbilitiesTitleWizardFlameComet;
            Description = Properties.Resources.AbilitiesDescriptionWizardFlameComet;
            this.Icon = this.SetIcon(Properties.Resources.fireball);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WizardFlameComet()
        { }

        decimal damageValue = 0.0m;
        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            damageValue = (int)((_caster.BuffedIntellingence.IntValue * 1.1) * critModifier);
            _targets.CurrentHP.IntValue -= (int)damageValue;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", dealing " + damageValue + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", critting for " + damageValue + " damage!";
        }
    }

    /// <summary>
    /// Revitalize: "The Wizard heals the target for 50% of her intellect."
    /// </summary>
    public class WizardRevitalize : ActiveAbility
    {
        public WizardRevitalize(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            AbilityName = Properties.Resources.AbilitiesTitleWizardRevitalize;
            Description = Properties.Resources.AbilitiesDescriptionWizardRevitalize;
            this.Icon = this.SetIcon(Properties.Resources.heal);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WizardRevitalize()
        { }

        
        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _target)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int healValue = 0;
            int index = 0;
            healValue = (int)((_caster.BuffedIntellingence.IntValue * 0.5) * critModifier);

            foreach (var item in alliesIndexes)
            {
                if (_allies[item].CurrentHP.IntValue > 0)
                {
                    index = item;
                    if ((_allies[item].CurrentHP.IntValue + healValue) > _allies[item].BuffedHP.IntValue)
                        _allies[item].CurrentHP.IntValue = _allies[item].BuffedHP.IntValue;
                    else
                        _allies[item].CurrentHP.IntValue += healValue;
                    break;
                }
            }

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[index].UnitName + ", healing for " + healValue + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[index].UnitName + ", critically healing for " + healValue + "!";
        }
    }

    /// <summary>
    /// Brilliance: "Increases the intellect of the Wizard by 40%."
    /// </summary>
    public class WizardBrilliance : ActiveAbility
    {
        public WizardBrilliance(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleWizardBrilliance;
            this.Description = Properties.Resources.AbilitiesDescriptionWizardBrilliance;
            this.Icon = this.SetIcon(Properties.Resources.fireball);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 3;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WizardBrilliance()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            if (!_caster.UnitBuffsAndDebuffs.Any(x => x.AbilityName == "Brilliant"))
            {
                _caster.UnitBuffsAndDebuffs.Add(new Brilliant(_caster, null, null, null, EnumAbilityClassReq.ANY));
                int buff = (int)(_caster.BuffedIntellingence.IntValue * 0.40);
                _caster.BuffedIntellingence.IntValue += buff;
                _caster.BuffedCrit.IntValue += (int)(buff * 0.3);

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _caster.UnitName + ", increasing Intellect for " + buff + "!";
            }
            else
            {
                this.ChatString = _caster.UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    /// <summary>
    /// Archon: "Reduces maximum health by 60%, but increases intellect by 300%."
    /// </summary>
    public class WizardArchon : ActiveAbility
    {
        public WizardArchon(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleWizardArchon;
            this.Description = Properties.Resources.AbilitiesDescriptionWizardArchon;
            this.Icon = this.SetIcon(Properties.Resources.fireball);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 4;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WizardArchon()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            if (!_caster.UnitBuffsAndDebuffs.Any(x => x.AbilityName == "Transformed"))
            {
                _caster.UnitBuffsAndDebuffs.Add(new Transformed(_caster, null, null, null, EnumAbilityClassReq.ANY));
                int newInt = (int)(_caster.BuffedIntellingence.IntValue * 3);
                int newMax = (int)(_caster.BuffedHP.IntValue * 0.40);

                _caster.BuffedIntellingence.IntValue = newInt;
                _caster.BuffedCrit.IntValue = (int)(newInt * 0.3);

                _caster.BuffedHP.IntValue = newMax;

                if (_caster.BuffedHP.IntValue < _caster.CurrentHP.IntValue)
                {
                    int temp = _caster.BuffedHP.IntValue;
                    _caster.CurrentHP.IntValue = temp;
                }

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", immensely increasing Intellect to " + newInt + ", but reduces maximum health to " + newMax + "!";
            }
            else
            {
                this.ChatString = _caster.UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    /// <summary>
    /// Inferno: "Deals damage to the target for 200% of the Wizards intellect."
    /// </summary>
    public class WizardInferno : ActiveAbility
    {
        public WizardInferno(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            AbilityName = Properties.Resources.AbilitiesTitleWizardInferno;
            Description = Properties.Resources.AbilitiesDescriptionWizardInferno;
            this.Icon = this.SetIcon(Properties.Resources.fireball);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 5;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WizardInferno()
        { }

        decimal damageValue = 0.0m;
        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            damageValue = (int)((_caster.BuffedIntellingence.IntValue * 2.8) * critModifier);
            _targets.CurrentHP.IntValue -= (int)damageValue;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", dealing " + damageValue + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", critting for " + damageValue + " damage!";
        }
    }

    /// <summary>
    /// Oracle: "Heals all allies for 55/40/30 % of the Wizards Intellect. Percentage is dependant on number of valid targets."
    /// </summary>
    public class WizardOracle : ActiveAbility
    {
        public WizardOracle(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            AbilityName = Properties.Resources.AbilitiesTitleWizardOracle;
            Description = Properties.Resources.AbilitiesDescriptionWizardOracle;
            this.Icon = this.SetIcon(Properties.Resources.heal);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 5;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public WizardOracle()
        { }


        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _target)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int healValue = 0;
            int numberAlive = 0;

            foreach (var item in _allies)
            {
                if (item.CurrentHP.IntValue > 0)
                {
                    numberAlive++;
                }
            }

            switch (numberAlive)
            {
                case 1:
                case 2:
                    healValue = (int)((_caster.BuffedIntellingence.IntValue * 0.55) * critModifier);
                    break;
                case 3:
                    healValue = (int)((_caster.BuffedIntellingence.IntValue * 0.40) * critModifier);
                    break;
                case 4:
                    healValue = (int)((_caster.BuffedIntellingence.IntValue * 0.30) * critModifier);
                    break;
                default:
                    break;
            }


            foreach (var item in _allies)
            {
                if (item.CurrentHP.IntValue > 0)
                {
                    if ((item.CurrentHP.IntValue + healValue) > item.BuffedHP.IntValue)
                        item.CurrentHP.IntValue = item.BuffedHP.IntValue;
                    else
                        item.CurrentHP.IntValue += healValue;
                }
            }

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on all allies, healing each for " + healValue + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on all allies, critically healing each for " + healValue + "!";
        }
    }
    #endregion

    #region Thief Abilities

    /// <summary>
    /// Quick Attack: "Swiftly injure the target for 50% of the casters agility."
    /// </summary>
    public class ThiefQuickAttack : ActiveAbility
    {
        public ThiefQuickAttack(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleThiefQuickAttack;
            this.Description = Properties.Resources.AbilitiesDescriptionThiefQuickAttack;
            this.Icon = this.SetIcon(Properties.Resources.quickattack);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 1;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public ThiefQuickAttack()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)((_caster.BuffedAgility.IntValue * 0.5) * critModifier);
            _targets.CurrentHP.IntValue -= damage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " dealing " + damage + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting for " + damage + " damage!";
        }
    }

    /// <summary>
    /// Borrow Weapon: "The Thief uses the best attack of his allies together with his own, dealing 65% of their combined damage."
    /// </summary>
    public class ThiefBorrowWeapon : ActiveAbility
    {
        public ThiefBorrowWeapon(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleThiefBorrowWeapon;
            this.Description = Properties.Resources.AbilitiesDescriptionThiefBorrowWeapon;
            this.Icon = this.SetIcon(Properties.Resources.quickattack);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 1;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public ThiefBorrowWeapon()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int best = 0;
            int damage = 0;
            string weaponOwner = "";

            foreach (var item in _allies)
            {
                if (item.BuffedAttackDamage.IntValue > best)
                {
                    weaponOwner = item.UnitName;
                    best = item.BuffedAttackDamage.IntValue;
                }
            }

            damage = (int)(((_caster.BuffedAttackDamage.IntValue + best) * 0.65) * critModifier);
            _targets.CurrentHP.IntValue -= damage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", borrowing " + weaponOwner + "'s attack and dealing " + damage + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + ", borrowing " + weaponOwner + "'s attack and critting for " + damage + " damage!";
        }
    }

    /// <summary>
    /// Bloodstealer: "Deals 100% of the Thiefs agility in damage and heals him for 10% of the damage dealt."
    /// </summary>
    public class ThiefBloodstealer : ActiveAbility
    {
        public ThiefBloodstealer(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleThiefBloodstealer;
            this.Description = Properties.Resources.AbilitiesDescriptionThiefBloodstealer;
            this.Icon = this.SetIcon(Properties.Resources.quickattack);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public ThiefBloodstealer()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)((_caster.BuffedAgility.IntValue * 1) * critModifier);
            int healing = (int)(damage * 0.1);

            _targets.CurrentHP.IntValue -= damage;

            if (_caster.CurrentHP.IntValue + healing > _caster.BuffedHP.IntValue)
                _caster.CurrentHP.IntValue = _caster.BuffedHP.IntValue;
            else
                _caster.CurrentHP.IntValue += healing;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " dealing " + damage + " and healing for " + healing + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting for " + damage + " and healing for " + healing + "!";
        }
    }

    /// <summary>
    /// Poisoned Blade
    /// </summary>
    public class ThiefPoisonedBlade : ActiveAbility
    {
        public ThiefPoisonedBlade(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleThiefPoisonedBlade;
            this.Description = Properties.Resources.AbilitiesDescriptionThiefPoisonedBlade;
            this.Icon = this.SetIcon(Properties.Resources.quickattack);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public ThiefPoisonedBlade()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)((_caster.BuffedAttackDamage.IntValue * 1.4 + _caster.BuffedAgility.IntValue * 0.75) * critModifier);

            _targets.CurrentHP.IntValue -= damage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " dealing " + damage + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting for " + damage + "!";
        }
    }

    /// <summary>
    /// Swiftness: "Increases the agility of the Thief by 40%".
    /// </summary>
    public class ThiefSwiftness : ActiveAbility
    {
        public ThiefSwiftness(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleThiefSwiftness;
            this.Description = Properties.Resources.AbilitiesDescriptionThiefSwiftness;
            this.Icon = this.SetIcon(Properties.Resources.quickattack);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 3;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public ThiefSwiftness()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            if (!_caster.UnitBuffsAndDebuffs.Any(x => x.AbilityName == "Swift"))
            {
                _caster.UnitBuffsAndDebuffs.Add(new Swift(_caster, null, null, null, EnumAbilityClassReq.ANY));
                int buff = (int)(_caster.BuffedAgility.IntValue * 0.40);
                _caster.BuffedAgility.IntValue += buff;
                _caster.BuffedSpeed.IntValue += (int)(buff * 0.3);

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", increasing agility by " + buff + "!";
            }
            else
            {
                this.ChatString = _caster.UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    /// <summary>
    /// Envenom: "Increases the Attack of the Thief by 50%."
    /// </summary>
    public class ThiefEnvenom : ActiveAbility
    {
        public ThiefEnvenom(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleThiefEnvenom;
            this.Description = Properties.Resources.AbilitiesDescriptionThiefEnvenom;
            this.Icon = this.SetIcon(Properties.Resources.quickattack);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 4;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public ThiefEnvenom()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            if (!_caster.UnitBuffsAndDebuffs.Any(x => x.AbilityName == "Venomous"))
            {
                _caster.UnitBuffsAndDebuffs.Add(new Venomous(_caster, null, null, null, EnumAbilityClassReq.ANY));
                int buff = (int)(_caster.BuffedAttackDamage.IntValue * 0.50);
                _caster.BuffedAttackDamage.IntValue += buff;

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", increasing attack by " + buff + "!";
            }
            else
            {
                this.ChatString = _caster.UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    /// <summary>
    /// Dirty Tricks: "Deals 250% of the Thiefs agility and 40% of his attack as damage to the target."
    /// </summary>
    public class ThiefDirtyTricks : ActiveAbility
    {
        public ThiefDirtyTricks(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleThiefDirtyTricks;
            this.Description = Properties.Resources.AbilitiesDescriptionThiefDirtyTricks;
            this.Icon = this.SetIcon(Properties.Resources.quickattack);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 5;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public ThiefDirtyTricks()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)(((_caster.BuffedAgility.IntValue * 2.5) + (_caster.BuffedAttackDamage.IntValue * 0.4)) * critModifier);
            _targets.CurrentHP.IntValue -= damage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " dealing " + damage + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting for " + damage + " damage!";
        }
    }

    /// <summary>
    /// Flurry: "Deals 10% of the Thiefs Attack to the target, 10% of his agility times."
    /// </summary>
    public class ThiefFlurry : ActiveAbility
    {
        public ThiefFlurry(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleThiefFlurry;
            this.Description = Properties.Resources.AbilitiesDescriptionThiefFlurry;
            this.Icon = this.SetIcon(Properties.Resources.quickattack);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 5;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public ThiefFlurry()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)((_caster.BuffedAttackDamage.IntValue * 0.1) * critModifier);
            int times = (int)(_caster.BuffedAgility.IntValue * 0.1);
            int totalDamage = damage * times;

            for (int i = 0; i < times; i++)
            {
                _targets.CurrentHP.IntValue -= damage;
            }

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " dealing " + damage + " damage " + times + " times, for at total of " + totalDamage + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting for " + damage + " damage " + times + " times, for at total of " + totalDamage + "!";
        }
    }

    #endregion

    #region Caretaker Abilities

    /// <summary>
    /// Body Slam: "Deals 20% of the Caretakers maximum health in damage to the target."
    /// </summary>
    public class CaretakerBodySlam : ActiveAbility
    {
        public CaretakerBodySlam(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleCaretakerBodySlam;
            this.Description = Properties.Resources.AbilitiesDescriptionCaretakerBodySlam;
            this.Icon = this.SetIcon(Properties.Resources.bodyslam);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 1;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public CaretakerBodySlam()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)((_caster.BuffedHP.IntValue * 0.25) * critModifier);
            _targets.CurrentHP.IntValue -= damage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " dealing " + damage + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting for " + damage + "!";
        }
    }

    /// <summary>
    /// Sacrifice: "Deals 55% of the Caretakers Agility in damage, but takes damage equal to the difference between Strength and Agility."
    /// </summary>
    public class CaretakerSacrifice : ActiveAbility
    {
        public CaretakerSacrifice(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleCaretakerSacrifice;
            this.Description = Properties.Resources.AbilitiesDescriptionCaretakerSacrifice;
            this.Icon = this.SetIcon(Properties.Resources.bodyslam);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 1;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public CaretakerSacrifice()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)((_caster.BuffedAgility.IntValue * 0.55) * critModifier);
            _targets.CurrentHP.IntValue -= damage;

            int damageTake = Math.Abs((_caster.BuffedAgility.IntValue-(_caster.BuffedStrength.IntValue)));

            _caster.CurrentHP.IntValue -= damageTake;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " dealing " + damage + ", but takes " + damageTake + " himself!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting for " + damage + ", but takes " + damageTake + " himself!";
        }
    }

    /// <summary>
    /// Lifeforce: "Deals 90% of the Caretakers health deficit in damage to the target AND the Caretaker."
    /// </summary>
    public class CaretakerLifeforce : ActiveAbility
    {
        public CaretakerLifeforce(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleCaretakerLifeforce;
            this.Description = Properties.Resources.AbilitiesDescriptionCaretakerLifeforce;
            this.Icon = this.SetIcon(Properties.Resources.bodyslam);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public CaretakerLifeforce()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)(((_caster.BuffedHP.IntValue - _caster.CurrentHP.IntValue) * critModifier)*0.9);
            _targets.CurrentHP.IntValue -= damage;
            _caster.CurrentHP.IntValue -= damage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " dealing " + damage + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting for " + damage + " damage!";
            
        }
    }

    /// <summary>
    /// Zeal of Humanity: "Heals a random ally for 75% of the Caretakers strength, but injures himself for 50% of the amount healed."
    /// </summary>
    public class CaretakerZealOfHumanity : ActiveAbility
    {
        public CaretakerZealOfHumanity(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleCaretakerZealOfHumanity;
            this.Description = Properties.Resources.AbilitiesDescriptionCaretakerZealOfHumanity;
            this.Icon = this.SetIcon(Properties.Resources.bodyslam);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public CaretakerZealOfHumanity()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int heal = (int)((_caster.BuffedStrength.IntValue * 0.75) * critModifier);
            int damagetaken = (int)(heal * 0.5);
            int index = 0;

            Random r = new Random();

            foreach (var item in alliesIndexes)
            {
                if (_allies[item].CurrentHP.IntValue > 0)
                {
                    index = item;
                    if ((_allies[item].CurrentHP.IntValue + heal) > _allies[item].BuffedHP.IntValue)
                        _allies[item].CurrentHP.IntValue = _allies[item].BuffedHP.IntValue;
                    else
                        _allies[item].CurrentHP.IntValue += heal;
                    break;
                }
            }

            _caster.CurrentHP.IntValue -= damagetaken;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[index].UnitName + " healing for " + heal + ", but takes " + damagetaken + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _allies[index].UnitName + " critically healing for " + heal + ", but takes " + damagetaken + " damage!";
        }
    }

    /// <summary>
    /// Action: "Increases the strength and agility of the Caretaker by 20%."
    /// </summary>
    public class CaretakerAction : ActiveAbility
    {
        public CaretakerAction(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleCaretakerAction;
            this.Description = Properties.Resources.AbilitiesDescriptionCaretakerAction;
            this.Icon = this.SetIcon(Properties.Resources.bodyslam);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 3;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public CaretakerAction()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            if (!_caster.UnitBuffsAndDebuffs.Any(x => x.AbilityName == "In Action"))
            {
                _caster.UnitBuffsAndDebuffs.Add(new InAction(_caster, null, null, null, EnumAbilityClassReq.ANY));
                int strbuff = (int)(_caster.BuffedStrength.IntValue * 0.2);
                int agibuff = (int)(_caster.BuffedAgility.IntValue * 0.2);
                _caster.BuffedStrength.IntValue +=  strbuff;
                _caster.BuffedAgility.IntValue += agibuff;

                _caster.BuffedHP.IntValue += (int)(strbuff * 0.3);
                _caster.BuffedSpeed.IntValue += (int)(agibuff * 0.3);

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", increasing strength by " + strbuff + " and agility by " + agibuff + "!";
            }
            else
            {
                this.ChatString = _caster.UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    /// <summary>
    /// Lifeblood: "The Caretaker heals a target ally to full, but takes the allys' health deficit in damage."
    /// </summary>
    public class CaretakerLifeblood : ActiveAbility
    {
        public CaretakerLifeblood(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleCaretakerLifeblood;
            this.Description = Properties.Resources.AbilitiesDescriptionCaretakerLifeblood;
            this.Icon = this.SetIcon(Properties.Resources.bodyslam);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 4;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public CaretakerLifeblood()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            int index = -1;
            int deficit = 0;

            foreach (var item in alliesIndexes)
            {
                if (_allies[item].CurrentHP.IntValue > 0)
                {
                    index = item;
                    break;
                }
            }

            if (index != -1)
            {
                deficit = _allies[index].BuffedHP.IntValue - _allies[index].CurrentHP.IntValue;
                _allies[index].BuffedHP.IntValue += deficit;

                _caster.CurrentHP.IntValue -= deficit;

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " and heals " + _allies[index].UnitName + " to full, but takes " + deficit + " damage!";
            }
            else
            {
                this.ChatString = "No valid target for " + _caster.UnitName + "'s " + this.AbilityName + "!";
            }
            

        }
    }

    /// <summary>
    /// Power and Dexterity: "Deals 125% of the Caretakers combined Strength and Agility to the target."
    /// </summary>
    public class CaretakerPowerAndDexterity : ActiveAbility
    {
        public CaretakerPowerAndDexterity(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleCaretakerPowerAndDexterity;
            this.Description = Properties.Resources.AbilitiesDescriptionCaretakerPowerAndDexterity;
            this.Icon = this.SetIcon(Properties.Resources.bodyslam);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 5;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public CaretakerPowerAndDexterity()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)(((_caster.BuffedAgility.IntValue + _caster.BuffedStrength.IntValue) * 1.40) * critModifier);
            _targets.CurrentHP.IntValue -= damage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " dealing " + damage + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting for " + damage + " damage!";
        }
    }

    /// <summary>
    /// Deathdefiance: "Splits the Caretakers health deficit as healing between all allies."
    /// </summary>
    public class CaretakerDeathdefiance : ActiveAbility
    {
        public CaretakerDeathdefiance(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleCaretakerDeathdefiance;
            this.Description = Properties.Resources.AbilitiesDescriptionCaretakerDeathdefiance;
            this.Icon = this.SetIcon(Properties.Resources.bodyslam);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 5;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public CaretakerDeathdefiance()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int healing = (int)((_caster.BuffedHP.IntValue - _caster.CurrentHP.IntValue) * critModifier);
            int numberAlive = 0;
            int realHealing = 0;

            foreach (var item in _allies)
            {
                if (item.CurrentHP.IntValue > 0)
                    numberAlive++;
            }

            realHealing = (int)((double)healing / (double)numberAlive);

            foreach (var item in _allies)
            {
                if (item.CurrentHP.IntValue > 0)
                {
                    if ((item.CurrentHP.IntValue + realHealing) > item.BuffedHP.IntValue)
                        item.CurrentHP.IntValue = item.BuffedHP.IntValue;
                    else
                        item.CurrentHP.IntValue += realHealing;
                }
            }

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", splitting " + healing + " healing between allies, healing each for " + realHealing + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", splitting " + healing + " healing between allies, critically healing each for " + realHealing + "!";
        }
    }
    #endregion

    #region Synergist Abilities

    /// <summary>
    /// Duality: "Deals 25% of the Synergists combined intellect and agility in damage."
    /// </summary>
    public class SynergistDuality : ActiveAbility
    {
        public SynergistDuality(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleSynergistDuality;
            this.Description = Properties.Resources.AbilitiesDescriptionSynergistDuality;
            this.Icon = this.SetIcon(Properties.Resources.duality);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 1;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public SynergistDuality()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)((((int)_caster.BuffedIntellingence.IntValue +_caster.BuffedAgility.IntValue) * 0.25) * critModifier);
            _targets.CurrentHP.IntValue -= damage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " dealing " + damage + " damage!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting for " + damage + " damage!";
        }
    }

    /// <summary>
    /// Agile Mind: "Deals damage for 55% of the Synergists Agility, but subtracts the difference between Agility and Intellect from the damage."
    /// </summary>
    public class SynergistAgileMind : ActiveAbility
    {
        public SynergistAgileMind(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleSynergistAgileMind;
            this.Description = Properties.Resources.AbilitiesDescriptionSynergistAgileMind;
            this.Icon = this.SetIcon(Properties.Resources.duality);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 1;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public SynergistAgileMind()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)((_caster.BuffedAgility.IntValue * 0.55) * critModifier);
            int difference = Math.Abs(_caster.BuffedAgility.IntValue - _caster.BuffedIntellingence.IntValue);
            int realDamage = (damage - difference);

            _targets.CurrentHP.IntValue -= realDamage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " dealing " + realDamage + "! " + difference + " was substracted!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting " + realDamage + "! " + difference + " was substracted!";
        }
    }

    /// <summary>
    /// Balance: "Of Agility and Intellect, increases lowest stat by 15% and highest by 10%."
    /// </summary>
    public class SynergistBalance : ActiveAbility
    {
        public SynergistBalance(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleSynergistBalance;
            this.Description = Properties.Resources.AbilitiesDescriptionSynergistBalance;
            this.Icon = this.SetIcon(Properties.Resources.duality);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public SynergistBalance()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            if (!_caster.UnitBuffsAndDebuffs.Any(x => x.AbilityName == "Balanced"))
            {
                _caster.UnitBuffsAndDebuffs.Add(new Balanced(_caster, null, null, null, EnumAbilityClassReq.ANY));
                int agiBuff = 0;
                int intBuff = 0;
                if (_caster.BuffedIntellingence.IntValue > _caster.BuffedAgility.IntValue)
                {
                    intBuff = (int)(_caster.BuffedIntellingence.IntValue * 0.1);
                    agiBuff = (int)(_caster.BuffedAgility.IntValue * 0.15);
                    _caster.BuffedIntellingence.IntValue += intBuff;
                    _caster.BuffedAgility.IntValue += agiBuff;
                }
                else
                {
                    intBuff = (int)(_caster.BuffedIntellingence.IntValue * 0.15);
                    agiBuff = (int)(_caster.BuffedAgility.IntValue * 0.1);
                    _caster.BuffedIntellingence.IntValue += intBuff;
                    _caster.BuffedAgility.IntValue += agiBuff;
                }

                _caster.BuffedCrit.IntValue += (int)(intBuff * 0.3);
                _caster.BuffedSpeed.IntValue += (int)(agiBuff * 0.3);

                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " increasing agility by " + agiBuff + " and increasing intellect by " + intBuff + "!";
            }
            else
            {
                this.ChatString = _caster.UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    /// <summary>
    /// Mental Agility: "Deals 115% of the Synergists Intellect in damage, subtracting the difference between Intellect and Agility."
    /// </summary>
    public class SynergistMentalAgility : ActiveAbility
    {
        public SynergistMentalAgility(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleSynergistMentalAgility;
            this.Description = Properties.Resources.AbilitiesDescriptionSynergistMentalAgility;
            this.Icon = this.SetIcon(Properties.Resources.duality);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public SynergistMentalAgility()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)((_caster.BuffedIntellingence.IntValue*1.15) * critModifier);
            int difference = Math.Abs(_caster.BuffedAgility.IntValue - _caster.BuffedIntellingence.IntValue);
            int realDamage = (damage - difference);

            _targets.CurrentHP.IntValue -= realDamage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " dealing " + realDamage + "! " + difference + " was substracted!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting " + realDamage + "! " + difference + " was substracted!";
        }
    }

    /// <summary>
    /// Align: "Increases the intellect and agility of the Synergist by 20%."
    /// </summary>
    public class SynergistAlign : ActiveAbility
    {
        public SynergistAlign(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleSynergistAlign;
            this.Description = Properties.Resources.AbilitiesDescriptionSynergistAlign;
            this.Icon = this.SetIcon(Properties.Resources.duality);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 3;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public SynergistAlign()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            if (!_caster.UnitBuffsAndDebuffs.Any(x => x.AbilityName == "Aligned"))
            {
                _caster.UnitBuffsAndDebuffs.Add(new Aligned(_caster, null, null, null, EnumAbilityClassReq.ANY));
                int intBuff = (int)(_caster.BuffedIntellingence.IntValue * 0.2);
                int agiBuff = (int)(_caster.BuffedAgility.IntValue * 0.2);
                _caster.BuffedIntellingence.IntValue += intBuff;
                _caster.BuffedAgility.IntValue += agiBuff;

                _caster.BuffedCrit.IntValue += (int)(intBuff * 0.3);
                _caster.BuffedSpeed.IntValue += (int)(agiBuff * 0.3);


                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " increasing agility by " + agiBuff + " and increasing intellect by " + intBuff + "!";
            }
            else
            {
                this.ChatString = _caster.UnitName + " is already affected by " + this.AbilityName + "!";
                _caster.CurrentTurnPoints.IntValue += this.TurnPointCost;
            }
        }
    }

    /// <summary>
    /// Collapsed Equality: "Heals all allies for 50/37/25 % of the Synergists Intellect, but reduces intellect by 20%."
    /// </summary>
    public class SynergistCollapsedEquality : ActiveAbility
    {
        public SynergistCollapsedEquality(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleSynergistCollapsedEquality;
            this.Description = Properties.Resources.AbilitiesDescriptionSynergistCollapsedEquality;
            this.Icon = this.SetIcon(Properties.Resources.duality);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 4;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public SynergistCollapsedEquality()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int heal = 0;
            int numberAlive = 0;

            foreach (var item in _allies)
            {
                if (item.CurrentHP.IntValue > 0)
                    numberAlive++;
            }

            switch (numberAlive)
            {
                case 1:
                case 2:
                    heal = (int)((_caster.BuffedIntellingence.IntValue * 0.50) * critModifier);
                    break;
                case 3:
                    heal = (int)((_caster.BuffedIntellingence.IntValue * 0.37) * critModifier);
                    break;
                case 4:
                    heal = (int)((_caster.BuffedIntellingence.IntValue * 0.25) * critModifier);
                    break;
                default:
                    break;
            }

            foreach (var item in _allies)
            {
                if (item.CurrentHP.IntValue > 0)
                {
                    if ((item.CurrentHP.IntValue + heal) > item.BuffedHP.IntValue)
                        item.CurrentHP.IntValue = item.BuffedHP.IntValue;
                    else
                        item.CurrentHP.IntValue += heal;
                }
            }
            
            int reduced = (int)(_caster.BuffedIntellingence.IntValue * 0.20);

            _caster.BuffedIntellingence.IntValue -= reduced;
            _caster.BuffedCrit.IntValue -= (int)(reduced * 0.3);

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", healing all allies for " + heal + ", but decreases intellect by " + reduced + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", critically healing all allies for " + heal + ", but decreases intellect by " + reduced + "!";
        }
    }

    /// <summary>
    /// Synergy: "Deals 145% of the Synergists combined intellect and agility as damage, but subtracts difference between them from this amount:"
    /// </summary>
    public class SynergistSynergy : ActiveAbility
    {
        public SynergistSynergy(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleSynergistSynergy;
            this.Description = Properties.Resources.AbilitiesDescriptionSynergistSynergy;
            this.Icon = this.SetIcon(Properties.Resources.duality);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 5;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public SynergistSynergy()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int damage = (int)(((_caster.BuffedAgility.IntValue + _caster.BuffedIntellingence.IntValue) * 1.45) * critModifier);
            int difference = Math.Abs(_caster.BuffedAgility.IntValue - _caster.BuffedIntellingence.IntValue);

            int realdamage = (damage - difference);

            _targets.CurrentHP.IntValue -= realdamage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " dealing " + realdamage + "! " + difference + " was substracted!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting for " + realdamage + "! " + difference + " was substracted!";
        }
    }

    /// <summary>
    /// Complete Balance: "Aligns all allies health to be at the average percentage and heals them for 8% of the Synergists agility and intellect."
    /// </summary>
    public class SynergistCompleteBalance : ActiveAbility
    {
        public SynergistCompleteBalance(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = Properties.Resources.AbilitiesTitleSynergistCompleteBalance;
            this.Description = Properties.Resources.AbilitiesDescriptionSynergistCompleteBalance;
            this.Icon = this.SetIcon(Properties.Resources.duality);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 5;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public SynergistCompleteBalance()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            double averagePercent = 0.0;
            double sumPercent = 0.0;
            int numberAlive = 0;
            int heal = 0;
            int temp = 0;

            foreach (var item in _allies)
            {
                if (item.CurrentHP.IntValue > 0)
                {
                    sumPercent += ((double)item.CurrentHP.IntValue / (double)item.BuffedHP.IntValue);
                    numberAlive++;
                }
            }

            averagePercent = (sumPercent / numberAlive);

            heal = (int)(((_caster.BuffedAgility.IntValue + _caster.BuffedIntellingence.IntValue) * 0.08) * critModifier);

            foreach (var item in _allies)
            {
                if (item.CurrentHP.IntValue > 0)
                {
                    temp = (int)(averagePercent * item.BuffedHP.IntValue);
                    item.CurrentHP.IntValue = temp;
                    if ((item.CurrentHP.IntValue + heal) > item.BuffedHP.IntValue)
                        item.CurrentHP.IntValue = item.BuffedHP.IntValue;
                    else
                        item.CurrentHP.IntValue += heal;
                }
            }

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", bringing all allies to " + (int)(averagePercent * 100) + "% of their maximum health and then heals them for " + heal + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + ", bringing all allies to " + (int)(averagePercent * 100) + "% of their maximum health and then critically heals them for " + heal + "!";
        }
    }

    #endregion

    #endregion

    #region NPC Abilities
    /// <summary>
    /// This ability deals damage to the 1 target, based on the NPCs level.
    /// </summary>
    public class NPCFireball : ActiveAbility
    {
        public NPCFireball(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = "Fireball";
            this.Description = "This ability deals 175% the units level in damage.";
            this.Icon = this.SetIcon(Properties.Resources.fireball);
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public NPCFireball()
        { }

        int damageValue = 0;
        public override void UseAbility(Units.NPC _caster, List<Units.Character> _targets)
        {
            string damagedone = "";
            Random r = new Random();
            for (int i = 0; i < _targets.Count; i++)
            {
                int index;
                do
                {
                    index = r.Next(0, _targets.Count);
                } while (_targets[index].CurrentHP.IntValue <= 0 && _targets.Any(x => x.CurrentHP.IntValue > 0));

                int damage = (int)Math.Abs(_caster.UnitLevel * 1.75);

                _targets[index].CurrentHP.IntValue -= damage;

                 damagedone += _targets[index].UnitName + " for " + damage + ", ";
            }
            this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + damagedone + "!";
        }
    }

    public class NPCHeal : ActiveAbility
    {
        public NPCHeal(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = "Heal";
            this.Description = "This ability heals the unit for 7% of its max HP";
            this.Icon = this.SetIcon(Properties.Resources.heal);
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public NPCHeal()
        { }

        int damageValue = 0;
        public override void UseAbility(Units.NPC _caster, List<Units.Character> _targets)
        {
            int heal = (int)Math.Abs(_caster.BuffedHP.IntValue * 0.07);

            if (heal + _caster.CurrentHP.IntValue > _caster.BuffedHP.IntValue)
                _caster.CurrentHP.IntValue = _caster.BuffedHP.IntValue;
            else
                _caster.CurrentHP.IntValue += heal;

            this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _caster.UnitName + " for " + heal + "!";
        }
    }

    public class NPCNuke : ActiveAbility
    {
        public NPCNuke(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = "Nuke";
            this.Description = "This ability deals 600% of the casters level in damage. Can only be used every 4 turns.";
            this.Icon = this.SetIcon(Properties.Resources.fireball);
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public NPCNuke()
        { }

        int damageValue = 0;
        public override void UseAbility(Units.NPC _caster, List<Units.Character> _targets)
        {
            string damagedone = "";
            int damage = Math.Abs(_caster.UnitLevel * 6);
            for (int i = 0; i < _targets.Count; i++)
            {
                if (_targets[i].CurrentHP.IntValue > 0)
                {
                    _targets[i].CurrentHP.IntValue -= damage;
                    damagedone += _targets[i].UnitName + " for " + damage + ", ";
                }
            }
            this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + damagedone + "!";
        }
    }

    public class NPCAtonementSmite : ActiveAbility
    {
        public NPCAtonementSmite(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = "Atonement Smite";
            this.Description = "This ability deals the units level in damage and heals it for 2% of its maximum health.";
            this.Icon = this.SetIcon(Properties.Resources.fireball);
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public NPCAtonementSmite()
        { }

        int damageValue = 0;
        public override void UseAbility(Units.NPC _caster, List<Units.Character> _targets)
        {
            string damagedone = "";
            Random r = new Random();
            for (int i = 0; i < _targets.Count; i++)
            {
                int index;
                do
                {
                    index = r.Next(0, _targets.Count);
                } while (_targets[index].CurrentHP.IntValue <= 0 && _targets.Any(x => x.CurrentHP.IntValue > 0));

                int damage = Math.Abs(_caster.UnitLevel);
                int healing = (int)(_caster.BuffedHP.IntValue * 0.02);

                if (healing + _caster.CurrentHP.IntValue >= _caster.BuffedHP.IntValue)
                    _caster.CurrentHP.IntValue = _caster.BuffedHP.IntValue;
                else
                    _caster.CurrentHP.IntValue += healing;

                _targets[index].CurrentHP.IntValue -= damage;

                damagedone += _targets[index].UnitName + " for " + damage + " and heals himself for " + healing + ", ";
            }
            this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + damagedone + "!";
        }
    }

    public class NPCGrow : ActiveAbility
    {
        public NPCGrow(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = "Grow";
            this.Description = "This ability increases the monsters health by for 10%";
            this.Icon = this.SetIcon(Properties.Resources.heal);
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public NPCGrow()
        { }

        int damageValue = 0;
        public override void UseAbility(Units.NPC _caster, List<Units.Character> _targets)
        {
            int buff = (int)Math.Abs(_caster.BuffedHP.IntValue * 0.10);

            _caster.BuffedHP.IntValue += buff;

            this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _caster.UnitName + ", increasing its max health by " + buff + "!";
        }
    }

    public class NPCDesperation : ActiveAbility
    {
        public NPCDesperation(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = "Desperation";
            this.Description = "This ability deals 15% of the monsters health deficit in damage to a character!";
            this.Icon = this.SetIcon(Properties.Resources.strength);
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public NPCDesperation()
        { }

        int damageValue = 0;
        public override void UseAbility(Units.NPC _caster, List<Units.Character> _targets)
        {
            int damage = (int)Math.Abs((_caster.BuffedHP.IntValue-_caster.CurrentHP.IntValue) * 0.15);

            Random r = new Random();
            int index;
            do
            {
                index = r.Next(_targets.Count);
            } while (_targets[index].CurrentHP.IntValue < 0 && _targets.Any(x => x.CurrentHP.IntValue > 0));

            _targets[index].CurrentHP.IntValue -= damage;

            this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets[index].UnitName + ", dealing " + damage + "!";
        }
    }

    public class NPCGrowingDespair : ActiveAbility
    {
        public NPCGrowingDespair(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = "Growing Despair";
            this.Description = "This ability deals increasing damage to a character.";
            this.Icon = this.SetIcon(Properties.Resources.strength);
            
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public NPCGrowingDespair()
        { }
        int iteration = 1;
        int damageValue = 0;
        public override void UseAbility(Units.NPC _caster, List<Units.Character> _targets)
        {
            int damage = (int)(_caster.UnitLevel * (0.5 * iteration));
            Random r = new Random();
            int index;
            do
            {
                index = r.Next(_targets.Count);
            } while (_targets[index].CurrentHP.IntValue < 0 && _targets.Any(x => x.CurrentHP.IntValue > 0));

            _targets[index].CurrentHP.IntValue -= damage;
            
            this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets[index].UnitName + ", dealing " + damage + " to each!";
            iteration++;
        }
    }

    #endregion

    #region Unused abilities (Old abilities that are there for save purposes only)

    /// <summary>
    /// Copycat: "Deals 95% of the Thiefs allies' highest stat in damage."
    /// </summary>
    public class ThiefCopycat : ActiveAbility
    {
        public ThiefCopycat(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = "Copycat";
            this.Description = Properties.Resources.AbilitiesDescriptionThiefPoisonedBlade;
            this.Icon = this.SetIcon(Properties.Resources.quickattack);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Damage;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public ThiefCopycat()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            double critModifier = Function.CombatHandler.CritCalculator(_caster.UnitLevel, _caster.BuffedCrit.IntValue);
            int best = 0;
            int damage = 0;
            EnumAttributeType type = EnumAttributeType.Strength;
            string statOwner = "";

            foreach (var item in _allies)
            {
                if (item.BuffedIntellingence.IntValue > best)
                {
                    statOwner = item.UnitName;
                    best = item.BuffedIntellingence.IntValue;
                    type = EnumAttributeType.Intellect;
                }
                if (item.BuffedStrength.IntValue > best)
                {
                    statOwner = item.UnitName;
                    best = item.BuffedStrength.IntValue;
                    type = EnumAttributeType.Strength;
                }
                if (item.BuffedAgility.IntValue > best)
                {
                    statOwner = item.UnitName;
                    best = item.BuffedAgility.IntValue;
                    type = EnumAttributeType.Agility;
                }
            }

            damage = (int)((best * 0.95) * critModifier);
            _targets.CurrentHP.IntValue -= damage;

            if (critModifier == 1.0)
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " dealing " + damage + " by using " + statOwner + "'s " + type.ToString().ToLower() + "!";
            else
                this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " on " + _targets.UnitName + " critting for " + damage + " by using " + statOwner + "'s " + type.ToString().ToLower() + "!";
        }
    }

    /// <summary>
    /// Balance - Agility: "Decreases intellect by 10%, but increases agility by this amount."
    /// </summary>
    public class SynergistBalanceAgility : ActiveAbility
    {
        public SynergistBalanceAgility(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = "Balance - Agility";
            this.Description = "Decreases intellect by 10%, but increases agility by this amount.";
            this.Icon = this.SetIcon(Properties.Resources.duality);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public SynergistBalanceAgility()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            int temp = (int)(_caster.BuffedIntellingence.IntValue * 0.10);
            _caster.BuffedIntellingence.IntValue -= temp;
            _caster.BuffedAgility.IntValue += temp;

            this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " increasing agility and decreasing intellect by " + temp + "!";
        }
    }

    /// <summary>
    /// Balance - Intellect: "Decreases agility by 10%, but increases intellect by this amount."
    /// </summary>
    public class SynergistBalanceIntellect : ActiveAbility
    {
        public SynergistBalanceIntellect(Character _char, string _name, string _description, Image _icon, EnumAbilityClassReq _classReq)
            : base(_char, _name, _description, _icon, _classReq)
        {
            this.AbilityName = "Balance - Intellect";
            this.Description = "Decreases agility by 10%, but increases intellect by this amount.";
            this.Icon = this.SetIcon(Properties.Resources.duality);
            this.NumberOfTargets = 1;
            this.TurnPointCost = 2;
            this.DamageOrHealing = EnumActiveAbilityType.Healing;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public SynergistBalanceIntellect()
        { }

        public override void UseAbility(Units.Character _caster, List<Units.Character> _allies, List<int> alliesIndexes, Units.NPC _targets)
        {
            int temp = (int)(_caster.BuffedAgility.IntValue * 0.10);
            _caster.BuffedAgility.IntValue -= temp;
            _caster.BuffedIntellingence.IntValue += temp;

            this.ChatString = _caster.UnitName + " uses " + this.AbilityName + " increasing intellect and decreasing agility by " + temp + "!";
        }
    }

    #endregion
}
