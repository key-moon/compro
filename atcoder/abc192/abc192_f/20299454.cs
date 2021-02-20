// detail: https://atcoder.jp/contests/abc192/submissions/20299454
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
        var nx = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = (int)nx[0];
        var x = nx[1];
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long res = long.MaxValue;
        for (int k = 1; k <= n; k++)
        {
            // dp[i][j] := i個取ってmodがjのときの最大値
            long[][] dp = Enumerable.Repeat(0, k + 1).Select(_ => Enumerable.Repeat(long.MinValue / 2, k).ToArray()).ToArray();
            dp[0][0] = 0;
            foreach (var item in a)
            {
                for (int i = k - 1; i >= 0; i--)
                {
                    for (int j = 0; j < k; j++)
                    {
                        if (dp[i][j] < 0) continue;
                        dp[i + 1][(j + item) % k] = Max(dp[i + 1][(j + item) % k], dp[i][j] + item);
                    }
                }
            }
            if (dp[k][x % k] < 0) continue;
            res = Min(res, (x - dp[k][x % k]) / k);
        }
        Console.WriteLine(res);
    }
}