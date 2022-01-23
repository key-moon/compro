// detail: https://atcoder.jp/contests/abc236/submissions/28754764
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
        var ntl = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = ntl[0];
        var t = ntl[1];
        var l = ntl[2];
        Matrix m = new Matrix(n, n);
        for (int i = 1; i <= t; i++)
        {
            var uv = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var u = uv[0] - 1;
            var v = uv[1] - 1;
            m[u, v] = i;
        }
        var res = Power(m, l);
        Console.WriteLine(string.Join(" ", Enumerable.Range(0, n).Select(x => res[0, x] != int.MaxValue ? res[0, x] : -1)));
    }
    static Matrix Power(Matrix n, long m)
    {
        Matrix pow = n;
        Matrix res = null;
        while (m > 0)
        {
            if ((m & 1) == 1)
            {
                if (res is null) res = pow;
                else res *= pow;
            }
            pow *= pow;
            m >>= 1;
        }
        return res;
    }
}


class Matrix
{
    public readonly int Height;
    public readonly int Width;
    int[] data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Matrix(int height, int width)
    {
        data = new int[height * width];
        Array.Fill(data, int.MaxValue);
        Height = height;
        Width = width;
    }
    public Matrix(Matrix m)
    {
        data = m.data.ToArray();
        Height = m.Height;
        Width = m.Width;
    }
    public int this[int i, int j]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return data[i * Width + j]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { data[i * Width + j] = value; }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix Add(Matrix a, Matrix b)
    {
        var res = new Matrix(a.Height, a.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < a.Width; j++) res[i, j] = Min(res[i, j], b[i, j]);
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix Mul(Matrix a, Matrix b)
    {
        var res = new Matrix(a.Height, b.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < b.Width; j++) for (int k = 0; k < a.Width; k++)
                {
                    res[i, j] = Min(res[i, j], Max(a[i, k], b[k, j]));
                }
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix operator +(Matrix a, Matrix b) => Add(a, b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix operator *(Matrix a, Matrix b) => Mul(a, b);
}
