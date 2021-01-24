using System;
using Xunit;

namespace Day05.Tests
{
    public class SantasCheckerTest
    {
        [Theory]
        [InlineData("ugknbfddgicrmopn", true)]
        [InlineData("aaa", true)]
        [InlineData("jchzalrnumimnmhp", false)]
        [InlineData("haegwjzuvuyypxyu", false)]
        [InlineData("dvszwmarrgswjxmb", false)]
        public void ShouldBeNiceOrNaughty(string input, bool expected)
        {
            var result = SantasChecker.CheckString(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("qjhvhtzxzqqjkmpb", true)]
        [InlineData("xxyxx", true)]
        [InlineData("uurcxstgmygtbstg", false)]
        [InlineData("ieodomkazucvgmuy", false)]
        public void ShouldBeNiceOrNaughtyRefined(string input, bool expected)
        {
            var result = SantasChecker.CheckStringRefined(input);
            Assert.Equal(expected, result);
        }
    }
}
