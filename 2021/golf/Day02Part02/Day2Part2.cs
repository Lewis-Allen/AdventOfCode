var i=File.ReadLines("2");

int d,p,a,v,c;
d=p=a=0;
foreach(var j in i)
{
    v=j[^1]-48;
    c=j[0];

    if(c=='f')
    {
        p+=v;
        d+=a*v;
    }

    a+=c<101?v:c>116?-v:0;
}

Console.Write(d*p);