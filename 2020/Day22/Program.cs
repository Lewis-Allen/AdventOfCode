using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllText("../../../Input.txt")
    .Split("\r\n\r\n")
    .Select(s => s.Split("\r\n").Skip(1).ToArray())
    .Select(k => new Queue<long>(Array.ConvertAll(k, long.Parse)))
    .ToArray();

Queue<long> p1 = new(lines[0]);
Queue<long> p2 = new(lines[1]);

// Part One
while(p1.Count > 0 && p2.Count > 0)
{
    long p1current = p1.Dequeue();
    long p2current = p2.Dequeue();

    if(p1current > p2current)
    {
        p1.Enqueue(p1current);
        p1.Enqueue(p2current);
    }
    else
    {
        p2.Enqueue(p2current);
        p2.Enqueue(p1current);
    }
}

long acc = 0;
Queue<long> winner = p1.Count > 0 ? p1 : p2;
for (int i = winner.Count - 1; i >= 0; i--)
{
    acc += winner.ElementAt(i) * (winner.Count - i);
}

Console.WriteLine($"Part 1: The winning player's score is {acc}.");

// Part Two
(bool winningPlayer, Queue<long> winningDeck) = RecursiveCombat(new(lines[0]), new(lines[1]));

acc = 0;
for (int i = winningDeck.Count - 1; i >= 0; i--)
{
    acc += winningDeck.ElementAt(i) * (winningDeck.Count - i);
}

Console.WriteLine($"Game 2: The winning player's score is {acc}.");

/// <summary>
/// Returns whether P1 won and the winning deck.
/// </summary>
static (bool, Queue<long>) RecursiveCombat(Queue<long> p1, Queue<long> p2)
{
    List<Queue<long>> p1history = new();
    List<Queue<long>> p2history = new();

    bool p1winner = false;
    while (p1.Count > 0 && p2.Count > 0)
    {
        if (p1history.Any(s => Enumerable.SequenceEqual(p1, s)) &&
           p2history.Any(s => Enumerable.SequenceEqual(p2, s)))
        {
            p1winner = true;
            break;
        }

        p1history.Add(new(p1));
        p2history.Add(new(p2));

        long p1current = p1.Dequeue();
        long p2current = p2.Dequeue();

        if(p1.Count >= p1current && p2.Count >= p2current)
        {
            Queue<long> p1Copy = new(p1.Take((int)p1current));
            Queue<long> p2Copy = new(p2.Take((int)p2current));
            
            p1winner = RecursiveCombat(p1Copy, p2Copy).Item1;
        }
        else
        {
            p1winner = p1current > p2current;
        }

        if (p1winner)
        {
            p1.Enqueue(p1current);
            p1.Enqueue(p2current);
        }
        else
        {
            p2.Enqueue(p2current);
            p2.Enqueue(p1current);
        }
    }

    return (p1winner, p1winner ? p1 : p2);
}