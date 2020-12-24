using C5;
using Day23;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

List<long> input = File.ReadAllText("../../../Input.txt").ToCharArray().Select(n => (long)(n - '0')).ToList();

List<long> numbers = new(input);
long currentCup = numbers[0];

long movesCompleted = 0;

while(movesCompleted < 100)
{
    var currentIndex = numbers.FindIndex(c => c == currentCup);

    List<long> removedCups = new();
    for(int i = 0; i < 3; i++)
    {
        int removeIndex = (currentIndex + 1) % numbers.Count;
        long number = numbers[removeIndex];
        removedCups.Add(number);
        numbers.RemoveAt(removeIndex);
        currentIndex = numbers.FindIndex(c => c == currentCup);
    }

    int destinationIndex = numbers.IndexOf(currentCup - 1 < numbers.Min() ? numbers.Max() : numbers.Where(n => n < currentCup).Max());

    numbers.InsertRange(destinationIndex + 1, removedCups);

    currentCup = numbers[(numbers.FindIndex(c => c == currentCup) + 1) % numbers.Count];

    movesCompleted++;
    Console.WriteLine(movesCompleted);
}

var startPos = numbers.IndexOf(1);
StringBuilder sb = new();
for(int i = startPos; i < startPos + 8; i++)
{
    sb.Append(numbers[(i + 1) % numbers.Count]);
}
Console.WriteLine(string.Join("", sb.ToString()));

// Part Two
const long MAX_ELEMENTS = 1000000;
const long NO_OF_MOVES = 10000000;

TreeDictionary<long, MyLinkedListNode<long>> NodeLocations = new();

MyLinkedListNode<long> head = new(input[0]);
NodeLocations.Add(head.Value, head);

var current = head;

for (int i = 1; i < input.Count; i++)
{
    current.Next = new (input[i]);
    NodeLocations.Add(current.Next.Value, current.Next);
    current = current.Next;
}

for (long i = 10; i <= MAX_ELEMENTS; i++)
{
    MyLinkedListNode<long> newNode = new(i);
    if(i == 10)
    {
        NodeLocations[input[8]].Next = newNode;
    }
    else
    {
        NodeLocations[i - 1].Next = newNode;
    }
    NodeLocations[i] = newNode;
}
NodeLocations[MAX_ELEMENTS].Next = head;

var currentNode = head;
movesCompleted = 0;
while(movesCompleted < NO_OF_MOVES)
{
    List<long> nextThree = new()
    {
        currentNode.Next.Value,
        currentNode.Next.Next.Value,
        currentNode.Next.Next.Next.Value
    };

    long? predecessorValue = null;
    long valueToCheck = currentNode.Value;

    while(predecessorValue == null)
    {
        if(NodeLocations.TryPredecessor(valueToCheck, out var predecessor))
        {
            var value = predecessor.Value.Value;
            if(nextThree.Contains(predecessor.Value.Value))
            {
                valueToCheck = value;
            }
            else
            {
                predecessorValue = value;
            }
        }
        else
        {
            valueToCheck = MAX_ELEMENTS + 1;
        }
    }

    MyLinkedListNode<long> destination = NodeLocations[(long)predecessorValue];

    var destNext = destination.Next;
    var currentNodeNextNextNextNext = currentNode.Next.Next.Next.Next;
    var currentNodeNext = currentNode.Next;

    destination.Next = currentNodeNext; 
    destination.Next.Next.Next.Next = destNext;
    currentNode.Next = currentNodeNextNextNextNext;

    currentNode = currentNode.Next;

    movesCompleted++;
}

var final = NodeLocations[1];
long res = final.Next.Value * final.Next.Next.Value;
Console.WriteLine(res);