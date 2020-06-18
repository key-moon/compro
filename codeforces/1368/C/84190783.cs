// detail: https://codeforces.com/contest/1368/submission/84190783
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
        var n = int.Parse(Console.ReadLine());
        List<int[]> res = new List<int[]>();
        res.Add(new int[] { -1, -1 });
        res.Add(new int[] { 0, -1 });
        res.Add(new int[] { -1, 0 });
        res.Add(new int[] { 0, 0 });

        for (int i = 1; i <= n; i++)
        {
            res.Add(new int[] { i, i - 1 });
            res.Add(new int[] { i - 1, i });
            res.Add(new int[] { i, i });
        }

        Console.WriteLine(res.Count);
        Console.WriteLine(string.Join("\n", res.Select(x => string.Join(" ", x))));
    }
}