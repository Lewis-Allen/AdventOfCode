using Xunit;

namespace Day04.Tests;

public class ElfTests
{
    [Theory]
    [InlineData("2-4,6-8", 2,4,6,8)]
    [InlineData("2-3,4-5", 2,3,4,5)]
    [InlineData("5-7,7-9", 5,7,7,9)]
    [InlineData("2-8,3-7", 2,8,3,7)]
    [InlineData("6-6,4-6", 6,6,4,6)]
    [InlineData("2-6,4-8", 2,6,4,8)]
    public void Should_Parse_Elf_From_String(string input, int lowerA, int upperA, int lowerB, int upperB)
    {
        var exp = new ElfPair(lowerA, upperA, lowerB, upperB);
        var res = ElfPair.FromString(input);

        Assert.Equal(exp, res);
    }

    [Theory]
    [InlineData(2, 4, 6, 8, false)]
    [InlineData(2, 3, 4, 5, false)]
    [InlineData(5, 7, 7, 9, false)]
    [InlineData(2, 8, 3, 7, true)]
    [InlineData(6, 6, 4, 6, true)]
    [InlineData(2, 6, 4, 8, false)]
    public void Should_Return_Correct_Overlap_Fully_Result(int lowerA, int upperA, int lowerB, int upperB, bool overlaps)
    {
        var elfPair = new ElfPair(lowerA, upperA, lowerB, upperB);

        var res = ElfPair.OverlapsFully(elfPair);

        Assert.Equal(overlaps, res);
    }

    [Theory]
    [InlineData(2, 4, 6, 8, false)]
    [InlineData(2, 3, 4, 5, false)]
    [InlineData(5, 7, 7, 9, true)]
    [InlineData(2, 8, 3, 7, true)]
    [InlineData(6, 6, 4, 6, true)]
    [InlineData(2, 6, 4, 8, true)]
    public void Should_Return_Correct_Overlap_Result(int lowerA, int upperA, int lowerB, int upperB, bool overlaps)
    {
        var elfPair = new ElfPair(lowerA, upperA, lowerB, upperB);

        var res = ElfPair.Overlaps(elfPair);

        Assert.Equal(overlaps, res);
    }
}