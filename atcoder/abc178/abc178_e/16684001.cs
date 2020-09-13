// detail: https://atcoder.jp/contests/abc178/submissions/16684001
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
        var points = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();
        var a = points.Select(x => x[0] + x[1]).ToArray();
        var b = points.Select(x => x[0] - x[1]).ToArray();
        Console.WriteLine(Max(a.Max() - a.Min(), b.Max() - b.Min()));
    }
}