// detail: https://atcoder.jp/contests/abc180/submissions/17454013
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
        var x = Console.ReadLine().Split().Select(long.Parse).ToArray();
        Console.WriteLine(x.Sum(Abs));
        Console.WriteLine(Sqrt(x.Sum(x => x * x)));
        Console.WriteLine(x.Max(Abs));
    }
}