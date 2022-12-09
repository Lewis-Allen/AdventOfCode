using Xunit;

namespace Day03.Tests;

public class RucksackTests
{
    [Fact]
    public void Should_Return_Rucksack_Object()
    {
        var exp1 = new Rucksack("vJrwpWtwJgWr".ToCharArray(), "hcsFMMfFFhFp".ToCharArray());
        var res1 = Rucksack.FromString("vJrwpWtwJgWrhcsFMMfFFhFp");

        Assert.Equal(new string(exp1.CompartmentA), new string(res1.CompartmentA));
        Assert.Equal(new string(exp1.CompartmentB), new string(res1.CompartmentB));
    }

    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 16)]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 38)]
    [InlineData("PmmdzqPrVvPwwTWBwg", 42)]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 22)]
    [InlineData("ttgJtRGJQctTZtZT", 20)]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", 19)]
    public void Should_Return_Correct_Priority(string contents, int expectedPriority)
    {
        var rucksack = Rucksack.FromString(contents);

        Assert.Equal(expectedPriority, Rucksack.GetRucksackPriority(rucksack));
    }

    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg", 18)]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw", 52)]
    public void Should_Return_Correct_Group_Priority(string A, string B, string C, int expectedPriority)
    {
        var rucksacks = new Rucksack[] {
            Rucksack.FromString(A),
            Rucksack.FromString(B),
            Rucksack.FromString(C)
        };

        Assert.Equal(expectedPriority, Rucksack.GetGroupPriority(rucksacks));
    }
}