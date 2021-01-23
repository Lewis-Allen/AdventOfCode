using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

var lines = File.ReadAllLines("../../../Input.txt");

Dictionary<string[], List<string>> linesLookup = new();
SortedDictionary<string, string> allergensLookup = new();

// Parse file into dictionary:
foreach (var line in lines)
{
    var allergens = Regex.Match(line, "contains ([^\\)]*)").Groups[1].Value.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
    var ingredients = Regex.Match(line, ".+?(?= \\(contains)").Value.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();

    linesLookup[allergens] = ingredients;
}

HashSet<string> allAllergens = linesLookup.Keys
    .Skip(1)
    .Aggregate(
        new HashSet<string>(linesLookup.Keys.First()),
        (h, e) => { h.UnionWith(e); return h; }
    );

while (allergensLookup.Keys.Count < allAllergens.Count)
{
    foreach (var allergen in allAllergens.Where(s => !allergensLookup.ContainsKey(s)))
    {
        var linesContainingAllergen = linesLookup
            .Where(l => l.Key.Contains(allergen))
            .Select(l => l.Value);

        HashSet<string> allergyPossibilites = linesContainingAllergen
            .Skip(1)
            .Aggregate(
                new HashSet<string>(linesContainingAllergen.First()),
                (h, e) => { h.IntersectWith(e); return h; }
            );

        if (allergyPossibilites.Count == 1)
        {
            allergensLookup[allergen] = allergyPossibilites.First();

            foreach(var key in linesLookup.Keys)
            {
                linesLookup[key].Remove(allergyPossibilites.First());
            }
        }
    }
}

// Part One
int safeIngredients = linesLookup.Sum(s => s.Value.Count);
Console.WriteLine($"Safe ingredient occurrences: {safeIngredients}.");

// Part Two
string canonicalList = string.Join(",", allergensLookup.Values);
Console.WriteLine($"My canonical list is {canonicalList}.");