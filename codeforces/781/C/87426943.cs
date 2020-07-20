// detail: https://codeforces.com/contest/781/submission/87426943
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
        var nmk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmk[0];
        var m = nmk[1];
        var k = nmk[2];

        UnionFind uf = new UnionFind(n);

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            if (uf.TryUnite(st[0], st[1]))
            {
                graph[st[0]].Add(st[1]);
                graph[st[1]].Add(st[0]);
            }
        }
        //全域木
        List<int> tour = new List<int>();
        bool[] arrived = new bool[n];
        int[] pointToTourIndex = Enumerable.Repeat(-1, n).ToArray();
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            while (stack.Count > 0)
            {
                var point = stack.Pop();
                tour.Add(point);
                if (arrived[point]) continue;
                arrived[point] = true;
                foreach (var adj in graph[point])
                {
                    if (arrived[adj]) continue;
                    stack.Push(point);
                    stack.Push(adj);
                }
            }
        }
        var maxTime = (2 * n + k - 1) / k;
        var res = Enumerable.Repeat(0, k).Select(x => new List<int>()).ToArray();
        int curTime = 0;
        int cloneInd = 0;
        for (int i = 0; i < tour.Count; i++)
        {
            res[cloneInd].Add(tour[i]);
            curTime++;
            if (curTime == maxTime)
            {
                curTime = 0;
                cloneInd++;
            }
        }

        Console.WriteLine(string.Join("\n", res.Select(x => x.Count == 0 ? "1 1" : $"{x.Count} {string.Join(" ", x.Select(y => y + 1))}")));
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
