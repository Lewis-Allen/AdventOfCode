using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

// Part One
var lines = File.ReadAllText("../../../Input.txt").Split("\r\n\r\n");

var rules = lines[0].Split("\r\n").OrderBy(r => int.Parse(Regex.Match(r, "\\d+").Value)).ToArray();
var messages = lines[1].Split("\r\n");

var index = rules.ToList().FindIndex(s => Regex.IsMatch(s, $"^0:"));
var regexString = RegexString(" " + Regex.Match(rules[index], "(?<=(: )).*").Value + " ", rules);

var count = messages.Count(m =>
{
    return Regex.IsMatch(m, regexString) &&
           Regex.Match(m, regexString).Value.Length == m.Length;
});

Console.WriteLine($"Part One Matching Rules = {count}.");

/*  Part Two - This really isn't a proper solution to be honest.
 *  
 *  The rule "8: 42 | 42 8" is recursive but can be interpreted as "one or more occurences of rule 42".
 *  
 *  Instead of accounting for the recursive regex properly, I removed the recursion and increased the number
 *  of occurences of the rule that was being recursed.
 *
 *  e.g. 42 | 42 8 becomes 42 | 42 42 | 42 42 42 | 42 42 42 42 | 42 42 42 42 42 etc..
 *  
 *  I kept increasing the depth until the solution output stopped changing and all messages were covered.
 *  
 *  The above can be applied for rule 11 also.
 *
 *  This let me use the same string replace algorithm I used for the first solution.
 */
lines = File.ReadAllText("../../../Input2.txt").Split("\r\n\r\n");

rules = lines[0].Split("\r\n").OrderBy(r => int.Parse(Regex.Match(r, "\\d+").Value)).ToArray(); ;
messages = lines[1].Split("\r\n");

index = rules.ToList().FindIndex(s => Regex.IsMatch(s, $"^0:"));
regexString = RegexString(" " + Regex.Match(rules[index], "(?<=(: )).*").Value + " ", rules);

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
