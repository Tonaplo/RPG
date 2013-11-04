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
            int critPercent = ReturnCritAndSpeedPercent(_unitLevel, _critRating);
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
            int speedPercent = ReturnCritAndSpeedPercent(_unitLevel, _critRating);
            Random r = new Random();

            if (speedPercent > 95)
                speedPercent = 95;

            if (r.Next(0, 101) < speedPercent)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public static int ReturnCritAndSpeedPercent(int _unitLevel, int _critRating)
        {
            return (int)((double)_critRating/((_unitLevel+1)*0.3));
        }
    }
}
