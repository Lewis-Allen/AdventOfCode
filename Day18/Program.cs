using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../Input.txt");

// Part One
Console.WriteLine($"Sum of all Values is {lines.Sum(l => Evaluate(ShuntingYard(l, s => 0)))}");

// Part Two
Console.WriteLine($"Sum of all Values is {lines.Sum(l => Evaluate(ShuntingYard(l, s => s == '+' ? 1 : 0)))}");

/**
 *  Post fix stack evaluator.
 *  Input file only contains + and * so I don't account for anything else.
 */
static long Evaluate(Queue<char> things)
{
    Stack<long> stack = new();

    while(things.Count > 0)
    {
        char token = things.Dequeue();

        if (char.IsDigit(token))
        {
            stack.Push(long.Parse(token.ToString()));
        }
        else
        {
            long a = long.Parse(stack.Pop().ToString());
            long b = long.Parse(stack.Pop().ToString());

            if (token is '*')
                stack.Push(b * a);
            else
                stack.Push(b + a);
        }
    }
    return stack.Pop();
}

/**
 * Parses an infix notation string into postfix notation.
 */
static Queue<char> ShuntingYard(string line, Func<char, int> precedence)
{
    line = line.Replace(" ", "");
    
    Stack<char> operatorStack = new();
    Queue<char> outputQueue = new();

    foreach (char token in line)
    {
        if (char.IsDigit(token))
        {
            outputQueue.Enqueue(token);
        } 
        else if (token is '*' or '+')
        {
            while(operatorStack.Count > 0 && 
                  precedence(operatorStack.Peek()) >= precedence(token) && 
                  operatorStack.Peek() is not '(')
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }

            operatorStack.Push(token);
        }
        else if (token is '(')
        {
            operatorStack.Push(token);
        }
        else if (token is ')')
        {
            while(operatorStack.Peek() is not '(')
                outputQueue.Enqueue(operatorStack.Pop());

            if (operatorStack.Peek() is '(')
                operatorStack.Pop();
        }

    }

    while(operatorStack.Count > 0)
        outputQueue.Enqueue(operatorStack.Pop());

    return outputQueue;
}