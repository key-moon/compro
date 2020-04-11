// detail: https://atcoder.jp/contests/arc025/submissions/11758293
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
        var nmrt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmrt[0];
        var m = nmrt[1];
        var r = nmrt[2];
        var t = nmrt[3];

        var graph = Enumerable.Repeat(0, n).Select(_ => new List<Edge>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(new Edge() { To = st[1], Distance = st[2] + 1 });
            graph[st[1]].Add(new Edge() { To = st[0], Distance = st[2] + 1 });
        }

        long res = 0;
        for (int a = 0; a < n; a++)
        {
            var distances = new long[n];
            PriorityQueue<Edge, int> pqueue = new PriorityQueue<Edge, int>(x => x.Distance);
            pqueue.Push(new Edge() { Distance = 0, To = a });
            while (pqueue.Count > 0)
            {
                var elem = pqueue.Pop();
                if (distances[elem.To] != 0) continue;
                distances[elem.To] = elem.Distance;
                foreach (var item in graph[elem.To])
                {
                    if (item.To == a || distances[item.To] != 0) continue;
                    pqueue.Push(new Edge() { To = item.To, Distance = elem.Distance + item.Distance });
                }
            }
            Array.Sort(distances);
            int ptrTurtle = 1;
            int ptrRubbit = 1;
            for (; ptrTurtle < n; ptrTurtle++)
            {
                while (ptrRubbit < n && distances[ptrTurtle] * r >= distances[ptrRubbit] * t) 
                    ptrRubbit++;
                res += n - ptrRubbit;
                if (ptrRubbit <= ptrTurtle) res--;
            }
        }
        Console.WriteLine(res);

    }
}

struct Edge
{
    public int To;
    public int Distance;
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
