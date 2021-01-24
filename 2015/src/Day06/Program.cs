using System;
using System.IO;
using System.Linq;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("../../../Inputs/6.txt");

            LightGridWithoutBrightness lights = new(1000, 1000);

            foreach(var line in lines)
            {
                var (instruction, fromX, fromY, toX, toY) = LightGridWithoutBrightness.ParseInstruction(line);

                lights.PerformOperation(instruction, fromX, fromY, toX, toY);
            }

            Console.WriteLine("Part One---");
            Console.WriteLine(lights.Lights.SelectMany(x => x).Count(x => x));

            LightGridWithBrightness brightnessLights = new(1000, 1000);

            foreach(var line in lines)
            {
                var (instruction, fromX, fromY, toX, toY) = LightGridWithoutBrightness.ParseInstruction(line);

                brightnessLights.PerformOperation(instruction, fromX, fromY, toX, toY);
            }

            Console.WriteLine("Part Two---");
            Console.WriteLine(brightnessLights.Lights.SelectMany(x => x).Sum());
        }
    }
}
