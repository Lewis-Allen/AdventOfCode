using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day06
{
    public class LightGridWithBrightness
    {
        public int[][] Lights { get; private set; }

        public LightGridWithBrightness(int width, int height)
        {
            Lights = new int[height][];

            for(var i = 0; i < Lights.Length; i++)
            {
                Lights[i] = new int[width];
            }
        }

        public LightGridWithBrightness(int[][] lights)
        {
            Lights = lights;
        }

        public int[][] PerformOperation(Instruction instruction, int fromX, int fromY, int toX, int toY)
        {
            switch (instruction)
            {
                case Instruction.SWITCH_ON:
                    return Set(true, fromX, fromY, toX, toY);
                case Instruction.SWITCH_OFF:
                    return Set(false, fromX, fromY, toX, toY);
                case Instruction.TOGGLE:
                    return Toggle(fromX, fromY, toX, toY);
            }

            throw new Exception($"PerformOperation - Invalid Instruction {instruction}");
        }

        public int[][] Set(bool turnOn, int fromX, int fromY, int toX, int toY)
        {
            for(int y = fromY; y <= toY; y++)
            {
                for(int x = fromX; x <= toX; x++)
                {
                    Lights[y][x] = turnOn ? Lights[y][x] + 1 : (Lights[y][x] <= 0 ? 0 : Lights[y][x] - 1);
                }
            }
            return Lights;
        }

        public int[][] Toggle(int fromX, int fromY, int toX, int toY)
        {
            for (int y = fromY; y <= toY; y++)
            {
                for (int x = fromX; x <= toX; x++)
                {
                    Lights[y][x] = Lights[y][x] + 2;
                }
            }
            return Lights;
        }

        public static (Instruction, int, int, int, int) ParseInstruction(string input)
        {
            Instruction instruction;
            if(input.StartsWith("turn off"))
            {
                instruction = Instruction.SWITCH_OFF;
            }
            else if(input.StartsWith("turn on"))
            {
                instruction = Instruction.SWITCH_ON;
            }
            else
            {
                instruction = Instruction.TOGGLE;
            }

            var nums = Regex.Matches(input, "\\d+");
            return (instruction, int.Parse(nums[0].Value), int.Parse(nums[1].Value), int.Parse(nums[2].Value), int.Parse(nums[3].Value));
        }
    }
}
