// detail: https://atcoder.jp/contests/arc108/submissions/18274676
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
        int n = int.Parse(Console.ReadLine());
        //BAはAB→ABB→ABABみたいな時にでうる
        char aa = Console.ReadLine()[0];
        char ab = Console.ReadLine()[0];
        char ba = Console.ReadLine()[0];
        char bb = Console.ReadLine()[0];
        var notate = "" + aa + ab + ba + bb;

        static ModInt Stupid(int n, string notate)
        {
            HashSet<string> res = new HashSet<string>() { "AB" };
            for (int iter = 2; iter < n; iter++)
            {
                HashSet<string> newRes = new HashSet<string>();
                foreach (var item in res)
                {
                    for (int i = 1; i < item.Length; i++)
                    {
                        var idx = (item[i - 1] == 'B' ? 2 : 0) + (item[i] == 'B' ? 1 : 0);
                        var nxt = item.Substring(0, i) + notate[idx] + item.Substring(i);
                        newRes.Add(nxt);
                    }
                }
                res = newRes;
            }
            //Console.WriteLine(string.Join("\n", res));
            return res.Count;
        }

        var cand = new []{
            "AAAA",
            "AAAB",
            "AABA",
            "AABB",
            "ABAA",
            "ABAB",
            "ABBA",
            "ABBB",
            "BAAA",
            "BAAB",
            "BABA",
            "BABB",
            "BBAA",
            "BBAB",
            "BBBA",
            "BBBB"
        };

        //AA→BとかBB→Aとかは興味深い
        //extendableな方に生成がついたら、単発になる?
        //BBBA→
        //AAAA→1
        //BBBB→
        static ModInt Solve(int n, string notate)
        {
            if (n == 2) return 1;
            switch (notate)
            {
                case "AAAA":
                case "AAAB":
                case "AABA":
                case "AABB":
                case "ABAB":
                case "ABBB":
                case "BBAB":
                case "BBBB":
                    return 1;

                case "ABAA":
                case "BABA":
                case "BABB":
                case "BBAA":
                    return Power(2, n - 3);
                case "ABBA":
                case "BAAA":
                case "BAAB":
                case "BBBA":
                    ModInt[] fib = new ModInt[n];
                    fib[0] = 1;
                    fib[1] = 1;
                    for (int i = 2; i < n; i++) fib[i] = fib[i - 2] + fib[i - 1];
                    return fib[n - 2];
            }
            throw new Exception();
        }

        /*for (int i = 2; i < n; i++)
        {
            foreach (var item in cand)
            {
                var sol = Solve(i, item);
                var ans = Stupid(i, item);
                if (sol != ans)
                {
                    Solve(i, item);
                    throw new Exception();
                }
            }
            Console.WriteLine(i);
        }*/
        Console.WriteLine(Solve(n, notate));
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