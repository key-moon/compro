// detail: https://codeforces.com/contest/846/submission/111318653
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
        var nkm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nkm[0];
        var m = nkm[2];
        var t = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();

        long[] dp = Enumerable.Repeat(long.MaxValue / 2, n * (t.Length + 1) + 1).ToArray();
        dp[0] = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = dp.Length - 1; j >= 0; j--)
            {
                long sum = 0;
                for (int k = 0; k < t.Length; k++)
                {
                    sum += t[k];
                    var nxt = j + k + 1 + (k + 1 == t.Length ? 1 : 0);
                    if (nxt < dp.Length) dp[nxt] = Min(dp[nxt], dp[j] + sum);
                }
            }
        }

        int res = 0;
        for (int i = 0; i < dp.Length; i++)
        {
            if (dp[i] <= m) res = i;
        }
        Console.WriteLine(res);
    }
}