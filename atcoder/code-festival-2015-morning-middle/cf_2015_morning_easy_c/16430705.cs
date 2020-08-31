// detail: https://atcoder.jp/contests/code-festival-2015-morning-middle/submissions/16430705
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
        var nkmr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nkmr[0];
        var k = nkmr[1];
        var m = nkmr[2];
        long r = nkmr[3];
        var s = Enumerable.Repeat(0, n - 1).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        if (r <= s.Append(0).OrderByDescending(x => x).Take(k).Average())
        {
            Console.WriteLine(0);
            return;
        }
        var res = r * k - s.OrderByDescending(x => x).Take(k - 1).Sum(x => (long)x);
        if (m < res) res = -1;
        Console.WriteLine(res);
    }
}