var i=File.ReadLines("1").Select(int.Parse).ToList();

Console.Write(Enumerable.Range(1,i.Count-1)
    .Count(a=>i[a]>i[a-1]));