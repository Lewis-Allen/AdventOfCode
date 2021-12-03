var i=File.ReadLines("1").Select(int.Parse).ToArray();

Console.Write(Enumerable.Range(3,i.Length-3)
    .Count(a=>i[a]+i[a-1]+i[a-2]>i[a-1]+i[a-2]+i[a-3]));