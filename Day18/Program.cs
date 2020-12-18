using System;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../Input.txt");

Console.WriteLine($"1 + (2 * 3) + (4 * (5 + 6)) = {CalculateLine("1 + (2 * 3) + (4 * (5 + 6))")}");
Console.WriteLine($"2 * 3 + (4 * 5) = {CalculateLine("2 * 3 + (4 * 5)")}");
Console.WriteLine($"5 + (8 * 3 + 9 + 3 * 4 * 3) = {CalculateLine("5 + (8 * 3 + 9 + 3 * 4 * 3)")}");
Console.WriteLine($"5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4)) = {CalculateLine("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))")}");
Console.WriteLine($"((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2 = {CalculateLine("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2")}");

Console.WriteLine($"Sum of all Values is {lines.Sum(l => CalculateLine(l))}");
static long CalculateLine(string line)
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
            case '-':
                currentOperator = Operator.MINUS;
                break;
            case '*':
                currentOperator = Operator.MULTIPLY;
                break;
            case '/':
                currentOperator = Operator.DIVIDE;
                break;
            case '(':
                int closingBracket = FindClosingBracket(line, i);
                acc = Operate(acc, CalculateLine(line[(i+1)..closingBracket]), currentOperator);
                i = closingBracket;
                break;
            default:
                acc = Operate(acc, int.Parse(currentCharacter.ToString()), currentOperator);
                break;
        }
    }

    return acc;
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


static long Operate(long acc, long amt, Operator operation)
{
    return operation switch
    {
        Operator.PLUS => acc + amt,
        Operator.MINUS => acc - amt,
        Operator.MULTIPLY => acc * amt,
        Operator.DIVIDE => acc / amt
    };
}

enum Operator
{
    PLUS,
    MINUS,
    MULTIPLY,
    DIVIDE
}

