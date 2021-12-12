using System.Collections.Generic;
using Xunit;

namespace Day12.Tests
{
    public class SpelunkerTests
    {
        [Fact]
        public void Should_Find_Number_Of_Paths()
        {
            var dict = new Dictionary<string, string[]>
            {
                { "start", new string[] { "A", "b" } },
                { "A", new string[] { "start", "c", "b", "end" } },
                { "b", new string[] { "start", "A", "d", "end" } },
                { "c", new string[] { "A" } },
                { "d", new string[] { "b" } },
                { "end", new string[] { "A", "b" } },
            };

            var result = Spelunker.FindPaths(dict);

            Assert.Equal(10, result.Count);
        }

        [Fact]
        public void Should_Find_Number_Of_Paths_With_Extra_Visiting()
        {
            var dict = new Dictionary<string, string[]>
            {
                { "start", new string[] { "A", "b" } },
                { "A", new string[] { "start", "c", "b", "end" } },
                { "b", new string[] { "start", "A", "d", "end" } },
                { "c", new string[] { "A" } },
                { "d", new string[] { "b" } },
                { "end", new string[] { "A", "b" } },
            };

            var result = Spelunker.FindPathsWithExtraVisiting(dict);

            Assert.Equal(36, result.Count);
        }
    }
}