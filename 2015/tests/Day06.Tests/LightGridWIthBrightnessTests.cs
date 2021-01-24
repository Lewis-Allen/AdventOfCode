using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Day06.Tests
{
    public class LightGridWIthBrightnessTests
    {
        [Fact]
        public void ShouldDecreaseLightBrightness()
        {
            LightGridWithBrightness lights = new(new int[][] {
                new int[] { 1, 0, 1 },
                new int[] { 0, 1, 0 },
                new int[] { 1, 0, 1 }
            });

            int[][] expected = new int[][] {
                new int[] { 0, 0, 0 },
                new int[] { 0, 0, 0 },
                new int[] { 0, 0, 0 }
            };

            var result = lights.PerformOperation(Instruction.SWITCH_OFF, 0, 0, 2, 2);

            for (var i = 0; i < lights.Lights.Length; i++)
            {
                Assert.True(Enumerable.SequenceEqual(expected[i], result[i]));
            }
        }

        [Fact]
        public void ShouldIncreaseLightBrightness()
        {
            LightGridWithBrightness lights = new(new int[][] {
                new int[] { 1, 0, 1 },
                new int[] { 0, 1, 0 },
                new int[] { 1, 0, 1 }
            });

            int[][] expected = new int[][] {
                new int[] { 2, 1, 2 },
                new int[] { 1, 2, 1 },
                new int[] { 2, 1, 2 }
            };

            var result = lights.PerformOperation(Instruction.SWITCH_ON, 0, 0, 2, 2);

            for (var i = 0; i < lights.Lights.Length; i++)
            {
                Assert.True(Enumerable.SequenceEqual(expected[i], result[i]));
            }
        }

        [Fact]
        public void ShouldToggleIncreaseLightBrightness()
        {
            LightGridWithBrightness lights = new(new int[][] {
                new int[] { 1, 0, 1 },
                new int[] { 0, 1, 0 },
                new int[] { 1, 0, 1 }
            });

            int[][] expected = new int[][] {
                new int[] { 3, 2, 3 },
                new int[] { 2, 3, 2 },
                new int[] { 3, 2, 3 }
            };

            var result = lights.PerformOperation(Instruction.TOGGLE, 0, 0, 2, 2);

            for (var i = 0; i < lights.Lights.Length; i++)
            {
                Assert.True(Enumerable.SequenceEqual(expected[i], result[i]));
            }
        }
    }
}
