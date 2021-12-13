using System.Text;

namespace Day13;

public class PaperFolder
{
    public static Dot[] Fold(Instruction i, Dot[] dots)
    {
        var p1 = dots
            .Where(d => (i.IsX && d.X < i.Pos) || (!i.IsX && d.Y < i.Pos));

        var p2 = dots
            .Where(d => (i.IsX && d.X > i.Pos) || (!i.IsX && d.Y > i.Pos))
            .Select(d => new Dot(i.IsX ? i.Pos - (d.X - i.Pos) : d.X, !i.IsX ? i.Pos - (d.Y - i.Pos) : d.Y));

        return p1.Union(p2).ToArray();
    }

    public static void OutputToConsole(Dot[] dots)
    {
        var maxY = dots.Select(d => d.Y).Max();
        var maxX = dots.Select(d => d.X).Max();

        for (int y = 0; y <= maxY; y++)
        {
            var builder = new StringBuilder();
            for (int x = 0; x <= maxX; x++)
            {
                if (dots.FirstOrDefault(d => d.X == x && d.Y == y) == null)
                {
                    builder.Append('.');
                }
                else
                {
                    builder.Append('#');
                }

            }
            Console.WriteLine(builder.ToString());
        }
    }
}
