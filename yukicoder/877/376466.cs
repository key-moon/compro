// detail: https://yukicoder.me/submissions/376466
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //クエリ先読み昇順ソート
        SegmentTree<long> rsq = new SegmentTree<long>(nq[0], 0, (x, y) => x + y);
        SegmentTree<long> rcq = new SegmentTree<long>(nq[0], 0, (x, y) => x + y);
        Stack<int> stack = new Stack<int>(a.Select((Elem, Index) => new { Elem, Index }).OrderBy(x => x.Elem).Select(x => x.Index));
        long[] res = new long[nq[1]];
        //大きいクエリから降ってくるので、できるところから追加
        foreach (var item in Enumerable.Range(0, nq[1]).Select(Index => new { Index, Elem = Console.ReadLine().Split().Select(int.Parse).ToArray() }).OrderByDescending(x => x.Elem[3]))
        {
            var l = item.Elem[1] - 1;
            var r = item.Elem[2] - 1;
            var x = item.Elem[3];
            while (stack.Count != 0 && x <= a[stack.Peek()])
            {
                var ind = stack.Pop();
                rsq[ind] = a[ind];
                rcq[ind] = 1;
            }

            res[item.Index] = rsq.Query(l, r) - rcq.Query(l, r) * x;
        }
        Console.WriteLine(string.Join("\n", res));
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

        Data = new T[LeafCount << 1];
        elems.CopyTo(Data, LeafCount);
        for (int i = LeafCount - 1; i >= 1; i--) Data[i] = Merge(Data[i << 1], Data[(i << 1) + 1]);
    }

    public T this[int index]
    {
        get { return Data[LeafCount + index]; }
        set { Update(index, value); }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Update(int i, T x)
    {
        i += LeafCount;
        Data[i] = x;
        while (0 < (i >>= 1)) Data[i] = Merge(Data[i << 1], Data[(i << 1) + 1]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x)
    {
        i += LeafCount;
        Data[i] = Merge(Data[i], x);
        while (0 < (i >>= 1)) Data[i] = Merge(Data[i << 1], Data[(i << 1) + 1]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int l, int r)
    {
        l += LeafCount; r += LeafCount;
        T lRes = IdentityElement, rRes = IdentityElement;
        while (l <= r)
        {
            if ((l & 1) == 1) lRes = Merge(lRes, Data[l]);
            if ((r & 1) == 0) rRes = Merge(Data[r], rRes);
            l = (l + 1) >> 1;
            r = (r - 1) >> 1;
        }
        return Merge(lRes, rRes);
    }
}