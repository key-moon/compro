// detail: https://atcoder.jp/contests/panasonic2020/submissions/10852395
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
        var abc = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a = abc[0];
        var b = abc[1];
        var c = abc[2];
        Console.WriteLine(c > a + b && 4 * a * b < (c - a - b) * (c - a - b) ? "Yes" : "No");
    }
}
