// detail: https://atcoder.jp/contests/abc204/submissions/23246486
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var x = xy[0];
        var y = xy[1];
        Console.WriteLine(x == y ? x : 3 - x - y);
    }
}
