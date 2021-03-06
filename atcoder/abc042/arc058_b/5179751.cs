// detail: https://atcoder.jp/contests/abc042/submissions/5179751
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var hwab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int h = hwab[0];
        int w = hwab[1];
        int a = hwab[2];
        int b = hwab[3];
        ModInt res = 0;
        for (int i = 0; i < h - a; i++) res += (Factorial(i + b - 1) / (Factorial(i) * Factorial(b - 1))) * (Factorial((w - b - 1) + (h - i - 1)) / (Factorial(w - b - 1) * Factorial(h - i - 1)));
        Console.WriteLine(res);
    }
    static List<ModInt> factorialMemo = new List<ModInt>() { 1 };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static ModInt Factorial(int x)
    {
        for (int i = factorialMemo.Count; i <= x; i++) factorialMemo.Add(factorialMemo.Last() * i);
        return factorialMemo[x];
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
    public static ModInt operator +(ModInt a, long b) => new ModInt(a.Data + b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, ModInt b)
    {
        long res = a.Data - b.Data;
        return new ModInt() { Data = res < 0 ? res + MOD : res };
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, long b) => new ModInt(a.Data - b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator /(ModInt a, ModInt b) => a * GetInverse(b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => Data.ToString();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long GetInverse(long a)
    {
        //ax≡1(mod p)なるxがaの逆元
        //これは、a*x-p*y=1(x,yは整数)を満たすxであれば良く、
        //a,pが互いに素なる時は拡張ユークリッドの互除法で解ける。

        //A,B,x1,y1,x2,y2の間に、常に以下の関係性が成立するとする。
        //  A = a * x1 + p * y1
        //  B = a * x2 + p * y2

        //mod := A % B, div := floor(A / B) とする時、
        //  A = B * div + mod
        //⇔mod = A - B * div
        //⇔mod = a * x1 + p * y1 - (a * x2 + p * y2) * div
        //⇔mod = a * (x1 - x2 * div) + p * (y1 - y2 * div)

        //ここで、(A, x1, y1) = (mod, x1 - x2 * div, y1 - y2 * div) と置き換えることができる。
        

        long div, mod;
        long p = MOD;

        long x1 = 1, y1 = 0, x2 = 0, y2 = 1;
        while (true)
        {
            if (p == 1) return x2;
            div = a / p;
            mod = a % p;
            x1 = x1 - x2 * div;
            y1 = y1 - y2 * div;
            a = mod;
            if (a == 1) return x1;
            div = p / a;
            mod = p % a;
            x2 = x2 - x1 * div;
            y2 = y2 - y1 * div;
            p = mod;
        }
    }
}
