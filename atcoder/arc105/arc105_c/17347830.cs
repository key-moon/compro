// detail: https://atcoder.jp/contests/arc105/submissions/17347830
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
#if !DEBUG
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        long[] w = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long[][] lvs = Enumerable.Repeat(0, m).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();
#else
        int n = 8; int m = 100000;
        Random rng = new Random(114514);
        long[] w = Enumerable.Repeat(0, n).Select(_ => (long)rng.Next(1, 100000)).ToArray();
        long[][] lvs = Enumerable.Repeat(0, m).Select(_ => new long[] { rng.Next(1, 100000000), rng.Next(100000, 100000000) }).ToArray();
#endif

        if (lvs.Min(x => x[1]) < w.Max())
        {
            Console.WriteLine(-1);
            return;
        }

        List<long> weights = lvs.Select(x => x[1]).ToList();
        for (int i = 0; i < (1 << w.Length); i++)
        {
            long sum = 0;
            for (int j = 0; j < w.Length; j++)
            {
                if ((i >> j & 1) == 1) sum += w[j];
            }
            weights.Add(sum);
        }
        weights.Add(-1);

        List<long> list = weights.Distinct().OrderBy(x => x).ToList();
        long[] lengths = new long[list.Count];
        foreach (long[] lv in lvs)
        {
            int ind = list.BinarySearch(lv[1]);
            lengths[ind] = Max(lengths[ind], lv[0]);
        }
        for (int i = 1; i < lengths.Length; i++)
        {
            lengths[i] = Max(lengths[i - 1], lengths[i]);
        }

        long[] lengthPerComb = new long[1 << n];
        for (int i = 0; i < (1 << n); i++)
        {
            long sum = 0;
            for (int j = 0; j < w.Length; j++)
            {
                if ((i >> j & 1) == 1) sum += w[j];
            }
            lengthPerComb[i] = lengths[list.BinarySearch(sum) - 1];
        }

        int[] arr = Enumerable.Range(0, n).ToArray();
        long[] pos = new long[n];
        long res = long.MaxValue;
        foreach (int[] item in Permutations(arr))
        {
            for (int i = 0; i < pos.Length; i++)
            {
                pos[i] = 0;
                //long weight = w[item[i]];
                int comb = 1 << item[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    //weight += w[item[j]];
                    comb |= 1 << item[j];
                    //pos[i] = Max(pos[i], pos[j] + lengths[list.BinarySearch(weight) - 1]);
                    pos[i] = Max(pos[i], pos[j] + lengthPerComb[comb]);
                }
            }
            res = Min(res, pos[pos.Length - 1]);
        }
        Console.WriteLine(res);
    }

    static IEnumerable<T[]> Permutations<T>(T[] array) where T : IComparable<T>
    {
        int index = 0;
        yield return array;
        while (true)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i - 1].CompareTo(array[i]) >= 0) continue;
                int j = Array.FindLastIndex(array, x => array[i - 1].CompareTo(x) < 0);
                T tmp = array[i - 1]; array[i - 1] = array[j]; array[j] = tmp;
                Array.Reverse(array, i, array.Length - i);
                yield return array;
                goto end;
            }
            Array.Reverse(array, index, array.Length);
            yield break;
            end:;
        }
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
    public int Next(int start, int end) => Next() % (end - start + 1) + start;
    public void Update()
    {
        _xorshift ^= _xorshift << 7;
        _xorshift ^= _xorshift >> 9;
    }
}
