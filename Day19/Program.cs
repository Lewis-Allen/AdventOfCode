using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

// Part One
var lines = File.ReadAllText("../../../Input.txt").Split("\r\n\r\n");

var rules = lines[0].Split("\r\n");
var messages = lines[1].Split("\r\n");

rules = rules.OrderBy(r => int.Parse(Regex.Match(r, "\\d+").Value)).ToArray();

var index = rules.ToList().FindIndex(s => Regex.IsMatch(s, $"^0:"));
string regexString = " " + Regex.Match(rules[index], "(?<=(: )).*").Value + " ";
regexString = RegexString(regexString, rules);

var count = messages.Count(m =>
{
    return Regex.IsMatch(m, regexString) &&
           Regex.Match(m, regexString).Value.Length == m.Length;
});

Console.WriteLine($"Part One Matching Rules = {count}.");

/*  Part Two - This really isn't a proper solution to be honest.
   
    Instead of accounting for the recursive regex properly, I just increased the amount of rule occurences 
    in the file for the new rules.

    e.g. 8: 42 | 42 8 became 42 | 42 42 | 42 42 42 | 42 42 42 42 | 42 42 42 42 42 etc..
    
    I just kept increasing the depth until the solution stopped changing.

    This let me use the same string replace algorithm I used for the first solution.
*/
lines = File.ReadAllText("../../../Input2.txt").Split("\r\n\r\n");

rules = lines[0].Split("\r\n");
messages = lines[1].Split("\r\n");

rules = rules.OrderBy(r => int.Parse(Regex.Match(r, "\\d+").Value)).ToArray();

index = rules.ToList().FindIndex(s => Regex.IsMatch(s, $"^0:"));
regexString = " " + Regex.Match(rules[index], "(?<=(: )).*").Value + " ";
regexString = RegexString(regexString, rules);

count = messages.Count(m =>
{
    return Regex.IsMatch(m, regexString) &&
           Regex.Match(m, regexString).Value.Length == m.Length;
});

// Part Two
Console.WriteLine($"Part Two Matching Rules = {count}.");

static string RegexString(string initial, string[] rules)
{
    int count = 0;
    while (Regex.IsMatch(initial, "\\d+") && count < 200 )
    {
        foreach (var match in Regex.Matches(initial, "[^\\d]\\d+[^\\d]").ToList())
        {
            var ruleNo = int.Parse(match.Value);
            var index = rules.ToList().FindIndex(s => Regex.IsMatch(s, $"^{ruleNo}:"));

            var replacement = " ( " + Regex.Match(rules[index], "(?<=(: )).*").Value + " ) ";

            initial = initial.Replace(match.Value, replacement);
        }

        count++;
    }

    return initial.Replace(" ", "").Replace("\"", "");
}
