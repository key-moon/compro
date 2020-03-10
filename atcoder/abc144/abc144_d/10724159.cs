// detail: https://atcoder.jp/contests/abc144/submissions/10724159
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
        var abx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        double a = abx[0];
        double b = abx[1];
        double x = abx[2];
        var triangle = x / a;
        double res;
        if (triangle < a * b / 2)
        {
            var width = triangle * 2 / b;
            res = Acos(width / Sqrt(b * b + width * width)) / PI * 180;
        }
        else
        {
            var height = (a * b - triangle) * 2 / a;
            res = Asin(height / Sqrt(height * height + a * a)) / PI * 180;
        }
        Console.WriteLine(res);
    }
}