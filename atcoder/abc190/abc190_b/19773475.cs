// detail: https://atcoder.jp/contests/abc190/submissions/19773475
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
        var nsd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Enumerable.Repeat(0, nsd[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        Console.WriteLine(a.Any(x => x[0] < nsd[1] && nsd[2] < x[1]) ? "Yes" : "No");
    }
}
