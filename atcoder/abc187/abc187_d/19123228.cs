// detail: https://atcoder.jp/contests/abc187/submissions/19123228
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
        var ab = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();
        var a = ab.Select(x => x[0]).ToArray();
        var b = ab.Select(x => x[1]).ToArray();

        var diff = a.Sum();
        var earns = a.Zip(b, (x, y) => x * 2 + y).OrderByDescending(x => x).ToArray();
        int res = 0;
        foreach (var earn in earns)
        {
            diff -= earn;
            res++;
            if (diff < 0) break;
        }
        Console.WriteLine(res);
    }
}