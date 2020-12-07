using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var file = File.ReadAllLines("../../../input.txt");

List<string> colours = new();

var bags = new Dictionary<string, List<(int, string)>>();

foreach(var line in file)
{
    ParseLine(line, bags);
}

int noOfColours = PartOne(bags);
Console.WriteLine(noOfColours);

int noOfBags = TotalBags("shiny gold", bags);

// We want bags inside! (not counting the shiny gold back itself).
Console.WriteLine(noOfBags - 1);

static int PartOne(Dictionary<string, List<(int, string)>> bag)
{
    HashSet<string> found = new();

    FindParents("shiny gold", bag, found);

    return found.Count;
}

static void FindParents(string colour, Dictionary<string, List<(int, string)>> bag, HashSet<string> found)
{
    foreach (var key in bag.Keys)
    {
        if (bag[key].Any(s => s.Item2 == colour) && !found.Contains(key))
        {
            found.Add(key);
            FindParents(key, bag, found);
        }
    }
}

static int TotalBags(string colour, Dictionary<string, List<(int, string)>> bag)
{
    return 1 + bag[colour].Sum(s => s.Item1 * TotalBags(s.Item2, bag));
}

static void ParseLine(string line, Dictionary<string, List<(int, string)>> bags)
{
    //clear purple bags contain 5 faded indigo bags, 3 muted purple bags.
    var items = Regex.Matches(line, "((?:\\S+\\s){2,3})(bags?)")
        .OfType<Match>()
        .Select(m => m.Groups[0].Value.Replace("bags", "").Replace("bag", "").Trim())
        .ToArray();

    var bagColour = items[0];

    bags.Add(bagColour, new());

    for (var i = 1; i < items.Length; i++)
    {
        if (items[i] == "contain no other")
            continue;

        var num = int.Parse(items[i].Substring(0, 1));
        var colour = items[i].Substring(2, items[i].Length - 2);

        bags[bagColour].Add((num, colour));
    }
}