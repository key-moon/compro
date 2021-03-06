// detail: https://atcoder.jp/contests/abc194/submissions/20724980
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
        var input = Console.ReadLine().Split();
        var n = input[0];
        var k = int.Parse(input[1]);

        bool[] used = new bool[16];
        int ConvertFromHex(char n) => char.IsDigit(n) ? n - '0' : n - 'A' + 10;
        ModInt res = 0;
        for (int i = 0; i < n.Length; i++)
        {
            int cnt = used.Count(x => x);
            var digit = ConvertFromHex(n[i]);
            var remainDigit = n.Length - i - 1;
            if (i != 0) res += Solve(16, k, 1, remainDigit) * 15; //trilling zero
            for (int dig = i == 0 ? 1 : 0; dig < digit; dig++)
            {
                var curcnt = !used[dig] ? cnt + 1 : cnt;
                if (k < curcnt) continue;
                res += Solve(16, k, curcnt, remainDigit);
            }
            used[digit] |= true;
        }
        if (used.Count(x => x) == k) res++;
        Console.WriteLine(res);
    }
    static ModInt Naive(string n, int k)
    {
        var deci = Convert.ToInt32(n, 16);
        int res = 0;
        for (int i = 1; i <= deci; i++)
        {
            if (Convert.ToString(i, 16).Distinct().Count() == k) res++;
        }
        return res;
    }
    static ModInt Solve(int n, int toUse, int used, int remainDigit)
    {
        if (toUse < used) return 0;
        var spare = toUse - used;
        if (remainDigit < spare) return 0;
        ModInt perms = 0;
        for (int i = 0; i <= spare; i++)
        {
            var val = Combination(spare, i) * Power(toUse - i, remainDigit);
            if (i % 2 == 0) perms += val;
            else perms -= val;
        }
        return Combination(n - used, spare) * perms;
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

    static ModInt Combination(int n, int m) => Factorial(n) * InvFactorial(n - m) * InvFactorial(m);
    static List<ModInt> factorialMemo = new List<ModInt>() { 1 };
    static ModInt Factorial(int x)
    {
        for (int i = factorialMemo.Count; i <= x; i++) factorialMemo.Add(factorialMemo.Last() * i);
        return factorialMemo[x];
    }
    static List<ModInt> invFactorialMemo = new List<ModInt>() { 1 };
    static ModInt InvFactorial(int x)
    {
        for (int i = invFactorialMemo.Count; i <= x; i++) invFactorialMemo.Add(1 / Factorial(i));
        return invFactorialMemo[x];
    }
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
