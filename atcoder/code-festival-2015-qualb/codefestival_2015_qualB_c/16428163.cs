// detail: https://atcoder.jp/contests/code-festival-2015-qualb/submissions/16428163
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
        var n = nm[0];
        var m = nm[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(n >= m && a.OrderByDescending(x => x).Zip(b.OrderByDescending(x => x), (x, y) => x >= y).All(x => x) ? "YES" : "NO");
    }
}
