using Day06;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaySix
{
    class OrbitCountVisitor : IPlanetVisitor
    {
        public int OrbitingCount { get; set; } = 0;

        public void Visit(Planet planet)
        {
            var visiting = planet;
            while (visiting.Orbiting is not null)
            {
                OrbitingCount++;
                visiting = visiting.Orbiting;
            }

            planet.Orbiters.ForEach(p => p.Accept(this));
        }
    }
}