using Day05;

var clouds = File.ReadAllLines("Inputs/5.txt")
    .Select(Cloud.FromString)
    .ToArray();

var intersectingClouds = CloudCalculator.GetNumberOfIntersectionsNoDiagonals(clouds);

Console.WriteLine($"The number of intersecting clouds (horizontal or vertical only) is {intersectingClouds}.");

intersectingClouds = CloudCalculator.GetNumberOfIntersections(clouds);

Console.WriteLine($"The number of intersecting clouds is {intersectingClouds}.");
