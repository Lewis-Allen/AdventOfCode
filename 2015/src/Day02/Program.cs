using System;
using System.IO;
using System.Linq;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("../../../Inputs/2.txt")
                .Select(l => Array.ConvertAll(l.Split("x"), int.Parse))
                .ToArray();

            Console.WriteLine("Part One---");
            var partOne = lines.Sum(a => WrappingCalculator.GetRequiredWrappingPaper(a[0], a[1], a[2]));
            Console.WriteLine(partOne);

            Console.WriteLine("Part Two---");
            var partTwo = lines.Sum(a => WrappingCalculator.GetRequiredRibbon(a[0], a[1], a[2]));
            Console.WriteLine(partTwo);
        }
    }
}
