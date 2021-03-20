// detail: https://atcoder.jp/contests/joi2011yo/submissions/21050360
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
        int n = int.Parse(Console.ReadLine());
        var k = int.Parse(Console.ReadLine());

        var inSquare = (n + 1) / 2;
        for (int i = 0; i < k; i++)
        {
            var xy = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var x = xy[0];
            var y = xy[1];
            x = Min(x, n + 1 - x);
            y = Min(y, n + 1 - y);
            Console.WriteLine((Min(x, y) - 1) % 3 + 1);
        }
    }
}