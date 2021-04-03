// detail: https://codeforces.com/contest/1503/submission/111901184
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
        var ac = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();
        var sorted = ac.OrderBy(x => x[0]).Select(x => (a: x[0], c: x[1])).ToArray();
        var accum = new long[n + 1];
        for (int i = 0; i < sorted.Length; i++)
            accum[i + 1] = accum[i] + sorted[i].a;
        SegmentTree<long> segTree = new SegmentTree<long>(n, long.MaxValue, Min);
        segTree[0] = 0;
        for (int i = 0; i < n; i++)
        {
            var (a, c) = sorted[i];
            var freeUntil = a + c;
            int valid = i;
            int invalid = n;
            while ((invalid - valid) > 1)
            {
                var mid = (valid + invalid) / 2;
                if (sorted[mid].a <= freeUntil) valid = mid;
                else invalid = mid;
            }
            segTree.Operate(i, valid, segTree[i]);
            if (invalid < n)
            {
                segTree.Operate(invalid, segTree[i] + sorted[invalid].a - freeUntil);
            }
        }
        var res = segTree[n - 1] + sorted.Sum(x => x.c);
        Console.WriteLine(res);
    }
}


class SegmentTree<T>
{
    public readonly int Size;
    T Identity;
    Func<T, T, T> Merge;
    int LeafCount;
    int Height;
    T[] Operators;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        Height = 1;
        LeafCount = 1;
        while (LeafCount < size) { Height++; LeafCount <<= 1; }
        Operators = new T[LeafCount << 1];
        for (int i = 0; i < Operators.Length; i++) Operators[i] = identity;
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Query(index); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { Propagate(index += LeafCount); Operators[index] = value; }
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x) { Propagate(i += LeafCount); Operators[i] = Merge(Operators[i], x); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int l, int r, T x)
    {
        l += LeafCount;
        r += LeafCount;
        Propagate(l);
        Propagate(r);
        while (l <= r)
        {
            if ((l & 1) == 1) Operators[l] = Merge(Operators[l], x);
            if ((r & 1) == 0) Operators[r] = Merge(Operators[r], x);
            l = (l + 1) / 2;
            r = (r - 1) / 2;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int index)
    {
        index += LeafCount;
        Propagate(index);
        return Operators[index];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Propagate(int sectionIndex)
    {
        for (int i = Height - 1; i >= 1; i--)
        {
            var section = sectionIndex >> i;
            var leftChild = sectionIndex >> (i - 1);
            var rightChild = leftChild ^ 1;
            Operators[leftChild] = Merge(Operators[leftChild], Operators[section]);
            Operators[rightChild] = Merge(Operators[rightChild], Operators[section]);
            Operators[section] = Identity;
        }
    }
}