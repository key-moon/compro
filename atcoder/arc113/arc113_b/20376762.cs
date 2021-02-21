// detail: https://atcoder.jp/contests/arc113/submissions/20376762
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
        var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = abc[0];
        a %= 10;
        var b = abc[1];
        var c = abc[2];
        var period = 0;
        {
            var pow = a;
            do
            {
                pow *= a;
                pow %= 10;
                period++;
            } while (pow != a);
        }
        var res = BigInteger.ModPow(a, BigInteger.ModPow(b, c, period) + period, 10);
        Console.WriteLine(res);
    }
}