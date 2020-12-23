using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

List<int> input = File.ReadAllText("../../../Input.txt").ToCharArray().Select(n => n - '0').ToList();

List<int> numbers = new(input);
int currentCup = numbers[0];

int movesCompleted = 0;

while(movesCompleted < 100)
{
    var currentIndex = numbers.FindIndex(c => c == currentCup);

    List<int> removedCups = new();
    for(int i = 0; i < 3; i++)
    {
        var removeIndex = (currentIndex + 1) % numbers.Count;
        var number = numbers[removeIndex];
        removedCups.Add(number);
        numbers.RemoveAt(removeIndex);
        currentIndex = numbers.FindIndex(c => c == currentCup);
    }

    int destinationIndex = numbers.IndexOf(currentCup - 1 < numbers.Min() ? numbers.Max() : numbers.Where(n => n < currentCup).Max());

    numbers.InsertRange(destinationIndex + 1, removedCups);

    currentCup = numbers[(numbers.FindIndex(c => c == currentCup) + 1) % numbers.Count];

    movesCompleted++;
}

var startPos = numbers.IndexOf(1);
StringBuilder sb = new();
for(int i = startPos; i < startPos + 8; i++)
{
    sb.Append(numbers[(i + 1) % numbers.Count]);
}
Console.WriteLine(string.Join("", sb.ToString()));