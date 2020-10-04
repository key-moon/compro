// detail: https://codeforces.com/contest/1422/submission/94685590
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var sf = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var points = Enumerable.Repeat(0, m).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => (y: x[0], x: x[1])).Select((x, y) => (point: x, ind: y)).Append((point: (y: sf[0], x: sf[1]), ind: m)).ToArray();
        
        List<(int, int)>[] edges = Enumerable.Repeat(0, m + 1).Select(_ => new List<(int, int)>()).ToArray();

        var oby = points.OrderBy(x => x.point.y).ToArray();
        for (int i = 0; i < oby.Length - 1; i++)
        {
            var ((y1, _), ind1) = oby[i];
            var ((y2, _), ind2) = oby[i + 1];
            var dist = Abs(y1 - y2);
            edges[ind1].Add((ind2, dist));
            edges[ind2].Add((ind1, dist));
        }

        var obx = points.OrderBy(x => x.point.x).ToArray();
        for (int i = 0; i < obx.Length - 1; i++)
        {
            var ((_, x1), ind1) = obx[i];
            var ((_, x2), ind2) = obx[i + 1];
            var dist = Abs(x1 - x2);
            edges[ind1].Add((ind2, dist));
            edges[ind2].Add((ind1, dist));
        }

        long[] minDist = Enumerable.Repeat(long.MaxValue / 2, m + 1).ToArray();
        PriorityQueue<(int, long), long> pqueue = new PriorityQueue<(int, long), long>(x => x.Item2);
        pqueue.Push((m, 0));
        while (pqueue.Count != 0)
        {
            var (ind, dist) = pqueue.Pop();
            if (minDist[ind] <= dist) continue;
            minDist[ind] = dist;
            foreach (var (adj, adjDist) in edges[ind])
            {
                var nextDist = dist + adjDist;
                if (minDist[adj] <= nextDist) continue;
                pqueue.Push((adj, nextDist));
            }
        }
        var sy = sf[0];
        var sx = sf[1];
        var fy = sf[2];
        var fx = sf[3];
        long res = Abs(sy - fy) + Abs(sx - fx);
        for (int i = 0; i < m; i++)
        {
            var ((y, x), _) = points[i];
            res = Min(res, minDist[i] + Abs(y - fy) + Abs(x - fx));
        }
        Console.WriteLine(res);
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
