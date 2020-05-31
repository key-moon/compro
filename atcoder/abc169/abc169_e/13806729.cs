// detail: https://atcoder.jp/contests/abc169/submissions/13806729
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
        int n = int.Parse(Console.ReadLine());
        var ab = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var a = ab.Select(x => x[0]).OrderBy(x => x).ToArray();
        var b = ab.Select(x => x[1]).OrderBy(x => x).ToArray();
        int getMed(int[] a) => a.Length % 2 == 0 ? (a[a.Length / 2 - 1] + a[a.Length / 2]) : a[a.Length / 2] * 2;
        var diff = getMed(b) - getMed(a);
        Console.WriteLine(n % 2 == 0 ? diff + 1 : diff / 2 + 1);
    }
}