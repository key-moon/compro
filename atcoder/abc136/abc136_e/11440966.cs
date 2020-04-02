// detail: https://atcoder.jp/contests/abc136/submissions/11440966
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var sum = a.Sum(x => x);
        var max = -1L;
        for (int i = 1; i * i <= sum; i++)
        {
            if (sum % i != 0) continue;
            if (IsValid(a, i, nk[1])) max = Max(max, i);
            if (IsValid(a, sum / i, nk[1])) max = Max(max, sum / i);
        }
        Console.WriteLine(max);
    }
    static bool IsValid(long[] a, long m, int k)
    {
        var p = a.Select(x => x % m).OrderBy(x => x).ToArray();
        var valid = -1;
        var invalid = a.Length;
        while (invalid - valid > 1)
        {
            var mid = (invalid + valid) / 2;
            if (p.Take(mid).Sum() <= p.Skip(mid).Select(x => m - x).Sum()) valid = mid;
            else invalid = mid;
        }
        return p.Take(valid).Sum() <= k;
    }
}