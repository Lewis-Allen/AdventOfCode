using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    public static class LineCalculator
    {
        public static List<(int, int)> GetPointsFromString(string directions)
        {
            string[] steps = directions.Split(",");
            List<(int, int)> points = new();
            int curX = 0;
            int curY = 0;

            points.Add((curX, curY));
            foreach (var step in steps)
            {
                char direction = step[0];

                int factor = direction switch
                {
                    'L' or 'D' => -1,
                    'R' or 'U' => 1,
                    _ => throw new ArgumentException("Invalid directon. Check for valid file data.")
                };

                if (direction == 'L' || direction == 'R')
                {
                    curX += int.Parse(step[1..]) * factor;
                }
                else if (direction == 'D' || direction == 'U')
                {
                    curY += int.Parse(step[1..]) * factor;
                }
                else
                {
                    throw new ArgumentException("Invalid directon. Check for valid file data.");
                }

                points.Add((curX, curY));
            }

            return points;
        }

        public static List<(int, int)> GetOccupiedBetweenPoints(int fromX, int fromY, int toX, int toY)
        {
            if (fromX != toX && fromY != toY)
                throw new ArgumentException($"points shouldn't form a diagonal - ({fromX},{fromY}) to ({toX},{toY})");

            List<(int, int)> occupiedPoints = new();

            var lowerX = Math.Min(fromX, toX);
            var lowerY = Math.Min(fromY, toY);

            var upperX = Math.Max(fromX, toX);
            var upperY = Math.Max(fromY, toY);

            for (int x = lowerX; x <= upperX; x++)
            {
                var pos = (x, fromY);
                if (!occupiedPoints.Contains(pos))
                    occupiedPoints.Add(pos);
            }

            for (int y = lowerY; y <= upperY; y++)
            {
                var pos = (fromX, y);
                if (!occupiedPoints.Contains(pos))
                    occupiedPoints.Add(pos);
            }

            return occupiedPoints;
        }

        public static List<(int, int)> GetOccupiedBetweenPoints(List<(int, int)> points)
        {
            if (points.Count == 0)
                throw new ArgumentException("No points provided", nameof(points));

            if (points.Count == 1)
                return points;

            List<(int, int)> occupiedPoints = new();

            for (int i = 0; i < points.Count - 1; i++)
            {
                var (fromX, fromY) = points[i];
                var (toX, toY) = points[i + 1];

                occupiedPoints = occupiedPoints.Union(GetOccupiedBetweenPoints(fromX, fromY, toX, toY)).ToList();
            }

            return occupiedPoints;
        }

        public static int GetClosestIntersectionManhattan(string directionsOne, string directionsTwo)
        {
            var intersections = GetIntersectionPoints(directionsOne, directionsTwo);

            var closest = intersections
                .Where((i) => i != (0, 0))
                .Min(s => ManhattanCalculator.GetManhattanDistance(0, 0, s.Item1, s.Item2));

            return closest;
        }

        public static List<(int,int)> GetIntersectionPoints(string directionsOne, string directionsTwo)
        {
            var lineOnePoints = LineCalculator.GetPointsFromString(directionsOne);
            var lineTwoPoints = LineCalculator.GetPointsFromString(directionsTwo);

            var lineOneOccupied = LineCalculator.GetOccupiedBetweenPoints(lineOnePoints);
            var lineTwoOccupied = LineCalculator.GetOccupiedBetweenPoints(lineTwoPoints);

            return lineOneOccupied.Intersect(lineTwoOccupied).ToList();
        }

        public static int GetTotalStepsToReachPoint(string directions, int x, int y)
        {
            var points = GetPointsFromString(directions);

            int sum = 0;
            bool found = false;
            for(int i = 0; !found && i < points.Count - 1; i++)
            {
                var occupiedPoints = GetOccupiedBetweenPoints(points[i].Item1, points[i].Item2, points[i + 1].Item1, points[i + 1].Item2);

                if (!occupiedPoints.Contains((x,y)))
                {
                    sum += occupiedPoints.Count - 1;
                }
                else
                {
                    sum += ManhattanCalculator.GetManhattanDistance(points[i].Item1, points[i].Item2, x, y);
                    found = true;
                }
            }

            if (!found)
                throw new ArgumentException($"Point ({x},{y}) does not fall on provided directions");

            return sum;
        }
    }
}
