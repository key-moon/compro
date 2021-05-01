// detail: https://atcoder.jp/contests/zone2021/submissions/22209373
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
        var ndh = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = ndh[0];
        var D = ndh[1];
        var H = ndh[2];
        var objs = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var res = objs.Max(x =>
        {
            var d = x[0];
            var h = x[1];
            return h - ((double)H - h) / (D - d) * d;
        });
        Console.WriteLine(Max(res, 0));
    }
}