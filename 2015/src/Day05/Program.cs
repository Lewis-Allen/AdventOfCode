using System;
using System.IO;
using System.Linq;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("../../../Inputs/5.txt");

            Console.WriteLine("Part One---");
            Console.WriteLine(lines.Count(s => SantasChecker.CheckString(s)));

            Console.WriteLine("Part Two---");
            Console.WriteLine(lines.Count(s => SantasChecker.CheckStringRefined(s)));
        }
    }
}
