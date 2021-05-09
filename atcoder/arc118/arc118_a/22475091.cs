// detail: https://atcoder.jp/contests/arc118/submissions/22475091
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
        var tn = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var t = tn[0];
        var n = tn[1];
        // 境界の値→
        Console.WriteLine((100 * n - 1) / t + n);
    }
}