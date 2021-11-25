// detail: https://atcoder.jp/contests/abc020/submissions/27484682
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
        var hwt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwt[0];
        var w = hwt[1];
        var t = hwt[2];
        var map = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine()).ToArray();

        int sx = -1, sy = -1;
        int gx = -1, gy = -1;
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                if (map[i][j] == 'S')
                {
                    (sy, sx) = (i, j);
                }
                if (map[i][j] == 'G')
                {
                    (gy, gx) = (i, j);
                }
            }
        }

        var ds = new[] { (-1, 0), (0, -1), (1, 0), (0, 1) };

        long valid = 0, invalid = int.MaxValue;
        while (invalid - valid > 1)
        {
            var mid = (valid + invalid) / 2;

            var min = Enumerable.Range(0, h).Select(_ => Enumerable.Repeat(long.MaxValue / 2, w).ToArray()).ToArray();

            PriorityQueue<((int, int), long), long> pqueue = new PriorityQueue<((int, int), long), long>(x => x.Item2);
            pqueue.Push(((sy, sx), 0));
            while (pqueue.Count != 0)
            {
                var ((y, x), dist) = pqueue.Pop();
                if (min[y][x] <= dist) continue;
                min[y][x] = dist;

                foreach (var (dy, dx) in ds)
                {
                    int ny = y + dy;
                    int nx = x + dx;
                    if (ny < 0 || h <= ny || nx < 0 || w <= nx) continue;
                    var ndist = dist + (map[ny][nx] == '#' ? mid : 1);
                    if (min[ny][nx] <= ndist) continue;
                    pqueue.Push(((ny, nx), ndist));
                }
            }

            if (min[gy][gx] <= t) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(valid);
    }
}


class PriorityQueue<TValue, TKey> where TKey : IComparable<TKey>
{
    public int Count { get; private set; }
    private Func<TValue, TKey> KeySelector;
    private bool Descendance;
    private TValue[] data = new TValue[16];
    private TKey[] keys = new TKey[16];
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
