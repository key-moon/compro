// detail: https://atcoder.jp/contests/indeednow-quala/submissions/16434459
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
        var a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).OrderByDescending(x => x).Where(x => x != 0).ToArray();
        var q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            var query = int.Parse(Console.ReadLine());
            int res = query >= a.Length ? 0 : a[query] + 1;
            Console.WriteLine(res);
        }
    }
}