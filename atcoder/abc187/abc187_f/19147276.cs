// detail: https://atcoder.jp/contests/abc187/submissions/19147276
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
public static class P
{
    public static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];

        Random rng = new Random(1);
        var shuffle = Enumerable.Range(0, n).OrderBy(_ => rng.Next()).ToArray();

        bool[][] mat = Enumerable.Repeat(0, n).Select(_ => new bool[n]).ToArray();
        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => shuffle[int.Parse(x) - 1]).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
            mat[st[0]][st[1]] = true;
            mat[st[1]][st[0]] = true;
        }

        bool[] contains = new bool[1 << n];
        contains[0] = true;
        var maximalSets = new List<int>();
        for (int b = (1 << n) - 1; b >= 0; b--)
        {
            if (!contains[b])
            {
                for (int i = 0; i < n; i++)
                {
                    if ((b >> i & 1) != 1) continue;
                    for (int j = i + 1; j < n; j++)
                    {
                        if ((b >> j & 1) != 1) continue;
                        if (!mat[i][j]) goto invalid;
                    }
                }
                maximalSets.Add(b);
            }
            for (int i = 0; i < n; i++)
            {
                if ((b >> i & 1) != 1) continue;
                contains[b - (1 << i)] = true;
            }
            invalid:;
        }
        int[] res = Enumerable.Repeat(int.MaxValue / 2, 1 << n).ToArray();
        res[0] = 0;
        for (int i = 0; i < res.Length; i++)
        {
            foreach (var set in maximalSets)
            {
                res[i | set] = Min(res[i | set], res[i] + 1);
            }
        }
        Console.WriteLine(res.Last());
    }
}


[StructLayout(LayoutKind.Explicit)]
class Random
{
    [FieldOffset(0)]
    private byte __byte;
    [FieldOffset(0)]
    private sbyte __sbyte;
    [FieldOffset(0)]
    private char __char;
    [FieldOffset(0)]
    private short __short;
    [FieldOffset(0)]
    private ushort __ushort;
    [FieldOffset(0)]
    private int __int;
    [FieldOffset(0)]
    private uint __uint;
    [FieldOffset(0)]
    private long __long;
    [FieldOffset(0)]
    private ulong __ulong;

    public byte Byte { get { Update(); return __byte; } }
    public sbyte SByte { get { Update(); return __sbyte; } }
    public char Char { get { Update(); return __char; } }
    public short Short { get { Update(); return __short; } }
    public ushort UShort { get { Update(); return __ushort; } }
    public int Int { get { Update(); return __int; } }
    public uint UInt { get { Update(); return __uint; } }
    public long Long { get { Update(); return __long; } }
    public ulong ULong { get { Update(); return __ulong; } }
    public double Double { get { return (double)ULong / ulong.MaxValue; } }

    [FieldOffset(0)]
    private ulong _xorshift;

    public Random() : this((ulong)DateTime.Now.Ticks) { }
    public Random(ulong seed) { SetSeed(seed); }
    public void SetSeed(ulong seed) => _xorshift = seed * 0x3141592c0ffeeul;

    public int Next() => Int & 2147483647;
    public void Update()
    {
        _xorshift ^= _xorshift << 7;
        _xorshift ^= _xorshift >> 9;
    }
}
