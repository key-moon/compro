// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/DSL_2_D/judge/3814963/C#
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        SegmentTree<int> segTree = new SegmentTree<int>(NextInt, -1, (x, y) => y == -1 ? x : y);
        segTree.Operate(0, segTree.Size - 1, int.MaxValue);
        int q = NextInt;
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < q; i++)
        {
            if (NextInt == 0)
                segTree.Operate(NextInt, NextInt, NextInt);
            else
                builder.AppendLine(segTree[NextInt].ToString());
        }
        Console.Write(builder.ToString());
    }


    static readonly TextReader In = Console.In;
    static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0;
            int next = In.Read();
            while (45 > next || next > 57) next = In.Read();
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = In.Read();
            }
            return res;
        }
    }
}


class SegmentTree<T>
{
    public int Size { get; private set; }
    T Identity;
    Func<T, T, T> Merge;
    Func<T, T> GetLeftHalf;
    Func<T, T> GetRightHalf;
    int LeafCount;
    int Height;
    T[] Operators;

    public SegmentTree(int size, T identity, Func<T, T, T> merge) : this(size, identity, merge, x => x) { }
    public SegmentTree(int size, T identity, Func<T, T, T> merge, Func<T, T> split) : this(size, identity, merge, split, split) { }
    public SegmentTree(int size, T identity, Func<T, T, T> merge, Func<T, T> getLeftHalf, Func<T, T> getRightHalf)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        GetLeftHalf = getLeftHalf;
        GetRightHalf = getRightHalf;
        Height = 1;
        LeafCount = 1;
        while (LeafCount < size)
        {
            Height++;
            LeafCount <<= 1;
        }
        Operators = new T[LeafCount << 1];
        for (int i = 0; i < Operators.Length; i++)
            Operators[i] = identity;
    }

    public SegmentTree(T[] elem, T identity, Func<T, T, T> merge) : this(elem, identity, merge, x => x) { }
    public SegmentTree(T[] elem, T identity, Func<T, T, T> merge, Func<T, T> split) : this(elem, identity, merge, split, split) { }
    public SegmentTree(T[] elem, T identity, Func<T, T, T> merge, Func<T, T> getLeftHalf, Func<T, T> getRightHalf)
    {
        Size = elem.Length;
        Identity = identity;
        Merge = merge;
        GetLeftHalf = getLeftHalf;
        GetRightHalf = getRightHalf;
        Height = 1;
        LeafCount = 1;
        while (LeafCount < Size)
        {
            Height++;
            LeafCount <<= 1;
        }
        Operators = new T[LeafCount << 1];
        for (int i = 0; i < LeafCount; i++)
            Operators[i] = identity;
        elem.CopyTo(Operators, LeafCount);
    }

    public T this[int index]
    {
        get { return Query(index); }
        set { Operate(index, index, value); }
    }

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
            var leftChild = section << 1;
            var rightChild = leftChild + 1;
            Operators[leftChild] = Merge(Operators[leftChild], Operators[section]);
            Operators[rightChild] = Merge(Operators[rightChild], Operators[section]);
            Operators[section] = Identity;
        }
    }
}

