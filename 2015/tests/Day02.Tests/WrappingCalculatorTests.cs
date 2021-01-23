using System;
using Xunit;

namespace Day02.Tests
{
    public class WrappingCalculatorTests
    {
        [Theory]
        [InlineData(2,3,4,58)]
        [InlineData(1,1,10,43)]
        public void ShouldFindRequiredPaper(int length, int width, int height, int expected)
        {
            var result = WrappingCalculator.GetRequiredWrappingPaper(length, width, height);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2,3,4,34)]
        [InlineData(1,1,10,14)]
        [InlineData(5,5,2,64)]
        public void ShouldFindRequiredRibbon(int length, int width, int height, int expected)
        {
            var result = WrappingCalculator.GetRequiredRibbon(length, width, height);
            Assert.Equal(expected, result);
        }
    }
}
