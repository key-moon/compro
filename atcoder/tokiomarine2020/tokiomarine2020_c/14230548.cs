// detail: https://atcoder.jp/contests/tokiomarine2020/submissions/14230548
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //var a = Enumerable.Repeat(0, n).ToArray();
        //nが小さい時注意
        for (int count = 0; count < k; count++)
        {
            SegmentTree<int> next = new SegmentTree<int>(n, 0, (x, y) => x + y);
            for (int i = 0; i < n; i++)
                next.Operate(Max(i - a[i], 0), Min(i + a[i], n - 1), 1);
            var isAllN = true;
            for (int i = 0; i < n; i++)
            {
                a[i] = next[i];
                if (a[i] != n) isAllN = false;
            }
            if (isAllN) break;
            //Console.WriteLine(string.Join(" ", a));
        }

        Console.WriteLine(string.Join(" ", a));
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