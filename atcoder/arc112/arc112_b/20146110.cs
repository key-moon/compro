// detail: https://atcoder.jp/contests/arc112/submissions/20146110
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
        var bc = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var b = bc[0];
        var c = bc[1];
        List<(long, int)> list = new List<(long, int)>();
        void Add(long start, long end)
        {
            list.Add((start, 1));
            list.Add((end + 1, -1));
        }
        Add(b - c / 2, b);
        if (1 <= c) Add(-b, -(b - (c - 1) / 2));
        if (1 <= c) Add(-b - (c - 1) / 2, -b);
        if (2 <= c) Add(-(-b), -(-b - (c - 2) / 2));

        long res = 0;
        long cur = 0;
        long last = 0;
        foreach (var (val, d) in list.OrderBy(x => x.Item1))
        {
            if (cur == 0) last = val;
            cur += d;
            if (cur == 0) res += val - last;
        }
        Console.WriteLine(res);
    }
}
