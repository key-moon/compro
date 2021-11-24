// detail: https://atcoder.jp/contests/abc093/submissions/27474047
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
        int q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            var ab = Console.ReadLine().Split().Select(long.Parse).ToArray();
            Console.WriteLine(Solve(ab[0], ab[1]));
        }
    }
    static long Solve(long a, long b)
    {
        if (a > b) (a, b) = (b, a);
        long res = 0;
        res += (a - 1) * 2;
        var mid = (long)Floor(Sqrt(a * b));
        while (a * b <= mid * mid) mid--;
        while ((mid + 1) * (mid + 1) < a * b) mid++;
        if (a < mid)
        {
            res += (mid - a) * 2;
            if (a * b <= mid * (mid + 1)) res--;
        }
        if (b - a >= 2) res++;
        return res;
    }
}