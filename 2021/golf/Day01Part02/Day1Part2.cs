var i=File.ReadLines("1").Select(int.Parse).ToList();

Console.Write(Enumerable.Range(3,i.Count-3)
    .Count(a=>i[a]+i[a-1]+i[a-2]>i[a-1]+i[a-2]+i[a-3]));