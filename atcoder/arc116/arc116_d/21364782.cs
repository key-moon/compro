// detail: https://atcoder.jp/contests/arc116/submissions/21364782
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        ModInt[] dp = new ModInt[m + 1];
        dp[0] = 1;
        for (int i = 1; i <= m; i *= 2)
        {
            for (int j = m; j >= 0; j--)
            {
                for (int cnt = 2; j + (i * cnt) <= m; cnt += 2)
                {
                    if (n < cnt) break;
                    dp[j + i * cnt] += dp[j] * Combination(n, cnt);
                }
            }
        }
        Console.WriteLine(dp[m]);
    }

    const int MAX = 10000;
    static ModInt[] FactorialMemo = new ModInt[MAX + 1];
    static ModInt[] InvFactorialMemo = new ModInt[MAX + 1];
    static P()
    {
        FactorialMemo[0] = 1;
        for (int i = 1; i <= MAX; i++)
            FactorialMemo[i] = FactorialMemo[i - 1] * i;
        InvFactorialMemo[MAX] = 1 / FactorialMemo[MAX];
        for (int i = MAX - 1; i >= 0; i--)
            InvFactorialMemo[i] = InvFactorialMemo[i + 1] * (i + 1);
    }
    static ModInt Factorial(int x) => FactorialMemo[x];
    static ModInt InvFactorial(int x) => InvFactorialMemo[x];
    static ModInt Combination(int n, int m) => Factorial(n) * InvFactorial(m) * InvFactorial(n - m);
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
