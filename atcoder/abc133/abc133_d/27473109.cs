// detail: https://atcoder.jp/contests/abc133/submissions/27473109
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long[] res = Enumerable.Repeat(long.MaxValue / 2, n).ToArray();
        res[0] = 0;
        int ind = 0;
        do
        {
            var nxt1 = (ind + 1) % n;
            var nxt2 = (ind + 2) % n;
            var d = a[nxt1] - a[ind];
            res[nxt2] = res[ind] + d * 2;
            ind = nxt2;
        } while (ind != 0);
        Trace.Assert(res[0] == 0);
        var diff = a.Sum() - res.Sum();
        Trace.Assert(diff % n == 0);
        var avg = diff / n;
        for (int i = 0; i < n; i++) res[i] += avg;
        Console.WriteLine(string.Join(" ", res));
    }
}