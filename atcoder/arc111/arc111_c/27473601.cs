// detail: https://atcoder.jp/contests/arc111/submissions/27473601
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var p = Console.ReadLine().Split().Select(int.Parse).ToArray();

        bool[] disabled = new bool[n];

        void Check(int ind)
        {
            if (a[ind] <= b[p[ind]]) disabled[ind] = true;
        }
        List<(int, int)> res = new List<(int, int)>();
        void Swap(int a, int b)
        {
            Trace.Assert(!disabled[a] && !disabled[b]);
            (p[a], p[b]) = (p[b], p[a]);
            Check(a);
            Check(b);
            res.Add((a + 1, b + 1));
        }

        UnionFind uf = new UnionFind(n);
        for (int i = 0; i < n; i++)
        {
            p[i]--;
            Check(i);
            uf.TryUnite(i, p[i]);
            if (disabled[i] && i != p[i])
            {
                Console.WriteLine(-1);
                return;
            }
        }

        foreach (var group in Enumerable.Range(0, n).GroupBy(uf.Find))
        {
            int max = -1;
            int maxInd = -1;
            foreach (var i in group)
            {
                if (max < a[i])
                {
                    max = a[i];
                    maxInd = i;
                }
            }
            while (maxInd != p[maxInd])
            {
                Swap(p[maxInd], maxInd);
            }
        }

        Trace.Assert(!p.Where((elem, ind) => elem != ind).Any());

        Console.WriteLine(res.Count);
        Console.WriteLine(string.Join("\n", res.Select(x => $"{x.Item1} {x.Item2}")));
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
