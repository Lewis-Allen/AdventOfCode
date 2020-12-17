using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../Input.txt");

HashSet<Cube> cubes = new();

var height = lines.Length;

for(int y = 0; y < lines.Length; y++)
{
    for(int x = 0; x < lines[y].Length; x++)
    {
        cubes.Add(new(x, y, 0, lines[y][x] == '#'));
    }
}

int noOfCycles = 6;
for (int c = 0; c < noOfCycles; c++)
{
    int minX = cubes.Min(c => c.X);
    int minY = cubes.Min(c => c.Y);
    int minZ = cubes.Min(c => c.Z);

    int maxX = cubes.Max(c => c.X);
    int maxY = cubes.Max(c => c.Y);
    int maxZ = cubes.Max(c => c.Z);

    HashSet<Cube> newCubes = new();

    for(int z = minZ - 1; z <= maxZ + 1; z++)
    {
        for(int y = minY - 1; y <= maxY + 1; y++)
        {
            for(int x = minX - 1; x <= maxX + 1; x++)
            {
                Cube cube = cubes.FirstOrDefault(c => c.X == x && c.Y == y && c.Z == z);
                
                bool currentlyActive = cube != null && cube.Active;

                Cube newCube = new(x, y, z, GoActive(x, y, z, currentlyActive, cubes));
                newCubes.Add(newCube);
                Console.Write(newCube.Active ? '#' : '.');
            }
            Console.WriteLine();
        }

        Console.WriteLine("---------------------");
    }

    cubes = newCubes;
}

Console.WriteLine(cubes.Count(c => c.Active));

static bool GoActive(int x, int y, int z, bool active, HashSet<Cube> cubes)
{
    int nearbyActives = cubes.Where(c =>
    {
        return c.Active && !(c.X == x && c.Y == y && c.Z == z) &&
               c.X >= x - 1 &&
               c.X <= x + 1 &&
               c.Y >= y - 1 &&
               c.Y <= y + 1 &&
               c.Z >= z - 1 &&
               c.Z <= z + 1;
    }).Count();

    return (active && (nearbyActives == 2 || nearbyActives == 3)) || (!active && nearbyActives == 3);
}

public record Cube(int X, int Y, int Z, bool Active);
