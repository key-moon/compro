// detail: https://yukicoder.me/submissions/358807
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var np = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Solve(np[0], np[1]));
    }

    static ModInt Solve(int n, int p)
    {
        if (n == 1) return 0;

        ModInt res = 0;
        var fibs = new ModInt[n * 2];
        fibs[0] = 0;
        fibs[1] = 1;
        for (int i = 2; i < fibs.Length; i++)
            fibs[i] = fibs[i - 1] * p + fibs[i - 2];
        var lastFib = fibs[n - 1];
        //端材を足す
        for (int i = 0; i < n; i++)
        {
            var mod = (i + n) % 4;
            if (mod == 1 || mod == 2)
            {
                res += lastFib * fibs[i];
            }
        }

        for (int i = 1; i < n * 2; i++)
        {
            var mod = i % 4;
            if (mod == 1 || mod == 2)
                res += (Min(i, (n - 1) * 2 - i) + 1) / 2 * fibs[i];
        }

        return res;
    }

    static ModInt Stupid(int n, int p)
    {
        if (n == 1) return 0;

        var fibs = new ModInt[n];
        fibs[0] = 0;
        fibs[1] = 1;
        for (int i = 2; i < n; i++)
            fibs[i] = fibs[i - 1] * p + fibs[i - 2];

        ModInt res = 0;
        for (int i = 0; i < n; i++)
            for (int j = i; j < n; j++)
                res += fibs[i] * fibs[j];

        return res;
    }
}


struct ModInt
{
    const int MOD = 1000000007;
    long Data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ModInt(long data) { if ((Data = data % MOD) < 0) Data += MOD; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator long(ModInt modInt) => modInt.Data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ModInt(long val) => new ModInt(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, ModInt b) { long res = a.Data + b.Data; return new ModInt() { Data = res >= MOD ? res - MOD : res }; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, long b) => a.Data + b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, ModInt b) { long res = a.Data - b.Data; return new ModInt() { Data = res < 0 ? res + MOD : res }; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, long b) => a.Data - b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator *(ModInt a, int b) => new ModInt() { Data = a.Data * b % MOD };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator *(ModInt a, long b) => a * new ModInt(b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt() { Data = a.Data * b.Data % MOD };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator /(ModInt a, ModInt b) => new ModInt() { Data = a.Data * GetInverse(b) % MOD };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => Data.ToString();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long GetInverse(long a)
    {
        long div, p = MOD, x1 = 1, y1 = 0, x2 = 0, y2 = 1;
        while (true)
        {
            if (p == 1) return x2 + MOD;
            div = a / p; x1 -= x2 * div; y1 -= y2 * div; a %= p;
            if (a == 1) return x1 + MOD;
            div = p / a; x2 -= x1 * div; y2 -= y1 * div; p %= a;
        }
    }
}
