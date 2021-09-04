// detail: https://atcoder.jp/contests/abc217/submissions/25586285
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
        var n = nm[0] * 2;
        var m = nm[1];

        var pairs = Enumerable.Repeat(0, m).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        bool[][] hasPair = Enumerable.Repeat(0, n).Select(_ => new bool[n]).ToArray();
        foreach (var pair in pairs)
        {
            hasPair[pair[0] - 1][pair[1] - 1] = true;
            hasPair[pair[1] - 1][pair[0] - 1] = true;
        }
        ModInt[][] merged = Enumerable.Repeat(0, n + 1).Select(_ => new ModInt[n + 1]).ToArray();
        ModInt[][] wrapped = Enumerable.Repeat(0, n + 1).Select(_ => new ModInt[n + 1]).ToArray();
        ModInt[][] pattern = Enumerable.Repeat(0, n + 1).Select(_ => new ModInt[n + 1]).ToArray();
        for (int i = 0; i < n + 1; i++)
        {
            wrapped[i][i] = 1;
            pattern[i][i] = 1;
        }
        for (int len = 0; len <= n; len += 2)
        {
            for (int i = 0; i <= n - len; i++)
            {
                int j = i + len;
                // merge
                for (int k = i + 2; k < j; k += 2)
                {
                    merged[i][j] += pattern[i][k] * wrapped[k][j] * Combination(len / 2, (k - i) / 2);
                }
                // extended
                if (2 <= len && hasPair[i][j - 1])
                {
                    wrapped[i][j] += pattern[i + 1][j - 1];
                }
                pattern[i][j] = merged[i][j] + wrapped[i][j];
            }
        }

        // Console.WriteLine(string.Join("\n", pattern.Select(x => string.Join(" ", x))));
        Console.WriteLine(pattern[0][n]);
    }

    const int MAX = 10000;
    static ModInt[] FactorialMemo = new ModInt[MAX + 1];
    static ModInt[] InvFactorialMemo = new ModInt[MAX + 1];
    static P()
    {
        FactorialMemo[0] = 1;
        for (int i = 1; i <= MAX; i++) FactorialMemo[i] = FactorialMemo[i - 1] * i;
        InvFactorialMemo[MAX] = 1 / FactorialMemo[MAX];
        for (int i = MAX - 1; i >= 0; i--) InvFactorialMemo[i] = InvFactorialMemo[i + 1] * (i + 1);
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
