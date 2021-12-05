using Xunit;

namespace Day05.Tests;

public class CloudCalculatorTests
{
    [Fact]
    public void Should_Get_Number_Of_Intersections_No_Diagonals()
    {
        var clouds = new Cloud[] {
            new(0,9,5,9),
            new(8,0,0,8),
            new(9,4,3,4),
            new(2,2,2,1),
            new(7,0,7,4),
            new(6,4,2,0),
            new(0,9,2,9),
            new(3,4,1,4),
            new(0,0,8,8),
            new(5,5,8,2)
        };

        var result = CloudCalculator.GetNumberOfIntersectionsNoDiagonals(clouds);

        Assert.Equal(5, result);
    }

    [Fact]
    public void Should_Get_Number_Of_Intersections()
    {
        var clouds = new Cloud[] {
            new(0,9,5,9),
            new(8,0,0,8),
            new(9,4,3,4),
            new(2,2,2,1),
            new(7,0,7,4),
            new(6,4,2,0),
            new(0,9,2,9),
            new(3,4,1,4),
            new(0,0,8,8),
            new(5,5,8,2)
        };

        var result = CloudCalculator.GetNumberOfIntersections(clouds);

        Assert.Equal(12, result);
    }
}
