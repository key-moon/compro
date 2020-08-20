// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_15_B/judge/4776391/C#
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
        var nw = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nw[0];
        var totalWeight = nw[1];

        var products = Enumerable.Repeat(0, (int)n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).OrderByDescending(x => (double)x[0] / x[1]).ToArray();
        long res = 0;
        double fracRes = 0;
        foreach (var product in products)
        {
            var v = product[0];
            var w = product[1];
            if (totalWeight < w)
            {
                var additional = ((double)v / w) * totalWeight;
                res += (long)Floor(additional);
                fracRes = additional % 1;
                break;
            }
            res += v;
            totalWeight -= w;
        }
        Console.Write(res); Console.WriteLine(fracRes.ToString(".#############"));
    }
}
