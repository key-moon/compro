// detail: https://codeforces.com/contest/1131/submission/50380236
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

class Ph
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToList();
        var a = Enumerable.Repeat(0, nm[0]).Select(_ => Console.ReadLine()).ToList();
        var nodeInSet = Enumerable.Repeat(0, nm[0] + nm[1]).Select(_ => new HashSet<int>()).ToArray();
        var nodeOutSet = Enumerable.Repeat(0, nm[0] + nm[1]).Select(_ => new HashSet<int>()).ToArray();
        var uf = new UnionFind(nm[0] + nm[1]);
        for (int i = 0; i < nm[0]; i++)
        {
            for (int j = 0; j < nm[1]; j++)
            {
                if (a[i][j] == '=') uf.Unite(i, nm[0] + j);
            }
        }
        for (int i = 0; i < nm[0]; i++)
        {
            for (int j = 0; j < nm[1]; j++)
            {
                if (a[i][j] == '<')
                {
                    nodeInSet[uf.Find(nm[0] + j)].Add(uf.Find(i));
                    nodeOutSet[uf.Find(i)].Add(uf.Find(nm[0] + j));
                }
                if (a[i][j] == '>')
                {
                    nodeInSet[uf.Find(i)].Add(uf.Find(nm[0] + j));
                    nodeOutSet[uf.Find(nm[0] + j)].Add(uf.Find(i));
                }
            }
        }

        var nodeInCounts = nodeInSet.Select(x => x.Count).ToArray();
        var nodeNum = new int[nm[0] + nm[1]];

        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        for (int i = 0; i < nm[0] + nm[1]; i++)
        {
            if (i == uf.Find(i) && nodeInSet[uf.Find(i)].Count == 0) queue.Enqueue(new Tuple<int, int>(i, 1));
        }

        while (queue.Count > 0)
        {
            var item = queue.Dequeue();
            nodeNum[item.Item1] = item.Item2;
            foreach (var o in nodeOutSet[item.Item1])
            {
                var O = uf.Find(o);
                nodeInCounts[O]--;
                if (nodeInCounts[O] == 0)
                {
                    queue.Enqueue(new Tuple<int, int>(O, item.Item2 + 1));
                }
            }
        }


        if (nodeNum.Where((_, x) => uf.Find(x) == x).Contains(0))
        {
            Console.WriteLine("No");
            return;
        }
        Console.WriteLine("Yes");
        Console.WriteLine(string.Join(" ", Enumerable.Range(0, nm[0]).Select(x => nodeNum[uf.Find(x)])));
        Console.WriteLine(string.Join(" ", Enumerable.Range(nm[0], nm[1]).Select(x => nodeNum[uf.Find(x)])));
    }
}


[StructLayout(LayoutKind.Explicit)]
class Random
{
    [FieldOffset(0)]
    private byte __byte;
    public byte Byte
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __byte;
        }
    }
    [FieldOffset(0)]
    private sbyte __sbyte;
    public sbyte SByte
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __sbyte;
        }
    }
    [FieldOffset(0)]
    private char __char;
    public char Char
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __char;
        }
    }
    [FieldOffset(0)]
    private short __short;
    public short Short
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __short;
        }
    }
    [FieldOffset(0)]
    private ushort __ushort;
    public ushort UShort
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __ushort;
        }
    }
    [FieldOffset(0)]
    private int __int;
    public int Int
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __int;
        }
    }
    [FieldOffset(0)]
    private uint __uint;
    public uint UInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __uint;
        }
    }
    [FieldOffset(0)]
    private long __long;
    public long Long
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __long;
        }
    }
    [FieldOffset(0)]
    private ulong __ulong;
    public ulong ULong
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __ulong;
        }
    }
    [FieldOffset(0)]
    private ulong _xorshift;

    public double Double
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return (double)ULong / ulong.MaxValue;
        }
    }

    public Random()
    {
        SetSeed((ulong)DateTime.Now.Ticks);
    }
    public Random(ulong seed)
    {
        SetSeed(seed);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetSeed(ulong seed) => _xorshift = seed * 0x3141592c0ffeeul;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Next()
    {
        _xorshift ^= _xorshift << 7;
        _xorshift ^= _xorshift >> 9;
    }
}

class UnionFind
{
    public int Size { get; private set; }
    List<int> parent;
    List<int> sizes;
    public UnionFind(int count)
    {
        Size = 0;
        parent = new List<int>(count);
        sizes = new List<int>(count);
        ExtendSize(count);
    }
    public bool Unite(int x, int y)
    {
        int xp = Find(x);
        int yp = Find(y);
        if (yp == xp) return false;
        if (sizes[xp] < sizes[yp])
        {
            var tmp = xp;
            xp = yp;
            yp = tmp;
        }
        parent[yp] = xp;
        sizes[xp] += sizes[yp];
        return true;
    }
    public IEnumerable<int> AllParents => parent.Where(x => x == parent[x]);
    public int GetSize(int x) => sizes[x];
    public int Find(int x) => parent[x] == parent[parent[x]] ? parent[x] : parent[x] = Find(parent[x]);
    public void ExtendSize(int treeSize)
    {
        if (treeSize <= Size) return;
        parent.Capacity = treeSize;
        sizes.Capacity = treeSize;
        while (Size < treeSize)
        {
            parent.Add(Size);
            sizes.Add(1);
            Size++;
        }
    }
}