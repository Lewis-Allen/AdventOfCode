using System;
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
            char[] index = Convert.ToString(long.Parse(nums[0].Value), 2).PadLeft(36, '0').ToCharArray();
            long value = long.Parse(nums[1].Value);

            // 1. Deal with masking the 0s and 1s.
            for (var i = 0; i < currentMask.Length; i++)
            {
                char letter = currentMask[i];

                if (letter != '0')
                    index[i] = letter;
            }

            // 2. Create a list of stacks, each with a unique combination of 0s and 1s.
            //    These will be used to replace X with.
            int Xs = index.Count(c => c == 'X');
            double upper = Math.Pow(2, Xs);
            List<Stack<bool>> stacks = new();

            for(long i = 0; i < upper; i++)
            {
                var list = Convert.ToString(i, 2).PadLeft((int)upper, '0').Select(s => s == '1').ToList();
                Stack<bool> stack = new(list);
                stacks.Add(stack);
            }

            // 3. Iterate through the stacks, replacing the Xs with a unique combination each time.
            //    Each unique combination is saved to memory with the value for the line.
            foreach (var s in stacks)
            {
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