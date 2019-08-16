// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/DSL_2_E/judge/3814170/C#
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
        SegmentTree<int> segTree = new SegmentTree<int>(NextInt, 0, (x, y) => x + y);
        int q = NextInt;
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < q; i++)
        {
            if (NextInt == 0)
                segTree.Operate(NextInt - 1, NextInt - 1, NextInt);
            else
                builder.AppendLine(segTree.Query(NextInt - 1).ToString());
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
    public readonly int Size;
    T[] Operators;
    Func<T, T, T> Merge;
    int LeafCount;

    public SegmentTree(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Merge = merge;
        LeafCount = 1;
        while (LeafCount < size) LeafCount <<= 1;
        Operators = new T[LeafCount * 2];
        for (int i = 0; i < Operators.Length; i++)
            Operators[i] = identity;
    }

    public T this[int index]
    {
        get { return Query(index); }
        set { Operators[index] = Merge(Operators[index], value); }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int l, int r, T x)
    {
        l += LeafCount;
        r += LeafCount;
        while (l <= r)
        {
            if ((l & 1) == 1) Operators[l] = Merge(Operators[l], x);
            if ((r & 1 ) == 0) Operators[r] = Merge(Operators[r], x);
            l = (l + 1) >> 1;
            r = (r - 1) >> 1;
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
