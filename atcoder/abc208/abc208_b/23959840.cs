// detail: https://atcoder.jp/contests/abc208/submissions/23959840
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
        var p = int.Parse(Console.ReadLine());
        int[] minCost = Enumerable.Repeat(int.MaxValue / 2, p + 1).ToArray();
        minCost[0] = 0;
        var cur = 1;
        for (int i = 1; i <= 10; i++)
        {
            cur *= i;
            for (int j = cur; j < minCost.Length; j++)
            {
                minCost[j] = Min(minCost[j], minCost[j - cur] + 1);
            }
        }
        Console.WriteLine(minCost[p]);
    }
}