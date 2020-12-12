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
    var magnitude = int.Parse(line.Substring(1, line.Length - 1));

    if(direction == 'N' || direction == 'E' || direction == 'S' || direction == 'W')
    {
        waypointX = direction switch
        {
            'E' => waypointX += magnitude,
            'W' => waypointX -= magnitude,
            _ => waypointX
        };

        waypointY = direction switch
        {
            'N' => waypointY += magnitude,
            'S' => waypointY -= magnitude,
            _ => waypointY
        };
    } 
    else if (direction == 'R' || direction == 'L')
    {
        var directionMagnitude = magnitude / 90;

        for(var i = 0; i < directionMagnitude; i++)
        {
            var beforeX = waypointX;
            var beforeY = waypointY;

            waypointX = direction == 'R' ? beforeY : -beforeY;
            waypointY = direction == 'R' ? -beforeX : beforeX;
        }
    }
    else
    {
        x += waypointX * magnitude;
        y += waypointY * magnitude;
    }
}

Console.WriteLine($"The manhattan distance from zero is the sum of {Math.Abs(x)} and {Math.Abs(y)} which is {Math.Abs(x) + Math.Abs(y)}.");