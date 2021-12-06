using Xunit;

namespace Day06.Tests
{
    public class LanternfishCalculatorTests
    {
        [Theory]
        [InlineData(18, 26)]
        [InlineData(80, 5934)]
        [InlineData(256, 26984457539)]
        
        public void Should_Get_Number_Of_Fish_After_X_Days(int days, long expected)
        {
            int[] state = new int[] { 3, 4, 3, 1, 2 };

            var result = LanternfishCalculator.GetFishCountAfterXDays(state, days);

            Assert.Equal(expected, result);
        }
    }
}