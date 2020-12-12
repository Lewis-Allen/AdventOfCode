using System;
using System.IO;

var lines = File.ReadAllLines("../../../Input.txt");

var waypointX = 10;
var waypointY = 1;
var x = 0;
var y = 0;

foreach(var line in lines)
{
    var direction = line[0];
    var magnitude = int.Parse(line[1..]);

    switch(direction)
    {
        case 'N':
            waypointY += magnitude;
            break;
        case 'E':
            waypointX += magnitude;
            break;
        case 'S':
            waypointY -= magnitude;
            break;
        case 'W':
            waypointX -= magnitude;
            break;
        case 'R':
            for (var i = 0; i < magnitude / 90; i++)
            {
                var beforeX = waypointX;
                var beforeY = waypointY;

                waypointX = beforeY;
                waypointY = -beforeX;
            }
            break;
        case 'L':
            for (var i = 0; i < magnitude / 90; i++)
            {
                var beforeX = waypointX;
                var beforeY = waypointY;

                waypointX = -beforeY;
                waypointY = beforeX;
            }
            break;
        case 'F':
            x += waypointX * magnitude;
            y += waypointY * magnitude;
            break;
    }
}

Console.WriteLine($"The manhattan distance from zero is the sum of {Math.Abs(x)} and {Math.Abs(y)} which is {Math.Abs(x) + Math.Abs(y)}.");