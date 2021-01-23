using System;
using Xunit;

namespace Day04.Tests
{
    public class MD5HasherTest
    {
        [Theory]
        [InlineData("abcdef", 609043)]
        [InlineData("pqrstuv", 1048970)]
        public void ShouldReturnFirstHashWithSixLeadingZeroes(string key, long expected)
        {
            var result = MD5Hasher.FindFirstWithLeadingZeroes(key, 5);
            Assert.Equal(expected, result);
        }
    }
}
