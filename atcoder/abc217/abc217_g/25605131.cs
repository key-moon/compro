// detail: https://atcoder.jp/contests/abc217/submissions/25605131
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
        // for (int i = 2; ; i++)
        // {
        //     for (int j = 2; j <= i; j++)
        //     {
        //         var res = Solve(i, j);
        //         var ans = Naive(i, j);
        //         if (!res.SequenceEqual(ans))
        //         {
        //             Console.WriteLine($"res: {string.Join(" ", res)}");
        //             Console.WriteLine($"ans: {string.Join(" ", ans)}");
        //             Console.WriteLine("NEQ!");
        //         }
        //     }
        // }
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];

        // Console.WriteLine(string.Join(" ", Naive(n, m).Skip(1)));
        Console.WriteLine(string.Join("\n", Solve(n, m).Skip(1)));
    }

    static ModInt[] Solve(int n, int m)
    {
        var smallGroupSize = n / m;
        var smallGroupCnt = m - n % m;
        var largeGroupSize = n / m + 1;
        var largeGroupCnt = n % m;
        Trace.Assert(smallGroupCnt != 0);
        Trace.Assert(smallGroupSize * smallGroupCnt + largeGroupSize * largeGroupCnt == n);
        ModInt[] res = new ModInt[n + 1];
        for (int k = 1; k <= n; k++)
        {
            if (k < smallGroupSize) continue;
            if (largeGroupCnt != 0 && k < largeGroupSize) continue;
            // k 個の区別できる箱を size 個選んで並べる方法→ k!/(k-size)! 通り
            // i 個へのグループ分けが何個含まれているか→ res_i * k!/(k-i)!
            ModInt curRes = 1;
            curRes *= Power(Permutation(k, smallGroupSize), smallGroupCnt);
            if (largeGroupSize <= k) curRes *= Power(Permutation(k, largeGroupSize), largeGroupCnt);
            for (int i = 1; i < k; i++) curRes -= res[i] * Permutation(k, i);
            curRes *= InvFactorial(k);
            res[k] = curRes;
        }
        // Console.WriteLine(string.Join("\n", res.Skip(1)));
        return res;
    }

    static ModInt[] Naive(int n, int m)
    {
        static IEnumerable<int[]> Generate(int cnt, int max)
        {
            if (cnt == 0)
            {
                yield return new int[0];
                yield break;
            }
            foreach (var item in Generate(cnt - 1, max))
            {
                for (int i = 0; i < max; i++)
                {
                    yield return item.Append(i).ToArray();
                }
            }
        }
        ModInt[] allRes = new ModInt[n + 1];
        for (int k = 1; k <= n; k++)
        {
            ModInt res = 0;
            foreach (var grouped in Generate(n, k))
            {
                int[][] groups = Enumerable.Range(0, n).GroupBy(x => grouped[x]).Select(x => x.ToArray()).ToArray();
                if (groups.Length != k) continue;
                if (groups.Any(x => x.Length != x.Select(x => x % m).Distinct().Count())) continue;
                res++;
            }
            res /= Factorial(k);
            allRes[k] = res;
        }
        return allRes;
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
    const int MAX = 100000;
    static ModInt[] FactorialMemo = new ModInt[MAX + 1];
    static ModInt[] InvFactorialMemo = new ModInt[MAX + 1];
    static P()
    {
        FactorialMemo[0] = 1;
        for (int i = 1; i <= MAX; i++) FactorialMemo[i] = FactorialMemo[i - 1] * i;
        InvFactorialMemo[MAX] = 1 / FactorialMemo[MAX];
        for (int i = MAX - 1; i >= 0; i--) InvFactorialMemo[i] = InvFactorialMemo[i + 1] * (i + 1);
    }
    static ModInt Factorial(int x) => FactorialMemo[x];
    static ModInt InvFactorial(int x) => InvFactorialMemo[x];

    static ModInt Permutation(int n, int m) => Factorial(n) * InvFactorial(n - m);
    static ModInt Combination(int n, int m) => Factorial(n) * InvFactorial(m) * InvFactorial(n - m);
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
