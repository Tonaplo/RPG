using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Core;
using RPG.Core.Units;

namespace RPG.Function
{
    public static class WorldGeneration
    {
        #region Fields
        static Random r = new Random();
        static List<string> dragonNames = new List<string>();
        static List<string> beastNames = new List<string>();
        static List<string> humanoidNames = new List<string>();
        static List<NPCAI> listOfAI = new List<NPCAI>();
        #endregion

        public static void InitializeWorldGeneration()
        {

            #region Dragon Names

            dragonNames.Add("Xiuhcoatl");
            dragonNames.Add("Apalala");
            dragonNames.Add("Apep");
            dragonNames.Add("Apephis");
            dragonNames.Add("Astarot");
            dragonNames.Add("Attor");
            dragonNames.Add("Chua");
            dragonNames.Add("Dracul");
            dragonNames.Add("Drago");
            dragonNames.Add("Drakon");
            dragonNames.Add("Ehecatl");
            dragonNames.Add("Fraener");
            dragonNames.Add("Leviathan");
            dragonNames.Add("Livyathan");
            dragonNames.Add("Nagendra");
            dragonNames.Add("Nilakanta");
            dragonNames.Add("Ophiucus");
            dragonNames.Add("Ormass");
            dragonNames.Add("Orochi");
            dragonNames.Add("Pachua");
            dragonNames.Add("Pendragon");
            dragonNames.Add("Pythius");
            dragonNames.Add("Quetzalcoatl");
            dragonNames.Add("Samael");
            dragonNames.Add("Shesha");
            dragonNames.Add("Tatsuo");
            dragonNames.Add("Tatsuya");
            dragonNames.Add("Vasuki");
            dragonNames.Add("Veles");
            dragonNames.Add("Volos");
            dragonNames.Add("Vritra");

            #endregion

            #region Beast Names
            beastNames.Add("Ancient Cobra");
            beastNames.Add("Bane-chiller");
            beastNames.Add("Blessed Fiend-woman");
            beastNames.Add("Bony Freezer");
            beastNames.Add("Burning Stinger");
            beastNames.Add("Chaotic Wisp");
            beastNames.Add("Cursed Shiver Mammoth");
            beastNames.Add("Dryad Cactus");
            beastNames.Add("Greater Mane Worm");
            beastNames.Add("Invisible Sedge");
            beastNames.Add("Mist Ripper");
            beastNames.Add("Stun Shredder");
            beastNames.Add("Throatfungus");
            beastNames.Add("Vaultbrute");
            beastNames.Add("Vomitmouth");
            beastNames.Add("Banshee");
            beastNames.Add("Sentinel");
            beastNames.Add("Bug Gremlin");
            beastNames.Add("Cobra Charge");
            beastNames.Add("Creature-executioner");
            beastNames.Add("Elder Moray");
            beastNames.Add("Infernal Behemoth");
            beastNames.Add("Jagged Wraith");
            beastNames.Add("Lurking Bear");
            beastNames.Add("Phased Twister Ape");
            beastNames.Add("Primal Frill Sprite");
            beastNames.Add("Razorstealth Goblin");
            beastNames.Add("Root Ooze");
            beastNames.Add("Siren Burner");
            beastNames.Add("Stinging Dirge");
            beastNames.Add("Thornsnow Heap");
            beastNames.Add("Underwater Choker-screamer");
            beastNames.Add("Unknowable Combat Cheeta");
            beastNames.Add("Vicious Thief-quipper");
            beastNames.Add("Visionweb Wraith");
            #endregion

            #region Humanoid names
            humanoidNames.Add("Charmcog");
            humanoidNames.Add("Charnelbloom");
            humanoidNames.Add("Corpsefire");
            humanoidNames.Add("Crazevomit");
            humanoidNames.Add("Hatewave");
            humanoidNames.Add("Hauntblade");
            humanoidNames.Add("Hunterdash");
            humanoidNames.Add("Leafpulley");
            humanoidNames.Add("Masterdart");
            humanoidNames.Add("Moneystealth");
            humanoidNames.Add("Nightghast");
            humanoidNames.Add("Quickcinder");
            humanoidNames.Add("Scumdemon");
            humanoidNames.Add("Seekarc");
            humanoidNames.Add("Seekerhaunt");
            humanoidNames.Add("Shadowsmash");
            humanoidNames.Add("Sharpthorn");
            humanoidNames.Add("Shiverseek");
            humanoidNames.Add("Slyflare");
            humanoidNames.Add("Zapgibber");
            #endregion

        }

        #region Generation of NPCs

        /// <summary>
        /// This method generates an NPC, along with a random AI
        /// </summary>
        /// <param name="_npcName">The name of the NPC - set to null for generated name</param>
        /// <param name="_npcLevel">The level the NPC should be</param>
        /// <param name="_npcType">The Monster Type of the NPC - set to null for generated type</param>
        /// <param name="_numberOfChars">The amount of targets, that the NPC should go for</param>
        /// <returns></returns>
        public static Core.Units.NPC GenerateNPC(string _npcName, int _npcLevel, int _difficulty, EnumMonsterType _npcType, int numberOfChars)
        {
            int realLevel = _npcLevel + _difficulty;
            int expGained = 0;
            int hp = 0;
            if (realLevel <= 1)
                hp = (int)(5 * numberOfChars*1.2 * ((_npcLevel/10)+1));
            else if (realLevel == 2)
                hp = (int)((realLevel * 4) * numberOfChars * 1.2 + (realLevel / 10) * 2);
            else
                hp = (int)((realLevel * (realLevel - 1)) * numberOfChars * 1.2 + (_npcLevel / 10) * 2);

            if (_difficulty == -4)
                expGained = 0;
            else if (_difficulty == -2)
                expGained = (int)(realLevel * 0.5);
            else if (_difficulty == 0)
                expGained = realLevel;
            else if (_difficulty == 2)
                expGained = (int)(realLevel * 1.2);
            else if (_difficulty == 4)
                expGained = (int)(realLevel * 1.5);

            expGained *= (int)(0.9 + (double)numberOfChars/6.0);

            Core.Units.NPC returnedNPC = new Core.Units.NPC(_npcName, realLevel, hp, hp, _npcType, expGained, null, null);

            if (_npcType == EnumMonsterType.Null)
                returnedNPC.TypeOfNPC = GenerateMonterType();

            if (_npcName == null)
                returnedNPC.UnitName = GenerateMonterName(returnedNPC.TypeOfNPC);

            return returnedNPC;
        }

        /// <summary>
        /// This function generates a montername based on the type of the monster
        /// NOTE: Humanoids and undead share the same names.
        /// </summary>
        /// <param name="_npcType">The type of NPC being named</param>
        /// <returns>The new name of the NPC</returns>
        private static string GenerateMonterName(EnumMonsterType _npcType)
        {
            string _name = "";

            switch (_npcType)
            {
                case EnumMonsterType.Dragon:
                    _name += dragonNames[r.Next(dragonNames.Count - 1)];
                    break;
                case EnumMonsterType.Humanoid:
                    _name += humanoidNames[r.Next(humanoidNames.Count - 1)];
                    break;
                case EnumMonsterType.Beast:
                    _name += beastNames[r.Next(beastNames.Count - 1)];
                    break;
                case EnumMonsterType.Undead:
                    _name += humanoidNames[r.Next(humanoidNames.Count - 1)];
                    break;
            }
            return _name;
        }

        /// <summary>
        /// Generates a Random Monster Type;
        /// </summary>
        /// <returns></returns>
        private static EnumMonsterType GenerateMonterType()
        {
            EnumMonsterType _newtype;
            int selectionValue = r.Next(0, 20);

            if (selectionValue < 8)
                _newtype = EnumMonsterType.Beast;
            else if (selectionValue <= 14)
                _newtype = EnumMonsterType.Humanoid;
            else if (selectionValue <= 18)
                _newtype = EnumMonsterType.Undead;
            else
                _newtype = EnumMonsterType.Dragon;

            return _newtype;
        }

        /// <summary>
        /// This function generates a random NPC AI based on the NPC, an integer and a list of it's possible targets.
        /// </summary>
        /// <param name="npc">The NPC to generate from</param>
        /// <param name="random">Make it a random ai (true) or base it on the NPC type</param>
        /// <param name="_characters">The targets for the NPC</param>
        /// <returns></returns>
        public static NPCAI GenerateNPCAI(Core.Units.NPC npc, List<Character> _characters)
        {
            NPCAI ai = new NPCAI(npc, _characters);
            return ai;
        }

        #endregion
    }
}
