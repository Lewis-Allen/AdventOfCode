using Xunit;

namespace Day02.Tests
{
    public class PositionCalculatorTests
    {
        [Fact]
        public void Should_Get_Correct_DepthPosition()
        {
            string[] instructions = new string[] {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2",
            };

            var result = PositionCalculator.GetFinalDepthByFinalPosition(instructions);

            Assert.Equal(150, result);
        }

        [Fact]
        public void Should_Get_Correct_DepthPosition_With_Aim()
        {
            string[] instructions = new string[] {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2",
            };

            var result = PositionCalculator.GetFinalDepthByFinalPositionWithAim(instructions);

            Assert.Equal(900, result);
        }
    }
}