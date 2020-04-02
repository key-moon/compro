// detail: https://atcoder.jp/contests/abc082/submissions/11440290
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
        var n = long.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var res = a.GroupBy(x => x).Sum(x => x.Count() >= x.Key ? x.Count() - x.Key : x.Count());
        Console.WriteLine(res);
    }
}
