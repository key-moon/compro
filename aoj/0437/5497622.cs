// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0437/judge/5497622/C#
//#define DEBUG
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
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        const long MUL = 1L << 32;
        const long MASK = MUL - 1;
        //const int SIZE = 3;
        const int SIZE = 150;
#if DEBUG
        var a = Enumerable.Range(0, n).ToArray();
        var b = Enumerable.Range(0, n).ToArray();
#else
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(long.Parse).ToArray();
#endif
        var aBlocks = new long[n / SIZE + 1];
        var bAccums = new long[b.Length + 1];

        SegmentTree<long> segTree = new SegmentTree<long>(n, 0, Max);
        for (int i = 0; i < a.Length; i++) aBlocks[i / SIZE] += a[i];
        for (int i = 1; i < bAccums.Length; i++) bAccums[i] = bAccums[i - 1] + b[i - 1];

        for (int iter = 1; iter <= m; iter++)
        {
#if DEBUG
            //var ops = new[] { 0, 2, 1, n - 1 };
            var ops = new[] { 1, 2, n - 1 };
#else
            var ops = Console.ReadLine().Split().Select(int.Parse).ToArray();
#endif
            if (ops[0] == 0)
            {
                var z = ops[3];
                var aS = ops[1] - 1;
                var aT = aS + z;
                var bS = ops[2] - 1;
                var bT = bS + z;

                int blockBegin = (aS + SIZE - 1) / SIZE;
                int blockEnd = aT / SIZE;
                if (blockBegin <= blockEnd)
                {
                    for (int i = aS; i < blockBegin * SIZE; i++)
                    {
                        var ind = segTree[i];
                        if (ind == 0) aBlocks[blockBegin - 1] -= a[i];
                        else aBlocks[blockBegin - 1] -= b[(ind + i) & MASK];
                        aBlocks[blockBegin - 1] += b[i - aS + bS];
                    }
                    for (int i = blockEnd * SIZE; i < aT; i++)
                    {
                        var ind = segTree[i];
                        if (ind == 0) aBlocks[blockEnd] -= a[i];
                        else aBlocks[blockEnd] -= b[(ind + i) & MASK];
                        aBlocks[blockEnd] += b[i - aS + bS];
                    }
                    for (int i = blockBegin; i < blockEnd; i++)
                    {
                        var bBegin = bS + i * SIZE - aS;
                        var bEnd = bBegin + SIZE;
                        aBlocks[i] = bAccums[bEnd] - bAccums[bBegin];
                    }
                }
                else
                {
                    for (int i = aS; i < aT; i++)
                    {
                        var ind = segTree[i];
                        if (ind == 0) aBlocks[blockEnd] -= a[i];
                        else aBlocks[blockEnd] -= b[(ind + i) & MASK];
                        aBlocks[blockEnd] += b[i - aS + bS];
                    }
                }
                segTree.Operate(aS, aT - 1, unchecked((uint)(bS - aS)) + MUL * iter);
            }
            if (ops[0] == 1)
            {
                long sum = 0;
                var p = ops[1] - 1;
                var q = ops[2] - 1 + 1;
                int blockBegin = (p + SIZE - 1) / SIZE;
                int blockEnd = q / SIZE;
                if (blockBegin <= blockEnd)
                {
                    for (int i = blockBegin * SIZE - 1; i >= p; i--)
                    {
                        var ind = segTree[i];
                        if (ind == 0) sum += a[i];
                        else sum += b[(ind + i) & MASK];
                    }
                    for (int i = blockEnd * SIZE; i < q; i++)
                    {
                        var ind = segTree[i];
                        if (ind == 0) sum += a[i];
                        else sum += b[(ind + i) & MASK];
                    }
                    for (int i = blockBegin; i < blockEnd; i++) sum += aBlocks[i];
                }
                else
                {
                    for (int i = p; i < q; i++)
                    {
                        var ind = segTree[i];
                        if (ind == 0) sum += a[i];
                        else sum += b[(ind + i) & MASK];
                    }
                }
                Console.WriteLine(sum);
            }
        }
        Console.Out.Flush();
    }
}


class SegmentTree<T>
{
    public readonly int Size;
    T[] Operators;
    Func<T, T, T> Merge;
    int LeafCount;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Merge = merge;
        LeafCount = 1;
        while (LeafCount < size) LeafCount <<= 1;
        Operators = new T[LeafCount << 1];
        for (int i = 0; i < Operators.Length; i++)
            Operators[i] = identity;
    }
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Query(index); }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x) { i += LeafCount; Operators[i] = Merge(Operators[i], x); }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int l, int r, T x)
    {
        for (l += LeafCount, r += LeafCount; l <= r; l = (l + 1) >> 1, r = (r - 1) >> 1)
        {
            if ((l & 1) == 1) Operators[l] = Merge(Operators[l], x);
            if ((r & 1) == 0) Operators[r] = Merge(Operators[r], x);
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


