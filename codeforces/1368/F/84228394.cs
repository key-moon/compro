// detail: https://codeforces.com/contest/1368/submission/84228394
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
    static int N;
    static bool[] Lamp;
    static int Optimal;
    public static void Main()
    {
        N = int.Parse(Console.ReadLine());
        Lamp = new bool[N];
        int maxOptimal = 0;
        int optimalK = 0;
        for (int k = 1; k <= N; k++)
        {
            var optimal = (N / k - 1) * (k - 1) + Max(0, N % k - 1);
            if (maxOptimal < optimal)
            {
                maxOptimal = optimal;
                optimalK = k;
            }
        }
        Optimal = maxOptimal;
        if (optimalK != 0) Solve(optimalK);
        Terminate();
    }


    public static void Solve(int k)
    {
        Random rng = new Random(314);
        List<int> shouldTurnOn = new List<int>();
        for (int i = 0; i < N; i++)
        {
            if (i % k == k - 1) continue;
            shouldTurnOn.Add(i);
        }
        while (Lamp.Count(x => x) < Optimal)
        {
            shouldTurnOn.AddRange(lastRemoved);
            var randomized = shouldTurnOn.OrderBy(_ => rng.Next()).ToArray();
            Query(randomized.Take(k).ToArray());
            shouldTurnOn = randomized.Skip(k).ToList();
        }
    }

    static List<int> lastRemoved = new List<int>();
    static int prevK;
    public static Tuple<int, int> Query(int[] a)
    {
        prevK = a.Length;
        foreach (var item in a) Lamp[item] = true;
        Console.WriteLine($"{a.Length} {string.Join(" ", a.Select(y => y + 1))}");

        var x = int.Parse(Console.ReadLine());

        if (x == -1) Terminate();

        x--;

        lastRemoved.Clear();
        var end = (x + a.Length) % N;
        for (int i = x; i != end; i = i != (N - 1) ? i + 1 : 0)
        {
            if (!Lamp[i]) continue;
            Lamp[i] = false;
            lastRemoved.Add(i);
        }
        
        return new Tuple<int, int>(x, end);
    }

    public static void Terminate()
    {
        Console.WriteLine(0);
        Environment.Exit(0);
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