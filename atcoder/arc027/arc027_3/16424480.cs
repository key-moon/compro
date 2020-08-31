// detail: https://atcoder.jp/contests/arc027/submissions/16424480
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
        var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var X = xy[0];
        var Y = xy[1];
        var n = int.Parse(Console.ReadLine());
        var maxHappiness = Enumerable.Repeat(0, X + 1).Select(_ => new long[X + Y + 1]).ToArray();
        for (int count = 0; count < n; count++)
        {
            var th = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var t = th[0];
            var h = th[1];
            for (int i = X - 1; i >= 0; i--)
                for (int j = 0; j <= X + Y - t; j++)
                    maxHappiness[i + 1][j + t] = Max(maxHappiness[i + 1][j + t], maxHappiness[i][j] + h);
                
        }
        Console.WriteLine(maxHappiness.Max(x => x.Max()));
    }
}