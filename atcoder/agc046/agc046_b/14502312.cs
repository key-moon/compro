// detail: https://atcoder.jp/contests/agc046/submissions/14502312
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
        var abcd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = abcd[0];
        var b = abcd[1];
        var c = abcd[2];
        var d = abcd[3];
        if (a == c && b == d)
        {
            Console.WriteLine(1);
            return;
        }
        //table[y][x][normal cantDuplicate(y+1→1,x+1→1)]
        ModInt[][][] table = Enumerable.Range(0, c + 1).Select(_ => Enumerable.Repeat(0, d + 1).Select(_ => new ModInt[3]).ToArray()).ToArray();
        table[a][b][0] = 1;
        {
            for (int j = b + 1; j <= d; j++)
            {
                table[a][j][0] = table[a][j - 1][0] * a;
            }
            for (int i = a + 1; i <= c; i++)
            {
                table[i][b][0] = table[i - 1][b][0] * b;
            }
        }
        var inv = 1 / new ModInt(2);
        for (int i = a + 1; i <= c; i++)
        {
            for (int j = b + 1; j <= d; j++)
            {
                //i→i+1、つまり長さj追加しても複製できないもの
                var sum1 = table[i - 1][j][0] + table[i - 1][j][2] + table[i - 1][j][1];
                var sum2 = table[i][j - 1][0] + table[i][j - 1][1] + table[i][j - 1][2];
                table[i][j][1] = sum1 + table[i - 1][j][1] * (j - 1);
                table[i][j][2] = sum2 + table[i][j - 1][2] * (i - 1);

                table[i][j][0] = 
                      sum1 * j
                    + sum2 * i
                    - table[i][j][1] - table[i][j][2];
                table[i][j][0] *= inv;
            }
        }
        Console.WriteLine(table[c][d].Aggregate((x, y) => x + y));
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
