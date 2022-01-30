// detail: https://atcoder.jp/contests/abc237/submissions/28907956
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

        var a = Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var b = Enumerable.Range(0, hw[1]).Select(x => a.Select(y => y[x]).ToArray()).ToArray();

        Console.WriteLine(string.Join("\n", b.Select(x => string.Join(" ", x))));
    }
}