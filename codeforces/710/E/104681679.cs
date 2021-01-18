// detail: https://codeforces.com/contest/710/submission/104681679
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
    static long x;
    static long y;
    public static void Main()
    {
        var input = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = input[0];

        x = input[1];
        y = input[2];

        memo[0] = 0;
        
        var res = Calc(n);
        Console.WriteLine(res);
    }
    static Dictionary<long, long> memo = new Dictionary<long, long>();
    static long Calc(long val)
    {
        if (memo.ContainsKey(val)) return memo[val];
        memo[val] = long.MaxValue / 2;
        long res = val * x;
        if ((val & 1) == 0) res = Min(res, Calc(val >> 1) + y);
        else res = Min(res, Min(Calc(val + 1), Calc(val - 1)) + x);
        return memo[val] = res;
    }
}
