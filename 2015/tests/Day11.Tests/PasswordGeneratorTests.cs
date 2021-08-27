using System;
using Xunit;

namespace Day11.Tests
{
    public class PasswordGeneratorTests
    {
        [Theory]
        [InlineData("abcdefgh", "abcdffaa")]
        [InlineData("ghijklmn", "ghjaabcc")]
        public void Should_Get_Next_Password(string current, string expected)
        {
            var actual = PasswordGenerator.FindNextPassword(current);

            Assert.Equal(expected, actual);
        }
    }
}
