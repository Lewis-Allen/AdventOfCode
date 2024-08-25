namespace Day18;

public class Grid
{
    public bool[][] Lights = [];

    public static Grid FromLines(string[] lights)
    {
        return new Grid()
        {
            Lights = lights
                .Select(l => l.ToCharArray()
                    .Select(c => c == '#')
                    .ToArray())
                .ToArray()
        };
    }

    private static (int y, int x)[] OFFSETS =
                        [
                            (-1, -1),
                            (-1, 0),
                            (-1, 1),
                            (0, -1),
                            (0, 1),
                            (1, -1),
                            (1, 0),
                            (1, 1)
                        ];

    public void Switch()
    {
        var lights = new bool[Lights.Length][];

        for (var i = 0; i < lights.Length; i++)
        {
            lights[i] = new bool[Lights[i].Length];
        }

        for (var y = 0; y < Lights.Length; y++)
        {
            for (var x = 0; x < Lights[y].Length; x++)
            {
                var current = Lights[y][x];
                var surrounding = 0;

                foreach (var offset in OFFSETS)
                {
                    var yPos = offset.y + y;
                    var xPos = offset.x + x;

                    if (yPos >= 0 && yPos <= Lights.Length - 1 &&
                        xPos >= 0 && xPos <= Lights[y].Length - 1)
                    {
                        var lookup = Lights[yPos][xPos];

                        if (lookup)
                            surrounding++;
                    }
                }

                lights[y][x] = current ? surrounding == 2 || surrounding == 3 : surrounding == 3;
            }
        }

        Lights = lights;
    }

    public void SwitchWithStuckLights()
    {
        var lights = new bool[Lights.Length][];

        for (var i = 0; i < lights.Length; i++)
        {
            lights[i] = new bool[Lights[i].Length];
        }

        // Corners
        var stucks = new (int y, int x)[]
        {
            (0,0),
            (0,Lights[0].Length - 1),
            (Lights.Length - 1,0),
            (Lights.Length - 1,Lights[0].Length - 1)
        };

        foreach(var (y, x) in stucks)
        {
            Lights[y][x] = true;
        }

        for (var y = 0; y < Lights.Length; y++)
        {
            for (var x = 0; x < Lights[y].Length; x++)
            {
                // Skip the stucks
                if (stucks.Contains((y, x)))
                {
                    lights[y][x] = true;
                    continue;
                }

                var current = Lights[y][x];
                var surrounding = 0;

                foreach (var offset in OFFSETS)
                {
                    var yPos = offset.y + y;
                    var xPos = offset.x + x;

                    if (yPos >= 0 && yPos <= Lights.Length - 1 &&
                        xPos >= 0 && xPos <= Lights[y].Length - 1)
                    {
                        var lookup = Lights[yPos][xPos];

                        if (lookup)
                            surrounding++;
                    }
                }

                lights[y][x] = current ? surrounding == 2 || surrounding == 3 : surrounding == 3;
            }
        }

        Lights = lights;
    }

    public int GetOnLights()
    {
        return Lights.Sum(l => l.Sum(c => c == true ? 1 : 0));
    }
}
