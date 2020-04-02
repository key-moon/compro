// detail: https://atcoder.jp/contests/abc095/submissions/11449780
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
        var abcxy = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a = abcxy[0];
        var b = abcxy[1];
        var c2 = Min(abcxy[2] * 2, a + b);
        var X = abcxy[3];
        var Y = abcxy[4];
        Console.WriteLine(Min(Max(X, Y) * c2, Min(X, Y) * c2 + (X < Y ? (Y - X) * b : (X - Y) * a)));
    }
}