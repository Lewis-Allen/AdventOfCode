using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var lines = File.ReadAllLines("../../../Input.txt");

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
    Dictionary<string, long> memory = new();
    string currentMask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

    foreach (var line in lines)
    {
        var nums = Regex.Matches(line, "[\\dX]+");

        if (nums.Count > 1)
        {
            char[] index = Convert.ToString(long.Parse(nums[0].Value), 2).PadLeft(36,'0').ToCharArray();

            long value = long.Parse(nums[1].Value);

            for (var i = 0; i < currentMask.Length; i++)
            {
                char letter = currentMask[currentMask.Length - 1 - i];

                if (letter != '0')
                    index[currentMask.Length - 1 - i] = letter;
            }

            int Xs = index.Count(c => c == 'X');
            double upper = Math.Pow(2, Xs);
            List<Stack<bool>> stacks = new();

            for(long i = 0; i < upper; i++)
            {
                var list = Convert.ToString(i, 2).PadLeft((int)upper, '0').Select(s => s == '1').ToList();
                Stack<bool> stack = new(list);
                stacks.Add(stack);
            }

            int total = 0;
            foreach (var s in stacks)
            {
                total++;
                var indexCopy = new string(index).ToCharArray();
                for(int i = 0; i < indexCopy.Length; i++)
                {
                    if(indexCopy[indexCopy.Length - 1 - i] == 'X')
                    {
                        indexCopy[indexCopy.Length - 1 - i] = s.Pop() ? '1' : '0';
                    }
                }

                memory[new string(indexCopy)] = value;
            }
        }
        else
        {
            // Set the mask
            currentMask = nums[0].Value;
        }
    }

    Console.WriteLine($"The sum of all values in memory is {memory.Values.Sum()}.");
}