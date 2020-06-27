// detail: https://atcoder.jp/contests/abc161/submissions/14708903
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
        var nk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var k = nk[1];
        var n = nk[0] % k;
        Console.WriteLine(Min(n, k - n));
    }
}