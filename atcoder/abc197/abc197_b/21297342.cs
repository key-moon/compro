// detail: https://atcoder.jp/contests/abc197/submissions/21297342
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
        var hwxy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwxy[0];
        var w = hwxy[1];
        var x = hwxy[2];
        var y = hwxy[3];
        var ud = string.Join("", Enumerable.Repeat('#', w + 2));
        var grid = Enumerable.Repeat(0, h).Select(_ => $"#{Console.ReadLine()}#").Append(ud).Prepend(ud).ToArray();
        (int, int)[] ds = new[] { (0, 1), (0, -1), (1, 0), (-1, 0) };
        int res = 1;
        foreach (var (dy, dx) in ds)
        {
            var curx = x + dx;
            var cury = y + dy;
            while (grid[curx][cury] == '.')
            {
                res++;
                curx += dx;
                cury += dy;
            }
        }
        Console.WriteLine(res);
    }
}