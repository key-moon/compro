// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/DSL_2_D/judge/3959199/C#
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
using static Reader;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    const int inf = int.MaxValue;
    static void Main()
    {
        SegmentTree<int> segTree = new SegmentTree<int>(NextInt, inf, (x, y) => y == inf ? x : y);
        int q = NextInt;
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < q; i++)
        {
            if (NextInt == 0)
                segTree.Operate(NextInt, NextInt, NextInt);
            else
                builder.AppendLine(segTree[NextInt].ToString());
        }
        Console.Write(builder.ToString());
    }
}

static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = 0;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }
    public static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
    public static uint NextUInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            uint res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (uint)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}


class SegmentTree<T>
{
    public readonly int Size;
    T Identity;
    Func<T, T, T> Merge;
    int LeafCount;
    int Height;
    T[] Operators;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        Height = 1;
        LeafCount = 1;
        while (LeafCount < size) { Height++; LeafCount <<= 1; }
        Operators = new T[LeafCount << 1];
        for (int i = 0; i < Operators.Length; i++) Operators[i] = identity;
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Query(index); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { Propagate(index += LeafCount); Operators[index] = value; }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int l, int r, T x)
    {
        l += LeafCount;
        r += LeafCount;
        Propagate(l, r);
        while (l <= r)
        {
            if ((l & 1) == 1) Operators[l] = Merge(Operators[l], x);
            if ((r & 1) == 0) Operators[r] = Merge(Operators[r], x);
            l = (l + 1) >> 1;
            r = (r - 1) >> 1;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int index)
    {
        index += LeafCount;
        Propagate(index);
        return Operators[index];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Propagate(int sectionIndex)
    {
        for (int i = Height - 1; i >= 1; i--)
        {
            var section = sectionIndex >> i;
            var leftChild = sectionIndex >> (i - 1);
            var rightChild = leftChild ^ 1;
            Operators[leftChild] = Merge(Operators[leftChild], Operators[section]);
            Operators[rightChild] = Merge(Operators[rightChild], Operators[section]);
            Operators[section] = Identity;
        }
    }

    private void Propagate(int l, int r)
    {
        if (l == r) { Propagate(l); return; }
        int xor = l ^ r, i = Height - 1;
        for (; (xor >> i) == 0; i--)
        {
            var section = l >> i;
            var leftChild = l >> (i - 1);
            var rightChild = leftChild ^ 1;
            Operators[leftChild] = Merge(Operators[leftChild], Operators[section]);
            Operators[rightChild] = Merge(Operators[rightChild], Operators[section]);
            Operators[section] = Identity;
        }
        for (; i >= 1; i--) 
        {
            var section = l >> i;
            var leftChild = l >> (i - 1);
            var rightChild = leftChild ^ 1;
            Operators[leftChild] = Merge(Operators[leftChild], Operators[section]);
            Operators[rightChild] = Merge(Operators[rightChild], Operators[section]);
            Operators[section] = Identity;

            section = r >> i;
            leftChild = r >> (i - 1);
            rightChild = leftChild ^ 1;
            Operators[leftChild] = Merge(Operators[leftChild], Operators[section]);
            Operators[rightChild] = Merge(Operators[rightChild], Operators[section]);
            Operators[section] = Identity;
        }
    }
}

