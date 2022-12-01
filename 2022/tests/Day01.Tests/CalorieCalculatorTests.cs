using Xunit;

namespace Day01.Tests;

public class CalorieCalculatorTests
{

    private readonly string[] data = new string[] { "1000", "2000", "3000", "", "4000", "", "5000", "6000", "", "7000", "8000", "9000", "", "10000" };

    [Fact]
    public void Should_Return_Highest_Calories()
    {
        var result = CalorieCalculator.GetMaxCalories(data);

        Assert.Equal(24000, result);
    }

    [Fact]
    public void Should_Get_Total_Of_Top_Three()
    {
        var result = CalorieCalculator.GetTotalOfTopThree(data);

        Assert.Equal(45000, result);
    }
}