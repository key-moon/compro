// detail: https://atcoder.jp/contests/abc098/submissions/16040831
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
        var s = Console.ReadLine();
        int res = 0;
        for (int i = 1; i < n; i++)
        {
            var cnt = s.Substring(0, i).Intersect(s.Substring(i)).ToArray();
            res = Max(res, cnt.Length);
        }
        Console.WriteLine(res);
    }
}
