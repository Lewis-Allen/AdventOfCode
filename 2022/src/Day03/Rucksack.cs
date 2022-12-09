using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Day03;

public record Rucksack(char[] CompartmentA, char[] CompartmentB)
{
    public static Rucksack FromString(string input)
    {
        var compartments = input.Chunk(input.Length / 2);

        return new Rucksack(compartments.ToArray()[0], compartments.ToArray()[1]);
    }

    public static int GetRucksackPriority(Rucksack rucksack) =>
        rucksack.CompartmentA.Intersect(rucksack.CompartmentB)
            .Sum(GetPriority);

    public static int GetPriority(char c) => char.IsUpper(c) ? c - 38 : c - 96;

    public static int GetGroupPriority(Rucksack[] rucksacks)
    {
        var first = rucksacks.First();
        char[] acc = first.CompartmentA.Concat(first.CompartmentB).ToArray();

        for (int i = 1; i < rucksacks.Length; i++)
        {
            acc = acc.Intersect(new string(rucksacks[i].CompartmentA) + new string(rucksacks[i].CompartmentB)).ToArray();

        }

        return acc.Sum(GetPriority);
    }
}
