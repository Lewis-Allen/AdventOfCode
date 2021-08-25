using Day06;
using System;
using System.IO;

var planets = File.ReadAllLines("Inputs/6.txt");

// Part One
OrbitMap orbitMap = new(planets);
var totalOrbits = orbitMap.GetTotalOrbits();

Console.WriteLine($"The total number of orbits (direct + indirect) for part one is {totalOrbits}.");

// Part Two
var totalOrbitalTransfers = orbitMap.GetRequiredOrbitalTransfers("YOU", "SAN");

Console.WriteLine($"The total orbital transfers to move from YOU to SAN is {totalOrbitalTransfers}.");