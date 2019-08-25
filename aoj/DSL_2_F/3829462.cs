// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/DSL_2_F/judge/3829462/C#
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        int n = NextInt;
        var q = NextInt;
        SegmentTree<uint, uint> segTree = new SegmentTree<uint, uint>(n, int.MaxValue, uint.MaxValue, Min, (x, y) => y == uint.MaxValue ? x : y, (x, y) => y == uint.MaxValue ? x : y);
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < q; i++)
        {
            if (NextUInt == 0)
                segTree.Update(NextInt, NextInt, NextUInt);
            else
                builder.AppendLine(segTree.Query(NextInt, NextInt).ToString());
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

    static uint NextUInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            uint res = 0;
            int next = In.Read();
            while (45 > next || next > 57) next = In.Read();
            while (48 <= next && next <= 57)
            {
                res = res * 10 + (uint)(next - 48);
                next = In.Read();
            }
            return res;
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

    #region Construct
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
    #endregion

    public DataT this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { Propagate(index + LeafCount); return Reflect(index); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { Propagate(index += LeafCount); Data[index] = value; Operators[index] = OperatorIdentity; Calculate(index, index); }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Update(int l, int r, OperatorT x)
    {
        l += LeafCount;
        r += LeafCount;
        int origL = l, origR = r;
        Propagate(l, r);
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
    private void Propagate(int index)
    {
        for (int i = Height - 1; i >= 1; i--)
        {
            int ind = index >> i;
            int l = index >> (i - 1);
            int r = l ^ 1;
            Operators[l] = MergeOperator(Operators[l], Operators[ind]);
            Operators[r] = MergeOperator(Operators[r], Operators[ind]);
            Data[ind] = Reflect(ind);
            Operators[ind] = OperatorIdentity;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Propagate(int l, int r)
    {
        if (l == r) { Propagate(l); return; }
        int xor = l ^ r, i = Height - 1;
        for (; (xor >> i) == 0; i--) { Eval(l >> i); }
        for (; i >= 1; i--)
        {
            int rind = r >> i;
            int rl = r >> (i - 1);
            int rr = rl ^ 1;
            Operators[rl] = MergeOperator(Operators[rl], Operators[rind]);
            Operators[rr] = MergeOperator(Operators[rr], Operators[rind]);
            Data[rind] = Reflect(rind);
            Operators[rind] = OperatorIdentity;

            int lind = l >> i;
            int ll = l >> (i - 1);
            int lr = ll ^ 1;
            Operators[ll] = MergeOperator(Operators[ll], Operators[lind]);
            Operators[lr] = MergeOperator(Operators[lr], Operators[lind]);
            Data[lind] = Reflect(lind);
            Operators[lind] = OperatorIdentity;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private DataT Reflect(int ind) { return Operate(Data[ind], Operators[ind]); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Eval(int ind)
    {
        int l = ind << 1, r = l ^ 1;
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

