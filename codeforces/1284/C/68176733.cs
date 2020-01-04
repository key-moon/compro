// detail: https://codeforces.com/contest/1284/submission/68176733
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
    static int MOD;

    public static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        MOD = nm[1];
        long res = 0;
        for (int frameSize = 1; frameSize <= n; frameSize++)
        {
            res += (n - frameSize + 1) * Factorial(frameSize) % MOD * Factorial(n - frameSize + 1) % MOD;
            res %= MOD;
        }
        Console.WriteLine(res);
    }

    static List<long> factorialMemo = new List<long>() { 1 };
    static long Factorial(int x)
    {
        for (int i = factorialMemo.Count; i <= x; i++) factorialMemo.Add(factorialMemo.Last() * i % MOD);
        return factorialMemo[x];
    }
}
