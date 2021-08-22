using Day01;
using System;
using System.IO;
using System.Linq;

int[] masses = File.ReadAllLines("Inputs/1.txt").Select(i => int.Parse(i)).ToArray();

// Part One
var totalFuel = masses.Sum(m => FuelCalculator.CalculateFuelPartOne(m));
Console.WriteLine($"The total fuel required for part one is {totalFuel}");

// Part Two
totalFuel = masses.Sum(m => FuelCalculator.CalculateFuelPartTwo(m));
Console.WriteLine($"The total fuel required for part two is {totalFuel}");
