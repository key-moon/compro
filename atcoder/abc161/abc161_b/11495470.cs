// detail: https://atcoder.jp/contests/abc161/submissions/11495470
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var threshold = a.Sum() / (nm[1] * 4.0);

        Console.WriteLine(a.Count(x => x >= threshold) >= nm[1] ? "Yes" : "No");
    }
}