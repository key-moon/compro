// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_14_C/judge/4777626/C#
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
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        RollingHash[] rhs = new RollingHash[h];
        for (int i = 0; i < h; i++)
            rhs[i] = new RollingHash(Console.ReadLine());
        var rc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = rc[0];
        var c = rc[1];
        ulong[] hashes = new ulong[r];
        for (int i = 0; i < r; i++)
            hashes[i] = new RollingHash(Console.ReadLine()).Slice(0, c);
        for (int i = 0; i <= h - r; i++)
        {
            for (int j = 0; j <= w - c; j++)
            {
                for (int k = 0; k < r; k++)
                {
                    if (rhs[i + k].Slice(j, c) != hashes[k]) goto end;
                }
                Console.WriteLine($"{i} {j}");
                end:;
            }
        }
        Console.Out.Flush();
    }
}


class RollingHash
{
    const ulong MASK30 = (1UL << 30) - 1;
    const ulong MASK31 = (1UL << 31) - 1;
    const ulong MOD = (1UL << 61) - 1;
    const ulong POSITIVIZER = MOD * ((1UL << 3) - 1);
    static uint Base;
    static ulong[] powMemo = new ulong[1000 + 1];
    static RollingHash()
    {
        Base = (uint)new Random().Next(129, int.MaxValue);
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

