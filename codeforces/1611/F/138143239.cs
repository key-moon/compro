// detail: https://codeforces.com/contest/1611/submission/138143239
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        var ns = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = ns[0];
        var s = ns[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var accum = new long[n + 1];
        for (int i = 0; i < a.Length; i++)
        {
            accum[i + 1] = accum[i] + a[i];
        }
        DisjointSparseTable<long> dst = new DisjointSparseTable<long>(accum, Min);
        int mxLen = 0;
        int l = -1;
        int r = -1;
        for (int i = 0; i < n; i++)
        {
            int valid = i, invalid = n + 1;
            while (invalid - valid > 1)
            {
                var mid = (valid + invalid) / 2;
                if (accum[i] - s <= dst.Query(i, mid)) valid = mid;
                else invalid = mid;
            }
            var len = valid - i;
            if (mxLen < len)
            {
                mxLen = len;
                (l, r) = (i, valid);
            }
        }
        if (mxLen == 0)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine($"{l + 1} {r}");
        }
    }
}


class DisjointSparseTable<T>
{
    public readonly int Size;
    readonly int Height;
    readonly T[] Table;
    readonly Func<T, T, T> Merge;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DisjointSparseTable(T[] data, Func<T, T, T> merge)
    {
        Size = data.Length;
        Height = MSBPos(Size) + 1;
        Table = new T[Size * Height];
        Merge = merge;
        data.CopyTo(Table, 0);
        for (int layer = 1; layer < Height; layer++)
        {
            int layerOffset = layer * Size;
            int block = 0;
            int i;
            for (; block + 2 <= Size >> layer; block += 2)
            {
                i = layerOffset + ((block | 1) << layer) - 1; Table[i] = Table[i - layerOffset]; i--;
                for (; i >= layerOffset + (block << layer); i--) Table[i] = Merge(Table[i - layerOffset], Table[i + 1]);
                i = layerOffset + ((block | 1) << layer); Table[i] = Table[i - layerOffset]; i++;
                for (; i < layerOffset + ((block + 2) << layer); i++) Table[i] = Merge(Table[i - 1], Table[i - layerOffset]);
            }
            if (((block | 1) << layer) < Size)
            {
                i = layerOffset + ((block | 1) << layer) - 1; Table[i] = Table[i - layerOffset]; i--;
                for (; i >= layerOffset + (block << layer); i--) Table[i] = Merge(Table[i - layerOffset], Table[i + 1]);
                i = layerOffset + ((block | 1) << layer); Table[i] = Table[i - layerOffset]; i++;
                for (; i < layerOffset + Size; i++) Table[i] = Merge(Table[i - 1], Table[i - layerOffset]);
            }
        }
    }

    public T Query(int l, int r)
    {
        if (l == r) return Table[l];
        var layer = MSBPos(l ^ r);
        return Merge(Table[l + layer * Size], Table[r + layer * Size]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int MSBPos(int n)
    {
        int res = 0;
        if (0 != (n >> (res | 16))) res |= 16;
        if (0 != (n >> (res | 8))) res |= 8;
        if (0 != (n >> (res | 4))) res |= 4;
        if (0 != (n >> (res | 2))) res |= 2;
        if (0 != (n >> (res | 1))) res |= 1;
        return res;
    }
}
