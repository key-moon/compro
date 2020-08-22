// detail: https://atcoder.jp/contests/abc176/submissions/16124812
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
        var nxt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nxt[0];
        var x = nxt[1];
        var t = nxt[2];
        Console.WriteLine(((n + x - 1) / x) * t);
    }
}