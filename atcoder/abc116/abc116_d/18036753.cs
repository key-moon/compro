// detail: https://atcoder.jp/contests/abc116/submissions/18036753
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++)
        {
            var td = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var t = td[0];
            var d = td[1];
            if (!dic.ContainsKey(t)) dic[t] = new List<int>();
            dic[t].Add(d);
        }
        long gSum = 0;
        PriorityQueue<int> group = new PriorityQueue<int>();
        void pushToGroup(int n) { gSum += n; group.Push(n); }
        void popFromGroup() => gSum -= group.Pop();
        PriorityQueue<int> pqueue = new PriorityQueue<int>(true);
        foreach (var (_, items) in dic)
        {
            var ordered = items.OrderByDescending(x => x).ToArray();
            pushToGroup(ordered[0]);
            foreach (var item in ordered.Skip(1)) pqueue.Push(item);
        }
        while (k < group.Count) popFromGroup();
        long curKinds = group.Count;
        while (group.Count < k) pushToGroup(pqueue.Pop());

        long res = gSum + curKinds * curKinds;
        while (1 < curKinds && pqueue.Count != 0)
        {
            popFromGroup();
            pushToGroup(pqueue.Pop());
            curKinds--;
            res = Max(res, gSum + curKinds * curKinds);
        }
        Console.WriteLine(res);
    }
}


class PriorityQueue<T> where T : IComparable<T>
{
    public int Count { get; private set; }
    private bool Descendance;
    private T[] data = new T[65536];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PriorityQueue(bool descendance = false) { Descendance = descendance; }
    public T Top
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNonEmpty(); return data[1]; }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Pop()
    {
        var top = Top;
        var elem = data[Count--];
        int index = 1;
        while (true)
        {
            if ((index << 1) >= Count)
            {
                if (index << 1 > Count) break;
                if (elem.CompareTo(data[index << 1]) > 0 ^ Descendance) data[index] = data[index <<= 1];
                else break;
            }
            else
            {
                var nextIndex = data[index << 1].CompareTo(data[(index << 1) + 1]) <= 0 ^ Descendance ? (index << 1) : (index << 1) + 1;
                if (elem.CompareTo(data[nextIndex]) > 0 ^ Descendance) data[index] = data[index = nextIndex];
                else break;
            }
        }
        data[index] = elem;
        return top;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Push(T value)
    {
        int index = ++Count;
        if (data.Length == Count) Extend(data.Length * 2);
        while ((index >> 1) != 0)
        {
            if (data[index >> 1].CompareTo(value) > 0 ^ Descendance) data[index] = data[index >>= 1];
            else break;
        }
        data[index] = value;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Extend(int newSize)
    {
        T[] newDatas = new T[newSize];
        data.CopyTo(newDatas, 0);
        data = newDatas;
    }
    private void ValidateNonEmpty() { if (Count == 0) throw new Exception(); }
}
