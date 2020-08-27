// detail: https://atcoder.jp/contests/abc148/submissions/16271378
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split();

        Console.WriteLine(string.Join("", a[0].Zip(a[1], (x, y) => $"{x}{y}")));
    }
}