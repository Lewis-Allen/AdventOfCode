using System;
using System.Linq;
using Xunit;

namespace Day09.Tests
{
    public class DistanceCalculatorTests
    {
        [Theory]
        [InlineData("Dublin", "Belfast", 982)]
        [InlineData("London", "Belfast", 605)]
        [InlineData("London", "Dublin", 659)]
        [InlineData("Dublin", "London", 659)]
        [InlineData("Belfast", "London", 605)]
        [InlineData("Belfast", "Dublin", 982)]
        public void Should_Return_Shortest_Distance_Between_Two_Cities_VIsiting_All(string cityOne, string cityTwo, int expected)
        {
            var distances = @"London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141".Split("\r\n");

            var distanceCalculator = new DistanceCalculator(distances);

            var result = distanceCalculator.GetShortestDistance(cityOne, cityTwo);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_Return_Shortest_Distance_Of_All()
        {
            var distances = @"London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141".Split("\r\n");

            var distanceCalculator = new DistanceCalculator(distances);

            var result = distanceCalculator.CalculateAllShortestDistances().Values.Min();

            Assert.Equal(605, result);
        }

        [Fact]
        public void Should_Return_Longest_Distance_Of_All()
        {
            var distances = @"London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141".Split("\r\n");

            var distanceCalculator = new DistanceCalculator(distances);

            var result = distanceCalculator.CalculateAllLongestDistances().Values.Max();

            Assert.Equal(982, result);
        }
    }
}
