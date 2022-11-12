using Day17;

var input = "target area: x=248..285, y=-85..-56";

Instruction instruction = Instruction.FromString(input);

var highestPoint = VelocityCalculator.GetHighestPoint(instruction);

Console.WriteLine($"The highest point on a journey to {input} is {highestPoint}");

var distinctVelocities = VelocityCalculator.GetDistinctVelocities(instruction);

Console.WriteLine($"The number of distinct velocities to reach {input} is {distinctVelocities}");