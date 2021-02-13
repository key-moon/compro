// detail: https://atcoder.jp/contests/arc112/submissions/20142934
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            var lr = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var l = lr[0];
            var r = lr[1];
            var cnt = Max(r - l * 2 + 1, 0);
            Console.WriteLine(cnt * (cnt + 1) / 2);
        }
    }
}
