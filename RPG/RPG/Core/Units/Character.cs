using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Core.Units
{
    public class Character : Unit
    {
        #region Fields
        string owner = "";
        private EnumCharClass charClass;
        // Base is the base of the attributes, only modified when the char levels up.
        // Buffed is the attributes value after getting armor on, debuffs and so on, meaning the values combat are based upon
        UnitAttribute baseStrength = new UnitAttribute(EnumAttributeType.Strength);
        UnitAttribute baseAgility = new UnitAttribute(EnumAttributeType.Agility);
        UnitAttribute baseIntellingence = new UnitAttribute(EnumAttributeType.Intellect);
        UnitAttribute buffedStrength = new UnitAttribute(EnumAttributeType.Strength);
        UnitAttribute buffedAgility = new UnitAttribute(EnumAttributeType.Agility);
        UnitAttribute buffedIntellingence = new UnitAttribute(EnumAttributeType.Intellect);
        UnitAttribute baseCrit = new UnitAttribute(EnumAttributeType.Crit);
        UnitAttribute buffedCrit = new UnitAttribute(EnumAttributeType.Crit);
        UnitAttribute baseSpeed = new UnitAttribute(EnumAttributeType.Speed);
        UnitAttribute buffedSpeed = new UnitAttribute(EnumAttributeType.Speed);
        UnitAttribute unUsedAttributePoints = new UnitAttribute(EnumAttributeType.Unused);

        UnitAttribute baseTurnPoints = new UnitAttribute(EnumAttributeType.Turnpoints);
        UnitAttribute currentTurnPoints = new UnitAttribute(EnumAttributeType.Turnpoints);

        UnitAttribute baseArmor = new UnitAttribute(EnumAttributeType.Armor, 0);
        UnitAttribute buffedArmor = new UnitAttribute(EnumAttributeType.Armor, 0);
        UnitAttribute baseAttackDamage = new UnitAttribute(EnumAttributeType.Attackdamage, 0);
        UnitAttribute buffedAttackDamage = new UnitAttribute(EnumAttributeType.Attackdamage, 0);
        //The experience variables of the character
        private int charCurrentXP;
        private int charXPToLevel;
        Gear charGear;
        #endregion

        #region Properties

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public EnumCharClass CharClass
        {
            get { return charClass; }
            set { charClass = value; }
        }
        
        public UnitAttribute BaseAgility
        {
            get { return baseAgility; }
            set { baseAgility = value; }
        }

        public UnitAttribute BaseStrength
        {
            get { return baseStrength; }
            set { baseStrength = value; }
        }

        public UnitAttribute BaseIntellingence
        {
            get { return baseIntellingence; }
            set { baseIntellingence = value; }
        }

        public UnitAttribute BaseCrit
        {
            get { return baseCrit; }
            set { baseCrit = value; }
        }

        public UnitAttribute BaseSpeed
        {
            get { return baseSpeed; }
            set { baseSpeed = value; }
        }

        public UnitAttribute BuffedAgility
        {
            get { return buffedAgility; }
            set { buffedAgility = value; }
        }

        public UnitAttribute BuffedStrength
        {
            get { return buffedStrength; }
            set { buffedStrength = value; }
        }

        public UnitAttribute BuffedIntellingence
        {
            get { return buffedIntellingence; }
            set { buffedIntellingence = value; }
        }

        public UnitAttribute BuffedCrit
        {
            get { return buffedCrit; }
            set { buffedCrit = value; }
        }

        public UnitAttribute BuffedSpeed
        {
            get { return buffedSpeed; }
            set { buffedSpeed = value; }
        }

        public UnitAttribute BaseArmor
        {
            get { return baseArmor; }
            set { baseArmor = value; }
        }

        public UnitAttribute BaseAttackDamage
        {
            get { return baseAttackDamage; }
            set { baseAttackDamage = value; }
        }

        public UnitAttribute BuffedArmor
        {
            get { return buffedArmor; }
            set { buffedArmor = value; }
        }

        public UnitAttribute BuffedAttackDamage
        {
            get { return buffedAttackDamage; }
            set { buffedAttackDamage = value; }
        }

        public UnitAttribute BaseTurnPoints
        {
            get { return baseTurnPoints; }
            set { baseTurnPoints = value; }
        }

        public UnitAttribute CurrentTurnPoints
        {
            get { return currentTurnPoints; }
            set { currentTurnPoints = value; }
        }

        public UnitAttribute UnUsedAttributePoints
        {
            get { return unUsedAttributePoints; }
            set { unUsedAttributePoints = value; }
        }

        public int CharCurrentXP
        {
            get { return charCurrentXP; }
            set { charCurrentXP = value;}
        }

        public int CharXPToLevel
        {
            get 
            {   
                charXPToLevel = (int)((10 * this.UnitLevel)*Math.Pow(1.06,(float)this.UnitLevel));
                return charXPToLevel;
            }
            set { charXPToLevel = value; }
        }

        public Gear CharGear
        {
            get { return charGear; }
            set { charGear = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// The main constructor for a character. All fields must be filled.
        /// </summary>
        /// <param name="_name">The name of the character</param>
        /// <param name="_level">The level of the character granted-</param>
        /// <param name="_basehp">The max amount of health the character</param>
        /// <param name="_curhp">The CURRENT amount of health</param>
        /// <param name="_charclass"> The class of the character</param>
        /// <param name="_curxp">The current amount of experience the character has</param>
        /// <param name="_str">The amount of strength the character has</param>
        /// <param name="_agi">The amount of agility the character has</param>
        /// <param name="_int">The amount of intellingence the character has</param>
        /// <param name="_armor">The armor of the character</param>
        /// <param name="_meleeattack">The melee attack damage of the character</param>
        /// <param name="_gear">The characters current gear</param>
        /// <param name="_gear">The characters inventory</param>
        public Character(string _name, int _level, int _basehp, int _curhp, EnumCharClass _charclass, int _curxp, int _str, int _agi, int _int, int _crit, int _armor, int _meleeattack, Gear _gear)
            : base(_name, _level, _basehp, _curhp)
        {
            this.charClass = _charclass;
            this.charCurrentXP = _curxp;
            this.baseStrength.IntValue = _str;
            this.baseAgility.IntValue = _agi;
            this.baseIntellingence.IntValue = _int;
            this.buffedStrength.IntValue = _str;
            this.buffedAgility.IntValue = _agi;
            this.buffedIntellingence.IntValue = _int;
            this.BaseCrit.IntValue = _crit;
            this.BuffedCrit.IntValue = _crit;
            this.BuffedAttackDamage.IntValue = _meleeattack;
            this.BaseArmor.IntValue = _armor;
            this.BaseAttackDamage.IntValue = _meleeattack;
            this.BuffedArmor.IntValue = _armor;
            this.BuffedAttackDamage.IntValue = _meleeattack;

            if (_gear == null)
                this.charGear = new Gear();
            else
                this.charGear = _gear;
            this.baseTurnPoints.IntValue = (this.UnitLevel / 10) + 1;
            this.currentTurnPoints = this.baseTurnPoints;

            this.UnitBuffsAndDebuffs = new List<Abilities.BuffsAndDebuffs>();
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public Character()
        { }

        #endregion

        #region Functions

        #region Experience functions
        /// <summary>
        /// This function increases the currentXP of the character. Please note that it does NOT automatically level up the character, since the GM must specify how much XP is needed to level up and how much stats increase on level up.
        /// </summary>
        /// <param name="xprecieved">The amount of XP the Character recieves</param>
        public void CharRecieveXP(int xprecieved)
        {
            if (this.UnitLevel != 60)
            {
                if (charCurrentXP + xprecieved < charXPToLevel)
                    this.charCurrentXP += xprecieved;
                else
                {
                    charCurrentXP = (charCurrentXP + xprecieved) - charXPToLevel;
                    this.CharLevelUp();
                }
            }

            
        }

        /// <summary>
        /// This function levels up a character. It only increases the BASE values of the characters attributes
        /// </summary>
        public void CharLevelUp()
        {
            this.BaseHP.IntValue += 2;
            int temp = this.UnitLevel+1;
            this.baseCrit.IntValue = temp;
            this.baseSpeed.IntValue = temp;
            this.UnUsedAttributePoints.IntValue += 4;
            this.UnitLevel++;
            this.baseTurnPoints.IntValue = (this.UnitLevel / 10) + 1;
            RPG.UI.MessageForm mes = new RPG.UI.MessageForm("Your character " + this.UnitName + " leveled up!" + Environment.NewLine + this.UnitName + " is now level " + this.UnitLevel + "!");
            mes.ShowDialog();
            this.LevelUpClassAbilties(charClass, false);
            this.LevelUpAnyClassAbilties(false);
        }

        private void LevelUpAnyClassAbilties(bool _reset)
        {
            if (this.UnitLevel == 1)
            {
                if (!_reset)
                {
                    RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Battle Regeneration!");
                    mes.ShowDialog();
                }
                this.AddActiveAbility(new Abilities.MeleeAttack(this, null, null, null, Core.EnumAbilityClassReq.ANY));
                this.AddPassiveAbility(new Abilities.MeleeAttack(this,null, null, null, Core.EnumAbilityClassReq.ANY));
            }
            if (this.UnitLevel == 5)
            {
                if (!_reset)
                {
                    RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Battle Regeneration!");
                    mes.ShowDialog();
                }
                this.AddActiveAbility(new Abilities.BattleRegeneration(this, null, null, null, Core.EnumAbilityClassReq.ANY));
                this.AddPassiveAbility(new Abilities.BattleRegeneration(this, null, null, null, Core.EnumAbilityClassReq.ANY));
            }
            if (this.UnitLevel == 10)
            {
                if (!_reset)
                {
                    RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Empowerment!");
                    mes.ShowDialog();
                }
                this.AddActiveAbility(new Abilities.Empowerment(this, null, null, null, EnumAbilityClassReq.ANY));
                this.AddPassiveAbility(new Abilities.Empowerment(this, null, null, null, EnumAbilityClassReq.ANY));
            }
            if (this.UnitLevel == 20)
            {
                if (!_reset)
                {
                    RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Invigorate!");
                    mes.ShowDialog();
                }
                this.AddActiveAbility(new Abilities.Invigorate(this, null, null, null, EnumAbilityClassReq.ANY));
                this.AddPassiveAbility(new Abilities.Invigorate(this, null, null, null, EnumAbilityClassReq.ANY));
            }
            if (this.UnitLevel == 30)
            {
                if (!_reset)
                {
                    RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Double Swing!");
                    mes.ShowDialog();
                }
                this.AddActiveAbility(new Abilities.DoubleSwing(this, null, null, null, EnumAbilityClassReq.ANY));
                this.AddPassiveAbility(new Abilities.DoubleSwing(this, null, null, null, EnumAbilityClassReq.ANY));
            }
            if (this.UnitLevel == 40)
            {
                if (!_reset)
                {
                    RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Opportunity!");
                    mes.ShowDialog();
                }
                this.AddActiveAbility(new Abilities.Opportunity(this, null, null, null, EnumAbilityClassReq.ANY));
                this.AddPassiveAbility(new Abilities.Opportunity(this, null, null, null, EnumAbilityClassReq.ANY));
            }
            if (this.UnitLevel == 50)
            {
                if (!_reset)
                {
                    RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Totalitarism!");
                    mes.ShowDialog();
                }
                this.AddActiveAbility(new Abilities.Totalitarism(this, null, null, null, EnumAbilityClassReq.ANY));
                this.AddPassiveAbility(new Abilities.Totalitarism(this, null, null, null, EnumAbilityClassReq.ANY));
            }
            if (this.UnitLevel == 57)
            {
                if (!_reset)
                {
                    RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Ascend!");
                    mes.ShowDialog();
                }
                this.AddActiveAbility(new Abilities.Ascend(this, null, null, null, EnumAbilityClassReq.ANY));
                this.AddPassiveAbility(new Abilities.Ascend(this, null, null, null, EnumAbilityClassReq.ANY));
            }
        }

        private void LevelUpClassAbilties(EnumCharClass _class, bool _reset)
        {
            switch (_class)
            {
                case EnumCharClass.Warrior:
                    #region warrior
                    if (this.UnitLevel == 2)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Strength!");
                            mes.ShowDialog();
                        }
                        this.AddActiveAbility(new Abilities.WarriorStrength(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                        this.AddPassiveAbility(new Abilities.WarriorStrength(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                    }
                    if (this.UnitLevel == 8)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Power Strike!");
                            mes.ShowDialog();
                        }
                        this.AddActiveAbility(new Abilities.WarriorPowerStrike(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                        this.AddPassiveAbility(new Abilities.WarriorPowerStrike(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                    }
                    if (this.UnitLevel == 15)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Blind Rage!");
                            mes.ShowDialog();
                        }
                        this.AddActiveAbility(new Abilities.WarriorBlindRage(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                        this.AddPassiveAbility(new Abilities.WarriorBlindRage(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                    }
                    if (this.UnitLevel == 25)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Rampage!");
                            mes.ShowDialog();
                        }
                        this.AddActiveAbility(new Abilities.WarriorRampage(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                        this.AddPassiveAbility(new Abilities.WarriorRampage(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                    }
                    if (this.UnitLevel == 35)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Roar!");
                            mes.ShowDialog();
                        }
                        this.AddActiveAbility(new Abilities.WarriorRoar(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                        this.AddPassiveAbility(new Abilities.WarriorRoar(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                    }
                    if (this.UnitLevel == 45)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Infuriate!");
                            mes.ShowDialog();
                        }
                        this.AddActiveAbility(new Abilities.WarriorInfuriate(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                        this.AddPassiveAbility(new Abilities.WarriorInfuriate(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                    }
                    if (this.UnitLevel == 55)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Execution!");
                            mes.ShowDialog();
                        }
                        this.AddActiveAbility(new Abilities.WarriorExecution(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                        this.AddPassiveAbility(new Abilities.WarriorExecution(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                    }
                    if (this.UnitLevel == 60)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Insanity!");
                            mes.ShowDialog();
                        }
                        this.AddActiveAbility(new Abilities.WarriorInsanity(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                        this.AddPassiveAbility(new Abilities.WarriorInsanity(this, null, null, null, EnumAbilityClassReq.WARRIOR));
                    }
                    #endregion
                    break;
                case EnumCharClass.Paladin:
                    #region paladin
                    if (this.UnitLevel == 2)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Wrath!");
                            mes.ShowDialog();
                        }
                        this.AddActiveAbility(new Abilities.PaladinWrath(this, null, null, null, EnumAbilityClassReq.PALADIN));
                        this.AddPassiveAbility(new Abilities.PaladinWrath(this, null, null, null, EnumAbilityClassReq.PALADIN));
                    }
                    if (this.UnitLevel == 8)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Justice!");
                            mes.ShowDialog();
                        }
                        this.AddActiveAbility(new Abilities.PaladinJustice(this, null, null, null, EnumAbilityClassReq.PALADIN));
                        this.AddPassiveAbility(new Abilities.PaladinJustice(this, null, null, null, EnumAbilityClassReq.PALADIN));
                    }
                    if (this.UnitLevel == 15)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Serenity!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.PaladinSerenity(this, null, null, null, EnumAbilityClassReq.PALADIN));
                        this.AddActiveAbility(new Abilities.PaladinSerenity(this, null, null, null, EnumAbilityClassReq.PALADIN));
                    }
                    if (this.UnitLevel == 25)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Raise Spirit!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.PaladinRaiseSpirit(this, null, null, null, EnumAbilityClassReq.PALADIN));
                        this.AddActiveAbility(new Abilities.PaladinRaiseSpirit(this, null, null, null, EnumAbilityClassReq.PALADIN));
                    }
                    if (this.UnitLevel == 35)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Prayer!");
                            mes.ShowDialog();
                        }
                        this.AddActiveAbility(new Abilities.PaladinPrayer(this, null, null, null, EnumAbilityClassReq.PALADIN));
                        this.AddPassiveAbility(new Abilities.PaladinPrayer(this, null, null, null, EnumAbilityClassReq.PALADIN));
                    }
                    if (this.UnitLevel == 45)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Blessing!");
                            mes.ShowDialog();
                        }
                        this.AddActiveAbility(new Abilities.PaladinBlessing(this, null, null, null, EnumAbilityClassReq.PALADIN));
                        this.AddPassiveAbility(new Abilities.PaladinBlessing(this, null, null, null, EnumAbilityClassReq.PALADIN));
                    }
                    if (this.UnitLevel == 55)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Desperate Plea!");
                            mes.ShowDialog();
                        }
                        this.AddActiveAbility(new Abilities.PaladinDesperatePlea(this, null, null, null, EnumAbilityClassReq.PALADIN));
                        this.AddPassiveAbility(new Abilities.PaladinDesperatePlea(this, null, null, null, EnumAbilityClassReq.PALADIN));
                    }
                    if (this.UnitLevel == 60)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned The Power of Faith!");
                            mes.ShowDialog();
                        }
                        this.AddActiveAbility(new Abilities.PaladinThePowerOfFaith(this, null, null, null, EnumAbilityClassReq.PALADIN));
                        this.AddPassiveAbility(new Abilities.PaladinThePowerOfFaith(this, null, null, null, EnumAbilityClassReq.PALADIN));
                    }
                    #endregion
                    break;
                case EnumCharClass.Wizard:
                    #region wizard
                    if (this.UnitLevel == 2)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Fireball!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.WizardFireball(this, null, null, null, EnumAbilityClassReq.WIZARD));
                        this.AddActiveAbility(new Abilities.WizardFireball(this, null, null, null, EnumAbilityClassReq.WIZARD));
                    }
                    if (this.UnitLevel == 8)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Heal!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.WizardHeal(this, null, null, null, EnumAbilityClassReq.WIZARD));
                        this.AddActiveAbility(new Abilities.WizardHeal(this, null, null, null, EnumAbilityClassReq.WIZARD));
                    }
                    if (this.UnitLevel == 15)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Flame Comet!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.WizardFlameComet(this, null, null, null, EnumAbilityClassReq.WIZARD));
                        this.AddActiveAbility(new Abilities.WizardFlameComet(this, null, null, null, EnumAbilityClassReq.WIZARD));
                    }
                    if (this.UnitLevel == 25)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Revitalize!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.WizardRevitalize(this, null, null, null, EnumAbilityClassReq.WIZARD));
                        this.AddActiveAbility(new Abilities.WizardRevitalize(this, null, null, null, EnumAbilityClassReq.WIZARD));
                    }
                    if (this.UnitLevel == 35)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Brilliance!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.WizardBrilliance(this, null, null, null, EnumAbilityClassReq.WIZARD));
                        this.AddActiveAbility(new Abilities.WizardBrilliance(this, null, null, null, EnumAbilityClassReq.WIZARD));
                    }
                    if (this.UnitLevel == 45)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Archon!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.WizardArchon(this, null, null, null, EnumAbilityClassReq.WIZARD));
                        this.AddActiveAbility(new Abilities.WizardArchon(this, null, null, null, EnumAbilityClassReq.WIZARD));
                    }
                    if (this.UnitLevel == 55)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Inferno!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.WizardInferno(this, null, null, null, EnumAbilityClassReq.WIZARD));
                        this.AddActiveAbility(new Abilities.WizardInferno(this, null, null, null, EnumAbilityClassReq.WIZARD));
                    }
                    if (this.UnitLevel == 60)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Oracle!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.WizardOracle(this, null, null, null, EnumAbilityClassReq.WIZARD));
                        this.AddActiveAbility(new Abilities.WizardOracle(this, null, null, null, EnumAbilityClassReq.WIZARD));
                    }
                    #endregion
                    break;
                case EnumCharClass.Thief:
                    #region thief
                    if (this.UnitLevel == 2)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Quick Attack!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.ThiefQuickAttack(this, null, null, null, EnumAbilityClassReq.THIEF));
                        this.AddActiveAbility(new Abilities.ThiefQuickAttack(this, null, null, null, EnumAbilityClassReq.THIEF));
                    }
                    if (this.UnitLevel == 8)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Borrow Weapon!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.ThiefBorrowWeapon(this, null, null, null, EnumAbilityClassReq.THIEF));
                        this.AddActiveAbility(new Abilities.ThiefBorrowWeapon(this, null, null, null, EnumAbilityClassReq.THIEF));
                    }
                    if (this.UnitLevel == 15)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Bloodstealer!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.ThiefBloodstealer(this, null, null, null, EnumAbilityClassReq.THIEF));
                        this.AddActiveAbility(new Abilities.ThiefBloodstealer(this, null, null, null, EnumAbilityClassReq.THIEF));
                    }
                    if (this.UnitLevel == 25)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Poisoned Blade!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.ThiefPoisonedBlade(this, null, null, null, EnumAbilityClassReq.THIEF));
                        this.AddActiveAbility(new Abilities.ThiefPoisonedBlade(this, null, null, null, EnumAbilityClassReq.THIEF));
                    }
                    if (this.UnitLevel == 35)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Swiftness!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.ThiefSwiftness(this, null, null, null, EnumAbilityClassReq.THIEF));
                        this.AddActiveAbility(new Abilities.ThiefSwiftness(this, null, null, null, EnumAbilityClassReq.THIEF));
                    }
                    if (this.UnitLevel == 45)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Envenom!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.ThiefEnvenom(this, null, null, null, EnumAbilityClassReq.THIEF));
                        this.AddActiveAbility(new Abilities.ThiefEnvenom(this, null, null, null, EnumAbilityClassReq.THIEF));
                    }
                    if (this.UnitLevel == 55)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Dirty Tricks!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.ThiefDirtyTricks(this, null, null, null, EnumAbilityClassReq.THIEF));
                        this.AddActiveAbility(new Abilities.ThiefDirtyTricks(this, null, null, null, EnumAbilityClassReq.THIEF));
                    }
                    if (this.UnitLevel == 60)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Flurry!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.ThiefFlurry(this, null, null, null, EnumAbilityClassReq.THIEF));
                        this.AddActiveAbility(new Abilities.ThiefFlurry(this, null, null, null, EnumAbilityClassReq.THIEF));
                    }
                    #endregion
                    break;
                case EnumCharClass.Caretaker:
                    #region caretaker
                    if (this.UnitLevel == 2)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Body Slam!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.CaretakerBodySlam(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                        this.AddActiveAbility(new Abilities.CaretakerBodySlam(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                    }
                    if (this.UnitLevel == 8)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Sacrifice!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.CaretakerSacrifice(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                        this.AddActiveAbility(new Abilities.CaretakerSacrifice(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                    }
                    if (this.UnitLevel == 15)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Lifeforce!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.CaretakerLifeforce(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                        this.AddActiveAbility(new Abilities.CaretakerLifeforce(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                    }
                    if (this.UnitLevel == 25)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Zeal of Humanity!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.CaretakerZealOfHumanity(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                        this.AddActiveAbility(new Abilities.CaretakerZealOfHumanity(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                    }
                    if (this.UnitLevel == 35)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Action!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.CaretakerAction(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                        this.AddActiveAbility(new Abilities.CaretakerAction(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                    }
                    if (this.UnitLevel == 45)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Lifeblood!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.CaretakerLifeblood(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                        this.AddActiveAbility(new Abilities.CaretakerLifeblood(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                    }
                    if (this.UnitLevel == 55)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Power and Dexterity!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.CaretakerPowerAndDexterity(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                        this.AddActiveAbility(new Abilities.CaretakerPowerAndDexterity(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                    }
                    if (this.UnitLevel == 60)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Deathdefiance!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.CaretakerDeathdefiance(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                        this.AddActiveAbility(new Abilities.CaretakerDeathdefiance(this, null, null, null, EnumAbilityClassReq.CARETAKER));
                    }
                    #endregion
                    break;
                case EnumCharClass.Synergist:
                     #region 
                    if (this.UnitLevel == 2)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Duality!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.SynergistDuality(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                        this.AddActiveAbility(new Abilities.SynergistDuality(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                    }
                    if (this.UnitLevel == 8)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Agile Mind!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.SynergistAgileMind(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                        this.AddActiveAbility(new Abilities.SynergistAgileMind(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                    }
                    if (this.UnitLevel == 15)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Balance!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.SynergistBalance(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                        this.AddActiveAbility(new Abilities.SynergistBalance(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                    }
                    if (this.UnitLevel == 25)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Mental Agility!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.SynergistMentalAgility(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                        this.AddActiveAbility(new Abilities.SynergistMentalAgility(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                    }
                    if (this.UnitLevel == 35)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Align!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.SynergistAlign(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                        this.AddActiveAbility(new Abilities.SynergistAlign(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                    }
                    if (this.UnitLevel == 45)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Collapsed Equality!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.SynergistCollapsedEquality(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                        this.AddActiveAbility(new Abilities.SynergistCollapsedEquality(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                    }
                    if (this.UnitLevel == 55)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Synergy!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.SynergistSynergy(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                        this.AddActiveAbility(new Abilities.SynergistSynergy(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                    }
                    if (this.UnitLevel == 60)
                    {
                        if (!_reset)
                        {
                            RPG.UI.MessageForm mes = new UI.MessageForm(this.UnitName + " learned Complete Balance!");
                            mes.ShowDialog();
                        }
                        this.AddPassiveAbility(new Abilities.SynergistCompleteBalance(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                        this.AddActiveAbility(new Abilities.SynergistCompleteBalance(this, null, null, null, EnumAbilityClassReq.SYNERGIST));
                    }
                    #endregion
                    break;
                default:
                    break;
            }
        }
        #endregion

        /// <summary>
        /// This functions resets the characters stats and recalculates them again.
        /// </summary>
        public void UpdateGear()
        {
            this.ResetAttributes();

            if(this.charGear.HeadArmor != null)
                this.AddItemAttributesToChar(this.charGear.HeadArmor);

            if (this.charGear.ChestArmor != null)
                this.AddItemAttributesToChar(this.charGear.ChestArmor);

            if (this.charGear.LegArmor != null)
                this.AddItemAttributesToChar(this.charGear.LegArmor);

            if (this.charGear.Weapon != null)
                this.AddItemAttributesToChar(this.charGear.Weapon);

            if (this.charGear.BattleCharms.Count != 0)
            {
                foreach (Item item in this.charGear.BattleCharms)
                {
                    this.AddItemAttributesToChar(item);
                }
            }
        }

        /// <summary>
        /// This function adds all of the attributes of the items of to the characters stats. Use this function when you equip a new item.
        /// </summary>
        /// <param name="item">The Item to be added.</param>
        private void AddItemAttributesToChar(Item item)
        {
            foreach (UnitAttribute stat in item.stats)
            {
                switch (stat.Type)
                {
                    case EnumAttributeType.Strength:
                        this.buffedStrength.IntValue += stat.IntValue;
                        break;
                    case EnumAttributeType.Agility:
                        this.buffedAgility.IntValue += stat.IntValue;
                        break;
                    case EnumAttributeType.Intellect:
                        this.buffedIntellingence.IntValue += stat.IntValue;
                        break;
                    case EnumAttributeType.Health:
                        this.BuffedHP.IntValue += stat.IntValue;
                        break;
                    case EnumAttributeType.Attackdamage:
                        this.BuffedAttackDamage.IntValue += stat.IntValue;
                        break;
                    case EnumAttributeType.Armor:
                        this.BuffedArmor.IntValue += stat.IntValue;
                        break;
                    case EnumAttributeType.Crit:
                        this.BuffedCrit.IntValue += stat.IntValue;
                        break;
                    case EnumAttributeType.Speed:
                        this.BuffedSpeed.IntValue += stat.IntValue;
                        break;
                    default:
                        break;
                }
            }
            
        }

        /// <summary>
        /// This function resets the buffed attributes of the character to the base attributes of the character
        /// </summary>
        private void ResetAttributes()
        {
            this.BuffedHP.IntValue = this.BaseHP.IntValue;
            this.buffedStrength.IntValue = this.baseStrength.IntValue;
            this.buffedAgility.IntValue = this.baseAgility.IntValue;
            this.buffedIntellingence.IntValue = this.baseIntellingence.IntValue;
            this.BuffedArmor.IntValue = this.BaseArmor.IntValue;
            this.BuffedAttackDamage.IntValue = this.BaseAttackDamage.IntValue;
            this.BuffedCrit.IntValue = this.BaseCrit.IntValue;
            this.BuffedSpeed.IntValue = this.BaseSpeed.IntValue;
        }

        /// <summary>
        /// This function calculates the health, attackdamage and armor of the character according to the buffed Str, Int and Agi.
        /// NOTE: This function is called AFTER a characters gear has been updated.
        /// </summary>
        private void SetStats()
        {
            this.BuffedHP.IntValue += (int)(this.BuffedStrength.IntValue * 0.3);
            this.BuffedSpeed.IntValue += (int)(this.BuffedAgility.IntValue * 0.3);
            this.BuffedCrit.IntValue += (int)(this.BuffedIntellingence.IntValue * 0.3);
            this.BuffedHP.IntValue += this.BuffedArmor.IntValue;
        }

        public void ResetChar()
        {
            int temp2 = this.UnitLevel + 1;
            this.baseCrit.IntValue = temp2;
            this.baseSpeed.IntValue = temp2;
            UpdateGear();
            SetStats();
            int temp = this.BuffedHP.IntValue;
            this.CurrentHP.IntValue = temp;
        }

        public void ResetCharSkills()
        {
            List<Abilities.ActiveAbility> previous = new List<Abilities.ActiveAbility>();

            foreach (var item in this.UnitActiveAbilities)
            {
                previous.Add(item);
            }

            this.UnitActiveAbilities.Clear();
            this.UnitPassiveAbilities.Clear();

            int truelevel = this.UnitLevel;

            for (this.UnitLevel = 0; this.UnitLevel <= truelevel; this.UnitLevel++)
            {
                this.LevelUpAnyClassAbilties(true);
                this.LevelUpClassAbilties(charClass, true);
                this.UnitActiveAbilities.Clear();
            }
            this.UnitLevel--;

            foreach (var item in this.UnitPassiveAbilities)
            {
                if (previous.Any(x => x.AbilityName.Equals(item.AbilityName)))
                {
                    Abilities.ActiveAbility temp = item;
                    this.AddActiveAbility(temp);
                }
            }
            
        }

        #endregion
    }

    public class Gear
    {
        #region Fields

        Item weapon;
        Item headArmor;
        Item chestArmor;
        Item legArmor;
        List<Item> battleCharms = new List<Item>();

        #endregion

        /// <summary>
        /// All of these properties allows you to get the item but not set it.
        /// </summary>
        #region Properties

        public Item Weapon
        {
            set { weapon = value; }
            get { return weapon; }
        }

        public Item HeadArmor
        {
            set { headArmor = value; }
            get { return headArmor; }
        }

        public Item ChestArmor
        {
            set { chestArmor = value; }
            get { return chestArmor; }
        }

        public Item LegArmor
        {
            set { legArmor = value; }
            get { return legArmor; }
        }

        public List<Item> BattleCharms
        {
            set { battleCharms = value; }
            get { return battleCharms; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// An empty constructor for the chooser character, meaning the character that the player will choose characters from.
        /// </summary>
        public Gear()
        { }

        /// <summary>
        /// This is the startup constructor, which adds a weapon and a chestarmor to the character
        /// </summary>
        public Gear(Items.Weapon _weapon, Items.Armor _chestarmor)
        {
            this.weapon = _weapon;
            this.chestArmor = _chestarmor;
        }

        #endregion

        #region Functions adding items to the gear
        /// <summary>
        /// This functions adds or removes a weapon to or from the characters gear. Set "modifier" appropiately to add or remove. NOTE: This function DELETES the current item in the slot!
        /// </summary>
        /// <param name="_weapon">The Weapon to be added</param>
        /// <param name="add">Set this value to "true" to add the weapon and "false" to remove it.</param>
        public void AddOrRemoveWeapon(Items.Weapon _weapon, bool modifier)
        {
            if (modifier && ((_weapon as Item).ItemType == EnumItemType.Weapon))
                this.weapon = _weapon;
            else if (!modifier)
                this.weapon = null;
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("Wrong Itemtype! Attempted to insert " + (_weapon as Item).ItemType + " when Weapon was expected");
                mes.ShowDialog();
            }
        }

        /// <summary>
        /// This functions adds or removes a headarmor to or from the characters gear. Set "modifier" appropiately to add or remove. NOTE: This function DELETES the current item in the slot!
        /// </summary>
        /// <param name="_weapon">The headarmor to be added</param>
        /// <param name="add">Set this value to "true" to add the headarmor and "false" to remove it.</param>
        public void AddOrRemoveHeadArmor(Items.Armor _armor, bool modifier)
        {
            if (modifier && ((_armor as Item).ItemType == EnumItemType.Armor))
                this.headArmor = _armor;
            else if (!modifier)
                this.headArmor = null;
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("Wrong Itemtype! Attempted to insert " + (_armor as Item).ItemType + " when HeadArmor was expected");
                mes.ShowDialog();
            }
        }

        /// <summary>
        /// This functions adds or removes a chestarmor to or from the characters gear. Set "modifier" appropiately to add or remove. NOTE: This function DELETES the current item in the slot!
        /// </summary>
        /// <param name="_weapon">The chestarmor to be added</param>
        /// <param name="add">Set this value to "true" to add the chestarmor and "false" to remove it.</param>
        public void AddOrRemoveChestArmor(Items.Armor _armor, bool modifier)
        {
            if (modifier && ((_armor as Item).ItemType == EnumItemType.Armor))
                this.chestArmor = _armor;
            else if (!modifier)
                this.chestArmor = null;
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("Wrong Itemtype! Attempted to insert " + (_armor as Item).ItemType + " when ChestArmor was expected");
                mes.ShowDialog();
            }
        }

        /// <summary>
        /// This functions adds or removes a legarmor to or from the characters gear. Set "modifier" appropiately to add or remove. NOTE: This function DELETES the current item in the slot!
        /// </summary>
        /// <param name="_weapon">The legarmor to be added</param>
        /// <param name="add">Set this value to "true" to add the legarmor and "false" to remove it.</param>
        public void AddOrRemoveLegArmor(Items.Armor _armor, bool modifier)
        {
            if (modifier && ((_armor as Item).ItemType == EnumItemType.Armor))
                this.legArmor = _armor;
            else if (!modifier)
                this.legArmor = null;
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("Wrong Itemtype! Attempted to insert " + (_armor as Item).ItemType + " when LegArmor was expected");
                mes.ShowDialog();
            }
        }

        /// <summary>
        /// This functions adds or removes a BattleCharm to or from the characters gear. Set "modifier" appropiately to add or remove. A Character may only hold 4 BattleCharms
        /// </summary>
        /// <param name="_weapon">The legarmor to be added</param>
        /// <param name="add">Set this value to "true" to add the battlecharm and "false" to remove it.</param>
        public void AddOrRemoveBattleCharm(Items.BattleCharm _bc, bool modifier)
        {
            if (modifier && this.battleCharms.Count < 2)
                this.battleCharms.Add(_bc);
            else if (modifier && this.battleCharms.Count >= 2)
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("This character allready has 2 BattleCharms! You must remove one before you can add this one!");
                mes.ShowDialog();
            }
            else if (!modifier && this.battleCharms.Contains(_bc))
                this.battleCharms.Remove(_bc);
        }
        #endregion
    }
}
