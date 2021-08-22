using System;
using Xunit;

namespace Day04.Tests
{
    public class PasswordValidatorTests
    {
        [Theory]
        [InlineData("111111", true)]
        [InlineData("223450", false)]
        [InlineData("123789", false)]
        public void Should_Return_Correct_Validation_Part_One(string password, bool expected)
        {
            var result = PasswordValidator.ValidatePasswordPartOne(password);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("112233", true)]
        [InlineData("123444", false)]
        [InlineData("111122", true)]
        public void Should_Return_Correct_Validation_Part_Two(string password, bool expected)
        {
            var result = PasswordValidator.ValidatePasswordPartTwo(password);
            Assert.Equal(expected, result);
        }
    }
}
