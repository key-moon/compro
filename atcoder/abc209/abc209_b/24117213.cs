// detail: https://atcoder.jp/contests/abc209/submissions/24117213
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
        var nx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nx[0];
        var x = nx[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(a.Sum() - n / 2 <= x ? "Yes" : "No");
    }
}