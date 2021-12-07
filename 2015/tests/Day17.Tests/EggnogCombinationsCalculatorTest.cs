using System.Collections.Generic;
using Xunit;

namespace Day17.Tests
{
    public class EggnogCombinationsCalculatorTest
    {
        [Fact]
        public void Should_Return_Number_Of_Possible_Combinations()
        {
            int litres = 25;
            List<Container> containers = new() { new(0,20), new(1,15), new(2,10), new(3,5), new(4,5) };

            var result = EggnogCombinationsFinder.GetNoOfCombinations(containers, litres);

            Assert.Equal(4, result);
        }

        [Fact]
        public void Should_Return_Number_Of_Minimum_Combinations()
        {
            var litres = 25;
            List<Container> containers = new() { new(0, 20), new(1, 15), new(2, 10), new(3, 5), new(4, 5) };

            var result = EggnogCombinationsFinder.GetNoOfMinimumCombinations(containers, litres);

            Assert.Equal(3, result);
        }
    }
}