// detail: https://atcoder.jp/contests/abc180/submissions/17449487
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        int n = int.Parse(Console.ReadLine());
        var cs = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).Select(x => (x[0], x[1], x[2])).ToArray();

        long calcd(int i, int j)
        {
            var (a, b, c) = cs[i];
            var (p, q, r) = cs[j];
            return Abs(a - p) + Abs(b - q) + Max(0, r - c);
        }

        long[][] dists = Enumerable.Repeat(0, n).Select(_ => new long[n]).ToArray();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dists[i][j] = calcd(i, j);
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    dists[j][k] = Min(dists[j][k], dists[j][i] + dists[i][k]);
                }
            }
        }

        var dp = Enumerable.Repeat(0, 1 << n).Select(_ => Enumerable.Repeat(long.MaxValue / 2, n).ToArray()).ToArray();
        dp[0][0] = 0;

        for (int i = 0; i < (1 << n); i++)
        {
            for (int cur = 0; cur < n; cur++)
            {
                for (int next = 0; next < n; next++)
                {
                    var ni = i | (1 << next);
                    //if (i == ni) continue;
                    dp[ni][next] = Min(dp[i][cur] + dists[cur][next], dp[ni][next]);
                }
            }
        }

        Console.WriteLine(dp[(1 << n) - 1][0]);
    }
}


