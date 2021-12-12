using Day12;

var lookup = Spelunker.ParseLines(File.ReadAllLines("Inputs/12.txt"));

var paths = Spelunker.FindPaths(lookup);

Console.WriteLine($"The number of distinct paths to the end is {paths.Count}.");

paths = Spelunker.FindPathsWithExtraVisiting(lookup);

Console.WriteLine($"The number of distinct paths with an extra visit to a small cave is {paths.Count}.");