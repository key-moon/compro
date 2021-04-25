// detail: https://atcoder.jp/contests/abc064/submissions/22076987
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
        var rgb = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = rgb[0];
        var g = rgb[1];
        var b = rgb[2];
        Console.WriteLine(int.Parse($"{r}{g}{b}") % 4 == 0 ? "YES" : "NO");
    }
}