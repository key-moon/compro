// detail: https://atcoder.jp/contests/abc225/submissions/26890899
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
        int n = Console.ReadLine().Split().Select(int.Parse).ToArray()[0];

        var a = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var m = a[0].Length;
        var res = true;
        res &= (a[0][0] - 1) % 7 + m <= 7;
        res &= a.Zip(a.Skip(1), (x, y) => x.Zip(y, (x, y) => y - x == 7).All(x => x)).All(x => x);

        Console.WriteLine(res ? "Yes" : "No");
    }
}