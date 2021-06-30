// detail: https://atcoder.jp/contests/arc024/submissions/23878515
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
    static Random rng = new Random();
    static long[] val = Enumerable.Repeat(0, 26).Select(_ => rng.Long).ToArray();
    public static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var s = Console.ReadLine();
        long[] cnts = new long[26];
        for (int i = 0; i < k - 1; i++)
            cnts[s[i] - 'a']++;
        long[] hashes = new long[s.Length - (k - 1)];
        for (int i = k - 1; i < s.Length; i++)
        {
            cnts[s[i] - 'a']++;
            hashes[i - (k - 1)] = cnts.Zip(val, (x, y) => x * y).Aggregate(0L, (x, y) => x + y);
            cnts[s[i - (k - 1)] - 'a']--;
        }
        bool res = false;
        Dictionary<long, int> multiset = hashes.Distinct().ToDictionary(x => x, _ => 0);
        for (int i = k; i < hashes.Length; i++) multiset[hashes[i]]++;
        for (int i = 0; i < hashes.Length; i++)
        {
            res |= 1 <= multiset[hashes[i]];
            if (0 <= i - (k - 1)) multiset[hashes[i - (k - 1)]]++;
            if (i + k < hashes.Length) multiset[hashes[i + k]]--;
        }

        Console.WriteLine(res ? "YES" : "NO");
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
