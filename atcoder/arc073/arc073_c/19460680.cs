// detail: https://atcoder.jp/contests/arc073/submissions/19460680
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
        int n = int.Parse(Console.ReadLine());
        long[][] balls = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();
        long res = (balls.Max(x => x.Max()) - balls.Min(x => x.Max())) * (balls.Max(x => x.Min()) - balls.Min(x => x.Min()));
        var totalMin = balls.Min(x => x.Min());
        var totalMax = balls.Max(x => x.Max());
        bool minAdded = false, maxAdded = false;
        PriorityQueue<Pair, long> pqueue = new PriorityQueue<Pair, long>(x => x.Val);
        long curMax = 0;
        void Add(long val, long next = -1)
        {
            curMax = Max(curMax, val);
            pqueue.Push(new Pair() { Val = val, Next = next });
        }
        foreach (var ball in balls)
        {
            var min = ball.Min();
            var max = ball.Max();
            if (min == totalMin && !minAdded)
            {
                Add(max);
                minAdded = true;
                continue;
            }
            if (max == totalMax && !maxAdded)
            {
                Add(min);
                maxAdded = true;
                continue;
            }
            Add(min, max);
        }
        void UpdateRes() => res = Min(res, (totalMax - totalMin) * (curMax - pqueue.Top.Val));
        UpdateRes();
        while (true)
        {
            var elem = pqueue.Pop();
            if (elem.Next == -1) break;
            Add(elem.Next);
            UpdateRes();
        }
        Console.WriteLine(res);
    }
}

class Pair
{
    public long Val;
    public long Next;
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