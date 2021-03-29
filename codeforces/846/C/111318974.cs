// detail: https://codeforces.com/contest/846/submission/111318974
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        DisjointSparseTable<long> dst = new DisjointSparseTable<long>(a, (x, y) => x + y);
        long totalMax = long.MinValue / 2;
        var totalMaxInd = (-1, -1, -1);
        for (int ind2 = 0; ind2 <= a.Length; ind2++)
        {
            var max1 = long.MinValue / 2;
            int maxInd1 = -1;
            for (int ind1 = 0; ind1 <= ind2; ind1++)
            {
                var cur = dst.Query(0, ind1 - 1) - dst.Query(ind1, ind2 - 1);
                if (max1 < cur)
                {
                    max1 = cur;
                    maxInd1 = ind1;
                }
            }

            var max2 = long.MinValue / 2;
            int maxInd3 = -1;
            for (int ind3 = ind2; ind3 <= a.Length; ind3++)
            {
                var cur = dst.Query(ind2, ind3 - 1) - dst.Query(ind3, n - 1);
                if (max2 < cur)
                {
                    max2 = cur;
                    maxInd3 = ind3;
                }
            }

            if (totalMax < max1 + max2)
            {
                totalMax = max1 + max2;
                totalMaxInd = (maxInd1, ind2, maxInd3);
            }
        }
        Console.WriteLine($"{totalMaxInd.Item1} {totalMaxInd.Item2} {totalMaxInd.Item3}");
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
        if (l > r) return default;
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
