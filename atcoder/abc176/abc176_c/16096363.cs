// detail: https://atcoder.jp/contests/abc176/submissions/16096363
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long max = 0;
        long res = 0;
        for (int i = 0; i < a.Length; i++)
        {
            max = Max(a[i], max);
            res += max - a[i];
        }
        Console.WriteLine(res);
    }
}
