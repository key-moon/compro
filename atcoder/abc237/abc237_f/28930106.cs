// detail: https://atcoder.jp/contests/abc237/submissions/28930106
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
        int M = m + 1;
        int ToIndex(int i, int j, int k) => (i * M + j) * M + k;
        // dp[(i, j, k)] := 長さ 1 の LIS の末尾の最小値, 長さ 2 の……, 長さ 3 の……
        ModInt[] dp = new ModInt[ToIndex(M, 0, 0)];
        dp[ToIndex(m, m, m)] = 1;
        for (int cnt = 0; cnt < n; cnt++)
        {
            ModInt[] newdp = new ModInt[ToIndex(M, 0, 0)];
            
            for (int i = 0; i < M; i++)
            {
                for (int j = i; j < M; j++)
                {
                    for (int k = j; k < M; k++)
                    {
                        for (int nxt = 0; nxt < m; nxt++)
                        {
                            if (k < nxt) continue;
                            var (ni, nj, nk) = (i, j, k);
                            if (j < nxt) nk = Min(nk, nxt);
                            if (i < nxt) nj = Min(nj, nxt);
                            ni = Min(ni, nxt);
                            newdp[ToIndex(ni, nj, nk)] += dp[ToIndex(i, j, k)];
                        }
                    }
                }
            }
            dp = newdp;
        }
        ModInt res = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                for (int k = 0; k < m; k++)
                {
                    res += dp[ToIndex(i, j, k)];
                }
            }
        }
        Console.WriteLine(res);
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
