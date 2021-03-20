// detail: https://atcoder.jp/contests/joi2011yo/submissions/21053898
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
        var s = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).ToArray();

        var mask = (1 << m) - 1;
        // dps[前がJか][JOの位置]
        ModInt[][] dps = new[]
        {
            new ModInt[1 << m],
            new ModInt[1 << m]
        };
        dps[0][0] = 1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ModInt[][] newdps = new[]
                {
                    new ModInt[1 << m],
                    new ModInt[1 << m]
                };
                if (s[i][j] == 'J' || s[i][j] == '?')
                {
                    var flg = j == m - 1 ? 0 : 1;
                    for (int k = 0; k < (1 << m); k++)
                    {
                        newdps[flg][k << 1 & mask] += dps[0][k];
                        newdps[flg][k << 1 & mask] += dps[1][k];
                    }
                }
                if (s[i][j] == 'O' || s[i][j] == '?')
                {
                    for (int k = 0; k < (1 << m); k++)
                    {
                        newdps[0][(k << 1 & mask) | 0] += dps[0][k];
                        newdps[0][(k << 1 & mask) | 2] += dps[1][k];
                    }
                }
                if (s[i][j] == 'I' || s[i][j] == '?')
                {
                    for (int k = 0; k < (1 << m); k++)
                    {
                        if ((k >> (m - 1) & 1) == 1) continue;
                        newdps[0][k << 1 & mask] += dps[0][k];
                        newdps[0][k << 1 & mask] += dps[1][k];
                    }
                }
                dps = newdps;
            }
        }

        var all = s.Sum(x => x.Count(x => x == '?'));
        Console.WriteLine(Power(3, all) - dps.SelectMany(x => x).Aggregate(new ModInt(0), (x, y) => x + y));
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
    public const int Mod = 100000;
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
