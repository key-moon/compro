// detail: https://atcoder.jp/contests/abc175/submissions/16211311
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
        var xkd = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var x = xkd[0];
        var k = xkd[1];
        var d = xkd[2];
        x *= Sign(x);
        var need = x / d;
        if (k < need)
        {
            Console.WriteLine(x - k * d);
            return;
        }
        x -= need * d;
        k -= need;

        Console.WriteLine(k % 2 == 0 ? x : d - x);
    }
}