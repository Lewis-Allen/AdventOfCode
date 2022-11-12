using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public class VelocityCalculator
    {
        public static int GetHighestPoint(Instruction target)
        {
            int highestPoint = 0;

            for (var xVelocity = 0; xVelocity <= Math.Max(target.FromX, target.ToX); xVelocity++)
            {
                for (var yVelocity = Math.Min(target.FromY, target.ToY); yVelocity < Math.Min(target.FromY, target.ToY) + Math.Max(target.FromX, target.ToX); yVelocity++)
                {
                    var xV = xVelocity;
                    var yV = yVelocity;

                    var x = 0;
                    var y = 0;
                    var yMax = 0;

                    var success = false;

                    while (!(xV == 0 && y < Math.Min(target.FromY, target.ToY)))
                    {
                        x += xV;
                        y += yV;

                        if (xV > 0)
                            xV--;

                        if (xV < 0)
                            xV++;

                        yV--;

                        yMax = Math.Max(yMax, y);

                        if (x >= Math.Min(target.FromX, target.ToX) && x <= Math.Max(target.FromX, target.ToX) && y >= Math.Min(target.FromY, target.ToY) && y <= Math.Max(target.FromY, target.ToY))
                        {
                            success = true;
                        }

                        if (success && yV <= 0)
                            break;
                    }

                    if (success)
                        highestPoint = Math.Max(yMax, highestPoint);
                }
            }

            return highestPoint;
        }

        public static int GetDistinctVelocities(Instruction target)
        {
            int distinctVelocities = 0;

            for (var xVelocity = 0; xVelocity <= Math.Max(target.FromX, target.ToX); xVelocity++)
            {
                for (var yVelocity = Math.Min(target.FromY, target.ToY); yVelocity < Math.Min(target.FromY, target.ToY) + Math.Max(target.FromX, target.ToX); yVelocity++)
                {
                    var xV = xVelocity;
                    var yV = yVelocity;

                    var x = 0;
                    var y = 0;
                    var yMax = 0;

                    while (!(xV == 0 && y < Math.Min(target.FromY, target.ToY)))
                    {
                        x += xV;
                        y += yV;

                        if (xV > 0)
                            xV--;

                        if (xV < 0)
                            xV++;

                        yV--;

                        yMax = Math.Max(yMax, y);

                        if (x >= Math.Min(target.FromX, target.ToX) && x <= Math.Max(target.FromX, target.ToX) && y >= Math.Min(target.FromY, target.ToY) && y <= Math.Max(target.FromY, target.ToY))
                        {
                            distinctVelocities++;
                            break;
                        }
                    }
                }
            }

            return distinctVelocities;
        }
    }
}
