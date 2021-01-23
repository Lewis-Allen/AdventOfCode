using System;
using Xunit;

namespace Day03.Tests
{
    public class TransversalCalculatorTests
    {
        [Theory]
        [InlineData(">", 2)]
        [InlineData("^>v<", 4)]
        [InlineData("^v^v^v^v^v", 2)]
        public void ShouldReturnNumberOfHousesVisited(string directions, int expected)
        {
            var result = TransversalCalculator.FindNoOfHousesVisited(directions);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("^v", 3)]
        [InlineData("^>v<", 3)]
        [InlineData("^v^v^v^v^v", 11)]
        public void ShouldReturnNumberOfHousesVisitedWithRoboSantaHelp(string directions, int expected)
        {
            var result = TransversalCalculator.FindNoOfHousesVisitedWithRoboSanta(directions);
            Assert.Equal(expected, result);
        }
    }
}
