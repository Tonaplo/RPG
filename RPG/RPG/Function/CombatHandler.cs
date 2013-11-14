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
                if(value < 20)
                    return 2;
                else if (value < 40)
                    return 3;
                else if (value < 60)
                    return 4;
                else if (value < 80)
                    return 5;
                else
                    return 6;
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
    }
}
