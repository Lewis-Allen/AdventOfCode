using System;
using Xunit;

namespace Day01.Tests
{
    public class FloorCalculatorTests
    {
        [Theory]
        [InlineData("(())", 0)]
        [InlineData("()()", 0)]
        [InlineData("(((", 3)]
        [InlineData("(()(()(", 3)]
        [InlineData("))(((((", 3)]
        [InlineData("())", -1)]
        [InlineData("))(", -1)]
        [InlineData(")))", -3)]
        [InlineData(")())())", -3)]
        public void ShouldCalculateCorrectFloor(string instructions, int expected)
        {
            int result = FloorCalculator.CalculateFloor(instructions);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(")", 1)]
        [InlineData("()())", 5)]
        public void ShouldFindBasementEntryPosition(string instructions, int expected)
        {
            int result = FloorCalculator.FindBasementEntryPosition(instructions);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldThrowNoBasementEntryException()
        {
            Assert.Throws<Exception>(() => FloorCalculator.FindBasementEntryPosition("(((("));
        }
    }
}
