using System;
using Xunit;

namespace Day03.Tests
{
    public class ManhattanCalculatorTests
    {
        [Theory]
        [InlineData(1,2,3,4,4)]
        [InlineData(-4,6,3,-4,17)]
        public void Should_Be_Correct_Manhattan_Distance(int fromX, int fromY, int toX, int toY, int expected)
        {
            int result = ManhattanCalculator.GetManhattanDistance(fromX, fromY, toX, toY);

            Assert.Equal(expected, result);
        }
    }
}
