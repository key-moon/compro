// detail: https://atcoder.jp/contests/abc188/submissions/19313768
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
        var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(xy.Max() - xy.Min() < 3 ? "Yes" : "No");
    }
}