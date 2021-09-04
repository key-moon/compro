// detail: https://atcoder.jp/contests/abc217/submissions/25573665
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
        var lq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var length = lq[0];
        var q = lq[1];

        var queries = Enumerable.Repeat(0, q).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();

        var lines = queries.Select(x => x[1]).OrderBy(x => x).Prepend(0).Append(length).Distinct().ToArray();
        var dic = lines.Select((item, ind) => (item, ind)).ToDictionary(x => x.item, x => x.ind);
        SegmentTree<(int, int)> segTree = new SegmentTree<(int, int)>
            (
                lines.Length + 1,
                (-1, -1),
                (x, y) => y.Item1 == -1 ? x : y
            );
        segTree.Operate(0, segTree.Size - 1, (0, lines.Length - 1));

        foreach (var query in queries)
        {
            var c = query[0];
            var x = query[1];
            var xind = dic[x];
            var (L, R) = segTree[xind];
            if (c == 1)
            {
                segTree.Operate(L, xind, (L, xind));
                segTree.Operate(xind + 1, R, (xind, R));
            }
            if (c == 2)
            {
                Console.WriteLine(lines[R] - lines[L]);
            }
        }
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
