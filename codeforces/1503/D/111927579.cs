// detail: https://codeforces.com/contest/1503/submission/111927579
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
        int n = int.Parse(Console.ReadLine());

        var abs = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => (a: x[0], b: x[1])).ToArray();
        SegmentTree<long, long> segA = new SegmentTree<long, long>(2 * n + 2, int.MaxValue / 2, 0, Min, (x, y) => x + y, (x, op) => x + op);
        SegmentTree<long, long> segB = new SegmentTree<long, long>(2 * n + 2, int.MaxValue / 2, 0, Min, (x, y) => x + y, (x, op) => x + op);
        int curLower = 2 * n + 1;
        segA[curLower] = 0;
        segB[curLower] = 0;
        foreach (var item in abs.OrderBy(x => Min(x.a, x.b)))
        {
            var (a, b) = item;
            char smallSide = 'a';
            if (a > b) (a, b, smallSide) = (b, a, 'b');
            // a < b

            var minA = segA.Query(b, 2 * n + 1);
            var minB = segB.Query(b, 2 * n + 1);
            if (curLower < b)
            {
                //aをcurLowerのほうに置きたい
                if (curLower < a) { Console.WriteLine(-1); return; }
                if (smallSide == 'a') minA++;
                if (smallSide == 'b') minB++;
                segA.Update(0, 2 * n + 1, int.MaxValue / 2);
                segB.Update(0, 2 * n + 1, int.MaxValue / 2);
                segA[b] = minA;
                segB[b] = minB;
            }
            else
            {
                segA[curLower] = minB;
                segB[curLower] = minA;
                if (smallSide == 'a') segB.Update(b, 2 * n + 1, 1);
                if (smallSide == 'b') segA.Update(b, 2 * n + 1, 1);
                curLower = b;
            }

            //Console.WriteLine(string.Join(" ", Enumerable.Range(0, 2 * n + 2)));
            //Console.WriteLine(string.Join(" ", Enumerable.Range(0, 2 * n + 2).Select(x => segA[x])));
            //Console.WriteLine(string.Join(" ", Enumerable.Range(0, 2 * n + 2).Select(x => segB[x])));
        }
        var res = Min(segA.Query(0, 2 * n + 1), segB.Query(0, 2 * n + 1));
        if (int.MaxValue / 2 <= res) res = -1;
        Console.WriteLine(res);
    }
}


class SegmentTree<DataT, OperatorT>
{
    public readonly int Size;
    DataT DataIdentity;
    OperatorT OperatorIdentity;
    Func<DataT, DataT, DataT> MergeData;
    Func<OperatorT, OperatorT, OperatorT> MergeOperator;
    Func<DataT, OperatorT, DataT> Operate;
    int LeafCount;
    int Height;
    DataT[] Data;
    OperatorT[] Operators;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(int size, DataT dataIdentity, OperatorT operatorIdentity, Func<DataT, DataT, DataT> mergeData, Func<OperatorT, OperatorT, OperatorT> mergeOpeator, Func<DataT, OperatorT, DataT> operate)
        : this(dataIdentity, operatorIdentity, mergeData, mergeOpeator, operate)
    {
        Size = size;
        Build();
        for (int i = 0; i < Data.Length; i++) Data[i] = DataIdentity;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(DataT[] data, DataT dataIdentity, OperatorT operatorIdentity, Func<DataT, DataT, DataT> mergeData, Func<OperatorT, OperatorT, OperatorT> mergeOpeator, Func<DataT, OperatorT, DataT> operate)
        : this(dataIdentity, operatorIdentity, mergeData, mergeOpeator, operate)
    {
        Size = data.Length;
        Build();
        for (int i = 0; i < data.Length; i++) Data[i + LeafCount] = data[i];
        for (int i = data.Length + LeafCount; i < Data.Length; i++) Data[i] = dataIdentity;
        for (int i = LeafCount - 1; i >= 0; i--) Data[i] = MergeData(Data[i << 1], Data[(i << 1) + 1]);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private SegmentTree(DataT dataIdentity, OperatorT operatorIdentity, Func<DataT, DataT, DataT> mergeData, Func<OperatorT, OperatorT, OperatorT> mergeOpeator, Func<DataT, OperatorT, DataT> operate)
    {
        DataIdentity = dataIdentity;
        OperatorIdentity = operatorIdentity;
        MergeData = mergeData;
        MergeOperator = mergeOpeator;
        Operate = operate;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Build()
    {
        Height = 1;
        LeafCount = 1;
        while (LeafCount < Size) { Height++; LeafCount <<= 1; }
        Operators = new OperatorT[LeafCount << 1];
        for (int i = 0; i < Operators.Length; i++) Operators[i] = OperatorIdentity;
        Data = new DataT[LeafCount << 1];
    }
    public DataT this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { Propagate(index += LeafCount); return Reflect(index); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { Propagate(index += LeafCount); Data[index] = value; Operators[index] = OperatorIdentity; Calculate(index, index); }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Update(int l, int r, OperatorT x)
    {
        l += LeafCount;
        r += LeafCount;
        int origL = l, origR = r;
        while (l <= r)
        {
            if ((l & 1) == 1) Operators[l] = MergeOperator(Operators[l], x);
            if ((r & 1) == 0) Operators[r] = MergeOperator(Operators[r], x);
            l = (l + 1) >> 1; r = (r - 1) >> 1;
        }
        Calculate(origL, origR);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DataT Query(int l, int r)
    {
        l += LeafCount;
        r += LeafCount;
        DataT lRes = DataIdentity, rRes = DataIdentity;
        Propagate(l, r);
        while (l <= r)
        {
            if ((l & 1) == 1) lRes = MergeData(lRes, Reflect(l));
            if ((r & 1) == 0) rRes = MergeData(Reflect(r), rRes);
            l = (l + 1) >> 1; r = (r - 1) >> 1;
        }
        return MergeData(lRes, rRes);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Propagate(int ind) { for (int i = Height - 1; i >= 1; i--) { Eval(ind >> i); } return; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Propagate(int l, int r)
    {
        if (l == r) { Propagate(l); return; }
        int xor = l ^ r, i = Height - 1;
        for (; (xor >> i) == 0; i--) { Eval(l >> i); }
        for (; i >= 1; i--) { Eval(l >> i); Eval(r >> i); }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private DataT Reflect(int ind) { return Operate(Data[ind], Operators[ind]); }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Eval(int ind)
    {
        int l = ind << 1, r = ind << 1 | 1;
        Operators[l] = MergeOperator(Operators[l], Operators[ind]);
        Operators[r] = MergeOperator(Operators[r], Operators[ind]);
        Data[ind] = Reflect(ind);
        Operators[ind] = OperatorIdentity;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Calculate(int l, int r)
    {
        var xor = l ^ r;
        while (xor > 1) { xor >>= 1; l >>= 1; r >>= 1; Data[l] = MergeData(Reflect(l << 1), Reflect((l << 1) | 1)); Data[r] = MergeData(Reflect(r << 1), Reflect((r << 1) | 1)); }
        while (l > 1) { l >>= 1; Data[l] = MergeData(Reflect(l << 1), Reflect((l << 1) | 1)); }
    }
}