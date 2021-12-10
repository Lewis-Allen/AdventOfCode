namespace Day10;

public class LineCalculator
{
    public static char AnalyseForCorruption(char[] line)
    {
        Stack<char> stack = new();
        foreach (var current in line)
        {
            if (current is '<' or '{' or '(' or '[')
                stack.Push(current);

            if (current is '>' or '}' or ')' or ']')
            {
                var last = stack.Pop();
                if (last != GetAlternateCharacter(current))
                    return current;
            }

        }

        return 'N';
    }

    public static int CalculateScoreForCorrupt(string[] lines) => lines
        .Sum(l => GetScoreForInvalidCharacter(AnalyseForCorruption(l.ToCharArray())));

    public static long CalculateScoreForIncomplete(string[] lines)
    {
        var toConsider = lines
            .Where(l => AnalyseForCorruption(l.ToCharArray()) == 'N');

        return toConsider
            .Select(l => GetCompletingString(l.ToCharArray()).Aggregate(0, (long acc, char c) => acc * 5 + GetScoreForIncompleteCharacter(c)))
            .OrderBy(s => s)
            .Skip(toConsider.Count() / 2)
            .First();
    }

    public static string GetCompletingString(char[] line)
    {
        Stack<char> stack = new();
        foreach (var current in line)
        {
            if (current is '<' or '{' or '(' or '[')
                stack.Push(current);

            if (current is '>' or '}' or ')' or ']')
                stack.Pop();
        }

        return string.Join("", stack.Select(c => GetAlternateCharacter(c)).ToArray());
    }

    private static char GetAlternateCharacter(char c) => c switch
    {
        '(' => ')',
        '[' => ']',
        '{' => '}',
        '<' => '>',
        ')' => '(',
        ']' => '[',
        '}' => '{',
        '>' => '<',
        _ => 'N'
    };

    private static int GetScoreForInvalidCharacter(char c) => c switch
    {
        ')' => 3,
        ']' => 57,
        '}' => 1197,
        '>' => 25137,
        _ => 0
    };

    private static int GetScoreForIncompleteCharacter(char c) => c switch
    {
        ')' => 1,
        ']' => 2,
        '}' => 3,
        '>' => 4,
        _ => 0
    };
}
