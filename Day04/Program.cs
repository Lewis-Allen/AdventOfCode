using Day04;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../input.txt");

Passport passport = new();
List<Passport> passports = new()
{
    passport
};

foreach(var line in lines)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        passport = new Passport();
        passports.Add(passport);
    }
    else
    {
        foreach (var lineEntry in line.Split(" "))
        {
            var entry = lineEntry.Split(":");
            var entryName = entry[0];
            var entryValue = entry[1];

            switch (entryName)
            {
                case "byr": passport.BirthYear = entryValue; break;
                case "iyr": passport.IssueYear = entryValue; break;
                case "eyr": passport.ExpirationYear = entryValue; break;
                case "hgt": passport.Height = entryValue; break;
                case "hcl": passport.HairColour = entryValue; break;
                case "ecl": passport.EyeColour = entryValue; break;
                case "pid": passport.PassportID = entryValue; break;
                case "cid": passport.CountryID = entryValue; break;
            }
        }
    }
}

Console.WriteLine(passports.Count(s => s.IsValid()));


