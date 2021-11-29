using System;
using Xunit;

namespace Day15.Tests;

public class IngredientTests
{
    [Theory]
    [InlineData("Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8", "Butterscotch", -1, -2, 6, 3, 8)]
    [InlineData("Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3", "Cinnamon", 2, 3, -2, -1, 3)]
    public void Should_Parse_Ingredient_From_Line(string line, string expectedName, int expectedCapacity, int expectedDurability, int expectedFlavour, int expectedTexture, int expectedCalories)
    {
        Ingredient expected = new(expectedName, expectedCapacity, expectedDurability, expectedFlavour, expectedTexture, expectedCalories);

        var result = Ingredient.FromString(line);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Should_Throw_Argument_Exception()
    {
        string line = "This is a line that should not parse correctly as an ingredient.";

        Assert.Throws<ArgumentException>(() => Ingredient.FromString(line));
    }
}
