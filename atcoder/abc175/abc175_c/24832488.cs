// detail: https://atcoder.jp/contests/abc175/submissions/24832488
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
using static System.Numerics.BigInteger;
public static class P
{
    public static void Main()
    {
        var xkd = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
        var x = Abs(xkd[0]);
        var k = xkd[1];
        var d = xkd[2];

        BigInteger res;
        if (k * d <= x)
        {
            res = x - k * d;
        }
        else
        {
            if (k % 2 == 1) x = Abs(x - d);
            var modres = x % (2 * d);
            res = Min(modres, 2 * d - modres);
        }
        Console.WriteLine(res);
    }
}
