using Day11;
using System;

var input = "hxbxwxba";

// Part One
var result = PasswordGenerator.FindNextPassword(input);
Console.WriteLine($"The next password from {input} is {result}");

// Part Two
input = result;
result = PasswordGenerator.FindNextPassword(input);
Console.WriteLine($"The next password from {input} is {result}");
