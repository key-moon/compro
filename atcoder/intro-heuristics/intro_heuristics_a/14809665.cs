// detail: https://atcoder.jp/contests/intro-heuristics/submissions/14809665
//#define B
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
    static int d;
    static int[] c;
    static int[][] s;
    public static void Main()
    {
        Random rng = new Random(1);
        DateTime endAt = DateTime.Now.AddSeconds(1.8);
        d = int.Parse(Console.ReadLine());
        c = Console.ReadLine().Split().Select(int.Parse).ToArray();
        s = Enumerable.Repeat(0, d).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int period = 0;
        int[] curOptimal = GenRandom();
        int curScore = Score(curOptimal);
        while (true)
        {
            var solution = GenRandom(rng.ULong);
            var score = Score(solution);
            if (curScore < score)
            {
                curOptimal = solution;
                curScore = score;
            }
            period++;
            if (period == 100)
            {
                period = 0;
                if (endAt < DateTime.Now) break;
            }
        }

        Console.WriteLine(string.Join("\n", curOptimal.Select(x => x + 1)));
    }

    static int[] GenRandom(ulong seed = 1)
    {
        Random rng = new Random(seed);
        int[] t = new int[d];
        for (int i = 0; i < t.Length; i++)
            t[i] = rng.Next() % 26;
        return t;
    }


    static int Score(int[] t)
    {
        int score = 0;
        int[] last = new int[26];
        for (int i = 0; i < t.Length; i++)
        {
            score += s[i][t[i]];
            last[t[i]] = i + 1;
            for (int j = 0; j < last.Length; j++)
                score -= (i - last[j] + 1) * c[j];
#if B
            Console.WriteLine(score);
#endif
        }
        return score;
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
