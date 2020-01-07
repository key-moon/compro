// detail: https://codeforces.com/contest/1/submission/68347529
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
        double EPS = 1e-5;
        var a = Console.ReadLine().Split().Select(double.Parse).ToArray();
        var v1 = new Vector(a[0], a[1]);
        a = Console.ReadLine().Split().Select(double.Parse).ToArray();
        var v2 = new Vector(a[0], a[1]) - v1;
        a = Console.ReadLine().Split().Select(double.Parse).ToArray();
        var v3 = new Vector(a[0], a[1]) - v1;
        v1 -= v1;
        
        double res = int.MaxValue;
        for (int cornor = 3; cornor <= 120; cornor++)
        {
            var area = cornor / 4.0 / Tan(PI / cornor);
            var angle = PI - 2 * PI / cornor;
            Vector[] vertexes = new Vector[cornor];
            for (int i = 0; i < vertexes.Length - 1; i++)
                vertexes[i + 1] = vertexes[i] + new Vector(1, 0).RotateVector((PI - angle) * i);

            for (int i = 1; i < vertexes.Length; i++)
            {
                var ang = vertexes[i].Angle - v2.Angle;
                var len = vertexes[i].SqrtLength / v2.SqrtLength;
                var another = v3.RotateVector(ang) * len;
                for (int j = 1; j < vertexes.Length; j++)
                {
                    if (Abs(another.x - vertexes[j].x) < EPS &&
                        Abs(another.y - vertexes[j].y) < EPS)
                    {
                        res = Min(res, area / (len * len));
                    }
                }
            }
        }
        if (res == int.MaxValue) throw new Exception();
        Console.WriteLine(res.ToString("0.0000000"));
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
    public double Angle => Atan2(y, x);
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
