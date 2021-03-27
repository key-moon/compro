// detail: https://atcoder.jp/contests/abc197/submissions/21306243
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
        var xc = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();
        (long pos, long time)[] cur = new (long pos, long time)[] { (0, 0) };
        foreach (var item in xc.GroupBy(x => x[1]).OrderBy(x => x.Key))
        {
            var c = item.Key;
            var group = item.Select(x => x[0]).ToArray();
            (long, long)[] nxt;
            if (group.Length == 1)
            {
                var nxtpos = group.Single();
                nxt = new[] { (nxtpos, cur.Min(x => Abs(x.pos - nxtpos) + x.time)) };
            }
            else
            {
                var max = group.Max(x => x);
                var min = group.Min(x => x);
                var dist = max - min;
                nxt = new[] {
                    (max, cur.Min(x => Abs(x.pos - min) + x.time) + dist),
                    (min, cur.Min(x => Abs(x.pos - max) + x.time) + dist)
                };
            }
            cur = nxt;
        }
        Console.WriteLine(cur.Min(x => x.time + Abs(x.pos)));
    }
}