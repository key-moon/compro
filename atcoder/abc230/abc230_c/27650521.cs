// detail: https://atcoder.jp/contests/abc230/submissions/27650521
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
        var nab = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nab[0];
        var a = nab[1] - 1;
        var b = nab[2] - 1;
        var pqrs = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var p = pqrs[0] - 1;
        var q = pqrs[1] - 1;
        var r = pqrs[2] - 1;
        var s = pqrs[3] - 1;

        char[][] grid = Enumerable.Repeat(0, (int)(q - p + 1)).Select(_ => new char[s - r + 1]).ToArray();
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                var reali = p + i;
                var realj = r + j;
                var k = reali - a;

                bool shouldPaint = false;
                shouldPaint |= b + k == realj;
                shouldPaint |= b - k == realj;
                grid[i][j] = shouldPaint ? '#' : '.';
            }
        }

        Console.WriteLine(string.Join("\n", grid.Select(x => string.Join("", x))));
    }
}