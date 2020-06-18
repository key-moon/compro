// detail: https://atcoder.jp/contests/indeednow-qualb/submissions/14460273
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
        var xy1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var xy2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Abs(xy1[0] - xy2[0]) + Abs(xy1[1] - xy2[1]) + 1);
    }
}