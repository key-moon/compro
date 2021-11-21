// detail: https://atcoder.jp/contests/arc129/submissions/27426879
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
        var lrs = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();
        var pts = lrs.SelectMany(x => x).Distinct().OrderBy(x => x).ToArray();
        var dic = pts.Select((elem, ind) => (elem, ind)).ToDictionary(x => x.elem, x => x.ind);
        SegmentTree<(long, long)> segTree = new SegmentTree<(long, long)>(pts.Length, (0, 0), (a, b) => (a.Item1 + b.Item1, a.Item2 + b.Item2));

        long maxL = -1;
        long minR = int.MaxValue;
        foreach (var lr in lrs)
        {
            var l = lr[0];
            var r = lr[1];
            maxL = Max(maxL, l);
            minR = Min(minR, r);
            Console.WriteLine(Max((maxL - minR + 1) / 2, 0));
        }
    }
}

class SegmentTree<T>
{
    public readonly int Size;
    T[] Operators;
    Func<T, T, T> Merge;
    int LeafCount;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Merge = merge;
        LeafCount = 1;
        while (LeafCount < size) LeafCount <<= 1;
        Operators = new T[LeafCount << 1];
        for (int i = 0; i < Operators.Length; i++)
            Operators[i] = identity;
    }
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Query(index); }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x) { i += LeafCount; Operators[i] = Merge(Operators[i], x); }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int l, int r, T x)
    {
        for (l += LeafCount, r += LeafCount; l <= r; l = (l + 1) >> 1, r = (r - 1) >> 1)
        {
            if ((l & 1) == 1) Operators[l] = Merge(Operators[l], x);
            if ((r & 1) == 0) Operators[r] = Merge(Operators[r], x);
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int i)
    {
        i += LeafCount;
        T res = Operators[i];
        while (0 < (i >>= 1)) res = Merge(res, Operators[i]);
        return res;
    }
}
