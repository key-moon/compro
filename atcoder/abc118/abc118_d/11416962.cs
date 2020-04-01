// detail: https://atcoder.jp/contests/abc118/submissions/11416962
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;


public static class P
{
    static void Main()
    {
        var count = new[] { 0, 2, 5, 5, 4, 5, 6, 3, 7, 6 };
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        BigInteger[] dp = new BigInteger[nm[0] + 10];
        for (int i = 0; i <= nm[0]; i++)
        {
            if (i != 0 && dp[i] == 0) continue;
            foreach (var c in a)
            {
                dp[i + count[c]] = BigInteger.Max(dp[i + count[c]], dp[i] * 10 + c);
            }
        }
        Console.WriteLine(dp[nm[0]]);
    }
}
