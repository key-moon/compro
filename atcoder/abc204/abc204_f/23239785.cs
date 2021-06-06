// detail: https://atcoder.jp/contests/abc204/submissions/23239785
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
        var hw = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var h = (int)hw[0];
        var w = hw[1];
        Matrix mat = new Matrix(1 << h, 1 << h);
        for (int b = 0; b < (1 << h); b++)
        {
            for (int b2 = 0; b2 < (1 << (h - 1)); b2++)
            {
                var tmpB = b;
                for (int i = 0; i < h - 1; i++)
                {
                    if ((b2 >> i & 1) != 1) continue;
                    if ((tmpB >> i & 1) == 1) goto end;
                    if ((tmpB >> (i + 1) & 1) == 1) goto end;
                    tmpB |= 1 << i;
                    tmpB |= 1 << (i + 1);
                }
                for (int newB = 0; newB < (1 << h); newB++)
                {
                    if ((newB & tmpB) != 0) continue;
                    mat[newB, b] += 1;
                    // mat[b, newB] += 1;
                }
                end:;
            }
        }

        var iv = new Matrix(1 << h, 1);
        iv[0, 0] = 1;
        var resVec = Power(mat, w) * iv;
        Console.WriteLine(resVec[0, 0]);
    }

    static Matrix Power(Matrix n, long m)
    {
        Matrix pow = n;
        Matrix res = Matrix.DiagonalMatrix(n.Height, 1);
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
    ModInt[] data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Matrix(int height, int width)
    {
        data = new ModInt[height * width];
        Height = height;
        Width = width;
    }
    public ModInt this[int i, int j]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return data[i * Width + j]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { data[i * Width + j] = value; }
    }
    public static Matrix DiagonalMatrix(int n, ModInt val)
    {
        var res = new Matrix(n, n);
        for (int i = 0; i < n; i++) res[i, i] = val;
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix Add(Matrix a, Matrix b)
    {
        var res = new Matrix(a.Height, a.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < a.Width; j++) res[i, j] = a[i, j] + b[i, j];
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix Sub(Matrix a, Matrix b)
    {
        var res = new Matrix(a.Height, a.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < a.Width; j++) res[i, j] = a[i, j] - b[i, j];
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix Mul(Matrix a, Matrix b)
    {
        var res = new Matrix(a.Height, b.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < b.Width; j++) for (int k = 0; k < a.Width; k++) res[i, j] += a[i, k] * b[k, j];
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix operator +(Matrix a, Matrix b) => Add(a, b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix operator -(Matrix a, Matrix b) => Sub(a, b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix operator *(Matrix a, Matrix b) => Mul(a, b);
}


struct ModInt
{
    public const int Mod = 998244353;
    const long POSITIVIZER = ((long)Mod) << 31;
    long Data;
    public ModInt(long data) { if ((Data = data % Mod) < 0) Data += Mod; }
    public static implicit operator long(ModInt modInt) => modInt.Data;
    public static implicit operator ModInt(long val) => new ModInt(val);
    public static ModInt operator +(ModInt a, int b) => new ModInt() { Data = (a.Data + b + POSITIVIZER) % Mod };
    public static ModInt operator +(ModInt a, long b) => new ModInt(a.Data + b);
    public static ModInt operator +(ModInt a, ModInt b) { long res = a.Data + b.Data; return new ModInt() { Data = res >= Mod ? res - Mod : res }; }
    public static ModInt operator -(ModInt a, int b) => new ModInt() { Data = (a.Data - b + POSITIVIZER) % Mod };
    public static ModInt operator -(ModInt a, long b) => new ModInt(a.Data - b);
    public static ModInt operator -(ModInt a, ModInt b) { long res = a.Data - b.Data; return new ModInt() { Data = res < 0 ? res + Mod : res }; }
    public static ModInt operator *(ModInt a, int b) => new ModInt(a.Data * b);
    public static ModInt operator *(ModInt a, long b) => a * new ModInt(b);
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt() { Data = a.Data * b.Data % Mod };
    public static ModInt operator /(ModInt a, ModInt b) => new ModInt() { Data = a.Data * GetInverse(b) % Mod };
    public static bool operator ==(ModInt a, ModInt b) => a.Data == b.Data;
    public static bool operator !=(ModInt a, ModInt b) => a.Data != b.Data;
    public override string ToString() => Data.ToString();
    public override bool Equals(object obj) => (ModInt)obj == this;
    public override int GetHashCode() => (int)Data;
    static long GetInverse(long a)
    {
        long div, p = Mod, x1 = 1, y1 = 0, x2 = 0, y2 = 1;
        while (true)
        {
            if (p == 1) return x2 + Mod; div = a / p; x1 -= x2 * div; y1 -= y2 * div; a %= p;
            if (a == 1) return x1 + Mod; div = p / a; x2 -= x1 * div; y2 -= y1 * div; p %= a;
        }
    }
}
