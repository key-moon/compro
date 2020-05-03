// detail: https://atcoder.jp/contests/abc141/submissions/12797189
using System;
using System.Collections.Generic;

public static class P
{
    static bool IsValid(RollingHash hash, int len)
    {
        HashSet<ulong> hashes = new HashSet<ulong>();
        for (int i = len; i <= hash.Length - len; i++)
        {
            hashes.Add(hash.Slice((i - len), len));
            if (hashes.Contains(hash.Slice(i, len))) return true;
        }
        return false;
    }

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        var hash = new RollingHash(s);

        int valid = 0, invalid = n;
        while (invalid - valid > 1)
        {
            var mid = (valid + invalid) / 2;
            if (IsValid(hash, mid)) valid = mid;
            else invalid = mid;
        }

        Console.WriteLine(valid);
    }
}


class RollingHash
{
    const ulong MASK30 = (1UL << 30) - 1;
    const ulong MASK31 = (1UL << 31) - 1;
    const ulong MOD = (1UL << 61) - 1;
    const ulong POSITIVIZER = MOD * ((1UL << 3) - 1);
    static uint Base;
    static ulong[] powMemo = new ulong[5000 + 1];
    static RollingHash()
    {
        Base = (uint)new Random().Next(129, int.MaxValue);
        powMemo[0] = 1;
        for (int i = 1; i < powMemo.Length; i++)
            powMemo[i] = CalcMod(Mul(powMemo[i - 1], Base));
    }

    public int Length => hash.Length - 1;
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