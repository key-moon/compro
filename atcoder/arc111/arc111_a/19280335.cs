// detail: https://atcoder.jp/contests/arc111/submissions/19280335
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
        var nm = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var M = m * m;
        Console.WriteLine(Power(n, M) / m);
    }

    static long Power(long n, long m)
    {
        long pow = 10;
        long res = 1;
        while (n > 0)
        {
            if ((n & 1) == 1) res = (res * pow) % m;
            pow = (pow * pow) % m;
            n >>= 1;
        }
        return res;
    }
}