// detail: https://atcoder.jp/contests/arc111/submissions/19283960
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
        bool[,] res = new bool[n, n];
        (int, int)[] edges = new (int, int)[m];
        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            edges[i] = (st[0], st[1]);
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }
        var c = Console.ReadLine().Split().Select(int.Parse).ToArray();
        
        UnionFind uf = new UnionFind(n);
        foreach (var (a, b) in edges)
        {
            if (c[a] == c[b]) uf.TryUnite(a, b);
            else
            {
                if (c[a] > c[b]) res[a, b] = true;
                else res[b, a] = true;
            }
        }
        
        List<(int, int)> groups = new List<(int, int)>();
        foreach (var group in Enumerable.Range(0, n).GroupBy(uf.Find))
        {
            var key = group.Key;
            var groupSet = group.ToHashSet();
            bool[] arrived = new bool[n];
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((groupSet.First(), -1));
            while (stack.Count != 0)
            {
                var (elem, prev) = stack.Pop();
                if (prev != -1 && !res[elem, prev] && !res[prev, elem]) res[prev, elem] = true;
                if (arrived[elem]) continue;
                arrived[elem] = true;
                foreach (var adj in graph[elem])
                {
                    if (!groupSet.Contains(adj)) continue;
                    if (arrived[adj])
                    {
                        if (!res[adj, elem]) res[elem, adj] = true;
                    }
                    else stack.Push((adj, elem));
                }
            }
        }

        foreach (var (a, b) in edges)
        {
            if (res[a, b]) Console.WriteLine("->");
            else if (res[b, a]) Console.WriteLine("<-");
            else throw new Exception();
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
