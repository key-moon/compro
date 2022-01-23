// detail: https://atcoder.jp/contests/abc236/submissions/28721479
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
        var s = Console.ReadLine().ToArray();
        var ab = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        (s[ab[0]], s[ab[1]]) = (s[ab[1]], s[ab[0]]);
        Console.WriteLine(s);
    }
}