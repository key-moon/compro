// detail: https://atcoder.jp/contests/arc109/submissions/18453587
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
        var abcd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = abcd[0];
        var b = abcd[1];
        var x = abcd[2];
        var y = abcd[3];

        int[] res = Enumerable.Repeat(int.MaxValue, 200).ToArray();
        var pqueue = new PriorityQueue<(int, int), int>(x => x.Item2);
        pqueue.Push((a - 1, 0));
        while (pqueue.Count != 0)
        {
            var (ind, elem) = pqueue.Pop();
            if (res[ind] <= elem) continue;
            res[ind] = elem;
            if (ind < 100)
            {
                pqueue.Push((ind + 100, elem + x));
                if (ind != 0)
                {
                    pqueue.Push((ind + 100 - 1, elem + x));
                    pqueue.Push((ind - 1, elem + y));
                }
                if (ind != 99)
                {
                    pqueue.Push((ind + 1, elem + y));
                }
            }
            else
            {
                pqueue.Push((ind - 100, elem + x));
                if (ind != 100)
                {
                    pqueue.Push((ind - 1, elem + y));
                }
                if (ind != 199)
                {
                    pqueue.Push((ind - 100 + 1, elem + x));
                    pqueue.Push((ind + 1, elem + y));
                }
            }
        }
        Console.WriteLine(res[100 + b - 1]);
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