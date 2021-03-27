// detail: https://atcoder.jp/contests/abc197/submissions/21299352
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
        var xy1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var xy2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var p1 = new Vector(xy1[0], xy1[1]);
        var p2 = new Vector(xy2[0], xy2[1]);
        var c = (p1 + p2) / 2;
        var v = (p1 - p2) / 2;
        var res = c + v.RotateVector(2 * PI / n);
        Console.WriteLine($"{res.x} {res.y}");
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
    public static Vector operator *(Vector a, double b) => new Vector(a.x * b, a.y * b);
    public static Vector operator /(Vector a, double b) => new Vector(a.x / b, a.y / b);
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