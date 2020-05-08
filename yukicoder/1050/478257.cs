// detail: https://yukicoder.me/submissions/478257
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
        var pk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var p = pk[0];
        var k = pk[1];

        Matrix matrix = new Matrix(p, p);
        for (int i = 0; i < p; i++)
        {
            for (int j = 0; j < p; j++)
            {
                matrix[i, (i + j) % p]++;
                matrix[i, (i * j) % p]++;
            }
        }

        Matrix iv = new Matrix(p, 1);
        iv[0, 0] = 1;
        var res = Power(matrix, k) * iv;
        Console.WriteLine(res[0, 0]);
    }


    static Matrix Power(Matrix n, long m)
    {
        Matrix pow = n;
        Matrix res = new Matrix(n.Height, n.Width);
        for (int i = 0; i < n.Height; i++)
            res[i, i] = 1;
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
    public const int Mod = 1000000007;
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