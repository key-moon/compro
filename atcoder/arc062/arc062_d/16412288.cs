// detail: https://atcoder.jp/contests/arc062/submissions/16412288
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
        var color = nmk[2];

        ModInt[] pow = new ModInt[m + 1];
        pow[0] = 1;
        for (int i = 1; i <= m; i++)
            pow[i] = pow[i - 1] * color;

        ModInt[] nonSimpleCyclePerms = new ModInt[m + 1];
        nonSimpleCyclePerms[0] = 1;
        for (int i = 0; i < color; i++)
            for (int j = nonSimpleCyclePerms.Length - 1; j >= 0; j--)
                for (int k = nonSimpleCyclePerms.Length - 1; k > j; k--)
                    nonSimpleCyclePerms[k] += nonSimpleCyclePerms[j];

        ModInt[] simpleCyclePerms = new ModInt[m + 1];
        {
            for (int size = 1; size <= m; size++)
            {
                ModInt[] perms = new ModInt[size + 1];
                for (int i = 1; i <= size; i++)
                {
                    if (size % i != 0) continue;
                    perms[i] += pow[i];
                    for (int j = i * 2; j <= size; j += i)
                        perms[j] -= perms[i];
                    perms[i] /= i;
                }
                simpleCyclePerms[size] =
                    perms
                    .Where((_, ind) => ind == 0 || size % ind == 0)
                    .Aggregate((ModInt)0, (x, y) => x + y);
            }
        }

        var edges = Enumerable.Repeat(0, m).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => (x[0] - 1, x[1] - 1)).ToArray();

        int cycleCount = 0;
        ModInt res = 1;
        while (edges.Length != 0)
        {
            bool[][] sameGroup = Enumerable.Repeat(0, n).Select(_ => Enumerable.Repeat(true, n).ToArray()).ToArray();

            int groupCount;
            {
                UnionFind uf = new UnionFind(n);
                foreach (var (s, t) in edges)
                    uf.TryUnite(s, t);
                groupCount = uf.GroupCount;
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        sameGroup[i][j] &= uf.Find(i) == uf.Find(j);
            }

            HashSet<int> articulate = new HashSet<int>();
            for (int targetNode = 0; targetNode < n; targetNode++)
            {
                UnionFind uf = new UnionFind(n);
                int count = 0;
                foreach (var (s, t) in edges)
                {
                    if (s != targetNode && t != targetNode) uf.TryUnite(s, t);
                    else count++;
                }
                if (count > 1 && groupCount == (uf.GroupCount - 1)) continue;
                articulate.Add(targetNode);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        sameGroup[i][j] &= uf.Find(i) == uf.Find(j);
            }

            List<(int, int)> bridges = new List<(int, int)>();
            List<(int, int)> nonBridges = new List<(int, int)>();
            foreach (var targetEdge in edges)
            {
                UnionFind uf1 = new UnionFind(n);
                foreach (var edge in edges)
                    if (targetEdge != edge)
                        uf1.TryUnite(edge.Item1, edge.Item2);
                if (groupCount == uf1.GroupCount) nonBridges.Add(targetEdge);
                else bridges.Add(targetEdge);
            }

            res *= pow[bridges.Count];
            bool[] used = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (articulate.Contains(i) || used[i]) continue;
                var coreNodes = sameGroup[i].Select((elem, ind) => (elem, ind)).Where(x => x.elem).Select(x => x.ind).ToHashSet();
                var nodes = new HashSet<int>();
                foreach (var (s, t) in edges)
                    if (coreNodes.Contains(s) || coreNodes.Contains(t))
                    { nodes.Add(s); nodes.Add(t); }

                if (nodes.Count - coreNodes.Count > 1) continue;

                foreach (var (s, t) in edges)
                    if (nodes.Contains(s) && nodes.Contains(t))
                        nonBridges.Remove((s, t));

                //Console.WriteLine($"{++cycleCount}: {string.Join(" ", nodes.Select(x => x + 1))}");
                foreach (var item in nodes)
                    used[item] = true;

                var edgeCount = 0;
                foreach (var (s, t) in edges)
                    if (nodes.Contains(s) && nodes.Contains(t))
                        edgeCount++;
                var perms = edgeCount == nodes.Count ? simpleCyclePerms : nonSimpleCyclePerms;
                res *= perms[edgeCount];
            }
            edges = nonBridges.ToArray();
        }

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

struct ModInt
{
    public const int Mod = 1000000007;
    const long POSITIVIZER = ((long)Mod) << 31;
    long Data;
    public ModInt(long data) { if ((Data = data % Mod) < 0) Data += Mod; }
    public static implicit operator long(ModInt modInt) => modInt.Data;
    public static implicit operator ModInt(long val) => new ModInt(val);
    public static ModInt operator +(ModInt a, int b) => new ModInt() { Data = (a.Data + b + POSITIVIZER) % Mod };
    public static ModInt operator +(ModInt a, long b) => new ModInt(a.Data + b);
    public static ModInt operator +(ModInt a, ModInt b) { long res = a.Data + b.Data; return new ModInt() { Data = res >= Mod ? res - Mod : res }; }
    public static ModInt operator -(ModInt a, int b) => new ModInt() { Data = (a.Data - b + POSITIVIZER) % Mod };
    public static ModInt operator -(ModInt a, long b) => new ModInt(a.Data - b);
    public static ModInt operator -(ModInt a, ModInt b) { long res = a.Data - b.Data; return new ModInt() { Data = res < 0 ? res + Mod : res }; }
    public static ModInt operator *(ModInt a, int b) => new ModInt(a.Data * b);
    public static ModInt operator *(ModInt a, long b) => a * new ModInt(b);
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt() { Data = a.Data * b.Data % Mod };
    public static ModInt operator /(ModInt a, ModInt b) => new ModInt() { Data = a.Data * GetInverse(b) % Mod };
    public static bool operator ==(ModInt a, ModInt b) => a.Data == b.Data;
    public static bool operator !=(ModInt a, ModInt b) => a.Data != b.Data;
    public override string ToString() => Data.ToString();
    public override bool Equals(object obj) => (ModInt)obj == this;
    public override int GetHashCode() => (int)Data;
    static long GetInverse(long a)
    {
        long div, p = Mod, x1 = 1, y1 = 0, x2 = 0, y2 = 1;
        while (true)
        {
            if (p == 1) return x2 + Mod; div = a / p; x1 -= x2 * div; y1 -= y2 * div; a %= p;
            if (a == 1) return x1 + Mod; div = p / a; x2 -= x1 * div; y2 -= y1 * div; p %= a;
        }
    }
}
