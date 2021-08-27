using Xunit;

namespace Day08.Tests
{
    public class CharacterCounterTests
    {
        [Theory]
        [InlineData(@"""""", 2)]
        [InlineData(@"""abc""", 2)]
        [InlineData(@"""aaa\""aaa""", 3)]
        [InlineData(@"""\x27""", 5)]
        public void Should_Return_Literal_Length_Minus_Code_Length(string data, int expected)
        {
            var result = CharacterCounter.GetCharacters(data);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(@"""""", 4)]
        [InlineData(@"""abc""", 4)]
        [InlineData(@"""aaa\""aaa""", 6)]
        [InlineData(@"""\x27""", 5)]
        public void Should_Return_Encoded_Minus_Code_Length(string data, int expected)
        {
            var result = CharacterCounter.GetCharactersEncode(data);

            Assert.Equal(expected, result);
        }
    }
}
