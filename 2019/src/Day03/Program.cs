using Day03;
using System;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("Inputs/3.txt");

var directionsOne = lines[0];
var directionsTwo = lines[1];

// Part One
var closest = LineCalculator.GetClosestIntersectionManhattan(directionsOne, directionsTwo);

Console.WriteLine($"The Manhattan distance from the central port to the closest intersection is {closest}.");

// Part Two
var intersections = LineCalculator.GetIntersectionPoints(directionsOne, directionsTwo);

var lowestCombinedSteps = intersections
    .Where(i => i != (0,0))
    .Select(s => LineCalculator.GetTotalStepsToReachPoint(directionsOne, s.Item1, s.Item2) + LineCalculator.GetTotalStepsToReachPoint(directionsTwo, s.Item1, s.Item2))
    .Min();

Console.WriteLine($"The fewest combined steps the wires must take to reach an intersection is {lowestCombinedSteps}.");
    
