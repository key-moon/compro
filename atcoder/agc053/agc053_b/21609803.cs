// detail: https://atcoder.jp/contests/agc053/submissions/21609803
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
public static class P
{
    public static void Main()
    {
        //Test();
        int n = int.Parse(Console.ReadLine());
        var v = Console.ReadLine().Split().Select(long.Parse).ToArray();
        Console.WriteLine(Solve(v));
    }
    static void Test()
    {
        Random r = new Random(0);
        int i = 0;
        while (true)
        {
            int n = 10;
            var v = Enumerable.Repeat(0, n).Select(_ => (long)r.Next(0, 100)).ToArray();
            var ans = Solve(v);
            var res = Naive(v);
            if (ans != res)
            {
                Solve(v);
                Naive(v);
            }
            if (i % 100 == 0) Console.WriteLine(i);
            i++;
        }
    }
    static long Solve(long[] v)
    {
        Stack<long> a = new Stack<long>();
        Stack<long> b = new Stack<long>();
        for (int i = 0; i < v.Length / 2; i++) a.Push(v[i]);
        for (int i = v.Length - 1; i >= v.Length / 2; i--) b.Push(v[i]);
        PriorityQueue<long> pqueue = new PriorityQueue<long>();
        while (a.Count != 0 && b.Count != 0)
        {
            var vals = new[] { a.Pop(), b.Pop() };
            Array.Sort(vals);
            pqueue.Push(vals[1]);
            if (pqueue.Top < vals[0])
            {
                pqueue.Pop();
                pqueue.Push(vals[0]);
            }
        }
        long res = 0;
        while (pqueue.Count != 0) res += pqueue.Pop();
        return res;
    }
    static long Naive(long[] seq)
    {
        int n = seq.Length;
        long[] memo = Enumerable.Repeat(-1L, 1 << n).ToArray();
        long Solve(int inds)
        {
            if (0 <= memo[inds]) return memo[inds];
            int top1 = 0;
            int top2 = 0;
            for (int i = 0; i < n / 2; i++)
                if ((inds >> i & 1) == 1) top1 = i;
            for (int i = n - 1; i >= n / 2; i--)
                if ((inds >> i & 1) == 1) top2 = i;
            long max = 0;
            for (int i = 0; i < n / 2; i++)
                if ((inds >> i & 1) == 1)
                    max = Max(max, Solve(inds ^ (1 << i) ^ (1 << top2)) + seq[i]);
            for (int i = n - 1; i >= n / 2; i--)
                if ((inds >> i & 1) == 1)
                    max = Max(max, Solve(inds ^ (1 << i) ^ (1 << top1)) + seq[i]);
            return memo[inds] = max;
        }
        return Solve((1 << n) - 1);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int PopCount(int n)
    {
        n = n - ((n >> 1) & 0x55555555);
        n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
        return (int)(((n + (n >> 4) & 0xF0F0F0F) * 0x1010101) >> 24);
    }
}


class PriorityQueue<T> where T : IComparable<T>
{
    public int Count { get; private set; }
    private bool Descendance;
    private T[] data = new T[65536];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PriorityQueue(bool descendance = false) { Descendance = descendance; }
    public T Top
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNonEmpty(); return data[1]; }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Pop()
    {
        var top = Top;
        var elem = data[Count--];
        int index = 1;
        while (true)
        {
            if ((index << 1) >= Count)
            {
                if (index << 1 > Count) break;
                if (elem.CompareTo(data[index << 1]) > 0 ^ Descendance) data[index] = data[index <<= 1];
                else break;
            }
            else
            {
                var nextIndex = data[index << 1].CompareTo(data[(index << 1) + 1]) <= 0 ^ Descendance ? (index << 1) : (index << 1) + 1;
                if (elem.CompareTo(data[nextIndex]) > 0 ^ Descendance) data[index] = data[index = nextIndex];
                else break;
            }
        }
        data[index] = elem;
        return top;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Push(T value)
    {
        int index = ++Count;
        if (data.Length == Count) Extend(data.Length * 2);
        while ((index >> 1) != 0)
        {
            if (data[index >> 1].CompareTo(value) > 0 ^ Descendance) data[index] = data[index >>= 1];
            else break;
        }
        data[index] = value;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Extend(int newSize)
    {
        T[] newDatas = new T[newSize];
        data.CopyTo(newDatas, 0);
        data = newDatas;
    }
    private void ValidateNonEmpty() { if (Count == 0) throw new Exception(); }
}
