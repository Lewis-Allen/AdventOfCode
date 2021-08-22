using System;
using System.Collections.Generic;
using Xunit;

namespace Day03.Tests
{
    public class LineCalculatorTests
    {
        [Fact]
        public void Should_Return_Occupied_Points()
        {
            int fromX = 0;
            int fromY = 0;

            int toX = 5;
            int toY = 0;

            var expected = new List<(int, int)> { (0, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0) };

            List<(int, int)> result = LineCalculator.GetOccupiedBetweenPoints(fromX, fromY, toX, toY);
            Assert.Equal(expected, result);

            fromX = 0;
            fromY = 0;

            toX = 0;
            toY = 5;

            expected = new List<(int, int)> { (0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5) };

            result = LineCalculator.GetOccupiedBetweenPoints(fromX, fromY, toX, toY);
            Assert.Equal(expected, result);

            fromX = 2;
            fromY = 0;

            toX = -2;
            toY = 0;

            expected = new List<(int, int)> { (-2, 0), (-1, 0), (0, 0), (1, 0), (2, 0) };

            result = LineCalculator.GetOccupiedBetweenPoints(fromX, fromY, toX, toY);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_Return_Occupied_Points_Multiple_Positions()
        {
            var points = new List<(int, int)>()
            {
                (0,0),
                (3,0),
                (3,2),
            };

            var expected = new List<(int, int)>() { (0, 0), (1, 0), (2, 0), (3, 0), (3, 1), (3, 2) };
            var result = LineCalculator.GetOccupiedBetweenPoints(points);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_Return_List_Of_Points()
        {
            var directions = "R8,U5,L5,D3";

            var expected = new List<(int, int)>() { (0, 0), (8, 0), (8, 5), (3, 5), (3, 2) };
            var result = LineCalculator.GetPointsFromString(directions);

            Assert.Equal(expected, result);
            
        }

        [Theory]
        [InlineData("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        [InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72","U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51","U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void Should_Return_Closest_Intersection(string directionsOne, string directionsTwo, int expected)
        {
            var result = LineCalculator.GetClosestIntersectionManhattan(directionsOne, directionsTwo);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("U7,R6,D4,L4", 6, 5, 15)]
        [InlineData("U7,R6,D4,L4", 3, 3, 20)]
        [InlineData("R8,U5,L5,D3", 6, 5, 15)]
        [InlineData("R8,U5,L5,D3", 3, 3, 20)]
        public void Should_Return_Number_Of_Steps_To_Point(string directions, int x, int y, int expected)
        {
            var result = LineCalculator.GetTotalStepsToReachPoint(directions, x, y);
            Assert.Equal(expected, result);
        }

    }
}
