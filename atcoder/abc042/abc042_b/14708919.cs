// detail: https://atcoder.jp/contests/abc042/submissions/14708919
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
        var nl = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nl[0];


        Console.WriteLine(string.Join("", Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).OrderBy(x => x)));
    }
}