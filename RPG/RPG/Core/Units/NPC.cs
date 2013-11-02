using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Core.Units
{
    public class NPC :Unit
    {
        #region Fields

        EnumMonsterType typeOfNPC;
        int experienceYielded;
        static Random r = new Random();
        #endregion

        #region Properties

        public EnumMonsterType TypeOfNPC
        {
            get { return typeOfNPC; }
            set { typeOfNPC = value; }
        }

        public int ExperienceYielded
        {
            get { return experienceYielded; }
            set { experienceYielded = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// The Main constructor for the NPCs.
        /// </summary>
        /// <param name="_name">The name of the NPC</param>
        /// <param name="_level">The level of the NPC. This value also indicates how good the loot the NPC drops will be</param>
        /// <param name="_basehp">The BASE amount of health of the NPC</param>
        /// <param name="_basemana">The BASE amount of mana of the NPC</param>
        /// <param name="_curhp">The CURRENT amount of health of the NPC</param>
        /// <param name="_curmana"> The CURRENT amount of mana of the NPC</param>
        /// <param name="_npctype">The type of the NPC</param>
        /// <param name="_xpGranted">How much Experience the NPC will grant the player when it is killed</param>
        /// <param name="_armor">The armor of the NPC</param>
        /// <param name="_meleeattack">The meleeattack damage of the NPC</param>
        /// <param name="_pa">The Passive Abilities of the NPC</param>
        /// <param name="_aa">The Activate Abilities of the NPC</param>
        /// <param name="_loot">The loot the NPC will drop. NOTE: Only include EPOCHAL items here, as other drops will be auto generated</param>
        public NPC(string _name, int _level, int _basehp, int _curhp, EnumMonsterType _npctype, int _xpGranted, List<Abilities.ActiveAbility> _pa, List<Abilities.ActiveAbility> _aa)
            : base(_name, _level, _basehp, _curhp)
        {
            this.typeOfNPC = _npctype;
            this.UnitActiveAbilities = _aa;
            this.UnitPassiveAbilities = _pa;
            if (_xpGranted > 0)
                this.experienceYielded = 3*_xpGranted;
            else
                this.experienceYielded = 3;

            if (_pa == null)
                this.UnitPassiveAbilities = new List<Abilities.ActiveAbility>();
            else
                this.UnitPassiveAbilities = _pa;

            if (_aa == null)
                this.UnitActiveAbilities = new List<Abilities.ActiveAbility>();
            else
                this.UnitActiveAbilities = _aa;
        }
        #endregion

        #region Functions

        #endregion
    }
}
