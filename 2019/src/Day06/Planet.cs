using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    public class Planet
    {
        public string Name { get; set; }
        public List<Planet> Orbiters { get; } = new();
        public Planet Orbiting { get; set; }
        public int Depth { get; set; }

        public Planet(string name, int depth)
        {
            Name = name;
            Depth = depth;
        }

        public List<Planet> GetAncestors()
        {
            List<Planet> ancestors = new();

            var visiting = this;

            while(visiting.Orbiting is not null)
            {
                ancestors.Add(visiting.Orbiting);
                visiting = visiting.Orbiting;
            }

            return ancestors;
        }

        public void Accept(IPlanetVisitor v) => v.Visit(this);
    }
}
