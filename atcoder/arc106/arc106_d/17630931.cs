// detail: https://atcoder.jp/contests/arc106/submissions/17630931
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
        ModInt[] factorial = new ModInt[1001];
        ModInt[] invfactorial = new ModInt[1001];
        factorial[0] = 1;
        invfactorial[0] = 1;
        for (int i = 1; i < factorial.Length; i++)
        {
            factorial[i] = factorial[i - 1] * i;
            invfactorial[i] = 1 / factorial[i];
        }

        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        ModInt[] powSum = new ModInt[k + 1];
        for (int i = 0; i < a.Length; i++)
        {
            ModInt powed = 1;
            powSum[0] += powed;
            for (int j = 1; j < powSum.Length; j++)
            {
                powed *= a[i];
                powSum[j] += powed;
            }
        }

        ModInt pow2 = 2;
        for (int i = 1; i <= k; i++)
        {
            ModInt sum = 0;
            for (int j = 0; j <= i; j++)
            {
                var iCj = factorial[i] * invfactorial[j] * invfactorial[i - j];
                sum += iCj * powSum[j] * powSum[i - j];
            }
            var res = (sum - powSum[i] * pow2) / 2;
            pow2 *= 2;
            Console.WriteLine(res);
        }
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
