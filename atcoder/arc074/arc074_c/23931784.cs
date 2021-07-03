// detail: https://atcoder.jp/contests/arc074/submissions/23931784
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
        var constraints = Enumerable.Repeat(0, m).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => (l: x[0], r: x[1], x: x[2])).ToArray();

        // dp[col][pos1][pos2] := col が一つ前の色で、それ以外の色の最終登場場所が pos1 と pos2(1-indexed)
        ModInt[][][] dp = Enumerable.Repeat(0, 3).Select(_ => Enumerable.Repeat(0, 1).Select(_ => new ModInt[1]).ToArray()).ToArray();
        dp[0][0][0] = 1;
        dp[1][0][0] = 1;
        dp[2][0][0] = 1;
        foreach (var (l, r, x) in constraints.Where(x => x.r == 1))
        {
            int kinds = 1;
            if (kinds != x)
            {
                dp[0][0][0] = 0;
                dp[1][0][0] = 0;
                dp[2][0][0] = 0;
            }
        }

        for (int i = 2; i <= n; i++)
        {
            var affectConstraints = constraints.Where(x => x.r == i).ToArray();
            ModInt[][][] newDp = Enumerable.Repeat(0, 3).Select(_ => Enumerable.Repeat(0, i).Select(_ => new ModInt[i]).ToArray()).ToArray();
            for (int useCol = 0; useCol < 3; useCol++)
            {
                var c1 = useCol == 0 ? 1 : 0;
                var c2 = useCol == 2 ? 1 : 2;
                var pos = new int[3];
                for (int prevCol = 0; prevCol < 3; prevCol++)
                {
                    pos[prevCol] = i - 1;
                    var prevC1 = prevCol == 0 ? 1 : 0;
                    var prevC2 = prevCol == 2 ? 1 : 2;
                    for (int prevPos1 = 0; prevPos1 < i - 1; prevPos1++)
                    {
                        pos[prevC1] = prevPos1;
                        for (int prevPos2 = 0; prevPos2 < i - 1; prevPos2++)
                        {
                            pos[prevC2] = prevPos2;
                            newDp[useCol][pos[c1]][pos[c2]] += dp[prevCol][prevPos1][prevPos2];
                        }
                    }
                }
                
                foreach (var (l, r, x) in affectConstraints)
                {
                    for (int pos1 = 0; pos1 < i; pos1++)
                    {
                        for (int pos2 = 0; pos2 < i; pos2++)
                        {
                            int kinds = 1;
                            if (l <= pos1) kinds++;
                            if (l <= pos2) kinds++;
                            if (kinds != x) newDp[useCol][pos1][pos2] = 0;
                        }
                    }
                }
            }
            dp = newDp;
        }
        Console.WriteLine(dp.SelectMany(x => x).SelectMany(x => x).Aggregate(new ModInt(0), (x, y) => x + y));
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
