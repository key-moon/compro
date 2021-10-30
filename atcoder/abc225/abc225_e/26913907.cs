// detail: https://atcoder.jp/contests/abc225/submissions/26913907
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
        var pts = Enumerable.Range(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => new Vector(x[0], x[1])).ToArray();
        Array.Sort(pts, new AngleComparer());
        var possible = pts.Concat(pts.Select(x => x - new Vector(1, 0))).Concat(pts.Select(x => x - new Vector(0, 1))).ToArray();
        Array.Sort(possible, new AngleComparer());
        var dic = possible.Select(x => x.Representative).Distinct().Select((elem, ind) => (elem, ind)).ToDictionary(x => x.elem, x => x.ind);
        var dp = new int[dic.Count + 1];
        int prev = 0;
        for (int i = 0; i < pts.Length; i++)
        {

            var point = pts[i];
            var begin = point - new Vector(0, 1);
            var beginId = dic[begin.Representative];
            var end = point - new Vector(1, 0);
            var endId = dic[end.Representative];

            while (prev < beginId)
            {
                dp[prev + 1] = Max(dp[prev + 1], dp[prev]);
                prev++;
            }
            dp[endId] = Max(dp[endId], dp[beginId] + 1);
        }

        // Console.WriteLine(string.Join("\n", dic.Select(x => Atan2(x.Key.y, x.Key.x))));
        Console.WriteLine(dp.Max());
    }
}

class AngleComparer : IComparer<Vector>
{
    public int Compare(Vector x, Vector y)
    {
        return -Sign(Vector.CrossProduct(x, y));
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
    public Vector Representative => x == 0 && y == 0 ? this : this / GCD(x, y);
    static long GCD(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            a %= b;
            if (a == 0) return b;
            b %= a;
        }
    }
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
    public static Vector operator *(Vector a, long op) => new Vector(a.x * op, a.y * op);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector operator /(Vector a, long op) => new Vector(a.x / op, a.y / op);
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
