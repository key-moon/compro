// detail: https://atcoder.jp/contests/abc216/submissions/25404692
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
        var res = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).Distinct().Count() != n;

        Console.WriteLine(res ? "Yes" : "No");
    }
}