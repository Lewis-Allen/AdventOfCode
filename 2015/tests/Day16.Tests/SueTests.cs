using System.Collections.Generic;
using Xunit;

namespace Day16.Tests
{
    public class SueTests
    {
        [Fact]
        public void Should_Parse_Line_Into_Sue()
        {
            var line = "Sue 1: children: 1, cars: 8, vizslas: 7";

            var expected = new Sue(1, new Dictionary<string, int>()
            {
                { "children", 1 },
                { "cars", 8 },
                { "vizslas", 7 }
            });
            var result = Sue.FromString(line);

            Assert.Equal(expected.Id, result.Id);
            Assert.Equal(expected.Items.Count, result.Items.Count);
            Assert.Equal(expected.Items.Keys, result.Items.Keys);
            Assert.Equal(expected.Items.Values, result.Items.Values);
        }
    }
}