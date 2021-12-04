var f=File.ReadLines("3");

int r(string[]b,bool k)
{
    for(int j=0;b.Length>1;j++)
        b=b.Where(o=>k==(o[j]<49==(b.Count(c=>c[j]<49)>b.Length/2))).ToArray();

    return Convert.ToInt32(b[0],2);
}
Console.Write(r(f.ToArray(),1>0)*r(f.ToArray(),0>1));