// detail: https://yukicoder.me/submissions/570611
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
        var nlr = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = (int)nlr[0];
        var l = nlr[1];
        var r = nlr[2];
        //上位互換の文字列がある場合にkill
        List<long> fibs = new List<long>();

        long pp = 0;
        long p = 1;
        while (true)
        {
            var next = pp + p;
            pp = p;
            p = next;
            if (l <= next && next <= r) fibs.Add(next);
            if (r < next) break;
        }
        HashSet<string> fibSet = new HashSet<string>();
        List<string> subSs = new List<string>();
        Dictionary<string, int> dic = new Dictionary<string, int>();
        subSs.Add("");
        dic[""] = 0;
        foreach (var fib in fibs)
        {
            var s = fib.ToString();
            fibSet.Add(s);
            for (int i = 0; i < s.Length; i++)
            {
                var subs = s.Substring(0, i);
                if (fibSet.Any(x => subs.Contains(x))) break;
                if (fibSet.Contains(subs) || dic.ContainsKey(subs)) continue;
                subSs.Add(subs);
                dic[subs] = dic.Count;
            }
        }
     
        int[][] dests = Enumerable.Repeat(0, dic.Count + 1).Select(_ => new int[10]).ToArray();
        dests[dic.Count] = Enumerable.Repeat(dic.Count, 10).ToArray();
        for (int i = 0; i < subSs.Count; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                var nxt = subSs[i] + j.ToString();
                while (true)
                {
                    if (fibSet.Contains(nxt))
                    {
                        dests[i][j] = dic.Count;
                        break;
                    }
                    if (dic.ContainsKey(nxt))
                    {
                        dests[i][j] = dic[nxt];
                        break;
                    }                    
                    nxt = nxt.Substring(1);
                }
            }
        }

        ModInt[] cur = new ModInt[dests.Length];
        cur[dic[""]] = 1;
        for (int i = 0; i < n; i++)
        {
            ModInt[] nxt = new ModInt[dests.Length];
            for (int j = 0; j < dests.Length; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    nxt[dests[j][k]] += cur[j];
                }
            }
            cur = nxt;
        }
        var lim = (int)Pow(10, n);
        Console.WriteLine(cur.Take(cur.Length - 1).Aggregate(new ModInt(0), (x, y) => x + y) - 1/*stands 0*/);
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
