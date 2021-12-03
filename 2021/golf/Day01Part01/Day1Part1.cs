var i = Array.ConvertAll(File.ReadAllLines("1"), int.Parse);

Console.Write(Enumerable.Range(1, i.Length - 1)
    .Count(a => i[a] > i[a - 1]));