// detail: https://codeforces.com/contest/786/submission/88280931
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
        var nqs = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nqs[0];
        var q = nqs[1];
        var s = nqs[2];

        var len = largePow(n);

        List<Tuple<int, long>>[] edges = Enumerable.Repeat(0, len * 3).Select(_ => new List<Tuple<int, long>>()).ToArray();
        for (int i = 1; i < len / 2; i++)
        {
            edges[len + i].Add(new Tuple<int, long>(len + i * 2, 0));
            edges[len + i].Add(new Tuple<int, long>(len + i * 2 + 1, 0));
            edges[len * 2 + i * 2].Add(new Tuple<int, long>(len * 2 + i, 0));
            edges[len * 2 + i * 2 + 1].Add(new Tuple<int, long>(len * 2 + i, 0));
        }
        var half = len / 2;
        for (int i = half; i < len; i++)
        {
            var next = i * 2 - len;
            edges[len + i].Add(new Tuple<int, long>(next, 0));
            edges[len + i].Add(new Tuple<int, long>(next + 1, 0));
            edges[next].Add(new Tuple<int, long>(len * 2 + i, 0));
            edges[next + 1].Add(new Tuple<int, long>(len * 2 + i, 0));
        }

        for (int i = 0; i < q; i++)
        {
            int v, u, w, l, r;
            var plan = Console.ReadLine().Split().Select(int.Parse).ToArray();
            switch (plan[0])
            {
                case 1:
                    v = plan[1] - 1; u = plan[2] - 1; w = plan[3];
                    edges[v].Add(new Tuple<int, long>(u, w));
                    break;
                case 2:
                    v = plan[1] - 1; l = plan[2] - 1; r = plan[3] - 1; w = plan[4];
                    foreach (var item in 
                        GetSectionID(l, r, len)
                        .Select(x => len <= x ? x - len : x + len))
                    {
                        edges[v].Add(new Tuple<int, long>(item, w));
                    }
                    break;
                case 3:
                    v = plan[1] - 1; l = plan[2] - 1; r = plan[3] - 1; w = plan[4];
                    foreach (var item in
                        GetSectionID(l, r, len)
                        .Select(x => len <= x ? x - len : x + len * 2))
                    {
                        edges[item].Add(new Tuple<int, long>(v, w));
                    }
                    break;
            }
        }

        long[] dists = Enumerable.Repeat(long.MaxValue / 2, len * 3).ToArray();
        PriorityQueue<Tuple<int, long>, long> pqueue = new PriorityQueue<Tuple<int, long>, long>(x => x.Item2);
        pqueue.Push(new Tuple<int, long>(s - 1, 0));
        while (pqueue.Count != 0)
        {
            var elem = pqueue.Pop();
            var ind = elem.Item1;
            var dist = elem.Item2;

            if (dists[ind] < dist) continue;
            dists[ind] = dist;

            foreach (var adj in edges[ind])
            {
                var next = dist + adj.Item2;
                if (dists[adj.Item1] <= next) continue;
                dists[adj.Item1] = next;
                pqueue.Push(new Tuple<int, long>(adj.Item1, next));
            }
        }


        Console.WriteLine(string.Join(" ", dists.Take(n).Select(x => long.MaxValue / 2 <= x ? -1 : x)));
    }
    static IEnumerable<int> GetSectionID(int l, int r, int size)
    {
        for (l += size, r += size; l <= r; l = (l + 1) >> 1, r = (r - 1) >> 1)
        {
            if ((l & 1) == 1) yield return l;
            if ((r & 1) == 0) yield return r;
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int largePow(int s)
    { 
        s |= s >> 1; s |= s >> 2; s |= s >> 4; s |= s >> 8; s |= s >> 16; 
        return s + 1;
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
