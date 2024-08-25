using Day18;

var lines = File.ReadAllLines("input.txt");

var grid = Grid.FromLines(lines);

for(var i = 0; i < 100; i++)
{
    grid.Switch();
}

Console.WriteLine($"The number of lights on after 100 steps is {grid.GetOnLights()}");

grid = Grid.FromLines(lines);

for (var i = 0; i < 100; i++)
{
    grid.SwitchWithStuckLights();
}

foreach(var line in grid.Lights)
{
    foreach(var light in line)
    {
        Console.Write(light ? "#" : ".");
    }
    Console.WriteLine();
}

Console.WriteLine($"The number of lights on after 100 steps with stuck lights is {grid.GetOnLights()}");