// detail: https://atcoder.jp/contests/abc174/submissions/16270998
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
        var nd = Console.ReadLine().Split().Select(long.Parse).ToArray();

        Console.WriteLine(Enumerable.Repeat(0, (int)nd[0]).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).Where(x => x[0] * x[0] + x[1] * x[1] <= nd[1] * nd[1]).Count());
    }
}
