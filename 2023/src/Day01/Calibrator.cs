using System.Text.RegularExpressions;

namespace Day01;

public static partial class Calibrator
{

    public static int GetCalibrationValue(string line)
    {
        char min = default;
        for (var i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
            {
                min = line[i];
                break;
            }
        }

        char max = default;
        for (var i = line.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(line[i]))
            {
                max = line[i];
                break;
            }
        }

        return int.Parse(min.ToString() + max.ToString());
    }

    public static int GetCalibrationValueTotal(string[] lines)
    {
        return lines.Sum(GetCalibrationValue);
    }

    public static int GetRealCalibrationValue(string line)
    {
        HashSet<string> values = [
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        ];

        string min = "";
        for (var i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
            {
                
                min = line[i].ToString();
                break;
            }
            else
            {
                var lineSpan = line.AsSpan();
                foreach (var value in values)
                {
                    if (line.Length - i >= value.Length)
                    {
                        var slice = lineSpan.Slice(i, value.Length);
                        if (slice.SequenceEqual(value))
                        {
                            min = TextToNumber(slice.ToString());
                            break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(min))
                    break;
            }
        }

        string max = "";
        for (var i = line.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(line[i]))
            {
                max = TextToNumber(line[i].ToString());
                break;
            }
            else
            {
                var lineSpan = line.AsSpan();
                foreach (var value in values)
                {
                    if (line.Length - i >= value.Length)
                    {
                        var slice = lineSpan.Slice(i, value.Length);
                        if (slice.SequenceEqual(value))
                        {
                            max = TextToNumber(slice.ToString());
                            break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(max))
                    break;
            }
        }

        return int.Parse(min.ToString() + max.ToString());
    }

    public static int GetRealCalibrationValueTotal(string[] lines)
    {
        return lines.Sum(GetRealCalibrationValue);
    }

    private static string TextToNumber(string text) => text switch
    {
        "one" => "1",
        "two" => "2",
        "three" => "3",
        "four" => "4",
        "five" => "5",
        "six" => "6",
        "seven" => "7",
        "eight" => "8",
        "nine" => "9",
        _ => text
    };
}