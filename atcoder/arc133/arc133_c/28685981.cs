// detail: https://atcoder.jp/contests/arc133/submissions/28685981
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
        var hwk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwk[0];
        var w = hwk[1];
        long k = hwk[2];
        var a = Console.ReadLine().Split().Select(x => ((k - 1) * w - long.Parse(x)) % k).ToArray();
        var b = Console.ReadLine().Split().Select(x => ((k - 1) * h - long.Parse(x)) % k).ToArray();

        var asum = a.Sum();
        var bsum = b.Sum();

        if (asum % k != bsum % k)
        {
            Console.WriteLine(-1);
            return;
        }

        var res = (k - 1) * h * w - Max(asum, bsum);
        Console.WriteLine(res);
    }
}