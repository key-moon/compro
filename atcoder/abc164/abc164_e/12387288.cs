// detail: https://atcoder.jp/contests/abc164/submissions/12387288
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
        var nms = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nms[0];
        var m = nms[1];
        var s = nms[2];
        //銀貨n枚持ってるの頂点を作る

        List<Edge>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<Edge>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var uvab = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            var u = uvab[0] - 1;
            var v = uvab[1] - 1;
            var a = uvab[2];
            var b = uvab[3];
            graph[u].Add(new Edge() { From = u, To = v, Fee = a, Time = b });
            graph[v].Add(new Edge() { From = v, To = u, Fee = a, Time = b });
        }

        var ex = Enumerable.Repeat(0, n).Select(_ =>
        {
            var cd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            return new Exchange() { Rate = cd[0], Time = cd[1] };
        }).ToArray();
        
        const int maxSickle = 50 * 50 + 1;
        static int Encode(int node, long sickle) => (node << 12) + (int)Min(maxSickle - 1, sickle);
        static (int node, int sickle) decode(int id) => (id >> 12, id & 4095);

        long[] minTime = Enumerable.Repeat(long.MaxValue, n << 12).ToArray();
        var pqueue = new PriorityQueue<Tuple<int, long>, long>(edge => edge.Item2);

        pqueue.Push(new Tuple<int, long>(Encode(0, s), 0));

        while (pqueue.Count > 0)
        {
            var elem = pqueue.Pop();
            var id = elem.Item1;
            (var node, var sickle) = decode(id);
            var time = elem.Item2;
            if (minTime[id] != long.MaxValue) continue;
            minTime[id] = time;

            foreach (var item in graph[node])
            {
                if (sickle < item.Fee) continue;
                var encoded = Encode(item.To, sickle - item.Fee);
                var nextTime = time + item.Time;
                if (minTime[encoded] != long.MaxValue) continue;
                pqueue.Push(
                    new Tuple<int, long>(
                            encoded, 
                            nextTime
                        )
                    );
            }

            {
                var encoded = Encode(node, sickle + ex[node].Rate);
                var nextTime = time + ex[node].Time;
                if (minTime[encoded] != long.MaxValue) continue;
                pqueue.Push(
                    new Tuple<int, long>(
                            encoded,
                            nextTime
                        )
                    );
            
            }
        }

        for (int t = 1; t < n; t++)
        {
            var res = Enumerable.Range(0, maxSickle).Select(x => minTime[Encode(t, x)]).Min();
            Console.WriteLine(res);
        }
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

class Edge
{
    public int From;
    public int To;
    public int Fee;
    public long Time;
}

class Exchange
{
    public long Rate;
    public long Time;
}
