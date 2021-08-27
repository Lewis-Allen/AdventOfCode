using Day10;
using System;

var input = "1113222113";

// Part One
for(int i = 0; i < 40; i++)
{
    input = LookAndSayGenerator.Generate(input);
}
Console.WriteLine($"LookAndSay applied 40 times to 1113222113 results in an output of length {input.Length}.");

// Part Two
for (int i = 0; i < 10; i++)
{
    input = LookAndSayGenerator.Generate(input);
}
Console.WriteLine($"LookAndSay applied 50 times to 1113222113 results in an output of length {input.Length}.");

