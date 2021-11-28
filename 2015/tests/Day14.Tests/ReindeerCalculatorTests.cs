using Xunit;

namespace Day14.Tests;

public class ReindeerCalculatorTests
{
    [Theory]
    [InlineData("Rudolph can fly 22 km/s for 8 seconds, but then must rest for 165 seconds.", "Rudolph", 22, 8, 165)]
    [InlineData("Cupid can fly 8 km/s for 17 seconds, but then must rest for 114 seconds.", "Cupid", 8, 17, 114)]
    [InlineData("Prancer can fly 18 km/s for 6 seconds, but then must rest for 103 seconds.", "Prancer", 18, 6, 103)]
    public void ParseLine_Should_Return_A_Reindeer_Object(string line, string expectedName, int expectedSpeed, int expectedStamina, int expectedRestTime)
    {
        Reindeer expected = new(expectedName, expectedSpeed, expectedStamina, expectedRestTime);

        var result = ReindeerCalculator.ParseLine(line);

        Assert.Equal(result, expected);
    }

    [Theory]
    [InlineData(1, "Comet", 14, 10, 127, 0, "Dancer", 16, 11, 162, 1)]
    [InlineData(140, "Comet", 14, 10, 127, 1, "Dancer", 16, 11, 162, 139)]
    [InlineData(1000, "Comet", 14, 10, 127, 312, "Dancer", 16, 11, 162, 689)]
    public void Should_Return_Amount_Of_Points_Held_By_Winning_Reindeer_At_N_Seconds(int seconds, string name1, int speed1, int stamina1, int restTime1, int points1, string name2, int speed2, int stamina2, int restTime2, int points2)
    {
        Reindeer reindeer1 = new(name1, speed1, stamina1, restTime1);
        Reindeer reindeer2 = new(name2, speed2, stamina2, restTime2);

        ReindeerCalculator.PerformRace(new[] { reindeer1, reindeer2 }, seconds);

        Assert.Equal(points1, reindeer1.Points);
        Assert.Equal(points2, reindeer2.Points);
    }
}
