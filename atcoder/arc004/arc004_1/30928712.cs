// detail: https://atcoder.jp/contests/arc004/submissions/30928712
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
        var pts = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();

        var res = 0.0;
        for (int i = 0; i < n; i++)
        {
            var (x1, y1) = (pts[i][0], pts[i][1]);
            for (int j = i; j < n; j++)
            {
                var (x2, y2) = (pts[j][0], pts[j][1]);
                res = Max(res, Sqrt(Pow(x2 - x1, 2) + Pow(y2 - y1, 2)));                
            }
        }
        Console.WriteLine(res);
    }
}