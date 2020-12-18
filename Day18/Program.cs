using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/**
 * Note for next time - Google 'parse infix expression' and look at the first result. (Shunting-yard algorithm)
 * It's so much nicer than what I did here.
 */

var lines = File.ReadAllLines("../../../Input.txt");

// Printing examples then Sum of all items in file.
Console.WriteLine("Part One: -------------------------------");
Console.WriteLine($"1 + (2 * 3) + (4 * (5 + 6)) = {CalculateSegment("1 + (2 * 3) + (4 * (5 + 6))")}");
Console.WriteLine($"2 * 3 + (4 * 5) = {CalculateSegment("2 * 3 + (4 * 5)")}");
Console.WriteLine($"5 + (8 * 3 + 9 + 3 * 4 * 3) = {CalculateSegment("5 + (8 * 3 + 9 + 3 * 4 * 3)")}");
Console.WriteLine($"5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4)) = {CalculateSegment("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))")}");
Console.WriteLine($"((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2 = {CalculateSegment("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2")}");
Console.WriteLine($"Sum of all Values is {lines.Sum(l => CalculateSegment(l))}");

Console.WriteLine();

Console.WriteLine("Part Two: -------------------------------");
Console.WriteLine($"1 + (2 * 3) + (4 * (5 + 6)) = {CalculateSegment(TransformLine("1 + (2 * 3) + (4 * (5 + 6))"))}");
Console.WriteLine($"2 * 3 + (4 * 5) = {CalculateSegment(TransformLine("2 * 3 + (4 * 5)"))}");
Console.WriteLine($"5 + (8 * 3 + 9 + 3 * 4 * 3) = {CalculateSegment(TransformLine("5 + (8 * 3 + 9 + 3 * 4 * 3)"))}");
Console.WriteLine($"5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4)) = {CalculateSegment(TransformLine("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))"))}");
Console.WriteLine($"((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2 = {CalculateSegment(TransformLine("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2"))}");
Console.WriteLine($"Sum of all Values is {lines.Sum(l => CalculateSegment(TransformLine(l)))}");

/**
 * This will take a line and calculate a result, giving precedence to brackets then left to right.
 * Brackets are worked out recursively.
 */
static long CalculateSegment(string line)
{
    long acc = 0;
    line = line.Replace(" ", "");
    Operator currentOperator = Operator.PLUS;

    for(int i = 0; i < line.Length; i++)
    {
        char currentCharacter = line[i];
        switch(currentCharacter)
        {
            case '+':
                currentOperator = Operator.PLUS;
                break;
            case '*':
                currentOperator = Operator.MULTIPLY;
                break;
            case '(':
                int closingBracket = FindClosingBracket(line, i);
                acc = Operate(acc, CalculateSegment(line[(i + 1)..closingBracket]), currentOperator);
                i = closingBracket;
                break;
            default:
                acc = Operate(acc, int.Parse(currentCharacter.ToString()), currentOperator);
                break;
        }
    }

    return acc;
}

/**
 * This function takes a line and wraps every + operation in brackets to give it precedence.
 * The line can then be calculated using the above CalculateSegment function.
 */
static string TransformLine(string line)
{
    line = line.Replace(" ", "");

    List<char> lineList = new(line);

    int currentChar = -1;

    while(new string(lineList.ToArray()).IndexOf('+', currentChar + 1) != -1)
    {
        currentChar = new string(lineList.ToArray()).IndexOf('+', currentChar + 1);

        if (lineList[currentChar + 1] != '(')
        {
            lineList.Insert(currentChar + 2, ')');
        }
        else
        {
            int closingIndex = FindClosingBracket(new string(lineList.ToArray()), currentChar + 1);

            lineList.Insert(closingIndex + 1, ')');
        }

        if (lineList[currentChar - 1] != ')')
        {
            lineList.Insert(currentChar - 1, '(');
        }
        else
        {
            int openingIndex = FindOpeningBracket(new string(lineList.ToArray()), currentChar - 1);

            lineList.Insert(openingIndex, '(');
        }
        currentChar++;
    }

    return new string(lineList.ToArray());
}

static int FindClosingBracket(string line, int index)
{
    int depth = 0;
    for(int i = index; i < line.Length; i++)
    {
        char currentChar = line[i];
        if (currentChar == '(')
            depth++;

        if (currentChar == ')')
            depth--;

        if (currentChar == ')' && depth == 0)
            return i;
    }
    return -1;
}

static int FindOpeningBracket(string line, int index)
{
    int depth = 0;
    for (int i = index; i >= 0; i--)
    {
        char currentChar = line[i];
        if (currentChar == ')')
            depth++;

        if (currentChar == '(')
            depth--;

        if (currentChar == '(' && depth == 0)
            return i;
    }
    return -1;
}

static long Operate(long acc, long amt, Operator operation) => operation switch
{
    Operator.PLUS => acc + amt,
    Operator.MULTIPLY => acc * amt,
};

enum Operator
{
    PLUS,
    MULTIPLY
}

