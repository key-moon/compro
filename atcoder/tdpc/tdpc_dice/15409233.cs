// detail: https://atcoder.jp/contests/tdpc/submissions/15409233
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
        var nd = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nd[0];
        var d = nd[1];
        var factorRes = PrimeFactors(d).ToArray();
        if (factorRes.Any(x => 5 < x))
        {
            Console.WriteLine(0);
            return;
        }
        var f2Count = factorRes.Count(x => x == 2);
        var f3Count = factorRes.Count(x => x == 3);
        var f5Count = factorRes.Count(x => x == 5);
        double[][][] dp = Enumerable.Range(0, f2Count + 1).Select(_ => Enumerable.Range(0, f3Count + 1).Select(_ => new double[f5Count + 1]).ToArray()).ToArray();

        dp[0][0][0] = 1;

        (int, int, int)[] factorCounts = new (int, int, int)[]
        {
            (0, 0, 0),
            (1, 0, 0),
            (0, 1, 0),
            (2, 0, 0),
            (0, 0, 1),
            (1, 1, 0)
        };

        for (int count = 0; count < n; count++)
        {
            double[][][] newdp = Enumerable.Range(0, f2Count + 1).Select(_ => Enumerable.Range(0, f3Count + 1).Select(_ => new double[f5Count + 1]).ToArray()).ToArray();
            foreach (var (f2, f3, f5) in factorCounts)
            {
                for (int i = 0; i < dp.Length; i++)
                    for (int j = 0; j < dp[i].Length; j++)
                        for (int k = 0; k < dp[i][j].Length; k++)
                            newdp[Min(i + f2, f2Count)][Min(j + f3, f3Count)][Min(k + f5, f5Count)]
                                += dp[i][j][k] / 6;
            }

            dp = newdp;
        }

        Console.WriteLine(dp.Last().Last().Last());
    }



    static IEnumerable<long> PrimeFactors(long n)
    {
        while ((n & 1) == 0)
        {
            n >>= 1;
            yield return 2;
        }
        for (long i = 3; i * i <= n; i += 2)
        {
            while (n % i == 0)
            {
                n /= i;
                yield return i;
            }
        }
        if (n != 1) yield return n;
    }
}
