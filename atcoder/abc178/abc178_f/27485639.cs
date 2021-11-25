// detail: https://atcoder.jp/contests/abc178/submissions/27485639
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var begin = DateTime.Now;
        var res = Solve(a, b);
        var end = DateTime.Now;

        var iter = end - begin;

        uint seed = 1337;
        while (res is null && DateTime.Now - begin + iter <= new TimeSpan(0, 0, 0, 1, 500))
        {
            Random rng = new Random(seed++);
            var table = new long[n + 1];
            for (uint i = 0; i <= n; i++)
            {
                table[i] = (long)rng.Next() << 30 | i;
            }
            var na = a.OrderBy(x => table[x]).ToArray();
            var nb = b.OrderBy(x => table[x]).ToArray();
            res = Solve(a, nb);
        }

        if (res is null)
        {
            Console.WriteLine("No");
            return;
        }

        for (int i = 0; i < n; i++)
        {
            Trace.Assert(a[i] != res[i]);
        }
        Trace.Assert(res.OrderBy(x => x).Zip(b.OrderBy(x => x), (x, y) => x == y).All(x => x));

        Console.WriteLine("Yes");
        Console.WriteLine(string.Join(" ", res));
    }
    static int[] Solve(int[] a, int[] b)
    {
        int n = a.Length;
        var ends = Enumerable.Repeat(-10, n + 1).ToArray();
        for (int i = 0; i < a.Length; i++) ends[a[i]] = i;

        Deque<int> skipped = new Deque<int>();
        int last = 0;
        int[] c = new int[n];
        foreach (var group in b.GroupBy(x => x))
        {
            var item = group.Key;
            var cnt = group.Count();
            while (0 < cnt)
            {
                if (a[last] == item)
                {
                    skipped.PushBack(last);
                    last = (ends[item] + 1) % n;
                }

                if (c[last] != 0) break;

                c[last] = item;
                last++;
                last %= n;
                cnt--;
            }
            while (skipped.Count != 0 && 0 < cnt)
            {
                var ind = skipped.PopFront();
                if (a[ind] == item) return null;
                while (a[ind] != item && c[ind] == 0 && 0 < cnt)
                {
                    c[ind] = item;
                    ind++;
                    ind %= n;
                    cnt--;
                }
                if (c[ind] == 0) skipped.PushFront(ind);
            }
            if (cnt != 0)
            {
                return null;
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (a[i] == c[i]) return null;
        }
        int[] cnts = new int[n + 1];
        foreach (var item in b) cnts[item]++;
        foreach (var item in c) cnts[item]--;
        if (cnts.Any(x => x != 0)) return null;
        return c;
    }
}


class Deque<T> : IEnumerable<T>
{
    public int Count;
    T[] data; int FrontInd, BackInd;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Deque() { data = new T[1 << 16]; FrontInd = 0; BackInd = data.Length - 1; Count = 0; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Deque(T[] elem)
    {
        int s = elem.Length; s |= s >> 1; s |= s >> 2; s |= s >> 4; s |= s >> 8; s |= s >> 16;
        data = new T[++s]; elem.CopyTo(data, 0);
        FrontInd = 0; BackInd = elem.Length - 1; Count = elem.Length;
    }

    public T Front
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNoEmpty(); return data[FrontInd]; }
    }
    public T Back
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNoEmpty(); return data[BackInd]; }
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { if (index >= Count) throw new Exception(); return data[FrontInd + index & data.Length - 1]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { if (index >= Count) throw new Exception(); data[FrontInd + index & data.Length - 1] = value; }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PushFront(T elem) { if (Count == data.Length) Extend(data.Length << 1); Count++; data[FrontInd = (FrontInd - 1) & data.Length - 1] = elem; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T PopFront() { var res = Front; FrontInd = (FrontInd + 1) & data.Length - 1; Count--; return res; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PushBack(T elem) { if (Count == data.Length) Extend(data.Length << 1); Count++; data[BackInd = (BackInd + 1) & data.Length - 1] = elem; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T PopBack() { var res = Back; BackInd = (BackInd - 1) & data.Length - 1; Count--; return res; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Extend(int newSize)
    {
        T[] newData = new T[newSize];
        if (0 < Count)
        {
            if (FrontInd <= BackInd) Array.Copy(data, FrontInd, newData, 0, Count);
            else
            {
                Array.Copy(data, FrontInd, newData, 0, data.Length - FrontInd);
                Array.Copy(data, 0, newData, data.Length - FrontInd, BackInd + 1);
            }
        }
        data = newData; FrontInd = 0; BackInd = Count - 1;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ValidateNoEmpty() { if (Count == 0) throw new Exception(); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerator<T> GetEnumerator() { for (int i = FrontInd; i != BackInd; i = i + 1 & data.Length - 1) yield return data[i]; yield return data[BackInd]; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
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
