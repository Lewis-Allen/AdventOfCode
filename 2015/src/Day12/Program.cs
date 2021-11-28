// See https://aka.ms/new-console-template for more information
using Day12;

var input = File.ReadAllText("Inputs/12.json");

// Part One
var total = BooksReader.SumOfAllNumbers(input);

Console.WriteLine($"The sum of all numbers in the document is {total}.");

// Part Two
total = BooksReader.SumExcludingRed(input);

Console.WriteLine(@$"The sum of all numbers in the document excluding objects containing ""red"" is {total}.");