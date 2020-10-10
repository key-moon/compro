// detail: https://atcoder.jp/contests/hhkb2020/submissions/17307159
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
        var s = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine()).ToArray();
        int[][] light = Enumerable.Repeat(0, h).Select(_ => new int[w]).ToArray();
        
        for (int i = 0; i < h; i++)
        {
            int cur = 0;
            for (int j = 0; j < w; j++)
            {
                if (s[i][j] != '#') cur++;
                else cur = 0;
                light[i][j] += cur;
            }
        }
        for (int i = h - 1; i >= 0; i--)
        {
            int cur = 0;
            for (int j = w - 1; j >= 0; j--)
            {
                if (s[i][j] != '#') cur++;
                else cur = 0;
                light[i][j] += cur;
            }
        }
        
        for (int j = w - 1; j >= 0; j--)
        {
            int cur = 0;
            for (int i = 0; i < h; i++)
            {
                if (s[i][j] != '#') cur++;
                else cur = 0;
                light[i][j] += cur;
            }
        }
        for (int j = w - 1; j >= 0; j--)
        {
            int cur = 0;
            for (int i = h - 1; i >= 0; i--)
            {
                if (s[i][j] != '#') cur++;
                else cur = 0;
                light[i][j] += cur;
            }
        }

        var k = s.Sum(x => x.Count(x => x != '#'));
        
        ModInt[] pow2 = new ModInt[2000 * 2000 + 10];
        pow2[0] = 1;
        for (int i = 1; i < pow2.Length; i++)
            pow2[i] = pow2[i - 1] * 2;

        ModInt res = 0;
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                if (s[i][j] == '#') continue;
                res += pow2[k] - pow2[k - (light[i][j] - 3)];
            }
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