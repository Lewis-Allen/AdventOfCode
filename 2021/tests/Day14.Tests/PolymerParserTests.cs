using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Day14.Tests;

public class PolymerParserTests
{
    [Fact]
    public void Should_Parse_Lines_Into_Polymers()
    {
        var lines = new string[]
        {
            "CH -> B",
            "HH -> N",
            "CB -> H",
            "NH -> C",
            "HB -> C",
            "HC -> B",
            "HN -> C",
            "NN -> C",
            "BH -> H",
            "NC -> B",
            "NB -> B",
            "BN -> B",
            "BB -> N",
            "BC -> B",
            "CC -> N",
            "CN -> C"
        };

        var result = PolymerParser.ParseLines(lines);

        var expected = new Dictionary<string, char>()
        {
            { "CH", 'B' },
            { "HH", 'N' },
            { "CB", 'H' },
            { "NH", 'C' },
            { "HB", 'C' },
            { "HC", 'B' },
            { "HN", 'C' },
            { "NN", 'C' },
            { "BH", 'H' },
            { "NC", 'B' },
            { "NB", 'B' },
            { "BN", 'B' },
            { "BB", 'N' },
            { "BC", 'B' },
            { "CC", 'N' },
            { "CN", 'C' }
        };

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Should_Get_Correct_Key_Count()
    {
        var lookup = new Dictionary<string, char>()
        {
            { "CH", 'B' },
            { "HH", 'N' },
            { "CB", 'H' },
            { "NH", 'C' },
            { "HB", 'C' },
            { "HC", 'B' },
            { "HN", 'C' },
            { "NN", 'C' },
            { "BH", 'H' },
            { "NC", 'B' },
            { "NB", 'B' },
            { "BN", 'B' },
            { "BB", 'N' },
            { "BC", 'B' },
            { "CC", 'N' },
            { "CN", 'C' }
        };

        // "NNCB";
        Dictionary<string, long> pairCounts = new()
        {
            { "NN", 1 },
            { "NC", 1 },
            { "CB", 1 }
        };

        Dictionary<char, long> keyCounts = new()
        {
            { 'N', 2 },
            { 'C', 1 },
            { 'B', 1 }
        };

        var polymer = new PairResult(pairCounts, keyCounts);

        for (int i = 0; i < 10; i++)
        {
            polymer = PolymerParser.Step(polymer, lookup);
        }

        var result = polymer.KeyCounts.Values.Max() - polymer.KeyCounts.Values.Min();

        Assert.Equal(1588, result);

    }
}
