// detail: https://atcoder.jp/contests/abc168/submissions/13348171
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        List<long> xAxis = new List<long>() { int.MinValue, 0, int.MaxValue };
        List<long> yAxis = new List<long>() { int.MinValue, 0, int.MaxValue };

        (long y1, long y2, long x)[] tate = new (long y1, long y2, long x)[n];
        for (int i = 0; i < n; i++)
        {
            var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            tate[i] = (abc[0], abc[1], abc[2]);
            yAxis.Add(tate[i].y1);
            yAxis.Add(tate[i].y2);
            xAxis.Add(tate[i].x);
        }

        (long y, long x1, long x2)[] yoko = new (long y, long x1, long x2)[m];
        for (int i = 0; i < m; i++)
        {
            var def = Console.ReadLine().Split().Select(int.Parse).ToArray();
            yoko[i] = (def[0], def[1], def[2]);
            yAxis.Add(yoko[i].y);
            xAxis.Add(yoko[i].x1);
            xAxis.Add(yoko[i].x2);
        }

        xAxis = xAxis.Distinct().OrderBy(x => x).ToList();
        yAxis = yAxis.Distinct().OrderBy(x => x).ToList();
        var xComp = xAxis.Distinct().OrderBy(x => x).Select((elem, ind) => (elem, ind)).ToDictionary(x => x.elem, x => x.ind);
        var yComp = yAxis.Distinct().OrderBy(x => x).Select((elem, ind) => (elem, ind)).ToDictionary(x => x.elem, x => x.ind);

        var yTotal = yAxis.Count - 1;
        var xTotal = xAxis.Count - 1;

        bool[] cantYoko = new bool[yTotal * xTotal];

        int Encode(int y, int x) => y * xTotal + x;

        foreach (var (y1, y2, x) in tate)
        {
            //var xInd = xAxis.BinarySearch(x);
            //var yStart = yAxis.BinarySearch(y1);
            //var yEnd = yAxis.BinarySearch(y2);
            var xInd = xComp[x];
            var yStart = yComp[y1];
            var yEnd = yComp[y2];
            for (int y = yStart; y < yEnd; y++)
            {
                var a = Encode(y, xInd - 1);
                cantYoko[a] = true;
            }
        }

        bool[] cantTate = new bool[yTotal * xTotal];

        foreach (var (y, x1, x2) in yoko)
        {
            //var yInd = yAxis.BinarySearch(y);
            //var xStart = xAxis.BinarySearch(x1);
            //var xEnd = xAxis.BinarySearch(x2);
            var yInd = yComp[y];
            var xStart = xComp[x1];
            var xEnd = xComp[x2];
            for (int x = xStart; x < xEnd; x++)
            {
                var a = Encode(yInd - 1, x);
                cantTate[a] = true;
            }
        }

        UnionFind uf = new UnionFind(yTotal * xTotal);
        for (int i = 0; i < yTotal - 1; i++)
            for (int j = 0; j < xTotal; j++)
            {
                var id = i * xTotal + j;
                if (cantTate[id]) continue;
                uf.TryUnite(id, id + xTotal);
                //Console.WriteLine($"{id} {id + xTotal}");
            }
        for (int i = 0; i < yTotal; i++)
            for (int j = 0; j < xTotal - 1; j++)
            {
                var id = i * xTotal + j;
                if (cantYoko[id]) continue;
                uf.TryUnite(id, id + 1);
                //Console.WriteLine($"{id} {id + 1}");
            }


        //var ushiID = uf.Find(Encode(yAxis.BinarySearch(0), xAxis.BinarySearch(0)));
        var ushiID = uf.Find(Encode(yComp[0], xComp[0]));
        if (ushiID == uf.Find(0))
        {
            Console.WriteLine("INF");
            return;
        }
        long res = 0;
        for (int i = 0; i < uf.Size; i++)
        {
            if (ushiID != uf.Find(i)) continue;
            var yInd = i / xTotal;
            var xInd = i % xTotal;
            res += (xAxis[xInd + 1] - xAxis[xInd]) * (yAxis[yInd + 1] - yAxis[yInd]);
        }
        Console.WriteLine(res);
    }
}


class UnionFind
{
    public int Size { get; private set; }
    public int GroupCount { get; private set; }
    public IEnumerable<int> AllRepresents => Parent.Where((x, y) => x == y);
    int[] Sizes;
    int[] Parent;
    public UnionFind(int count)
    {
        Size = count;
        GroupCount = count;
        Parent = new int[count];
        Sizes = new int[count];
        for (int i = 0; i < count; i++) Sizes[Parent[i] = i] = 1;
    }
    public bool TryUnite(int x, int y)
    {
        int xp = Find(x);
        int yp = Find(y);
        if (yp == xp) return false;
        if (Sizes[xp] < Sizes[yp]) { var tmp = xp; xp = yp; yp = tmp; }
        GroupCount--;
        Parent[yp] = xp;
        Sizes[xp] += Sizes[yp];
        return true;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetSize(int x) => Sizes[Find(x)];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Find(int x)
    {
        while (x != Parent[x]) x = (Parent[x] = Parent[Parent[x]]);
        return x;
    }
}


struct Vector
{
    public long x;
    public long y;
    public long this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { if (index == 0) return x; else return y; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { if (index == 0) x = value; else y = value; }
    }
    public long Length => x * x + y * y;
    public double SqrtLength => Math.Sqrt(Length);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector(long x, long y) { this.x = x; this.y = y; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector RotateVector(double radian) => new Vector((long)(x * Math.Cos(radian) - y * Math.Sin(radian)), (long)(x * Math.Sin(radian) + y * Math.Cos(radian)));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static public long CrossProduct(Vector a, Vector b) => a.x * b.y - a.y * b.x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static public long InnerProduct(Vector a, Vector b) => a.x * b.x + a.y * b.y;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector operator +(Vector a, Vector b) => new Vector(a.x + b.x, a.y + b.y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector operator -(Vector a, Vector b) => new Vector(a.x - b.x, a.y - b.y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Vector a, Vector b) => a.x == b.x && a.y == b.y;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Vector a, Vector b) => a.x != b.x || a.y != b.y;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object obj) => this == (Vector)obj;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => x.GetHashCode() * 1000000007 + y.GetHashCode();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => $"({x},{y})";
}
