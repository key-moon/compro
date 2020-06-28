// detail: https://atcoder.jp/contests/intro-heuristics/submissions/14822534
//#define B
//#undef DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        DateTime endAt = DateTime.Now.AddSeconds(1.8);
#if DEBUG
        GenCase(4965145);
#else
        GetCase();
#endif

        Random rng = new Random(1);
        int period = 0;
        int[] current = GenInit();
        int curScore = Score(current);
        Debug(curScore);
        for (int _ = 0; _ < 20; _++)
        {
            var solution = GenRandomV3(rng.ULong);
            var score = Score(solution);
            if (curScore < score)
            {
                current = solution;
                curScore = score;
            }
        }

        const int startTemp = 3000;
        const int endTemp = 50;

        double temp = 0;

        while (true)
        {
            var start = rng.Next() % d;
            var duration = (rng.Next() & 7) + 1;
            if (d <= start + duration) continue;
            var nextScore = current.Shuffle(start, start + duration);
            var prob = Exp((nextScore - curScore) / temp);
            if (prob * uint.MaxValue > rng.UInt)
            //if (nextScore > curScore)
            {
                curScore = nextScore;
                Debug(curScore);
            }
            else
            {
                current.Rev(start, start + duration);
            }
            period++;
            if (period == 100)
            {
                period = 0;
                var progress = 1 - (endAt - DateTime.Now).TotalSeconds / 2;
                temp = startTemp + (endTemp - startTemp) * progress;
                //Debug(temp);
                if (1 <= progress) break;
            }
        }

#if DEBUG
        Console.WriteLine($"score : {curScore}");
#else
        Console.WriteLine(string.Join("\n", current.Select(x => x + 1)));
#endif
        Console.Out.Flush();
    }

    static void Rev(this int[] a, int start, int end)
    {
        var tmp = a[end];
        for (int i = end; i >= start + 1; i--)
        {
            a[i] = a[i - 1];
        }
        a[start] = tmp;
    }

    static int Shuffle(this int[] a, int start, int end)
    {
        //var res = new int[a.Length];
        //a.CopyTo(res, 0);
        var tmp = a[start];
        for (int i = start; i < end; i++)
        {
            a[i] = a[i + 1];
        }
        a[end] = tmp;
        //Debug($"{start} {end}\n{string.Join(" ", a)}\n{string.Join(" ", res)}");
        return Score(a);
    }

    #region case
    static void GetCase()
    {
        d = int.Parse(Console.ReadLine());
        c = Console.ReadLine().Split().Select(int.Parse).ToArray();
        s = Enumerable.Repeat(0, d).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
    }

    static void GenCase(ulong seed = 1, int d = 365)
    {
        Random rng = new Random(seed);
        P.d = d;
        c = Enumerable.Range(0, 26).Select(_ => rng.Next() % 101).ToArray();
        s = Enumerable.Range(0, 20000).Select(_ => Enumerable.Range(0, 26).Select(_ => rng.Next() % 20001).ToArray()).ToArray();
    }
    #endregion

    [Conditional("DEBUG")]
    static void Debug(object s)
    {
        Console.WriteLine(s.ToString());
    }

    static int[] GenInit()
    {
        int[] t = new int[d];
        int[] last = new int[26];
        int[] pens = new int[26];
        for (int i = 0; i < t.Length; i++)
        {
            int maxPen = 0;
            int maxInd = 0;
            for (int j = 0; j < last.Length; j++)
            {
                int pen = (i - last[j]) * c[j];
                if (maxPen < pen)
                {
                    maxPen = pen;
                    maxInd = j;
                }
            }
            t[i] = maxInd;
            last[maxInd] = i;
        }
        return t;
    }

    static int[] GenRandomV3(ulong seed = 1, int threshold = 3)
    {
        Random rng = new Random(seed);
        int[] t = new int[d];
        int[] last = new int[26];
        for (int i = 0; i < threshold; i++)
        {
            var ind = rng.Next() % 26;
            t[i] = ind;
            last[ind] = i;
        }
        for (int i = threshold; i < t.Length; i++)
        {
            int maxPen = 0;
            int maxInd = 0;
            for (int j = 0; j < last.Length; j++)
            {
                int pen = (i - last[j]) * c[j];
                if (maxPen < pen)
                {
                    maxPen = pen;
                    maxInd = j;
                }
            }
            t[i] = maxInd;
            last[maxInd] = i;
        }
        return t;
    }

    static int[] GenRandomV2(ulong seed = 1)
    {
        Random rng = new Random(seed);
        int[] t = new int[d];
        int[] last = new int[26];
        int[] pens = new int[26];
        t[0] = rng.Next() % 26;
        for (int i = 1; i < t.Length; i++)
        {
            long penSum = 0;
            for (int j = 0; j < last.Length; j++)
            {
                int pen = (i - last[j]) * c[j];
                pens[j] = pen;
                penSum += pen;
            }
            int ind = 0;
            var rem = rng.NextLong() % penSum;
            for (int j = 0; j < pens.Length; j++)
            {
                if ((penSum -= pens[j]) <= rem)
                {
                    ind = j;
                    break;
                }
            }
            t[i] = ind;
            last[ind] = i;
        }
        return t;
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
        return score + 1000000;
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

    public int Next() => Int & int.MaxValue;
    public long NextLong() => Long & long.MaxValue;
    public void Update()
    {
        _xorshift ^= _xorshift << 7;
        _xorshift ^= _xorshift >> 9;
    }
}
