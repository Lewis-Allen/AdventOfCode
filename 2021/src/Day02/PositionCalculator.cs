namespace Day02;

public class PositionCalculator
{
    // Part One
    public static int GetFinalDepthByFinalPosition(string[] instructions)
    {
        int depth = 0;
        int position = 0;

        foreach(string instruction in instructions)
        {
            int val = instruction[^1] - '0';

            switch(instruction[0])
            {
                case 'f':
                    position += val;
                    break;

                case 'd':
                    depth += val;
                    break;

                case 'u':
                    depth -= val;
                    break;
            }
        }

        return depth * position;
    }

    // Part Two
    public static int GetFinalDepthByFinalPositionWithAim(string[] instructions)
    {
        int depth = 0;
        int position = 0;
        int aim = 0;

        foreach (string instruction in instructions)
        {
            int val = instruction[^1] - '0';

            switch (instruction[0])
            {
                case 'f':
                    position += val;
                    depth += aim * val;
                    break;

                case 'd':
                    aim += val;
                    break;

                case 'u':
                    aim -= val;
                    break;
            }
        }

        return depth * position;
    }
}
