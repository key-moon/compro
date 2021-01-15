// detail: https://yukicoder.me/submissions/604500
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
        var nmt = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = (int)nmt[0];
        var m = (int)nmt[1];
        var t = nmt[2];
        Matrix mat = new Matrix(n, n);
        for (int i = 0; i < m; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = ab[0];
            var b = ab[1];
            mat[b, a] = true;
        }
        Matrix iv = new Matrix(n, 1);
        iv[0, 0] = true;
        var res = Power(mat, t) * iv;
        Console.WriteLine(Enumerable.Range(0, n).Count(x => res[x, 0]));
    }

    static Matrix Power(Matrix n, long m)
    {
        Matrix pow = n;
        Matrix res = Matrix.Delta(n.Height, true);
        while (m > 0)
        {
            if ((m & 1) == 1) res *= pow;
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
    bool[] data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Matrix(int height, int width)
    {
        data = new bool[height * width];
        Height = height;
        Width = width;
    }
    public bool this[int i, int j]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return data[i * Width + j]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { data[i * Width + j] = value; }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix Delta(int n, bool val)
    {
        var res = new Matrix(n, n);
        for (int i = 0; i < n; i++) res[i, i] = val;
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix Add(Matrix a, Matrix b)
    {
        var res = new Matrix(a.Height, a.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < a.Width; j++) res[i, j] = a[i, j] | b[i, j];
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix Mul(Matrix a, Matrix b)
    {
        var res = new Matrix(a.Height, b.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < b.Width; j++) for (int k = 0; k < a.Width; k++) res[i, j] |= a[i, k] & b[k, j];
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix operator +(Matrix a, Matrix b) => Add(a, b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix operator *(Matrix a, Matrix b) => Mul(a, b);
}
