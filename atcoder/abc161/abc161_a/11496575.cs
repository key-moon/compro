// detail: https://atcoder.jp/contests/abc161/submissions/11496575
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var tmp = a[0];
        a[0] = a[1];
        a[1] = tmp;
        tmp = a[0];
        a[0] = a[2];
        a[2] = tmp;

        Console.WriteLine(string.Join(" ", a));
    }
}