// detail: https://atcoder.jp/contests/abc214/submissions/25022173
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

        var n = int.Parse(Console.ReadLine());

        var s = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var t = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long[] res = new long[2 * n];
        for (int i = 0; i < res.Length; i++)
            res[i] = t[i % n];
        for (int i = 1; i < res.Length; i++)
        {
            res[i] = Min(res[i], res[i - 1] + s[(i - 1) % n]);
        }

        Console.WriteLine(string.Join("\n", res.Skip(n)));
    }
}
