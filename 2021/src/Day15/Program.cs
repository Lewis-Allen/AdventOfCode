using Day15;

var map = File.ReadAllLines("Inputs/15.txt")
    .Select(l => l.Select(c => c - '0').ToArray())
    .ToArray();

var result = PathCalculator.Dijkstra(map, (0, 0));

Console.WriteLine($"The shortest path to the end has a weight of {result[(map[^1].Length - 1, map.Length - 1)]}");

// Stretch out columns
List<int[][]> extraTiles = new();
for(int i = 1; i < 5; i++)
{
    var tile = map
        .Select(l => l.Select(c => (c + i) > 9 ? (c + i) % 9 : (c + i)).ToArray())
        .ToArray();

    extraTiles.Add(tile);
}

foreach(var tile in extraTiles)
{
    map = map
        .Concat(tile)
        .ToArray();
}

// Stretch out rows
for(int i = 0; i < map.Length; i++)
{
    var line = map[i];
    
    map[i] = Enumerable.Range(0, 5)
        .SelectMany(i => line.Select(c => (c + i) > 9 ? (c + i) % 9 : (c + i)).ToArray())
        .ToArray();
}

result = PathCalculator.Dijkstra(map, (0,0));

Console.WriteLine($"The shortest path to the end on the full map has a weight of {result[(map[^1].Length - 1, map.Length - 1)]}");
