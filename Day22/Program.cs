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
    var p1current = p1.Dequeue();
    var p2current = p2.Dequeue();

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
var winner = p1.Count > 0 ? p1 : p2;
for (int i = winner.Count - 1; i >= 0; i--)
{
    acc += winner.ElementAt(i) * (winner.Count - i);
}

Console.WriteLine($"Part 1: The winning player's score is {acc}.");

// Part Two
var (winningPlayer, winningDeck) = PlayGame(new(lines[0]), new(lines[1]));

acc = 0;
for (int i = winningDeck.Count - 1; i >= 0; i--)
{
    acc += winningDeck.ElementAt(i) * (winningDeck.Count - i);
}

Console.WriteLine($"Game 2: The winning player's score is {acc}.");

/// <summary>
/// Returns whether P1 won and the deck.
/// </summary>
static (bool, Queue<long>) PlayGame(Queue<long> p1, Queue<long> p2)
{
    List<Queue<long>> p1History = new();
    List<Queue<long>> p2History = new();

    bool p1winner = false;
    while (p1.Count > 0 && p2.Count > 0)
    {
        if (p1History.Any(s => Enumerable.SequenceEqual(p1, s)) &&
           p2History.Any(s => Enumerable.SequenceEqual(p2, s)))
        {
            p1winner = true;
            break;
        }

        p1History.Add(new(p1));
        p2History.Add(new(p2));

        var p1Current = p1.Dequeue();
        var p2Current = p2.Dequeue();

        if(p1.Count >= p1Current && p2.Count >= p2Current)
        {
            Queue<long> p1Copy = new();
            Queue<long> p2Copy = new();

            for (int i = 0; i < p1Current; i++)
            {
                p1Copy.Enqueue(p1.ElementAt(i));
            }
            for (int i = 0; i < p2Current; i++)
            {
                p2Copy.Enqueue(p2.ElementAt(i));
            }
            p1winner = PlayGame(new(p1Copy), new(p2Copy)).Item1;
        }
        else
        {
            p1winner = p1Current > p2Current;
        }

        if (p1winner)
        {
            p1.Enqueue(p1Current);
            p1.Enqueue(p2Current);
        }
        else
        {
            p2.Enqueue(p2Current);
            p2.Enqueue(p1Current);
        }
    }

    return (p1winner, p1winner ? p1 : p2);
}