namespace Day15;

public class PathCalculator
{
    public static Dictionary<(int X, int Y), int> Dijkstra(int[][] graph, (int X, int Y) source)
    {
        Dictionary<(int X, int Y), int> dist = new();
        List<(int X, int Y)> items = new();
        
        bool[][] visited = new bool[graph.Length][];
        for(var i = 0; i < visited.Length; i++)
        {
            visited[i] = new bool[graph[i].Length];
        }

        dist[source] = 0;
        items.Add(source);
        visited[source.Y][source.X] = true;

        for(var y = 0; y < graph.Length; y++)
            for(var x = 0; x < graph[y].Length; x++)
            {
                var v = (x, y);
                if(v != source)
                {
                    dist[v] = int.MaxValue;
                }
            }

        while (items.Count > 0)
        {
            (int X, int Y) v = items.MinBy(x => dist[x]);
            items.Remove(v);

            var children = GetNeighbours(graph, v);

            foreach(var child in children)
            {
                var a = dist[v] + graph[child.Y][child.X];
                if(a < dist[child])
                {
                    dist[child] = a;
                }

                if (!visited[child.Y][child.X])
                {
                    items.Add(child);
                    visited[child.Y][child.X] = true;
                }
            }
        }

        return dist;
    }
    
    private static List<(int X, int Y)> GetNeighbours(int[][] graph, (int X, int Y) v) 
    {
        var positions = new (int X, int Y)[]
            {
                (1,0),
                (-1,0),
                (0,1),
                (0,-1)
            };
        var children = new List<(int X, int Y)>();

        foreach (var (X, Y) in positions)
        {
            (int X, int Y) checkPos = (v.X + X, v.Y + Y);

            if (checkPos.X > graph[0].Length - 1 ||
               checkPos.X < 0 ||
               checkPos.Y > graph.Length - 1 ||
               checkPos.Y < 0)
                continue;

            children.Add(checkPos);
        }

        return children;
    }
}
