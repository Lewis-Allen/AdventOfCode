using System;
using System.IO;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            var directions = File.ReadAllText("../../../Inputs/3.txt");

            Console.WriteLine("Part One---");
            Console.WriteLine(TransversalCalculator.FindNoOfHousesVisited(directions));

            Console.WriteLine("Part Two---");
            Console.WriteLine(TransversalCalculator.FindNoOfHousesVisitedWithRoboSanta(directions));
        }
    }
}
