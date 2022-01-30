// detail: https://atcoder.jp/contests/abc237/submissions/28946905
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
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
        Random rng = new Random(1337);

        var nqx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nqx[0];
        var q = nqx[1];
        var X = nqx[2];
#if DEBUG
        var p = Enumerable.Range(1, n).OrderBy(x => rng.Next()).ToArray();
#else
        var p = Console.ReadLine().Split().Select(int.Parse).ToArray();
#endif
        
        var lowerNode = new Node() { LowerCnt = 1, UpperCnt = 0, Size = 1, XInd = -1 };
        var upperNode = new Node() { LowerCnt = 0, UpperCnt = 1, Size = 1, XInd = -1 };
        var xNode = new Node() { LowerCnt = 0, UpperCnt = 0, Size = 1, XInd = 0 };
        var idNode = new Node() { LowerCnt = 0, UpperCnt = 0, Size = 0, XInd = -1 };
        
        var arr = p.Select(x => x < X ? lowerNode : X < x ? upperNode : xNode).ToArray();
        SegmentTree<Node, AssignedType> segTree = new SegmentTree<Node, AssignedType>(
            arr,
            idNode,
            AssignedType.None,
            Node.Merge,
            (a, b) => b == AssignedType.None ? a : b,
            (node, op) =>
            {
                if (op == AssignedType.None) return node;
                node.UpperCnt = 0;
                node.LowerCnt = 0;
                node.XInd = -1;
                switch (op)
                {
                    case AssignedType.Lower:
                        node.LowerCnt = node.Size;
                        break;
                    case AssignedType.Upper:
                        node.UpperCnt = node.Size;
                        break;
                    default:
                        break;
                }
                return node;
            }
        );
        for (int i = 0; i < q; i++)
        {
#if DEBUG
            var c = rng.Next() % 2 + 1;
            var l = rng.Next() % n;
            var r = rng.Next() % n;
            if (l > r) (l, r) = (r, l);
#else
            var clr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var c = clr[0];
            var l = clr[1] - 1;
            var r = clr[2] - 1;
#endif
            var section = segTree.Query(l, r);
            Trace.Assert(section.UpperCnt + section.LowerCnt + (section.XInd != -1 ? 1 : 0) == section.Size);
            if (c == 1)
            {
                segTree.Update(l, l + section.LowerCnt - 1, AssignedType.Lower);
                segTree.Update(r - section.UpperCnt + 1, r, AssignedType.Upper);
                if (section.XInd != -1) segTree[l + section.LowerCnt] = xNode;
            }
            if (c == 2)
            {
                segTree.Update(l, l + section.UpperCnt - 1, AssignedType.Upper);
                segTree.Update(r - section.LowerCnt + 1, r, AssignedType.Lower);
                if (section.XInd != -1) segTree[l + section.UpperCnt] = xNode;
            }
        }
        Console.WriteLine(segTree.Query(0, segTree.Size - 1).XInd + 1);
    }
}

enum AssignedType
{
    None, Lower, Upper
}

struct Node
{
    public int LowerCnt;
    public int UpperCnt;
    public int XInd;
    public int Size;
    public static Node Merge(Node l, Node r)
    {
        Trace.Assert(l.XInd == -1 || r.XInd == -1);
        var val = new Node()
        {
            LowerCnt = l.LowerCnt + r.LowerCnt,
            UpperCnt = l.UpperCnt + r.UpperCnt,
            XInd = l.XInd != -1 ? l.XInd : r.XInd != -1 ? l.Size + r.XInd : -1,
            Size = l.Size + r.Size
        };
        return val;
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
        for (int i = LeafCount - 1; i >= 1; i--) Data[i] = MergeData(Data[i << 1], Data[(i << 1) + 1]);
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
        if (l > r) return;
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
        if (l > r) return DataIdentity;
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



[StructLayout(LayoutKind.Explicit)]
class Random
{
    [FieldOffset(0)]
    private byte __byte;
    [FieldOffset(0)]
    private sbyte __sbyte;
    [FieldOffset(0)]
    private char __char;
    [FieldOffset(0)]
    private short __short;
    [FieldOffset(0)]
    private ushort __ushort;
    [FieldOffset(0)]
    private int __int;
    [FieldOffset(0)]
    private uint __uint;
    [FieldOffset(0)]
    private long __long;
    [FieldOffset(0)]
    private ulong __ulong;

    public byte Byte { get { Update(); return __byte; } }
    public sbyte SByte { get { Update(); return __sbyte; } }
    public char Char { get { Update(); return __char; } }
    public short Short { get { Update(); return __short; } }
    public ushort UShort { get { Update(); return __ushort; } }
    public int Int { get { Update(); return __int; } }
    public uint UInt { get { Update(); return __uint; } }
    public long Long { get { Update(); return __long; } }
    public ulong ULong { get { Update(); return __ulong; } }
    public double Double { get { return (double)ULong / ulong.MaxValue; } }

    [FieldOffset(0)]
    private ulong _xorshift;

    public Random() : this((ulong)DateTime.Now.Ticks) { }
    public Random(ulong seed) { SetSeed(seed); }
    public void SetSeed(ulong seed) => _xorshift = seed * 0x3141592c0ffeeul;

    public int Next() => Int & 2147483647;
    public void Update()
    {
        _xorshift ^= _xorshift << 7;
        _xorshift ^= _xorshift >> 9;
    }
}
