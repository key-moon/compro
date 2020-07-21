// detail: https://codeforces.com/contest/1381/submission/87589740
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
        while (false)
        {
            var n = rng.Next(2, 5);
            var x = rng.Next(0, n);
            var y = rng.Next(x, n);
            var b = Enumerable.Range(0, n).Select(_ => rng.Next(1, n + 1)).ToArray();
            Solve(n, x, y, b);
        }
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            var nxy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = nxy[0];
            var hit = nxy[1];
            var blow = nxy[2];
            var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Solve(n, hit, blow, b);
        }
    }

    static Random rng = new Random();
    static void Solve(int n, int hit, int blow, int[] b)
    {
        var sortedB = b.Select((x, y) => new Tuple<int, int>(x, y)).OrderBy(_ => rng.Next()).OrderBy(x => x).ToArray();
        List<int> keys = new List<int>();
        Dictionary<int, Stack<int>> inds = new Dictionary<int, Stack<int>>();
        var maxStreak = 0;
        var streak = 0;
        var last = -1;
        var unused = 1;
        {
            foreach (var tuple in sortedB)
            {
                var item = tuple.Item1;
                var ind = tuple.Item2;
                if (item == unused) unused++;
                if (item != last)
                {
                    keys.Add(item);
                    inds.Add(item, new Stack<int>());
                    if (maxStreak < streak) { maxStreak = streak; }
                    streak = 0;
                }
                inds[item].Push(ind);
                streak++;
                last = item;
            }
            if (maxStreak < streak) { maxStreak = streak; }
        }
        PriorityQueue<int, int> pqueue = new PriorityQueue<int, int>(x => inds[x].Count, true);
        foreach (var item in inds)
        {
            var key = item.Key;
            var value = item.Value;
            pqueue.Push(key);
        }
        int[] res = new int[n];
        for (int i = 0; i < hit; i++)
        {
            var elem = pqueue.Pop();
            var item = inds[elem].Pop();
            res[item] = b[item];
            if (inds[elem].Count != 0) pqueue.Push(elem);
        }
        int realMaxStreak = 0;
        int[] indLists = new int[n - hit];
        int _ind = 0;
        while (pqueue.Count != 0)
        {
            var elem = pqueue.Pop();
            var stack = inds[elem];
            realMaxStreak = Max(realMaxStreak, stack.Count);
            while (stack.Count != 0)
            {
                indLists[_ind++] = stack.Pop();
            }
        }
        var cantAvoid = Max(realMaxStreak * 2 - indLists.Length, 0);
        var none = n - blow;
        if (none < cantAvoid)
        {
            Console.WriteLine("NO");
            return;
        }
        for (int i = 0; i < none; i++)
        {
            res[indLists[i]] = unused;
        }
        for (int i = none; i < indLists.Length; i++)
        {
            res[indLists[i]] = b[indLists[(i + indLists.Length - realMaxStreak) % indLists.Length]];
        }
        Console.WriteLine("YES");
        Console.WriteLine(string.Join(" ", res));
        return;
        {
            for (int i = 0; i < res.Length; i++)
            {
                if (b[i] == res[i]) { hit--; }
            }
            if (hit != 0) throw new Exception();
            int ind = 0;
            foreach (var item in res.OrderBy(x => x))
            {
                while (ind < sortedB.Length && sortedB[ind].Item1 < item) ind++;
                if (ind < sortedB.Length && sortedB[ind].Item1 == item) { blow--; ind++; }
            }
            if (blow != 0) throw new Exception();
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
