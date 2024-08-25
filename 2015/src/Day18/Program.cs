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

Console.WriteLine($"The number of lights on after 100 steps with stuck lights is {grid.GetOnLights()}");