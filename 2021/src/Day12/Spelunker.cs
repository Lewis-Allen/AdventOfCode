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
                var final = route.ToList();
                final.Add(key);

                paths.Add(final.ToArray());
                return;
            }

            if (char.IsLower(key[0]) && route.Contains(key))
                return;

            var current = route.ToList();
            current.Add(key);

            foreach (var next in lookup[key])
            {
                Transverse(lookup, current, next, paths);
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
                var final = route.ToList();
                final.Add(key);
                paths.Add(final.ToArray());
                return;
            }

            if (char.IsLower(key[0]) &&
                route.Contains(key) &&
               (key == "start" || route.Where(c => char.IsLower(c[0])).GroupBy(k => k).Any(o => o.Count() >= 2)))
                return;

            var current = route.ToList();
            current.Add(key);

            foreach (var next in lookup[key])
            {
                TransverseWithExtraVisiting(lookup, current, next, paths);
            }
        }



        public static Dictionary<string, string[]> ParseLines(string[] lines)
        {
            var lookup = new Dictionary<string, string[]>();

            foreach (var line in lines)
            {
                var split = line.Split("-");
                var from = split[0];
                var to = split[1];

                AddPath(lookup, from, to);
            }

            return lookup;
        }

        private static void AddPath(Dictionary<string, string[]> lookup, string from, string to)
        {
            if (lookup.ContainsKey(from))
            {
                lookup[from] = lookup[from].Concat(new string[] { to }).ToArray();
            }
            else
            {
                lookup[from] = new string[] { to };
            }

            if (lookup.ContainsKey(to))
            {
                lookup[to] = lookup[to].Concat( new string[] { from }).ToArray();
            }
            else
            {
                lookup[to] = new string[] { from };
            }
        }
    }
}
