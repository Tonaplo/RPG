using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG;
using RPG.Core;
using RPG.Function;

namespace RPG.Function
{
    public class Battle
    {
        #region Fields
        List<Core.Units.Character> battleChars;
        Core.Units.NPC enemy;
        Function.NPCAI ai;
        Random r = new Random();
        #endregion

        public Battle(List<Core.Units.Character> _listOfChars, int _difficulty)
        {
            battleChars = _listOfChars;

            int sum = 0;

            foreach (var item in battleChars)
            {
                sum += item.UnitLevel;
	        }

            int average = (int)(sum/battleChars.Count);

            enemy = WorldGeneration.GenerateNPC("", average, _difficulty, EnumMonsterType.Null, battleChars.Count);
            ai = WorldGeneration.GenerateNPCAI(enemy, battleChars);
        }

        /// <summary>
        /// This function runs the AI's turn and resets the characters turnpoints.
        /// </summary>
        public void DoAITurn()
        {
            ai.Run();

            foreach (var item in battleChars)
            {
                item.CurrentTurnPoints.IntValue = (item.UnitLevel/10)+1;
            }
        }
    }
}
