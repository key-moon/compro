// detail: https://atcoder.jp/contests/abc223/submissions/26636290
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
        var xyabc = Console.ReadLine().Split().Select(long.Parse).ToArray();


        bool Solve2(long y, long x, long b, long c)
        {
            var bWidth = (b + y - 1) / y;
            var cWidth = x - bWidth;
            if (cWidth <= 0) return false;
            if (cWidth * y < c) return false;
            Trace.Assert(b <= bWidth * y);
            Trace.Assert(c <= cWidth * y);
            return true;
        }
        bool Solve(long y, long x, long a, long b, long c)
        {
            var awidth = (a + y - 1) / y;
            var remainWidth = x - awidth;
            if (remainWidth <= 0) return false;
            Trace.Assert(a <= awidth * y);
            return Solve2(y, remainWidth, b, c) || Solve2(remainWidth, y, b, c);
        }

        var x = xyabc[0];
        var y = xyabc[1];
        var a = xyabc[2];
        var b = xyabc[3];
        var c = xyabc[4];

        bool res = false;
        res |= Solve(y, x, a, b, c);
        res |= Solve(y, x, b, a, c);
        res |= Solve(y, x, c, a, b);

        res |= Solve(x, y, a, b, c);
        res |= Solve(x, y, b, a, c);
        res |= Solve(x, y, c, a, b);


        Console.WriteLine(res ? "Yes" : "No");
    }
}