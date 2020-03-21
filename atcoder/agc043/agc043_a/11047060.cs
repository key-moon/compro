// detail: https://atcoder.jp/contests/agc043/submissions/11047060
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        var map = Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine().ToArray()).ToArray();
        var res = 0;
        var steps = Enumerable.Range(0, h).Select(_ => Enumerable.Repeat(int.MaxValue, w).ToArray()).ToArray();
        steps[0][0] = map[0][0] == '#' ? 1 : 0;
        for (int i = 0; i < h + w; i++)
        {
            for (int y = 0, x = i; y < h && 0 <= x; y++, x--)
            {
                if (w <= x) continue;
                
                if (y != 0) 
                    steps[y][x] = Min(steps[y][x], steps[y - 1][x] + (map[y - 1][x] != map[y][x] ? 1 : 0));
                
                if (x != 0) 
                    steps[y][x] = Min(steps[y][x], steps[y][x - 1] + (map[y][x - 1] != map[y][x] ? 1 : 0));
            }
        }
        Console.WriteLine((steps.Last().Last() + 1) / 2);
    }
}
