// detail: https://atcoder.jp/contests/arc104/submissions/17166904
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
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var y = (ab[0] - ab[1]) / 2;
        var x = ab[0] - y;
        Console.WriteLine($"{x} {y}");
    }
}