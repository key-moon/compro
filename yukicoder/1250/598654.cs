// detail: https://yukicoder.me/submissions/598654
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
        var nh = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nh[0];
        long h = nh[1];
        foreach (var a in Console.ReadLine().Split().Select(long.Parse)) h /= GCD(h, Abs(a));
        Console.WriteLine(h == 1 ? "YES" : "NO");
    }

    static long GCD(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            a %= b;
            if (a == 0) return b;
            b %= a;
        }
    }
}