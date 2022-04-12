// detail: https://atcoder.jp/contests/abc051/submissions/30928749
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
        var ks = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var k = ks[0];
        var s = ks[1];
        int res = 0;
        for (int x = 0; x <= k; x++)
        {
            for (int y = 0; y <= k; y++)
            {
                var z = s - x - y;
                if (z < 0 || k < z) continue;
                res++;
            }
        }
        Console.WriteLine(res);
    }
}