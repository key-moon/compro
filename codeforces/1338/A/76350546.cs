// detail: https://codeforces.com/contest/1338/submission/76350546
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
        for (int i = 0; i < t; i++) Solve();
    }
    public static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long max = a[0];
        long maxDepth = 0;
        for (int i = 1; i < a.Length; i++)
        {
            if (max > a[i])
            {
                maxDepth = Max(maxDepth, max - a[i]);
            }
            else
            {
                max = a[i];
            }
        }
        Console.WriteLine(maxDepth == 0 ? 0 : Convert.ToString(maxDepth, 2).Length);
    }
}