// detail: https://yukicoder.me/submissions/598664
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
        var abcdef = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = abcdef[0];
        var b = abcdef[1];
        var c = abcdef[2];
        var d = abcdef[3];
        var e = abcdef[4];
        var f = abcdef[5];
        var y = (double)(c * d - a * f) / (b * d - a * e);
        var x = (c - b * y) / a;
        Console.WriteLine($"{x} {y}");
    }
}