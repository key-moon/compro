// detail: https://codeforces.com/contest/788/submission/88792202
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];

        bool[] hasEdge = new bool[n];
        int[] counts = new int[n];

        long loop = 0;

        UnionFind uf = new UnionFind(n);

        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            hasEdge[st[0]] = true;
            hasEdge[st[1]] = true;
            if (st[0] == st[1])
            {
                loop++;
                continue;
            }

            counts[st[0]]++;
            counts[st[1]]++;
            uf.TryUnite(st[0], st[1]);
        }

        var alone = hasEdge.Count(x => !x);

        if (uf.GroupCount - alone != 1)
        {
            Console.WriteLine(0);
            return;
        }

        long res = 0;
        foreach (var count in counts)
        {
            res += (count - 1L) * count / 2;
        }
        res += loop * (m - loop);
        res += loop * (loop - 1) / 2;
        Console.WriteLine(res);
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
