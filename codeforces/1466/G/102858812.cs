// detail: https://codeforces.com/contest/1466/submission/102858812
//#define DEBUG
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nq[0];
        var q = nq[1];
#if DEBUG
        var s0 = "aa";
        var t = string.Join("", Enumerable.Repeat('a', n));
        //var t = string.Join("", Enumerable.Range(0, n).Select(x => (char)('a' + x % 26)));
#else
        var s0 = Console.ReadLine();
        var t = Console.ReadLine();
#endif

        var queries = Enumerable.Repeat(0, q).Select(_ => Console.ReadLine()).ToArray();

        int maxq = queries.Max(x => x.Split().Last().Length);

        List<string> s = new List<string>() { s0 };
        for (int i = 0; i < t.Length; i++)
        {
            var news = s.Last() + t[i] + s.Last();
            s.Add(news);
            if (maxq <= news.Length) break;
        }

        var sas = s.Select(SuffixArray).ToArray();

        var rh = new RollingHash(s.Last());
        static int GetCnt(string s, int[] sa, string t)
        {
            int lo_valid = -1, lo_invalid = s.Length;
            while (lo_invalid - lo_valid > 1)
            {
                var mid = (lo_valid + lo_invalid) / 2;

                int sj = sa[mid], tj = 0;
                for (; sj < s.Length && tj < t.Length; sj++, tj++)
                {
                    if (s[sj] != t[tj])
                    {
                        if (s[sj] < t[tj]) lo_valid = mid;
                        else lo_invalid = mid;
                        goto end;
                    }
                }
                // tよりsが長い
                if (tj == t.Length) lo_invalid = mid;
                else lo_valid = mid;
                end:;
            }


            int hi_valid = -1, hi_invalid = s.Length;
            while (hi_invalid - hi_valid > 1)
            {
                var mid = (hi_valid + hi_invalid) / 2;

                int sj = sa[mid], tj = 0;
                for (; sj < s.Length && tj < t.Length; sj++, tj++)
                {
                    if (s[sj] != t[tj])
                    {
                        if (s[sj] <= t[tj]) hi_valid = mid;
                        else hi_invalid = mid;
                        goto end;
                    }
                }
                hi_valid = mid;
                end:;
            }
            return hi_invalid - lo_invalid;
        }

        //含まれている個数
        ModInt[][] containsCnt = Enumerable.Repeat(0, n + 1).Select(_ => new ModInt[27]).ToArray();
        containsCnt[s.Count - 1][26] = 1;
        for (int i = s.Count; i < containsCnt.Length; i++)
        {
            for (int j = 0; j < containsCnt[i].Length; j++) containsCnt[i][j] += containsCnt[i - 1][j] * 2;
            containsCnt[i][t[i - 1] - 'a']++;
        }

        for (int i = 0; i < q; i++)
        {
#if DEBUG
            var query = $"{i % (n + 1)} a".Split();
#else
            var query = queries[i].Split();
#endif
            var ind = int.Parse(query[0]);
            var name = query[1];


            ModInt res = 0;
            if (ind < s.Count)
            {
                res = GetCnt(s[ind], sas[ind], name);
            }
            else
            {
                var lastNameCnt = GetCnt(s.Last(), sas.Last(), name);
                res += lastNameCnt * containsCnt[ind][26];
                var nameHash = new RollingHash(name);
                for (int pivot = 0; pivot < name.Length; pivot++)
                {
                    var aLen = pivot;
                    var bLen = name.Length - pivot - 1;
                    if (rh.Slice(rh.Length - aLen, aLen) == nameHash.Slice(0, aLen) &&
                        rh.Slice(0, bLen) == nameHash.Slice(aLen + 1, bLen))
                    {
                        res += containsCnt[ind][name[pivot] - 'a'];
                    }
                }
            }
            Console.WriteLine(res);
        }
        Console.Out.Flush();
    }
    public static int[] SuffixArray(string s)
    {
        var n = s.Length;
        int[] s2 = s.Select(c => (int)c).ToArray();
        return String.SAIS(s2, char.MaxValue);
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


class RollingHash
{
    public int Length => hash.Length - 1;
    const ulong MASK30 = (1UL << 30) - 1;
    const ulong MASK31 = (1UL << 31) - 1;
    const ulong MOD = (1UL << 61) - 1;
    const ulong POSITIVIZER = MOD * ((1UL << 3) - 1);
    static uint Base;
    static ulong[] powMemo = new ulong[(int)1e6 + 101];
    static RollingHash()
    {
        Base = (uint)new Random((int)(DateTime.Now.Ticks % 1000000007)).Next(129, int.MaxValue);
        powMemo[0] = 1;
        for (int i = 1; i < powMemo.Length; i++)
            powMemo[i] = CalcMod(Mul(powMemo[i - 1], Base));
    }

    ulong[] hash;

    public RollingHash(string s)
    {
        hash = new ulong[s.Length + 1];
        for (int i = 0; i < s.Length; i++)
            hash[i + 1] = CalcMod(Mul(hash[i], Base) + s[i]);
    }

    public ulong Slice(int begin, int length)
    {
        return CalcMod(hash[begin + length] + POSITIVIZER - Mul(hash[begin], powMemo[length]));
    }

    private static ulong Mul(ulong l, ulong r)
    {
        var lu = l >> 31;
        var ld = l & MASK31;
        var ru = r >> 31;
        var rd = r & MASK31;
        var middleBit = ld * ru + lu * rd;
        return ((lu * ru) << 1) + ld * rd + ((middleBit & MASK30) << 31) + (middleBit >> 30);
    }

    private static ulong Mul(ulong l, uint r)
    {
        var lu = l >> 31;
        var rd = r & MASK31;
        var middleBit = lu * rd;
        return (l & MASK31) * rd + ((middleBit & MASK30) << 31) + (middleBit >> 30);
    }

    private static ulong CalcMod(ulong val)
    {
        val = (val & MOD) + (val >> 61);
        if (val >= MOD) val -= MOD;
        return val;
    }
}


public static class String
{
    /// <summary>
    /// 数列 <paramref name="sm"/> の Suffix Array をナイーブな文字列比較により求め、長さ |<paramref name="sm"/>| の配列として返す。
    /// </summary>
    /// <remarks>
    /// <para>Suffix Array sa は (0,1,…,n−1) の順列であって、i=0,1,⋯,n−2 について s[sa[i]..n)&lt;s[sa[i+1]..n) を満たすもの。</para>
    /// <para>制約: 0≤|<paramref name="sm"/>|&lt;10^8</para>
    /// <para>計算量: 時間O(|<paramref name="sm"/>|^2 log|<paramref name="sm"/>|), 空間O(|<paramref name="sm"/>|)</para>
    /// </remarks>
    private static int[] SANaive(ReadOnlyMemory<int> sm)
    {
        var n = sm.Length;
        var sa = Enumerable.Range(0, n).ToArray();
        Array.Sort(sa, Compare);
        return sa;

        int Compare(int l, int r)
        {
            // l == r にはなり得ない
            var s = sm.Span;
            while (l < s.Length && r < s.Length)
            {
                if (s[l] != s[r])
                {
                    return s[l] - s[r];
                }
                l++;
                r++;
            }

            return r - l;
        }
    }

    /// <summary>
    /// 数列 <paramref name="sm"/> の Suffix Array をダブリングにより求め、長さ |<paramref name="sm"/>| の配列として返す。
    /// </summary>
    /// <remarks>
    /// <para>Suffix Array sa は (0,1,…,n−1) の順列であって、i=0,1,⋯,n−2 について s[sa[i]..n)&lt;s[sa[i+1]..n) を満たすもの。</para>
    /// <para>制約: 0≤|<paramref name="sm"/>|&lt;10^8</para>
    /// <para>計算量: 時間O(|<paramref name="sm"/>|(log|<paramref name="sm"/>|)^2), 空間O(|<paramref name="sm"/>|)</para>
    /// </remarks>
    private static int[] SADoubling(ReadOnlyMemory<int> sm)
    {
        var s = sm.Span;
        var n = s.Length;
        var sa = Enumerable.Range(0, n).ToArray();
        var rnk = new int[n];
        var tmp = new int[n];
        s.CopyTo(rnk);

        for (int k = 1; k < n; k <<= 1)
        {
            Array.Sort(sa, Compare);
            tmp[sa[0]] = 0;
            for (int i = 1; i < sa.Length; i++)
            {
                tmp[sa[i]] = tmp[sa[i - 1]] + (Compare(sa[i - 1], sa[i]) < 0 ? 1 : 0);
            }
            (tmp, rnk) = (rnk, tmp);

            int Compare(int x, int y)
            {
                if (rnk[x] != rnk[y])
                {
                    return rnk[x] - rnk[y];
                }

                int rx = x + k < n ? rnk[x + k] : -1;
                int ry = y + k < n ? rnk[y + k] : -1;

                return rx - ry;
            }
        }

        return sa;
    }

    /// <summary>
    /// 数列 <paramref name="sm"/> の Suffix Array を SA-IS 等により求め、長さ |<paramref name="sm"/>| の配列を返す。
    /// </summary>
    /// <remarks>
    /// <para>Suffix Array sa は (0,1,…,n−1) の順列であって、i=0,1,⋯,n−2 について s[sa[i]..n)&lt;s[sa[i+1]..n) を満たすもの。</para>
    /// <para>制約: 0≤|<paramref name="sm"/>|&lt;10^8</para>
    /// <para>計算量: O(|<paramref name="sm"/>|)</para>
    /// </remarks>
    public static int[] SAIS(ReadOnlyMemory<int> sm, int upper) => SAIS(sm, upper, 10, 40);

    /// <summary>
    /// 数列 <paramref name="sm"/> の Suffix Array を SA-IS 等により求め、長さ |<paramref name="sm"/>| の配列を返す。
    /// </summary>
    /// <remarks>
    /// <para>Suffix Array sa は (0,1,…,n−1) の順列であって、i=0,1,⋯,n−2 について s[sa[i]..n)&lt;s[sa[i+1]..n) を満たすもの。</para>
    /// <para>制約: 0≤|<paramref name="sm"/>|&lt;10^8</para>
    /// <para>計算量: O(|<paramref name="sm"/>|)</para>
    /// </remarks>
    public static int[] SAIS(ReadOnlyMemory<int> sm, int upper, int thresholdNaive, int thresholdDouling)
    {
        var s = sm.Span;
        var n = s.Length;

        if (n == 0)
        {
            return Array.Empty<int>();
        }
        else if (n == 1)
        {
            return new int[] { 0 };
        }
        else if (n == 2)
        {
            if (s[0] < s[1])
            {
                return new int[] { 0, 1 };
            }
            else
            {
                return new int[] { 1, 0 };
            }
        }
        else if (n < thresholdNaive)
        {
            return SANaive(sm);
        }
        else if (n < thresholdDouling)
        {
            return SADoubling(sm);
        }

        var sa = new int[n];
        var ls = new bool[n];

        for (int i = sa.Length - 2; i >= 0; i--)
        {
            // S-typeならtrue、L-typeならfalse
            ls[i] = (s[i] == s[i + 1]) ? ls[i + 1] : (s[i] < s[i + 1]);
        }

        // バケットサイズの累積和（＝開始インデックス）
        var sumL = new int[upper + 1];
        var sumS = new int[upper + 1];

        for (int i = 0; i < s.Length; i++)
        {
            if (!ls[i])
            {
                sumS[s[i]]++;
            }
            else
            {
                sumL[s[i] + 1]++;
            }
        }

        for (int i = 0; i < sumL.Length; i++)
        {
            sumS[i] += sumL[i];
            if (i < upper)
            {
                sumL[i + 1] += sumS[i];
            }
        }

        var lmsMap = GetFilledArray(-1, n + 1);
        int m = 0;
        for (int i = 1; i < ls.Length; i++)
        {
            if (!ls[i - 1] && ls[i])
            {
                lmsMap[i] = m++;
            }
        }

        var lms = new List<int>(m);
        for (int i = 1; i < ls.Length; i++)
        {
            if (!ls[i - 1] && ls[i])
            {
                lms.Add(i);
            }
        }

        Induce(lms);

        // LMSを再帰的にソート
        if (m > 0)
        {
            var sortedLms = new List<int>(m);
            foreach (var v in sa)
            {
                if (lmsMap[v] != -1)
                {
                    sortedLms.Add(v);
                }
            }

            var recS = new int[m];
            var recUpper = 0;
            recS[lmsMap[sortedLms[0]]] = 0;

            // 同じLMS同士をまとめていく
            for (int i = 1; i < sortedLms.Count; i++)
            {
                var l = sortedLms[i - 1];
                var r = sortedLms[i];
                var endL = (lmsMap[l] + 1 < m) ? lms[lmsMap[l] + 1] : n;
                var endR = (lmsMap[r] + 1 < m) ? lms[lmsMap[r] + 1] : n;
                var same = true;

                if (endL - l != endR - r)
                {
                    same = false;
                }
                else
                {
                    while (l < endL)
                    {
                        if (s[l] != s[r])
                        {
                            break;
                        }
                        l++;
                        r++;
                    }

                    if (l == n || s[l] != s[r])
                    {
                        same = false;
                    }
                }

                if (!same)
                {
                    recUpper++;
                }

                recS[lmsMap[sortedLms[i]]] = recUpper;
            }

            var recSA = SAIS(recS, recUpper, thresholdNaive, thresholdDouling);

            for (int i = 0; i < sortedLms.Count; i++)
            {
                sortedLms[i] = lms[recSA[i]];
            }

            Induce(sortedLms);
        }

        return sa;

        void Induce(List<int> lms)
        {
            var s = sm.Span;
            sa.AsSpan().Fill(-1);
            var buf = new int[sumS.Length];

            // LMS
            sumS.AsSpan().CopyTo(buf);
            foreach (var d in lms)
            {
                if (d == n)
                {
                    continue;
                }
                sa[buf[s[d]]++] = d;
            }

            // L-type
            sumL.AsSpan().CopyTo(buf);
            sa[buf[s[n - 1]]++] = n - 1;
            for (int i = 0; i < sa.Length; i++)
            {
                int v = sa[i];
                if (v >= 1 && !ls[v - 1])
                {
                    sa[buf[s[v - 1]]++] = v - 1;
                }
            }

            // S-type
            sumL.AsSpan().CopyTo(buf);
            for (int i = sa.Length - 1; i >= 0; i--)
            {
                int v = sa[i];
                if (v >= 1 && ls[v - 1])
                {
                    sa[--buf[s[v - 1] + 1]] = v - 1;
                }
            }
        }
    }

    /// <summary>
    /// 各要素が <paramref name="value"/> で初期化された長さ <paramref name="length"/> の配列を取得する。
    /// </summary>
    private static T[] GetFilledArray<T>(T value, int length)
    {
        // Enumerable.Repeatより1-2割ほど高速（64bit環境、intの場合）
        // |           Method |     Mean |   Error |  StdDev |
        // |----------------- |---------:|--------:|--------:|
        // | EnumerableRepeat | 212.7 ms | 2.99 ms | 2.80 ms |
        // |         SpanFill | 178.7 ms | 1.29 ms | 1.14 ms |

        // ちなみにEnumerable.Rangeとnew[] + for文とでは有意差は見られない
        // |          Method |     Mean |   Error |  StdDev |
        // |---------------- |---------:|--------:|--------:|
        // | EnumerableRange | 225.6 ms | 4.35 ms | 3.85 ms |
        // |         SpanFor | 223.0 ms | 2.88 ms | 2.69 ms |

        var result = new T[length];
        result.AsSpan().Fill(value);
        return result;
    }
}