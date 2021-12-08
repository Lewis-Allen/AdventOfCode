using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    public class SignalDecoder
    {
        // I could just check length of output strings for this one...
        public static int DecodeSignals(string[] lines) => lines
            .Select(l => new Signal(l))
            .Sum(s => s.Outputs.Count(s => s == 1 || s == 4 || s == 7 || s == 8));

        public static int DecodeSignalsAndGetSum(string[] lines) => lines
            .Select(l => new Signal(l))
            .Sum(s => int.Parse(string.Join("", s.Outputs.Select(o => o.ToString()).ToArray())));
    }
}
