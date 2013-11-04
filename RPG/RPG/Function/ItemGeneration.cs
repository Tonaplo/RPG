using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Core;
using RPG.Core.Items;

namespace RPG.Function
{
    public static class ItemGeneration
    {

        /// <summary>
        /// These Lists are used for storing strings of item names. String are added to them in the SystemInterface
        /// The Random value is used to calculate alot of functions.
        /// </summary>
        #region Fields

        public static List<string> itemPrefixes = new List<string>();
        public static List<string> itemSuffixes = new List<string>();
        public static List<string> swordNames = new List<string>();
        public static List<string> axeNames = new List<string>();
        public static List<string> maceNames = new List<string>();
        public static List<string> staffNames = new List<string>();
        public static List<string> bowNames = new List<string>();
        public static List<string> daggerNames = new List<string>();
        public static List<string> legArmorNames = new List<string>();
        public static List<string> chestArmorNames = new List<string>();
        public static List<string> helmArmorNames = new List<string>();
        public static Random r = new Random();

        #endregion

        /// <summary>
        /// This function MUST be called before any other ItemGeneration functions.
        /// </summary>
        public static void ItemGenerationInitialization()
        {
            #region Sword names
            swordNames.Add("Short Sword");
            swordNames.Add("Scimitar");
            swordNames.Add("Sabre");
            swordNames.Add("Falchion");
            swordNames.Add("Crystal Sword");
            swordNames.Add("Broad Sword");
            swordNames.Add("Long Sword");
            swordNames.Add("War Sword");
            swordNames.Add("Two-handed Sword");
            swordNames.Add("Claymore");
            swordNames.Add("Giant Sword");
            swordNames.Add("Bastard Sword");
            swordNames.Add("Flamberge");
            #endregion

            #region Axe names
            axeNames.Add("Hand Axe");
            axeNames.Add("Axe");
            axeNames.Add("Double Axe");
            axeNames.Add("Military Pick");
            axeNames.Add("War Axe");
            axeNames.Add("Large Axe");
            axeNames.Add("Broad Axe");
            axeNames.Add("Battle Axe");
            axeNames.Add("Great Axe");
            axeNames.Add("Giant Axe");
            #endregion

            #region Mace names
            maceNames.Add("Club");
            maceNames.Add("Spiked Club");
            maceNames.Add("Mace");
            maceNames.Add("Morning Star");
            maceNames.Add("Flail");
            maceNames.Add("War Hammer");
            maceNames.Add("Maul");
            maceNames.Add("Truncheon");
            maceNames.Add("Tyrant Club");
            maceNames.Add("Reinforced Mace");
            maceNames.Add("Devil Star");
            maceNames.Add("Scourge");
            maceNames.Add("Legendary Mallet");
            maceNames.Add("Ogre Maul");
            maceNames.Add("Thunder Maul");

            #endregion

            #region Staff names
            staffNames.Add("Walking Stick");
            staffNames.Add("Stalagmite");
            staffNames.Add("Elder Staff");
            staffNames.Add("Shillelagh");
            staffNames.Add("Archon Staff");
            staffNames.Add("Jo Staff");
            staffNames.Add("Quarterstaff");
            staffNames.Add("Cedar Staff");
            staffNames.Add("Gothic Staff");
            staffNames.Add("Rune Staff");
            staffNames.Add("Short Staff");
            staffNames.Add("Long Staff");
            staffNames.Add("Gnarled Staff");
            staffNames.Add("Battle Staff");
            staffNames.Add("War Staff");
            #endregion

            #region Bow names
            bowNames.Add("Spider Bow");
            bowNames.Add("Blade Bow");
            bowNames.Add("Shadow Bow");
            bowNames.Add("Great Bow");
            bowNames.Add("Diamond Bow");
            bowNames.Add("Crusader Bow");
            bowNames.Add("Ward Bow");
            bowNames.Add("Hydra Bow");
            bowNames.Add("Short Bow");
            bowNames.Add("Hunter's Bow");
            bowNames.Add("Long Bow");
            bowNames.Add("Composite Bow");
            bowNames.Add("Short Battle Bow");
            bowNames.Add("Long Battle Bow");
            bowNames.Add("Short War Bow");
            bowNames.Add("Long War Bow");
            #endregion

            #region Dagger names
            daggerNames.Add("Bone Knife");
            daggerNames.Add("Mithril Point");
            daggerNames.Add("Fanged Knife");
            daggerNames.Add("Legend Spike");
            daggerNames.Add("Poignard");
            daggerNames.Add("Rondel");
            daggerNames.Add("CinquedeaS");
            daggerNames.Add("Stiletto");
            daggerNames.Add("Dagger");
            daggerNames.Add("Dirk");
            daggerNames.Add("Kris");
            daggerNames.Add("Blade");
            #endregion

            #region Leg names
            legArmorNames.Add("Cloth Pants");
            legArmorNames.Add("Leather Pants");
            legArmorNames.Add("Hide Breeches");
            legArmorNames.Add("Chain Leggings");
            legArmorNames.Add("Faulds");
            legArmorNames.Add("Plate Leggings");
            legArmorNames.Add("Legwraps");
            legArmorNames.Add("Etched Pants");
            legArmorNames.Add("Chausses");
            legArmorNames.Add("Tassets");
            legArmorNames.Add("Boneweave Faulds");
            legArmorNames.Add("Leg Guards");
            legArmorNames.Add("Poleyns");
            legArmorNames.Add("Warlord Leg Plates");
            legArmorNames.Add("Schynbalds");
            legArmorNames.Add("Sovereign Tassets");
            legArmorNames.Add("Archon Faulds");
            #endregion 

            #region Chestarmor names
            chestArmorNames.Add("Dusk Shroud");
            chestArmorNames.Add("Wyrmhide");
            chestArmorNames.Add("Scarab Husk");
            chestArmorNames.Add("Wire Fleece");
            chestArmorNames.Add("Diamond Mail");
            chestArmorNames.Add("Loricated Mail");
            chestArmorNames.Add("Great Hauberk");
            chestArmorNames.Add("Boneweave");
            chestArmorNames.Add("Balrog Skin");
            chestArmorNames.Add("Archon Plate");
            chestArmorNames.Add("Kraken Shell");
            chestArmorNames.Add("Hellforge Plate");
            chestArmorNames.Add("Lacquered Plate");
            chestArmorNames.Add("Shadow Plate");
            chestArmorNames.Add("Sacred Armor");
            chestArmorNames.Add("Ghost Armor");
            chestArmorNames.Add("Serpentskin Armor");
            chestArmorNames.Add("Demonhide Armor");
            chestArmorNames.Add("Trellised Armor");
            chestArmorNames.Add("Linked Mail");
            chestArmorNames.Add("Tigulated Mail");
            chestArmorNames.Add("Cuirass");
            chestArmorNames.Add("Mesh Armor");
            chestArmorNames.Add("Russet Armor");
            chestArmorNames.Add("Mage Plate");
            chestArmorNames.Add("Sharktooth Armor");
            chestArmorNames.Add("Templar Coat");
            chestArmorNames.Add("Embossed Plate");
            chestArmorNames.Add("Chaos Armor");
            chestArmorNames.Add("Ornate Plate");
            chestArmorNames.Add("Quilted Armor");
            chestArmorNames.Add("Leather Armor");
            chestArmorNames.Add("Hard Leather Armor");
            chestArmorNames.Add("Studded Leather");
            chestArmorNames.Add("Ring Mail");
            chestArmorNames.Add("Scale Mail");
            chestArmorNames.Add("Breast Plate");
            chestArmorNames.Add("Chain Mail");
            chestArmorNames.Add("Splint Mail");
            chestArmorNames.Add("Light Plate");
            chestArmorNames.Add("Field Plate");
            chestArmorNames.Add("Plate Mail");
            chestArmorNames.Add("Gothic Plate");
            chestArmorNames.Add("Full Plate Mail");
            chestArmorNames.Add("Ancient Armor");
            #endregion

            #region Helm names
            helmArmorNames.Add("Shako");
            helmArmorNames.Add("Hydraskull");
            helmArmorNames.Add("Armet");
            helmArmorNames.Add("Giant Conch");
            helmArmorNames.Add("Spired Helm");
            helmArmorNames.Add("Demonhead");
            helmArmorNames.Add("Corona");
            helmArmorNames.Add("Bone Visage");
            helmArmorNames.Add("War Hat");
            helmArmorNames.Add("Sallet");
            helmArmorNames.Add("Casque");
            helmArmorNames.Add("Basinet");
            helmArmorNames.Add("Winged Helm");
            helmArmorNames.Add("Death Mask");
            helmArmorNames.Add("Grand Crown");
            helmArmorNames.Add("Grim Helm");
            helmArmorNames.Add("Cap");
            helmArmorNames.Add("Skull Cap");
            helmArmorNames.Add("Helm");
            helmArmorNames.Add("Full Helm");
            helmArmorNames.Add("Great Helm");
            helmArmorNames.Add("Mask");
            helmArmorNames.Add("Crown");
            helmArmorNames.Add("Bone Helm");
            #endregion
            
            string data = Properties.Resources.Prefixes;
            itemPrefixes = new List<string>(data.Split(','));

            data = Properties.Resources.Suffixes;
            itemSuffixes = new List<string>(data.Split(','));

            Console.WriteLine(Environment.NewLine + "Checking Prefixes:" +Environment.NewLine);
            CheckListForRepeats(itemPrefixes);

            Console.WriteLine(Environment.NewLine + "Checking Suffixes:" + Environment.NewLine);
            CheckListForRepeats(itemSuffixes);
            
        }

        #region Epochal Item Functions

        /// <summary>
        /// Before an EPOCHAL item is made for the player, it must first have randomized values of its stats. 
        /// That is what this function does. 
        /// NOTE: It reduces all of the stats of the item by a value between 0 and 1/4 of the itemlevel
        /// NOTE: It increases or decreases the armor/damage slightly of EPOCHAL Armor/Weapons
        /// </summary>
        /// <param name="_epochal">The EPOCHAL item to the randomized</param>
        /// <returns>The stat-randomized EPOCHAL item</returns>
        public static Item RandomizeEpochalItem(Item _epochal)
        {
            int _damageOrArmor = _epochal.ItemLevel;
            if (r.Next(10) > 5)
                _damageOrArmor += (int)r.Next(_epochal.ItemLevel / 10);
            else
                _damageOrArmor -= (int)r.Next(_epochal.ItemLevel / 10);

            foreach (UnitAttribute att in _epochal.stats)
            {
                if (_epochal.ItemType.Equals(EnumItemType.Weapon) && att.Type.Equals(EnumAttributeType.Attackdamage))
                    att.IntValue = _damageOrArmor;
                else if (_epochal.ItemType.Equals(EnumItemType.Armor) && att.Type.Equals(EnumAttributeType.Armor))
                    att.IntValue = _damageOrArmor;
                else
                    att.IntValue -= r.Next(_epochal.ItemLevel / 4);
            }

            return _epochal;
        }

        /// <summary>
        /// This function returns an random epochal item with 5 level of the _npclevel or 60 or higher if the _npc is level 60.
        /// </summary>
        /// <param name="_npclevel">The level of the NPC that drops the item</param>
        /// <returns></returns>
        public static Item ReturnEpocalItem(int _npclevel)
        {
            Item returnedItem = null;

            if (_npclevel + 1 < 10)
            {
                returnedItem = GenerateFabledItem(_npclevel);
                return returnedItem;
            }

            int itemlevel = r.Next(10, _npclevel + 1);

            if (itemlevel > 55)
            {
                returnedItem = Return5560Epochal(itemlevel);
            }

            else if (itemlevel > 50)
            {
                returnedItem = Return5055Epochal(itemlevel);
            }

            else if (itemlevel > 40)
            {
                returnedItem = Return4050Epochal(itemlevel);
            }

            else if (itemlevel > 30)
            {
                returnedItem = Return3040Epochal(itemlevel);
            }

            else if (itemlevel > 20)
            {
                returnedItem = Return2030Epochal(itemlevel);
            }

            else if (itemlevel > 10)
            {
                returnedItem = Return1020Epochal(itemlevel);
            }

            if (returnedItem == null)
                returnedItem = GenerateFabledItem(itemlevel);


            return returnedItem;
        }

        public static Item Return1020Epochal(int _npclevel)
        {
            Item returnedItem = new Item();
            int increasedStat = _npclevel + 2;

            switch (r.Next(0,6))
            {
                case 0:
                    returnedItem = new Weapon("Thief-s Tool", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, Core.Items.EnumWeaponType.Dagger, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 1:
                    returnedItem = new Weapon("The Crusher", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, Core.Items.EnumWeaponType.Mace, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 2:
                    returnedItem = new Weapon("The Flutterer", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, Core.Items.EnumWeaponType.Sword, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 3:
                    returnedItem = new Armor("Apprentice' Headpiece", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Headarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 4:
                    returnedItem = new Armor("Quickleaps", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Legarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 5:
                    returnedItem = new Armor("The Thornebrush", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Chestarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                default:
                    break;
            }

            return returnedItem;
        }

        public static Item Return2030Epochal(int _npclevel)
        {
            Item returnedItem = new Item();
            int increasedStat = _npclevel + 2;

            switch (r.Next(0, 7))
            {
                case 0:
                    returnedItem = new Weapon("Battlemage's Ward", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, EnumWeaponType.Staff, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 1:
                    returnedItem = new Weapon("Defiance", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, EnumWeaponType.Axe, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Armor, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 2:
                    returnedItem = new Weapon("Choosen of the Ranger", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, Core.Items.EnumWeaponType.Bow, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 3:
                    returnedItem = new Armor("The Crown", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Headarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 4:
                    returnedItem = new Armor("The Unknown", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Legarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 5:
                    returnedItem = new Armor("Harmony of Lightweave", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Chestarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 6:
                    returnedItem = new BattleCharm("The Balance", EnumItemType.Battlecharm, EnumItemQuality.Epochal, _npclevel);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem = (BattleCharm)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                default:
                    break;
            }
            return returnedItem;
        }

        public static Item Return3040Epochal(int _npclevel)
        {
            Item returnedItem = new Item();
            int increasedStat = _npclevel + 2;

            switch (r.Next(0, 6))
            {
                case 0:
                    returnedItem = new Weapon("Faith Blade", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, EnumWeaponType.Sword, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 1:
                    returnedItem = new Weapon("Burning Omen", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, EnumWeaponType.Mace, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 2:
                    returnedItem = new Weapon("Leaf of the Forrest", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, Core.Items.EnumWeaponType.Dagger, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 3:
                    returnedItem = new Armor("The Skull", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Headarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 4:
                    returnedItem = new Armor("Eiwars' Legwraps", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Legarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 5:
                    returnedItem = new Armor("Harmony of Lightweave", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Chestarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                default:
                    break;
            }
            return returnedItem;
        }

        public static Item Return4050Epochal(int _npclevel)
        {
            Item returnedItem = new Item();
            int increasedStat = _npclevel + 2;

            switch (r.Next(0, 7))
            {
                case 0:
                    returnedItem = new Weapon("Branch of Yggdrasil", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, EnumWeaponType.Staff, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 1:
                    returnedItem = new Weapon("Skullsplitter", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, EnumWeaponType.Axe, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 2:
                    returnedItem = new Weapon("Hawks' Aim", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, Core.Items.EnumWeaponType.Bow, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 3:
                    returnedItem = new Armor("Hood of Power", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Headarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, (int)(increasedStat * 1.1));
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, (int)(increasedStat*1.1));
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 4:
                    returnedItem = new Armor("The Heavy Plates", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Legarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, (int)(increasedStat*1.5));
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 5:
                    returnedItem = new Armor("Eiwars Armor", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Chestarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 6:
                    returnedItem = new BattleCharm("The Energy Gem", EnumItemType.Battlecharm, EnumItemQuality.Epochal, _npclevel);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem = (BattleCharm)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                default:
                    break;
            }
            return returnedItem;
        }

        public static Item Return5055Epochal(int _npclevel)
        {
            Item returnedItem = new Item();
            int increasedStat = _npclevel + 2;

            switch (r.Next(0, 6))
            {
                case 0:
                    returnedItem = new Weapon("Eiwars Blade", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, EnumWeaponType.Sword, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Armor, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 1:
                    returnedItem = new Weapon("The Myst", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, EnumWeaponType.Mace, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, (int)(increasedStat*1.4));
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, (int)(increasedStat*1.4));
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 2:
                    returnedItem = new Weapon("Splint", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, Core.Items.EnumWeaponType.Dagger, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 3:
                    returnedItem = new Armor("Nobility", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Headarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, (int)(increasedStat*1.4));
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, (int)(increasedStat*1.4));
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 4:
                    returnedItem = new Armor("Hide of Scales", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Legarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat/2);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 5:
                    returnedItem = new Armor("The Bulwark", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Chestarmor, (int)(increasedStat*1.2));
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, (int)(increasedStat*1.2));
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                default:
                    break;
            }
            return returnedItem;
        }

        public static Item Return5560Epochal(int _npclevel)
        {
            Item returnedItem = new Item();
            int increasedStat = _npclevel + 2;

            switch (r.Next(0, 7))
            {
                case 0:
                    returnedItem = new Weapon("The Occulus", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, EnumWeaponType.Staff, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 1:
                    returnedItem = new Weapon("The Divider", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, EnumWeaponType.Axe, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, (int)(increasedStat*1.4));
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 2:
                    returnedItem = new Weapon("Eiwars Bow", EnumItemType.Weapon, EnumItemQuality.Epochal, _npclevel, Core.Items.EnumWeaponType.Bow, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem = (Weapon)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 3:
                    returnedItem = new Armor("Halo", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Headarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, (int)(increasedStat*1.1));
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 4:
                    returnedItem = new Armor("Carriers", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Legarmor, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, (int)(increasedStat * 1.2));
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 5:
                    returnedItem = new Armor("The Exposed Heart", EnumItemType.Armor, EnumItemQuality.Epochal, _npclevel, EnumArmorType.Chestarmor, -(increasedStat/4));
                    returnedItem.AddAttributeToItem(EnumAttributeType.Agility, increasedStat*2);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Health, -(increasedStat/4));
                    returnedItem.AddAttributeToItem(EnumAttributeType.Intellect, increasedStat*2);
                    returnedItem = (Armor)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                case 6:
                    returnedItem = new BattleCharm("Sigil of Madness", EnumItemType.Battlecharm, EnumItemQuality.Epochal, _npclevel);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Crit, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Strength, increasedStat);
                    returnedItem.AddAttributeToItem(EnumAttributeType.Attackdamage, increasedStat);
                    returnedItem = (BattleCharm)ItemGeneration.RandomizeEpochalItem(returnedItem);
                    break;
                default:
                    break;
            }
            return returnedItem;
        }
        #endregion

        /// <summary>
        /// These functions returns items based on the itemlevel. 
        /// Their armor/damage is adjusted by a +- (int)Math.Log(Random.Next(_itemlevel)) function and their stats will be at least (int)Math.Log(_itemlevel) and at most _itemlevel.
        /// Only NORMAL, GRAND and FABLED items can be fully generated. 
        /// EPOCHAL Items are unique items and therefore, the values of their stats are merely randomized, nothing else is generated.
        /// </summary>

        #region WeaponGenerating Functions

        /// <summary>
        /// This function returns a normal weapon of a certain type with stats depending on the itemlevel.
        /// </summary>
        /// <param name="_weaponName">The name of the weapon. NOTE: Set this to null if you want the items name to be random</param>
        /// <param name="_weaponType">The type of the weapon. NOTE: Set this to EnumWeaponType.Null if you want the weapons type to be random</param>
        /// <param name="_itemlevel">The itemlevel of the weapon</param>
        /// <param name="_damage">The base damage the weapon should deal</param>
        /// <returns>A normal weapon</returns>
        public static Weapon GenerateNormalWeapon(string _weaponName, EnumWeaponType _weaponType, int _itemlevel)
        {
            int _damage = 1;
            if (_itemlevel != 0)
                _damage = (int)r.Next(1, _itemlevel);
            Weapon returnedWeapon;

            if (_weaponType == EnumWeaponType.Null)
                returnedWeapon = new Weapon(_weaponName, EnumItemType.Weapon, EnumItemQuality.Normal, _itemlevel, GetRandomWeaponType(), _damage);
            else
                returnedWeapon = new Weapon(_weaponName, EnumItemType.Weapon, EnumItemQuality.Normal, _itemlevel, _weaponType, _damage);

            //A normal item has neither prefixes, nor suffixes
            if (_weaponName == null)
                returnedWeapon.ItemName = Function.ItemGeneration.GenerateWeaponName(returnedWeapon, false, false);

            return returnedWeapon;
        }

        /// <summary>
        /// This function returns a grand weapon of a certain type with stats depending on the itemlevel. Adds 1 or 2 attributes to the item.
        /// </summary>
        /// <param name="_weaponName">The name of the weapon. NOTE: Set this to null if you want the item's name to be random</param>
        /// <param name="_weaponType">The type of the weapon. NOTE: Set this to EnumWeaponType.Null if you want the weapons type to be random</param>
        /// <param name="_itemlevel">The itemlevel of the weapon</param>
        /// <param name="_damage">The base damage the weapon should deal</param>
        /// <returns>A grand weapon</returns>
        public static Weapon GenerateGrandWeapon(string _weaponName, EnumWeaponType _weaponType, int _itemlevel)
        {
            int _damage = 1;
            if (_itemlevel != 0)
                _damage = (int)r.Next(1, _itemlevel);
            Weapon returnedWeapon = null;

            if (_weaponType == EnumWeaponType.Null)
                returnedWeapon = new Weapon(_weaponName, EnumItemType.Weapon, EnumItemQuality.Grand, _itemlevel, GetRandomWeaponType(), _damage);
            else
                returnedWeapon = new Weapon(_weaponName, EnumItemType.Weapon, EnumItemQuality.Grand, _itemlevel, _weaponType, _damage);

            // Grand items only have prefixes
            if (_weaponName == null)
                returnedWeapon.ItemName = Function.ItemGeneration.GenerateWeaponName(returnedWeapon, true, false);

            for (int i = 0; i < r.Next(1,3); i++)
            {
                returnedWeapon.AddAttributeToItem(GetRandomAttribute(_itemlevel + r.Next(48), returnedWeapon.ItemType), r.Next(_itemlevel / 4, _itemlevel));
            }

            return returnedWeapon;
        }

        /// <summary>
        /// This function returns a fabled weapon of a certain type with stats depending on the itemlevel. Adds 2 or 3 attributes to the item.
        /// </summary>
        /// <param name="_weaponName">The name of the weapon. NOTE: Set this to null if you want the item's name to be random</param>
        /// <param name="_weaponType">The type of the weapon. NOTE: Set this to EnumWeaponType.Null if you want the weapons type to be random</param>
        /// <param name="_itemlevel">The itemlevel of the weapon</param>
        /// <param name="_damage">The base damage the weapon should deal</param>
        /// <returns>A fabled weapon</returns>
        public static Weapon GenerateFabledWeapon(string _weaponName, EnumWeaponType _weaponType, int _itemlevel)
        {
            int _damage = 1;
            if (_itemlevel >= 0)
                _damage = (int)r.Next(1, _itemlevel);
            Weapon returnedWeapon = null;

            if(_weaponType == EnumWeaponType.Null)
                returnedWeapon = new Weapon(_weaponName, EnumItemType.Weapon, EnumItemQuality.Fabled, _itemlevel, GetRandomWeaponType(), _damage);
            else
                returnedWeapon = new Weapon(_weaponName, EnumItemType.Weapon, EnumItemQuality.Fabled, _itemlevel, _weaponType, _damage);

            if (_weaponName == null)
                returnedWeapon.ItemName = Function.ItemGeneration.GenerateWeaponName(returnedWeapon, true, true);

            //This code adds 2 or 3 attributes to the item. The _itemlevel+r.Next(48) is to ensure randomness.
            for (int i = 0; i < r.Next(1, 4); i++)
            {
                returnedWeapon.AddAttributeToItem(GetRandomAttribute(_itemlevel + r.Next(48), returnedWeapon.ItemType), r.Next(_itemlevel / 4, _itemlevel));
            }

            return returnedWeapon;
        }


        #endregion

        #region ArmorGenerating Functions

        /// <summary>
        /// This function returns a normal armor of a certain type with stats depending on the itemlevel.
        /// </summary>
        /// <param name="_armorName">The name of the armor. NOTE: Set this to null if you want the items name to be random</param>
        /// <param name="_armorType">The type of the armor. NOTE: Set this to EnumArmorType.Null if you want the armors type to be random</param>
        /// <param name="_itemlevel">The itemlevel of the armor</param>
        /// <param name="_armor">The base armor of the armor</param>
        /// <returns>A normal armor</returns>
        public static Armor GenerateNormalArmor(string _armorName, EnumArmorType _armorType, int _itemlevel)
        {
            int _armor = 1;
            if(_itemlevel != 0)
                _armor = (int)r.Next(1, _itemlevel);
            Armor returnedArmor = null;

            if (_armorType == EnumArmorType.Null)
                returnedArmor = new Armor(_armorName, EnumItemType.Armor, EnumItemQuality.Normal, _itemlevel, GetRandomArmorType(), _armor);
            else
                returnedArmor = new Armor(_armorName, EnumItemType.Armor, EnumItemQuality.Normal, _itemlevel, _armorType, _armor);

            //A normal item has neither prefixes, nor suffixes
            if (_armorName == null)
                returnedArmor.ItemName = Function.ItemGeneration.GenerateArmorName(returnedArmor, false, false);

            return returnedArmor;
        }

        /// <summary>
        /// This function returns a grand armor of a certain type with stats depending on the itemlevel. Adds 1 or 2 attributes to the item.
        /// </summary>
        /// <param name="_armorName">The name of the armor. NOTE: Set this to null if you want the item's name to be random</param>
        /// <param name="_armorType">The type of the armor. NOTE: Set this to EnumArmorType.Null if you want the armors type to be random</param>
        /// <param name="_itemlevel">The itemlevel of the armor</param>
        /// <param name="_armor">The base armor of the armor</param>
        /// <returns>A grand armor</returns>
        public static Armor GenerateGrandArmor(string _armorName, EnumArmorType _armorType, int _itemlevel)
        {
            int _armor = 1;
            if (_itemlevel != 0)
                _armor = (int)r.Next(1, _itemlevel);
            Armor returnedArmor = null;

            if (_armorType == EnumArmorType.Null)
                returnedArmor = new Armor(_armorName , EnumItemType.Armor, EnumItemQuality.Grand, _itemlevel, GetRandomArmorType(), _armor);
            else
                returnedArmor = new Armor(_armorName, EnumItemType.Armor, EnumItemQuality.Grand, _itemlevel, _armorType, _armor);

            // Grand items only have prefixes
            if (_armorName == null)
                returnedArmor.ItemName = Function.ItemGeneration.GenerateArmorName(returnedArmor, true, false);

            for (int i = 0; i < r.Next(1, 3); i++)
            {
                returnedArmor.AddAttributeToItem(GetRandomAttribute(_itemlevel + r.Next(48), returnedArmor.ItemType), r.Next(_itemlevel / 4, _itemlevel));
            }

            return returnedArmor;
        }

        /// <summary>
        /// This function returns a fabled armor of a certain type with stats depending on the itemlevel. Adds 2 or 3 attributes to the item.
        /// </summary>
        /// <param name="_armorName">The name of the armor. NOTE: Set this to null if you want the item's name to be random</param>
        /// <param name="_armorType">The type of the armor. NOTE: Set this to EnumArmorType.Null if you want the armors type to be random</param>
        /// <param name="_itemlevel">The itemlevel of the armor</param>
        /// <param name="_armor">The base armor of the weapon</param>
        /// <returns>A fabled weapon</returns>
        public static Armor GenerateFabledArmor(string _armorName, EnumArmorType _armorType, int _itemlevel)
        {
            int _armor = 1;
            if (_itemlevel >= 0)
                _armor = (int)r.Next(1, _itemlevel);
            
            Armor returnedArmor = null;

            if (_armorType == EnumArmorType.Null)
                returnedArmor = new Armor(_armorName, EnumItemType.Armor, EnumItemQuality.Fabled, _itemlevel, GetRandomArmorType(), _armor);
            else
                returnedArmor = new Armor(_armorName, EnumItemType.Armor, EnumItemQuality.Fabled, _itemlevel, _armorType, _armor);

            if (_armorName == null)
                returnedArmor.ItemName = Function.ItemGeneration.GenerateArmorName(returnedArmor, true, true);

            //This code adds 2 or 3 attributes to the item. The _itemlevel+r.Next(48) is to ensure randomness.
            for (int i = 0; i < r.Next(1, 4); i++)
            {
                returnedArmor.AddAttributeToItem(GetRandomAttribute(_itemlevel + r.Next(48), returnedArmor.ItemType), r.Next(_itemlevel / 4, _itemlevel));
            }

            return returnedArmor;
        }

        #endregion

        #region Battle Charm Generating Functions

        /// <summary>
        /// This function returns a grand BattleCharm of a certain type with stats depending on the itemlevel. Adds 1 or 2 attributes to the item.
        /// NOTE: Because there are 4 battlecharms in each inventory and they can give attack and armor, the attributes needed are much lower.
        /// </summary>
        /// <param name="_bcName">The name of the BattleCharm. NOTE: Set this to null if you want the item's name to be random</param>
        /// <param name="_itemlevel">The itemlevel of the BattleCharm</param>
        /// <returns>A grand BattleCharm</returns>
        public static BattleCharm GenerateGrandBattleCharm(string _bcName, int _itemlevel)
        {
            int _armor = 1;
            if (_itemlevel != 0)
                _armor = (int)r.Next(1, _itemlevel);
            BattleCharm returnedBC = new BattleCharm(_bcName, EnumItemType.Battlecharm, EnumItemQuality.Grand, _itemlevel);

            // Grand items only have prefixes
            if (_bcName == null)
                returnedBC.ItemName = Function.ItemGeneration.GenerateBattleCharmName(returnedBC, true, false);

            for (int i = 0; i < r.Next(1, 3); i++)
            {
                returnedBC.AddAttributeToItem(GetRandomAttribute(_itemlevel + r.Next(48), returnedBC.ItemType), r.Next(_itemlevel/4, _itemlevel/2));
            }


            return returnedBC;
        }

        /// <summary>
        /// This function returns a fabled BattleCharm of a certain type with stats depending on the itemlevel. Adds 2, 3 or 4 attributes to the item.
        /// NOTE: Because there are 4 battlecharms in each inventory and they can give attack and armor, the attributes needed are much lower.
        /// </summary>
        /// <param name="_bcName">The name of the BattleCharm. NOTE: Set this to null if you want the item's name to be random</param>
        /// <param name="_itemlevel">The itemlevel of the BattleCharm</param>
        /// <returns>A fabled BattleCharm</returns>
        public static BattleCharm GenerateFabledBattleCharm(string _bcName, int _itemlevel)
        {
            int _armor = 1;
            if (_itemlevel >= 0)
                _armor = (int)r.Next(1, _itemlevel);
            BattleCharm returnedBC = new BattleCharm(_bcName, EnumItemType.Battlecharm, EnumItemQuality.Fabled, _itemlevel);

            // Fabled items have prefixes and suffixes
            if (_bcName == null)
                returnedBC.ItemName = Function.ItemGeneration.GenerateBattleCharmName(returnedBC, true, true);

            for (int i = 0; i < r.Next(1, 4); i++)
            {
                returnedBC.AddAttributeToItem(GetRandomAttribute(_itemlevel + r.Next(48), returnedBC.ItemType), r.Next(_itemlevel / 4, _itemlevel/2));
            }


            return returnedBC;
        }

        #endregion

        #region Loot generating functions

        /// <summary>
        /// This function genereates loot according to the char level compared to the npc level.
        /// It gives a slightly better chance of loot if the npcs where higher level than the characters.
        /// It gives a slightly better chance of loot if the number of players is lower or equal to the number of NPCs
        /// Fabled Items can also be Epochal of lower quality if the NPC is higher than 30 levels.
        /// </summary>
        /// <param name="_charLevel">The level of the character</param>
        /// <param name="_npcLevel">The level of the NPC</param>
        /// <returns>A list of item - the loot from the mob</returns>
        public static Item GenerateLoot(int _charLevels, int numberOfCharacters, int _npcLevels)
        {


            Item loot = new Item();
            int modifier = 0;
            int roll = 0;

            if (numberOfCharacters > 1)
                modifier += (numberOfCharacters - 1) * 40;

            if (_npcLevels > _charLevels)
                modifier += (_npcLevels - _charLevels) * 60;

            if (_npcLevels < _charLevels)
                modifier -= (_charLevels - _npcLevels) * 60;

            roll = r.Next(0,10000);
            double normal = 3750 - modifier;
            double grand = 8750 - modifier;
            double fabled = 9850 - modifier;

            if (normal > roll)
                loot = GenerateNormalItem((int)(_npcLevels));
            else if (grand > roll)
                loot = GenerateGrandItem((int)(_npcLevels));
            else if (fabled > roll)
            {
                if(_npcLevels/numberOfCharacters >= 30 && r.Next(0,10) > 7)
                    loot = ReturnEpocalItem((int)(_npcLevels)-10);
                else
                    loot = GenerateFabledItem((int)(_npcLevels));
            }
            else
                loot = ReturnEpocalItem((int)(_npcLevels));
            

            return loot;
        }

        /// <summary>
        /// This functions returns a randomly generated Normal item, based on the level of the NPC
        /// </summary>
        /// <param name="_npclevel">The level of the NPC that the item should be generated from</param>
        /// <returns>a randomly generated normal item</returns>
        public static Item GenerateNormalItem(int _npclevel)
        {
            Item returnedItem;

            switch (r.Next(2))
            {
                case 1:
                    returnedItem = GenerateNormalArmor(null, EnumArmorType.Null, _npclevel);
                    return returnedItem as Armor;
                default:
                    returnedItem = GenerateNormalWeapon(null, EnumWeaponType.Null, _npclevel);
                    return returnedItem as Weapon;
            }
        }

        /// <summary>
        /// This functions returns a randomly generated Grand item, based on the level of the NPC
        /// </summary>
        /// <param name="_npclevel">The level of the NPC that the item should be generated from</param>
        /// <returns>a randomly generated grand item</returns>
        public static Item GenerateGrandItem(int _npclevel)
        {
            Item returnedItem;

            switch (r.Next(3))
            {
                case 1:
                    returnedItem = GenerateGrandArmor(null, EnumArmorType.Null, _npclevel);
                    return returnedItem as Armor;
                case 2:
                    returnedItem = GenerateGrandWeapon(null, EnumWeaponType.Null, _npclevel);
                    return returnedItem as Weapon;
                default:
                    returnedItem = GenerateGrandBattleCharm(null, _npclevel);
                    return returnedItem as BattleCharm;
            }
        }

        /// <summary>
        /// This functions returns a randomly generated fabled item, based on the level of the NPC
        /// </summary>
        /// <param name="_npclevel">The level of the NPC that the item should be generated from</param>
        /// <returns>a randomly generated fabled item</returns>
        public static Item GenerateFabledItem(int _npclevel)
        {
            Item returnedItem;

            switch (r.Next(3))
            {
                case 1:
                    returnedItem = GenerateFabledArmor(null, EnumArmorType.Null, _npclevel);
                    return returnedItem as Armor;
                case 2:
                    returnedItem = GenerateFabledWeapon(null, EnumWeaponType.Null, _npclevel);
                    return returnedItem as Weapon;
                default:
                    returnedItem = GenerateFabledBattleCharm(null, _npclevel);
                    return returnedItem as BattleCharm;
            }
        }

        #endregion

        #region Helper functions for item generation

        /// <summary>
        /// This function returns a random attribute to be added to an item. If the item is a BattleChar, Armor and Attackdamage can be returned, otherwise not.
        /// </summary>
        /// <param name="_random">The random number to generate the attribute from. This is usually the itemlevel of the item + a random, nonnegative number less than 47</param>
        /// <param name="_itype">The type of item</param>
        /// <returns>An Attribute for an item</returns>
        private static EnumAttributeType GetRandomAttribute(int _random, EnumItemType _itype)
        {
            if (_itype == EnumItemType.Battlecharm)
            {
                switch (r.Next(_random) % 9)
                {
                    case 1:
                        return EnumAttributeType.Agility;
                    case 2:
                        return EnumAttributeType.Health;
                    case 3:
                        return EnumAttributeType.Intellect;
                    case 5:
                        return EnumAttributeType.Strength;
                    case 6:
                        return EnumAttributeType.Armor;
                    case 7:
                        return EnumAttributeType.Crit;
                    case 8:
                        return EnumAttributeType.Speed;
                    default:
                        return EnumAttributeType.Attackdamage;
                }
            }
            else 
            {
                switch (r.Next(_random) % 7)
                {
                    case 1:
                        return EnumAttributeType.Agility;
                    case 2:
                        return EnumAttributeType.Health;
                    case 3:
                        return EnumAttributeType.Intellect;
                    case 4:
                        return EnumAttributeType.Crit;
                    case 5:
                        return EnumAttributeType.Speed;
                    default:
                        return EnumAttributeType.Strength;
                }
            }
        }

        /// <summary>
        /// This function returns a random weapontype
        /// </summary>
        /// <returns>A random weapontype</returns>
        public static EnumWeaponType GetRandomWeaponType()
        {
            switch (r.Next(FacultyOfNumber(6)) % 6)
            {
                case 0:
                    return EnumWeaponType.Axe;
                case 1:
                    return Core.Items.EnumWeaponType.Bow;
                case 2:
                    return Core.Items.EnumWeaponType.Dagger;
                case 3:
                    return Core.Items.EnumWeaponType.Mace;
                case 4:
                    return EnumWeaponType.Staff;
                default:
                    return Core.Items.EnumWeaponType.Sword;
            }
        }

        /// <summary>
        /// This function returns a random armortype
        /// </summary>
        /// <returns>A random armortype</returns>
        public static EnumArmorType GetRandomArmorType()
        {
            switch (r.Next(FacultyOfNumber(3)) % 3)
            {
                case 0:
                    return EnumArmorType.Chestarmor;
                case 1:
                    return EnumArmorType.Headarmor;
                default:
                    return EnumArmorType.Legarmor;

            }
        }

        public static int FacultyOfNumber(int _number)
        {
            if (_number == 0)
                return 1;
            else
                return _number * FacultyOfNumber(_number - 1);
        }

        #endregion

        #region Item Name Generating functions

        public static void CheckListForRepeats(List<string> list)
        {
            int numer = 0;
            for (int i = 0; i < list.Count; i++)
			{
                for (int k = i+1; k < list.Count; k++)
                {
                    if (list[i] == list[k])
                    {
                        Console.WriteLine(list[i]);
                        numer++;
                    }
                }
			}
            Console.WriteLine(Environment.NewLine + numer + " repeats.");
        }

        public static string RandomizeNewName(Item _item)
        {
            bool prefix = false;
            bool suffix = false;
            string newName = "";
            string oldName = _item.ItemName;

            if(_item.ItemQuality == EnumItemQuality.Fabled)
            {
                prefix = true;
                suffix = true;
            }
            else
            {
                prefix = true;
            }

            do
            {
                if (_item.ItemType == EnumItemType.Armor)
                    newName = GenerateArmorName((_item as Armor), prefix, suffix);
                else if(_item.ItemType == EnumItemType.Battlecharm)
                    newName = GenerateBattleCharmName((_item as BattleCharm), prefix, suffix);
                else if (_item.ItemType == EnumItemType.Weapon)
                    newName = GenerateWeaponName((_item as Weapon), prefix, suffix);

            } while (newName == oldName);

            return newName;
        }

        private static string GenerateWeaponName(Weapon _weapon, bool prefix, bool suffix)
        {
            Random r = new Random();
            int index = 0;
            string _name = "";

            if (prefix)
            {
                index = (_weapon.ItemLevel * (int)r.Next(itemPrefixes.Count)) % (itemPrefixes.Count);
                _name = itemPrefixes[index];
                _name += " ";
            }

            switch (_weapon.WeaponType)
            {
                case Core.Items.EnumWeaponType.Sword:
                    index = (_weapon.ItemLevel * (int)r.Next(swordNames.Count)) % (swordNames.Count);
                    _name += swordNames[index];
                    break;
                case EnumWeaponType.Axe:
                    index = (_weapon.ItemLevel * (int)r.Next(axeNames.Count)) % (axeNames.Count);
                    _name += axeNames[index];
                    break;
                case Core.Items.EnumWeaponType.Mace:
                    index = (_weapon.ItemLevel * (int)r.Next(maceNames.Count)) % (maceNames.Count);
                    _name += maceNames[index];
                    break;
                case EnumWeaponType.Staff:
                    index = (_weapon.ItemLevel * (int)r.Next(staffNames.Count)) % (staffNames.Count);
                    _name += staffNames[index];
                    break;
                case Core.Items.EnumWeaponType.Bow:
                    index = (_weapon.ItemLevel * (int)r.Next(bowNames.Count)) % (bowNames.Count);
                    _name += bowNames[index];
                    break;
                case Core.Items.EnumWeaponType.Dagger:
                    index = (_weapon.ItemLevel * (int)r.Next(daggerNames.Count)) % (daggerNames.Count);
                    _name += daggerNames[index];
                    break;
            }

            if (suffix)
            {
                _name += " ";
                index = (_weapon.ItemLevel * r.Next(itemSuffixes.Count)) % (itemSuffixes.Count);
                _name += itemSuffixes[index];
            }

            return _name;
 
        }

        private static string GenerateArmorName(Armor _armor, bool prefix, bool suffix)
        {
            Random r = new Random();
            int index = 0;
            string _name = "";

            if (prefix)
            {
                index = (_armor.ItemLevel * r.Next(itemPrefixes.Count)) % (itemPrefixes.Count);
                _name = itemPrefixes[index];
                _name += " ";
            }

            switch (_armor.ArmorType)
            {
                case EnumArmorType.Chestarmor:
                    index = (_armor.ItemLevel * r.Next(chestArmorNames.Count)) % (chestArmorNames.Count);
                    _name += chestArmorNames[index];
                    break;
                case EnumArmorType.Headarmor:
                    index = (_armor.ItemLevel * r.Next(helmArmorNames.Count)) % (helmArmorNames.Count);
                    _name += helmArmorNames[index];
                    break;
                case EnumArmorType.Legarmor:
                    index = (_armor.ItemLevel * r.Next(legArmorNames.Count)) % (legArmorNames.Count);
                    _name += legArmorNames[index];
                    break;
            }

            if (suffix)
            {
                _name += " ";
                index = (_armor.ItemLevel * r.Next(itemSuffixes.Count)) % (itemSuffixes.Count - 1);
                _name += itemSuffixes[index];
            }

            return _name;

        }

        private static string GenerateBattleCharmName(BattleCharm _bc, bool prefix, bool suffix)
        {
            Random r = new Random();
            int index = 0;
            string _name = "";

            if (prefix)
            {
                index = (_bc.ItemLevel * r.Next(itemPrefixes.Count)) % (itemPrefixes.Count);
                _name = itemPrefixes[index];
                _name += " ";
            }

            _name += "Battle Charm";
           
            if (suffix)
            {
                _name += " ";
                index = (_bc.ItemLevel * r.Next(itemSuffixes.Count)) % (itemSuffixes.Count - 1);
                _name += itemSuffixes[index];
            }

            return _name;

        }

        #endregion
    }
}
