// detail: https://atcoder.jp/contests/tkppc6-1/submissions/25259387
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var less = a.Count(x => x != -1 && x < a[0]);
        var more = a.Count(x => x != -1 && a[0] < x);
        Console.WriteLine(less <= n - 1 && more <= n - 1 ? "Yes" : "No");
    }
}