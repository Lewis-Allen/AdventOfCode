using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    public static class FuelCalculator
    {
        public static int CalculateFuelPartOne(int mass) => (mass / 3) - 2;

        public static int CalculateFuelPartTwo(int mass)
        {
            var total = CalculateFuelPartOne(mass);
            
            if (total <= 0) 
                return 0;

            return total + CalculateFuelPartTwo(total);
        }
    }
}
