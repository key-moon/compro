// detail: https://yukicoder.me/submissions/612304
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        var abc = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var orders = new[]
        {
            new[] { 1, 0, 2 },
            new[] { 1, 2, 0 },
            new[] { 2, 0, 1 },
            new[] { 0, 2, 1 },
        };
        long min = long.MaxValue;
        foreach (var order in orders)
        {
            var vals = abc.ToArray();
            long res = 0;
            for (int i = 1; i < order.Length; i++)
            {
                var prev = order[i - 1];
                var cur = order[i];
                var sub = Max(vals[cur] - (vals[prev] - 1), 0);
                vals[cur] -= sub;
                res += sub;
            }
            if (1 <= vals.Min()) min = Min(min, res);
        }
        Console.WriteLine(min == long.MaxValue ? -1 : min);
    }
}
