﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Core;
using RPG.Core.Abilities;

namespace RPG.Function
{
    public class NPCAI
    {
        string chatAction = "";
        Core.Units.NPC npc;
        List<Core.Units.Character> targets = new List<Core.Units.Character>();
        int aiScript = 0;
        int aiStep = 0;
        Random r = new Random();

        /// <summary>
        /// This is the NPC AI. It is used by using the Run() function.
        /// </summary>
        /// <param name="_npc">The NPC this AI is for</param>
        /// <param name="_aiNumber">The AI to be choosen</param>
        /// <param name="_targets">The targets the AI should go for</param>
        public NPCAI(Core.Units.NPC _npc, List<Core.Units.Character> _targets)
        {
            int averagelevel = 0;
            int sum = 0;

            foreach (var item in _targets)
            {
                sum += item.UnitLevel;
            }

            averagelevel = (int)((double)sum / (double)_targets.Count);
            this.npc = _npc;

            if (averagelevel < 10)
            {
                this.aiScript = 0;
            }
            else
            {
                this.aiScript = r.Next(0, 7);
            }

            this.targets = _targets;
            AddAbilities();
        }

        public string Chat
        {
            get { return chatAction; }
            private set { chatAction = value; }
        }

        public List<Core.Units.Character> Targets
        {
            get { return targets; }
            set { targets = value; }
        }

        public Core.Units.NPC ModifiedNPC
        {
            get { return npc; }
        }

        /// <summary>
        /// Adds abilities to the given NPCAI
        /// </summary>
        public void AddAbilities()
        {
            switch (aiScript)
            {
                case 0:
                    if (npc.UnitActiveAbilities.Count == 0)
                        npc.AddActiveAbility(new NPCFireball(null, "", "", null, EnumAbilityClassReq.NPC));
                    break;
                case 1:
                    if (npc.UnitActiveAbilities.Count == 0)
                    {
                        npc.AddActiveAbility(new NPCHeal(null, "", "", null, EnumAbilityClassReq.NPC));
                        npc.AddActiveAbility(new NPCNuke(null, "", "", null, EnumAbilityClassReq.NPC));
                    }
                    break;
                case 2:
                    if (npc.UnitActiveAbilities.Count == 0)
                        npc.AddActiveAbility(new NPCAtonementSmite(null, "", "", null, EnumAbilityClassReq.NPC));
                    break;
                case 3:
                    if (npc.UnitActiveAbilities.Count == 0)
                    {
                        npc.AddActiveAbility(new NPCHeal(null, "", "", null, EnumAbilityClassReq.NPC));
                        npc.AddActiveAbility(new NPCAtonementSmite(null, "", "", null, EnumAbilityClassReq.NPC));
                        npc.AddActiveAbility(new NPCFireball(null, "", "", null, EnumAbilityClassReq.NPC));
                    }
                    break;
                case 4:
                    if (npc.UnitActiveAbilities.Count == 0)
                    {
                        npc.AddActiveAbility(new NPCGrow(null, "", "", null, EnumAbilityClassReq.NPC));
                        npc.AddActiveAbility(new NPCDesperation(null, "", "", null, EnumAbilityClassReq.NPC));
                    }
                    break;
                case 5:
                    if (npc.UnitActiveAbilities.Count == 0)
                    {
                        npc.AddActiveAbility(new NPCGrowingDespair(null, "", "", null, EnumAbilityClassReq.NPC));
                    }
                    break;
                case 6:
                    if (npc.UnitActiveAbilities.Count == 0)
                    {
                        npc.AddActiveAbility(new NPCCarpetBomb(null, "", "", null, EnumAbilityClassReq.NPC));
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Runs the given NPCAI script
        /// </summary>
        public void Run()
        {

            switch (aiScript)
            {
                case 0:
                    ConstantFireballs();
                    break;
                case 1:
                    NukeAndHeal();
                    break;
                case 2:
                    AtonementSmite();
                    break;
                case 3:
                    WhichShouldITake();
                    break;
                case 4:
                    GrowAndDespair();
                    break;
                case 5:
                    GrowingDespair();
                    break;
                case 6:
                    CarpetBomber();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// this AI just constantly fires Fireballs at the enemy. 
        /// </summary>
        private void ConstantFireballs()
        {
            npc.UnitActiveAbilities[0].UseAbility(npc, targets);
            chatAction = npc.UnitActiveAbilities[0].ChatString;
        }

        /// <summary>
        /// Drop a huge nuke on the players and then heals up self for 5 rounds
        /// </summary>
        private void NukeAndHeal()
        {
            if (aiStep == 0)
            {
                npc.UnitActiveAbilities[1].UseAbility(npc, targets);
                chatAction = npc.UnitActiveAbilities[1].ChatString;
            }
            else
            {
                npc.UnitActiveAbilities[0].UseAbility(npc, targets);
                chatAction = npc.UnitActiveAbilities[0].ChatString;
            }

            aiStep++;

            if (aiStep == 5)
                aiStep = 0;
        }

        /// <summary>
        /// Spams Atonement on enemies
        /// </summary>
        private void AtonementSmite()
        {
            npc.UnitActiveAbilities[0].UseAbility(npc, targets);
            chatAction = npc.UnitActiveAbilities[0].ChatString;
        }

        /// <summary>
        /// Randomly either Heals, Fireballs or Atonement Smites.
        /// </summary>
        private void WhichShouldITake()
        {
            for (int i = 0; i < 1; i++)
            {
                int index = r.Next(0, 3);
                npc.UnitActiveAbilities[index].UseAbility(npc, targets);
                chatAction = npc.UnitActiveAbilities[index].ChatString;
            }
            
        }

        /// <summary>
        /// Alternates between increasing it's health pool and dealing damage based on it's remaining health
        /// </summary>
        private void GrowAndDespair()
        {
            if (aiStep == 0)
            {
                npc.UnitActiveAbilities[1].UseAbility(npc, targets);
                chatAction = npc.UnitActiveAbilities[1].ChatString;
            }
            else
            {
                npc.UnitActiveAbilities[0].UseAbility(npc, targets);
                chatAction = npc.UnitActiveAbilities[0].ChatString;
            }

            aiStep++;

            if (aiStep == 3)
                aiStep = 0;
        }

        /// <summary>
        /// Deals increasingly higher damage each turn.
        /// </summary>
        private void GrowingDespair()
        {
            npc.UnitActiveAbilities[0].UseAbility(npc, targets);
            chatAction = npc.UnitActiveAbilities[0].ChatString;
        }

        private void CarpetBomber()
        {
            npc.UnitActiveAbilities[0].UseAbility(npc, targets);
            chatAction = npc.UnitActiveAbilities[0].ChatString;
        }
    }
}
