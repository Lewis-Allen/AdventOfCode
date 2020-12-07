using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var file = File.ReadAllLines("../../../input.txt");
var bags = new Dictionary<string, List<(int, string)>>();

foreach(var line in file)
{
    ParseLine(line, bags);
}

var colour = "shiny gold";

int noOfColours = FindParents(colour, bags).Count;
Console.WriteLine($"{noOfColours} different bag colours have at least one {colour} bag inside!");

// We want bags inside! (not counting the shiny gold bag itself).
int noOfBags = TotalBags(colour, bags);
Console.WriteLine($"The {colour} bag contains {noOfBags - 1} other bags!");

static HashSet<string> FindParents(string colour, Dictionary<string, List<(int, string)>> bags)
{
    HashSet<string> found = new();
    FindParentsHelper(colour, bags, found);
    return found;
}

static void FindParentsHelper(string colour, Dictionary<string, List<(int, string)>> bags, HashSet<string> found)
{
    foreach(var key in bags.Keys.Where(s => bags[s].Any(t => t.Item2 == colour) && !found.Contains(s)))
    {
        found.Add(key);
        FindParentsHelper(key, bags, found);
    }
}

static int TotalBags(string colour, Dictionary<string, List<(int, string)>> bags)
{
    return 1 + bags[colour].Sum(s => s.Item1 * TotalBags(s.Item2, bags));
}

static void ParseLine(string line, Dictionary<string, List<(int, string)>> bags)
{
    var items = Regex.Matches(line, "(^\\w+\\s\\w+)|(\\d\\s\\w+\\s\\w+)")
        .OfType<Match>()
        .Select(m => m.Groups[0].Value)
        .ToArray();

    string bagColour = items[0];

    bags.Add(bagColour, new());

    for (var i = 1; i < items.Length; i++)
    {
        var num = int.Parse(items[i].Substring(0, 1));
        var colour = items[i].Substring(2, items[i].Length - 2);

        bags[bagColour].Add((num, colour));
    }
}