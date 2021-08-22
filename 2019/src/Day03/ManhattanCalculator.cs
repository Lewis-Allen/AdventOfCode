using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    public static class ManhattanCalculator
    {
        public static int GetManhattanDistance(int fromX, int fromY, int toX, int toY)
            => Math.Abs(fromX - toX) + Math.Abs(fromY - toY);
    }
}
