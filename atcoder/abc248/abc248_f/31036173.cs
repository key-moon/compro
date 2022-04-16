// detail: https://atcoder.jp/contests/abc248/submissions/31036173
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
        var np = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = np[0];
        var p = np[1];
        
        ModInt.Mod = p;
        ModInt.POSITIVIZER = ((long)ModInt.Mod) << 31;

        ModInt[] res = new ModInt[n];

        ModInt[] reachable = new ModInt[n];
        ModInt[] unreachable = new ModInt[n];
        unreachable[0] = 1;
        for (int i = 0; i < n; i++)
        {
            {
                ModInt[] newRes = new ModInt[n];
                ModInt[] newUnreachable = new ModInt[n];
                ModInt[] newReachable = new ModInt[n];

                for (int j = 0; j < n - 1; j++)
                {
                    newRes[j + 1] += res[j];
                    newUnreachable[j + 1] += unreachable[j];
                    newReachable[j + 1] += reachable[j];
                }
                for (int j = 0; j < n; j++)
                {
                    newRes[j] += res[j];
                    newReachable[j] += reachable[j] + unreachable[j];
                }
                res = newRes;
                reachable = newReachable;
                unreachable = newUnreachable;
            }

            if (i == n - 1) break;

            {
                ModInt[] newRes = new ModInt[n];
                ModInt[] newUnreachable = new ModInt[n];
                ModInt[] newReachable = new ModInt[n];

                for (int j = 0; j < n - 2; j++)
                {
                    newRes[j + 2] += res[j];
                    newRes[j + 2] += unreachable[j];
                    newRes[j + 2] += reachable[j];
                }
                
                for (int j = 0; j < n - 1; j++)
                {
                    newRes[j + 1] += res[j] * 2;
                    newRes[j + 1] += unreachable[j] * 2;
                    newUnreachable[j + 1] += reachable[j] * 2;
                }

                for (int j = 0; j < n; j++)
                {
                    newRes[j] += res[j];
                    newUnreachable[j] += unreachable[j];
                    newReachable[j] += reachable[j];
                }

                res = newRes;
                unreachable = newUnreachable;
                reachable = newReachable;
            }
        }
        var total = 3 * n - 2;
        ModInt cur = 1;
        for (int i = 1; i < n; i++)
        {
            cur *= total - i + 1;
            cur /= i;
            Console.WriteLine(cur - (res[i] + unreachable[i]));
        }
    }
}


struct ModInt
{
    public static int Mod = 1000000007;
    public static long POSITIVIZER = ((long)Mod) << 31;
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
