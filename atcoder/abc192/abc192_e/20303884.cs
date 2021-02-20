// detail: https://atcoder.jp/contests/abc192/submissions/20303884
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
        var nmxy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmxy[0];
        var m = nmxy[1];
        var x = nmxy[2] - 1;
        var y = nmxy[3] - 1;

        List<Edge>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<Edge>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            var a = st[0] - 1;
            var b = st[1] - 1;
            long t = st[2];
            long k = st[3];
            graph[a].Add(new Edge() { To = b, Period = k, Dist = t });
            graph[b].Add(new Edge() { To = a, Period = k, Dist = t });
        }

        const long INF = long.MaxValue / 2;
        long[] dist = Enumerable.Repeat(INF, n).ToArray();
        PriorityQueue<(int, long), long> pqueue = new PriorityQueue<(int, long), long>(x => x.Item2);
        pqueue.Push((x, 0));
        while (pqueue.Count != 0)
        {
            var (ind, t) = pqueue.Pop();
            if (dist[ind] <= t) continue;
            dist[ind] = t;
            foreach (var edge in graph[ind])
            {
                if (dist[edge.To] != INF) continue;
                var nxtTime = (t + edge.Period - 1) / edge.Period * edge.Period + edge.Dist;
                pqueue.Push((edge.To, nxtTime));
            }
        }
        var res = dist[y];
        if (res == INF) res = -1;
        Console.WriteLine(res);
    }
}

struct Edge
{
    public int To;
    public long Period;
    public long Dist;
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
