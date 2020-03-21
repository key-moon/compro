// detail: https://atcoder.jp/contests/agc038/submissions/11039582
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
        var hwab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwab[0];
        var w = hwab[1];
        var a = hwab[2];
        var b = hwab[3];
        int[][] res = Enumerable.Repeat(0, h).Select(_ => new int[w]).ToArray();
        for (int i = b; i < h; i++)
            for (int j = 0; j < a; j++)
                res[i][j] = 1;
        for (int i = 0; i < b; i++)
            for (int j = a; j < w; j++)
                res[i][j] = 1;

        Console.WriteLine(string.Join("\n", res.Select(x => string.Join("", x))));
    }
}