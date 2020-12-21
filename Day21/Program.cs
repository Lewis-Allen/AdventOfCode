using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

var lines = File.ReadAllLines("../../../Input.txt");

Dictionary<string[], List<string>> linesLookup = new();
Dictionary<string, string> allergensLookup = new();

// Parse file into dictionary:
foreach (var line in lines)
{
    var allergens = Regex.Match(line, "contains ([^\\)]*)").Groups[1].Value.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
    var ingredients = Regex.Match(line, ".+?(?= \\(contains)").Value.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();

    linesLookup[allergens] = ingredients;
}

List<string> foundAllergens = new();

var allAllergens = linesLookup.Keys
    .Skip(1)
    .Aggregate(
    new HashSet<string>(linesLookup.Keys.First()),
    (h, e) => { h.UnionWith(e); return h; }
);

while (foundAllergens.Count < allAllergens.Count)
{
    foreach (var allergen in allAllergens)
    {
        if (foundAllergens.Contains(allergen))
            continue;

        var linesContainingAllergen = linesLookup.Where(l => l.Key.Contains(allergen)).Select(l => l.Value);

        var allergyPossibilites = linesContainingAllergen
            .Skip(1)
            .Aggregate(
                new HashSet<string>(linesContainingAllergen.First()),
                (h, e) => { h.IntersectWith(e); return h; }
            );

        if (allergyPossibilites.Count == 1)
        {
            allergensLookup[allergen] = allergyPossibilites.First();
            foundAllergens.Add(allergen);

            var keys = linesLookup.Keys;
            foreach(var key in keys)
            {
                linesLookup[key].Remove(allergyPossibilites.First());
            }

        }
    }
}

int safeIngredients = linesLookup.Sum(s => s.Value.Count);
Console.WriteLine($"Safe ingredient occurences: {safeIngredients}.");

// Part Two
StringBuilder sb = new("");
foreach(var allergen in allergensLookup.Keys.ToList().OrderBy(x => x).ToList())
{
    sb.Append(allergensLookup[allergen] + ",");
}

string canonicalList = sb.ToString()[0..^1];
Console.WriteLine($"My canonical list is {canonicalList}.");