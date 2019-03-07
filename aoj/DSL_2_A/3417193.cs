// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/DSL_2_A/judge/3417193/C#
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

class P
{
    static void Main()
    {
        var nq = Console.ReadLine().Split().Select(int.Parse).ToList();
        SegmentTree<int> RMQ = new SegmentTree<int>(Enumerable.Repeat(int.MaxValue, nq[0]).ToArray(), int.MaxValue, (x, y) => Min(x, y));
        for (int i = 0; i < nq[1]; i++)
        {
            var a = Console.ReadLine().Split().Select(int.Parse).ToList();
            if (a[0] == 0) RMQ.Update(a[1], a[2]);
            if (a[0] == 1) Console.WriteLine(RMQ.Query(a[1], a[2] + 1));
        }
    }
}


class SegmentTree<T>
{
    public int Size { get; private set; }
    T IdentityElement;
    T[] Data;
    Func<T, T, T> Merge;
    int LeafCount;

    public SegmentTree(int size, T identityElement, Func<T, T, T> merge) : this(Enumerable.Repeat(identityElement, size).ToArray(), identityElement, merge) { }

    public SegmentTree(T[] elems, T identityElement, Func<T, T, T> merge)
    {
        Size = elems.Length;
        Merge = merge;
        IdentityElement = identityElement;
        LeafCount = 1;
        while (LeafCount < elems.Length) LeafCount <<= 1;

        Data = new T[LeafCount * 2];
        elems.CopyTo(Data, LeafCount);
        for (int i = LeafCount - 1; i >= 1; i--) Data[i] = Merge(Data[i * 2], Data[i * 2 + 1]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Update(int i, T x)
    {
        i += LeafCount;
        Data[i] = x;
        while (0 < (i >>= 1)) Data[i] = Merge(Data[i * 2], Data[i * 2 + 1]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int l, int r)
    {  // sum on interval [l, r)
        l += LeafCount;
        r += LeafCount;
        T lRes = IdentityElement;
        T rRes = IdentityElement;
        while (l < r)
        {
            if ((l & 1) == 1) lRes = Merge(lRes, Data[l++]);
            if ((r & 1) == 1) rRes = Merge(Data[--r], rRes);
            l >>= 1;
            r >>= 1;
        }
        return Merge(lRes, rRes);
    }
}
