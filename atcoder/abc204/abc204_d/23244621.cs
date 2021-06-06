// detail: https://atcoder.jp/contests/abc204/submissions/23244621
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
        int n = int.Parse(Console.ReadLine());
        var t = Console.ReadLine().Split().Select(int.Parse).ToArray();

        bool[] dp = new bool[t.Sum() + 1];
        dp[0] = true;
        foreach (var item in t)
        {
            for (int i = dp.Length - 1; i >= item; i--)
                dp[i] |= dp[i - item];
        }

        var sum = t.Sum();

        int value = (t.Sum() + 1) / 2;
        while (true)
        {
            if (dp[value])
            {
                Console.WriteLine(value);
                break;
            }
            value++;
        }
    }
}
