// detail: https://atcoder.jp/contests/abc251/submissions/31658645
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
        var res = 
            Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split())
            .Select((x, y) => (x[0], int.Parse(x[1]), y))
            .GroupBy(x => x.Item1)
            .Select(x => x.First())
            .OrderByDescending(x => x.Item2)
            .ThenBy(x => x.y)
            .First().y;
        Console.WriteLine(res + 1);
    }
}