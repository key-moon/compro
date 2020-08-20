// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_10_C/judge/4775123/C#
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
        int q = int.Parse(Console.ReadLine());
        for (int ctr = 0; ctr < q; ctr++)
        {
            var s = Console.ReadLine();
            var t = Console.ReadLine();
            //dp[i] := s[i]まで使った
            int[] dp = new int[s.Length];
            foreach (var c in t)
            {
                var curMax = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    var cur = dp[i];
                    if (c == s[i]) dp[i] = curMax + 1;
                    curMax = Max(curMax, cur);
                }
            }
            Console.WriteLine(dp.Max());
        }
    }
}

