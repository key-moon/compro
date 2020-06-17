// detail: https://atcoder.jp/contests/tokiomarine2020/submissions/14436349
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
        var monoid = new AbelianMonoid<int>((x, y) => x + y, 0);
        for (int count = 0; count < k; count++)
        {
            RangeGetSegmentTree<int> next = new RangeGetSegmentTree<int>(n, monoid);
            for (int i = 0; i < n; i++)
                next.Operate(Max(i - a[i], 0), Min(i + a[i], n - 1), 1);
            var isAllN = true;
            for (int i = 0; i < n; i++)
            {
                a[i] = next[i];
                if (a[i] != n) isAllN = false;
            }
            if (isAllN) break;
        }

        Console.WriteLine(string.Join(" ", a));
    }
}

class Monoid<T>
{
    public Func<T, T, T> Operation { get; }
    public T Identity { get; }

    public Monoid(Func<T, T, T> operation, T identity)
    {
        Operation = operation;
        Identity = identity;
    }
}

class AbelianMonoid<T> : Monoid<T>
{
    public AbelianMonoid(Func<T, T, T> operation, T identity) : base(operation, identity) { }
}

class RangeGetSegmentTree<T>
{
    public readonly int Size;
    readonly bool IsCommutative;
    Func<T, T, T> Merge;
    T Identity;
    T[] Operators;
    int Height;
    int LeafCount;

    public RangeGetSegmentTree(int size, Monoid<T> monoid)
    {
        Size = size;
        Identity = monoid.Identity;
        Merge = monoid.Operation;
        Height = 1;
        LeafCount = 1;
        while (LeafCount < size) { Height++; LeafCount <<= 1; }
        Operators = new T[LeafCount << 1];
        for (int i = 0; i < Operators.Length; i++)
            Operators[i] = monoid.Identity;
    }
    public RangeGetSegmentTree(int size, AbelianMonoid<T> monoid) : this(size, monoid as Monoid<T>) { IsCommutative = true; }

    public T this[int index]
    {
        get { return Query(index); }
        set { Propagate(index += LeafCount); Operators[index] = value; }
    }

    public void Operate(int i, T x)
    {
        i += LeafCount;
        if (!IsCommutative) Propagate(i);
        Operators[i] = Merge(Operators[i], x);
    }

    public void Operate(int l, int r, T x)
    {
        l += LeafCount; r += LeafCount;
        if (!IsCommutative) Propagate(l, r);
        for (; l <= r; l = (l + 1) >> 1, r = (r - 1) >> 1)
        {
            if ((l & 1) == 1) Operators[l] = Merge(Operators[l], x);
            if ((r & 1) == 0) Operators[r] = Merge(Operators[r], x);
        }
    }

    public T Query(int index)
    {
        index += LeafCount;
        Propagate(index);
        return Operators[index];
    }

    private void Eval(int section)
    {
        var leftChild = section << 1;
        var rightChild = leftChild | 1;
        Operators[leftChild] = Merge(Operators[leftChild], Operators[section]);
        Operators[rightChild] = Merge(Operators[rightChild], Operators[section]);
        Operators[section] = Identity;
    }

    private void Propagate(int sectionIndex)
    {
        for (int i = Height - 1; i >= 1; i--)
            Eval(sectionIndex >> i);
    }

    private void Propagate(int l, int r)
    {
        if (l == r) { Propagate(l); return; }
        int xor = l ^ r, i = Height - 1;
        for (; (xor >> i) == 0; i--) { Eval(l >> i); }
        for (; i >= 1; i--) { Eval(l >> i); Eval(r >> i); }
    }
}
