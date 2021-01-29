// detail: https://yukicoder.me/submissions/610975
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

        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static bool isKadomatsu(int a, int b, int c)
    {
        if (a == b || b == c || c == a) return false;
        if (a < b && b > c) return true;
        if (a > b && b < c) return true;
        return false;
    }
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long Solve(int[] arr)
        {
            long[] dp = new long[n + 1];
            for (int i = 2; i < arr.Length; i++)
            {
                dp[i + 1] = dp[i];
                if (isKadomatsu(arr[i - 2], arr[i - 1], arr[i])) dp[i + 1] = Max(dp[i - 2] + arr[i - 2], dp[i + 1]);
            }
            return dp[n];
        }
        Console.WriteLine(Enumerable.Range(0, 3).Select(x => Solve(a.Skip(x).Concat(a.Take(x)).ToArray())).Max());
    }
}