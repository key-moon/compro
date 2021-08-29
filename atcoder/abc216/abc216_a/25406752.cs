// detail: https://atcoder.jp/contests/abc216/submissions/25406752
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
        var xy = Console.ReadLine().Split('.').Select(int.Parse).ToArray();
        if (xy[1] <= 2) Console.WriteLine($"{xy[0]}-");
        else if (xy[1] <= 6) Console.WriteLine(xy[0]);
        else Console.WriteLine($"{xy[0]}+");
    }
}