// detail: https://codeforces.com/contest/1131/submission/50363426
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
        Random r = new Random();
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).OrderBy(_ => r.Int/*don't try to hack with sort*/).OrderBy(x => x).ToList();
        List<int> first = new List<int>();
        List<int> second = new List<int>();
        for (int i = 0; i < a.Count; i++)
        {
            if (i % 2 == 0) first.Add(a[i]); 
            if (i % 2 == 1) second.Add(a[i]); 
        }
        Console.WriteLine(string.Join(" ", second.Reverse<int>().Concat(first)));
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