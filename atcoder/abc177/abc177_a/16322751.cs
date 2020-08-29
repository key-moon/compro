// detail: https://atcoder.jp/contests/abc177/submissions/16322751
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
        var dts = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var d = dts[0];
        var t = dts[1];
        var s = dts[2];

        Console.WriteLine(t * s >= d ? "Yes" : "No");
    }
}