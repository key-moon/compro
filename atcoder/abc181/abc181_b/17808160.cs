// detail: https://atcoder.jp/contests/abc181/submissions/17808160
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
        long res = 0;
        for (int i = 0; i < n; i++)
        {
            var ab = Console.ReadLine().Split().Select(long.Parse).ToArray();
            res += ab[1] * (ab[1] + 1) / 2;
            res -= ab[0] * (ab[0] - 1) / 2;
        }
        Console.WriteLine(res);
    }
}