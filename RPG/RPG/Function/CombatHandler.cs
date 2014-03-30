using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Core;
using RPG.Core.Units;

namespace RPG.Function
{
    public static class CombatHandler
    {
        public static double CritCalculator(int _unitLevel, int _critRating)
        {
            int critPercent = ReturnCritPercent(_unitLevel, _critRating);
            Random r = new Random();

            if (critPercent > 95)
                critPercent = 95;

            if (r.Next(0, 101) < critPercent)
            {
                return 1.5;
            }
            else
            {
                return 1.0;
            }
        }

        public static int SpeedCalculator(int _unitLevel, int _critRating)
        {
            Random r = new Random();
            int speedPercent = ReturnSpeedPercent(_unitLevel, _critRating);
            int value = r.Next(0, 101);

            if (speedPercent > 95)
                speedPercent = 95;

            if (value < speedPercent)
            {
                if(value < 30)
                    return 2;
                else if (value < 60)
                    return 3;
                else if (value < 90)
                    return 4;
                else
                    return 5;
            }
            else
            {
                return 1;
            }
        }

        public static int ReturnSpeedPercent(int _unitLevel, int _critRating)
        {
            return (int)((double)_critRating/((_unitLevel+1)*0.22));
        }

        public static int ReturnCritPercent(int _unitLevel, int _critRating)
        {
            return (int)((double)_critRating / ((_unitLevel + 1) * 0.19));
        }

        public static bool RequiresNoTarget(Ability ab)
        {
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleAnyEmpowerment)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleAnyInvigorate)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleAnyOpportunity)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleAnyAscend)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleWarriorRoar)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleWarriorInfuriate)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitlePaladinPrayer)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitlePaladinThePowerOfFaith)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleWizardBrilliance)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleWizardArchon)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleThiefSwiftness)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleThiefEnvenom)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleCaretakerZealOfHumanity)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleCaretakerAction)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleCaretakerDeathdefiance)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleSynergistBalance)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleSynergistAlign)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleSynergistCollapsedEquality)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleSynergistCompleteBalance)
                return true;
            if (ab.AbilityName == Properties.Resources.AbilitiesTitleWizardOracle)
                return true;

            return false;
        }
    }
}
