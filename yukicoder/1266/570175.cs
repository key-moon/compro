// detail: https://yukicoder.me/submissions/570175
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
        var nmq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmq[0];
        var m = nmq[1];
        var q = nmq[2];
        UnionFind uf = new UnionFind(n * 7);
        bool[][] colors = new bool[n][];
        for (int i = 0; i < n; i++)
        {
            var s = Console.ReadLine();
            colors[i] = s.Select(x => x == '1').ToArray();
            for (int j = 0; j < 7; j++)
            {
                var next = (j + 1) % 7;
                if (colors[i][j] && colors[i][next]) uf.TryUnite(j * n + i, next * n + i);
            }
        }
        List<int>[] edges = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var uv = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int u = uv[0] - 1, v = uv[1] - 1;
            edges[u].Add(v);
            edges[v].Add(u);
            for (int j = 0; j < 7; j++)
            {
                if (colors[u][j] && colors[v][j]) uf.TryUnite(j * n + v, j * n + u);
            }
        }
        for (int i = 0; i < q; i++)
        {
            var txy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var t = txy[0];
            var x = txy[1] - 1;
            var y = txy[2] - 1;
            if (t == 1)
            {
                colors[x][y] = true;
                var prev = (y + 6) % 7;
                var next = (y + 1) % 7;
                if (colors[x][prev] && colors[x][y]) uf.TryUnite(prev * n + x, y * n + x);
                if (colors[x][y] && colors[x][next]) uf.TryUnite(y * n + x, next * n + x);
                foreach (var adj in edges[x])
                {
                    if (colors[adj][y]) uf.TryUnite(y * n + x, y * n + adj);
                }
            }
            else
            {
                Console.WriteLine(uf.GetSize(x));
            }
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
