using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var lines = File.ReadAllLines("../../../Example2.txt");

PartOne(lines);

PartTwo(lines);

static void PartOne(string[] lines)
{
    long[] memory = new long[100000];
    string currentMask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

    foreach(var line in lines)
    {
        var nums = Regex.Matches(line, "[\\dX]+");

        if(nums.Count > 1)
        {
            long index = long.Parse(nums[0].Value);
            long value = long.Parse(nums[1].Value);

            for (var i = 0; i < currentMask.Length; i++)
            {
                char letter = currentMask[currentMask.Length - 1 - i];

                if(letter == '1')
                    value |= 1L << i;

                if(letter == '0')
                    value &= ~(1L << i);
            }
            memory[index] = value;
        }
        else
        {
            // Set the mask
            currentMask = nums[0].Value;
        }
    }

    Console.WriteLine($"The sum of all values in memory is {memory.Sum()}.");
}

static void PartTwo(string[] lines)
{
    long[] memory = new long[100000];
    string currentMask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

    foreach (var line in lines)
    {
        var nums = Regex.Matches(line, "[\\dX]+");

        if (nums.Count > 1)
        {
            long index = long.Parse(nums[0].Value);
            long value = long.Parse(nums[1].Value);

            for (var i = 0; i < currentMask.Length; i++)
            {
                char letter = currentMask[currentMask.Length - 1 - i];

                if (letter == '1')
                    value |= 1L << i;

                if (letter == '0')
                    value &= ~(1L << i);

                if (letter == 'X')
                {

                }
            }
            memory[index] = value;
        }
        else
        {
            // Set the mask
            currentMask = nums[0].Value;
        }
    }

    Console.WriteLine($"The sum of all values in memory is {memory.Sum()}.");
}