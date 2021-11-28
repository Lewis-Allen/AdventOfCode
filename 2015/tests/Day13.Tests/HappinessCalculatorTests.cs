using System.Collections.Generic;
using Xunit;

namespace Day13.Tests
{
    public class HappinessCalculatorTests
    {
        [Theory]
        [InlineData("Alice would lose 2 happiness units by sitting next to David.", "Alice", "David", -2)]
        [InlineData("Bob would gain 83 happiness units by sitting next to Alice.", "Bob", "Alice", 83)]
        public void ParseLine_Should_Return_Tuple_With_Seating_Arrangement(string line, string expectedPerson, string expectedNextTo, int expectedHappiness)
        {
            ((string person, string nextTo), int happiness) seatingArrangement = HappinessCalculator.ParseLine(line);

            Assert.Equal(((expectedPerson, expectedNextTo), expectedHappiness), seatingArrangement);
        }

        [Fact]
        public void ParseLine_Should_Throw_Argument_Exception()
        {
            string input = "This is a string that is not in a valid format.";

            Assert.Throws<ArgumentException>(() => HappinessCalculator.ParseLine(input));
        }

        [Fact]
        public void Should_Find_Optimal_Seating_Happiness()
        {
            var seatingArrangements = new Dictionary<(string, string), int>
            {
                { ("Alice", "Bob"), 54 },
                { ("Alice", "Carol"), -79 },
                { ("Alice", "David"), -2 },
                { ("Bob", "Alice"), 83 },
                { ("Bob", "Carol"), -7 },
                { ("Bob", "David"), -63 },
                { ("Carol", "Alice"), -62 },
                { ("Carol", "Bob"), 60 },
                { ("Carol", "David"), 55 },
                { ("David", "Alice"), 46 },
                { ("David", "Bob"), -7 },
                { ("David", "Carol"), 41 }
            };

            var optimalHappiness = HappinessCalculator.FindHappinessFromOptimalSeating(seatingArrangements);

            Assert.Equal(330, optimalHappiness);
        }
    }
}