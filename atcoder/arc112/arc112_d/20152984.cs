// detail: https://atcoder.jp/contests/arc112/submissions/20152984
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        var s = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine()).ToArray();
        UnionFind genUF()
        {
            UnionFind uf = new UnionFind(h + w);
            uf.TryUnite(0, h);
            uf.TryUnite(h - 1, h);
            uf.TryUnite(0, h + w - 1);
            uf.TryUnite(h - 1, h + w - 1);
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    if (s[i][j] == '#') uf.TryUnite(i, h + j);
            return uf;
        }
        var uf = genUF();
        var res1 = Enumerable.Range(0, h).Select(uf.Find).GroupBy(x => x).Count() - 1;
        var res2 = Enumerable.Range(h, w).Select(uf.Find).GroupBy(x => x).Count() - 1;
        Console.WriteLine(Min(res1, res2));
    }
}


class UnionFind
{
    public int Size { get; private set; }
    public int GroupCount { get; private set; }
    public IEnumerable<int> AllRepresents => Parent.Where((x, y) => x == y);
    int[] Sizes;
    int[] Parent;
    public UnionFind(int count)
    {
        Size = count;
        GroupCount = count;
        Parent = new int[count];
        Sizes = new int[count];
        for (int i = 0; i < count; i++) Sizes[Parent[i] = i] = 1;
    }
    public bool TryUnite(int x, int y)
    {
        int xp = Find(x);
        int yp = Find(y);
        if (yp == xp) return false;
        if (Sizes[xp] < Sizes[yp]) { var tmp = xp; xp = yp; yp = tmp; }
        GroupCount--;
        Parent[yp] = xp;
        Sizes[xp] += Sizes[yp];
        return true;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetSize(int x) => Sizes[Find(x)];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Find(int x)
    {
        while (x != Parent[x]) x = (Parent[x] = Parent[Parent[x]]);
        return x;
    }
}
