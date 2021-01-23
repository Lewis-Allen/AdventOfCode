using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    public class FloorCalculator
    {
        public static int CalculateFloor(string instructions) =>
            instructions.Count(c => c == '(') - instructions.Count(c => c == ')');

        public static int FindBasementEntryPosition(string instructions)
        {
            int currentFloor = 0;

            for(int i = 1; i <= instructions.Length; i++)
            {
                currentFloor = instructions[i-1] == '(' ? currentFloor + 1 : currentFloor - 1;
                if (currentFloor < 0)
                    return i;
            }

            throw new Exception("Basement does not get entered.");
        }
    }
}
