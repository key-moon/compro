// detail: https://atcoder.jp/contests/abc215/submissions/25231848
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
        var pos = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).Select(x => (x: x[0], y: x[1])).OrderBy(x => x.x).ToArray();

        DisjointSparseTable<MinMax> dst = new DisjointSparseTable<MinMax>(
            pos.Select(x => new MinMax(x.y)).ToArray(),
            (x, y) => x | y
        );

        // Console.WriteLine(string.Join("\n", pos));
        // IsValid(805);

        bool IsValid(long dist)
        {
            int sectionBegin = 0;
            int sectionEnd = 0;
            while (sectionEnd < pos.Length)
            {
                while (dist <= pos[sectionEnd].x - pos[sectionBegin].x)
                {
                    var q1 = dst.Query(0, sectionBegin);
                    var q2 = dst.Query(sectionEnd, dst.Size - 1);
                    if (Max(q1.Max - q2.Min, q2.Max - q1.Min) >= dist) return true; 
                    sectionBegin++;
                }
                sectionEnd++;
            }
            return false;
        }

        long valid = 0, invalid = int.MaxValue;
        while (invalid - valid > 1)
        {
            var mid = (invalid + valid) / 2;
            if (IsValid(mid)) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(valid);
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
        if (l > r) throw new Exception();
        if (l == r) return Table[l];
        l = Max(l, 0);
        r = Min(r, Size - 1);
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

class MinMax
{
    public long Max { get; private set; }
    public long Min { get; private set; }
    public static MinMax None => new MinMax() { Max = long.MinValue, Min = long.MaxValue };
    private MinMax() { }
    public MinMax(long val) { Max = val; Min = val; }
    public static MinMax operator |(MinMax a, MinMax b)
    {
        return new MinMax() { Max = Max(a.Max, b.Max), Min = Min(a.Min, b.Min) };
    }
}
