using System;
using Xunit;

namespace Day06.Tests
{
    public class OrbitMapTests
    {
        [Fact]
        public void Total_Orbits_Should_Be_Correct()
        {
            var map = @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L".Split(Environment.NewLine);

            OrbitMap orbitMap = new(map);

            int totalOrbits = orbitMap.GetTotalOrbits();
            Assert.Equal(42, totalOrbits);

        }

        [Fact]
        public void Should_Get_Required_Orbital_Transfers()
        {
            var map = @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L
K)YOU
I)SAN".Split(Environment.NewLine);
            OrbitMap orbitMap = new(map);

            int totalTransfers = orbitMap.GetRequiredOrbitalTransfers("YOU", "SAN");

            Assert.Equal(4, totalTransfers);
        }
    }
}
