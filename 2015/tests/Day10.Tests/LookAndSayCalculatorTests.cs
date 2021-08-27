using System;
using Xunit;

namespace Day10.Tests
{
    public class LookAndSayCalculatorTests
    {
        [Theory]
        [InlineData("1", "11")]
        [InlineData("11", "21")]
        [InlineData("21", "1211")]
        [InlineData("1211", "111221")]
        [InlineData("111221", "312211")]
        public void Should_Generate_Correct_Output_String(string input, string expected)
        {
            var actual = LookAndSayGenerator.Generate(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1", "11")]
        [InlineData("11", "21")]
        [InlineData("21", "1211")]
        [InlineData("1211", "111221")]
        [InlineData("111221", "312211")]
        public void Should_Generate_Correct_Output_StringV2(string input, string expected)
        {
            var actual = LookAndSayGenerator.Generate(input);
            Assert.Equal(expected, actual);
        }
    }
}
