using Xunit;

namespace Day17.Tests
{
    public class VelocityCalculatorTests
    {
        [Fact]
        public void Should_Get_Highest_Point()
        {
            var target = new Instruction(20, 30, -10, -5);

            var result = VelocityCalculator.GetHighestPoint(target);

            Assert.Equal(45, result);
        }

        [Fact]
        public void Should_Get_Distinct_Velocities()
        {
            var target = new Instruction(20, 30, -10, -5);

            var result = VelocityCalculator.GetDistinctVelocities(target);

            Assert.Equal(112, result);
        }
    }
}