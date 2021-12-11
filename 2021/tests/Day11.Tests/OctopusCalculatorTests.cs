using System.Linq;
using Xunit;

namespace Day11.Tests
{
    public class OctopusCalculatorTests
    {
        [Fact]
        public void Should_Return_Charges_After_Steps()
        {
            var lines = new string[]
            {
                "5483143223",
                "2745854711",
                "5264556173",
                "6141336146",
                "6357385478",
                "4167524645",
                "2176841721",
                "6882881134",
                "4846848554",
                "5283751526"
            };

            var octopuses = lines
                .SelectMany((l, y) => l.Select((o, x) => new Octopus(x, y, o - '0')))
                .ToArray();

            var result = OctopusCalculator.GetFlashesAfterXSteps(octopuses, 100);

            Assert.Equal(1656, result);
        }

        [Fact]
        public void Should_Return_Step_Of_Synchronising_Flash()
        {
            var lines = new string[]
            {
                "5483143223",
                "2745854711",
                "5264556173",
                "6141336146",
                "6357385478",
                "4167524645",
                "2176841721",
                "6882881134",
                "4846848554",
                "5283751526"
            };

            var octopuses = lines
                .SelectMany((l, y) => l.Select((o, x) => new Octopus(x, y, o - '0')))
                .ToArray();

            var result = OctopusCalculator.GetSynchronisingFlashStep(octopuses);

            Assert.Equal(195, result);
        }
    }
}