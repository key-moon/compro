// detail: https://atcoder.jp/contests/tokiomarine2020/submissions/14246603
//#define F
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Reader;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var n = NextInt;
        var half = Min(1 << 10, n);
#if F
        var vw = Enumerable.Repeat(0, n).Select(_ => new Obj() { V = 114, W = 514 }).ToArray();
        var q = 100000;
#else
        var vw = Enumerable.Repeat(0, n).Select(_ => new Obj() { V = NextInt, W = NextInt }).ToArray();
        var q = NextInt;
#endif

        int getPInd(int ind) => ((ind + 1) >> 1) - 1;

        //半分全列挙
        int[][] dps = Enumerable.Repeat(0, half).Select(_ => new int[100001]).ToArray();
        dps[0][vw[0].W] = vw[0].V;
        for (int i = 1; i < half; i++)
        {
            var value = vw[i].V;
            var weight = vw[i].W;
            var parent = dps[getPInd(i)];
            for (int j = 100001 - 1; j >= 0; j--)
            {
                dps[i][j] = parent[j];
                if (j + weight < parent.Length) dps[i][j + weight] = Max(dps[i][j + weight], parent[j] + value);
            }
        }

        int[][] accum = Enumerable.Repeat(0, half).Select(_ => new int[100001]).ToArray();
        for (int i = 0; i < half; i++)
        {
            accum[i][0] = dps[i][0];
            for (int j = 1; j < dps[i].Length; j++)
                accum[i][j] = Max(dps[i][j], accum[i][j - 1]);
        }

        List<(int weight, int value)> l1 = new List<(int weight, int value)>(1024);
        List<(int weight, int value)> l2 = new List<(int weight, int value)>(1024);

        for (int _ = 0; _ < q; _++)
        {
#if F
            var ind = n - 1;
            var maxWeight = 13413;
#else
            var ind = NextInt - 1;
            var maxWeight = NextInt;
#endif
            if (ind < half)
            {
                Console.WriteLine(accum[ind][maxWeight]);
                continue;
            }
            List<(int weight, int value)> list = l1;
            var nextList = l2;
            list.Add((0, 0));
            while (ind >= half)
            {
                List<(int weight, int value)> newlist = nextList;

                foreach (var (weight, value) in list)
                {
                    newlist.Add((weight, value));
                    newlist.Add((weight + vw[ind].W, value + vw[ind].V));
                }

                nextList = list;
                nextList.Clear();
                list = newlist;
                ind = getPInd(ind);
            }
            int res = 0;
            foreach (var (weight, value) in list)
            {
                var i = maxWeight - weight;
                if (i < 0 || accum[ind].Length <= i) continue;
                res = Max(res, accum[ind][i] + value);
            }
            list.Clear();
            Console.WriteLine(res);
        }
        Console.Out.Flush();
    }
}

struct Obj
{
    public int V;
    public int W;
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


static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = BUF_SIZE - 1;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }

    public static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (int)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}
