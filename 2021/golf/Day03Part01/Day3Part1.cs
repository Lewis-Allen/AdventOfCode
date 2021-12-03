var f=File.ReadLines("3")
    .ToList();

int g,e,i,a;
for(g=e=i=0;i<f[0].Length;i++)
{
    var c=f.Count(b=>b[i]==48)>f.Count/2;

    a=c?1:0;
    g=(g<<1)+a^1;
    e=(e<<1)+a;
}

Console.Write(g*e);