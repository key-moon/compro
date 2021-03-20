// detail: https://atcoder.jp/contests/abc196/submissions/21112068
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

using System.Runtime.Intrinsics.X86;
using System.Runtime.InteropServices;

public static class P
{
    public unsafe static void Main()
    {
        var start = DateTime.Now;
        var s = Console.ReadLine();
        var t = Console.ReadLine();

        int n = s.Length;
        int m = t.Length;

        ulong[][] sarrs = new ulong[64][];
        for (int j = 0; j < 64; j++)
        {
            sarrs[j] = new ulong[(n >> 6) + 1];
            for (int i = j; i < s.Length; i++)
            {
               if (s[i] == '0') continue;
                var ind = i - j;
                sarrs[j][ind >> 6] |= 1UL << (ind & 63);
            }
        }

        ulong[] tarr = new ulong[(m >> 6) + 1];
        for (int i = 0; i < m; i++)
        {
            if (t[i] == '0') continue;
            tarr[i >> 6] |= 1UL << (i & 63);
        }
        var tspan = tarr.AsSpan();

        Random rng = new Random(1337);
        var precnt = m >> 6;
        var mask = (1UL << (m & 63)) - 1;
        var res = ulong.MaxValue;
        foreach (var i in Enumerable.Range(0, n - m + 1).OrderBy(_ => rng.Next()))
        {
            var curres = 0UL;
            var sspan = sarrs[i & 63].AsSpan().Slice(i >> 6, precnt + 1);
            int j = 0;
            for (; j + 4 < precnt; j += 4)
            {
                var xored = Vector.Xor(new Vector<ulong>(sspan.Slice(j, 4)), new Vector<ulong>(tspan.Slice(j, 4)));
                curres += Popcnt.X64.PopCount(xored[0]);
                curres += Popcnt.X64.PopCount(xored[1]);
                curres += Popcnt.X64.PopCount(xored[2]);
                curres += Popcnt.X64.PopCount(xored[3]);
                if (res < curres) goto end;
            }
            for (; j < precnt; j++) curres += Popcnt.X64.PopCount(sspan[j] ^ tspan[j]);
            curres += Popcnt.X64.PopCount((sspan[precnt] ^ tspan[precnt]) & mask);
            res = Min(res, curres);
            end:;
            if (2800 <= (DateTime.Now - start).TotalMilliseconds) break;
        }
        Console.WriteLine(res);
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
