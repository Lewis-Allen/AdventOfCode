using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var lines = File.ReadAllText("../../../Input2.txt").Split("\r\n\r\n");

var rules = lines[0].Split("\r\n");
var messages = lines[1].Split("\r\n");

rules = rules.OrderBy(r => int.Parse(Regex.Match(r, "\\d+").Value)).ToArray();

string regexString = " " + Regex.Match(rules[0], "(?<=(: )).*").Value + " ";

while(Regex.IsMatch(regexString, "\\d+"))
{
    foreach(var match in Regex.Matches(regexString, "[^\\d]\\d+[^\\d]").ToList())
    {
        var ruleNo = int.Parse(match.Value);
        var index = rules.ToList().FindIndex(s => Regex.IsMatch(s, $"^{ruleNo}:"));

        var replacement = " ( " + Regex.Match(rules[index], "(?<=(: )).*").Value + " ) ";

        regexString = regexString.Replace(match.Value, replacement);
    }
    Console.WriteLine(regexString);
}

regexString = regexString.Replace(" ", "").Replace("\"", "");

var count = messages.Count(m =>
{
    return Regex.IsMatch(m, regexString) &&
           Regex.Match(m, regexString).Value.Length == m.Length;
});

// Part One
Console.WriteLine($"Part One Matching Rules = {count}.");