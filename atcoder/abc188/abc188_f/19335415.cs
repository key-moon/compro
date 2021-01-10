// detail: https://atcoder.jp/contests/abc188/submissions/19335415
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
        var xy = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var x = xy[0];
        var y = xy[1];

        Dictionary<long, long> memo = new Dictionary<long, long>();
        long Calc(long y)
        {
            if (memo.ContainsKey(y)) return memo[y];
            if (x >= y) return memo[y] = Abs(x - y);
            long res = Abs(y - x);
            if ((y & 1) == 0) res = Min(res, Calc(y >> 1) + 1);
            else res = Min(res, Min(Calc((y + 1) >> 1), Calc((y - 1) >> 1)) + 2);
            return memo[y] = res;
        }
        Calc(5);
        var res = Calc(y);
        Console.WriteLine(res);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long MSB(long s) { s |= s >> 1; s |= s >> 2; s |= s >> 4; s |= s >> 8; s |= s >> 16; s |= s >> 32; return (s + 1) >> 1; }
}
