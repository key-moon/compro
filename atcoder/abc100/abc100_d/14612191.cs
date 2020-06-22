// detail: https://atcoder.jp/contests/abc100/submissions/14612191
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
        var cakes = Enumerable.Repeat(0, nm[0]).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();
        long res = 0;
        for (int i = -1; i <= 1; i += 2)
        {
            for (int j = -1; j <= 1; j += 2)
            {
                for (int k = -1; k <= 1; k += 2)
                {
                    var sum = cakes.Select(x => i * x[0] + j * x[1] + k * x[2]).OrderByDescending(x => x).Take(nm[1]).Sum();
                    res = Max(res, sum);
                }
            }
        }
        Console.WriteLine(res);
    }
}