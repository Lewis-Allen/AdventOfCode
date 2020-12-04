using Day04;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var log = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Logger = log;

var lines = File.ReadAllLines("../../../input.txt");

Document passport = new();
List<Document> passports = new()
{
    passport
};

// Parse file
foreach(var line in lines)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        passport = new Document();
        passports.Add(passport);
    }
    else
    {
        foreach (var lineEntry in line.Split(" "))
        {
            var entry = lineEntry.Split(":");
            ParseEntry(passport, entry[0], entry[1]);
        }
    }
}

Console.WriteLine(passports.Count(s => s.IsValid()));

static void ParseEntry(Document document, string entryName, string entryValue)
{
    if (entryName == "byr") document.BirthYear = entryValue;
    if (entryName == "iyr") document.IssueYear = entryValue;
    if (entryName == "eyr") document.ExpirationYear = entryValue;
    if (entryName == "hgt") document.Height = entryValue;
    if (entryName == "hcl") document.HairColour = entryValue;
    if (entryName == "ecl") document.EyeColour = entryValue;
    if (entryName == "pid") document.PassportID = entryValue;
    if (entryName == "cid") document.CountryID = entryValue;
}


