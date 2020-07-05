// detail: https://atcoder.jp/contests/abc173/submissions/14999543
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
        long n = int.Parse(Console.ReadLine()) - 1;

        long res = (n + 1) * (n * n + 5 * n + 6) / 6;
        for (int i = 0; i < n; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).OrderBy(x => x).ToArray();
            long lLength = st[0] + 1;
            long rLength = n - st[1] + 1;
            res -= lLength * rLength;
        }
        Console.WriteLine(res);
    }
}
