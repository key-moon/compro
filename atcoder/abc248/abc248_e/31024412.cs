// detail: https://atcoder.jp/contests/abc248/submissions/31024412
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var K = nk[1];
        Vector[] vs = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => new Vector(x[0], x[1])).ToArray();
        if (K == 1)
        {
            Console.WriteLine("Infinity");
            return;
        }
        Dictionary<(Vector, Vector), int> v = new Dictionary<(Vector, Vector), int>();
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                var d = NormalizeVec(vs[i] - vs[j]);
                var vec = (NormalizePoint(vs[i], d), d);
                if (!v.ContainsKey(vec)) v.Add(vec, 0);
                v[vec]++;
            }
        }
        int res = 0;
        foreach (var (key, val) in v)
        {
            if (K * (K - 1) / 2 <= val) res++;
        }
        Console.WriteLine(res);
    }
    static Vector NormalizeVec(Vector axis)
    {
        if (axis.x < 0 || (axis.x == 0 && axis.y < 0)) axis *= -1;
        var gcd = GCD(Abs(axis.x), Abs(axis.y));
        axis /= gcd;
        return axis;
    }
    static Vector NormalizePoint(Vector point, Vector axis)
    {
        var original = point;
        if (axis.x == 0)
        {
            Trace.Assert(axis.y == 1);
            point.y = 0;
            return point;
        }
        if (axis.x != 0)
        {
            point.x %= axis.x;
            if (point.x < 0) point.x += axis.x;
        }
        point.y += ((point.x - original.x) / axis.x) * axis.y;
        return point;
    }

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
