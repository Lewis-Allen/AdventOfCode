using Day04;
using System;

var input = "264793-803935";

string[] bounds = input.Split("-");

int lowerBound = int.Parse(bounds[0]);
int upperBound = int.Parse(bounds[1]);

int validPasswords = 0;
for(var i = lowerBound; i <= upperBound; i++)
{
    if (PasswordValidator.ValidatePasswordPartOne(i.ToString()))
        validPasswords++;
}

Console.WriteLine($"The number of valid passwords for part one is {validPasswords}");

// Part Two
validPasswords = 0;
for (var i = lowerBound; i <= upperBound; i++)
{
    if (PasswordValidator.ValidatePasswordPartTwo(i.ToString()))
        validPasswords++;
}

Console.WriteLine($"The number of valid passwords for part two is {validPasswords}");
