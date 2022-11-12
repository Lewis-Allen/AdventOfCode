using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Day17.Tests
{
    public class InstructionTests
    {
        [Theory]
        [InlineData("target area: x=20..30, y=-10..-5", 20, 30, -10, -5)]
        [InlineData("target area: x=248..285, y=-85..-56", 248, 285, -85, -56)]
        public void Should_Parse_Instruction_String(string input, int fromX, int toX, int fromY, int toY)
        {
            var expected = new Instruction(fromX, toX, fromY, toY);

            var result = Instruction.FromString(input);

            Assert.Equal(expected, result);
        }
    }
}
