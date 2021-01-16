// detail: https://atcoder.jp/contests/keyence2021/submissions/19467021
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

public static class P
{
    public static void Main()
    {
        var hwk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwk[0];
        var w = hwk[1];
        var k = hwk[2];
        char[][] map = Enumerable.Repeat(0, h).Select(_ => new char[w]).ToArray();
        for (int i = 0; i < k; i++)
        {
            var input = Console.ReadLine().Split();
            map[int.Parse(input[0]) - 1][int.Parse(input[1]) - 1] = input[2][0];
        }

        ModInt[][] dp = Enumerable.Repeat(0, h).Select(_ => new ModInt[w]).ToArray();
        dp[h - 1][w - 1] = Power(3, h * w - k);
        var tmp = (ModInt)2 / 3;
        for (int i = h - 1; i >= 0; i--)
        {
            for (int j = w - 1; j >= 0; j--)
            {
                ModInt dMul = 0, rMul = 0;
                if (map[i][j] == '\0') (dMul, rMul) = (tmp, tmp);
                if (map[i][j] == 'X') (dMul, rMul) = (1, 1);
                if (map[i][j] == 'D') dMul = 1;
                if (map[i][j] == 'R') rMul = 1;
                if (i != h - 1) dp[i][j] += dp[i + 1][j] * dMul;
                if (j != w - 1) dp[i][j] += dp[i][j + 1] * rMul;
            }
        }
        Console.WriteLine(dp[0][0]);
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
