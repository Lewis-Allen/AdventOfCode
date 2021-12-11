using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class OctopusCalculator
    {
        public static int GetFlashesAfterXSteps(Octopus[] octopuses, int steps)
        {
            int flashes = 0;
            for (int i = 0; i < steps; i++)
            {
                foreach (var octopus in octopuses)
                {
                    if (octopus.Flashed)
                    {
                        octopus.Charge = 0;
                        octopus.Flashed = false;
                    }

                    octopus.Charge++;
                }

                while (octopuses.Any(o => o.Charge > 9 && !o.Flashed))
                {
                    var flashed = octopuses
                        .Select((o, i) => new { Octopus = o, Index = i })
                        .Where(o => o.Octopus.Charge > 9 && !o.Octopus.Flashed);

                    foreach (var flash in flashed)
                    {
                        octopuses[flash.Index].Flashed = true;
                        flashes++;

                        var affected = octopuses
                            .Select((o, i) => new { Octopus = o, Index = i })
                            .Where(o => o.Octopus.X >= flash.Octopus.X - 1 &&
                                        o.Octopus.X <= flash.Octopus.X + 1 &&
                                        o.Octopus.Y >= flash.Octopus.Y - 1 &&
                                        o.Octopus.Y <= flash.Octopus.Y + 1 &&
                                        !(o.Octopus.X == flash.Octopus.X && o.Octopus.Y == flash.Octopus.Y));

                        foreach (var octopus in affected)
                        {
                            octopuses[octopus.Index].Charge++;
                        }
                    }
                }
            }

            return flashes;
        }

        public static int GetSynchronisingFlashStep(Octopus[] octopuses)
        {
            var step = 0;
            while (octopuses.Any(o => !o.Flashed))
            {
                step++;
                foreach (var octopus in octopuses)
                {
                    if (octopus.Flashed)
                    {
                        octopus.Charge = 0;
                        octopus.Flashed = false;
                    }

                    octopus.Charge++;
                }

                while (octopuses.Any(o => o.Charge > 9 && !o.Flashed))
                {
                    var flashed = octopuses
                        .Select((o, i) => new { Octopus = o, Index = i })
                        .Where(o => o.Octopus.Charge > 9 && !o.Octopus.Flashed);

                    foreach (var flash in flashed)
                    {
                        octopuses[flash.Index].Flashed = true;

                        var affected = octopuses
                            .Select((o, i) => new { Octopus = o, Index = i })
                            .Where(o => o.Octopus.X >= flash.Octopus.X - 1 &&
                                        o.Octopus.X <= flash.Octopus.X + 1 &&
                                        o.Octopus.Y >= flash.Octopus.Y - 1 &&
                                        o.Octopus.Y <= flash.Octopus.Y + 1 &&
                                        !(o.Octopus.X == flash.Octopus.X && o.Octopus.Y == flash.Octopus.Y));

                        foreach (var octopus in affected)
                        {
                            octopuses[octopus.Index].Charge++;
                        }
                    }
                }
            }

            return step;
        }
    }
}
