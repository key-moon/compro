// detail: https://codeforces.com/contest/1446/submission/98450416
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

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Solve();
        }
        Console.Out.Flush();
    }
    static void Solve()
    {
        var nw = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var w = nw[1];
        var min = (w + 1) / 2;
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long sum = 0;
        List<int> res = new List<int>();
        Random rng = new Random();
        foreach (var (val, ind) in a.Select((val, ind) => (val, ind + 1)).OrderBy(_ => rng.Next()).OrderBy(x => x.val))
        {
            if (min <= val && val <= w)
            {
                Console.WriteLine(1);
                Console.WriteLine(ind);
                return;
            }
            sum += val;
            res.Add(ind);
            if (min <= sum && sum <= w)
            {
                Console.WriteLine(res.Count);
                Console.WriteLine(string.Join(" ", res.OrderBy(x => x)));
                return;
            }
        }
        Console.WriteLine(-1);
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
