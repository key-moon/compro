// detail: https://codeforces.com/contest/1320/submission/111538665
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
        Random rng = new Random();
        var nmp = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmp[0];
        var m = nmp[1];
        var p = nmp[2];

        Weapon[] weapons = Enumerable.Range(0, n).Select(_ =>
        {
            var ac = Console.ReadLine().Split().Select(int.Parse).ToArray();
            return new Weapon() { Attack = ac[0], Price = ac[1] };
        }).OrderBy(_ => rng.Next()).OrderBy(x => x.Attack).ToArray();

        Armor[] armors = Enumerable.Range(0, m).Select(_ =>
        {
            var dc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            return new Armor() { Defence = dc[0], Price = dc[1] };
        }).OrderBy(_ => rng.Next()).OrderBy(x => x.Defence).ToArray();
        //後ろからとっていって価格が単調減少になるように貪欲にやればいいが、いい

        Monster[] monsters = Enumerable.Range(0, p).Select(_ =>
        {
            var adc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            return new Monster() { Attack = adc[1], Defence = adc[0], Benefit = adc[2] };
        }).OrderBy(_ => rng.Next()).OrderBy(x => x.Attack).ToArray();

        SegmentTree<long, long> segmentTree = new SegmentTree<long, long>
        (
            weapons.Select(x => -x.Price).ToArray(),
            long.MinValue / 2,
            0,
            Max,
            (x, y) => x + y,
            (x, y) => x + y
        );

        long res = long.MinValue;
        var lastMonsterInd = 0;
        foreach (var armor in armors)
        {
            while (lastMonsterInd < monsters.Length && monsters[lastMonsterInd].Attack < armor.Defence)
            {
                var monster = monsters[lastMonsterInd];
                int valid = weapons.Length;
                int invalid = -1;
                while (valid - invalid > 1)
                {
                    var mid = (valid + invalid) / 2;
                    if (monster.Defence < weapons[mid].Attack) valid = mid;
                    else invalid = mid;
                }

                segmentTree.Update(valid, segmentTree.Size - 1, monster.Benefit);
                lastMonsterInd++;
            }
            res = Max(res, segmentTree.Query(0, segmentTree.Size - 1) - armor.Price);
        }
        Console.WriteLine(res);
    }
}

struct Weapon
{
    public int Attack;
    public long Price;
}

struct Armor
{
    public int Defence;
    public long Price;
}

struct Monster
{
    public int Attack;
    public int Defence;
    public long Benefit;
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
        get { Propagate(index + LeafCount); return Reflect(index); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { Propagate(index += LeafCount); Data[index] = value; Operators[index] = OperatorIdentity; Calculate(index, index); }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Update(int l, int r, OperatorT x)
    {
        l += LeafCount;
        r += LeafCount;
        if (l > r) return;
        int origL = l, origR = r;
        //Propagate(l, r);
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
        if (l > r) return DataIdentity;
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