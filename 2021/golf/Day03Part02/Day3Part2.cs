var f=File.ReadLines("3");

int s(string[]b,int i)=>b.Count(c=>c[i]<49)>b.Length/2?1:0;

int r(string[]b,bool k)
{
    for(int j=0;b.Length>1;j++)
        b=b.Where(o=>k==(o[j]==49-s(b,j))).ToArray();

    return Convert.ToInt32(b[0],2);
}
Console.WriteLine(r(f.ToArray(),1>0)*r(f.ToArray(),0>1));