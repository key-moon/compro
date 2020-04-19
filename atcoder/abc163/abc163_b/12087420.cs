// detail: https://atcoder.jp/contests/abc163/submissions/12087420
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var m = nm[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Max((nm[0] - a.Sum()), -1));
    }
}