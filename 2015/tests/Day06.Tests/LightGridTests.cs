using System;
using System.Linq;
using Xunit;

namespace Day06.Tests
{
    public class LightGridTests
    {
        [Fact]
        public void ShouldSwitchOffLights()
        {
            LightGridWithoutBrightness lights = new(new bool[][] {
                new bool[] { true, false, true }, 
                new bool[] { false, true, false }, 
                new bool[] { true, false, true } 
            });

            bool[][] expected = new bool[][] { 
                new bool[] { false, false, false }, 
                new bool[] { false, false, false }, 
                new bool[] { false, false, false } 
            };

            var result = lights.PerformOperation(Instruction.SWITCH_OFF, 0, 0, 2, 2);

            for(var i = 0; i < lights.Lights.Length; i++)
            {
                Assert.True(Enumerable.SequenceEqual(expected[i], result[i]));
            }
        }

        [Fact]
        public void ShouldSwitchOnLights()
        {
            LightGridWithoutBrightness lights = new(new bool[][] {
                new bool[] { true, false, true },
                new bool[] { false, true, false },
                new bool[] { true, false, true }
            });

            bool[][] expected = new bool[][] {
                new bool[] { true, true, true },
                new bool[] { true, true, true },
                new bool[] { true, true, true }
            };

            var result = lights.PerformOperation(Instruction.SWITCH_ON, 0, 0, 2, 2);

            for (var i = 0; i < lights.Lights.Length; i++)
            {
                Assert.True(Enumerable.SequenceEqual(expected[i], result[i]));
            }
        }

        [Fact]
        public void ShouldToggleLights()
        {
            LightGridWithoutBrightness lights = new(new bool[][] {
                new bool[] { true, false, true },
                new bool[] { false, true, false },
                new bool[] { true, false, true }
            });

            bool[][] expected = new bool[][] {
                new bool[] { false, true, false },
                new bool[] { true, false, true },
                new bool[] { false, true, false }
            };

            var result = lights.PerformOperation(Instruction.TOGGLE, 0, 0, 2, 2);

            for (var i = 0; i < lights.Lights.Length; i++)
            {
                Assert.True(Enumerable.SequenceEqual(expected[i], result[i]));
            }
        }

        [Theory]
        [InlineData("turn off 341,304 through 638,850", Instruction.SWITCH_OFF, 341, 304, 638, 850)]
        [InlineData("turn off 199, 133 through 461, 193", Instruction.SWITCH_OFF, 199, 133, 461, 193)]
        [InlineData("toggle 322, 558 through 977, 958", Instruction.TOGGLE, 322, 558, 977, 958)]
        [InlineData("toggle 537, 781 through 687, 941", Instruction.TOGGLE, 537, 781, 687, 941)]
        [InlineData("turn on 226, 196 through 599, 390", Instruction.SWITCH_ON, 226, 196, 599, 390)]
        [InlineData("turn on 240, 129 through 703, 297", Instruction.SWITCH_ON, 240, 129, 703, 297)]
        public void ShouldReturnValidInstruction(string input, Instruction instruction, int fromX, int fromY, int toX, int toY)
        {
            var expected = (instruction, fromX, fromY, toX, toY);
            var result = LightGridWithoutBrightness.ParseInstruction(input);
            Assert.Equal(expected, result);
        }
    }
}
