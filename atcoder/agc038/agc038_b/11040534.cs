// detail: https://atcoder.jp/contests/agc038/submissions/11040534
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
        var p = Console.ReadLine().Split().Select(int.Parse).ToArray();
        SegmentTree<int> minSegTree = new SegmentTree<int>(p, int.MaxValue, Min);
        SegmentTree<int> maxSegTree = new SegmentTree<int>(p, int.MinValue, Max);
        SegmentTree<Section> incrSegTree = 
            new SegmentTree<Section>(
                p.Select(x => new Section() { IsIncrease = true, L = x, R = x }).ToArray(), 
                new Section() { L = int.MaxValue, R = int.MinValue, IsIncrease = true }, 
                Section.Merge
            );
        var res = n - k + 1;
        var incrExists = incrSegTree.Query(0, k - 1).IsIncrease;
        for (int i = 0; i < n - k; i++)
        {
            var min = minSegTree.Query(i, i + k - 1);
            var max = maxSegTree.Query(i + 1, i + k);
            if (min == p[i] && max == p[i + k]) { res--; continue; }
            if (incrSegTree.Query(i + 1, i + k).IsIncrease)
                if (incrExists) res--;
                else incrExists = true;
        }
        Console.WriteLine(res);
    }
}


struct Section
{
    public bool IsIncrease;
    public int L;
    public int R;
    public static Section Merge(Section a, Section b) =>
        new Section() { L = a.L, R = b.R, IsIncrease = a.IsIncrease && b.IsIncrease && a.R < b.L };
}

class SegmentTree<T>
{
    public int Size { get; private set; }
    T Identity;
    T[] Data;
    Func<T, T, T> Merge;
    int LeafCount;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(int size, T identity, Func<T, T, T> merge)
    {
        Init(size, identity, merge);
        for (int i = 1; i < Data.Length; i++) Data[i] = identity;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(T[] elems, T identity, Func<T, T, T> merge)
    {
        Init(elems.Length, identity, merge);
        elems.CopyTo(Data, LeafCount);
        for (int i = elems.Length + LeafCount; i < Data.Length; i++) Data[i] = identity;
        for (int i = LeafCount - 1; i >= 1; i--) Data[i] = Merge(Data[i << 1], Data[(i << 1) | 1]);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Init(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        LeafCount = 1;
        while (LeafCount < size) LeafCount <<= 1;
        Data = new T[LeafCount << 1];
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Data[LeafCount + index]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { Update(index, value); }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Update(int i, T x) { Data[i += LeafCount] = x; while (0 < (i >>= 1)) Data[i] = Merge(Data[i << 1], Data[(i << 1) | 1]); }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x) { Data[i += LeafCount] = Merge(Data[i], x); while (0 < (i >>= 1)) Data[i] = Merge(Data[i << 1], Data[(i << 1) | 1]); }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int l, int r)
    {
        T lRes = Identity, rRes = Identity;
        for (l += LeafCount, r += LeafCount; l <= r; l = (l + 1) >> 1, r = (r - 1) >> 1)
        {
            if ((l & 1) == 1) lRes = Merge(lRes, Data[l]); if ((r & 1) == 0) rRes = Merge(Data[r], rRes);
        }
        return Merge(lRes, rRes);
    }
}
