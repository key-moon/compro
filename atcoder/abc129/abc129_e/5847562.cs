// detail: https://atcoder.jp/contests/abc129/submissions/5847562
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        ModInt upPow = Power(2, s.Count(x => x == '1'));
        //その桁より上が全て埋まっていることにする
        //その桁は0
        //もしその桁が0の時はするー
        //そうでない時は下がガラ空きなので3^dig
        ModInt curPow = 1;
        ModInt res = upPow;
        foreach (var c in s.Reverse())
        {
            if (c == '1')
            {
                upPow /= 2;
                res += curPow * upPow;
            }
            curPow *= 3;
        }
        Console.WriteLine(res);
    }

    static ModInt Power(ModInt n, long m)
    {
        ModInt pow = n;
        ModInt res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res *= pow;
            pow *= pow;
            m >>= 1;
        }
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
    public static ModInt operator +(ModInt a, ModInt b)
    {
        long res = a.Data + b.Data;
        return new ModInt() { Data = res >= MOD ? res - MOD : res };
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, long b) => a.Data + b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, ModInt b)
    {
        long res = a.Data - b.Data;
        return new ModInt() { Data = res < 0 ? res + MOD : res };
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, long b) => a.Data - b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt() { Data = a.Data * b.Data % MOD };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator /(ModInt a, ModInt b) => a.Data * GetInverse(b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => Data.ToString();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long GetInverse(long a)
    {
        long div;
        long p = MOD;
        long x1 = 1, y1 = 0, x2 = 0, y2 = 1;
        while (true)
        {
            if (p == 1) return x2;
            div = a / p;
            x1 -= x2 * div;
            y1 -= y2 * div;
            a %= p;
            if (a == 1) return x1;
            div = p / a;
            x2 -= x1 * div;
            y2 -= y1 * div;
            p %= a;
        }
    }
}