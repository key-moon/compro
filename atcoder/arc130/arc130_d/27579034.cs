// detail: https://atcoder.jp/contests/arc130/submissions/27579034
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

        // 赤チップが一つだけ入った列二つを順序を保ったままマージする。
        // 全てのマージの方法において、青チップを赤チップより左の場所に置く方法の数の和
        // 青チップ/列1, 青チップ/列2だけ取り出した時、どこに入るかは独立
        // \sum_i(nCi) を各 n ごとに前計算してから掛け算 

        // 違くて、青チップを i 番目に置く場合の場合の数がほしい
        // 列 1 から j 個、列 2 から i-j 個持ってくる
        // これができるのは、列 1 が j 番目以降だった場合かつ列 2 が i-j 番目以降だった場合

        ModInt[][] accumTable = Enumerable.Range(0, n + 1).Select(_ => new ModInt[n + 1]).ToArray();
        for (int i = 0; i < accumTable.Length; i++)
        {
            accumTable[i][0] = Combination(i, 0);
            for (int j = 1; j <= i; j++)
            {
                accumTable[i][j] = accumTable[i][j - 1] + Combination(i, j);
            }
        }

        List<int>[] tree = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            tree[st[0]].Add(st[1]);
            tree[st[1]].Add(st[0]);
        }

        const int BEFORE = 1;
        const int AFTER = -1;

        ModInt[] DFS(int root, int par, int nxtOrd)
        {
            ModInt[] res = new ModInt[1] { 1 };
            foreach (var adj in tree[root])
            {
                if (adj == par) continue;
                var toMerge = DFS(adj, root, -nxtOrd);
                if (nxtOrd == BEFORE) Array.Reverse(toMerge);

                ModInt[] bAccum = new ModInt[toMerge.Length + 1];
                for (int i = 1; i < bAccum.Length; i++) bAccum[i] = bAccum[i - 1] + toMerge[i - 1];
                ModInt bSum = bAccum.Last();

                ModInt[] nxt = new ModInt[res.Length + toMerge.Length];
                for (int i = 0; i < res.Length; i++)
                {
                    for (int j = 0; j <= toMerge.Length; j++)
                    {
                        // i 番目の前に j 個あり、その中に赤が含まれていない
                        var prevA = i;
                        var prevB = j;
                        var afterA = res.Length - prevA - 1; // 青玉は除く
                        var afterB = toMerge.Length - prevB; // 赤玉は含む
                        nxt[i + j] += 
                            res[i] * (bSum - bAccum[j]) * 
                            Combination(prevA + prevB, prevA) * 
                            Combination(afterA + afterB, afterA);
                    }
                }

                res = nxt;
            }
            if (nxtOrd == BEFORE) Array.Reverse(res);
            return res;
        }

        var res1 = DFS(0, -1, BEFORE);
        var res2 = DFS(0, -1, AFTER);

        var res = new ModInt(0);
        res += res1.Aggregate((x, y) => x + y);
        res += res2.Aggregate((x, y) => x + y);
        Console.WriteLine(res);
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
    static ModInt Combination(int n, int m) => Factorial(n) * InvFactorial(m) * InvFactorial(n - m);
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
