// detail: https://atcoder.jp/contests/tkppc6-1/submissions/25259440
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
        var n = nm[0];
        var m = nm[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var colors = a.Distinct().Count();
        Console.WriteLine(colors + Min(m, a.Length - colors));
    }
}