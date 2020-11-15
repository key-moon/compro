// detail: https://codeforces.com/contest/1446/submission/98456843
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var s = Console.ReadLine();
        var t = Console.ReadLine();
        int[][] dp = Enumerable.Repeat(0, s.Length + 1).Select(_ => new int[t.Length + 1]).ToArray();
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 0; j < t.Length; j++)
            {
                if (s[i] == t[j]) dp[i + 1][j + 1] = Max(dp[i + 1][j + 1], Max(dp[i][j] - 2 + 4, 4 - 2));
                dp[i + 1][j + 1] = Max(dp[i + 1][j + 1], Max(dp[i][j + 1] - 1, dp[i + 1][j] - 1));
            }
        }

        //Console.WriteLine(string.Join("\n", dp.Select(x => string.Join(" ", x))));
        Console.WriteLine(dp.Max(x => x.Max()));
    }
}