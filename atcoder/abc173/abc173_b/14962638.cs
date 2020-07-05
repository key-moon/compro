// detail: https://atcoder.jp/contests/abc173/submissions/14962638
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

        var a = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).ToArray();
        string[] h = new[] { "AC", "WA", "TLE", "RE" };

        Console.WriteLine(string.Join("\n", h.Select(x => $"{x} x {a.Count(y => y == x)}")));
    }
}
