using System;
using System.IO;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("../../../Inputs/1.txt");

            Console.WriteLine("Part One---");
            Console.WriteLine(FloorCalculator.CalculateFloor(input));

            Console.WriteLine("Part Two---");
            Console.WriteLine(FloorCalculator.FindBasementEntryPosition(input));
        }
    }
}
