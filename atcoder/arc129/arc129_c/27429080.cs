// detail: https://atcoder.jp/contests/arc129/submissions/27429080
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
        int[] dp = Enumerable.Repeat(int.MaxValue / 2, 1000001).ToArray();
        int[] used = new int[1000001];
        dp[0] = 0;
        used[0] = -1;
        for (int i = 1; i <= 1000; i++)
        {
            var val = i * (i + 1) / 2;
            for (int j = val; j < dp.Length; j++)
            {
                if (dp[j - val] + 1 < dp[j])
                {
                    dp[j] = dp[j - val] + 1;
                    used[j] = i;
                }
            }
        }
        { 
            StringBuilder res = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            int val = n;
            int cnt = 0;
            while (val != 0)
            {
                if (cnt == 1)
                {
                    char toAppend = '$';
                    var most = (int)Power(10, used[val]);
                    for (int i = 1; i <= 9; i++)
                    {
                        if ((most * i) % 7 == 1)
                        {
                            toAppend = i.ToString()[0];
                            break;
                        }
                    }
                    if (toAppend == '$') throw new Exception();
                    res.Append(toAppend);
                }
                if (cnt == 2)
                {
                    res.Append('1');
                }
                res.Append(new string('7', used[val]));
                val -= used[val] * (used[val] + 1) / 2;
                cnt++;
            }
            var s = res.ToString();
            if (4 <= cnt) throw new Exception();
            if (1000000 <= s.Length) throw new Exception();
            Console.WriteLine(s);
        }
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
    public const int Mod = 7;
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
