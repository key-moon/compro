// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_10_B/judge/4775092/C#
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
        int n = int.Parse(Console.ReadLine());
        var a = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int[][] costs = Enumerable.Repeat(0, n).Select(_ => Enumerable.Repeat(int.MaxValue / 4, n).ToArray()).ToArray();
        for (int i = 0; i < n; i++)
            costs[i][i] = 0;
        for (int i = 0; i < n; i++)
            for (int j = i - 1; j >= 0; j--)
                for (int k = j; k < i; k++)
                    costs[j][i] = Min(costs[j][i], costs[j][k] + costs[k + 1][i] + a[j][0] * a[i][1] * a[k][1]);         
        Console.WriteLine(costs[0][n - 1]);
    }
}

