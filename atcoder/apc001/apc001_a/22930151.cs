// detail: https://atcoder.jp/contests/apc001/submissions/22930151
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
        var xy = Console.ReadLine().Split().Select(long.Parse).ToArray();
        if (xy[0] % xy[1] == 0) Console.WriteLine(-1);
        else Console.WriteLine(xy[0]);
    }
}