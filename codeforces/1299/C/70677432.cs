// detail: https://codeforces.com/contest/1299/submission/70677432
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

        double[] minAverage = new double[n];
        int[] usedUntil = new int[n];

        for (int i = a.Length - 1; i >= 0; i--)
        {
            minAverage[i] = a[i];
            usedUntil[i] = i;
            while (usedUntil[i] < a.Length - 1 && minAverage[i] > minAverage[usedUntil[i] + 1])
            {
                minAverage[i] = (minAverage[i] * (usedUntil[i] - i + 1) +
                    minAverage[usedUntil[i] + 1] * (usedUntil[usedUntil[i] + 1] - usedUntil[i])) / (usedUntil[usedUntil[i] + 1] - i + 1);
                usedUntil[i] = usedUntil[usedUntil[i] + 1];
            }
        }
        double[] res = new double[n];
        int usedInd = -1;
        for (int i = 0; i < n; i++)
        {
            if (i <= usedInd)
            {
                res[i] = res[i - 1];
                continue;
            }
            res[i] = minAverage[i];
            usedInd = usedUntil[i];
        }

        Console.WriteLine(string.Join("\n", res));
    }
}

struct Tuple
{
    public double Item;
    public int Ind;
    public static Tuple Merge(Tuple a, Tuple b) => a.Item <= b.Item ? a : b;
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
