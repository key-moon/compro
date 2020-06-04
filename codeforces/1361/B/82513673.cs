// detail: https://codeforces.com/contest/1361/submission/82513673
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
#if !DEBUG
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
#endif
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
        Console.Out.Flush();
    }

    //static int[] set1 = new int[1000101];
    static int[] set2 = new int[1000101];
    static void Solve()
    {
        var np = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var p = np[1];
        var k = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if (p == 1)
        {
            Console.WriteLine(k.Length % 2);
            return;
        }
        //大きいのをできる限り貪欲に殺す? そうっぽい
        bool s1IsEmpty = true;
        Random rng = new Random();
        int s1ind = -1;
        HashSet<int> inds = new HashSet<int>();
        foreach (var item in k.OrderBy(_ => rng.Next()).OrderByDescending(x => x))
        {
            if (s1IsEmpty)
            {
                s1ind = item;
                s1IsEmpty = false;
                continue;
            }
            set2[item]++;
            inds.Add(item);
            var ind = item;
            while (set2[ind] == p)
            {
                set2[ind] = 0;
                inds.Remove(ind);
                ind++;
                set2[ind]++;
                inds.Add(ind);
            }
            if (s1ind == ind)
            {
                s1ind = -1;
                set2[ind]--;
                inds.Remove(ind);
                s1IsEmpty = true;
            }
        }

        ModInt s1 = 0;
        if (s1ind != -1)
        {
            s1 = Power(p, s1ind);
        }
        ModInt s2 = 0;
        foreach (var item in inds)
        {
            s2 += Power(p, item) * set2[item];
            set2[item] = 0;
        }

        Console.WriteLine(s1 - s2);
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
