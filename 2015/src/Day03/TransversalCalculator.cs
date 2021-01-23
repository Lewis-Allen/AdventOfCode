using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    public class TransversalCalculator
    {
        public static int FindNoOfHousesVisited(string directions)
        {
            int x = 0;
            int y = 0;
            HashSet<(int, int)> visitedLocations = new();
            visitedLocations.Add((x, y));

            foreach(char c in directions)
            {
                switch(c)
                {
                    case '^':
                        y++;
                        break;
                    case '>':
                        x++;
                        break;
                    case 'v':
                        y--;
                        break;
                    case '<':
                        x--;
                        break;
                    default:
                        throw new ArgumentException("String contains invalid characters. Valid characters are ^>v<");
                }

                if(!visitedLocations.Contains((x,y)))
                    visitedLocations.Add((x, y));
            }

            return visitedLocations.Count;
        }

        public static int FindNoOfHousesVisitedWithRoboSanta(string directions)
        {
            int x = 0;
            int y = 0;
            int roboX = 0;
            int roboY = 0;
            bool isRobotsTurn = false;
            HashSet<(int, int)> visitedLocations = new();
            visitedLocations.Add((x, y));

            foreach (char c in directions)
            {
                switch (c)
                {
                    case '^':
                        if (isRobotsTurn) roboY++; else y++;
                        break;
                    case '>':
                        if (isRobotsTurn) roboX++; else x++;
                        break;
                    case 'v':
                        if (isRobotsTurn) roboY--; else y--;
                        break;
                    case '<':
                        if (isRobotsTurn) roboX--; else x--;
                        break;
                    default:
                        throw new ArgumentException("String contains invalid characters. Valid characters are ^>v<");
                }

                var current = isRobotsTurn ? (roboX, roboY) : (x, y);
                if (!visitedLocations.Contains(current))
                    visitedLocations.Add(current);

                isRobotsTurn = !isRobotsTurn;
            }

            return visitedLocations.Count;
        }

    }
}
