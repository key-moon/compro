// detail: https://atcoder.jp/contests/arc060/submissions/16265820
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
        string s = Console.ReadLine();
        RollingHash rh = new RollingHash(s);
        if (s.Distinct().Count() == 1)
        {
            Console.WriteLine(s.Length);
            Console.WriteLine(1);
            return;
        }
        bool[] isBad = new bool[s.Length];
        for (int i = 1; i < s.Length; i++)
        {
            var hash = rh[0..i];
            for (int j = i * 2; j <= s.Length; j += i)
            {
                if (rh[(j - i)..j] != hash) break;
                isBad[j - 1] = true;
            }
        }
        if (!isBad.Last())
        {
            Console.WriteLine(1);
            Console.WriteLine(1);
            return;
        }
        bool[] isBadFromTail = new bool[s.Length];
        for (int i = 1; i < s.Length; i++)
        {
            var hash = rh[^i..];
            for (int j = i * 2; j <= s.Length; j += i)
            {
                if (rh[^j..^(j - i)] != hash) break;
                isBadFromTail[^j] = true;
            }
        }
        int res = 0;
        for (int i = 1; i < s.Length; i++)
        {
            if (isBad[i - 1] || isBadFromTail[i]) continue;
            res++;
        }
        Console.WriteLine(2);
        Console.WriteLine(res);
    }
}


class RollingHash
{
    const ulong MASK30 = (1UL << 30) - 1;
    const ulong MASK31 = (1UL << 31) - 1;
    const ulong MOD = (1UL << 61) - 1;
    const ulong POSITIVIZER = MOD * ((1UL << 3) - 1);
    static uint Base;
    static ulong[] powMemo = new ulong[500000 + 1];
    static RollingHash()
    {
        Base = (uint)new Random().Next(129, int.MaxValue);
        powMemo[0] = 1;
        for (int i = 1; i < powMemo.Length; i++)
            powMemo[i] = CalcMod(Mul(powMemo[i - 1], Base));
    }

    ulong[] hash;

    public int Length => hash.Length - 1;
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
