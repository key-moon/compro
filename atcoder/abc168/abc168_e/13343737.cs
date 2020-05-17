// detail: https://atcoder.jp/contests/abc168/submissions/13343737
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
        int n = int.Parse(Console.ReadLine());
        Dictionary<(long, long), (int, int)> counts = new Dictionary<(long, long), (int, int)>();
        int zero = 0;
        for (int i = 0; i < n; i++)
        {
            var ab = Console.ReadLine().Split().Select(long.Parse).ToArray();
            if (ab[0] == 0 && ab[1] == 0)
            {
                zero++;
                continue;
            }
            var sign = Sign(ab[0]) * Sign(ab[1]);
            ab[0] = Abs(ab[0]);
            ab[1] = Abs(ab[1]);
            var gcd = GCD(ab[0], ab[1]);
            var a = ab[0] / gcd;
            var b = ab[1] / gcd;
            if (sign != 0) b *= sign;
            if (counts.ContainsKey((a, b)))
            {
                var tuple = counts[(a, b)];
                tuple.Item1++;
                counts[(a, b)] = tuple;
                continue;
            }
            var opposit = (Abs(b), (sign == 0 ? 1 : sign * -1) * Abs(a));
            if (counts.ContainsKey(opposit))
            {
                var tuple = counts[opposit];
                tuple.Item2++;
                counts[opposit] = tuple;
                continue;
            }
            counts.Add((a, b), (1, 0));
        }
        ModInt res = 1;
        foreach (var ((_, _), (a, b)) in counts)
        {
            res *= Power(2, a) + Power(2, b) - 1;
        }
        //if (zero != 0) throw new Exception();
        Console.WriteLine(res - 1 + zero);
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


    static long GCD(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            a %= b;
            if (a == 0) return b;
            b %= a;
        }
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
