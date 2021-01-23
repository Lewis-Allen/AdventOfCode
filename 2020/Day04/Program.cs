using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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

Console.WriteLine(passports.Count(s => IsValidPassport(s)));

static bool IsValidPassport(Passport passport) => int.TryParse(passport.BirthYear, out int birthYear) && birthYear >= 1920 && birthYear <= 2002 &&
                                                  int.TryParse(passport.IssueYear, out int issueYear) && issueYear >= 2010 && issueYear <= 2020 &&
                                                  int.TryParse(passport.ExpirationYear, out int expirationYear) && expirationYear >= 2020 && expirationYear <= 2030 &&
                                                  Regex.IsMatch(passport.Height ?? "", "(1(([5-8][0-9])|(9[0-3]))cm)|(((59)|(6[0-9])|(7[0-6]))in)") &&
                                                  Regex.IsMatch(passport.HairColour ?? "", "#[\\da-f]{6}") &&
                                                  Regex.IsMatch(passport.EyeColour ?? "", "amb|blu|brn|gry|grn|hzl|oth") &&
                                                  Regex.IsMatch(passport.PassportID ?? "", "^[\\d]{9}$");

class Passport
{
    public string BirthYear { get; set; }
    public string IssueYear { get; set; }
    public string ExpirationYear { get; set; }
    public string Height { get; set; }
    public string HairColour { get; set; }
    public string EyeColour { get; set; }
    public string PassportID { get; set; }
    public string CountryID { get; set; }
}

