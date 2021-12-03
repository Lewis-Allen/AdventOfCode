var i=File.ReadLines("1").Select(int.Parse).ToArray();

Console.Write(Enumerable.Range(1,i.Length-1)
    .Count(a=>i[a]>i[a-1]));