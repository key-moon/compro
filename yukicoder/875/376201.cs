// detail: https://yukicoder.me/submissions/376201
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
        SegmentTree<Tuple<int, int>> rmq = new SegmentTree<Tuple<int, int>>(a.Select((x, y) => new Tuple<int, int>(x, y + 1)).ToArray(), new Tuple<int, int>(int.MaxValue, -1), (x, y) => x.Item1 < y.Item1 ? x : y);
        for (int i = 0; i < nq[1]; i++)
        {
            var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (query[0] == 1)
            {
                var tmp = rmq[query[1] - 1].Item1;
                rmq[query[1] - 1] = new Tuple<int, int>(rmq[query[2] - 1].Item1, query[1]);
                rmq[query[2] - 1] = new Tuple<int, int>(tmp, query[2]);
            }
            else
            {
                Console.WriteLine(rmq.Query(query[1] - 1, query[2] - 1).Item2);
            }
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

        Data = new T[LeafCount << 1];
        elems.CopyTo(Data, LeafCount);
        for (int i = elems.Length + LeafCount; i < Data.Length; i++) Data[i] = IdentityElement;
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
