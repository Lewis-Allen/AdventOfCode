using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    public class WrappingCalculator
    {
        public static int GetRequiredWrappingPaper(int length, int width, int height)
        {
            int min = new[] { length * width, width * height, height * length }.Min();

            return (2 * length * width) + (2 * width * height) + (2 * height * length) + min;
        }

        public static int GetRequiredRibbon(int length, int width, int height) =>
            Math.Min(Math.Min(2 * length + 2 * height, 2 * width + 2 * height), (2 * length) + (2 * width)) + (length * width * height);
        
    }
}
