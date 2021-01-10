// detail: https://atcoder.jp/contests/abc188/submissions/19324634
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
        var nc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<(int, long)> q = new List<(int, long)>();
        for (int i = 0; i < nc[0]; i++)
        {
            var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            q.Add((abc[0], abc[2]));
            q.Add((abc[1] + 1, -abc[2]));
        }
        long res = 0;
        int prev = 0;
        long curSum = 0;
        foreach (var group in q.GroupBy(x => x.Item1).OrderBy(x => x.Key))
        {
            var cur = group.Key;
            var d = group.Sum(x => x.Item2);

            res += Min(nc[1], curSum) * (cur - prev);

            curSum += d;
            prev = cur;
        }
        Console.WriteLine(res);
    }
}