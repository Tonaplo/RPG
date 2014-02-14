using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Core
{
    class Enums
    {
    }

    public enum EnumCharClass
    {
        Warrior, // Pure Strength class, Melee Damage Dealer or Tank.
        Paladin, // Hybrid Strength/Intellect Class, Melee Damage Dealer, Healer.
        Wizard, // Pure Intellect Class, Magical Damage Dealer or Healer
        Thief, // Pure Agility Class, Physical Damage Dealer
        Caretaker, // Hybrid Strength/Agility Class, Melee Damage Dealer and Tank, Can misdirect damage done to allies.
        Synergist, // Hybrid Agility/Intellect Class, Support character with Damage/Healing abilities
    }

    public enum EnumBattleMode
    {
        Single,
        Local,
        Online
    }

    public enum EnumQuestRewardType
    {
        Experience, 
        Item, 
        Dust
    }

    public enum EnumAttributeType
    {
        Strength,
        Agility,
        Intellect,
        Health,
        Attackdamage,
        Armor,
        Crit,
        Turnpoints,
        Speed,
        Unused
    }

    public enum EnumItemType
    {
        Weapon,
        Armor,
        Battlecharm,
    }

    public enum EnumItemQuality
    {
        Fabled,
        Epochal,
        Grand,
        Normal
    }

    public enum EnumActiveAbilityType
    {
        Damage,
        Healing
    }

    public enum EnumMonsterType
    {
        Dragon,
        Humanoid,
        Beast,
        Undead,
        Null
    }

    public enum EnumAbilityClassReq
    {
        ANY,
        WARRIOR,
        PALADIN,
        WIZARD,
        THIEF,
        CARETAKER,
        SYNERGIST,
        NPC
    }

    public enum EnumAbilityType
    {
        Fire,
        Wind,
        Water,
        Earth
    }
}
