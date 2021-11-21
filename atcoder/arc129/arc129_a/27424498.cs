// detail: https://atcoder.jp/contests/arc129/submissions/27424498
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
        var nlr = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nlr[0];
        var l = nlr[1];
        var r = nlr[2];
        Console.WriteLine(Solve(n, r) - Solve(n, l - 1));
    }
    static long Solve(long n, long max)
    {
        long res = 0;
        for (int i = 63; i >= 0; i--)
        {
            if ((n >> i & 1) == 1)
            {
                if ((1L << i) <= max)
                {
                    var mx = Min((1L << (i + 1)) - 1, max);
                    res += mx - (1L << i) + 1;
                }
            }
        }
        return res;
    }
}
