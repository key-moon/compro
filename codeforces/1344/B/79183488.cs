// detail: https://codeforces.com/contest/1344/submission/79183488
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
        var map = Enumerable.Repeat(0, nm[0]).Select(_ => Console.ReadLine().ToArray()).ToArray();

        bool blankr = false, blankc = false;
        HashSet<int> blankRow = new HashSet<int>();
        HashSet<int> blankColumn = new HashSet<int>();
        for (int i = 0; i < map.Length; i++)
        {
            if (!map[i].Contains('#'))
            {
                blankr = true;
                blankRow.Add(i);
            }
        }
        for (int i = 0; i < map[0].Length; i++)
        {
            if (!map.Select(x => x[i]).Contains('#'))
            {
                blankc = true;
                blankColumn.Add(i);
            }
        }
        if (blankr ^ blankc)
        {
            Console.WriteLine(-1);
            return;
        }
        n -= blankRow.Count;
        m -= blankColumn.Count;

        List<int>[] graph = Enumerable.Repeat(0, n * m).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < m; j++)
            { var id = i * m + j; graph[id].Add(id + m); graph[id + m].Add(id); }
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m - 1; j++)
            { var id = i * m + j; graph[id].Add(id + 1); graph[id + 1].Add(id); }
        UnionFind uf = new UnionFind(graph.Length + 1);
        map = map.Where((_, ind) => !blankRow.Contains(ind)).Select(x => x.Where((_, ind) => !blankColumn.Contains(ind)).ToArray()).ToArray();

        if (n == 0 && m == 0)
        {
            Console.WriteLine(0);
            return;
        }

        for (int i = 0; i < map.Length; i++)
        {
            if (map[i].SkipWhile(x => x == '.').SkipWhile(x => x == '#').Contains('#'))
            {
                Console.WriteLine(-1);
                return;
            }
        }
        for (int i = 0; i < map[0].Length; i++)
        {
            if (map.Select(x => x[i]).SkipWhile(x => x == '.').SkipWhile(x => x == '#').Contains('#'))
            {
                Console.WriteLine(-1);
                return;
            }
        }

        var s = map.SelectMany(x => x).ToArray();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '.') uf.TryUnite(i, n * m);
        }
        for (int i = 0; i < graph.Length; i++)
        {
            if (s[i] != '#') continue;
            foreach (var adj in graph[i])
            {
                if (s[adj] == '#') uf.TryUnite(i, adj);
            }
        }
        Console.WriteLine(uf.GroupCount - 1);
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