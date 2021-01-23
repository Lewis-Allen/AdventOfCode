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
        cubes.Add(new(x, y, 0, 0, lines[y][x] == '#'));
    }
}

int noOfCycles = 6;
for (int c = 0; c < noOfCycles; c++)
{
    int minX = cubes.Min(c => c.X);
    int minY = cubes.Min(c => c.Y);
    int minZ = cubes.Min(c => c.Z);
    int minW = cubes.Min(c => c.W);

    int maxX = cubes.Max(c => c.X);
    int maxY = cubes.Max(c => c.Y);
    int maxZ = cubes.Max(c => c.Z);
    int maxW = cubes.Max(c => c.W);

    HashSet<Cube> newCubes = new();

    for(int z = minZ - 1; z <= maxZ + 1; z++)
    {
        for (int w = minW - 1; w <= maxW + 1; w++)
        {
            for (int y = minY - 1; y <= maxY + 1; y++)
            {
                for (int x = minX - 1; x <= maxX + 1; x++)
                {
                    Cube cube = cubes.FirstOrDefault(c => c.X == x && c.Y == y && c.Z == z && c.W == w);

                    bool currentlyActive = cube != null && cube.Active;

                    Cube newCube = new(x, y, z, w, GoActive(x, y, z, w, currentlyActive, cubes));
                    newCubes.Add(newCube);
                }
            }
        }
    }

    cubes = newCubes;
}

Console.WriteLine(cubes.Count(c => c.Active));

static bool GoActive(int x, int y, int z, int w, bool active, HashSet<Cube> cubes)
{
    int nearbyActives = cubes.Where(c =>
    {
        return c.Active && !(c.X == x && c.Y == y && c.Z == z && c.W == w) &&
               c.X >= x - 1 &&
               c.X <= x + 1 &&
               c.Y >= y - 1 &&
               c.Y <= y + 1 &&
               c.Z >= z - 1 &&
               c.Z <= z + 1 &&
               c.W >= w - 1 &&
               c.W <= w + 1;
    }).Count();

    return (active && (nearbyActives == 2 || nearbyActives == 3)) || (!active && nearbyActives == 3);
}

public record Cube(int X, int Y, int Z, int W, bool Active);
