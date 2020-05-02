// detail: https://atcoder.jp/contests/abc165/submissions/12624546
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];

        List<string> res = new List<string>();
        var pivot = ((n - 1) / 2) / 2;
        var max = pivot;
        for (int i = 1; i <= pivot; i++)
        {
            res.Add($"{pivot - i + 1} {pivot + i + 1}");
            max = Max(max, pivot + i);
        }
        max++;
        var top = n - (n % 2 == 0 ? 1 : 0) - 1;
        while (max < top)
        {
            res.Add($"{max + 1} {top + 1}");
            max++;
            top--;
        }

        Console.WriteLine(string.Join("\n", res.Take(m)));
    }
}