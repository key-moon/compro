// detail: https://atcoder.jp/contests/abc183/submissions/18121982
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
        var w = nw[1];
        var q = new List<(long, long)>();
        for (int i = 0; i < n; i++)
        {
            var stp = Console.ReadLine().Split().Select(long.Parse).ToArray();
            q.Add((stp[0], stp[2]));
            q.Add((stp[1], -stp[2]));
        }
        long cur = 0;
        foreach (var item in q.GroupBy(x => x.Item1).OrderBy(x => x.Key))
        {
            var key = item.Key;
            cur += item.Sum(x => x.Item2);
            if (w < cur)
            {
                Console.WriteLine("No");
                return;
            }
        }
        Console.WriteLine("Yes");
    }
}
