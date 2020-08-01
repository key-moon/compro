// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2014/judge/4728072/C#
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
    const int PACKET_SIZE = 512;
    public static void Main()
    {
        while (true)
        {
            var wh = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var w = wh[0];
            var h = wh[1];
            if (w == 0) break;

            var map = Enumerable.Repeat(0, h).SelectMany(_ => Console.ReadLine()).ToArray();

            List<int>[] graph = Enumerable.Repeat(0, h * w).Select(_ => new List<int>()).ToArray();
            for (int i = 0; i < h - 1; i++)
                for (int j = 0; j < w; j++)
                { var id = i * w + j; graph[id].Add(id + w); graph[id + w].Add(id); }
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w - 1; j++)
                { var id = i * w + j; graph[id].Add(id + 1); graph[id + 1].Add(id); }

            int[] flag = new int[w * h];
            UnionFind uf = new UnionFind(w * h);
            for (int i = 0; i < graph.Length; i++)
            {
                if (map[i] != '.') continue;
                foreach (var j in graph[i])
                {
                    if (map[j] == '.')
                    {
                        uf.TryUnite(i, j);
                    }
                    if (map[j] == 'B')
                    {
                        flag[i] |= 1;
                    }
                    if (map[j] == 'W')
                    {
                        flag[i] |= 2;
                    }
                }
            }

            int res1 = 0;
            int res2 = 0;
            foreach (var item in Enumerable.Range(0, w * h).GroupBy(x => uf.Find(x)))
            {
                var count = item.Count();
                var a = item.Aggregate(0, (x, y) => x | flag[y]);
                if (a == 1) res1 += count;
                if (a == 2) res2 += count;
            }

            Console.WriteLine($"{res1} {res2}");
        }
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


