// detail: https://yukicoder.me/submissions/422748
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        Action<bool> assert = (bool b) => { if (!b) throw new Exception(); };
        var p = int.Parse(Console.ReadLine());
        assert(1 <= p && p <= 1000000000);
        var fibs = GetFibs(p, 2000000);
        var res = Solve(fibs);
        //var res = SolveStupid(fibs);
        var Q = int.Parse(Console.ReadLine());
        assert(1 <= Q && Q <= 200000);
        for (int i = 0; i < Q; i++)
        {
            var q = int.Parse(Console.ReadLine());
            assert(2 <= q && q <= 2000000);
            Console.WriteLine(res[q].ToString());
        }
        Console.Out.Flush();
    }

    static ModInt[] Solve(ModInt[] fibs)
    {
        ModInt[] res = new ModInt[fibs.Length];
        res[2] = 0;
        res[3] = 0;
        for (int i = 4; i < res.Length; i++)
        {
            res[i] = (i - 3) * fibs[i - 2] - res[i - 2];
        }
        return res;
    }

    static ModInt[] SolveStupid(ModInt[] fibs)
    {
        ModInt[] res = new ModInt[fibs.Length * 2];
        for (int i = 1; i < fibs.Length; i++)
            for (int j = 1; j < fibs.Length; j++)
                res[i + j] += fibs[i] * fibs[j];
        return res;
    }

    static ModInt[] GetFibs(int p, int count)
    {
        ModInt[] fibs = new ModInt[count + 1];
        fibs[1] = 0;
        fibs[2] = 1;
        for (int i = 3; i < fibs.Length; i++)
            fibs[i] = fibs[i - 1] * p + fibs[i - 2];
        return fibs;
    }
}


struct ModInt
{
    const int MOD = 1000000007;
    long Data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ModInt(long data) { if ((Data = data % MOD) < 0) Data += MOD; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator long(ModInt modInt) => modInt.Data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ModInt(long val) => new ModInt(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, ModInt b) { long res = a.Data + b.Data; return new ModInt() { Data = res >= MOD ? res - MOD : res }; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, long b) => a.Data + b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt() { Data = a.Data * b.Data % MOD };
    public override string ToString() => Data.ToString();
}
