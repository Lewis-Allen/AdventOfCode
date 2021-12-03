// Not done yet...
var i = File.ReadAllLines("2")
    .ToArray();

Console.WriteLine(i.Sum(a => a[0] == 'f' ? a[^1] - '0' : 0) * i.Sum(a => a[0] == 'd' ? a[^1] - '0' : a[0] == 'u' ? -(a[^1] - '0') : 0));