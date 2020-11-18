// detail: https://codeforces.com/contest/660/submission/98804631
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
        var n = nm[0]; //num
        var m = nm[1]; //kind

        //Console.WriteLine(Stupid(1, 1));
        //Console.WriteLine(Stupid(2, 2));
        //Console.WriteLine(Stupid(3, 3));
        //Console.WriteLine(Stupid(4, 6));
        //Console.WriteLine(Stupid(5, 5));
        //Console.WriteLine(Stupid(6, 3));
        
        //1/mの確率で次の状態に進めるオートマトンが、nターンでi回以上先の状態まで進む通り数

        ModInt comb = Power(m, n);
        ModInt res = comb;
        for (int len = 1; len <= n; len++)
        {
            //len回進めなかった場合
            //つまり、len-1回あたりが出て、n-len+1回はずれ
            comb -= Power(m - 1, n - len + 1) * Factorial(n) / Factorial(len - 1) / Factorial(n - len + 1);
            res += comb * Power(m, len);
        }
        Console.WriteLine(res);
    }


    static List<ModInt> factorialMemo = new List<ModInt>() { 1 };
    static ModInt Factorial(int x)
    {
        for (int i = factorialMemo.Count; i <= x; i++) factorialMemo.Add(factorialMemo.Last() * i);
        return factorialMemo[x];
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

    static ModInt Stupid(int n, int m)
    {
        List<string> seq = new List<string>() { "" };
        for (int i = 0; i < n; i++)
        {
            var newseq = new List<string>();
            foreach (var item in seq)
            {
                for (int j = 1; j <= m; j++)
                {
                    newseq.Add(item + (char)('0' + j));
                }
            }
            seq = newseq;
        }
        int res = 0;
        Dictionary<string, int> freqs = new Dictionary<string, int>();
        foreach (var item in seq)
        {
            HashSet<string> set = new HashSet<string>() { "" };
            for (int i = 0; i < (1 << item.Length); i++)
            {
                string s = "";
                for (int j = 0; j < item.Length; j++)
                {
                    if ((i >> j & 1) == 1) s += item[j];
                }
                set.Add(s);
            }
            //for (int i = 0; i < item.Length; i++)
            //    for (int j = i + 1; j <= item.Length; j++)
            //        set.Add(item[i..j]);
            foreach (var s in set)
            {
                if (!freqs.ContainsKey(s)) freqs[s] = 0;
                freqs[s]++;
            }
            res += set.Count;
        }
        foreach (var group in freqs.GroupBy(x => x.Value).OrderBy(x => x.Key))
        {
            Console.WriteLine($"{group.Key} {group.Count()} {string.Join(" ", group.Take(30).Select(x => x.Key))}");
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
