// detail: https://atcoder.jp/contests/abc173/submissions/14992485
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var pos = a.Where(x => 0 < x).OrderByDescending(x => x).ToArray();
        var neg = a.Where(x => 0 > x).OrderBy(x => x).ToArray();

        bool canZero = a.Contains(0);
        if (pos.Length + neg.Length < k)
        {
            Console.WriteLine(0);
            return;
        }
        //マイナス確定もある
        if (pos.Length == 0 && k % 2 == 1)
        {
            if (canZero)
            {
                Console.WriteLine(0);
                return;
            }
            ModInt res = 1;
            foreach (var item in neg.OrderByDescending(x => x).Take(k))
            {
                res *= item;
            }
            Console.WriteLine(res);
            return;
        }
        if (k == n)
        {
            if (neg.Length % 2 == 1 && canZero)
            {
                Console.WriteLine(0);
                return;
            }
            ModInt res = 1;
            for (int i = 0; i < a.Length; i++)
                res *= a[i];
            Console.WriteLine(res);
            return;
        }
        int posI = k - 1, negI = 0;
        ModInt cur = 1;
        while (pos.Length <= posI)
        {
            cur *= neg[negI];
            cur *= neg[negI + 1];
            posI -= 2;
            negI += 2;
        }
        for (int i = 0; i <= posI; i++)
            cur *= pos[i];
        for (; (posI - 1) >= 0 && (negI + 1) < neg.Length; posI -= 2, negI += 2)
        {
            var po = pos[posI] * pos[posI - 1];
            var ne = neg[negI] * neg[negI + 1];
            if (po >= ne) break;
            cur /= po;
            cur *= ne;
        }
        Console.WriteLine(cur);
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
