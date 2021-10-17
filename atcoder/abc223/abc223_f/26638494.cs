// detail: https://atcoder.jp/contests/abc223/submissions/26638494
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
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nq[0];
        var q = nq[1];
        char[] s = Console.ReadLine().ToArray();
        int[] arr = new int[n + 1];
        for (int i = 0; i < s.Length; i++)
            arr[i + 1] = arr[i] + (s[i] == '(' ? 1 : -1);
        SegmentTree<int, int> segtree = new SegmentTree<int, int>(
            arr,
            int.MaxValue,
            0,
            Min,
            (x, y) => x + y,
            (x, y) => x + y
        );
        for (int i = 0; i < q; i++)
        {
            var tlr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var t = tlr[0];
            var l = tlr[1] - 1;
            var r = tlr[2] - 1;
            if (t == 1)
            {
                if (s[l] == s[r]) continue;
                if (s[l] == ')') (l, r) = (r, l);

                Trace.Assert(s[l] == '(');
                Trace.Assert(s[r] == ')');

                segtree.Update(l + 1, n, -2);
                segtree.Update(r + 1, n, 2);

                (s[l], s[r]) = (s[r], s[l]);
            }
            if (t == 2)
            {
                var begin = segtree[l];
                var end = segtree[r + 1];
                bool res = begin == end && segtree.Query(l, r + 1) == end;

                Console.WriteLine(res ? "Yes" : "No");
            }
        }
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
