// detail: https://atcoder.jp/contests/abc175/submissions/15943734
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
        var a = Enumerable.Repeat(0, n).Select(_ =>
        {
            var sc = Console.ReadLine().Split();
            return (sc[0], long.Parse(sc[1]));
        }).ToArray();

        var ids = new int[n][];
        var memo = new List<(int, int)>();

        int OFFSET = 0;
        for (int i = 0; i < n; i++)
        {
            ids[i] = new int[a[i].Item1.Length + 1];
            for (int j = 0; j < ids[i].Length; j++)
            {
                ids[i][j] = OFFSET++;
                memo.Add((i, j));
            }
        }

        var strAndPos = memo.ToArray();

        const long MAX = long.MaxValue / 2;

        long[] costs = Enumerable.Repeat(MAX, OFFSET * 2).ToArray();
        PriorityQueue<(int, long), long> pqueue = new PriorityQueue<(int, long), long>(x => x.Item2);

        for (int i = 0; i < n; i++)
        {
            pqueue.Push((ids[i][0], a[i].Item2));
            pqueue.Push((OFFSET + ids[i][0], a[i].Item2));
        }
        //
        //0123 4567
        while (pqueue.Count > 0)
        {
            var (id, cost) = pqueue.Pop();
            if (costs[id] < cost) continue;
            costs[id] = cost;
            bool isBackWards = OFFSET <= id;
            if (isBackWards) id -= OFFSET;
            var (sInd, pos) = strAndPos[id];
            var s = a[sInd].Item1;
            for (int tInd = 0; tInd < n; tInd++)
            {
                var t = a[tInd].Item1;
                int i, j;
                if (!isBackWards)
                {
                    for (i = pos, j = t.Length - 1; i < s.Length && j >= 0; i++, j--)
                    {
                        if (s[i] != t[j]) goto end;
                    }
                    if (s.Length - pos >= t.Length)
                    {
                        var newPos = pos + t.Length;
                        pqueue.Push((ids[sInd][newPos], cost + a[tInd].Item2));
                    }
                    else
                    {
                        var newPos = s.Length - pos;
                        pqueue.Push((ids[tInd][newPos] + OFFSET, cost + a[tInd].Item2));
                    }
                    end:;
                }
                else
                {
                    for (i = s.Length - pos - 1, j = 0; i >= 0 && j < t.Length; i--, j++)
                    {
                        if (s[i] != t[j]) goto end;
                    }

                    if (s.Length - pos >= t.Length)
                    {
                        var newPos = pos + t.Length;
                        pqueue.Push((ids[sInd][newPos] + OFFSET, cost + a[tInd].Item2));
                    }
                    else
                    {
                        var newPos = s.Length - pos;
                        pqueue.Push((ids[tInd][newPos], cost + a[tInd].Item2));
                    }
                    end:;
                }
            }
        }

        bool isPalindrome(string s)
        {
            for (int i = 0, j = s.Length - 1; i < s.Length; i++, j--)
                if (s[i] != s[j]) return false;
            return true;
        }

        var res = long.MaxValue / 2;
        for (int i = 0; i < ids.Length; i++)
        {
            var s = a[i].Item1;
            var curRes = Min(costs[ids[i][s.Length]], costs[ids[i][s.Length] + OFFSET]);
            for (int j = 0; j < s.Length; j++)
            {
                if (isPalindrome(s[j..])) curRes = Min(curRes, costs[ids[i][j]]);
                if (isPalindrome(s[..^j])) curRes = Min(curRes, costs[ids[i][j] + OFFSET]);
            }

            res = Min(res, curRes);
        }
        if (MAX <= res) res = -1;
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
