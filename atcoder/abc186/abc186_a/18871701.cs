// detail: https://atcoder.jp/contests/abc186/submissions/18871701
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
        var nw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(nw[0] / nw[1]);
    }
}