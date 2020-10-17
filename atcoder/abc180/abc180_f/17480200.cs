// detail: https://atcoder.jp/contests/abc180/submissions/17480200
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

//using M = ModInt;

public static class P
{
    public static void Main()
    {
        ModInt[] fac = new ModInt[10001];
        fac[0] = 1;
        for (int i = 1; i < fac.Length; i++) fac[i] = fac[i - 1] * i;
        ModInt[] invfac = fac.Select(x => 1 / x).ToArray();

        ModInt[] pow2 = new ModInt[10001];
        pow2[0] = 1;
        for (int i = 1; i < pow2.Length; i++) pow2[i] = pow2[i - 1] * 2;
        var invpow2 = pow2.Select(x => 1 / x).ToArray();

        var nml = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nml[0];
        var m = nml[1];
        var l = nml[2];
        //o=oが何個あるか→
        ModInt[][] dp = Enumerable.Range(0, n + 1).Select(_ => new ModInt[m + 1]).ToArray();
        ModInt[][] path = Enumerable.Range(0, n + 1).Select(_ => new ModInt[m + 1]).ToArray();
        ModInt[][] cycle = Enumerable.Range(0, n + 1).Select(_ => new ModInt[m + 1]).ToArray();

        ModInt[][] prevDP = null;

        dp[0][0] = 1;
        for (int group = 2; group <= l; group++)
        {
            prevDP = dp.Select(x => x.ToArray()).ToArray();
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    path[i][j] = 0;
                    cycle[i][j] = 0;
                }
            }
            for (int count = 1; count * group <= n; count++)
            {
                var inv = invpow2[count] * invfac[count];
                var useNode = count * group;
                var useEdge = count * (group - 1);
                for (int i = useNode; i <= n; i++)
                {
                    var remain = n - i + useNode;
                    var cnt = fac[remain] * invfac[n - i] * inv;
                    for (int j = useEdge; j <= m; j++)
                    {
                        path[i][j] += dp[i - useNode][j - useEdge] * cnt;
                    }
                }
            }
            for (int i = 0; i <= n; i++)
                for (int j = 0; j <= m; j++)
                    dp[i][j] += path[i][j];

            ModInt powden = 1;
            for (int count = 1; count * group <= n; count++)
            {
                if (group != 2) powden /= group;
                var inv = invpow2[count] * invfac[count];
                var useNode = count * group;
                var useEdge = count * group;
                for (int i = useNode; i <= n; i++)
                {
                    var remain = n - i + useNode;
                    var cnt = fac[remain] * invfac[n - i] * inv * powden;
                    for (int j = useEdge; j <= m; j++)
                    {
                        cycle[i][j] += dp[i - useNode][j - useEdge] * cnt;
                    }
                }
            }
            for (int i = 0; i <= n; i++)
                for (int j = 0; j <= m; j++)
                    dp[i][j] += cycle[i][j];
        }

        ModInt res = 0;
        for (int i = 0; i <= n; i++)
        {
            res += path[i][m] + cycle[i][m];
        }

        Console.WriteLine(res);
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
