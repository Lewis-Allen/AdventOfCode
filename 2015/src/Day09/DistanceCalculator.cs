using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09
{
    public class DistanceCalculator
    {
        public Dictionary<(string, string), int> Distances { get; } = new();

        public DistanceCalculator(string[] distances)
        {
            foreach (var distance in distances)
            {
                var chunks = distance.Split(" ");
                var source = chunks[0];
                var destination = chunks[2];
                var length = int.Parse(chunks[4]);

                Distances.Add((source, destination), length);
            }
        }

        public Dictionary<(string, string), int> CalculateAllShortestDistances()
        {
            var cities = Distances.Keys.Select(s => s.Item1).Union(Distances.Keys.Select(s => s.Item2)).ToArray();
            Dictionary<(string, string), int> shortestDistances = new();

            for (int i = 0; i < cities.Length - 1; i++)
            {
                for (int j = i; j < cities.Length; j++)
                {
                    var shortestDistance = GetShortestDistance(cities[j], cities[i]);
                    if (shortestDistance != 0)
                        shortestDistances[(cities[j], cities[i])] = shortestDistance;
                }
            }

            return shortestDistances;
        }

        public Dictionary<(string, string), int> CalculateAllLongestDistances()
        {
            var cities = Distances.Keys.Select(s => s.Item1).Union(Distances.Keys.Select(s => s.Item2)).ToArray();
            Dictionary<(string, string), int> longestDistances = new();

            for (int i = 0; i < cities.Length - 1; i++)
            {
                for (int j = i; j < cities.Length; j++)
                {
                    var longestDistance = GetLongestDistance(cities[j], cities[i]);
                    if (longestDistance != 0)
                        longestDistances[(cities[j], cities[i])] = longestDistance;
                }
            }

            return longestDistances;
        }

        public int GetShortestDistance(string source, string destination)
        {
            var results = GetDistances(source);
            var noOfCities = Distances.Keys.Select(s => s.Item1).Distinct().Union(Distances.Keys.Select(s => s.Item2).Distinct()).Count();

            return results.Where(s => s.Item1 == destination && s.Item2 == noOfCities - 1)
                .Select(s => s.Item3)
                .DefaultIfEmpty()
                .Min();
        }

        public int GetLongestDistance(string source, string destination)
        {
            var results = GetDistances(source);
            var noOfCities = Distances.Keys.Select(s => s.Item1).Distinct().Union(Distances.Keys.Select(s => s.Item2).Distinct()).Count();

            return results.Where(s => s.Item1 == destination && s.Item2 == noOfCities - 1)
                .Select(s => s.Item3)
                .DefaultIfEmpty()
                .Max();
        }

        private List<(string, int, int)> GetDistances(string source)
        {
            Stack<(string, int, int, List<string>)> s = new();
            List<(string, int, int)> results = new();

            s.Push((source, 0, 0, new()));

            while (s.Any())
            {
                var (name, depth, distance, discovered) = s.Pop();
                if (!discovered.Contains(name))
                {
                    results.Add((name, depth, distance));

                    discovered.Add(name);
                    foreach (var connected in GetConnectedCities(name))
                    {
                        s.Push((connected, depth + 1, distance + GetDistanceBetweenConnectedCities(name, connected), new List<string>(discovered)));
                    }
                }
            }

            return results;
        }

        private string[] GetConnectedCities(string city) =>
             Distances.Keys.Where(s => s.Item1 == city)
                .Select(s => s.Item2)
                .Union(Distances.Keys.Where(s => s.Item2 == city).Select(s => s.Item1))
                .ToArray();

        private int GetDistanceBetweenConnectedCities(string cityOne, string cityTwo) =>
            Distances.ContainsKey((cityOne, cityTwo)) ? Distances[(cityOne, cityTwo)] : Distances[(cityTwo, cityOne)];

    }
}
