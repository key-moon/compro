// detail: https://atcoder.jp/contests/code-festival-2014-quala/submissions/16428524
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
        var a = ab[0];
        var b = ab[1];
        var startFraction = a % 400;
        var total = b / 400 - a / 400 - 1;
        var endFraction = b % 400;
        int res = total * 97;
        for (int i = startFraction + 400; i < 800; i++)
            if (DateTime.IsLeapYear(i)) res++;
        for (int i = 400; i <= endFraction + 400; i++)
            if (DateTime.IsLeapYear(i)) res++;
        Console.WriteLine(res);

    }
}