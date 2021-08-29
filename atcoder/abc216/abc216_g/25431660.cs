// detail: https://atcoder.jp/contests/abc216/submissions/25431660
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
        var constraints = Enumerable.Repeat(0, m).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => (l: x[0] - 1, r: x[1] - 1, x: x[2])).ToArray();
        int[] res = new int[n];
        SegmentTree<int> segTree = new SegmentTree<int>(n, 0, (x, y) => x + y);
        PriorityQueue<int> pqueue = new PriorityQueue<int>(true);
        int nextUpdate = 0;
        foreach (var (l, r, x) in constraints.OrderBy(x => x.r))
        {
            while (nextUpdate <= r)
            {
                pqueue.Push(nextUpdate);
                nextUpdate++;
            }
            var curSum = segTree.Query(l, r);
            while (curSum < x)
            {
                var pos = pqueue.Pop();
                res[pos]++;
                segTree[pos]++;
                curSum++;
            }
        }
        Console.WriteLine(string.Join(" ", res));
    }
}



class SegmentTree<T>
{
    public int Size { get; private set; }
    T Identity;
    T[] Data;
    Func<T, T, T> Merge;
    int LeafCount;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(int size, T identity, Func<T, T, T> merge)
    {
        Init(size, identity, merge);
        for (int i = 1; i < Data.Length; i++) Data[i] = identity;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(T[] elems, T identity, Func<T, T, T> merge)
    {
        Init(elems.Length, identity, merge);
        elems.CopyTo(Data, LeafCount);
        for (int i = elems.Length + LeafCount; i < Data.Length; i++) Data[i] = identity;
        for (int i = LeafCount - 1; i >= 1; i--) Data[i] = Merge(Data[i << 1], Data[(i << 1) | 1]);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Init(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        LeafCount = 1;
        while (LeafCount < size) LeafCount <<= 1;
        Data = new T[LeafCount << 1];
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Data[LeafCount + index]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { Update(index, value); }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Update(int i, T x) { Data[i += LeafCount] = x; while (0 < (i >>= 1)) Data[i] = Merge(Data[i << 1], Data[(i << 1) | 1]); }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x) { Data[i += LeafCount] = Merge(Data[i], x); while (0 < (i >>= 1)) Data[i] = Merge(Data[i << 1], Data[(i << 1) | 1]); }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int l, int r)
    {
        T lRes = Identity, rRes = Identity;
        for (l += LeafCount, r += LeafCount; l <= r; l = (l + 1) >> 1, r = (r - 1) >> 1)
        {
            if ((l & 1) == 1) lRes = Merge(lRes, Data[l]); if ((r & 1) == 0) rRes = Merge(Data[r], rRes);
        }
        return Merge(lRes, rRes);
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
