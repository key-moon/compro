// detail: https://codeforces.com/contest/1299/submission/70655638
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

        Action abort = () => { Console.WriteLine("No"); Environment.Exit(0); };
        int n = int.Parse(Console.ReadLine());
        Vector[] points = Enumerable.Repeat(0, n).Select(_ =>
        {
            var xy = Console.ReadLine().Split().Select(long.Parse).ToArray();
            return new Vector(xy[0] * 2, xy[1] * 2);
        }).ToArray();
        if (n % 2 != 0)
        {
            abort();
        }
        var half = n / 2;
        var cross = Line.Cross(new Line(points[0], points[half]), new Line(points[1], points[half + 1]));
        if (cross == null) abort();
        for (int i = 1; i < half; i++)
        {
            var currentCross = Line.Cross(new Line(points[0], points[half]), new Line(points[i], points[half + i]));
            if (currentCross != cross) abort();
        }
        Console.WriteLine("YES");
    }
}

struct Line
{
    public Vector a;
    public Vector b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Line(Vector a, Vector b) { this.a = a; this.b = b; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector? Cross(Line a, Line b, bool allowOutOfRegion = true)
    {
        long delta = (a.b.x - a.a.x) * (b.b.y - b.a.y) - (a.b.y - a.a.y) * (b.b.x - b.a.x);
        long lambda = (b.b.y - b.a.y) * (b.b.x - a.a.x) - (b.b.x - b.a.x) * (b.b.y - a.a.y);
        if (delta != lambda * 2) return null;
        return new Vector(a.a.x + (a.b.x - a.a.x) / 2, a.a.y + (a.b.y - a.a.y) / 2);
    }
    public override string ToString() => $"{a} {b}";
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

/*
struct Line
{
    public Vector a;
    public Vector b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Line(Vector a, Vector b) { this.a = a; this.b = b; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector? Cross(Line a, Line b, bool allowOutOfRegion = true)
    {
        double delta = (a.b.x - a.a.x) * (b.b.y - b.a.y) - (a.b.y - a.a.y) * (b.b.x - b.a.x);
        if (delta == 0) return null;
        double ramda = ((b.b.y - b.a.y) * (b.b.x - a.a.x) - (b.b.x - b.a.x) * (b.b.y - a.a.y)) / delta;
        if (!allowOutOfRegion)
        {
            double mu = ((a.b.x - a.a.x) * (b.b.y - a.a.y) - (a.b.y - a.a.y) * (b.b.x - a.a.x)) / delta;
            if (mu < 0 || 1 < mu || ramda < 0 || 1 < ramda) return null;
        }
        return new Vector(a.a.x + ramda * (a.b.x - a.a.x), a.a.y + ramda * (a.b.y - a.a.y));
    }
    public override string ToString() => $"{a} {b}";
}
*/
