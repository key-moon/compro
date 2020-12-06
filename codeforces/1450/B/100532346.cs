// detail: https://codeforces.com/contest/1450/submission/100532346
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
        for (int i = 0; i < n; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var pts = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                var dist = Abs(pts[i][0] - pts[j][0]) + Abs(pts[i][1] - pts[j][1]);
                if (k < dist) goto end;
            }
            Console.WriteLine(1);
            return;
            end:;
        }
        Console.WriteLine(-1);
    }
}