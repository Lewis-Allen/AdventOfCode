using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Octopus
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Charge { get; set; }
        public bool Flashed { get; set; } = false;

        public Octopus(int x, int y, int charge)
        {
            X = x;
            Y = y;
            Charge = charge;
        }
    }
}
