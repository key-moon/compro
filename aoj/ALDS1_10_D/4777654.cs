// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_10_D/judge/4777654/C#
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
        var p = Console.ReadLine().Split().Select(double.Parse).ToArray();
        var q = Console.ReadLine().Split().Select(double.Parse).ToArray();
        double[][] sums = Enumerable.Range(0, n + 1).Select(_ => new double[n + 1]).ToArray();
        for (int i = 0; i <= n; i++)
        {
            sums[i][i] = q[i];
            for (int j = i + 1; j <= n; j++)
            {
                sums[i][j] = sums[i][j - 1] + p[j - 1] + q[j];
            }
        }
        double[][] costs = Enumerable.Range(0, n + 1).Select(_ => Enumerable.Repeat(double.MaxValue, n + 1).ToArray()).ToArray();
        for (int i = 0; i <= n; i++)
            costs[i][i] = q[i];
        for (int i = 1; i < costs.Length; i++)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                for (int k = j; k < i; k++)
                {
                    costs[j][i] = Min(costs[j][i], (costs[j][k] + sums[j][k]) + p[k] + (costs[k + 1][i] + sums[k + 1][i]));
                }
            }
        }
        Console.WriteLine(costs[0][n]);
    }
}

