// detail: https://atcoder.jp/contests/nikkei2019-qual/submissions/11449723
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
        var a = Console.ReadLine();
        var b = Console.ReadLine();
        var c = Console.ReadLine();
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            res += new[] { a[i], b[i], c[i] }.Distinct().Count() - 1;
        }
        Console.WriteLine(res);
    }
}