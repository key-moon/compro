// detail: https://atcoder.jp/contests/abc217/submissions/25558006
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
        var set = new string[]{ "ABC", "ARC", "AGC", "AHC" };
        Console.WriteLine(set.Except(Enumerable.Repeat(0, 3).Select(_ => Console.ReadLine())).First());
    }
}