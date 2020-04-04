// detail: https://atcoder.jp/contests/abc161/submissions/11490741
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
        var n = nk[0];
        var k = nk[1];
        Console.WriteLine(Min(n % k, k - n % k));
    }
}