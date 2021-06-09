// detail: https://atcoder.jp/contests/abc145/submissions/23311574
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
        var nt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nt[0];
        var t = nt[1];

        int[] dp = new int[t + 1];
        foreach (var ab in Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).OrderBy(x => x[0]))
        {
            var a = ab[0];
            var b = ab[1];
            for (int i = t - 1; i >= 0; i--)
            {
                var ind = Min(t, i + a);
                dp[ind] = Max(dp[ind], dp[i] + b);
            }
        }
        Console.WriteLine(dp.Max());
    }
}