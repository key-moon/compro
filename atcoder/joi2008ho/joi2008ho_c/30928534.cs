// detail: https://atcoder.jp/contests/joi2008ho/submissions/30928534
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
        var a = Enumerable.Repeat(0, n).Select(_ => long.Parse(Console.ReadLine())).Append(0).ToArray();
        var sums = a.SelectMany(x => a.Select(y => x + y)).Distinct().OrderBy(x => x).ToArray();

        long res = 0;

        foreach (var s1 in sums)
        {
            int valid = -1, invalid = sums.Length;
            while (invalid - valid > 1)
            {
                var mid = (invalid + valid) / 2;
                if (s1 + sums[mid] <= m) valid = mid;
                else invalid = mid;
            }
            if (valid != -1) res = Max(res, s1 + sums[valid]);
        }
        Console.WriteLine(res);
    }
}