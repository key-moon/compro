// detail: https://atcoder.jp/contests/zone2021/submissions/22238776
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
        var rc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = rc[0];
        var w = rc[1];

        var a = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();
        var b = Enumerable.Repeat(0, h - 1).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();

        long[][] cost = Enumerable.Range(0, h).Select(_ => Enumerable.Repeat(long.MaxValue / 2, w).ToArray()).ToArray();
        bool[][] reached = Enumerable.Range(0, h).Select(_ => Enumerable.Repeat(false, w).ToArray()).ToArray();
        PriorityQueue<(int, int), long> pqueue = new PriorityQueue<(int, int), long>(x => cost[x.Item1][x.Item2]);
        cost[0][0] = 0;
        pqueue.Push((0, 0));
        bool Chmin(ref long a, long b)
        {
            if (a <= b) return false;
            a = b;
            return true;
        }
        while (pqueue.Count != 0)
        {
            var (y, x) = pqueue.Pop();
            if (reached[y][x]) continue;
            reached[y][x] = true;
            for (int i = 1; i <= y; i++)
            {
                if (Chmin(ref cost[y - i][x], cost[y][x] + 1 + i))
                {
                    pqueue.Push((y - i, x));
                }
            }
            if (x != 0 && Chmin(ref cost[y][x - 1], cost[y][x] + a[y][x - 1]))
            {
                pqueue.Push((y, x - 1));
            }
            if (x != w - 1 && Chmin(ref cost[y][x + 1], cost[y][x] + a[y][x]))
            {
                pqueue.Push((y, x + 1));
            }
            if (y != h - 1 && Chmin(ref cost[y + 1][x], cost[y][x] + b[y][x]))
            {
                pqueue.Push((y + 1, x));
            }
        }

        //Console.WriteLine(string.Join("\n", cost.Select(x => string.Join(" ", x))));
        Console.WriteLine(cost[h - 1][w - 1]);
    }
}

class PriorityQueue<TValue, TKey> where TKey : IComparable<TKey>
{
    public int Count { get; private set; }
    private Func<TValue, TKey> KeySelector;
    private bool Descendance;
    private TValue[] data = new TValue[65536];
    private TKey[] keys = new TKey[65536];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PriorityQueue(Func<TValue, TKey> keySelector, bool descendance = false) { KeySelector = keySelector; Descendance = descendance; }
    public TValue Top
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNonEmpty(); return data[1]; }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TValue Pop()
    {
        var top = Top;
        var item = data[Count];
        var key = keys[Count--];
        int index = 1;
        while (true)
        {
            if ((index << 1) >= Count)
            {
                if (index << 1 > Count) break;
                if (key.CompareTo(keys[index << 1]) > 0 ^ Descendance)
                { data[index] = data[index << 1]; keys[index] = keys[index << 1]; index <<= 1; }
                else break;
            }
            else
            {
                var nextIndex = keys[index << 1].CompareTo(keys[(index << 1) + 1]) <= 0 ^ Descendance ? (index << 1) : (index << 1) + 1;
                if (key.CompareTo(keys[nextIndex]) > 0 ^ Descendance)
                { data[index] = data[nextIndex]; keys[index] = keys[nextIndex]; index = nextIndex; }
                else break;
            }
        }
        data[index] = item;
        keys[index] = key;
        return top;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Push(TValue item)
    {
        var key = KeySelector(item);
        int index = ++Count;
        if (data.Length == Count) Extend(data.Length * 2);
        while ((index >> 1) != 0)
        {
            if (keys[index >> 1].CompareTo(key) > 0 ^ Descendance)
            { data[index] = data[index >> 1]; keys[index] = keys[index >> 1]; index >>= 1; }
            else break;
        }
        data[index] = item;
        keys[index] = key;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Extend(int newSize)
    {
        TValue[] newData = new TValue[newSize];
        TKey[] newKeys = new TKey[newSize];
        data.CopyTo(newData, 0);
        keys.CopyTo(newKeys, 0);
        data = newData;
        keys = newKeys;
    }
    private void ValidateNonEmpty() { if (Count == 0) throw new IndexOutOfRangeException(); }
}