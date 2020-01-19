// detail: https://codeforces.com/contest/1292/submission/69113817
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
using static Reader;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
public static class P
{
    public static void Main()
    {
        var x0 = NextLong;
        var y0 = NextLong;
        var ax = NextLong;
        var ay = NextLong;
        var bx = NextLong;
        var by = NextLong;
        var xs = NextLong;
        var ys = NextLong;
        var t = NextLong;
        var initPoint = new Vector(xs, ys);
        List<Vector> points = new List<Vector>();
        points.Add(new Vector(x0, y0));
        while (true)
        {
            var last = points.Last();
            var newPoint = new Vector(last.x * ax + bx, last.y * ay + by);
            if (initPoint.x < newPoint.x && initPoint.y < newPoint.y && t < (initPoint - newPoint).ManhattanLength)
                break;
            points.Add(newPoint);
        }
        int res = 0;
        for (int i = 0; i < points.Count; i++)
        {
            int count = 0;
            var cur = initPoint;
            var remainCost = t;
            for (int j = i; j < points.Count; j++)
            {
                remainCost -= (cur - points[j]).ManhattanLength;
                if (remainCost < 0) break;
                count++;
                cur = points[j];
            }
            res = Max(res, count);
        }
        for (int i = 0; i < points.Count; i++)
        {
            int count = 0;
            var cur = initPoint;
            var remainCost = t;
            for (int j = i; j >= 0; j--)
            {
                remainCost -= (cur - points[j]).ManhattanLength;
                if (remainCost < 0) break;
                count++;
                cur = points[j];
            }
            res = Max(res, count);
        }
        Console.WriteLine(res);
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
    public long ManhattanLength => Abs(x) + Abs(y);
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


static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = BUF_SIZE - 1;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }

    public static long NextLong
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            long res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (long)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}