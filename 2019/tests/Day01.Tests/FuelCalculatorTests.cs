using System;
using Xunit;
using Day01;

namespace Day01.Tests
{
    public class FuelCalculatorTests
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void Should_Calculate_Correct_Fuel_From_Mass_Part_One(int mass, int result)
        {
            var output = FuelCalculator.CalculateFuelPartOne(mass);
            Assert.Equal(result, output);
        }

        [Theory]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void Should_Calculate_Correct_Fuel_From_Mass_Part_Two(int mass, int result)
        {
            var output = FuelCalculator.CalculateFuelPartTwo(mass);
            Assert.Equal(result, output);
        }
    }
}
