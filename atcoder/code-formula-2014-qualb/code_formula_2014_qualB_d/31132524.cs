// detail: https://atcoder.jp/contests/code-formula-2014-qualb/submissions/31132524
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
        const int MOD = 1000000007;
        int n = int.Parse(Console.ReadLine());
        var a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine()))
            .Concat(new[] { 0, 0, 0, 0, 0, 0 })
            .ToArray();
        ModInt[] carried = new ModInt[6000];
        carried[0] = 1;
        for (int i = 0; i < a.Length; i++)
        {
            ModInt[] nxt = new ModInt[6000];
            for (int j = 0; j < carried.Length; j++)
            {
                var cur = a[i] + j;
                for (int k = Max(0, cur / 10 - 3); k < nxt.Length; k++)
                {
                    var remain = cur - 10 * k;
                    if (remain < 0) break;
                    if (remain <= 9)
                    {
                        nxt[k] += carried[j] * (remain + 1);
                        continue;
                    }
                    if (remain <= 18)
                    {
                        nxt[k] += carried[j] * (19 - remain);
                        continue;
                    }

                }
            }
            carried = nxt;
        }
        Console.WriteLine(carried.Aggregate((x, y) => x + y) - 1);
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
