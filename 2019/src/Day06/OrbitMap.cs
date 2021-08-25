using DaySix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    public class OrbitMap
    {
        public List<Planet> Planets { get; } = new();
        public Planet COM { get; set; }

        public OrbitMap(string[] orbits)
        {
            foreach(string orbit in orbits)
            {
                var planets = orbit.Split(")");
                string orbittedName = planets[0];
                string orbittingName = planets[1];

                Planet orbitted = Planets.Find(p => p.Name == orbittedName);

                if(orbitted is null)
                {
                    orbitted = new Planet(orbittedName, 0);
                    Planets.Add(orbitted);
                }

                Planet orbitting = Planets.Find(p => p.Name == orbittingName);

                if(orbitting is null)
                {
                    orbitting = new Planet(orbittingName, orbitted.Depth + 1);
                    Planets.Add(orbitting);
                }

                orbitted.Orbiters.Add(orbitting);
                orbitting.Orbiting = orbitted;

            }

            COM = Planets.Where(p => p.Orbiting is null).FirstOrDefault();
        }

        public int GetTotalOrbits()
        {
            var planet = COM;
            OrbitCountVisitor visitor = new();
            planet.Accept(visitor);

            return visitor.OrbitingCount;
        }

        public int GetRequiredOrbitalTransfers(string sourceOrbiter, string destinationOrbiter)
        {
            var source = Planets.Find(p => p.Name == sourceOrbiter);
            var destination = Planets.Find(p => p.Name == destinationOrbiter);

            // Find deepest common ancestor lower than the depth of the two planets
            var highestCommonAncestor = source.GetAncestors()
                .Intersect(destination.GetAncestors())
                .Where(p => p.Depth < source.Depth && p.Depth < destination.Depth)
                .OrderByDescending(p => p.Depth)
                .First();

            return source.Orbiting.Depth + destination.Orbiting.Depth - (highestCommonAncestor.Depth * 2);
            
        }
    }
}
