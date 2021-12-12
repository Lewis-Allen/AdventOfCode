using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    public class Spelunker
    {
        public static List<string[]> FindPaths(Dictionary<string, string[]> lookup)
        {
            var paths = new List<string[]>();

            Transverse(lookup, new List<string>(), "start", paths);

            return paths;
        }

        private static void Transverse(Dictionary<string, string[]> lookup, List<string> route, string key, List<string[]> paths)
        {
            if (key == "end")
            {
                paths.Add(route
                    .ToList()
                    .Append(key)
                    .ToArray());

                return;
            }

            if (char.IsLower(key[0]) && route.Contains(key))
                return;

            var current = route
                .ToList()
                .Append(key);

            foreach (var next in lookup[key])
            {
                Transverse(lookup, current.ToList(), next, paths);
            }
        }

        public static List<string[]> FindPathsWithExtraVisiting(Dictionary<string, string[]> lookup)
        {
            var paths = new List<string[]>();

            TransverseWithExtraVisiting(lookup, new List<string>(), "start", paths);

            return paths;
        }

        private static void TransverseWithExtraVisiting(Dictionary<string, string[]> lookup, List<string> route, string key, List<string[]> paths)
        {
            if (key == "end")
            {
                paths.Add(route
                    .ToList()
                    .Append(key)
                    .ToArray());

                return;
            }

            if (char.IsLower(key[0]) && route.Contains(key) && (key == "start" || route.Where(c => char.IsLower(c[0])).GroupBy(k => k).Any(o => o.Count() >= 2)))
                return;

            var current = route
                .ToList()
                .Append(key);

            foreach (var next in lookup[key])
            {
                TransverseWithExtraVisiting(lookup, current.ToList(), next, paths);
            }
        }

        public static Dictionary<string, string[]> ParseLines(string[] lines) => lines
            .SelectMany(l =>
            {
                var split = l.Split("-");
                var from = split[0];
                var to = split[1];

                return new string[2] { from + "-" + to, to + "-" + from };
            })
            .GroupBy(l => l.Split("-")[0], 
                     l => l.Split("-")[1])
            .ToDictionary(g => g.Key,
                          g => g.ToArray());
    }
}
