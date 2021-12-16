using System.Linq;
using Xunit;

namespace Day15.Tests
{
    public class PathCalculatorTests
    {
        [Fact]
        public void Should_Get_Value_Of_Shortest_Path()
        {
            string[] inputs = new string[]
            {
                "1163751742",
                "1381373672",
                "2136511328",
                "3694931569",
                "7463417111",
                "1319128137",
                "1359912421",
                "3125421639",
                "1293138521",
                "2311944581"
            };

            var nodes = inputs
                .Select(l => l.Select(c => c - '0').ToArray())
                .ToArray();

            var result = PathCalculator.Dijkstra(nodes, (0, 0))[(9, 9)];

            Assert.Equal(40, result);
        }
    }
}