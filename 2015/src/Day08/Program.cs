using Day08;
using System;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("Inputs/8.txt");

// Part One
var result = lines.Sum(l => CharacterCounter.GetCharacters(l));
Console.WriteLine($"The number of characters of code for string literals minus the number of characters in memory for the values of the strings in total for the entire file is {result}.");

// Part Two
result = lines.Sum(l => CharacterCounter.GetCharactersEncode(l));
Console.WriteLine($"The total number of characters to represent the newly encoded strings minus the number of characters of code in each original string literal is {result}.");