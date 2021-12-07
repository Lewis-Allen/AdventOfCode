using Xunit;

namespace Day07.Tests
{
    public class CrabAlignerTests
    {
        [Fact]
        public void Should_Get_Lowest_Fuel_Required_To_Align()
        {
            var input = new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

            var result = CrabAligner.GetFuelRequiredToAlign(input);

            Assert.Equal(37, result);
        }

        [Fact]
        public void Should_Get_Lowest_Fuel_Required_To_Align_With_Increasing_Cost()
        {
            var input = new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

            var result = CrabAligner.GetFuelRequiredToAlignWithIncreasingCost(input);

            Assert.Equal(168, result);
        }
    }
}