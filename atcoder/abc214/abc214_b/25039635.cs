// detail: https://atcoder.jp/contests/abc214/submissions/25039635
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
        var st = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var s = st[0];
        var t = st[1];
        int res = 0;
        for (int a = 0; a <= s; a++)
        {
            for (int b = 0; b <= s - a; b++)
            {
                for (int c = 0; c <= s - a - b; c++)
                {
                    if (a * b * c <= t) res++;
                }
            }
        }
        Console.WriteLine(res);
    }
}