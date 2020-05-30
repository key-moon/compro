// detail: https://atcoder.jp/contests/nomura2020/submissions/13739062
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
        var t = Console.ReadLine().Select(x => x == '1').ToArray();
        //101010101→後ろから抜いていくのが得策
        //できる限り早く抜いて最大を構築して、あとは後ろから抜いてく
        //構築でどうするのが最適か
        //前から抜いてくのが最適?
        SegmentTree<int> evenOne = new SegmentTree<int>(t.Select((x, y) => x && y % 2 == 0 ? 1 : 0).ToArray(), 0, (x, y) => x + y);
        SegmentTree<int> oddOne = new SegmentTree<int>(t.Select((x, y) => x && y % 2 == 1 ? 1 : 0).ToArray(), 0, (x, y) => x + y);
        
        //操作の度に操作前を足す
        long res = 0;

        int remainCount = t.Length;
        long curValids = 0;
        for (int i = 0; i < t.Length; i += 2)
        {
            if (!t[i])
            {
                //remove t_i
                res += curValids + (i % 2 == 0 ? evenOne : oddOne).Query(i, t.Length - 1);
                i--;
                remainCount--;
            }
            else
            {
                curValids++;
            }
        }
        //要素数がiのとき
        for (int i = remainCount; i >= 1; i--)
        {
            res += curValids;
            if (i % 2 == 1) curValids--;
        }
        Console.WriteLine(res);
    }
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
