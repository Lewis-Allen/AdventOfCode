var i=File.ReadLines("2");

Console.Write(i.Sum(a=>a[0]=='f'?a[^1]-48:0)*i.Sum(a=>a[0]=='d'?a[^1]-48:a[0]=='u'?-(a[^1]-48):0));