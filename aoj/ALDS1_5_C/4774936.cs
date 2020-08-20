// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_5_C/judge/4774936/C#
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
        Tuple<Vector, Vector>[] curve = new[] { new Tuple<Vector, Vector>(new Vector(0, 0), new Vector(100, 0)) };
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++) curve = curve.SelectMany(KochCurve).ToArray();
        Console.WriteLine(string.Join("\n", curve.Select(x => x.Item1).Concat(new[] { curve.Last().Item2 })));
    }

    static IEnumerable<Tuple<Vector, Vector>> KochCurve(Tuple<Vector, Vector> edge)
    {
        var d = edge.Item2 - edge.Item1;
        d.x /= 3; d.y /= 3;
        var p1 = edge.Item1;
        var p2 = p1 + d;
        var p3 = p2 + d.RotateVector(PI / 3);
        var p4 = p2 + d;
        var p5 = edge.Item2;
        yield return new Tuple<Vector, Vector>(p1, p2);
        yield return new Tuple<Vector, Vector>(p2, p3);
        yield return new Tuple<Vector, Vector>(p3, p4);
        yield return new Tuple<Vector, Vector>(p4, p5);
    }

}

struct Vector
{
    public double x;
    public double y;
    public double this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { if (index == 0) return x; else return y; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { if (index == 0) x = value; else y = value; }
    }
    public double Length => x * x + y * y;
    public double SqrtLength => Math.Sqrt(Length);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector(double x, double y) { this.x = x; this.y = y; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector RotateVector(double radian) => new Vector((double)(x * Math.Cos(radian) - y * Math.Sin(radian)), (double)(x * Math.Sin(radian) + y * Math.Cos(radian)));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static public double CrossProduct(Vector a, Vector b) => a.x * b.y - a.y * b.x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static public double InnerProduct(Vector a, Vector b) => a.x * b.x + a.y * b.y;
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
    public override string ToString() => $"{x} {y}";
}

