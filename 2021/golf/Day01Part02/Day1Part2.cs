var i=Array.ConvertAll(File.ReadAllLines("1"),int.Parse);

Console.Write(Enumerable.Range(3,i.Length-3)
    .Count(a=>i[a]+i[a-1]+i[a-2]>i[a-1]+i[a-2]+i[a-3]));