// detail: https://atcoder.jp/contests/abc170/submissions/14285730
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
        var x = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Array.IndexOf(x, 0) + 1);
    }
}
