// detail: https://atcoder.jp/contests/abc168/submissions/13340802
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
        var abhm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = abhm[0];
        var b = abhm[1];
        var h = abhm[2];
        var m = abhm[3];
        var tandeg = (PI * 2 / 12) * h + (PI * 2 / 12 / 60) * m;
        var choudeg = (PI * 2 / 60) * m;
        var deg = Abs(tandeg - choudeg);
        var cos = Cos(deg) * a;
        var sin = Sin(deg) * a;
        Console.WriteLine(Sqrt(Pow(b - cos, 2) + Pow(Abs(sin), 2)));
    }
}