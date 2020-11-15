// detail: https://atcoder.jp/contests/abc183/submissions/18130589
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
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        var s = Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine()).ToArray();
        var res = Enumerable.Range(0, h).Select(_ => new ModInt[w]).ToArray();
        var OFFSET = 5000;
        var curDCnt = new ModInt[10001];
        var curYCnt = new ModInt[h];
        var curXCnt = new ModInt[w];
        curDCnt[OFFSET] = 1;
        curYCnt[0] = 1;
        curXCnt[0] = 1;
        for (int i = 0; i < h; i++)
        {
            for (int j = i == 0 ? 1 : 0; j < w; j++)
            {
                if (s[i][j] == '#')
                {
                    curDCnt[i - j + OFFSET] = 0;
                    curYCnt[i] = 0;
                    curXCnt[j] = 0;
                }
                else
                {
                    res[i][j] = curDCnt[i - j + OFFSET] + curYCnt[i] + curXCnt[j];

                    curDCnt[i - j + OFFSET] += res[i][j];
                    curYCnt[i] += res[i][j];
                    curXCnt[j] += res[i][j];
                }
            }
        }
        Console.WriteLine(res[h - 1][w - 1]);
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
