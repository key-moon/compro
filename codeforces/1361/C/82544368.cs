// detail: https://codeforces.com/contest/1361/submission/82544368
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
#if DEBUG
        DateTime realstart = DateTime.Now;
        DateTime start;
        Random rng = new Random(1);
        int n = 500000;
        var ab = Enumerable.Repeat(0, n).Select(_ => new int[] { rng.Next(0, (1 << 20) - 1), rng.Next(0, (1 << 20) - 1) }).ToArray();
        start = DateTime.Now;
        Console.WriteLine((start - realstart).TotalMilliseconds);
        //var ab = Enumerable.Repeat(0, n).Select(_ => new int[] { (1 << 20) - 1, (1 << 20) - 1 }).ToArray();
        //ab[0][0] = (1 << 20) - 2; 
#else
        int n = int.Parse(Console.ReadLine());
        var ab = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
#endif
        for (int k = 20; k >= 0; k--)
        {
            var mask = (1 << k) - 1;
            UnionFind uf = new UnionFind(n * 2);
            Dictionary<int, int> map = new Dictionary<int, int>();
            List<int> count = new List<int>();
            for (int i = 0; i < ab.Length; i++)
            {
                var a = ab[i][0] & mask;
                var b = ab[i][1] & mask;
                if (!map.ContainsKey(a))
                {
                    map.Add(a, count.Count);
                    count.Add(0);
                }
                if (!map.ContainsKey(b))
                {
                    map.Add(b, count.Count);
                    count.Add(0);
                }
                count[map[a]]++;
                count[map[b]]++;
            }
            int[][] categories = new int[count.Count][];
            for (int i = 0; i < categories.Length; i++)
            {
                if (count[i] % 2 != 0) goto impossible;
                categories[i] = new int[count[i]];
            }
            for (int i = 0; i < ab.Length; i++)
            {
                var a = map[ab[i][0] & mask];
                var b = map[ab[i][1] & mask];
                categories[a][--count[a]] = i * 2;
                categories[b][--count[b]] = i * 2 + 1;
                uf.TryUnite(i * 2, i * 2 + 1);
            }
            for (int i = 0; i < categories.Length; i++)
            {
                var init = categories[i][0];
                for (int j = 0; j < categories[i].Length; j++)
                {
                    uf.TryUnite(init, categories[i][j]);
                }
            }
            if (uf.GetSize(0) != 2 * n) goto impossible;

            uf = new UnionFind(2 * n);

            Orb[] orbs = Enumerable.Range(0, 2 * n).Select(x => new Orb() { id = x + 1 }).ToArray();
            for (int i = 0; i < orbs.Length; i += 2)
            {
                orbs[i].Same = orbs[i + 1];
                orbs[i + 1].Same = orbs[i];
                uf.TryUnite(i, i + 1);
            }
            
            for (int i = 0; i < categories.Length; i++)
            {
                for (int j = 0; j < categories[i].Length; j += 2)
                {
                    var a = categories[i][j];
                    var b = categories[i][j + 1];
                    orbs[a].Other = orbs[b];
                    orbs[b].Other = orbs[a];
                    uf.TryUnite(a, b);
                }
            }

            for (int i = 0; i < categories.Length; i++)
            {
                var connectionA = orbs[categories[i][0]];
                var connectionB = orbs[categories[i][1]];
                int connectionElement = categories[i][0];
                for (int j = 2; j < categories[i].Length; j += 2)
                {
                    if (uf.Find(connectionElement) == uf.Find(categories[i][j])) continue;
                    var curA = orbs[categories[i][j]];
                    var curB = orbs[categories[i][j + 1]];
                    connectionA.Other = curA;
                    connectionB.Other = curB;
                    curA.Other = connectionA;
                    curB.Other = connectionB;
                    connectionB = curA;
                    uf.TryUnite(connectionElement, categories[i][j]);
                }
            }

            List<int> res = new List<int>();
            var curNode = orbs[0];
            for (int ctr = 0; ctr < n; ctr++)
            {
                res.Add(curNode.id);
                curNode = curNode.Same;
                res.Add(curNode.id);
                curNode = curNode.Other;
            }

#if DEBUG
            Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
#endif
            Console.WriteLine(k);
            Console.WriteLine(string.Join(" ", res));
            return;
            impossible:;
#if DEBUG
            Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
            start = DateTime.Now;
#endif
        }
        throw new Exception();
    }
}

class Orb
{
    public Orb Other;
    public int id;
    public Orb Same;
    public override string ToString() => $"[{Same.id}-{id}]-{(Other == null ? "-" : Other.id.ToString())}";
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
