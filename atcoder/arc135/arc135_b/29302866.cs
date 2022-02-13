// detail: https://atcoder.jp/contests/arc135/submissions/29302866
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
        var s = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long[] cur = new[] { 0L, 0L, 0L };
        long[] min = new[] { 0L, 0L, 0L };
        for (int i = 0; i < n - 1; i++)
        {
            var diff = s[i + 1] - s[i];
            cur[i % 3] += diff;
            min[i % 3] = Min(cur[i % 3], min[i % 3]);
        }
        List<long> res = new List<long>();
        res.AddRange(min.Select(x => -x));
        if (s[0] < res.Sum())
        {
            Console.WriteLine("No");
            return;
        }
        Console.WriteLine("Yes");
        res[2] += s[0] - res.Sum();
        for (int i = 1; i < s.Length; i++)
        {
            res.Add(s[i] - (res[^1] + res[^2]));
        }
        Trace.Assert(res.All(x => 0 <= x));
        Console.WriteLine(string.Join(" ", res));
    }
}