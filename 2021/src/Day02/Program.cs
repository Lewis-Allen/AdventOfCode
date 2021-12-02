using Day02;

var instructions = File
    .ReadAllLines("Inputs/2.txt")
    .ToArray();

// Part One
var depthPosition = PositionCalculator.GetFinalDepthByFinalPosition(instructions);

Console.WriteLine($"The final depth position is {depthPosition}.");

// Part Two
depthPosition = PositionCalculator.GetFinalDepthByFinalPositionWithAim(instructions);

Console.WriteLine($"The final depth position with aim considered is {depthPosition}.");