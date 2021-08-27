using Day09;
using System;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("Inputs/9.txt");
var calculator = new DistanceCalculator(lines);

// Part One
var distances = calculator.CalculateAllShortestDistances();
var result = distances.Values.Min();
Console.WriteLine($"The distance of the shortest route is {result}.");

// Part Two
distances = calculator.CalculateAllLongestDistances();
result = distances.Values.Max();
Console.WriteLine($"The distance of the longest route is {result}.");