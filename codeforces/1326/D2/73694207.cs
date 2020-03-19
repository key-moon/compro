// detail: https://codeforces.com/contest/1326/submission/73694207
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
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
        var t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
        Console.Out.Flush();
    }
    static void Solve()
    {
        var s = Console.ReadLine();
        var revS = string.Join("", s.Reverse());
        var hash = new RollingHash(s);
        var revHash = new RollingHash(revS);
        if (s == revS)
        {
            Console.WriteLine(s);
            return;
        }
        var reses = new[]
        {
            Solve1(s.Length, hash, revHash),
            Solve1(s.Length, revHash, hash),
            Solve2(s.Length, hash, revHash),
            Solve2(s.Length, revHash, hash)
        };
        var maxLen = reses.Max(x => x.Length);
        var res = reses.First(x => x.Length == maxLen);
        Console.WriteLine(res);
    }
    static string Solve1(int n, RollingHash hash, RollingHash revHash)
    {
        var max = 0;
        for (int i = 1; i < n; i++)
        {
            if (hash.Slice(0, i) == revHash.Slice(n - i, i)) max = i;
        }
        return hash.Original.Substring(0, max);
        //return max;
    }
    static string Solve2(int n, RollingHash hash, RollingHash revHash)
    {
        var unmatchPoint = 0;
        for (int i = 1; i < n; i++)
        {
            if (hash.Slice(0, i) != revHash.Slice(0, i))
            {
                unmatchPoint = i - 1;
                break;
            }
        }
        var longest = 0;
        for (int i = 1; i <= n - unmatchPoint * 2; i++)
        {
            if (hash.Slice(unmatchPoint, i) == revHash.Slice(n - unmatchPoint - i, i))
            {
                longest = i;
            }
        }

        return hash.Original.Substring(0, unmatchPoint)
            + hash.Original.Substring(unmatchPoint, longest)
            + hash.Original.Substring(n - unmatchPoint, unmatchPoint);
    }
}


class RollingHash
{
    const ulong MASK30 = (1UL << 30) - 1;
    const ulong MASK31 = (1UL << 31) - 1;
    const ulong MOD = (1UL << 61) - 1;
    const ulong POSITIVIZER = MOD * ((1UL << 3) - 1);
    static uint Base;
    static ulong[] powMemo = new ulong[1000000 + 1];
    static RollingHash()
    {
        Base = (uint)new Random().Next(129, int.MaxValue);
        powMemo[0] = 1;
        for (int i = 1; i < powMemo.Length; i++)
            powMemo[i] = CalcMod(Mul(powMemo[i - 1], Base));
    }
    public string Original;

    ulong[] hash;

    public RollingHash(string s)
    {
        Original = s;
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
