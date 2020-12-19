// detail: https://atcoder.jp/contests/abc186/submissions/18871326
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
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        var a = Enumerable.Repeat(0, h).SelectMany(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var min = a.Min();
        Console.WriteLine(a.Sum(x => x - min)); ;
    }
}